using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;
using RedesIP.Modelos.Datos;
using RedesIP.Modelos.Logicos.Equipos;
using RedesIP.Modelos;
using RedesIP.Modelos.Equipos.Componentes;
using SOA.Componentes;

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
        int GetFactorSimulacion();
        [OperationContract()]
        void  PeticionSetFactorSimulacion(int valor);
        [OperationContract()]
        void PeticionPlayPause();
        [OperationContract()]
        bool GetEstadoSimulacion();


        [OperationContract()]
        List<RutaSOA> TraerRutasEstaticas(Guid idRouter);

        [OperationContract()]
        List<RutaSOA> TraerRutasDinamicas(Guid idRouter);

        [OperationContract()]
        List<RutaSOA> TraerRutasInternas(Guid idRouter);
        [OperationContract()]
        void PeticionEstablecerDatosSwitch(SwitchSOA swi);
        [OperationContract()]
        void PeticionEliminarCable(Guid idCable);
        [OperationContract()]
        void PeticionEliminarEquipo(Guid IdEquipo);

        [OperationContract()]
        void PeticionCrearSwitchVLAN(SwitchVLanSOA switchVLanSOA);
        [OperationContract()]
        void PeticionActualizarVLans(Guid idSwitchVLan, List<VLanSOA> vLansActuales);

        byte[] GetFile(Guid _idPc, Guid guid);
    }












}
