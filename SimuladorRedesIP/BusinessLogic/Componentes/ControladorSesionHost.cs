using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLogic.Datos;

namespace BusinessLogic.Componentes
{
    public class ControladorSesionHost : ControladorSesion
    {
        private byte[] _data;
        public ControladorSesionHost(string ipOrigen, string ipDestino, int puertoOrigem, int PuertoDestino,
            byte[] data)
            : base(ipOrigen, ipDestino, puertoOrigem, PuertoDestino)
        {
            _data = data;
        }

        internal TCPSegment GetTCPSyncSegment()
        {
            TCPSegment tcpSyncSegment = new TCPSegment(PuertoOrigen, PuertoDestino, null);
            tcpSyncSegment.SYN_Flag = true;
            SeqNumber=(uint)R.Next();
            tcpSyncSegment.SEQ_Number = SeqNumber;

            return tcpSyncSegment;
        }

        internal TCPSegment ProcesarSegmento(TCPSegment segmentoOrigen)
        {
            TCPSegment segmentoRetorno=null;
            if (segmentoOrigen.SYN_Flag && segmentoOrigen.ACK_Flag)
            {
                segmentoRetorno = new TCPSegment(PuertoOrigen, PuertoDestino, null);
                segmentoRetorno.ACK_Flag = true;
                segmentoRetorno.SEQ_Number = segmentoOrigen.ACK_Number;
                segmentoRetorno.ACK_Number = segmentoOrigen.SEQ_Number++;
                return segmentoRetorno;
            }
            return segmentoRetorno;
        }
    }
}
