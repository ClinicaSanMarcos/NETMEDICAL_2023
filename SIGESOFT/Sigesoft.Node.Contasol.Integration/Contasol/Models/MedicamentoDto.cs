﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace Sigesoft.Node.Contasol.Integration.Contasol.Models
{
    [SuppressMessage("ReSharper", "ArrangeAccessorOwnerBody")]
    public class MedicamentoDto
    {
        public string IdProductoDetalle { get; set; }
        public string CodInterno { get; set; }
        public string Nombre { get; set; }
        public string Presentacion { get; set; }
        public string Concentracion { get; set; }
        public string Ubicacion { get; set; }
        public decimal Stock { get; set; }
        public string Almacen { get; set; }
        public string Lote { get; set; }
        public DateTime FechaCaducidad { get; set; }
        public string AccionFarmaco { get; set; }
        public string PrincipioActivo { get; set; }
        public string Laboratorio { get; set; }
        public decimal PrecioVenta { get; set; }
        public int IdUnidadMedida { get; set; }
        public string IdLinea { get; set; }
        public string v_Descripcion2 { get; set; }
        public decimal d_PrecioMayorista { get; set; }
        public string NombreGenerico { get; set; }
        public string NombreCompleto {
            get
            {
                return string.Format("{0}",
                    !string.IsNullOrEmpty(Nombre) ? Nombre : string.Empty);
            }
        }
    }
}
