using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RedesIP.Vistas.Equipos.Componentes;
using RedesIP.SOA;

namespace RedesIP.Vistas
{
    public partial class EstacionView
    {
        List<Conexion> _conexiones = new List<Conexion>();

        public void ConectarPuertos(CableSOA cable)
        {
            _conexiones.Add(new Conexion(cable.Id, _diccioPuertos[cable.IdPuerto1], _diccioPuertos[cable.IdPuerto2]));
            Invalidate();
        }
        private PuertoEthernetView _puerto1;

        private class HerramientaConexion : HerramientaBase
        {
            public HerramientaConexion(EstacionView estacion)
                : base(estacion)
            {
                Estacion.Cursor = Cursors.Cross;
            }

            public override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
            {
              
               for (int i = 0; i < Estacion._puertos.Count; i++)
                {
                    if (Estacion._puertos[i].HitTest(e.X, e.Y))
                    {

                        Estacion._puertos[i].Seleccionado = true;


                    }
                    else
                    {
                        if (Estacion._puertos[i] != Estacion._puerto1)
                            Estacion._puertos[i].Seleccionado = false;
                    }
                }
               Estacion.Invalidate();
            }
            public override void OnMouseUp(MouseEventArgs e)
            {
                for (int i = 0; i < Estacion._puertos.Count; i++)
                {
                    if (Estacion._puertos[i].HitTest(e.X, e.Y))
                    {
                        if (Estacion._puerto1 == null)
                        {
                            Estacion._puertos[i].Seleccionado = true;
                            Estacion._puerto1 = Estacion._puertos[i];
                        }
                        else
                        {
                            Estacion._server.PeticionConectarPuertos(Estacion._puerto1.Id, Estacion._puertos[i].Id);
                            Estacion._puerto1 = null;
                        }
                        break;
                    }
                }
            }
        }

    }
}