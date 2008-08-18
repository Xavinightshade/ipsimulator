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
		public PuertoSOA(Guid id)
		{
			_id = id;
		}
	}
}
