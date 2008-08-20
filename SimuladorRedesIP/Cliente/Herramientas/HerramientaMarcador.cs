using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimuladorCliente.Vistas;
using SimuladorCliente;
using RedesIP.SOA.Elementos;
using SimuladorCliente.Sniffers;

namespace RedesIP.Vistas
{
    public partial class EstacionView
    {
        List<MarcadorCable> _marcadores = new List<MarcadorCable>();
        private VistaSnifferMaster _snifferMaster;

        public void EnviarInformacionConexion(MensajeCableSOA mensajeSOA)
        {
            _snifferMaster.EnviarInformacionConexion(mensajeSOA);
        }





        private class HerramientaMarcador : HerramientaBase
        {
            Dictionary<Guid, MarcadorCable> _diccioMarcadores = new Dictionary<Guid, MarcadorCable>();

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
                for (int i = 0; i < Estacion._conexiones.Count; i++)
                {
                    CableView cable = Estacion._conexiones[i];
                    if (cable.HitTest(e.X, e.Y))
                    {
                        bool yaEstaSeleccionado = false;
                        for (int j = 0; j < Estacion._marcadores.Count; j++)
                        {
                            if (Estacion._marcadores[j].Conexion == cable)
                            {
                                yaEstaSeleccionado = true;
                                break;
                            }
                        }
                        if (!yaEstaSeleccionado)
                        {
                            MarcadorCable marcador = new MarcadorCable(cable);
                            Estacion._marcadores.Add(marcador);
                            _diccioMarcadores.Add(marcador.Id, marcador);
                            Estacion._snifferMaster.IniciarSnifferCable(marcador,Estacion._dockMain);
                            
                        }
                    }
                }
            }
        }

    }
}