using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace RedesIP.SOA
{
	[DataContract]
	public class ConexionSOA
	{
		private Guid _id;
		[DataMember]
		public Guid Id
		{
			get { return _id; }
			set { _id = value; }
		}
		private Guid _idPuerto1;
		[DataMember]
		public Guid IdPuerto1
		{
			get { return _idPuerto1; }
			set { _idPuerto1 = value; }
		}
		private Guid _idPuerto2;
		[DataMember]
		public Guid IdPuerto2
		{
			get { return _idPuerto2; }
			set { _idPuerto2 = value; }
		}
		public ConexionSOA(Guid id, Guid idPuerto1, Guid idPuerto2)
		{
			_id = id;
			_idPuerto1 = idPuerto1;
			_idPuerto2 = idPuerto2;
		}
	}
}
