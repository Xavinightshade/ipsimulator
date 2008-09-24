using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedesIP.Modelos.Equipos.Componentes;

namespace BusinessLogic.Componentes
{
   public class RouteTable
    {
       private List<EntradaTablaRouter> _tablaRouter = new List<EntradaTablaRouter>();

       public void IngresarEntrada(uint red, PuertoEthernetCompleto puerto)
       {
           EntradaTablaRouter entrada = new EntradaTablaRouter();
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

    }
}
