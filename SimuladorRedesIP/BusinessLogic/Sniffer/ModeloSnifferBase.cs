using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedesIP.SOA;

namespace BusinessLogic.Sniffer
{
    public class ModeloSnifferBase
    {
        private List<IVisualizacion> _vistas = new List<IVisualizacion>();

        public List<IVisualizacion> Vistas
        {
            get { return _vistas; }
        }
        public virtual void Dispose()
        {
            _vistas = null;
        }
        public int NumeroDeClientes { get { return _vistas.Count; } }

        public void AgregarVista(IVisualizacion vista)
        {
            Vistas.Add(vista);
        }
        public virtual void EliminarVista(IVisualizacion vista)
        {
                Vistas.Remove(vista);
        }
        public void EliminarSnifferTotal()
        {
            List<IVisualizacion> vistasABorrar = new List<IVisualizacion>();
            foreach (IVisualizacion vist in Vistas)
            {
                vistasABorrar.Add(vist);

            }
            foreach (IVisualizacion vista in vistasABorrar)
            {
                EliminarVista(vista);
            }
        }


    }
}
