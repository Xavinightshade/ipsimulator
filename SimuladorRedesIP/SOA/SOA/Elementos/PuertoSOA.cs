using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace RedesIP.SOA
{

	[DataContract]
	public class PuertoSOA
	{
		private Guid _id;
		[DataMember]
		public Guid Id
		{
			get { return _id; }
			set { _id = value; }
		}
        private string _direccionMAC;
        [DataMember]
        public string DireccionMAC
        {
            get { return _direccionMAC; }
            set { _direccionMAC = value; }
        }

        public PuertoSOA(Guid id, string direccionMAC)
		{
			_id = id;
            _direccionMAC = direccionMAC;
		}
	}
}
