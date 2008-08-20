using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimuladorCliente.Vistas;
using SimuladorCliente;
using RedesIP.SOA.Elementos;
using SimuladorCliente.Sniffers;
using SimuladorCliente.Marcadores;
using RedesIP.Vistas.Equipos;

namespace RedesIP.Vistas
{
    public partial class EstacionView
    {
        List<MarcadorBase> _marcadores = new List<MarcadorBase>();
        private VistaSnifferMaster _snifferMaster;

        public void EnviarInformacionConexion(MensajeCableSOA mensajeSOA)
        {
            _snifferMaster.EnviarInformacionConexion(mensajeSOA);
        }





        private class HerramientaMarcador : HerramientaBase
        {

            public HerramientaMarcador(EstacionView estacion)
                : base(estacion)
            {

            }

            public override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
            {
                for (int i = 0; i < Estacion._conexiones.Count; i++)
                {
                    if (Estacion._conexiones[i].HitTest(e.X, e.Y))
                    {
                        Estacion._conexiones[i].Seleccionado = true;
                        
                        break;
                    }
                    Estacion._conexiones[i].Seleccionado = false;
                }
                Estacion.Invalidate();
            }
            public override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
            {
                foreach (KeyValuePair<Guid,EquipoView> par in Estacion._equipos)
                {
                    if (par.Value.HitTest(e.X,e.Y))
                    {
                        bool yaEstaSeleccionado = false;
                        for (int j = 0; j < Estacion._marcadores.Count; j++)
                        {
                            MarcadorEquipo marcadorEquipo = Estacion._marcadores[j] as MarcadorEquipo;
                            if (marcadorEquipo == null)
                                return;
                            if (marcadorEquipo!=null && marcadorEquipo.Equipo == par.Value)
                            {
                                yaEstaSeleccionado = true;
                                break;
                            }
                        }
                        if (!yaEstaSeleccionado)
                        {
                            MarcadorEquipo marcador = new MarcadorEquipo(par.Value);
                            if (par.Value is SwitchView)
                            {
                                Estacion._marcadores.Add(marcador);
                                Estacion._snifferMaster.IniciarSnifferSwitch(marcador, Estacion._dockMain);
                            }
                            return;

                        }
                    }
                }
                for (int i = 0; i < Estacion._conexiones.Count; i++)
                {
                    CableView cable = Estacion._conexiones[i];
                    if (cable.HitTest(e.X, e.Y))
                    {
                        bool yaEstaSeleccionado = false;
                        for (int j = 0; j < Estacion._marcadores.Count; j++)
                        {
                            MarcadorCable marcador=Estacion._marcadores[j] as MarcadorCable;
                       
                            if (marcador!=null && marcador.Conexion == cable)
                            {
                                yaEstaSeleccionado = true;
                                break;
                            }
                        }
                        if (!yaEstaSeleccionado)
                        {
                            MarcadorCable marcador = new MarcadorCable(cable);
                            Estacion._marcadores.Add(marcador);
                            Estacion._snifferMaster.IniciarSnifferCable(marcador,Estacion._dockMain);
                            
                        }
                    }
                }
            }
        }

    }
}