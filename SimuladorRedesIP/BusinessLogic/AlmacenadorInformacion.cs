using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedesIP;
using RedesIP.Modelos.Logicos.Equipos;
using RedesIP.Modelos.Equipos.Componentes;
using AccesoDatos;
using RedesIP.Modelos;

namespace AccesoDatos
{
    public static class AlmacenadorInformacion
    {
        public static void AlmacenarEstacion(Estacion estacion)
        {
            Estaciones estacionBD = new Estaciones();
            estacionBD.Id = estacion.Id;
            foreach (KeyValuePair<Guid,EquipoLogico> par in estacion.Equipos)
            {
                EquipoLogico equipoLogico = par.Value;
                Equipos equipoBD = new Equipos();
                equipoBD.Id = equipoLogico.Id;
                equipoBD.TipoDeEquipo = (int)equipoLogico.TipoDeEquipo;
                equipoBD.IdEstacion = estacion.Id;
                equipoBD.X = equipoLogico.X;
                equipoBD.Y = equipoLogico.Y;
                foreach (PuertoEthernetLogico puertoLogico in equipoLogico.PuertosEthernet)
                {
                    Puertos puertoBD = new Puertos();
                    puertoBD.Id = puertoLogico.Id;
                    puertoBD.IdEquipo = equipoLogico.Id;
                    equipoBD.AgregarPuerto(puertoBD);
                }
                estacionBD.AgregarEquipo(equipoBD);
            }
            foreach (KeyValuePair<Guid, CableDeRedLogico> par in estacion.Cables)
            {
                CableDeRedLogico cableLogico = par.Value;
                Cables cableBD = new Cables();
                cableBD.Id = cableLogico.Id;
                cableBD.IdPuerto1 = cableLogico.Puerto1.Id;
                cableBD.IdPuerto2 = cableLogico.Puerto2.Id;
                estacionBD.AgregarCable(cableBD);

            }
            AccesoDatosBD.GuardarEstacion(estacionBD);
        }
        public static void Eliminar(Guid id)
        {
            AccesoDatosBD.Delete(id);
        }
        public static Estacion CargarEstacion(Guid id)
        {
            Estaciones estacionBD = AccesoDatosBD.GetEstacionById(id);
            Estacion estacionLogica = new Estacion(estacionBD.Id);

            CrearEquipos(estacionLogica,estacionBD);
            foreach (Cables cableBD in estacionBD.Cables)
            {
                estacionLogica.ConectarPuertos(cableBD.IdPuerto1, cableBD.IdPuerto2);
            }
            return estacionLogica;
        }

        private static void CrearEquipos(Estacion estacionLogica,Estaciones estacionBD)
        {
            foreach (Equipos equipoBD in estacionBD.Equipos)
            {
                switch ((TipoDeEquipo)equipoBD.TipoDeEquipo)
                {
                    case TipoDeEquipo.Ninguno:
                        break;
                    case TipoDeEquipo.Computador:
                        ComputadorLogico pc = new ComputadorLogico(equipoBD.Id, equipoBD.X, equipoBD.Y);
                        pc.AgregarPuerto(equipoBD.Puertos[0].Id);
                        pc.InicializarEquipo();
                        estacionLogica.CrearComputador(pc);
                        break;
                    case TipoDeEquipo.Switch:
                        SwitchLogico swi = new SwitchLogico(equipoBD.Id, equipoBD.X, equipoBD.Y);
                        foreach (Puertos puertoBD in equipoBD.Puertos)
                        {
                            swi.AgregarPuerto(puertoBD.Id);
                        }
                        swi.InicializarEquipo();
                        estacionLogica.CrearSwitch(swi);

                        break;
                    default:
                        break;
                }
            }
        }
    }
}
