using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLogic.Datos;

namespace BusinessLogic.Componentes
{
    public class ControladorSesionServer : ControladorSesion
    {
        public ControladorSesionServer(string ipOrigen, string ipDestino, int puertoOrigem, int PuertoDestino)
            : base(ipOrigen, ipDestino, puertoOrigem, PuertoDestino, 0,null,null)
        {

        }
        bool _fin = false;
        internal List<TCPSegment> ProcesarSegmento(TCPSegment segmentoOrigen)
        {
            List<TCPSegment> segmentos = new List<TCPSegment>();
            /// 2ns setp hand shacke
            if (segmentoOrigen.SYN_Flag &&
                !segmentoOrigen.ACK_Flag &&
                segmentoOrigen.DataLength == 0)
            {
                SeqNumber = (uint)R.Next();
                ACKNumber = segmentoOrigen.SEQ_Number + 1;

                TCPSegment segmentoRetorno = new TCPSegment(PuertoOrigen, PuertoDestino, null, 0);
                segmentoRetorno.SYN_Flag = true;
                segmentoRetorno.ACK_Flag = true;
                segmentoRetorno.SEQ_Number = SeqNumber;
                segmentoRetorno.ACK_Number = ACKNumber;
                segmentos.Add(segmentoRetorno);
                return segmentos;
            }
            // 3rd step hand shake server
            if (segmentoOrigen.ACK_Flag &&
                !segmentoOrigen.FinFlag &&
                !segmentoOrigen.SYN_Flag &&
                segmentoOrigen.ACK_Number == SeqNumber + 1 &&
                !_fin &&
                (segmentoOrigen.DataLength == 0))
            {
                SeqNumber = segmentoOrigen.ACK_Number;
                SegmentSize = segmentoOrigen.SegmentSize;
                return segmentos;
            }
            /// Transferencia
            if (segmentoOrigen.ACK_Flag &&
                !segmentoOrigen.FinFlag &&
                segmentoOrigen.ACK_Number == SeqNumber &&
                segmentoOrigen.SEQ_Number == ACKNumber&&
                (segmentoOrigen.DataLength != 0))
            {
                SegmentSize = segmentoOrigen.DataLength;
                ACKNumber = segmentoOrigen.SEQ_Number + (uint)SegmentSize + 1;
                TCPSegment segmentoRetorno = new TCPSegment(PuertoOrigen, PuertoDestino, null, 0);
                segmentoRetorno.ACK_Flag = true;
                segmentoRetorno.SEQ_Number = SeqNumber;
                segmentoRetorno.ACK_Number = ACKNumber;
                segmentos.Add(segmentoRetorno);
                return segmentos;


            }
            
            /// Fin ACK
            if (segmentoOrigen.ACK_Flag &&
                segmentoOrigen.FinFlag &&
                segmentoOrigen.ACK_Number == SeqNumber &&
                segmentoOrigen.SEQ_Number == ACKNumber + segmentoOrigen.DataLength &&
                (segmentoOrigen.DataLength == 0))
            {
                ACKNumber = segmentoOrigen.SEQ_Number + 1;
                SeqNumber = segmentoOrigen.ACK_Number;

                TCPSegment segmentoACK_FIN = new TCPSegment(PuertoOrigen, PuertoDestino, null, 0);
                segmentoACK_FIN.ACK_Flag = true;
                segmentoACK_FIN.SEQ_Number = SeqNumber;
                segmentoACK_FIN.ACK_Number = ACKNumber;
                segmentos.Add(segmentoACK_FIN);

                TCPSegment segmentoFIN = new TCPSegment(PuertoOrigen, PuertoDestino, null, 0);
                segmentoFIN.ACK_Flag = true;
                segmentoFIN.FinFlag = true;
                segmentoFIN.SEQ_Number = SeqNumber;
                segmentoFIN.ACK_Number = ACKNumber;
                segmentos.Add(segmentoFIN);
                _fin = true;
                return segmentos;

            }
            if (segmentoOrigen.ACK_Flag &&
                !segmentoOrigen.FinFlag &&
                segmentoOrigen.ACK_Number == SeqNumber +1&&
                segmentoOrigen.SEQ_Number == ACKNumber &&
                _fin &&
                (segmentoOrigen.DataLength == 0))
            {
                Data = segmentoOrigen.Data;
                FileName = segmentoOrigen.FileName;
                if (ArchivoRecibido != null)
                {
                    ArchivoRecibido(this, new EventArgs());
                }
                

            }
            return segmentos;
        }
        public event EventHandler<EventArgs> ArchivoRecibido;


    }
}
