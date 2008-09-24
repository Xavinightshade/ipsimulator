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
                        if (pc.Puerto.IPAddress != null)
                            formaPC.IPAddress = pc.Puerto.IPAddress;
                        if (pc.Puerto.Nombre != null)
                            formaPC.NombrePuerto = pc.Puerto.Nombre;
                        if (pc.Puerto.Mask != null)
                            formaPC.Mask = pc.Puerto.Mask.ToString();
                        if (pc.Nombre != null)
                            formaPC.NombrePC = pc.Nombre;
                        if (pc.DefaultGateWay != null)
                            formaPC.DefaultGateWay = pc.DefaultGateWay;

                        formaPC.MACAddress = pc.Puerto.DireccionMAC;
                        if (formaPC.ShowDialog() == DialogResult.OK)
                        {
                            _estacion.Contrato.PeticionEstablecerDatosComputador(new RedesIP.SOA.ComputadorSOA(pc.Id, formaPC.NombrePC, formaPC.DefaultGateWay));
                            int? mask=null;
                            int maskParsed;
                            if (int.TryParse(formaPC.Mask,out maskParsed))
                            {
                                mask = maskParsed;
                            }
                            _estacion.Contrato.PeticionEstablecerDatosPuertoCompleto(
                                new RedesIP.SOA.PuertoCompletoSOA(pc.Puerto.Id,
                                    formaPC.MACAddress, formaPC.NombrePuerto, formaPC.IPAddress,mask));
                        }
                        return;
                    }
                }
            }


        }
        
    }
}
