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


        public PuertoBaseSOA(Guid id)
		{
			_id = id;
		}
	}

}
