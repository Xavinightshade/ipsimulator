using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedesIP.Modelos.Equipos.Componentes;
using SOA.Componentes;

namespace BusinessLogic.Componentes
{
   public class RouteTable
    {
        private List<EntradaTablaRouter> _tablaRouterEstatico = new List<EntradaTablaRouter>();



       public void IngresarEntrada(Guid id,string red,int? mask,string nextHopIP, PuertoEthernetCompleto puerto)
       {
           EntradaTablaRouter entrada=new EntradaTablaRouter(id);
           entrada.Puerto = puerto;
           entrada.Red = red;
           entrada.Mask = mask;
           entrada.NextHopIP = nextHopIP;
           _tablaRouterEstatico.Add(entrada);
       }
       public EntradaTablaRouter BuscarRutaEnRutasInternas(string ipAddress)
       {
           foreach (EntradaTablaRouter entrada in CalcularRutasInternas())
           {
               uint valorRedPuerto=IPAddressFactory.GetRed(entrada.Puerto.IPAddress,entrada.Puerto.Mascara.Value);
               uint valorRedIpAddress=IPAddressFactory.GetRed(ipAddress,entrada.Puerto.Mascara.Value);
               if (valorRedIpAddress==valorRedPuerto)
               {
                   return entrada;
               }
           }
           return null;
       }

       public EntradaTablaRouter BuscarPuertoEnRutasEstaticas(string ipAddress)
       {
           foreach (EntradaTablaRouter entrada in _tablaRouterEstatico)
           {
               uint valorRedPuerto = IPAddressFactory.GetRed(entrada.Red, entrada.Mask.Value);
               uint valorRedIpAddress = IPAddressFactory.GetRed(ipAddress, entrada.Puerto.Mascara.Value);

               if (valorRedIpAddress == valorRedPuerto)
               {
                   return entrada;
               }
           }
           return null;
       }
       List<PuertoEthernetCompleto> _puertos;
       public RouteTable(List<PuertoEthernetCompleto> puertos)
       {
           _puertos=puertos;
       }

       internal List<RutaSOA> GetRutas()
       {
           return LlenarRutas(_tablaRouterEstatico);
       }
       private List<RutaSOA> LlenarRutas(List<EntradaTablaRouter> entradas)
       {
           List<RutaSOA> rutas = new List<RutaSOA>();
           foreach (EntradaTablaRouter item in entradas)
           {
               RutaSOA ruta = new RutaSOA(item.Id);
               ruta.IdPuerto = item.Puerto.Id;
               ruta.Red = item.Red;
               ruta.NombrePuerto = item.Puerto.Nombre;
               ruta.NextHopIP = item.NextHopIP;
               ruta.Mask = item.Mask;
               rutas.Add(ruta);
           }
           return rutas;
       }
       internal void LimpiarRutas()
       {
           _tablaRouterEstatico.Clear();
       }

       private List<EntradaTablaRouter> CalcularRutasInternas()
       {
           List<EntradaTablaRouter> rutasInternas = new List<EntradaTablaRouter>();
           foreach (PuertoEthernetCompleto puerto in _puertos)
           {
               if (!puerto.Habilitado)
                   continue;
               if ((puerto.IPAddress == null) || (puerto.Mascara == null))
                   continue;
               EntradaTablaRouter ruta = new EntradaTablaRouter(Guid.Empty);
               ruta.Mask = puerto.Mascara;
               ruta.Puerto = puerto;                
              ruta.Red = IPAddressFactory.GetRedRep(ruta.Puerto.IPAddress, ruta.Puerto.Mascara.Value);

               rutasInternas.Add(ruta);
           }
           return rutasInternas;
       }

       internal List<RutaSOA> GetRutasInternas()
       {
           return LlenarRutas(CalcularRutasInternas());
       }
    }
}
