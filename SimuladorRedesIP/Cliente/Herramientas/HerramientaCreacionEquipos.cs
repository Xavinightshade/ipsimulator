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
        public void CrearComputador(ComputadorSOA pc)
        {
            HerramientaCreacionEquipos herramientaCreacion = FabricaHerramienta.CrearHerramienta(Herramienta.CreacionEquipos, this) as HerramientaCreacionEquipos;
            herramientaCreacion.InsertarComputador(pc);
            Invalidate();
        }
        public void CrearSwitch(SwitchSOA swi)
        {
            HerramientaCreacionEquipos herramientaCreacion = FabricaHerramienta.CrearHerramienta(Herramienta.CreacionEquipos, this) as HerramientaCreacionEquipos;
            herramientaCreacion.InsertarSwitch(swi);
            Invalidate();
        }
        public void CrearSwitchVLan(SwitchVLanSOA swiRespuesta)
        {
            HerramientaCreacionEquipos herramientaCreacion = FabricaHerramienta.CrearHerramienta(Herramienta.CreacionEquipos, this) as HerramientaCreacionEquipos;
            herramientaCreacion.InsertarSwitchVLan(swiRespuesta);
            Invalidate();
        }
        public void CrearRouter(RouterSOA rou)
        {
            HerramientaCreacionEquipos herramientaCreacion = FabricaHerramienta.CrearHerramienta(Herramienta.CreacionEquipos, this) as HerramientaCreacionEquipos;
            herramientaCreacion.InsertarRouter(rou);
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
                switch (_tipoEquipo)
                {
                    case TipoDeEquipo.Ninguno:
                        throw new NotImplementedException();
                    case TipoDeEquipo.Computador:
                        Estacion._server.PeticionCrearComputador(new ComputadorSOA(_tipoEquipo,e.X,e.Y));
                        break;
                    case TipoDeEquipo.Switch:
                        Estacion._server.PeticionCrearSwitch(new SwitchSOA(_tipoEquipo, e.X, e.Y));
                        break;
                    case TipoDeEquipo.Router:
                        Estacion._server.PeticionCrearRouter(new RouterSOA(_tipoEquipo, e.X, e.Y));
                        break;
                    case  TipoDeEquipo.SwitchVLan:
                        Estacion._server.PeticionCrearSwitchVLAN(new SwitchVLanSOA(_tipoEquipo, e.X, e.Y));
                        break;
                    default:
                        throw new NotImplementedException();
                }
                
            }



            public void InsertarRouter(RouterSOA router)
            {
                RouterView rou = new RouterView(router);
                rou.EstablecerContenedor(Estacion);
                Estacion._routers.Add(rou);
                Estacion._equipos.Add(rou.Id, rou);
                foreach (PuertoEthernetViewBase puerto in rou.PuertosEthernet)
                {
                    Estacion._puertos.Add(puerto);
                    Estacion._diccioPuertos.Add(puerto.Id, puerto);
                }
            }
            public void InsertarComputador(ComputadorSOA pc)
            {

                ComputadorView computador = new ComputadorView(pc);
                computador.AgregarArchivos(pc.Archivos);
                computador.EstablecerContenedor(Estacion);
                Estacion._computadores.Add(computador);
                Estacion._equipos.Add(computador.Id, computador);
                Estacion._puertos.Add(computador.Puerto);
                Estacion._diccioPuertos.Add(computador.Puerto.Id, computador.Puerto);
            }
            public void InsertarSwitch(SwitchSOA swiSOA)
            {
                SwitchView swi = new SwitchView(swiSOA);
                swi.EstablecerContenedor(Estacion);
                Estacion._switches.Add(swi);
                Estacion._equipos.Add(swi.Id, swi);
                foreach (PuertoEthernetViewBase puerto in swi.PuertosEthernet)
                {
                    Estacion._puertos.Add(puerto);
                    Estacion._diccioPuertos.Add(puerto.Id, puerto);
                }


            }
            public void InsertarSwitchVLan(SwitchVLanSOA swiRespuesta)
            {
                SwitchVLanView swi = new SwitchVLanView(swiRespuesta);
                swi.EstablecerContenedor(Estacion);
                Estacion._switchesVLan.Add(swi);
                Estacion._equipos.Add(swi.Id, swi);
                foreach (PuertoEthernetViewBase puerto in swi.PuertosEthernet)
                {
                    Estacion._puertos.Add(puerto);
                    Estacion._diccioPuertos.Add(puerto.Id, puerto);
                }
            }
        }

    }
}