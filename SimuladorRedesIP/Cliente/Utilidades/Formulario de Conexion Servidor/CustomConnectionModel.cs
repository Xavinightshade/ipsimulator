using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Net;
using System.ComponentModel;
using BusinessObjects;

namespace SOA
{
	public class CustomConnectionModel : DomainObject
	{
		private const string _puertoPropiedad = "Puerto";
		public CustomConnectionModel(int puerto)
		{
			_puerto = puerto.ToString();
			_direccionesIp = new BindingList<string>();
			string strHostName = Dns.GetHostName();
			IPAddress[] addresses = Dns.GetHostAddresses(strHostName);
			foreach (IPAddress dir in addresses)
			{
				if (EsValidaLaDireccionIp(dir.ToString()))
					_direccionesIp.Add(dir.ToString());
			}
			if (_direccionesIp.Count > 0)
				_direccionIp = _direccionesIp[0];
			Validate();
		}


		public void Validate()
		{
			base.NotifyChanged(_direccionIpPropiedad);
			base.NotifyChanged(_puertoPropiedad);
		}

		private string _puerto;
		public string Puerto
		{
			get { return _puerto; }
			set
			{
				_puerto = value;
				base.NotifyChanged(_puertoPropiedad);
			}
		}
		private const string _direccionIpPropiedad = "DireccionIp";
		private string _direccionIp;
		public string DireccionIp
		{
			get { return _direccionIp; }
			set 
			{
				_direccionIp = value;
				base.NotifyChanged(_direccionIpPropiedad);
			}
		}
		private BindingList<string> _direccionesIp;
		public BindingList<string> DireccionesIp
		{
			get { return _direccionesIp; }
		}
		protected override System.Collections.ObjectModel.ReadOnlyCollection<Rule> CreateRules()
		{
			List<Rule> reglas = new List<Rule>(base.CreateRules());
			reglas.Add(new SimpleRule(_puertoPropiedad, "No es un valor numérico valido", delegate
			{
				int i;
				return int.TryParse(_puerto, out i);
			}));
			reglas.Add(new SimpleRule(_puertoPropiedad, "El puerto 80 no está disponible", delegate
{
	int i;
	bool esEntero = int.TryParse(_puerto, out i);
	if (!esEntero)
		return false;
	return (i != 80);



}));
			reglas.Add(new SimpleRule(_puertoPropiedad, "Seleccione un puerto entre 1 a 65535", delegate
			{
				int i;
				bool esEntero = int.TryParse(_puerto, out i);
				if (!esEntero)
					return false;
				return ((i >= 1) && (i <= 65535));



			}));
			reglas.Add(new SimpleRule(_direccionIpPropiedad, "La direccion Ip no es Valida", delegate
			{
				return EsValidaLaDireccionIp(_direccionIp);
			}));
			return reglas.AsReadOnly();
		}
		public static bool EsValidaLaDireccionIp(string direccion)
		{
			string url = "http://" + direccion + "/";
				Uri httpBaseAddress;// = new Uri(url);
				return Uri.TryCreate(url, UriKind.Absolute, out httpBaseAddress);
		}
	}
}
