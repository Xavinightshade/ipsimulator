using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedesIP;
using RedesIP.Modelos.Logicos.Equipos;
using RedesIP.Modelos.Equipos.Componentes;
using AccesoDatos;
using RedesIP.Modelos;
using System.IO;
using SimuladorCliente.Formularios;

namespace AccesoDatos
{
    public static class AlmacenadorInformacion
    {
        private static Equipos AgregarEquipo(Estaciones estacionBD, EquipoLogico equipo)
        {
            Equipos equipoBD = new Equipos();
            equipoBD.Id = equipo.Id;
            equipoBD.TipoDeEquipo = (int)equipo.TipoDeEquipo;
            equipoBD.IdEstacion = estacionBD.Id;
            equipoBD.X = equipo.X;
            equipoBD.Y = equipo.Y;
            estacionBD.AgregarEquipo(equipoBD);
            return equipoBD;
        }
        private static void AgregarPuerto(Equipos equipoBD, PuertoEthernetLogicoBase puerto)
        {
            Puertos puertoBD = new Puertos();
            puertoBD.Id = puerto.Id;
            puertoBD.IdEquipo = equipoBD.Id;
            equipoBD.AgregarPuerto(puertoBD);
        }
        public static void GuardarNuevaEstacion(EstacionModelo estacion, byte[] bitmapData)
        {


            Estaciones estacionBD = LlenarEstacion(estacion, bitmapData);
            AccesoDatosBD.GuardarNuevaEstacion(estacionBD);
        }
        public static void ActualizarEstacion(EstacionModelo estacion, byte[] bitmapData)
        {
            
            Estaciones estacionBD = LlenarEstacion(estacion, bitmapData);
            AccesoDatosBD.ActualizarEstacion(estacionBD);
        }

        private static Estaciones LlenarEstacion(EstacionModelo estacion, byte[] bitmapData)
        {
            Estaciones estacionBD = new Estaciones();
            estacionBD.Id = estacion.Id;
            estacionBD.Foto = new System.Data.Linq.Binary(bitmapData);
            foreach (KeyValuePair<Guid, ComputadorLogico> pc in estacion.Computadores)
            {
                Equipos equipoBD = AgregarEquipo(estacionBD, pc.Value);
                AgregarPuerto(equipoBD, pc.Value.PuertoEthernet);
            }
            foreach (KeyValuePair<Guid, SwitchLogico> swi in estacion.Switches)
            {
                Equipos equipoBD = AgregarEquipo(estacionBD, swi.Value);

                foreach (PuertoEthernetLogicoBase puerto in swi.Value.PuertosEthernet)
                {
                    AgregarPuerto(equipoBD, puerto);
                }
            }
            foreach (KeyValuePair<Guid, RouterLogico> rou in estacion.Routers)
            {
                Equipos equipoBD = AgregarEquipo(estacionBD, rou.Value);
                foreach (PuertoEthernetLogicoBase puerto in rou.Value.PuertosEthernet)
                {
                    AgregarPuerto(equipoBD, puerto);
                }

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
            return estacionBD;
        }
        public static void Eliminar(Guid id)
        {
            AccesoDatosBD.Delete(id);
        }
        public static  List<RedBrowserModel> CargarEstaciones()
        {
            List<RedBrowserModel> redes = new List<RedBrowserModel>();
            foreach (Estaciones estacionBD in AccesoDatosBD.GetAllEstaciones())
            {
                if (estacionBD.Foto == null)
                    continue;
                redes.Add(new RedBrowserModel(estacionBD.Foto.ToArray(), estacionBD.Nombre,estacionBD.Id));
            }
            return redes;
        }
        public static EstacionModelo CargarEstacion(Guid id)
        {
            Estaciones estacionBD = AccesoDatosBD.GetEstacionById(id);


            EstacionModelo estacionLogica = new EstacionModelo(estacionBD.Id);
            if (estacionBD.Foto != null)
                estacionLogica.Imagen = estacionBD.Foto.ToArray();

            CrearEquipos(estacionLogica, estacionBD);
            foreach (Cables cableBD in estacionBD.Cables)
            {
                estacionLogica.ConectarPuertos(cableBD.IdPuerto1, cableBD.IdPuerto2);
            }
            return estacionLogica;
        }

        private static void CrearEquipos(EstacionModelo estacionLogica, Estaciones estacionBD)
        {
            foreach (Equipos equipoBD in estacionBD.EquiposBD)
            {
                switch ((TipoDeEquipo)equipoBD.TipoDeEquipo)
                {
                    case TipoDeEquipo.Ninguno:
                        break;
                    case TipoDeEquipo.Computador:
                        ComputadorLogico pc = new ComputadorLogico(equipoBD.Id, equipoBD.X, equipoBD.Y);
                        pc.AgregarPuerto(equipoBD.PuertosBD[0].Id, "E.1");
                        estacionLogica.CrearComputador(pc);
                        break;
                    case TipoDeEquipo.Switch:
                        SwitchLogico swi = new SwitchLogico(equipoBD.Id, equipoBD.X, equipoBD.Y);
                        foreach (Puertos puertoBD in equipoBD.PuertosBD)
                        {
                            swi.AgregarPuerto(puertoBD.Id, "E." + equipoBD.PuertosBD.IndexOf(puertoBD).ToString());
                        }
                        estacionLogica.CrearSwitch(swi);

                        break;
                    default:
                        break;
                }
            }
        }
    }
}
