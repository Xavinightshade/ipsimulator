using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace RedesIP.SOA
{
	[DataContract]
	public class EquipoSOA
	{
		private Guid _id;
		private int _x;
		[DataMember]
		public int X
		{
			get { return _x; }
			set { _x = value; }
		}
		private int _y;
		[DataMember]

		public int Y
		{
			get { return _y; }
			set { _y = value; }
		}
		private TipoDeEquipo _tipoEquipo;
		[DataMember]

		public TipoDeEquipo TipoEquipo
		{
			get { return _tipoEquipo; }
			set { _tipoEquipo = value; }
		}
		[DataMember]

		public Guid Id
		{
			get { return _id; }
			set { _id = value; }
		}

		private List<PuertoSOA> _puertos = new List<PuertoSOA>();
		[DataMember]
		public List<PuertoSOA> Puertos
		{
			get { return _puertos; }
			set { _puertos = value; }
		}

		public void AgregarPuerto(PuertoSOA puerto)
		{
			_puertos.Add(puerto);
		}
		public EquipoSOA(TipoDeEquipo tipoEquipo, Guid id, int x, int y)
		{
			_tipoEquipo = tipoEquipo;
			_x = x;
			_y = y;
			_id = id;

		}


	}
}
