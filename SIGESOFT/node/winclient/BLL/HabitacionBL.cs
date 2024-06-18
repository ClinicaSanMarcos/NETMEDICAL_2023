using Sigesoft.Node.WinClient.BE.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using Sigesoft.Common;
using Sigesoft.Node.WinClient.DAL;
using Dapper;
using Sigesoft.Node.WinClient.BE;
//using Sigesoft.Node.WinClient.UI;

namespace Sigesoft.Node.WinClient.BLL
{
    public class HabitacionBL
    {
        public List<HabitacionCustom> GetHabitaciones(string value)
        {
            try
            {
                SigesoftEntitiesModel cnx = new SigesoftEntitiesModel();

                var listHabitaciones = (from sys in cnx.systemparameter
                                        where sys.i_GroupId == 309 && sys.i_IsDeleted == 0
                    select sys).ToList();

                var listHabitacionesHosp = (from hab in cnx.hospitalizacionhabitacion
                                            where hab.i_EstateRoom != null && (hab.i_EstateRoom == 1 || hab.i_EstateRoom == 2) && hab.i_IsDeleted == 0
                                            select hab).ToList();
                List<HabitacionCustom> ListHabit = new List<HabitacionCustom>();
                foreach (var habit in listHabitaciones)
                {
                    HabitacionCustom objHabit = new HabitacionCustom();
                    if (listHabitacionesHosp.Count > 0)
                    {
                        var objHab = listHabitacionesHosp.FindAll(x => x.i_HabitacionId == habit.i_ParameterId).FirstOrDefault();
                        if (objHab != null)
                        {
                            if (objHab.i_EstateRoom == (int)EstadoHabitacion.Ocupado)
                            {
                                objHabit.Habitacion = habit.v_Value1;
                                objHabit.Estado = "OCUPADO";
                                objHabit.i_HabitacionId = habit.i_ParameterId;
                                objHabit.v_HospHabitacionId = objHab.v_HospitalizacionHabitacionId;

                                objHabit.Comentarios = habit.v_ComentaryUpdate;

                            }
                            else
                            {
                                objHabit.Habitacion = habit.v_Value1;
                                objHabit.Estado = "EN LIMPIEZA";
                                objHabit.i_HabitacionId = habit.i_ParameterId;
                                objHabit.v_HospHabitacionId = objHab.v_HospitalizacionHabitacionId;

                                objHabit.Comentarios = habit.v_ComentaryUpdate;

                            }
                            
                        }
                        else
                        {
                            objHabit.Habitacion = habit.v_Value1;
                            objHabit.Estado = "LIBRE";
                            objHabit.i_HabitacionId = habit.i_ParameterId;

                            objHabit.Comentarios = habit.v_ComentaryUpdate;

                        }
                    }
                    else
                    {
                        objHabit.Habitacion = habit.v_Value1;
                        objHabit.Estado = "LIBRE";
                        objHabit.i_HabitacionId = habit.i_ParameterId;

                        objHabit.Comentarios = habit.v_ComentaryUpdate;

                    }
                    ListHabit.Add(objHabit);
                }

                return ListHabit.OrderBy(x => x.Habitacion).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<HabitacionCustom> GetHabitacionesViewEdit(string value)
        {
            try
            {
                SigesoftEntitiesModel cnx = new SigesoftEntitiesModel();

                var listHabitaciones = (from sys in cnx.systemparameter
                                        join B in cnx.systemuser on new { a = sys.i_InsertUserId.Value }
                                                                    equals new { a = B.i_SystemUserId } into B_join
                                        from B in B_join.DefaultIfEmpty()

                                        join C in cnx.systemuser on new { a = sys.i_UpdateUserId.Value }
                                                                    equals new { a = C.i_SystemUserId } into C_join
                                        from C in C_join.DefaultIfEmpty()
                                                                        
                                        where sys.i_GroupId == 309 && sys.i_IsDeleted == 0
                                        select new HabitacionCustom 
                                        {
                                            Habitacion = sys.v_Value1,
                                            i_HabitacionId = sys.i_ParameterId,
                                            Precio = sys.v_Value2,

                                            UsuarioCreaId = sys.i_InsertUserId,
                                            FechaCrea = sys.d_InsertDate.Value,
                                            UsuarioActualizaId = sys.i_InsertUserId,
                                            FechaActualiza = sys.d_UpdateDate.Value,
                                            UsuarioCrea = B.v_UserName == null ? "- - -" : B.v_UserName,
                                            UsuarioActualiza = C.v_UserName == null ? "- - -" : C.v_UserName,
                                            Comentarios = sys.v_ComentaryUpdate == null ? "- - -" : sys.v_ComentaryUpdate
                                        }).ToList();

                var listHabitacionesHosp = (from hab in cnx.hospitalizacionhabitacion
                                            where hab.i_EstateRoom != null && (hab.i_EstateRoom == 1 || hab.i_EstateRoom == 2) && hab.i_IsDeleted == 0
                                            select hab).ToList();
                List<HabitacionCustom> ListHabit = new List<HabitacionCustom>();
                foreach (var habit in listHabitaciones)
                {
                    HabitacionCustom objHabit = new HabitacionCustom();
                    if (listHabitacionesHosp.Count > 0)
                    {
                        var objHab = listHabitacionesHosp.FindAll(x => x.i_HabitacionId == habit.i_HabitacionId).FirstOrDefault();
                        if (objHab != null)
                        {
                            objHabit.Habitacion = habit.Habitacion;
                            if (objHab.i_EstateRoom == (int)EstadoHabitacion.Ocupado)
                            {
                                objHabit.Estado = "OCUPADO";
                            }
                            else
                            {
                                //objHabit.Habitacion = habit.Habitacion;
                                objHabit.Estado = "EN LIMPIEZA";
                                //objHabit.i_HabitacionId = habit.i_HabitacionId;
                                //objHabit.v_HospHabitacionId = objHab.v_HospitalizacionHabitacionId;
                            }

                            objHabit.i_HabitacionId = habit.i_HabitacionId;
                            objHabit.v_HospHabitacionId = objHab.v_HospitalizacionHabitacionId;

                            objHabit.Precio = habit.Precio;
                            objHabit.UsuarioCreaId = habit.UsuarioCreaId;
                            objHabit.FechaCrea = habit.FechaCrea;
                            objHabit.UsuarioActualizaId = habit.UsuarioActualizaId;
                            objHabit.FechaActualiza = habit.FechaActualiza;
                            objHabit.UsuarioCrea = habit.UsuarioCrea;
                            objHabit.UsuarioActualiza = habit.UsuarioActualiza;
                            objHabit.Comentarios = habit.Comentarios;

                        }
                        else
                        {
                            objHabit.Habitacion = habit.Habitacion;
                            objHabit.Estado = "LIBRE";
                            objHabit.i_HabitacionId = habit.i_HabitacionId;

                            objHabit.Precio = habit.Precio;
                            objHabit.UsuarioCreaId = habit.UsuarioCreaId;
                            objHabit.FechaCrea = habit.FechaCrea;
                            objHabit.UsuarioActualizaId = habit.UsuarioActualizaId;
                            objHabit.FechaActualiza = habit.FechaActualiza;
                            objHabit.UsuarioCrea = habit.UsuarioCrea;
                            objHabit.UsuarioActualiza = habit.UsuarioActualiza;
                            objHabit.Comentarios = habit.Comentarios;
                        }
                    }
                    else
                    {
                        objHabit.Habitacion = habit.Habitacion;
                        objHabit.Estado = "LIBRE";
                        objHabit.i_HabitacionId = habit.i_HabitacionId;

                        objHabit.Precio = habit.Precio;
                        objHabit.UsuarioCreaId = habit.UsuarioCreaId;
                        objHabit.FechaCrea = habit.FechaCrea;
                        objHabit.UsuarioActualizaId = habit.UsuarioActualizaId;
                        objHabit.FechaActualiza = habit.FechaActualiza;
                        objHabit.UsuarioCrea = habit.UsuarioCrea;
                        objHabit.UsuarioActualiza = habit.UsuarioActualiza;
                        objHabit.Comentarios = habit.Comentarios;
                    }
                    ListHabit.Add(objHabit);
                }

                return ListHabit.OrderBy(x => x.Habitacion).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public bool GetHabitacionByHabitacionId(string hospitalizacionId)
        {
            SigesoftEntitiesModel cnx = new SigesoftEntitiesModel();

            var query = (from hosp in cnx.hospitalizacionhabitacion
                where hosp.v_HopitalizacionId == hospitalizacionId select hosp).ToList();

            if (query.Count > 0)
            {
                int ultimo = query.Count - 1;
                int habitacionId = query[ultimo].i_HabitacionId.Value;
                var habitacion = (from hosp in cnx.hospitalizacionhabitacion
                                  where hosp.i_HabitacionId == habitacionId && hosp.i_EstateRoom == (int)EstadoHabitacion.Ocupado
                                  select hosp).FirstOrDefault();

                if (habitacion != null)
                {
                    return true;
                }
                else
                {
                    var ponerOcupado = (from hosp in cnx.hospitalizacionhabitacion
                        where hosp.v_HopitalizacionId == hospitalizacionId
                        select hosp).ToList();

                    ponerOcupado[ultimo].i_EstateRoom = (int) EstadoHabitacion.Ocupado;
                    cnx.SaveChanges();
                }
            }
            

            return false;
        }

        public void UpdateEstateHabitacion(int Estate, int HabitacionId, string HospitalizacionHabId)
        {
            try
            {

                SigesoftEntitiesModel cnx = new SigesoftEntitiesModel();
                var objHospHab = (from hosp in cnx.hospitalizacionhabitacion
                    where hosp.v_HospitalizacionHabitacionId == HospitalizacionHabId
                    select hosp).FirstOrDefault();

                if (objHospHab != null)
                {
                    objHospHab.i_EstateRoom = Estate;
                    cnx.SaveChanges();
                }
                
            }
            catch (Exception e)
            {
                return;
            }
            
        }

        public void UpdateEstateHabitacionLimpieza(string HospitalizacionId, string nroHabitacion)
        {
            try
            {

                SigesoftEntitiesModel cnx = new SigesoftEntitiesModel();

                var HabitacionObj = cnx.systemparameter.Where(x => x.i_GroupId == 309 && x.v_Value1 == nroHabitacion).FirstOrDefault();


                int habitacionId = HabitacionObj.i_ParameterId;
                var ListHospHab = (from hosp in cnx.hospitalizacionhabitacion
                                   where hosp.v_HopitalizacionId == HospitalizacionId && hosp.i_EstateRoom == (int)EstadoHabitacion.Libre && hosp.i_HabitacionId == habitacionId
                                   select hosp).ToList();

                if (ListHospHab.Count > 0)
                {
                    int ultimo = ListHospHab.Count - 1;
                    ListHospHab[ultimo].i_EstateRoom = (int)EstadoHabitacion.EnLimpieza;
                    cnx.SaveChanges();
                }

            }
            catch (Exception e)
            {
                return;
            }

        }
        public bool UpdateEstateHabitacionByHospId(string hospId)
        {
            try
            {

                SigesoftEntitiesModel cnx = new SigesoftEntitiesModel();
                var objHospHab = (from hosp in cnx.hospitalizacionhabitacion
                                  where hosp.v_HopitalizacionId == hospId && (hosp.i_EstateRoom == (int)EstadoHabitacion.Ocupado || hosp.i_EstateRoom == (int)EstadoHabitacion.EnLimpieza)
                    select hosp).FirstOrDefault();
                if (objHospHab != null)
                {
                    objHospHab.i_EstateRoom = (int)EstadoHabitacion.EnLimpieza;
                    objHospHab.d_EndDate = DateTime.Now;

                    cnx.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public string AddCama(ref OperationResult objOperationResult, systemparameterDto _systemparameter, List<string> ClientSession)
        {
            string NewId0 = null;
            try
            {
                SigesoftEntitiesModel cnx = new SigesoftEntitiesModel();

                var listHabitaciones = (from sys in cnx.systemparameter
                                        where sys.i_GroupId == 309
                                        select sys).ToList();

                listHabitaciones = listHabitaciones.OrderByDescending(p => p.i_ParameterId).ToList();
                int parameter = listHabitaciones[0].i_ParameterId + 1;
                NewId0 = parameter.ToString();

                using (var cnxs = Sigesoft.Node.WinClient.UI.ConnectionHelperSige.GetConnection)
                {

                    var queryDetails = "INSERT INTO systemparameter (i_GroupId, i_ParameterId, v_Value1, v_Value2, v_Field, i_ParentParameterId, i_IsDeleted, i_InsertUserId, d_InsertDate, v_ComentaryUpdate, i_Estado) " +
                                       "VALUES (309, " + parameter + " , '" + _systemparameter.v_Value1 + "', '" + _systemparameter.v_Value2 + "' , '' , -1, 0, " + ClientSession[2] + ", GETDATE(), '" + _systemparameter.v_ComentaryUpdate + "', 0)";
                    cnxs.Execute(queryDetails);
                }


                // Llenar entidad Log
                LogBL.SaveLog(ClientSession[0], ClientSession[1], ClientSession[2], LogEventType.CREACION, "SP_309", "i_ParameterId=" + NewId0.ToString(), Success.Ok, null);
            }
            catch (Exception ex)
            {
                objOperationResult.Success = 0;
                objOperationResult.ExceptionMessage = Common.Utils.ExceptionFormatter(ex);
                // Llenar entidad Log
                LogBL.SaveLog(ClientSession[0], ClientSession[1], ClientSession[2], LogEventType.CREACION, "SP_309", "i_ParameterId=" + NewId0.ToString(), Success.Failed, objOperationResult.ExceptionMessage);
            }
            return NewId0;
        }


        public void UpdateCama(ref OperationResult objOperationResult, systemparameterDto _systemparameter, List<string> ClientSession)
        {
            try
            {
                

                using (var cnxs = Sigesoft.Node.WinClient.UI.ConnectionHelperSige.GetConnection)
                {

                    var queryDetails = @"update systemparameter set v_Value1 = '" + _systemparameter.v_Value1 + @"',
				                    v_Value2 = '" + _systemparameter.v_Value2 + @"',
				                    v_ComentaryUpdate = '" + _systemparameter.v_ComentaryUpdate + @"',
				                    i_UpdateUserId = " + ClientSession[2] + @" ,
				                    d_UpdateDate = GETDATE()
				                     where i_GroupId = 309 and i_ParameterId = " + _systemparameter.i_ParameterId;

                    cnxs.Execute(queryDetails);
                }

                // Llenar entidad Log
                LogBL.SaveLog(ClientSession[0], ClientSession[1], ClientSession[2], LogEventType.ACTUALIZACION, "SP_309 / UPDATE", "v_TicketId=" + _systemparameter.i_ParameterId, Success.Ok, null);
            }
            catch (Exception ex)
            {
                objOperationResult.Success = 0;
                objOperationResult.ExceptionMessage = Common.Utils.ExceptionFormatter(ex);
                // Llenar entidad Log
                LogBL.SaveLog(ClientSession[0], ClientSession[1], ClientSession[2], LogEventType.ACTUALIZACION, "SP_309 / UPDATE", "i_ParameterId=" + _systemparameter.i_ParameterId, Success.Failed, objOperationResult.ExceptionMessage);
            
            }
            return;
        }

        public void DeleteCama(ref OperationResult objOperationResult, int parametroCuarto, List<string> ClientSession)
        {
            try
            {


                using (var cnxs = Sigesoft.Node.WinClient.UI.ConnectionHelperSige.GetConnection)
                {

                    var queryDetails = @"update systemparameter set i_IsDeleted = 1 , 
				                    i_UpdateUserId = " + ClientSession[2] + @" ,
				                    d_UpdateDate = GETDATE()
				                     where i_GroupId = 309 and i_ParameterId = " + parametroCuarto;

                    cnxs.Execute(queryDetails);
                }

                // Llenar entidad Log
                LogBL.SaveLog(ClientSession[0], ClientSession[1], ClientSession[2], LogEventType.ACTUALIZACION, "SP_309 / ELIMINADO", "i_ParameterId=" + parametroCuarto, Success.Ok, null);
            }
            catch (Exception ex)
            {
                objOperationResult.Success = 0;
                objOperationResult.ExceptionMessage = Common.Utils.ExceptionFormatter(ex);
                // Llenar entidad Log
                LogBL.SaveLog(ClientSession[0], ClientSession[1], ClientSession[2], LogEventType.ACTUALIZACION, "SP_309 / ELIMINADO", "i_ParameterId=" + parametroCuarto, Success.Failed, objOperationResult.ExceptionMessage);

            }
            return;
        }

        public void LiberarCama(ref OperationResult objOperationResult, int parametroCuarto, List<string> ClientSession)
        {
            try
            {


                using (var cnxs = Sigesoft.Node.WinClient.UI.ConnectionHelperSige.GetConnection)
                {

                    var queryDetails = @"update hospitalizacionhabitacion set i_EstateRoom = 3, v_ComentaryUpdate = convert(varchar(100),GETDATE()) + 'ACTUALIZADO POR NO LIBERAR CORRECTAMENTE LAS HABITACIONES' where i_HabitacionId = " + parametroCuarto + " AND i_EstateRoom != 3";

                    cnxs.Execute(queryDetails);
                }

                // Llenar entidad Log
                LogBL.SaveLog(ClientSession[0], ClientSession[1], ClientSession[2], LogEventType.ACTUALIZACION, "HOSPITALIZACION_HABITACIONlIBERACION / LIBERADO", "i_ParameterId=" + parametroCuarto + DateTime.Now.ToString(), Success.Ok, null);
            }
            catch (Exception ex)
            {
                objOperationResult.Success = 0;
                objOperationResult.ExceptionMessage = Common.Utils.ExceptionFormatter(ex);
                // Llenar entidad Log
                LogBL.SaveLog(ClientSession[0], ClientSession[1], ClientSession[2], LogEventType.ACTUALIZACION, "HOSPITALIZACION_HABITACIONlIBERACION / LIBERADO", "i_ParameterId=" + parametroCuarto + DateTime.Now.ToString(), Success.Failed, objOperationResult.ExceptionMessage);

            }
            return;
        }

    }
}
