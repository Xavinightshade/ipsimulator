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
            : base(ipOrigen, ipDestino, puertoOrigem, PuertoDestino, segmentSize, windowScale)
        {
            _data = data;
        }

        internal TCPSegment GetTCPSyncSegment()
        {
            SeqNumber = (uint)R.Next();
            _initSeqNumber = SeqNumber;
            // 1st step handshake
            TCPSegment tcpSyncSegment = new TCPSegment(PuertoOrigen, PuertoDestino, null, 0);
            tcpSyncSegment.SYN_Flag = true;
            tcpSyncSegment.SEQ_Number = SeqNumber;
            return tcpSyncSegment;
        }
        private uint _initSeqNumber = 0;
        public List<TCPSegment> ProcesarSegmento(TCPSegment segmentoOrigen)
        {
            List<TCPSegment> segmentos = new List<TCPSegment>();
            // 3rd setp handshake
            if (segmentoOrigen.SYN_Flag &&
                segmentoOrigen.ACK_Flag &&
                !segmentoOrigen.FinFlag &&
                segmentoOrigen.DataLength == 0 &&
                SeqNumber - _initSeqNumber != _data.Length &&
                segmentoOrigen.ACK_Number == SeqNumber + 1)
            {
                ACKNumber = segmentoOrigen.SEQ_Number + 1;
                SeqNumber = segmentoOrigen.ACK_Number;

                TCPSegment segmentoRetorno = new TCPSegment(PuertoOrigen, PuertoDestino, null, 0);
                segmentoRetorno.ACK_Flag = true;
                segmentoRetorno.SEQ_Number = SeqNumber;
                segmentoRetorno.ACK_Number = ACKNumber;
                segmentoRetorno.SegmentSize = SegmentSize;
                segmentoRetorno.WindowsSize = WindowsSize;
                segmentos.Add(segmentoRetorno);
                TCPSegment segmentoprimerDato = new TCPSegment(PuertoOrigen, PuertoDestino, null, SegmentSize);
                segmentoprimerDato.ACK_Flag = true;
                segmentoprimerDato.SEQ_Number = SeqNumber;
                segmentoprimerDato.ACK_Number = ACKNumber;
                segmentos.Add(segmentoprimerDato);
                return segmentos;
            }

            if (!segmentoOrigen.SYN_Flag &&
                 segmentoOrigen.ACK_Flag &&
                 segmentoOrigen.FinFlag &&
                segmentoOrigen.DataLength == 0 &&
              SeqNumber - _initSeqNumber == _data.Length &&
              segmentoOrigen.ACK_Number == SeqNumber + 1)
            {
                ACKNumber = segmentoOrigen.SEQ_Number + 1;
                SeqNumber = segmentoOrigen.ACK_Number;

                TCPSegment segmentoRetorno = new TCPSegment(PuertoOrigen, PuertoDestino, null, 0);
                segmentoRetorno.ACK_Flag = true;
                segmentoRetorno.SEQ_Number = SeqNumber;
                segmentoRetorno.ACK_Number = ACKNumber;
                segmentos.Add(segmentoRetorno);
                Console.WriteLine("fin host");
                return segmentos;
            }

            // Data Transfer
            if (!segmentoOrigen.SYN_Flag &&
                segmentoOrigen.ACK_Flag &&
                !segmentoOrigen.FinFlag &&
                segmentoOrigen.ACK_Number == SeqNumber + SegmentSize + 1 &&
                SeqNumber - _initSeqNumber != _data.Length &&
                segmentoOrigen.DataLength == 0)
            {
                SeqNumber = segmentoOrigen.ACK_Number;
                int bytesTransmited = (int)SeqNumber - (int)_initSeqNumber - 1;
                if (bytesTransmited >= _data.Length)
                {
                    segmentos.Add(GetFinRequest());
                    return segmentos;
                }
                TCPSegment segmentoRetorno = new TCPSegment(PuertoOrigen, PuertoDestino, null, SegmentSize);
                segmentoRetorno.ACK_Flag = true;
                segmentoRetorno.SEQ_Number = SeqNumber;
                segmentoRetorno.ACK_Number = ACKNumber;
                int segmentSize = SegmentSize;
                if (_data.Length - bytesTransmited < SegmentSize)
                {
                    segmentSize = _data.Length - bytesTransmited;
                    segmentoRetorno.Data = _data;
                }
                SegmentSize = segmentSize;
                segmentoRetorno.DataLength = SegmentSize;
                segmentos.Add(segmentoRetorno);

                return segmentos;
            }
            throw new Exception();
        }

        private TCPSegment GetFinRequest()
        {
            TCPSegment tcpSyncSegment = new TCPSegment(PuertoOrigen, PuertoDestino, null, 0);
            tcpSyncSegment.FinFlag = true;
            SeqNumber = SeqNumber;
            tcpSyncSegment.SEQ_Number = SeqNumber;
            tcpSyncSegment.ACK_Number = ACKNumber;
            return tcpSyncSegment;
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
