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
        private List<EntradaTablaRouter> _tablaRouter = new List<EntradaTablaRouter>();

        public List<EntradaTablaRouter> TablaRouter
        {
            get { return _tablaRouter; }
        }

       public void IngresarEntrada(Guid id,uint red, PuertoEthernetCompleto puerto)
       {
           EntradaTablaRouter entrada=new EntradaTablaRouter(id);
           entrada.Puerto = puerto;
           entrada.Red = red;
           _tablaRouter.Add(entrada);
       }
       public PuertoEthernetCompleto BuscarPuertoDeLaRed(uint red)
       {
           foreach (EntradaTablaRouter entrada in _tablaRouter)
           {
               if (entrada.Red==red)
               {
                   return entrada.Puerto;
               }
           }
           return null;
       }


       internal List<RutaSOA> GetRutas()
       {
           List<RutaSOA> rutas = new List<RutaSOA>();
           foreach (EntradaTablaRouter item in _tablaRouter)
           {
               RutaSOA ruta = new RutaSOA(item.Id);
               ruta.IdPuerto = item.Puerto.Id;
               ruta.Red = IPAddressFactory.GetIpRep(item.Red);
               ruta.NombrePuerto = item.Puerto.Nombre;
               rutas.Add(ruta);
           }
           return rutas;
       }

       internal void LimpiarRutas()
       {
           _tablaRouter.Clear();
       }
    }
}
