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
            byte[] data, int segmentSize, int windowScale)
            : base(ipOrigen, ipDestino, puertoOrigem, PuertoDestino,segmentSize,windowScale)
        {
            _data = data;
        }

        internal TCPSegment GetTCPSyncSegment()
        {
            TCPSegment tcpSyncSegment = new TCPSegment(PuertoOrigen, PuertoDestino, null,0);
            tcpSyncSegment.SYN_Flag = true;
            SeqNumber=(uint)R.Next();
            _initSeqNumber = SeqNumber;
            tcpSyncSegment.SEQ_Number = SeqNumber;

            return tcpSyncSegment;
        }
        private uint _initSeqNumber = 0;
        internal TCPSegment ProcesarSegmento(TCPSegment segmentoOrigen)
        {
            TCPSegment segmentoRetorno=null;
            if (segmentoOrigen.SYN_Flag && segmentoOrigen.ACK_Flag)
            {
                segmentoRetorno = new TCPSegment(PuertoOrigen, PuertoDestino, null,0);
                segmentoRetorno.ACK_Flag = true;
                ACKNumber = segmentoOrigen.SEQ_Number+1;
                SeqNumber = segmentoOrigen.ACK_Number;
                segmentoRetorno.SEQ_Number = SeqNumber;
                segmentoRetorno.ACK_Number = ACKNumber;
                segmentoRetorno.SegmentSize = SegmentSize;
                segmentoRetorno.WindowsSize = WindowsSize;
                return segmentoRetorno;
            }
            if (segmentoOrigen.ACK_Number==SeqNumber+SegmentSize+1)
            {
                if (SeqNumber-_initSeqNumber>_data.Length)
                {
                    return null;
                }
                segmentoRetorno = new TCPSegment(PuertoOrigen, PuertoDestino, null, 0);
                segmentoRetorno.ACK_Flag = true;
                SeqNumber = segmentoOrigen.ACK_Number+1;
                segmentoRetorno.SEQ_Number = SeqNumber;
                segmentoRetorno.ACK_Number = ACKNumber;
                segmentoRetorno.DataLength = SegmentSize;
                return segmentoRetorno;
            }
            return segmentoRetorno;
        }

        internal TCPSegment GetPrimerSegmentoStream()
        {
            TCPSegment segmento = new TCPSegment(PuertoOrigen, PuertoDestino, null, SegmentSize);
            segmento.ACK_Flag = true;
            segmento.SEQ_Number = SeqNumber;
            segmento.ACK_Number = ACKNumber;
            segmento.DataLength = SegmentSize;
            return segmento;
        }
    }
}
