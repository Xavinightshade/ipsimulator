using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace AccesoDatos
{
    public static class AccesoDatosBD
    {
        public static ReadOnlyCollection<Estaciones> GetAllTopologias()
        {
            return new List<Estaciones>().AsReadOnly();
        }
        public static Estaciones GetTopologiaById(Guid id)
        {
            return new Estaciones();
        }
        public static void GuardarTopologia(Estaciones topologia)
        {

        }
        
    }
}
