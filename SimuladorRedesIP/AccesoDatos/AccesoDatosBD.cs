using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace AccesoDatos
{
    public static class AccesoDatosBD
    {
        private static Red GetNewBD()
        {
            return new Red(@"D:\Tesis\SimuladorRedesIP\AccesoDatos\Red.sdf");
        }
        static Red db = GetNewBD();
        public static ReadOnlyCollection<Estaciones> GetAllEstaciones()
        {

            var query = from b in db.Estaciones select b;
            return query.ToList().AsReadOnly();

        }
        public static Estaciones GetEstacionById(Guid id)
        {
            db = GetNewBD();

            var query = from b in db.Estaciones where b.Id==id select b;
            Estaciones estacionBD = query.First();           


            Dictionary<Guid, Equipos> equiposBD = GetEquiposByIdEstacion(id);
            foreach (Puertos puertoBD in GetPuertosByIdEstacion(id))
            {
                equiposBD[puertoBD.IdEquipo].AgregarPuerto(puertoBD);
            }
            foreach (KeyValuePair<Guid,Equipos> equipo in equiposBD)
            {
                estacionBD.AgregarEquipo(equipo.Value);
            }
            estacionBD.AgregarCables(GetCablesByIdEstacion(id));
            return estacionBD;
        }
        private static Dictionary<Guid, Equipos> GetEquiposByIdEstacion(Guid id)
        {

            var equiposLINQ = from equipo in db.Equipos
                    join estacion in db.Estaciones on equipo.IdEstacion equals estacion.Id
                    where estacion.Id==id
                    select equipo;

            Dictionary<Guid, Equipos> equipos = new Dictionary<Guid, Equipos>();
            foreach (Equipos equipo in equiposLINQ)
            {
                equipos.Add(equipo.Id, equipo);
            }
            return equipos;
        }
        private static ReadOnlyCollection<Puertos> GetPuertosByIdEstacion(Guid id)
        {

            var PuertosLINQ = from puerto in db.Puertos
                              join equipo in db.Equipos on puerto.IdEquipo equals equipo.Id
                              join estacion in db.Estaciones on equipo.IdEstacion equals estacion.Id
                              where estacion.Id == id
                              select puerto;
            return PuertosLINQ.ToList().AsReadOnly();

                              }
        private static ReadOnlyCollection<Cables> GetCablesByIdEstacion(Guid id)
        {

            var cablesLINQ = from cable in db.Cables
                             join puerto in db.Puertos on cable.IdPuerto1 equals puerto.Id
                             join equipo in db.Equipos on puerto.IdEquipo equals equipo.Id
                             join estacion in db.Estaciones on equipo.IdEstacion equals estacion.Id
                             where estacion.Id == id
                             select cable;
            return cablesLINQ.ToList().AsReadOnly();
        }



        public static void GuardarEstacion(Estaciones estacion)
        {
            Delete(estacion.Id);
            db = GetNewBD();
            db.Estaciones.InsertOnSubmit(estacion);
            foreach (Equipos equipo in estacion.Equipos)
            {
                db.Equipos.InsertOnSubmit(equipo);
                foreach (Puertos puerto in equipo.Puertos)
                {
                    db.Puertos.InsertOnSubmit(puerto);
                }
            }
            foreach (Cables cable in estacion.Cables)
            {
                db.Cables.InsertOnSubmit(cable);
            }
            db.SubmitChanges();
        }
        public static void Delete(Guid id)
        {
             var query = from b in db.Estaciones where b.Id == id select b;
              Estaciones estacionBD = query.First();
                db.Estaciones.DeleteOnSubmit(estacionBD);
                  db.SubmitChanges();
        }




    }
}
