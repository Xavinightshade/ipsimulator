using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RedesIP.Vistas.Equipos.Componentes;
using RedesIP.SOA;
using RedesIP.Vistas.Equipos;

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
        private PuertoEthernetViewBase _puerto1;



        private class HerramientaConexion : HerramientaBase
        {
            public HerramientaConexion(EstacionView estacion)
                : base(estacion)
            {
                Estacion.Cursor = Cursors.Cross;
            }

            public override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
            {
                EquipoView eq = null;
                foreach (KeyValuePair<Guid,EquipoView> item in Estacion._equipos)
	{
		                    if (item.Value.HitTest(e.X, e.Y))
                    {
                        eq = item.Value;
                        break;
                    } 
	}

                if (eq == null)
                {
                    for (int i = 0; i < Estacion._puertos.Count; i++)
                    {
                            Estacion._puertos[i].Reseltado = false;
                    }
                    Estacion.Invalidate();
                    return;

                }
              
               for (int i = 0; i < Estacion._puertos.Count; i++)
                {
                    if (Estacion._puertos[i].ElementoPadre == eq)
                        Estacion._puertos[i].Reseltado = true;
                   else
                        Estacion._puertos[i].Reseltado = false;
                }
               Estacion.Invalidate();
            }
            public override void OnMouseUp(MouseEventArgs e)
            {
                if (e.Button == MouseButtons.Right)
                {
                    if (!(Estacion._puerto1 == null))
                    {
                        Estacion._puerto1.Seleccionado = false;
                        Estacion._puerto1 = null;                        
                    }
                    return;   
                }
                for (int i = 0; i < Estacion._puertos.Count; i++)
                {
                    if (Estacion._puertos[i].HitTest(e.X, e.Y))
                    {
                        if (Estacion._puertos[i].Conectado || Estacion._puertos[i].Seleccionado)
                            break;
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