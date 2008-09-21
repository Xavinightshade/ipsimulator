﻿using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;
using RedesIP.Modelos.Datos;
using RedesIP.Modelos.Logicos.Equipos;
using RedesIP.Modelos;
using RedesIP.Modelos.Equipos.Componentes;

namespace RedesIP.SOA
{
	[ServiceContract(	 Name = "EstacionServer", SessionMode = SessionMode.Required, CallbackContract = typeof(IVisualizacion))]

	public interface IModeloSOA:IModeloEstacion,IModeloSniffer
	{

		[OperationContract()]
		void ConectarCliente();
		[OperationContract()]
		void DesconectarCliente();
		[OperationContract()]
        float GetVelocidadSimulacion();
        [OperationContract()]
        void  SetVelocidadSimulacion(float valor);

    }












}