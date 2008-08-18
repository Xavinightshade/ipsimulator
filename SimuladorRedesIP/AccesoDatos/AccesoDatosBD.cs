using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace AccesoDatos
{
    public static class AccesoDatosBD
    {
        public static ReadOnlyCollection<Estaciones> GetAllEstaciones()
        {
            return new List<Estaciones>().AsReadOnly();
        }
        public static Estaciones GetEstacionById(Guid id)
        {
            // traigo la estacion by id
            Estaciones estacionBD = new Estaciones();
            Dictionary<Guid, Equipos> equiposBD = GetEquiposByIdEstacion(id);
            foreach (Puertos puertoBD in GetPuertosByIdEstacion(id))
            {
                equiposBD[puertoBD.IdEquipo].AgregarPuerto(puertoBD);
            }
            estacionBD.AgregarCables(GetCablesByIdEstacion(id));
            return estacionBD;
        }
        private static Dictionary<Guid,Equipos> GetEquiposByIdEstacion(Guid id)
        {
            return new Dictionary<Guid, Equipos>();
        }
        private static ReadOnlyCollection<Puertos> GetPuertosByIdEstacion(Guid id)
        {
            return new List<Puertos>().AsReadOnly();
        }
        private static ReadOnlyCollection<Cables> GetCablesByIdEstacion(Guid id)
        {
            return new List<Cables>().AsReadOnly();
        }



        public static void GuardarEstacion(Estaciones estacion)
        {

        }

       
        
        
    }
}
