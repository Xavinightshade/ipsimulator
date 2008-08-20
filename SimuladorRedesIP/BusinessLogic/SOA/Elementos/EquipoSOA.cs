using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace RedesIP.SOA
{
	[DataContract]
	public abstract class EquipoBaseSOA
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


		public EquipoBaseSOA(TipoDeEquipo tipoEquipo, Guid id, int x, int y)
            :this(tipoEquipo,x,y)
		{

			_id = id;

		}
        public EquipoBaseSOA(TipoDeEquipo tipoEquipo, int x, int y)
        {
            _tipoEquipo = tipoEquipo;
            _x = x;
            _y = y;

        }


	}





}
