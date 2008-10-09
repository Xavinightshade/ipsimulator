using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace RedesIP.SOA
{

	[DataContract]
	public class PuertoBaseSOA
	{
		private Guid _id;
		[DataMember]
		public Guid Id
		{
			get { return _id; }
			set { _id = value; }
		}
        private string _nombre;
        [DataMember]
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        private bool _habilitado;

        public bool Habilitado
        {
            get { return _habilitado; }
            set { _habilitado = value; }
        }
        public PuertoBaseSOA(Guid id,string nombre,bool habilitado)
		{
			_id = id;
            _nombre = nombre;
            _habilitado = habilitado;
		}
	}

}
