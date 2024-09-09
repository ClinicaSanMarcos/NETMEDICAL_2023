using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sigesoft.Node.WinClient.BE
{
    public class LiquidacionMedicoList
    {
        public int? MedicoTratanteId { get; set; }
        public string MedicoTratante { get; set; }
        public string Direccion { get; set; }
        public string CMP { get; set; }
        public string Telefono { get; set; }
        public int? i_MasterServiceId { get; set; }
        public int? i_MasterServiceTypeId { get; set; }
        public string Paciente { get; set; }
        public DateTime? d_ServiceDate { get; set; }
        public string v_ServiceId { get; set; }
        public string Aseguradora { get; set; }
        public string Tipo { get; set; }
        public string v_ServiceComponentId { get; set; }
        public float r_CostoComponente { get; set; }
        public string Componente { get; set; }
        public int TipoPagoMedico { get; set; }

        public List<LiquidacionServicios> Servicios { get; set; }
    }

    public class LiquidacionMedicoListPay
    {
        public int? MedicoTratanteId { get; set; }
        public string MedicoTratante { get; set; }
        public string Direccion { get; set; }
        public string CMP { get; set; }
        public string Telefono { get; set; }
        public int? i_MasterServiceId { get; set; }
        public int? i_MasterServiceTypeId { get; set; }
        public string Paciente { get; set; }
        public DateTime? d_ServiceDate { get; set; }
        public string v_ServiceId { get; set; }
        public string Aseguradora { get; set; }
        public string Tipo { get; set; }
        public string v_ServiceComponentId { get; set; }
        public float r_CostoComponente { get; set; }
        public string Componente { get; set; }
        public int TipoPagoMedico { get; set; }

        public string TipoProtocolo { get; set; }
        public string Comprobante { get; set; }
        public string TipoComprobante { get; set; }

        public decimal? d_Total { get; set; }
        public int? GrupoId { get; set; }
        public string Turno { get; set; }
        public int? CodigoId { get; set; }
        public string Grupo { get; set; }

        public double horas { get; set; }
        public double minutos { get; set; }

        public double montoo { get; set; }

        //public List<LiquidacionMedicoListPay> Servicios { get; set; }
    }

    public class DetallePagoTurno
    {
        public DateTime Fecha { get; set; }
        public string Grupo { get; set; }
        public decimal Monto { get; set; }

        public double horas { get; set; }
        public decimal Total { get; set; }
        public double minutos { get; set; }

        public string Tiempo { get; set; }

    }

    public class SystemParameterTurno
    {
        public int GrupoId { get; set; }
        public int ParameterId { get; set; }

        public string Value1 { get; set; }

    }

    public class DetallePagoeEXAMEN
    {
        public DateTime Fecha { get; set; }
        public string Examen { get; set; }
        public string TipoComprobante { get; set; }
        public string Comprobante { get; set; }
        public decimal Monto { get; set; }
        public decimal PorcMed { get; set; }
        public decimal PorcClinica { get; set; }
        public string DescIgv_Bol { get; set; }
        public string DescIgv_Fac { get; set; }
        public string DescIgv_Rec { get; set; }

        public decimal PagMed { get; set; }
    }
}
