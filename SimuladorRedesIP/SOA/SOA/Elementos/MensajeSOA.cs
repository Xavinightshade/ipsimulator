using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace RedesIP.SOA.Elementos
{
    [DataContract]
    public class MensajeSOA
    {
        private Guid _idConexion;
        [DataMember]
        public Guid IdConexion
        {
            get { return _idConexion; }
            set { _idConexion = value; }
        }
        private string _datos;
        [DataMember]
        public string Datos
        {
            get { return _datos; }
            set { _datos = value; }
        }

        string _macOrigen;
        [DataMember]
        public string MacOrigen
        {
            get { return _macOrigen; }
            set { _macOrigen = value; }
        }
        string _macDestino;
        [DataMember]
        public string MacDestino
        {
            get { return _macDestino; }
            set { _macDestino = value; }
        }

        DateTime _horaRecepcion;
        [DataMember]
        public DateTime HoraRecepcion
        {
            get { return _horaRecepcion; }
            set { _horaRecepcion = value; }
        }

        public MensajeSOA (Guid idConexion, string info,
            string  macOrigen,string macDestino,DateTime horaRecepcion)
	{
        _idConexion = idConexion;
        _datos = info;
        _macOrigen = macOrigen;
        _macDestino = macDestino;
        _horaRecepcion = horaRecepcion;
            
	}

    }
}
