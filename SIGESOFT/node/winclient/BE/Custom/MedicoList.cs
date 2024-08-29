using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sigesoft.Node.WinClient.BE
{
    public class MedicoList
    {
        public string v_MedicoId { get; set; }
        public string Usuario { get; set; }
        public int i_SystemUserId { get; set; }
        public string Medico { get; set; }
        public int i_GrupoId { get; set; }
        public string Grupo { get; set; }
        public decimal? r_Clinica { get; set; }
        public decimal? r_Medico { get; set; }
        public string Observaciones { get; set; }
        public string Tipo { get; set; }
    }

    public class MedicoConfList
    {
        public string v_IdConfPago { get; set; }
        public string Usuario { get; set; }
        public int i_SystemUserId { get; set; }
        public string Medico { get; set; }
        public string Observaciones { get; set; }

        public int i_TipoPago { get; set; }//(1 - Turno / 2 - Hora / 3 - Examen)
        public string v_TipoPago { get; set; }//(1 - Turno / 2 - Hora / 3 - Examen)

        public float? d_MontoxTurno { get; set; }
        public float? d_MonoxHora { get; set; }
        public int? i_OrdenExam { get; set; } //(1 - Medico Tratante / 2 - Medico Solicitante
        public string v_OrdenExam { get; set; } //(1 - Medico Tratante / 2 - Medico Solicitante
        public float? d_PorcClinicaExam { get; set; }
        public float? d_PorcMedicoExam { get; set; }
        public int? i_DescontarBoletaExam { get; set; }
        public string v_DescontarBoletaExam { get; set; }

        public int? i_DescontarFactExam { get; set; }
        public string v_DescontarFactExam { get; set; }

        public int? i_DescontarRecbExam { get; set; }
        public string v_DescontarRecbExam { get; set; }

        public string v_ObservacionesCambios { get; set; }
        public int? i_IsDeleted { get; set; }
        public int? i_InsertUserId { get; set; }
        public string v_InsertUserId { get; set; }
        public DateTime? d_InsertDate { get; set; }
        public int? i_UpdateUserId { get; set; }
        public string v_UpdateUserId { get; set; }
        public DateTime? d_UpdateDate { get; set; }

    }

    public class MedicoConfExamenList
    {
        public string v_idPagoExam { get; set; }
        public string v_IdConfPago { get; set; }
        public string v_ComponentId { get; set; }
        public string Examen { get; set; }

        public string v_Observaciones { get; set; }
       
        public string v_ObservacionesCambios { get; set; }
        public int? i_IsDeleted { get; set; }
        public int? i_InsertUserId { get; set; }
        public string v_InsertUserId { get; set; }
        public DateTime? d_InsertDate { get; set; }
        public int? i_UpdateUserId { get; set; }
        public string v_UpdateUserId { get; set; }
        public DateTime? d_UpdateDate { get; set; }

    }
}
