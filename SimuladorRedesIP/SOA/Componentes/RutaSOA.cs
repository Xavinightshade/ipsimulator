using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SOA.Componentes
{
    public class RutaSOA
    {
                private Guid _id;

        public Guid Id
        {
            get { return _id; }
        }
        private string _red;

        public string Red
        {
            get { return _red; }
            set { _red = value; }
        }
        private Guid _idPuerto;

        public Guid IdPuerto
        {
            get { return _idPuerto; }
            set { _idPuerto = value; }
        }
        private string _nombrePuerto;

        public string NombrePuerto
        {
            get { return _nombrePuerto; }
            set { _nombrePuerto = value; }
        }
        public RutaSOA(Guid id)
        {
            _id = id;
        }
    }
}
