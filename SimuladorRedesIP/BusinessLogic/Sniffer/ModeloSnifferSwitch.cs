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
    public class ModeloSnifferSwitch:ModeloSnifferBase
    {
        private SwitchLogico _switch;
        public ModeloSnifferSwitch(SwitchLogico swi)
        {
            _switch = swi;
            EscucharTablasDeFiltro();
        }

        private void EscucharTablasDeFiltro()
        {
            _switch.SwitchTable.CambioDeTablaDeFiltro += new EventHandler<TiempoEventArgs>(OnCambioDeTabla);


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
            foreach (IVisualizacion vist in Vistas)
            {
                vist.EnviarCambioDeTablaDeSwitch(mensajeTablaSwitch);

            }

        }
        public override void Dispose()
        {
            base.Dispose();
            _switch = null;
        }
        public override void EliminarVista(IVisualizacion vista)
        {
            base.EliminarVista(vista);
            vista.EliminarSnifferSwitch(_switch.Id);
        }
    }
}
