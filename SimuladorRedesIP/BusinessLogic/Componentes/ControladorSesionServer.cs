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
            : base(ipOrigen, ipDestino, puertoOrigem, PuertoDestino, 0, 0)
        {

        }

        internal TCPSegment ProcesarSegmento(TCPSegment segmentoOrigen)
        {
            TCPSegment segmentoRetorno = null;

            if (segmentoOrigen.SYN_Flag)
            {
                segmentoRetorno = new TCPSegment(PuertoOrigen, PuertoDestino, null,0);
                segmentoRetorno.SYN_Flag = true;
                segmentoRetorno.ACK_Flag = true;
                SeqNumber = (uint)R.Next();
                segmentoRetorno.SEQ_Number = SeqNumber;
                ACKNumber = segmentoOrigen.SEQ_Number + 1;
                segmentoRetorno.ACK_Number = ACKNumber;
                return segmentoRetorno;
            }
            if (segmentoOrigen.ACK_Flag &&
                segmentoOrigen.ACK_Number == SeqNumber + 1 &&
                (segmentoOrigen.DataLength==0))
            {
                SeqNumber = segmentoOrigen.ACK_Number;
                WindowsSize = segmentoOrigen.WindowsSize;
                SegmentSize = segmentoOrigen.SegmentSize;
                return null;
            }
            if (segmentoOrigen.ACK_Flag &&
                segmentoOrigen.ACK_Number == SeqNumber &&
                (segmentoOrigen.DataLength != 0))
            {
                segmentoRetorno = new TCPSegment(PuertoOrigen, PuertoDestino, null, 0);
                segmentoRetorno.ACK_Flag = true;
                segmentoRetorno.SEQ_Number = SeqNumber;
                ACKNumber = segmentoOrigen.SEQ_Number + (uint)SegmentSize+1;
                segmentoRetorno.ACK_Number = ACKNumber;
                return segmentoRetorno;


            }
            return null;
        }
    }
}
