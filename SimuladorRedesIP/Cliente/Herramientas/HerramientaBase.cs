using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SimuladorCliente;
using SimuladorCliente.Formularios;
using RedesIP.Vistas.Equipos;

namespace RedesIP.Vistas
{
    public partial class EstacionView
    {
        private abstract class HerramientaBase
        {
            private EstacionView _estacion;

            protected EstacionView Estacion
            {
                get { return _estacion; }
            }
            public HerramientaBase(EstacionView estacion)
            {
                _estacion = estacion;
            }
            public abstract void OnMouseMove(MouseEventArgs e);
            public abstract void OnMouseUp(MouseEventArgs e);
            public virtual void OnMouseDoubleClick(MouseEventArgs e)
            {
                for (int i = 0; i < _estacion._computadores.Count; i++)
                {
                    if (_estacion._computadores[i].HitTest(e.X, e.Y))
                    {
                        ComputadorView pc = _estacion._computadores[i];
                        FormularioComputador formaPC = new FormularioComputador();
                        formaPC.Text = pc.Puerto.DireccionMAC;
                        if (pc.Puerto.IPAddress != null)
                            formaPC.IPAddress = pc.Puerto.IPAddress;
                        if (pc.Puerto.Nombre != null)
                            formaPC.NombrePuerto = pc.Puerto.Nombre;
                        formaPC.MACAddress = pc.Puerto.DireccionMAC;
                        if (formaPC.ShowDialog() == DialogResult.OK)
                            _estacion.Contrato.PeticionEstablecerDatosPuertoCompleto(
                                new RedesIP.SOA.PuertoCompletoSOA(pc.Puerto.Id,
                                    formaPC.MACAddress, formaPC.NombrePuerto,formaPC.IPAddress));
                        return;
                    }
                }
            }


        }
        
    }
}
