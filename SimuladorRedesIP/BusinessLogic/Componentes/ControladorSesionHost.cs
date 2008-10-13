using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLogic.Datos;

namespace BusinessLogic.Componentes
{
    public class ControladorSesionHost : ControladorSesion
    {
        public ControladorSesionHost(string ipOrigen, string ipDestino, int puertoOrigem, int PuertoDestino,
            byte[] data, int segmentSize,string fileName)
            : base(ipOrigen, ipDestino, puertoOrigem, PuertoDestino, segmentSize,data,fileName)
        {
            Data = data;
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
                SeqNumber - _initSeqNumber != Data.Length &&
                segmentoOrigen.ACK_Number == SeqNumber + 1)
            {
                ACKNumber = segmentoOrigen.SEQ_Number + 1;
                SeqNumber = segmentoOrigen.ACK_Number;

                TCPSegment segmentoRetorno = new TCPSegment(PuertoOrigen, PuertoDestino, null, 0);
                segmentoRetorno.ACK_Flag = true;
                segmentoRetorno.SEQ_Number = SeqNumber;
                segmentoRetorno.ACK_Number = ACKNumber;
                segmentoRetorno.SegmentSize = SegmentSize;
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
              SeqNumber - _initSeqNumber -2== Data.Length &&
              segmentoOrigen.ACK_Number == SeqNumber + 1)
            {
                ACKNumber = segmentoOrigen.SEQ_Number + 1;
                SeqNumber = segmentoOrigen.ACK_Number;

                TCPSegment segmentoRetorno = new TCPSegment(PuertoOrigen, PuertoDestino, Data, 0);
                segmentoRetorno.FileName = FileName;
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
                SeqNumber - _initSeqNumber != Data.Length &&
                segmentoOrigen.DataLength == 0)
            {
                SeqNumber = segmentoOrigen.ACK_Number;
                int bytesTransmited = (int)SeqNumber - (int)_initSeqNumber - 1;
                if (bytesTransmited >= Data.Length)
                {
                    segmentos.Add(GetFinRequest());
                    return segmentos;
                }
                TCPSegment segmentoRetorno = new TCPSegment(PuertoOrigen, PuertoDestino, null, SegmentSize);
                segmentoRetorno.ACK_Flag = true;
                segmentoRetorno.SEQ_Number = SeqNumber;
                segmentoRetorno.ACK_Number = ACKNumber;
                int segmentSize = SegmentSize;
                if (Data.Length - bytesTransmited < SegmentSize)
                {
                    segmentSize = Data.Length - bytesTransmited;
                    segmentoRetorno.Data = Data;
                }
                SegmentSize = segmentSize;
                segmentoRetorno.DataLength = SegmentSize;
                segmentos.Add(segmentoRetorno);

                return segmentos;
            }
            return segmentos;
        }

        private TCPSegment GetFinRequest()
        {
            TCPSegment tcpFInSegment = new TCPSegment(PuertoOrigen, PuertoDestino, null, 0);
            tcpFInSegment.FinFlag = true;
            tcpFInSegment.ACK_Flag = true;
            SeqNumber = SeqNumber;
            tcpFInSegment.SEQ_Number = SeqNumber;
            tcpFInSegment.ACK_Number = ACKNumber;
            return tcpFInSegment;
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
