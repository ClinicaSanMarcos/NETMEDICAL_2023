﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sigesoft.Node.WinClient.BE
{

    public class TiposCuenta
    {
        public string NombreCuenta { get; set; }
        public int? Encontrados { get; set; }
        public decimal? TotalImporte { get; set; }
        public decimal? PrecioUnitario { get; set; }
        public decimal? ImporteCoaseguro { get; set; }
        public decimal? TotalSaldoPaciente { get; set; }
        public List<JoinTicketDetails> ListJoinTickets { get; set; }
    }

    public class JoinTicketDetails
    {

        
        public string Descripcion { get; set; }
        public decimal? Importe { get; set; }
        public decimal? Descuento { get; set; }
        public decimal? Total { get; set; }
        public decimal? SaldoPaciente { get; set; }
        public string v_Amount { get; set; }
        public string v_Discount { get; set; }
        public string v_Total { get; set; }
        public string v_Found { get; set; }
        public string v_Description { get; set; }
        public decimal? ImporteCoaseguro { get; set; }
    }

    public class TicketDetalleList
    {
        public int i_TipoCuenta { get; set; }
        public string v_TipoCuentaName { get; set; }
        public string v_TicketDetalleId { get; set; }
        public string v_TicketId { get; set; }
        public string v_IdProductoDetalle { get; set; }
        public string v_IdProducto { get; set; }
        public string v_NombreProducto { get; set; }
        public string v_CodInterno { get; set; }
        public string v_Descripcion { get; set; }
        public decimal d_Cantidad { get; set; }
        public int i_EsDespachado { get; set; }
        public string EsDespachado { get; set; }
        public int? i_RecordStatus { get; set; }
        public int? i_RecordType { get; set; }
        public decimal d_PrecioVenta{ get; set; }
        public decimal d_PrecioMayorista { get; set; }
        public decimal Total { get; set; }
        public int? i_IsDeletd { get; set; }
        
        public decimal? d_SaldoPaciente { get; set; }
        public decimal? d_SaldoAseguradora { get; set; }

        public string v_IdUnidadProductiva { get; set; }
        public int i_EsDeducible { get; set; }
        public int i_EsCoaseguro { get; set; }
        public decimal? ImporteCoaseguro { get; set; }
        public decimal? d_Importe { get; set; }

        public string UsuarioCrea { get; set; }
    }
}
