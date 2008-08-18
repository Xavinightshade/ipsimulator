using System;
using System.Collections.Generic;
using System.Text;

namespace RedesIP.Modelos.Datos
{
	public class TextMessage:IMessage
	{
		private string _mensaje;

		public string Mensaje
		{
			get { return _mensaje; }
			set { _mensaje = value; }
		}
		public TextMessage(string mensaje)
		{
			_mensaje = mensaje;
		}
		public override string ToString()
		{
			return _mensaje;
		}
	}
	public class TestMessage:IMessage
	{

	}
	public class ReplyTestMessage : IMessage
	{
		private TestMessage _mensajeOriginal;

		public TestMessage MensajeOriginal
		{
			get { return _mensajeOriginal; }
		}
		public ReplyTestMessage(TestMessage mensajeOriginal)
		{
			_mensajeOriginal = mensajeOriginal;
		}
	}

}
