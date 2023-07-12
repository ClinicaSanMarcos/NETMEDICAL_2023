using Sigesoft.Common;
using Sigesoft.Node.WinClient.BE;
using Sigesoft.Node.WinClient.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sigesoft.Node.WinClient.BLL
{
   public class AplicationHierarchyBL
    {
       public List<applicationhierarchyDto> ObtenerFormularios()
       {
           try
           {
               using (SigesoftEntitiesModel ctx  =new SigesoftEntitiesModel())
               {
                  //var query =  from a in ctx.applicationhierarchy
                  //             where a.
               }

               return null;
           }
           catch (Exception ex)
           {               
               throw;
           }
       }

       public List<applicationhierarchyDto> GetApplicationHierarchyByScopeId(ref OperationResult pobjOperationResult, int pintScopeId)
       {
           //mon.IsActive = true;
           try
           {
               SigesoftEntitiesModel dbContext = new SigesoftEntitiesModel();
               List<applicationhierarchyDto> oListApplicationHierarchy;

               oListApplicationHierarchy = (from a in dbContext.applicationhierarchy
                                            orderby a.v_Description
                                            where (a.i_ScopeId == pintScopeId) &&
                                                  (a.i_IsDeleted == 0) &&
                                                  (a.i_ExternalUserFunctionalityTypeId == null) ||   // Ocultar Permisos externos
                                                  (a.i_ScopeId == -1)
                                            select new applicationhierarchyDto
                                            {
                                                i_ApplicationHierarchyId = a.i_ApplicationHierarchyId,
                                                i_ApplicationHierarchyTypeId = a.i_ApplicationHierarchyTypeId,
                                                i_Level = a.i_Level,
                                                v_Description = a.v_Description,
                                                v_Form = a.v_Form,
                                                i_ParentId = a.i_ParentId,
                                                i_ScopeId = a.i_ScopeId,
                                                v_Code = a.v_Code
                                            }).ToList();
               pobjOperationResult.Success = 1;
               return oListApplicationHierarchy;
           }
           catch (Exception ex)
           {
               pobjOperationResult.Success = 0;
               pobjOperationResult.ExceptionMessage = ex.Message;
               return null;
           }

       }
    }
}
