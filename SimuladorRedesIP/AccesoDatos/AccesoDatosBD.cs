using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace AccesoDatos
{
    public static class AccesoDatosBD
    {
        private static string _rutaPorDefecto = "D:\\Tesis\\SimuladorRedesIP\\Red.sdf";
        //        private static string _rutaPorDefecto = Environment.CurrentDirectory + "\\Red.sdf";

        private static string _rutaBD = _rutaPorDefecto;

        public static string RutaBD
        {
            get { return AccesoDatosBD._rutaBD; }
            set { AccesoDatosBD._rutaBD = value;
            _db = GetNewBD();
            }
        }
        public static void SetDefaultBD()
        {
            _rutaBD = _rutaPorDefecto;
            _db = GetNewBD();
        }
        private static Red GetNewBD()
        {
            return new Red(_rutaBD);

        }
        private static Red _db = GetNewBD();
        public static ReadOnlyCollection<Estaciones> GetAllEstaciones()
        {
            var query = from b in _db.Estaciones select b;
            return query.ToList().AsReadOnly();

        }
        public static Estaciones GetEstacionById(Guid id)
        {

            var query = from b in _db.Estaciones where b.Id == id select b;
            Estaciones estacionBD = query.First();


            Dictionary<Guid, Equipos> equiposBD = GetEquiposByIdEstacion(id);
            foreach (Puertos puertoBD in GetPuertosByIdEstacion(id))
            {
                equiposBD[puertoBD.IdEquipo].AgregarPuerto(puertoBD);
            }
            foreach (KeyValuePair<Guid, Equipos> equipo in equiposBD)
            {
                estacionBD.AgregarEquipo(equipo.Value);
            }
            estacionBD.AgregarCables(GetCablesByIdEstacion(id));
            return estacionBD;
        }
        private static Dictionary<Guid, Equipos> GetEquiposByIdEstacion(Guid id)
        {

            var equiposLINQ = from equipo in _db.Equipos
                              join estacion in _db.Estaciones on equipo.IdEstacion equals estacion.Id
                              where estacion.Id == id
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

            var PuertosLINQ = from puerto in _db.Puertos
                              join equipo in _db.Equipos on puerto.IdEquipo equals equipo.Id
                              join estacion in _db.Estaciones on equipo.IdEstacion equals estacion.Id
                              where estacion.Id == id
                              select puerto;
            return PuertosLINQ.ToList().AsReadOnly();

        }
        private static ReadOnlyCollection<Cables> GetCablesByIdEstacion(Guid id)
        {

            var cablesLINQ = from cable in _db.Cables
                             join puerto in _db.Puertos on cable.IdPuerto1 equals puerto.Id
                             join equipo in _db.Equipos on puerto.IdEquipo equals equipo.Id
                             join estacion in _db.Estaciones on equipo.IdEstacion equals estacion.Id
                             where estacion.Id == id
                             select cable;
            return cablesLINQ.ToList().AsReadOnly();
        }


        public static void ActualizarEstacion(Estaciones estacion)
        {
            Delete(estacion.Id);
            GuardarNuevaEstacion(estacion);
        }

        public static void GuardarNuevaEstacion(Estaciones estacion)
        {
            _db = GetNewBD();
            _db.Estaciones.InsertOnSubmit(estacion);
            foreach (Equipos equipo in estacion.EquiposBD)
            {
                _db.Equipos.InsertOnSubmit(equipo);

                if (equipo.Computadores != null)
                {
                    _db.Computadores.InsertOnSubmit(equipo.Computadores);
                }
                if (equipo.Routers != null)
                {
                    _db.Routers.InsertOnSubmit(equipo.Routers);
                    foreach (Rutas ruta in equipo.Routers.Rutas)
                    {
                        _db.Rutas.InsertOnSubmit(ruta);
                    }
                }

                foreach (Puertos puerto in equipo.PuertosBD)
                {
                    _db.Puertos.InsertOnSubmit(puerto);
                    if (puerto.PuertosCompletos != null)
                    {
                        _db.PuertosCompletos.InsertOnSubmit(puerto.PuertosCompletos);
                    }

                }
            }
            foreach (Cables cable in estacion.Cables)
            {
                _db.Cables.InsertOnSubmit(cable);
            }
            _db.SubmitChanges();
        }

        public static void Delete(Guid id)
        {
            var query = from b in _db.Estaciones where b.Id == id select b;
            Estaciones estacionBD = query.First();
            _db.Estaciones.DeleteOnSubmit(estacionBD);
            _db.SubmitChanges();
        }




    }
}
