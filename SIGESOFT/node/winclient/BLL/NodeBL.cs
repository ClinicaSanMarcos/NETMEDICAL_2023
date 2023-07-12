using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Dynamic;
using System.Net.Sockets;
using Sigesoft.Node.WinClient.BE;
using Sigesoft.Node.WinClient.DAL;
using Sigesoft.Common;
using System.Transactions;

namespace Sigesoft.Node.WinClient.BLL
{
    public class NodeBL
    {
        public nodeDto GetNodeByNodeId(ref OperationResult pobjOperationResult, int pintNodeId)
        {           
            try
            {
                SigesoftEntitiesModel dbContext = new SigesoftEntitiesModel();
                nodeDto objDtoEntity = null;

                var objEntity = (from a in dbContext.node
                                 where a.i_NodeId == pintNodeId
                                 select a).FirstOrDefault();

                if (objEntity != null)
                    objDtoEntity = nodeAssembler.ToDTO(objEntity);

                pobjOperationResult.Success = 1;
                return objDtoEntity;
            }
            catch (Exception ex)
            {
                pobjOperationResult.Success = 0;
                pobjOperationResult.ExceptionMessage = Common.Utils.ExceptionFormatter(ex);
                return null;
            }
        }

        public bool UpdateNodeByNodeId(nodeDto data, int userId)
        {
            try
            {
                SigesoftEntitiesModel cnx = new SigesoftEntitiesModel();

                var entity = cnx.node.Where(x => x.i_NodeId == data.i_NodeId).FirstOrDefault();
                entity.v_Description = data.v_Description;
                entity.v_GeografyLocationDescription = data.v_GeografyLocationDescription;
                entity.v_GeografyLocationId = data.v_GeografyLocationId;
                entity.i_NodeTypeId = data.i_NodeTypeId;
                entity.d_BeginDate = data.d_BeginDate;
                entity.d_EndDate = data.d_EndDate;
                entity.i_UpdateUserId = userId;
                entity.d_UpdateDate = DateTime.Now;

                cnx.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool DeleteNode(int nodeId)
        {
            try
            {
                SigesoftEntitiesModel cnx = new SigesoftEntitiesModel();
                var obj = cnx.node.Where(x => x.i_NodeId == nodeId).FirstOrDefault();
                obj.i_IsDeleted = 1;
                cnx.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool AddNode(nodeDto data, int userId)
        {
            try
            {
                SigesoftEntitiesModel cnx = new SigesoftEntitiesModel();
                var list = GetNodePagedAndFiltered("").OrderByDescending(x => x.i_NodeId).ToList();

                int nodeId = list[0].i_NodeId.Value + 1;
                var objExiste = cnx.node.Where(x => x.i_NodeId == nodeId).FirstOrDefault();
                while (objExiste != null)
                {
                    nodeId++;
                    objExiste = cnx.node.Where(x => x.i_NodeId == nodeId).FirstOrDefault();
                }
                node entity = nodeAssembler.ToEntity(data);
                entity.i_IsDeleted = 0;
                entity.d_InsertDate = DateTime.Now;
                entity.i_InsertUserId = userId;
                entity.i_NodeId = nodeId;

                cnx.AddTonode(entity);
                cnx.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public nodeorganizationlocationwarehouseprofileDto GetNodeOrganizationLocationWarehouseProfile(ref OperationResult pobjOperationResult, string pstrWarehouseId)
        {
            //mon.IsActive = true;
            try
            {
                SigesoftEntitiesModel dbContext = new SigesoftEntitiesModel();
                nodeorganizationlocationwarehouseprofileDto objDtoEntity = null;

                var objEntity = (from a in dbContext.nodeorganizationlocationwarehouseprofile
                                 where a.v_WarehouseId == pstrWarehouseId && a.i_IsDeleted ==0
                                 select a).FirstOrDefault();

                if (objEntity != null)
                    objDtoEntity = nodeorganizationlocationwarehouseprofileAssembler.ToDTO(objEntity);

                pobjOperationResult.Success = 1;
                return objDtoEntity;
            }
            catch (Exception ex)
            {
                pobjOperationResult.Success = 0;
                pobjOperationResult.ExceptionMessage = Common.Utils.ExceptionFormatter(ex);
                return null;
            }
        }

        public nodeDto GetNodeByNodeIdReport(int pintNodeId)
        {
            try
            {
                SigesoftEntitiesModel dbContext = new SigesoftEntitiesModel();
                nodeDto objDtoEntity = null;

                var objEntity = (from a in dbContext.node
                                 where a.i_NodeId == pintNodeId
                                 select a).FirstOrDefault();

                if (objEntity != null)
                    objDtoEntity = nodeAssembler.ToDTO(objEntity);

                return objDtoEntity;
            }
            catch (Exception ex)
            {
                
                return null;
            }
        }

        #region NodeOrganization

        private bool IsWarehouseAssignedToNode(ref OperationResult pobjOperationResult, List<nodeorganizationlocationwarehouseprofileDto> pobjWarehouseList)
        {
            SigesoftEntitiesModel dbContext = new SigesoftEntitiesModel();

            // Validar que un almacen solo sea asignado a un solo nodo
            foreach (var item in pobjWarehouseList)
            {
                var query = (from a in dbContext.nodeorganizationlocationwarehouseprofile
                             join b in dbContext.node on a.i_NodeId equals b.i_NodeId
                             join c in dbContext.warehouse on a.v_WarehouseId equals c.v_WarehouseId
                             where a.v_WarehouseId == item.v_WarehouseId &&
                             a.i_IsDeleted == 0
                             select new
                             {
                                 v_NodeName = b.v_Description,
                                 v_WarehouseName = c.v_Name
                             }).FirstOrDefault();

                if (query != null)
                {
                    pobjOperationResult.ErrorMessage = string.Format("El Almacén <font color='red'> {0} </font> ya se encuentra asignado al nodo <font color='red'> {1} </font>. Por favor elija otro.",
                                                                                    query.v_WarehouseName,
                                                                                    query.v_NodeName);
                    pobjOperationResult.Success = 1;
                    return true;
                }
            }

            return false;
        }

        public void AddNodeOrganizationLoactionWarehouse(ref OperationResult pobjOperationResult, NodeOrganizationLoactionWarehouseList pobjNodeOrgLocationWarehouse, List<nodeorganizationlocationwarehouseprofileDto> pobjWarehouseList, List<string> ClientSession)
        {
            //mon.IsActive = true;

            nodeorganizationprofile objNodeorganizationprofile = new nodeorganizationprofile();
            nodeorganizationlocationprofile objNodeorganizationlocationprofile = new nodeorganizationlocationprofile();

            try
            {

                SigesoftEntitiesModel dbContext = new SigesoftEntitiesModel();

                OperationResult objOperationResult5 = new OperationResult();

                if (pobjWarehouseList != null)
                {
                    if (IsWarehouseAssignedToNode(ref objOperationResult5, pobjWarehouseList))
                    {
                        pobjOperationResult = objOperationResult5;
                        return;
                    }
                }

                var objEntitySource = (from a in dbContext.nodeorganizationlocationprofile
                                       join c in dbContext.nodeorganizationlocationprofile on a.i_NodeId equals c.i_NodeId
                                       where a.i_NodeId == pobjNodeOrgLocationWarehouse.i_NodeId &&
                                       a.v_OrganizationId == pobjNodeOrgLocationWarehouse.v_OrganizationId &&
                                       c.v_LocationId == pobjNodeOrgLocationWarehouse.v_LocationId
                                       select a).FirstOrDefault();

                if (objEntitySource != null)
                {
                    // Actualizar registro (dar de alta al registro ya existente "no volver a insertar")
                    OperationResult objOperationResult2 = new OperationResult();

                    UpdateNodeOrganizationChangeStatusAll(ref objOperationResult2,
                                                            pobjNodeOrgLocationWarehouse.i_NodeId,
                                                            pobjNodeOrgLocationWarehouse.v_OrganizationId,
                                                            pobjNodeOrgLocationWarehouse.v_LocationId,
                                                            0,
                                                            ClientSession);

                    pobjOperationResult = objOperationResult2;
                }
                else
                {
                    var query = (from a in dbContext.nodeorganizationlocationprofile
                                 where a.i_NodeId == pobjNodeOrgLocationWarehouse.i_NodeId &&
                                 a.v_OrganizationId == pobjNodeOrgLocationWarehouse.v_OrganizationId
                                 select a).FirstOrDefault();

                    // Grabar nuevo

                    if (query == null)
                    {
                        #region Nodeorganization
                        // Grabar nodo / empresa
                        objNodeorganizationprofile.d_InsertDate = DateTime.Now;
                        objNodeorganizationprofile.i_InsertUserId = Int32.Parse(ClientSession[2]);
                        objNodeorganizationprofile.i_IsDeleted = 0;
                        objNodeorganizationprofile.i_NodeId = pobjNodeOrgLocationWarehouse.i_NodeId;
                        objNodeorganizationprofile.v_OrganizationId = pobjNodeOrgLocationWarehouse.v_OrganizationId;

                        dbContext.AddTonodeorganizationprofile(objNodeorganizationprofile);
                        dbContext.SaveChanges();
                        #endregion

                        #region Nodeorganizationlocation
                        // Grabar nodo / empresa / sede

                        objNodeorganizationlocationprofile.d_InsertDate = DateTime.Now;
                        objNodeorganizationlocationprofile.i_InsertUserId = Int32.Parse(ClientSession[2]);
                        objNodeorganizationlocationprofile.i_IsDeleted = 0;
                        objNodeorganizationlocationprofile.i_NodeId = pobjNodeOrgLocationWarehouse.i_NodeId;
                        objNodeorganizationlocationprofile.v_OrganizationId = pobjNodeOrgLocationWarehouse.v_OrganizationId;
                        objNodeorganizationlocationprofile.v_LocationId = pobjNodeOrgLocationWarehouse.v_LocationId;

                        dbContext.AddTonodeorganizationlocationprofile(objNodeorganizationlocationprofile);
                        dbContext.SaveChanges();
                        #endregion

                        #region Add Warehouse

                        // Graba almacenes
                        OperationResult objOperationResult1 = new OperationResult();

                        if (pobjWarehouseList != null)
                        {
                            AddWarehouse(ref objOperationResult1, pobjWarehouseList, ClientSession);
                        }

                        #endregion
                    }
                    else
                    {
                        #region Nodeorganizationlocation
                        // Grabar nodo / empresa / sede

                        objNodeorganizationlocationprofile.d_InsertDate = DateTime.Now;
                        objNodeorganizationlocationprofile.i_InsertUserId = Int32.Parse(ClientSession[2]);
                        objNodeorganizationlocationprofile.i_IsDeleted = 0;
                        objNodeorganizationlocationprofile.i_NodeId = pobjNodeOrgLocationWarehouse.i_NodeId;
                        objNodeorganizationlocationprofile.v_OrganizationId = pobjNodeOrgLocationWarehouse.v_OrganizationId;
                        objNodeorganizationlocationprofile.v_LocationId = pobjNodeOrgLocationWarehouse.v_LocationId;

                        dbContext.AddTonodeorganizationlocationprofile(objNodeorganizationlocationprofile);
                        dbContext.SaveChanges();
                        #endregion

                        #region Add Warehouse

                        // Graba almacenes
                        OperationResult objOperationResult1 = new OperationResult();

                        if (pobjWarehouseList != null)
                        {
                            AddWarehouse(ref objOperationResult1, pobjWarehouseList, ClientSession);
                        }

                        #endregion
                    }

                }

                pobjOperationResult.Success = 1;

                // Llenar entidad Log
                LogBL.SaveLog(ClientSession[0], ClientSession[1], ClientSession[2], LogEventType.CREACION, "EMPRESA / SEDE / ALMACÉN", "v_OrganizationId=" + objNodeorganizationprofile.v_OrganizationId, Success.Ok, null);
            }
            catch (Exception ex)
            {
                pobjOperationResult.Success = 0;
                pobjOperationResult.ExceptionMessage = Common.Utils.ExceptionFormatter(ex);
                // Llenar entidad Log
                LogBL.SaveLog(ClientSession[0], ClientSession[1], ClientSession[2], LogEventType.CREACION, "EMPRESA / SEDE / ALMACÉN", "v_OrganizationId=" + objNodeorganizationprofile.v_OrganizationId, Success.Failed, pobjOperationResult.ExceptionMessage);
            }

        }

        public void UpdateNodeOrganizationLoactionWarehouse(ref OperationResult pobjOperationResult, NodeOrganizationLoactionWarehouseList pobjNodeOrgLocationWarehouse, List<nodeorganizationlocationwarehouseprofileDto> pobjWarehouseListAdd, List<nodeorganizationlocationwarehouseprofileDto> pobjWarehouseListDel, List<string> ClientSession)
        {
            //mon.IsActive = true;
            try
            {
                SigesoftEntitiesModel dbContext = new SigesoftEntitiesModel();

                #region Warehouse -> Add / Del

                // Eliminar Almacenes              
                if (pobjWarehouseListDel != null)
                {
                    OperationResult objOperationResult1 = new OperationResult();
                    DeleteWarehouse(ref objOperationResult1, pobjWarehouseListDel, ClientSession);
                }

                // Graba almacenes
                if (pobjWarehouseListAdd != null)
                {
                    OperationResult objOperationResult3 = new OperationResult();
                    if (IsWarehouseAssignedToNode(ref objOperationResult3, pobjWarehouseListAdd))
                    {
                        pobjOperationResult = objOperationResult3;
                        return;
                    }

                    OperationResult objOperationResult2 = new OperationResult();
                    AddWarehouse(ref objOperationResult2, pobjWarehouseListAdd, ClientSession);
                }

                #endregion

                pobjOperationResult.Success = 1;
                // Llenar entidad Log
                LogBL.SaveLog(ClientSession[0], ClientSession[1], ClientSession[2], LogEventType.ACTUALIZACION, "EMPRESA / SEDE / ALMACÉN", "v_OrganizationId=" + pobjNodeOrgLocationWarehouse.v_OrganizationId, Success.Ok, null);
                return;
            }
            catch (Exception ex)
            {
                pobjOperationResult.Success = 0;
                pobjOperationResult.ExceptionMessage = Common.Utils.ExceptionFormatter(ex);
                // Llenar entidad Log
                LogBL.SaveLog(ClientSession[0], ClientSession[1], ClientSession[2], LogEventType.ACTUALIZACION, "EMPRESA / SEDE / ALMACÉN", "v_OrganizationId=" + pobjNodeOrgLocationWarehouse.v_OrganizationId, Success.Failed, pobjOperationResult.ExceptionMessage);
            }
        }

        public List<NodeOrganizationLoactionWarehouseList> GetNodeOrganization(ref OperationResult pobjOperationResult, int pintNodeId, string pstrOrganizationName)
        {
            //mon.IsActive = true;

            try
            {
                SigesoftEntitiesModel dbContext = new SigesoftEntitiesModel();

                var query = (from n in dbContext.node
                             join a in dbContext.nodeorganizationlocationprofile on n.i_NodeId equals a.i_NodeId
                             join J1 in dbContext.nodeorganizationprofile on new { a = a.i_NodeId, b = a.v_OrganizationId }
                                                      equals new { a = J1.i_NodeId, b = J1.v_OrganizationId } into j1_join
                             from j1 in j1_join.DefaultIfEmpty()
                             join b in dbContext.organization on j1.v_OrganizationId equals b.v_OrganizationId
                             join c in dbContext.location on a.v_LocationId equals c.v_LocationId
                             orderby b.v_Name, c.v_Name
                             where n.i_NodeId == pintNodeId && n.i_IsDeleted == 0 &&
                                 //j1.i_IsDeleted == 0 &&
                             a.i_IsDeleted == 0 &&
                             b.v_Name.Contains(pstrOrganizationName)
                             select new NodeOrganizationLoactionWarehouseList
                             {
                                 v_OrganizationName = b.v_Name,
                                 v_LocationName = c.v_Name,
                                 v_LocationId = c.v_LocationId,
                                 v_OrganizationId = b.v_OrganizationId,
                                 i_NodeId = n.i_NodeId,
                             }
                           );

                var q = (from a in query.ToList()
                         select new NodeOrganizationLoactionWarehouseList
                         {
                             v_OrganizationName = a.v_OrganizationName,
                             v_LocationName = a.v_LocationName,
                             v_LocationId = a.v_LocationId,
                             v_OrganizationId = a.v_OrganizationId,
                             i_NodeId = a.i_NodeId,
                             v_WarehouseName = dd(a.i_NodeId, a.v_OrganizationId, a.v_LocationId)
                         });

                List<NodeOrganizationLoactionWarehouseList> objData = q.ToList();

                pobjOperationResult.Success = 1;
                return objData;
            }
            catch (Exception ex)
            {
                pobjOperationResult.Success = 0;
                pobjOperationResult.ExceptionMessage = Common.Utils.ExceptionFormatter(ex);
                return null;
            }
        }

        private string dd(int pintNodeId, string pstrOrganizationId, string pstrLocationId)
        {
            SigesoftEntitiesModel dbContext = new SigesoftEntitiesModel();

            var qry = (from a in dbContext.nodeorganizationlocationwarehouseprofile
                       join b in dbContext.warehouse on a.v_WarehouseId equals b.v_WarehouseId
                       where a.i_NodeId == pintNodeId &&
                       a.v_OrganizationId == pstrOrganizationId &&
                       a.v_LocationId == pstrLocationId &&
                       a.i_IsDeleted == 0
                       select new
                       {
                           v_Warehouse = b.v_Name
                       }).ToList();

            return string.Join(", ", qry.Select(p => p.v_Warehouse));
        }

        private void DeleteWarehouse(ref OperationResult pobjOperationResult, List<nodeorganizationlocationwarehouseprofileDto> pobjWarehouseList, List<string> ClientSession)
        {
            try
            {
                SigesoftEntitiesModel dbContext = new SigesoftEntitiesModel();

                foreach (var item in pobjWarehouseList)
                {
                    var objEntitySource = (from a in dbContext.nodeorganizationlocationwarehouseprofile
                                           where a.i_NodeId == item.i_NodeId &&
                                                 a.v_OrganizationId == item.v_OrganizationId &&
                                                 a.v_LocationId == item.v_LocationId &&
                                                 a.v_WarehouseId == item.v_WarehouseId
                                           select a).FirstOrDefault();

                    objEntitySource.d_UpdateDate = DateTime.Now;
                    objEntitySource.i_UpdateUserId = Int32.Parse(ClientSession[2]);
                    objEntitySource.i_IsDeleted = 1;

                    // Guardar los cambios
                    dbContext.SaveChanges();
                }

                pobjOperationResult.Success = 1;
                // Llenar entidad Log
                LogBL.SaveLog(ClientSession[0], ClientSession[1], ClientSession[2], LogEventType.ELIMINACION, "", "", Success.Ok, null);
                return;
            }
            catch (Exception ex)
            {
                pobjOperationResult.Success = 0;
                pobjOperationResult.ExceptionMessage = Common.Utils.ExceptionFormatter(ex);
                // Llenar entidad Log
                LogBL.SaveLog(ClientSession[0], ClientSession[1], ClientSession[2], LogEventType.ELIMINACION, "", "", Success.Failed, pobjOperationResult.ExceptionMessage);
                return;
            }
        }

        private void AddWarehouse(ref OperationResult pobjOperationResult, List<nodeorganizationlocationwarehouseprofileDto> pobjWarehouseList, List<string> ClientSession)
        {
            try
            {
                SigesoftEntitiesModel dbContext = new SigesoftEntitiesModel();

                nodeorganizationlocationwarehouseprofile objnodeorganizationlocationwarehouseprofile = null;

                // Grabar almacén
                foreach (var item in pobjWarehouseList)
                {
                    var objEntitySource = (from a in dbContext.nodeorganizationlocationwarehouseprofile
                                           where a.i_NodeId == item.i_NodeId &&
                                                 a.v_OrganizationId == item.v_OrganizationId &&
                                                 a.v_LocationId == item.v_LocationId &&
                                                 a.v_WarehouseId == item.v_WarehouseId
                                           select a).FirstOrDefault();

                    if (objEntitySource != null)
                    {
                        objEntitySource.d_UpdateDate = DateTime.Now;
                        objEntitySource.i_UpdateUserId = Int32.Parse(ClientSession[2]);
                        objEntitySource.i_IsDeleted = 0;

                        // Guardar los cambios
                        dbContext.SaveChanges();
                    }
                    else
                    {
                        objnodeorganizationlocationwarehouseprofile = nodeorganizationlocationwarehouseprofileAssembler.ToEntity(item);
                        objnodeorganizationlocationwarehouseprofile.d_InsertDate = DateTime.Now;
                        objnodeorganizationlocationwarehouseprofile.i_InsertUserId = int.Parse(ClientSession[2]);
                        objnodeorganizationlocationwarehouseprofile.i_IsDeleted = 0;

                        dbContext.AddTonodeorganizationlocationwarehouseprofile(objnodeorganizationlocationwarehouseprofile);
                        dbContext.SaveChanges();
                    }

                }

                pobjOperationResult.Success = 1;
                // Llenar entidad Log
                LogBL.SaveLog(ClientSession[0], ClientSession[1], ClientSession[2], LogEventType.CREACION, "", "", Success.Ok, null);
                return;
            }
            catch (Exception ex)
            {
                pobjOperationResult.Success = 0;
                pobjOperationResult.ExceptionMessage = Common.Utils.ExceptionFormatter(ex);
                // Llenar entidad Log
                LogBL.SaveLog(ClientSession[0], ClientSession[1], ClientSession[2], LogEventType.CREACION, "", "", Success.Failed, pobjOperationResult.ExceptionMessage);
                return;
            }
        }

        public void UpdateNodeOrganizationChangeStatusAll(ref OperationResult pobjOperationResult, int pintNodeId, string pstrOrganizationId, string pstrLocationId, int pintIsDeleted, List<string> ClientSession)
        {
            try
            {
                SigesoftEntitiesModel dbContext = new SigesoftEntitiesModel();

                #region nodeOrganization
                // Obtener la entidad fuente
                var objnodeOrganization = (from a in dbContext.nodeorganizationprofile
                                           where a.i_NodeId == pintNodeId &&
                                           a.v_OrganizationId == pstrOrganizationId
                                           select a).FirstOrDefault();

                // Crear la entidad con los datos actualizados
                objnodeOrganization.d_UpdateDate = DateTime.Now;
                objnodeOrganization.i_UpdateUserId = Int32.Parse(ClientSession[2]);
                objnodeOrganization.i_IsDeleted = pintIsDeleted;

                // Guardar los cambios
                dbContext.SaveChanges();
                #endregion

                #region nodeOrganizationLocation
                // Obtener la entidad fuente
                var objnodeOrganizationLocation = (from a in dbContext.nodeorganizationlocationprofile
                                                   where a.i_NodeId == pintNodeId &&
                                                   a.v_OrganizationId == pstrOrganizationId &&
                                                   a.v_LocationId == pstrLocationId
                                                   select a).FirstOrDefault();

                // Crear la entidad con los datos actualizados
                objnodeOrganizationLocation.d_UpdateDate = DateTime.Now;
                objnodeOrganizationLocation.i_UpdateUserId = Int32.Parse(ClientSession[2]);
                objnodeOrganizationLocation.i_IsDeleted = pintIsDeleted;

                // Guardar los cambios
                dbContext.SaveChanges();
                #endregion

                #region Warehouse

                // Obtener la entidad fuente
                var objWarehouse = (from a in dbContext.nodeorganizationlocationwarehouseprofile
                                    where a.i_NodeId == pintNodeId &&
                                    a.v_OrganizationId == pstrOrganizationId &&
                                    a.v_LocationId == pstrLocationId
                                    select a).ToList();
                if (objWarehouse != null)
                {
                    foreach (var item in objWarehouse)
                    {
                        item.d_UpdateDate = DateTime.Now;
                        item.i_UpdateUserId = Int32.Parse(ClientSession[2]);
                        item.i_IsDeleted = pintIsDeleted;
                    }

                    // Guardar los cambios
                    dbContext.SaveChanges();
                }
                #endregion

                // Llenar entidad Log
                LogBL.SaveLog(ClientSession[0], ClientSession[1], ClientSession[2], LogEventType.ACTUALIZACION, "EMPRESA / SEDE / ALMACÉN", "v_OrganizationId=" + pstrOrganizationId, Success.Ok, null);
                return;
            }
            catch (Exception ex)
            {
                pobjOperationResult.Success = 0;
                pobjOperationResult.ExceptionMessage = Common.Utils.ExceptionFormatter(ex);
                // Llenar entidad Log
                LogBL.SaveLog(ClientSession[0], ClientSession[1], ClientSession[2], LogEventType.ACTUALIZACION, "EMPRESA / SEDE / ALMACÉN", "v_OrganizationId=" + pstrOrganizationId, Success.Failed, pobjOperationResult.ExceptionMessage);
            }
        }

        public int GetNodeOrganizationCount(ref OperationResult pobjOperationResult, string filterExpression)
        {
            //mon.IsActive = true;
            try
            {
                SigesoftEntitiesModel dbContext = new SigesoftEntitiesModel();
                var query = (from a in dbContext.nodeorganizationprofile
                             join c in dbContext.nodeorganizationlocationprofile on a.i_NodeId equals c.i_NodeId
                             select new
                             {
                                 i_NodeId = a.i_NodeId,
                                 v_OrganizationId = a.v_OrganizationId,
                                 v_LocationId = c.v_LocationId,
                                 i_IsDeleted = a.i_IsDeleted
                             });

                string filterEx = "i_IsDeleted==0";
                query = query.Where(filterEx);

                if (!string.IsNullOrEmpty(filterExpression))
                    query = query.Where(filterExpression);

                int intResult = query.Count();

                pobjOperationResult.Success = 1;
                return intResult;
            }
            catch (Exception ex)
            {
                pobjOperationResult.Success = 0;
                pobjOperationResult.ExceptionMessage = ex.Message;
                return 0;
            }
        }

        public int GetNodeOrganizationLocationWarehouseProfileCount(ref OperationResult pobjOperationResult, string filterExpression)
        {
            //mon.IsActive = true;
            try
            {
                SigesoftEntitiesModel dbContext = new SigesoftEntitiesModel();
                var query = from a in dbContext.nodeorganizationlocationwarehouseprofile select a;

                //string _filterEx = "i_IsDeleted==0";
                //query = query.Where(_filterEx);

                if (!string.IsNullOrEmpty(filterExpression))
                    query = query.Where(filterExpression);

                int intResult = query.Count();

                pobjOperationResult.Success = 1;
                return intResult;
            }
            catch (Exception ex)
            {
                pobjOperationResult.Success = 0;
                pobjOperationResult.ExceptionMessage = Common.Utils.ExceptionFormatter(ex);
                return 0;
            }
        }

        #endregion
        public List<RoleNodeList> GetRoleNode(ref OperationResult pobjOperationResult, int pintNodeId, string name)
        {
            //mon.IsActive = true;

            try
            {
                SigesoftEntitiesModel dbContext = new SigesoftEntitiesModel();
                name = name == null ? "" : name;
                var query = (from a in dbContext.rolenode
                        join b in dbContext.node on a.i_NodeId equals b.i_NodeId
                        join J2 in dbContext.systemparameter on new { a = a.i_RoleId, b = 115 }
                            equals new { a = J2.i_ParameterId, b = J2.i_GroupId } into J2_join
                        from J2 in J2_join.DefaultIfEmpty()
                        where a.i_NodeId == pintNodeId && a.i_IsDeleted == 0 && (J2.v_Value1.Contains(name) || name == "")
                        select new RoleNodeList
                        {
                            i_NodeId = b.i_NodeId,
                            i_RoleId = a.i_RoleId,
                            v_RoleName = J2.v_Value1,
                            //v_NodeName = b.v_Description
                        }
                    );

                List<RoleNodeList> objData = query.ToList();

                pobjOperationResult.Success = 1;
                return objData;
            }
            catch (Exception ex)
            {
                pobjOperationResult.Success = 0;
                pobjOperationResult.ExceptionMessage = Common.Utils.ExceptionFormatter(ex);
                return null;
            }
        }

        public RoleNodeList FindRoleNode(int pintNodeId, string name)
        {
            //mon.IsActive = true;

            try
            {
                SigesoftEntitiesModel dbContext = new SigesoftEntitiesModel();
                name = name == null ? "" : name;
                var query = (from a in dbContext.rolenode
                        join b in dbContext.node on a.i_NodeId equals b.i_NodeId
                        join J2 in dbContext.systemparameter on new { a = a.i_RoleId, b = 115 }
                            equals new { a = J2.i_ParameterId, b = J2.i_GroupId } into J2_join
                        from J2 in J2_join.DefaultIfEmpty()
                             where a.i_NodeId == pintNodeId && a.i_IsDeleted == 0 && J2.v_Value1 == name
                        select new RoleNodeList
                        {
                            i_NodeId = b.i_NodeId,
                            i_RoleId = a.i_RoleId,
                            v_RoleName = J2.v_Value1,
                            //v_NodeName = b.v_Description
                        }
                    );

                RoleNodeList objData = query.FirstOrDefault();

                return objData;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool AddRoleNode(int pintNodeId, string name, int userId)
        {
            //mon.IsActive = true;

            try
            {
                using (var ts = new TransactionScope())
                {
                    SigesoftEntitiesModel dbContext = new SigesoftEntitiesModel();

                    var listExistentes = dbContext.systemparameter.Where(x => x.i_GroupId == 115).ToList()
                        .OrderByDescending(x => x.i_ParameterId).ToList();

                    int ultimo = listExistentes[0].i_ParameterId + 1;

                    var objRoleNode = dbContext.rolenode.Where(x => x.i_NodeId == pintNodeId && x.i_RoleId == ultimo).FirstOrDefault();

                    while (objRoleNode != null)
                    {
                        ultimo++;
                        objRoleNode = dbContext.rolenode.Where(x => x.i_NodeId == pintNodeId && x.i_RoleId == ultimo).FirstOrDefault();
                    }

                    systemparameterDto system = new systemparameterDto();

                    system.i_GroupId = 115;
                    system.i_IsDeleted = 0;
                    system.i_ParentParameterId = -1;
                    system.i_InsertUserId = userId;
                    system.i_ParameterId = ultimo;
                    system.v_Value1 = name;
                    system.v_Value2 = "";
                    system.v_Field = "";
                    system.d_InsertDate = DateTime.Now;

                    systemparameter entity = systemparameterAssembler.ToEntity(system);
                    dbContext.AddTosystemparameter(entity);
                    dbContext.SaveChanges();


                    rolenodeDto _rolenode = new rolenodeDto();
                    _rolenode.i_NodeId = pintNodeId;
                    _rolenode.i_RoleId = ultimo;
                    _rolenode.i_IsDeleted = 0;
                    _rolenode.i_InsertUserId = userId;
                    _rolenode.d_InsertDate = DateTime.Now;

                    rolenode entityRoleNode = rolenodeAssembler.ToEntity(_rolenode);
                    dbContext.AddTorolenode(entityRoleNode);
                    dbContext.SaveChanges();


                    ts.Complete();
                }
                
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateRoleNode(int roleId, string name, int userId)
        {
            //mon.IsActive = true;

            try
            {
                SigesoftEntitiesModel dbContext = new SigesoftEntitiesModel();
                var obj = dbContext.systemparameter.Where(x => x.i_ParameterId == roleId && x.i_GroupId == 115).FirstOrDefault();
                obj.v_Value1 = name;
                obj.i_UpdateUserId = userId;
                obj.d_UpdateDate = DateTime.Now;
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteRoleNode(int roleId)
        {
            //mon.IsActive = true;

            try
            {
                SigesoftEntitiesModel dbContext = new SigesoftEntitiesModel();
                var obj = dbContext.systemparameter.Where(x => x.i_ParameterId == roleId && x.i_GroupId == 115).FirstOrDefault();
                obj.i_IsDeleted = 1;
                dbContext.SaveChanges();

                var objRoleNode = dbContext.rolenode.Where(x => x.i_RoleId == roleId).FirstOrDefault();
                objRoleNode.i_IsDeleted = 1;
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<NodeList> GetNodePagedAndFiltered(string pstrFilterExpression)
        {
            //mon.IsActive = true;

            try
            {
                SigesoftEntitiesModel dbContext = new SigesoftEntitiesModel();
                pstrFilterExpression = pstrFilterExpression == null ? "" : pstrFilterExpression;
                var query = (from n in dbContext.node
                             join sp1 in dbContext.systemparameter on new { i_ParameterId = n.i_NodeTypeId.Value }
                                                                   equals new { i_ParameterId = sp1.i_ParameterId } into sp1_join
                             from sp1 in sp1_join.DefaultIfEmpty()

                             join su2 in dbContext.systemuser on new { i_InsertUserId = n.i_InsertUserId.Value }
                                                           equals new { i_InsertUserId = su2.i_SystemUserId } into su2_join
                             from su2 in su2_join.DefaultIfEmpty()

                             join su3 in dbContext.systemuser on new { i_UpdateUserId = n.i_UpdateUserId.Value }
                                                           equals new { i_UpdateUserId = su3.i_SystemUserId } into su3_join
                             from su3 in su3_join.DefaultIfEmpty()
                             where n.i_IsDeleted == 0 &&
                                   sp1.i_GroupId == 105 &&    // Tipo de Nodo
                                   n.v_Description.Contains(pstrFilterExpression)
                             select new NodeList
                             {
                                 i_NodeId = n.i_NodeId,
                                 v_Description = n.v_Description,
                                 v_GeographyLocationId = n.v_GeografyLocationId,
                                 v_GeographyLocationDescription = n.v_GeografyLocationDescription,
                                 v_NodeTypeName = sp1.v_Value1,
                                 d_BeginDate = n.d_BeginDate,
                                 d_EndDate = n.d_EndDate,
                             }
                            );

                List<NodeList> objData = query.ToList();
                return objData;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<RoleNodeComponentProfileList> GetRoleNodeComponentProfileForGridView(ref OperationResult pobjOperationResult, int pintNodeId, int pintRoleId)
        {
            //mon.IsActive = true;

            try
            {
                SigesoftEntitiesModel dbContext = new SigesoftEntitiesModel();

                var query = (from a in dbContext.rolenodecomponentprofile
                        join b in dbContext.component on a.v_ComponentId equals b.v_ComponentId
                        where a.i_NodeId == pintNodeId &&
                              a.i_RoleId == pintRoleId &&
                              a.i_IsDeleted == 0
                        select new RoleNodeComponentProfileList
                        {
                            v_RoleNodeComponentId = a.v_RoleNodeComponentId,
                            i_NodeId = a.i_NodeId,
                            i_RoleId = a.i_RoleId,
                            v_ComponentName = b.v_Name,
                            v_Read = a.i_Read == 1 ? "Si" : "No",
                            v_Write = a.i_Write == 1 ? "Si" : "No",
                            v_Dx = a.i_Dx == 1 ? "Si" : "No",
                            v_Approved = a.i_Approved == 1 ? "Si" : "No"
                        }
                    );

                List<RoleNodeComponentProfileList> objData = query.ToList();

                pobjOperationResult.Success = 1;
                return objData;
            }
            catch (Exception ex)
            {
                pobjOperationResult.Success = 0;
                pobjOperationResult.ExceptionMessage = Common.Utils.ExceptionFormatter(ex);
                return null;
            }
        }

        public List<AutorizationList> GetRoleNodeProfile(ref OperationResult pobjOperationResult, int pintNodeId, int pintRoleId)
        {
            //mon.IsActive = true;

            try
            {
                SigesoftEntitiesModel dbContext = new SigesoftEntitiesModel();

                var list = (from a in dbContext.rolenodeprofile
                        join b in dbContext.applicationhierarchy on a.i_ApplicationHierarchyId equals b.i_ApplicationHierarchyId
                        where a.i_NodeId == pintNodeId && a.i_RoleId == pintRoleId &&
                              b.i_IsDeleted == 0 && a.i_IsDeleted == 0
                             select new AutorizationList
                        {
                            I_ApplicationHierarchyId = b.i_ApplicationHierarchyId,
                            V_Description = b.v_Description,
                            I_ParentId = b.i_ParentId,
                            i_IsNew = 0
                        }
                    ).ToList();



                pobjOperationResult.Success = 1;
                return list;
            }
            catch (Exception ex)
            {
                pobjOperationResult.Success = 0;
                pobjOperationResult.ExceptionMessage = Common.Utils.ExceptionFormatter(ex);
                return null;
            }
        }

        public void UpdateRoleNodeProfile(ref OperationResult pobjOperationResult, List<rolenodeprofileDto> ListRoleNodeProfileUpdate, List<rolenodeprofileDto> ListRoleNodeProfileDelete, List<string> ClientSession)
        {
            OperationResult operationResult1 = new OperationResult();
            OperationResult operationResult2 = new OperationResult();

            try
            {
                if (ListRoleNodeProfileUpdate != null)
                {
                    AddRoleNodeProfile(ref operationResult1, null, ListRoleNodeProfileUpdate, ClientSession, false);
                }

                if (ListRoleNodeProfileDelete != null)
                {
                    DeleteRoleNodeProfile(ref operationResult2, ListRoleNodeProfileDelete, ClientSession);
                }

                pobjOperationResult.Success = 1;
                // Llenar entidad Log

                LogBL.SaveLog(ClientSession[0], ClientSession[1], ClientSession[2], LogEventType.ACTUALIZACION, "NodoRolProfile", string.Empty, Success.Ok, null);
                return;
            }
            catch (Exception ex)
            {
                pobjOperationResult.Success = 0;
                pobjOperationResult.ExceptionMessage = Common.Utils.ExceptionFormatter(ex);
                LogBL.SaveLog(ClientSession[0], ClientSession[1], ClientSession[2], LogEventType.ACTUALIZACION, "NodoRolProfile", string.Empty, Success.Failed, pobjOperationResult.ExceptionMessage);
                return;
            }
        }

        private void DeleteRoleNodeProfile(ref OperationResult pobjOperationResult, List<rolenodeprofileDto> ListRoleNodeProfileDto, List<string> ClientSession)
        {

            //mon.IsActive = true;

            try
            {
                SigesoftEntitiesModel dbContext = new SigesoftEntitiesModel();

                foreach (var item in ListRoleNodeProfileDto)
                {
                    // Obtener la entidad fuente
                    var objroleNodeProfile = (from a in dbContext.rolenodeprofile
                        where a.i_NodeId == item.i_NodeId &&
                              a.i_RoleId == item.i_RoleId &&
                              a.i_ApplicationHierarchyId == item.i_ApplicationHierarchyId
                        select a).FirstOrDefault();

                    objroleNodeProfile.d_UpdateDate = DateTime.Now;
                    objroleNodeProfile.i_UpdateUserId = Int32.Parse(ClientSession[2]);
                    objroleNodeProfile.i_IsDeleted = 1;
                }

                pobjOperationResult.Success = 1;

                // Guardar los cambios
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                pobjOperationResult.Success = 0;
                pobjOperationResult.ExceptionMessage = Common.Utils.ExceptionFormatter(ex);

            }

        }

        public void AddRoleNodeProfile(ref OperationResult pobjOperationResult, rolenodeDto pobjRoleNode, List<rolenodeprofileDto> ListRoleNodeProfile, List<string> ClientSession, bool pbRegisterLog)
        {
            try
            {
                SigesoftEntitiesModel dbContext = new SigesoftEntitiesModel();

                #region RoleNode

                if (pobjRoleNode != null)
                {
                    var objrolenode = (from a in dbContext.rolenode
                                       where a.i_NodeId == pobjRoleNode.i_NodeId &&
                                       a.i_RoleId == pobjRoleNode.i_RoleId
                                       select a).FirstOrDefault();

                    if (objrolenode != null)
                    {
                        if (objrolenode.i_IsDeleted == 1)
                        {
                            OperationResult objOperationResult = new OperationResult();
                            UpdateRoleNodeChangeStatus(ref objOperationResult, pobjRoleNode.i_NodeId, pobjRoleNode.i_RoleId, 0, ClientSession);
                        }
                    }
                    else
                    {
                        // Grabar como nuevo
                        var objRoleNode = rolenodeAssembler.ToEntity(pobjRoleNode);

                        objRoleNode.d_InsertDate = DateTime.Now;
                        objRoleNode.i_InsertUserId = Int32.Parse(ClientSession[2]);
                        objRoleNode.i_IsDeleted = 0;
                        dbContext.AddTorolenode(objRoleNode);
                        dbContext.SaveChanges();
                    }
                }

                #endregion

                #region RoleNodeProfile

                foreach (var item in ListRoleNodeProfile)
                {
                    var objroleNodeProfile = (from a in dbContext.rolenodeprofile
                                              where a.i_NodeId == item.i_NodeId &&
                                              a.i_RoleId == item.i_RoleId &&
                                              a.i_ApplicationHierarchyId == item.i_ApplicationHierarchyId
                                              select a).FirstOrDefault();

                    if (objroleNodeProfile != null)
                    {
                        if (objroleNodeProfile.i_IsDeleted == 1)
                        {
                            OperationResult objOperationResult = new OperationResult();
                            UpdateRoleNodeProfileChangeStatus(ref objOperationResult, item.i_NodeId, item.i_RoleId, item.i_ApplicationHierarchyId, 0, ClientSession);
                        }
                    }
                    else
                    {
                        // Grabar como nuevo
                        var objEntity = rolenodeprofileAssembler.ToEntity(item);

                        objEntity.d_InsertDate = DateTime.Now;
                        objEntity.i_InsertUserId = Int32.Parse(ClientSession[2]);
                        objEntity.i_IsDeleted = 0;
                        dbContext.AddTorolenodeprofile(objEntity);
                        dbContext.SaveChanges();
                    }
                }

                #endregion

                pobjOperationResult.Success = 1;

                if (pbRegisterLog == true)
                {
                    // Llenar entidad Log
                    LogBL.SaveLog(ClientSession[0], ClientSession[1], ClientSession[2], LogEventType.CREACION, "Nodo / Rol", "i_NodeId=" + pobjRoleNode.i_NodeId + "i_RoleId=" + pobjRoleNode.i_RoleId, Success.Ok, null);
                }

                return;
            }
            catch (Exception ex)
            {
                pobjOperationResult.Success = 0;
                pobjOperationResult.ExceptionMessage = Common.Utils.ExceptionFormatter(ex);
                LogBL.SaveLog(ClientSession[0], ClientSession[1], ClientSession[2], LogEventType.CREACION, "Nodo / Rol", "i_NodeId=" + pobjRoleNode.i_NodeId + "i_RoleId=" + pobjRoleNode.i_RoleId, Success.Failed, pobjOperationResult.ExceptionMessage);
                return;
            }

        }

        public void UpdateRoleNodeChangeStatus(ref OperationResult pobjOperationResult, int pintNodeId, int pintRoleId, int pintIsDeleted, List<string> ClientSession)
        {
            try
            {
                SigesoftEntitiesModel dbContext = new SigesoftEntitiesModel();

                #region RoleNode
                // Obtener la entidad fuente
                var objrolenode = (from a in dbContext.rolenode
                    where a.i_NodeId == pintNodeId &&
                          a.i_RoleId == pintRoleId
                    select a).FirstOrDefault();

                // Crear la entidad con los datos actualizados
                objrolenode.d_UpdateDate = DateTime.Now;
                objrolenode.i_UpdateUserId = Int32.Parse(ClientSession[2]);
                objrolenode.i_IsDeleted = pintIsDeleted;

                // Guardar los cambios
                dbContext.SaveChanges();
                #endregion

                pobjOperationResult.Success = 1;
                return;
            }
            catch (Exception ex)
            {
                pobjOperationResult.Success = 0;
                pobjOperationResult.ExceptionMessage = Common.Utils.ExceptionFormatter(ex);
                
            }
        }

        public void UpdateRoleNodeProfileChangeStatus(ref OperationResult pobjOperationResult, int pintNodeId, int pintRoleId, int pintApplicationHierarchyId, int pintIsDeleted, List<string> ClientSession)
        {
            try
            {
                SigesoftEntitiesModel dbContext = new SigesoftEntitiesModel();

                #region RoleNodeProfile
                // Obtener la entidad fuente
                var objroleNodeProfile = (from a in dbContext.rolenodeprofile
                                          where a.i_NodeId == pintNodeId &&
                                          a.i_RoleId == pintRoleId &&
                                          a.i_ApplicationHierarchyId == pintApplicationHierarchyId
                                          select a).FirstOrDefault();

                if (objroleNodeProfile != null)
                {
                    objroleNodeProfile.d_UpdateDate = DateTime.Now;
                    objroleNodeProfile.i_UpdateUserId = Int32.Parse(ClientSession[2]);
                    objroleNodeProfile.i_IsDeleted = pintIsDeleted;

                    // Guardar los cambios
                    dbContext.SaveChanges();
                }
                #endregion

                pobjOperationResult.Success = 1;
               
                return;
            }
            catch (Exception ex)
            {
                pobjOperationResult.Success = 0;
                pobjOperationResult.ExceptionMessage = Common.Utils.ExceptionFormatter(ex);
                
            }
        }

        public void DeleteRoleAll(ref OperationResult pobjOperationResult, int pintNodeId, int pintRoleId, int pintIsDeleted, List<string> ClientSession)
        {
            try
            {
                SigesoftEntitiesModel dbContext = new SigesoftEntitiesModel();

                #region RoleNode
                // Obtener la entidad fuente
                var objrolenode = (from a in dbContext.rolenode
                                   where a.i_NodeId == pintNodeId &&
                                   a.i_RoleId == pintRoleId
                                   select a).FirstOrDefault();

                // Crear la entidad con los datos actualizados
                objrolenode.d_UpdateDate = DateTime.Now;
                objrolenode.i_UpdateUserId = Int32.Parse(ClientSession[2]);
                objrolenode.i_IsDeleted = pintIsDeleted;

                // Guardar los cambios
                dbContext.SaveChanges();
                #endregion

                #region RoleNodeProfile
                // Obtener la entidad fuente
                var objroleNodeProfile = (from a in dbContext.rolenodeprofile
                                          where a.i_NodeId == pintNodeId &&
                                          a.i_RoleId == pintRoleId
                                          select a).ToList();

                if (objroleNodeProfile != null)
                {
                    foreach (var item in objroleNodeProfile)
                    {
                        item.d_UpdateDate = DateTime.Now;
                        item.i_UpdateUserId = Int32.Parse(ClientSession[2]);
                        item.i_IsDeleted = pintIsDeleted;
                    }

                    // Guardar los cambios
                    dbContext.SaveChanges();
                }
                #endregion

                pobjOperationResult.Success = 1;
                // Llenar entidad Log
                LogBL.SaveLog(ClientSession[0], ClientSession[1], ClientSession[2], LogEventType.ACTUALIZACION, "Nodo / Rol", "i_NodeId=" + pintNodeId + "i_RoleId=" + pintRoleId, Success.Ok, null);
                return;
            }
            catch (Exception ex)
            {
                pobjOperationResult.Success = 0;
                pobjOperationResult.ExceptionMessage = Common.Utils.ExceptionFormatter(ex);
                // Llenar entidad Log
                LogBL.SaveLog(ClientSession[0], ClientSession[1], ClientSession[2], LogEventType.ACTUALIZACION, "Nodo / Rol", "i_NodeId=" + pintNodeId + "i_RoleId=" + pintRoleId, Success.Failed, pobjOperationResult.ExceptionMessage);
            }
        }

        public List<CategoryCustom> GetComponentForRolNode()
        {
            SigesoftEntitiesModel dbContext = new SigesoftEntitiesModel();
            var listCategory = (from a in dbContext.component
                                join sys in dbContext.systemparameter on new { a = a.i_CategoryId.Value, b = 116} equals new { a = sys.i_ParameterId, b = sys.i_GroupId }
                                where a.i_IsDeleted == 0 && a.i_ComponentTypeId == (int?)ComponentType.Examen
                                select new CategoryCustom
                                {
                                    i_CategoryId = sys.i_ParameterId,
                                    v_CategoryName = sys.v_Value1,
                                }).ToList().GroupBy(x => x.i_CategoryId).Select(x => x.First()).ToList();

            var listExams = (from a in dbContext.component
                            where a.i_IsDeleted == 0 && a.i_ComponentTypeId == (int?)ComponentType.Examen
                            select new ExamCustom
                            {
                                i_CategoryId = a.i_CategoryId,
                                v_ComponentId = a.v_ComponentId,
                                v_ComponentName = a.v_Name,
                            }).ToList();

            foreach (var category in listCategory)
            {
                category.List = new List<ExamCustom>();
                var find = listExams.FindAll(x => x.i_CategoryId == category.i_CategoryId).ToList();
                if (find.Count > 0)
                {
                    category.List.AddRange(find);
                }
                
            }

            return listCategory;
        }

        public List<rolenodecomponentprofileDto> GetComponentForRolNodeByNodeRole(int nodeId, int roleId)
        {
            SigesoftEntitiesModel ctx = new SigesoftEntitiesModel();
            var list = (from a in ctx.rolenodecomponentprofile
                        where a.i_NodeId == nodeId && a.i_RoleId == roleId && a.i_IsDeleted == 0
                        select new rolenodecomponentprofileDto
                        {
                            i_NodeId = a.i_NodeId,
                            i_RoleId = a.i_RoleId,
                            i_Approved = a.i_Approved,
                            i_Dx = a.i_Dx,
                            i_Read = a.i_Read,
                            i_Write = a.i_Write,
                            v_ComponentId = a.v_ComponentId,
                            v_RoleNodeComponentId = a.v_RoleNodeComponentId,
                            i_IsDeleted = a.i_IsDeleted,
                        }).ToList();

            return list;
        }

        public void UpdateRoleNodeComponent(bool lec, bool esc, bool dx, bool apro, string rolecompoid)
        {
            SigesoftEntitiesModel ctx = new SigesoftEntitiesModel();
            var objEntity = ctx.rolenodecomponentprofile.Where(x => x.v_RoleNodeComponentId == rolecompoid).FirstOrDefault();
            objEntity.i_Read = lec ? 1 : 0;
            objEntity.i_Write = esc ? 1 : 0;
            objEntity.i_Dx = dx ? 1 : 0;
            objEntity.i_Approved = apro ? 1 : 0;
            ctx.SaveChanges();
        }

        public bool DeleteRoleNodeComponentProfile(string id)
        {
            try
            {
                SigesoftEntitiesModel cnx = new SigesoftEntitiesModel();
                var entity = cnx.rolenodecomponentprofile.Where(x => x.v_RoleNodeComponentId == id).FirstOrDefault();
                entity.i_IsDeleted = 1;
                cnx.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }    
            
        }

        public bool AddRoleNodeComponentProfile(rolenodecomponentprofileDto data, int userId, int nodeId)
        {
            try
            {
                SigesoftEntitiesModel cnx = new SigesoftEntitiesModel();

                var newId = Common.Utils.GetNewId(nodeId, Utils.GetNextSecuentialId(nodeId, 26), "RC"); ;
                data.i_IsDeleted = 0;
                data.d_InsertDate = DateTime.Now;
                data.i_InsertUserId = userId;
                data.v_RoleNodeComponentId = newId;

                rolenodecomponentprofile entity = rolenodecomponentprofileAssembler.ToEntity(data);
                cnx.AddTorolenodecomponentprofile(entity);
                cnx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
