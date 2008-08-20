using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccesoDatos
{
    public partial class Equipos
    {
        private List<Puertos> _puertos = new List<Puertos>();

        public List<Puertos> PuertosBD
        {
            get { return _puertos; }
        }
        public void AgregarPuerto(Puertos puerto)
        {
            _puertos.Add(puerto);
        }
        public void AgregarPuertos(IEnumerable<Puertos> puertos)
        {
            _puertos.AddRange(puertos);
        }
    }
}
