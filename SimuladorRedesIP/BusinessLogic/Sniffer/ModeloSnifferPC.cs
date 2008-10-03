using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedesIP.Modelos.Logicos.Equipos;
using RedesIP.SOA;

namespace BusinessLogic.Sniffer
{
    public class ModeloSnifferPC
    {
        private ComputadorLogico _pc;
        private List<IVisualizacion> _vistas;
        public ModeloSnifferPC(ComputadorLogico pc, List<IVisualizacion> vistas)
        {
           _pc=pc;
            _vistas = vistas;
            EscucharEventos();
        }
        private void EscucharEventos()
        {
            _pc.CapaRed.CapaDatos.PaqueteEncapsulado += new EventHandler<BusinessLogic.Datos.PaqueteEncapsuladoEventArgs>(CapaDatos_PaqueteEncapsulado);
            _pc.CapaRed.CapaDatos.PaqueteDesEncapsulado += new EventHandler<BusinessLogic.Datos.PaqueteDesencapsuladoEventArgs>(CapaDatos_PaqueteDesEncapsulado);
        }

        void CapaDatos_PaqueteDesEncapsulado(object sender, BusinessLogic.Datos.PaqueteDesencapsuladoEventArgs e)
        {
            throw new NotImplementedException();
        }

        void CapaDatos_PaqueteEncapsulado(object sender, BusinessLogic.Datos.PaqueteEncapsuladoEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
