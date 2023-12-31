﻿using System;
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
}
