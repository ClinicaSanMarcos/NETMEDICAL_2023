using Sigesoft.Node.WinClient.BE.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sigesoft.Node.WinClient.UI;
using System.Transactions;
using Dapper;
using Sigesoft.Node.WinClient.BE;

namespace Sigesoft.Node.WinClient.BLL
{
    public class ProductPackageBL
    {
        public List<TicketDetalleList> GetProductsByPackageId(string packageId)
        {
            try
            {
                string Year = DateTime.Now.Year.ToString();
                packageId = packageId == null ? "" : packageId;
                using (var cnx = ConnectionHelperSige.GetConnectionSAM)
                {
                    var query = "select pro.d_PrecioVenta, pro.d_PrecioMayorista, pkg.d_Cantidad, pro.v_IdProducto, prd.v_IdProductoDetalle, pro.v_Descripcion as v_NombreProducto, pro.v_CodInterno, pro.v_IdLinea as v_IdUnidadProductiva from producto pro " +
                                "join productodetalle prd on pro.v_IdProducto = prd.v_IdProducto " +
                                "join productoalmacen pra on prd.v_IdProductoDetalle = pra.v_ProductoDetalleId " +
                                "join almacen alm on pra.i_IdAlmacen = alm.i_IdAlmacen " +
                                "join productpackagedetail pkg on pro.v_IdProducto = pkg.v_ProductId " +
                                "where pkg.v_ProductPackageId = '" + packageId + "' and pkg.i_IsDeleted = 0";
                    var list = cnx.Query<TicketDetalleList>(query).ToList().GroupBy(x => x.v_IdProductoDetalle).Select(x => x.First()).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public List<ProductCustom> GetProductoCustoms(string value)
        {
            try
            {
                string Year = DateTime.Now.Year.ToString();
                value = value == null ? "" : value;
                using (var cnx = ConnectionHelperSige.GetConnectionSAM)
                {
                    var query = "select pro.v_IdProducto, pro.v_Descripcion, pro.d_PrecioVenta, pra.d_StockActual, alm.v_Nombre as v_Almacen from producto pro " +
                                "join productodetalle prd on pro.v_IdProducto = prd.v_IdProducto " +
                                "join productoalmacen pra on prd.v_IdProductoDetalle = pra.v_ProductoDetalleId " +
                                "join almacen alm on pra.i_IdAlmacen = alm.i_IdAlmacen " +
                                "where pro.i_Eliminado = 0 and pro.i_EsActivoFijo = 0 and pro.i_EsActivo = 1 " +
                                "and (pro.v_Descripcion like '%" + value + "%' or pro.v_IdProducto = '" + value + "' or '"+value+"' = '') and pra.v_Periodo = '" + Year + "'";
                    var list = cnx.Query<ProductCustom>(query).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public List<ProductPackageCustom> GetDataProductPackage(string value)
        {
            try
            {
                using (var cnx = ConnectionHelperSige.GetConnectionSAM)
                {
                    var query = "select * from productpackage where v_Description like  '%" + value + "%' and i_IsDeleted = 0";
                    return cnx.Query<ProductPackageCustom>(query).ToList();

                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public List<ProductPackageDetailCustom> GetPackageDetails(string packageId)
        {
            try
            {
                using (var cnx = ConnectionHelperSige.GetConnectionSAM)
                {
                    var query = "select prd.v_ProductId, prd.d_Cantidad, pro.v_Descripcion, pro.d_PrecioVenta as r_Price, prd.v_ProductPackageDetailId, prd.v_ProductPackageId from productpackagedetail prd" +
                                " join producto pro on prd.v_ProductId = pro.v_IdProducto" +
                                " where v_ProductPackageId = '" + packageId + "' and i_IsDeleted = 0";
                    return cnx.Query<ProductPackageDetailCustom>(query).ToList();

                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public string GetNamePackage(string packageId)
        {
            using (var cnx = ConnectionHelperSige.GetConnectionSAM)
            {
                var query = "select * from productpackage where v_ProductPackageId = '" + packageId + "' and i_IsDeleted = 0";
                return cnx.Query<ProductPackageCustom>(query).FirstOrDefault().v_Description;

            }
        }

        public bool SavePackage(ProductPackageCustom data, int userId, int nodeId)
        {
            try
            {
                using (var ts = new TransactionScope())
                {
                    var SecuentialId = GetNextSecuentialId(nodeId, 36);
                    var newPackageId = Common.Utils.GetNewId(nodeId, SecuentialId, "PP");
                    using (var cnx = ConnectionHelperSige.GetConnectionSAM)
                    {
                        var query = "INSERT INTO productpackage (v_ProductPackageId, v_Description, i_IsDeleted, i_InsertUserId, d_InsertDate) " +
                                    "VALUES ('" + newPackageId + "', '" + data.v_Description + "', 0, " + userId + ", GETDATE())";
                        cnx.Execute(query);

                        foreach (var item in data.listDetails)
                        {
                            SavePackageDetail(item, newPackageId, userId, nodeId);
                        }

                    }

                    ts.Complete();
                }

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool UpdatePackage(ProductPackageCustom data, int userId, int nodeId)
        {
            try
            {
                using (var ts = new TransactionScope())
                {
                    using (var cnx = ConnectionHelperSige.GetConnectionSAM)
                    {
                        var query = "UPDATE productpackage SET " +
                                    " v_Description = '" + data.v_Description + "'" +
                                    ", i_UpdateUserId = " + userId +
                                    ", d_UpdateDate = GETDATE() " +
                                    " WHERE v_ProductPackageId = '" + data.v_ProductPackageId + "'";
                        cnx.Execute(query);

                        foreach (var item in data.listDetails)
                        {
                            if (item.v_ProductPackageDetailId == null)
                            {
                                SavePackageDetail(item, data.v_ProductPackageId, userId, nodeId);
                            }
                            else
                            {
                                UpdatePackageDetail(item, data.v_ProductPackageId, userId, nodeId);
                            }
                        }
                    }
                    ts.Complete();
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool DeletedPackage(string packageId)
        {
            try
            {
                using (var cnx = ConnectionHelperSige.GetConnectionSAM)
                {
                    var query = "UPDATE productpackage SET " +
                                       "i_IsDeleted = 1 " +
                                       "WHERE v_ProductPackageId = '" + packageId + "'";
                    cnx.Execute(query);
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool DeletedPackageDetail(string packagedetailId)
        {
            try
            {
                using (var cnx = ConnectionHelperSige.GetConnectionSAM)
                {
                    var queryDetails = "UPDATE productpackagedetail SET " +
                                       "i_IsDeleted = 1 " +
                                       "WHERE v_ProductPackageDetailId = '" + packagedetailId + "'";
                    cnx.Execute(queryDetails);
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        private void UpdatePackageDetail(ProductPackageDetailCustom data, string productPackId, int userId, int nodeId)
        {
            using (var cnx = ConnectionHelperSige.GetConnectionSAM)
            {
                var queryDetails = "UPDATE productpackagedetail SET " +
                                   "d_Cantidad = " + data.d_Cantidad +
                                   ", i_UpdateUserId = " + userId +
                                   ", d_UpdateDate = GETDATE() " +
                                   "WHERE v_ProductPackageDetailId = '" + data.v_ProductPackageDetailId + "'";
                cnx.Execute(queryDetails);
            }
        }

        private void SavePackageDetail(ProductPackageDetailCustom data, string productPackId, int userId, int nodeId)
        {
            using (var cnx = ConnectionHelperSige.GetConnectionSAM)
            {
                var SecuentialId2 = GetNextSecuentialId(nodeId, 37);
                var newPackageId2 = Common.Utils.GetNewId(nodeId, SecuentialId2, "PD");
                var queryDetails = "INSERT INTO productpackagedetail (v_ProductPackageDetailId, v_ProductPackageId, v_ProductId, d_Cantidad, i_IsDeleted, i_InsertUserId, d_InsertDate) " +
                                   "VALUES ('" + newPackageId2 + "', '" + productPackId + "', '" + data.v_ProductId + "', " + data.d_Cantidad + ", 0, " + userId + ", GETDATE())";
                cnx.Execute(queryDetails);
            }
        }

        public int GetNextSecuentialId(int pintNodeId, int pintTableId)
        {
            using (var cnx = ConnectionHelperSige.GetConnectionSAM)
            {
                var query = "select * from secuential where i_TableId = " + pintTableId + " and i_NodeId = " +
                            pintNodeId + " and v_ReplicationID = 'N'";

                var objSecuential = cnx.Query<SecuentialDto>(query).FirstOrDefault();
                int secuencial = 0;

                if (objSecuential != null)
                {
                    secuencial = objSecuential.i_SecuentialId.Value + 1;
                }
                else
                {
                    objSecuential = new SecuentialDto
                    {
                        i_NodeId = pintNodeId,
                        i_TableId = pintTableId,
                        i_SecuentialId = 1,
                        v_ReplicationID = "N"
                    };
                    var qCreate = "INSERT INTO secuential (v_ReplicationID, i_NodeId, i_TableId, i_SecuentialId) " +
                                  "VALUES ('N', " + pintNodeId + ", " + pintTableId + ", 1)";

                    cnx.Execute(qCreate);
                }

                return secuencial;
            }

        }
    }
}
