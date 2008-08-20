using System;
using System.Collections.Generic;
using System.Text;

namespace RedesIP.Modelos.Datos
{
	public class TestFrameMessage:IFrameMessage
	{
		private string _mensaje;

		public string Mensaje
		{
			get { return _mensaje; }
			set { _mensaje = value; }
		}
        public TestFrameMessage(string mensaje)
		{
			_mensaje = mensaje;
		}
		public override string ToString()
		{
			return _mensaje;
		}
	}



}
