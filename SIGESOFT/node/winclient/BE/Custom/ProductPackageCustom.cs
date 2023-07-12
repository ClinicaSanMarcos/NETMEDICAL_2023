using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sigesoft.Node.WinClient.BE.Custom
{
    public class ProductPackageCustom
    {
        public string v_ProductPackageId { get; set; }
        public string v_Description { get; set; }
        public string v_InsertUser { get; set; }
        public DateTime? d_InsertDate { get; set; }
        public string v_UpdateUser { get; set; }
        public DateTime? d_UpdateDate { get; set; }

        public List<ProductPackageDetailCustom> listDetails { get; set; }
    }

    public class ProductPackageDetailCustom
    {
        public string v_ProductPackageDetailId { get; set; }
        public string v_ProductPackageId { get; set; }
        public string v_ProductId { get; set; }
        public decimal? d_Cantidad { get; set; }
        public float? r_Price { get; set; }
        public int? i_IsDeleted { get; set; }
        public int? i_InsertUserId { get; set; }
        public DateTime? d_InsertDate { get; set; }
        public int? i_UpdateUserId { get; set; }
        public DateTime? d_UpdateDate { get; set; }


        public string v_Descripcion { get; set; }
    }

    public class SecuentialDto
    {
        public string v_ReplicationID { get; set; }
        public int? i_NodeId { get; set; }
        public int? i_TableId { get; set; }
        public int? i_SecuentialId { get; set; }
    }

    public class ProductCustom
    {
        public string v_Almacen { get; set; }
        public string v_IdProducto { get; set; }
        public string v_Descripcion { get; set; }
        public decimal? d_PrecioVenta { get; set; }
        public decimal? d_StockActual { get; set; }
    }
}
