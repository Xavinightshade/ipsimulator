using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimuladorCliente.Vistas;
using RedesIP.SOA.Elementos;
using SimuladorCliente;

namespace RedesIP.Vistas
{
    public partial class EstacionView
    {
        List<Marcador> _marcadores = new List<Marcador>();
        public event EventHandler<NuevoMarcadorEventArgs> NuevoMarcador;

        public void EnviarInformacionConexion(MensajeSOA mensajeSOA)
        {
            foreach (Marcador marker in _marcadores)
            {
                if (marker.Conexion.Id == mensajeSOA.IdConexion)
                {
                    marker.EnviarNuevoMensaje(mensajeSOA);
                    return;
                }
            }
            throw new Exception();
        }





        private class HerramientaMarcador : HerramientaBase
        {
            Dictionary<Guid, Marcador> _diccioMarcadores = new Dictionary<Guid, Marcador>();

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
                    if (Estacion._conexiones[i].HitTest(e.X, e.Y))
                    {
                        bool yaEstaSeleccionado = false;
                        for (int j = 0; j < Estacion._marcadores.Count; j++)
                        {
                            if (Estacion._marcadores[j].Conexion == Estacion._conexiones[i])
                            {
                                yaEstaSeleccionado = true;
                                break;
                            }
                        }
                        if (!yaEstaSeleccionado)
                        {
                            Marcador marcador = new Marcador(Guid.NewGuid(), Estacion._conexiones[i]);
                            Estacion._marcadores.Add(marcador);
                            _diccioMarcadores.Add(marcador.Id, marcador);
                            if (Estacion.NuevoMarcador != null)
                            {
                                Estacion.NuevoMarcador(this, new NuevoMarcadorEventArgs(marcador));
                                Estacion._server.PeticionEnviarInformacionConexion(marcador.Conexion.Id);
                            }
                        }
                    }
                }
            }
        }

    }
}