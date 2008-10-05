using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedesIP.Modelos.Logicos.Equipos;
using RedesIP.SOA;
using RedesIP.SOA.Elementos;
using RedesIP.Modelos.Equipos.Componentes;
using SOA.Datos;

namespace BusinessLogic.Sniffer
{
    public class ModeloSnifferSwitch
    {
        private SwitchLogico _switch;
        private List<IVisualizacion> _vistas=new List<IVisualizacion>();
        public ModeloSnifferSwitch(SwitchLogico swi)
        {
            _switch = swi;
            EscucharTablasDeFiltro();
        }
        private void EscucharTablasDeFiltro()
        {
            _switch.SwitchTable.CambioDeTablaDeFiltro += new EventHandler<TiempoEventArgs>(OnCambioDeTabla);


        }
        public void AgregarVista(IVisualizacion vista)
        {
            _vistas.Add(vista);
        }


        private void OnCambioDeTabla(object sender, TiempoEventArgs e)
        {
            SwitchTableSOA tablaSOA = new SwitchTableSOA();
            foreach (KeyValuePair<string, PuertoEthernetLogicoBase> par in _switch.SwitchTable.TablaDeFiltro)
            {
                AsociacionPuertoMACAddressSOA aso = new AsociacionPuertoMACAddressSOA();
                aso.Puerto = new PuertoBaseSOA(par.Value.Id, par.Value.Nombre);
                aso.DescPuerto = par.Value.Nombre;
                aso.MacAddress = par.Key;
                tablaSOA.Asociaciones.Add(aso);
            }
            MensajeSwitchTableSOA mensajeTablaSwitch = new MensajeSwitchTableSOA(_switch.Id, e.HoraDeRecepcion);
            mensajeTablaSwitch.SwiTable = tablaSOA;
            foreach (IVisualizacion vist in _vistas)
            {
                vist.EnviarCambioDeTablaDeSwitch(mensajeTablaSwitch);

            }

        }
    }
}
