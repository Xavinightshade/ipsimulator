using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RedesIP.SOA;
using RedesIP.Vistas.Equipos;
using RedesIP.Vistas.Equipos.Componentes;

namespace RedesIP.Vistas
{
    public partial class EstacionView
    {
        public void CrearEquipo(EquipoSOA equipo)
        {
            HerramientaCreacionEquipos herramientaCreacion = FabricaHerramienta.CrearHerramienta(Herramienta.CreacionEquipos, this) as HerramientaCreacionEquipos;
            herramientaCreacion.CrearEQuipo(equipo);
            Invalidate();
        }
        public void PeticionCrearEquipo(TipoDeEquipo tipoDeEquipo)
        {
            CambiarHerramienta(Herramienta.CreacionEquipos);
            HerramientaCreacionEquipos herramientaCreacion = _herramienta as HerramientaCreacionEquipos;
            herramientaCreacion.EstablecerTipoDeEquipoACrear(tipoDeEquipo);
        }
        private class HerramientaCreacionEquipos : HerramientaBase
        {
            private TipoDeEquipo _tipoEquipo;
            public HerramientaCreacionEquipos(EstacionView estacion)
                : base(estacion)
            {

            }
            public void EstablecerTipoDeEquipoACrear(TipoDeEquipo tipo)
            {
                _tipoEquipo = tipo;
            }
            public override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
            {
               Estacion.Cursor = Cursors.Cross;
            }
            public override void OnMouseUp(MouseEventArgs e)
            {
                Estacion._server.PeticionCrearEquipo(_tipoEquipo, e.X, e.Y);
            }
            public void CrearEQuipo(EquipoSOA equipo)
            {
                switch (equipo.TipoEquipo)
                {
                    case TipoDeEquipo.Ninguno:
                        break;
                    case TipoDeEquipo.Computador:
                        InsertarComputador(equipo);
                        break;
                    case TipoDeEquipo.Switch:
                        InsertarSwitch(equipo);
                        break;
                    case TipoDeEquipo.Router:
                        InsertarRouter(equipo);
                        break;
                    default:
                        break;
                }
            }

            private void InsertarRouter(EquipoSOA equipo)
            {
                RouterView rou = new RouterView(equipo);
                rou.EstablecerContenedor(Estacion);
                Estacion._routers.Add(rou);
                Estacion._equipos.Add(rou.Id, rou);
                foreach (PuertoEthernetView puerto in rou.PuertosEthernet)
                {
                    Estacion._puertos.Add(puerto);
                    Estacion._diccioPuertos.Add(puerto.Id, puerto);
                }
            }
            private void InsertarComputador(EquipoSOA equipo)
            {

                ComputadorView computador = new ComputadorView(equipo);
                computador.EstablecerContenedor(Estacion);
                Estacion._computadores.Add(computador);
                Estacion._equipos.Add(computador.Id, computador);
                Estacion._puertos.Add(computador.Puerto);
                Estacion._diccioPuertos.Add(computador.Puerto.Id, computador.Puerto);
            }
            private void InsertarSwitch(EquipoSOA equipo)
            {
                SwitchView swi = new SwitchView(equipo);
                swi.EstablecerContenedor(Estacion);
                Estacion._switches.Add(swi);
                Estacion._equipos.Add(swi.Id, swi);
                foreach (PuertoEthernetView puerto in swi.PuertosEthernet)
                {
                    Estacion._puertos.Add(puerto);
                    Estacion._diccioPuertos.Add(puerto.Id, puerto);
                }


            }

        }

    }
}