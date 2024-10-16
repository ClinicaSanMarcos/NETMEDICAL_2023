﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Dynamic;
using Sigesoft.Node.WinClient.BE;
using Sigesoft.Node.WinClient.DAL;
using Sigesoft.Common;
using System.Data.Objects;

using System.Data.SqlClient;
using System.Data;
using System.Transactions;
using Dapper;
//using ConnectionState = System.Data.ConnectionState;
using Sigesoft.Node.WinClient.BE.Custom;
using Sigesoft.Node.WinClient.UI;

namespace Sigesoft.Node.WinClient.BLL
{
    public class HospitalizacionBL
    {
        public List<HospitalizacionList> GetHospitalizacionPagedAndFiltered_OLD(ref OperationResult pobjOperationResult, int? pintPageIndex, int? pintResultsPerPage, string pstrSortExpression, string pstrFilterExpression, DateTime? pdatBeginDate, DateTime? pdatEndDate)
        {
            try
            {
                SigesoftEntitiesModel dbContext = new SigesoftEntitiesModel();

                var query = from A in dbContext.hospitalizacion
                            join B in dbContext.person on A.v_PersonId equals B.v_PersonId
                            join C in dbContext.hospitalizacionservice on A.v_HopitalizacionId equals C.v_HopitalizacionId
                            join D in dbContext.service on C.v_ServiceId equals D.v_ServiceId
                            join A1 in dbContext.calendar on D.v_ServiceId equals A1.v_ServiceId
                            join P in dbContext.protocol on D.v_ProtocolId equals P.v_ProtocolId
                            join S in dbContext.systemparameter on new { a = P.i_MasterServiceId.Value, b = 119 }
                                equals new { a = S.i_ParameterId, b = S.i_GroupId }

                            join E in dbContext.servicecomponent on D.v_ServiceId equals E.v_ServiceId

                            join F in dbContext.systemuser on E.i_MedicoTratanteId equals F.i_SystemUserId  into F_join
                                from F in F_join.DefaultIfEmpty()

                            join G in dbContext.person on F.v_PersonId equals G.v_PersonId into G_join
                            from G in G_join.DefaultIfEmpty()

                            join H in dbContext.professional on G.v_PersonId equals H.v_PersonId into H_join
                            from H in H_join.DefaultIfEmpty()

                            //join G in dbContext.product on F.v_IdProductoDetalle equals G.v_ProductId

                            where A.i_IsDeleted == 0
                                  && (A.d_FechaIngreso >= pdatBeginDate.Value && A.d_FechaIngreso <= pdatEndDate.Value)
                                  && A1.i_CalendarStatusId != 4

                            select new HospitalizacionList
                            {
                                d_FechaAlta = A.d_FechaAlta,
                                d_FechaIngreso = A.d_FechaIngreso,
                                v_Paciente = B.v_FirstLastName + " " +B.v_SecondLastName + ", " +B.v_FirstName,
                                v_HopitalizacionId = A.v_HopitalizacionId,
                                v_PersonId = A.v_PersonId,
                                v_DocNumber = B.v_DocNumber,
                                d_Birthdate = B.d_Birthdate.Value,
                                i_IsDeleted = A.i_IsDeleted.Value,
                                v_Comentario = A.v_Comentario,
                                v_NroLiquidacion = A.v_NroLiquidacion,
                                d_PagoMedico = A.d_PagoMedico,
                                i_MedicoPago = A.i_MedicoPago,
                                d_PagoPaciente = A.d_PagoPaciente,
                                i_PacientePago = A.i_PacientePago,
                                v_MedicoTratante = G.v_FirstLastName + " " + G.v_SecondLastName + ", " + G.v_FirstName,
                                v_Servicio = S.v_Value1
                            };

                if (!string.IsNullOrEmpty(pstrFilterExpression))
                {
                    query = query.Where(pstrFilterExpression);
                }
                //if (pdatBeginDate.HasValue && pdatEndDate.HasValue)
                //{
                //    query = query.Where("d_FechaIngreso >= @0 && d_FechaIngreso <= @1", pdatBeginDate.Value, pdatEndDate.Value);
                //}
                if (!string.IsNullOrEmpty(pstrSortExpression))
                {
                    query = query.OrderBy(pstrSortExpression);
                }
                if (pintPageIndex.HasValue && pintResultsPerPage.HasValue)
                {
                    int intStartRowIndex = pintPageIndex.Value * pintResultsPerPage.Value;
                    query = query.Skip(intStartRowIndex);
                }
                if (pintResultsPerPage.HasValue)
                {
                    query = query.Take(pintResultsPerPage.Value);
                }

                List<HospitalizacionList> objData = query.ToList();
                // en hospitalizaciones tienes los padres
                var hospitalizaciones = (from a in objData
                         select new HospitalizacionList
                         {
                            v_Paciente = a.v_Paciente,
                            d_FechaIngreso = a.d_FechaIngreso,
                            d_FechaAlta = a.d_FechaAlta,
                            v_HopitalizacionId = a.v_HopitalizacionId,
                            v_PersonId = a.v_PersonId,
                            v_DocNumber = a.v_DocNumber,
                            i_Years = GetAge(a.d_Birthdate),
                            v_Comentario = a.v_Comentario,
                            v_NroLiquidacion = a.v_NroLiquidacion,
                            d_PagoMedico = a.d_PagoMedico,
                            MedicoPago = a.i_MedicoPago == 1 ? "SI" : a.d_PagoMedico == null? "SIN LIQUIDAR" : a.d_PagoMedico == 0? "---" : "NO",
                            d_PagoPaciente = a.d_PagoPaciente,
                            PacientePago = a.i_PacientePago == 1 ? "SI" : a.d_PagoPaciente == null ? "SIN LIQUIDAR" : a.d_PagoPaciente == 0 ? "---" : "NO",
                            v_MedicoTratante = a.v_MedicoTratante == "-1" ? " - - -": a.v_MedicoTratante == null ? " - - - " : a.v_MedicoTratante == "SAN LORENZO, CLINICA" ? "CLINICA SAN LORENZO": a.v_MedicoTratante,
                            v_Servicio = a.v_Servicio
                         }).ToList();

                var objtData = hospitalizaciones.AsEnumerable()
                    .Where(a => a.v_HopitalizacionId != null)
                    .GroupBy(b => b.v_HopitalizacionId)
                    .Select(group => group.First());

                List<HospitalizacionList> obj = objtData.ToList();
                
                HospitalizacionList hospit;
                List<HospitalizacionList> Lista = new List<HospitalizacionList>();

                var servicioMedico = obj.ToList().FindAll(p => p.v_Servicio != "EMERGENCIA").ToList();


                foreach (var item in servicioMedico)
                {
                    hospit = new HospitalizacionList();

                    hospit.v_HopitalizacionId = item.v_HopitalizacionId;
                    hospit.v_PersonId = item.v_PersonId;
                    hospit.v_Paciente = item.v_Paciente;
                    hospit.v_DocNumber = item.v_DocNumber;
                    hospit.i_Years = item.i_Years;
                    hospit.d_FechaIngreso = item.d_FechaIngreso;
                    hospit.d_FechaAlta = item.d_FechaAlta;
                    hospit.v_Comentario = item.v_Comentario;
                    hospit.v_NroLiquidacion = item.v_NroLiquidacion;
                    hospit.d_PagoMedico = item.d_PagoMedico;
                    hospit.MedicoPago = item.MedicoPago;
                    hospit.d_PagoPaciente = item.d_PagoPaciente;
                    hospit.PacientePago =item.PacientePago;
                    hospit.v_MedicoTratante = item.v_MedicoTratante;
                    hospit.v_Servicio = item.v_Servicio;

                    //// estos son los hijos de 1 hopitalización
                    //var servicios = BuscarServiciosHospitalizacion(item.v_HopitalizacionId).ToList();
                    
                    //List<HospitalizacionServiceList> HospitalizacionServicios = new List<HospitalizacionServiceList>();
                    //if (servicios.Count > 0)
                    //{
                    //    HospitalizacionServiceList oHospitalizacionServiceList;
                    //    ComponentesHospitalizacion oComponentesHospitalizacion;
                    //    foreach (var servicio in servicios)
                    //    {
                    //        oHospitalizacionServiceList = new HospitalizacionServiceList();
                    //        // acá vas poblando la entidad hijo hospitalización
                    //        oHospitalizacionServiceList.v_HopitalizacionId = servicio.v_HopitalizacionId;
                    //        oHospitalizacionServiceList.v_ServiceId = servicio.v_ServiceId;
                    //        oHospitalizacionServiceList.v_HospitalizacionServiceId = servicio.v_HospitalizacionServiceId;
                    //        oHospitalizacionServiceList.v_NroHospitalizacion = servicio.v_NroHospitalizacion;
                    //        oHospitalizacionServiceList.d_ServiceDate = servicio.d_ServiceDate;
                    //        oHospitalizacionServiceList.v_ProtocolName = servicio.v_ProtocolName;
                    //        oHospitalizacionServiceList.v_ProtocolId = servicio.v_ProtocolId;
                    //        oHospitalizacionServiceList.v_DocNumber = servicio.v_DocNumber;
                    //        oHospitalizacionServiceList.d_FechaAlta = servicio.d_FechaAlta;
                    //        // acá estoy agregando a las lista
                    //        HospitalizacionServicios.Add(servicio);
                    //    }
                    //    hospit.Servicios= HospitalizacionServicios;
                    //}

                    //#region Habitaciones
                    //var habitacioenes = BuscarHospitalizacionHabitaciones(item.v_HopitalizacionId).ToList();
                    //List<HospitalizacionHabitacionList> ListaHabitaciones = new List<HospitalizacionHabitacionList>();
                    //HospitalizacionHabitacionList oHospitalizacionHabitacionList;
                    //foreach (var habitacion in habitacioenes)
                    //{
                    //    oHospitalizacionHabitacionList = new HospitalizacionHabitacionList();
                    //    oHospitalizacionHabitacionList.v_HospitalizacionHabitacionId = habitacion.v_HospitalizacionHabitacionId;
                    //    oHospitalizacionHabitacionList.v_HopitalizacionId = item.v_HopitalizacionId;
                    //    oHospitalizacionHabitacionList.i_HabitacionId = habitacion.i_HabitacionId;
                    //    oHospitalizacionHabitacionList.NroHabitacion = habitacion.NroHabitacion;
                    //    oHospitalizacionHabitacionList.d_StartDate = habitacion.d_StartDate;
                    //    oHospitalizacionHabitacionList.d_EndDate = habitacion.d_EndDate;
                    //    oHospitalizacionHabitacionList.d_FechaAlta = habitacion.d_FechaAlta;
                    //    if ((decimal)habitacion.d_Precio != null)
                    //    {
                    //        oHospitalizacionHabitacionList.d_Precio = decimal.Round((decimal)habitacion.d_Precio, 2); 
                    //    }
                        
                    //    if (habitacion.d_Precio != null)
                    //        oHospitalizacionHabitacionList.Total =
                    //            CalcularCostoHabitacion(habitacion.d_Precio.ToString(), habitacion.d_StartDate,
                    //                habitacion.d_EndDate);
                    //    else
                    //        oHospitalizacionHabitacionList.Total = 0;
                    //    ListaHabitaciones.Add(oHospitalizacionHabitacionList);

                    //}
                    //hospit.Habitaciones = ListaHabitaciones;
                    //#endregion

                    Lista.Add(hospit);
                }
                pobjOperationResult.Success = 1;
                return Lista;

            }
            catch (Exception ex)
            {
                pobjOperationResult.Success = 0;
                pobjOperationResult.ExceptionMessage = Common.Utils.ExceptionFormatter(ex);
                return null;
            }
        }

        public List<HospSopList> GetHospitalizacionPagedAndFiltered(ref OperationResult pobjOperationResult, DateTime? pdatBeginDate, DateTime? pdatEndDate)
        {
            try
            {
                SigesoftEntitiesModel dbContext = new SigesoftEntitiesModel();

                var query = (from a in dbContext.gethospsoplist_sp(pdatBeginDate, pdatEndDate, "")
                                         select new HospSopList
                                         {   
                                             TipoDeIngreso  = a.TipoDeIngreso,
                                             TipoProcedimiento  = a.TipoProcedimiento,
                                             d_FechaIngreso_ = a.d_FechaIngreso.ToString(),
                                             d_FechaHoraCirugia_ = a.d_FechaHoraCirugia.ToString(),
                                             d_FechaHoraHospPac_ = a.d_FechaHoraHospPac.ToString(),
                                             d_FechaAlta_ = a.d_FechaAlta.ToString(),
                                             d_FechaAlta = a.d_FechaAlta,

                                             v_Paciente  = a.v_Paciente,
                                             TipoDocumento  = a.TipoDocumento,
                                             v_DocNumber  = a.v_DocNumber,
                                             HistoriaClinica  = a.HistoriaClinica,
                                             Edad  = a.Edad,
                                             v_Cie10  = a.v_Cie10,
                                             v_Diagnostico  = a.v_Diagnostico,
                                             v_MedicoTratante  = a.v_MedicoTratante,
                                             Especialidad  = a.Especialidad,
                                             Monto  = a.Monto,
                                             d_PagoMedico  = a.d_PagoMedico,
                                             MedicoPago  = a.MedicoPago,
                                             d_PagoPaciente  = a.d_PagoPaciente,
                                             PacientePago  = a.PacientePago,
                                             v_CIE10IdSalida  = a.v_CIE10IdSalida,
                                             v_DiseasesNameSalida  = a.v_DiseasesNameSalida,
                                             i_ProcedimientoSOP  = a.i_ProcedimientoSOP,
                                             v_ProcedimientoSOP  = a.v_ProcedimientoSOP,
                                             v_Servicio  = a.v_Servicio,
                                             v_NroLiquidacion  = a.v_NroLiquidacion,
                                             VendedorExterno  = a.VendedorExterno,
                                             v_Comentariox  =  a.v_Comentariox,
                                             v_HopitalizacionId  = a.v_HopitalizacionId,
                                             v_PersonId  = a.v_PersonId,
                                             i_IsDeleted  = a.i_IsDeleted,
                                             Value1  = a.Value1, //v_NroHospitalizacion
                                             Value2  = a.Value2,

                                             
                                         }).ToList();

                               
                pobjOperationResult.Success = 1;
                return query;

            }
            catch (Exception ex)
            {
                pobjOperationResult.Success = 0;
                pobjOperationResult.ExceptionMessage = Common.Utils.ExceptionFormatter(ex);
                return null;
            }
        }




        public List<HospitalizacionList> GetHospitalizacionPagedAndFilteredEmrg_Old(ref OperationResult pobjOperationResult, int? pintPageIndex, int? pintResultsPerPage, string pstrSortExpression, string pstrFilterExpression, DateTime? pdatBeginDate, DateTime? pdatEndDate)
        {
            try
            {
                SigesoftEntitiesModel dbContext = new SigesoftEntitiesModel();

                var query = from A in dbContext.hospitalizacion
                            join B in dbContext.person on A.v_PersonId equals B.v_PersonId
                            join C in dbContext.hospitalizacionservice on A.v_HopitalizacionId equals C.v_HopitalizacionId
                            join D in dbContext.service on C.v_ServiceId equals D.v_ServiceId
                            join A1 in dbContext.calendar on D.v_ServiceId equals A1.v_ServiceId
                            join P in dbContext.protocol on D.v_ProtocolId equals P.v_ProtocolId
                            join S in dbContext.systemparameter on new { a = P.i_MasterServiceId.Value, b = 119 }
                                equals new { a = S.i_ParameterId, b = S.i_GroupId }

                            join E in dbContext.servicecomponent on D.v_ServiceId equals E.v_ServiceId

                            join F in dbContext.systemuser on E.i_MedicoTratanteId equals F.i_SystemUserId into F_join
                            from F in F_join.DefaultIfEmpty()

                            join G in dbContext.person on F.v_PersonId equals G.v_PersonId into G_join
                            from G in G_join.DefaultIfEmpty()

                            join H in dbContext.professional on G.v_PersonId equals H.v_PersonId into H_join
                            from H in H_join.DefaultIfEmpty()

                            where A.i_IsDeleted == 0
                                  && (A.d_FechaIngreso >= pdatBeginDate.Value && A.d_FechaIngreso <= pdatEndDate.Value)
                                  && A1.i_CalendarStatusId != 4

                            select new HospitalizacionList
                            {
                                d_FechaAlta = A.d_FechaAlta,
                                d_FechaIngreso = A.d_FechaIngreso,
                                v_Paciente = B.v_FirstLastName + " " + B.v_SecondLastName + ", " + B.v_FirstName,
                                v_HopitalizacionId = A.v_HopitalizacionId,
                                v_PersonId = A.v_PersonId,
                                v_DocNumber = B.v_DocNumber,
                                d_Birthdate = B.d_Birthdate.Value,
                                i_IsDeleted = A.i_IsDeleted.Value,
                                v_Comentario = A.v_Comentario,
                                v_NroLiquidacion = A.v_NroLiquidacion,
                                d_PagoMedico = A.d_PagoMedico,
                                i_MedicoPago = A.i_MedicoPago,
                                d_PagoPaciente = A.d_PagoPaciente,
                                i_PacientePago = A.i_PacientePago,
                                v_MedicoTratante = G.v_FirstLastName + " " + G.v_SecondLastName + ", " + G.v_FirstName,
                                v_Servicio = S.v_Value1
                            };

                if (!string.IsNullOrEmpty(pstrFilterExpression))
                {
                    query = query.Where(pstrFilterExpression);
                }
                //if (pdatBeginDate.HasValue && pdatEndDate.HasValue)
                //{
                //    query = query.Where("d_FechaIngreso >= @0 && d_FechaIngreso <= @1", pdatBeginDate.Value, pdatEndDate.Value);
                //}
                if (!string.IsNullOrEmpty(pstrSortExpression))
                {
                    query = query.OrderBy(pstrSortExpression);
                }
                if (pintPageIndex.HasValue && pintResultsPerPage.HasValue)
                {
                    int intStartRowIndex = pintPageIndex.Value * pintResultsPerPage.Value;
                    query = query.Skip(intStartRowIndex);
                }
                if (pintResultsPerPage.HasValue)
                {
                    query = query.Take(pintResultsPerPage.Value);
                }

                List<HospitalizacionList> objData = query.ToList();
                // en hospitalizaciones tienes los padres
                var hospitalizaciones = (from a in objData
                                         select new HospitalizacionList
                                         {
                                             v_Paciente = a.v_Paciente,
                                             d_FechaIngreso = a.d_FechaIngreso,
                                             d_FechaAlta = a.d_FechaAlta,
                                             v_HopitalizacionId = a.v_HopitalizacionId,
                                             v_PersonId = a.v_PersonId,
                                             v_DocNumber = a.v_DocNumber,
                                             i_Years = GetAge(a.d_Birthdate),
                                             v_Comentario = a.v_Comentario,
                                             v_NroLiquidacion = a.v_NroLiquidacion,
                                             d_PagoMedico = a.d_PagoMedico,
                                             MedicoPago = a.i_MedicoPago == 1 ? "SI" : a.d_PagoMedico == null ? "SIN LIQUIDAR" : a.d_PagoMedico == 0 ? "---" : "NO",
                                             d_PagoPaciente = a.d_PagoPaciente,
                                             PacientePago = a.i_PacientePago == 1 ? "SI" : a.d_PagoPaciente == null ? "SIN LIQUIDAR" : a.d_PagoPaciente == 0 ? "---" : "NO",
                                             v_MedicoTratante = a.v_MedicoTratante == "-1" ? " - - -" : a.v_MedicoTratante == null ? " - - - " : a.v_MedicoTratante == "SAN LORENZO, CLINICA" ? "CLINICA SAN LORENZO" : a.v_MedicoTratante,
                                             v_Servicio = a.v_Servicio
                                         }).ToList();

                var objtData = hospitalizaciones.AsEnumerable()
                    .Where(a => a.v_HopitalizacionId != null)
                    .GroupBy(b => b.v_HopitalizacionId)
                    .Select(group => group.First());

                List<HospitalizacionList> obj = objtData.ToList();

                HospitalizacionList hospit;
                List<HospitalizacionList> Lista = new List<HospitalizacionList>();


                var servicioMedico = obj.ToList().FindAll(p => p.v_Servicio == "EMERGENCIA").ToList();


                foreach (var item in servicioMedico)
                {
                    hospit = new HospitalizacionList();

                    hospit.v_HopitalizacionId = item.v_HopitalizacionId;
                    hospit.v_PersonId = item.v_PersonId;
                    hospit.v_Paciente = item.v_Paciente;
                    hospit.v_DocNumber = item.v_DocNumber;
                    hospit.i_Years = item.i_Years;
                    hospit.d_FechaIngreso = item.d_FechaIngreso;
                    hospit.d_FechaAlta = item.d_FechaAlta;
                    hospit.v_Comentario = item.v_Comentario;
                    hospit.v_NroLiquidacion = item.v_NroLiquidacion;
                    hospit.d_PagoMedico = item.d_PagoMedico;
                    hospit.MedicoPago = item.MedicoPago;
                    hospit.d_PagoPaciente = item.d_PagoPaciente;
                    hospit.PacientePago = item.PacientePago;
                    hospit.v_MedicoTratante = item.v_MedicoTratante;
                    hospit.v_Servicio = item.v_Servicio;

                    //// estos son los hijos de 1 hopitalización
                    //var servicios = BuscarServiciosHospitalizacion(item.v_HopitalizacionId).ToList();

                    //List<HospitalizacionServiceList> HospitalizacionServicios = new List<HospitalizacionServiceList>();
                    //if (servicios.Count > 0)
                    //{
                    //    HospitalizacionServiceList oHospitalizacionServiceList;
                    //    ComponentesHospitalizacion oComponentesHospitalizacion;
                    //    foreach (var servicio in servicios)
                    //    {
                    //        oHospitalizacionServiceList = new HospitalizacionServiceList();
                    //        // acá vas poblando la entidad hijo hospitalización
                    //        oHospitalizacionServiceList.v_HopitalizacionId = servicio.v_HopitalizacionId;
                    //        oHospitalizacionServiceList.v_ServiceId = servicio.v_ServiceId;
                    //        oHospitalizacionServiceList.v_HospitalizacionServiceId = servicio.v_HospitalizacionServiceId;
                    //        oHospitalizacionServiceList.v_NroHospitalizacion = servicio.v_NroHospitalizacion;
                    //        oHospitalizacionServiceList.d_ServiceDate = servicio.d_ServiceDate;
                    //        oHospitalizacionServiceList.v_ProtocolName = servicio.v_ProtocolName;
                    //        oHospitalizacionServiceList.v_ProtocolId = servicio.v_ProtocolId;
                    //        oHospitalizacionServiceList.v_DocNumber = servicio.v_DocNumber;
                    //        oHospitalizacionServiceList.d_FechaAlta = servicio.d_FechaAlta;
                    //        // acá estoy agregando a las lista
                    //        HospitalizacionServicios.Add(servicio);
                    //    }
                    //    hospit.Servicios = HospitalizacionServicios;
                    //}

                    //#region Habitaciones
                    //var habitacioenes = BuscarHospitalizacionHabitaciones(item.v_HopitalizacionId).ToList();
                    //List<HospitalizacionHabitacionList> ListaHabitaciones = new List<HospitalizacionHabitacionList>();
                    //HospitalizacionHabitacionList oHospitalizacionHabitacionList;
                    //foreach (var habitacion in habitacioenes)
                    //{
                    //    oHospitalizacionHabitacionList = new HospitalizacionHabitacionList();
                    //    oHospitalizacionHabitacionList.v_HospitalizacionHabitacionId = habitacion.v_HospitalizacionHabitacionId;
                    //    oHospitalizacionHabitacionList.v_HopitalizacionId = item.v_HopitalizacionId;
                    //    oHospitalizacionHabitacionList.i_HabitacionId = habitacion.i_HabitacionId;
                    //    oHospitalizacionHabitacionList.NroHabitacion = habitacion.NroHabitacion;
                    //    oHospitalizacionHabitacionList.d_StartDate = habitacion.d_StartDate;
                    //    oHospitalizacionHabitacionList.d_EndDate = habitacion.d_EndDate;
                    //    oHospitalizacionHabitacionList.d_FechaAlta = habitacion.d_FechaAlta;
                    //    if ((decimal)habitacion.d_Precio != null)
                    //    {
                    //        oHospitalizacionHabitacionList.d_Precio = decimal.Round((decimal)habitacion.d_Precio, 2);
                    //    }

                    //    if (habitacion.d_Precio != null)
                    //        oHospitalizacionHabitacionList.Total =
                    //            CalcularCostoHabitacion(habitacion.d_Precio.ToString(), habitacion.d_StartDate,
                    //                habitacion.d_EndDate);
                    //    else
                    //        oHospitalizacionHabitacionList.Total = 0;
                    //    ListaHabitaciones.Add(oHospitalizacionHabitacionList);

                    //}
                    //hospit.Habitaciones = ListaHabitaciones;
                    //#endregion

                    Lista.Add(hospit);
                }
                pobjOperationResult.Success = 1;
                return Lista;

            }
            catch (Exception ex)
            {
                pobjOperationResult.Success = 0;
                pobjOperationResult.ExceptionMessage = Common.Utils.ExceptionFormatter(ex);
                return null;
            }
        }

        public List<EmergenciapList> GetHospitalizacionPagedAndFilteredEmrg(ref OperationResult pobjOperationResult, DateTime? pdatBeginDate, DateTime? pdatEndDate)
        {
            try
            {
                SigesoftEntitiesModel dbContext = new SigesoftEntitiesModel();

                var query = (from a in dbContext.getemergencialist_sp(pdatBeginDate, pdatEndDate, "")
                             select new EmergenciapList
                             {
                                 TipoDeIngreso = a.TipoDeIngreso,
                                 HoraCita_ = a.HoraCita.ToString(),
                                 d_FechaIngreso_ = a.d_FechaIngreso.ToString(),
                                 d_FechaEgreso_ = a.d_FechaEgreso.ToString(),
                                 d_FechaEgreso = a.d_FechaEgreso,

                                 v_Paciente = a.v_Paciente,
                                 TipoDocumento = a.TipoDocumento,
                                 v_DocNumber = a.v_DocNumber,
                                 HistoriaClinica = a.HistoriaClinica,
                                 Edad = a.Edad,
                                 v_Cie10 = a.v_Cie10,
                                 v_Diagnostico = a.v_Diagnostico,
                                 v_MedicoTratante = a.v_MedicoTratante,
                                 Especialidad = a.Especialidad,
                                 Hospitalizado = a.Hospitalizado,
                                 Value2  = a.Value2,
                                 Monto = a.Monto,
                                 d_PagoMedico = a.d_PagoMedico,
                                 MedicoPago = a.MedicoPago,
                                 d_PagoPaciente = a.d_PagoPaciente,
                                 PacientePago = a.PacientePago,
                                 v_CIE10IdSalida = a.v_CIE10IdSalida,
                                 v_DiseasesNameSalida = a.v_DiseasesNameSalida,
                                 i_ProcedimientoSOP = a.i_ProcedimientoSOP,
                                 v_ProcedimientoSOP = a.v_ProcedimientoSOP,
                                 v_Servicio = a.v_Servicio,
                                 v_NroLiquidacion = a.v_NroLiquidacion,
                                 VendedorExterno = a.VendedorExterno,
                                 v_Comentariox = a.v_Comentariox,
                                 v_HopitalizacionId = a.v_HopitalizacionId,
                                 v_PersonId = a.v_PersonId,
                                 i_IsDeleted = a.i_IsDeleted,
                                 Consultorio = a.Consultorio,
                                 Value1 = a.Value1, //v_NroHospitalizacion


                             }).ToList();


                pobjOperationResult.Success = 1;
                return query;

            }
            catch (Exception ex)
            {
                pobjOperationResult.Success = 0;
                pobjOperationResult.ExceptionMessage = Common.Utils.ExceptionFormatter(ex);
                return null;
            }
        }

        

        public int GetAge(DateTime FechaNacimiento)
        {
            return int.Parse((DateTime.Today.AddTicks(-FechaNacimiento.Ticks).Year - 1).ToString());

        }
        public List<HospitalizacionList> GetHospitalizcion(ref OperationResult pobjOperationResult, string hospitalizacionId)
        {

            try
            {
                SigesoftEntitiesModel dbContext = new SigesoftEntitiesModel();

                var query = from A in dbContext.hospitalizacion
                            join person B in dbContext.person on A.v_PersonId equals B.v_PersonId

                            where A.i_IsDeleted == 0 && A.v_HopitalizacionId == hospitalizacionId 

                            select new HospitalizacionList
                            {
                                d_FechaAlta = A.d_FechaAlta,
                                d_FechaIngreso = A.d_FechaIngreso,
                                v_Paciente = B.v_FirstName + " " + B.v_FirstLastName + " " + B.v_SecondLastName,
                                v_HopitalizacionId = A.v_HopitalizacionId,
                                v_PersonId = A.v_PersonId,
                                i_IsDeleted = A.i_IsDeleted.Value,

                            };

                List<HospitalizacionList> objData = query.ToList();

                var hospitalizaciones = (from a in objData
                                         select new HospitalizacionList
                                         {
                                             v_Paciente = a.v_Paciente,
                                             d_FechaIngreso = a.d_FechaIngreso,
                                             d_FechaAlta = a.d_FechaAlta,
                                             v_HopitalizacionId = a.v_HopitalizacionId,
                                             v_PersonId = a.v_PersonId
                                         }).ToList();

                var objtData = hospitalizaciones.AsEnumerable()
                    .Where(a => a.v_HopitalizacionId != null)
                    .GroupBy(b => b.v_HopitalizacionId)
                    .Select(group => group.First());

                List<HospitalizacionList> obj = objtData.ToList();

                HospitalizacionList hospit;
                List<HospitalizacionList> Lista = new List<HospitalizacionList>();

                foreach (var item in obj)
                {
                    hospit = new HospitalizacionList();

                    hospit.v_HopitalizacionId = item.v_HopitalizacionId;
                    hospit.v_PersonId = item.v_PersonId;
                    hospit.v_Paciente = item.v_Paciente;
                    hospit.d_FechaIngreso = item.d_FechaIngreso;
                    hospit.d_FechaAlta = item.d_FechaAlta;

                    // estos son los hijos de 1 hopitalización
                    var servicios = BuscarServiciosHospitalizacion(item.v_HopitalizacionId).ToList();

                    List<HospitalizacionServiceList> HospitalizacionServicios = new List<HospitalizacionServiceList>();
                    if (servicios.Count > 0)
                    {
                        HospitalizacionServiceList oHospitalizacionServiceList;
                        foreach (var servicio in servicios)
                        {
                            oHospitalizacionServiceList = new HospitalizacionServiceList();
                            // acá vas poblando la entidad hijo hospitalización
                            oHospitalizacionServiceList.v_HopitalizacionId = servicio.v_HopitalizacionId;
                            oHospitalizacionServiceList.v_ServiceId = servicio.v_ServiceId;
                            oHospitalizacionServiceList.v_HospitalizacionServiceId = servicio.v_HospitalizacionServiceId;
                            oHospitalizacionServiceList.d_ServiceDate = servicio.d_ServiceDate;
                            oHospitalizacionServiceList.v_ProtocolName = servicio.v_ProtocolName;
                            oHospitalizacionServiceList.v_ProtocolId = servicio.v_ProtocolId;
                            // acá estoy agregando a las lista
                            HospitalizacionServicios.Add(servicio);
                        }
                        hospit.Servicios = HospitalizacionServicios;
                    }

                    #region Habitaciones
                    var habitacioenes = BuscarHospitalizacionHabitaciones(item.v_HopitalizacionId).ToList();
                    List<HospitalizacionHabitacionList> ListaHabitaciones = new List<HospitalizacionHabitacionList>();
                    HospitalizacionHabitacionList oHospitalizacionHabitacionList;
                    foreach (var habitacion in habitacioenes)
                    {
                        oHospitalizacionHabitacionList = new HospitalizacionHabitacionList();
                        oHospitalizacionHabitacionList.v_HospitalizacionHabitacionId = habitacion.v_HospitalizacionHabitacionId;
                        oHospitalizacionHabitacionList.v_HopitalizacionId = item.v_HopitalizacionId;
                        oHospitalizacionHabitacionList.i_HabitacionId = habitacion.i_HabitacionId;
                        oHospitalizacionHabitacionList.NroHabitacion = habitacion.NroHabitacion;
                        oHospitalizacionHabitacionList.d_StartDate = habitacion.d_StartDate;
                        oHospitalizacionHabitacionList.d_EndDate = habitacion.d_EndDate;
                        oHospitalizacionHabitacionList.d_Precio = habitacion.d_Precio;
                        oHospitalizacionHabitacionList.i_conCargoA = habitacion.i_conCargoA;
                        oHospitalizacionHabitacionList.d_FechaAlta = habitacion.d_FechaAlta;
                        if (habitacion.d_Precio != null)
                            oHospitalizacionHabitacionList.Total =
                                CalcularCostoHabitacion(habitacion.d_Precio.ToString(), habitacion.d_StartDate,
                                    habitacion.d_EndDate);
                        else
                            oHospitalizacionHabitacionList.Total = 0;
                        ListaHabitaciones.Add(oHospitalizacionHabitacionList);

                    }
                    hospit.Habitaciones = ListaHabitaciones;
                    #endregion

                    Lista.Add(hospit);
                }
                pobjOperationResult.Success = 1;
                return Lista;

            }
            catch (Exception ex)
            {
                pobjOperationResult.Success = 0;
                pobjOperationResult.ExceptionMessage = Common.Utils.ExceptionFormatter(ex);
                return null;
            }
        }

        private decimal CalcularCostoHabitacion(string precio , DateTime? fechaIni, DateTime? fechafin)
        {
            var precioHabitacion = decimal.Parse(precio);
            var cantidadDias = 0;
            if (fechafin != null)
            {
                if (fechaIni != null)
                {
                    TimeSpan ts = fechafin.Value.Date - fechaIni.Value.Date;
                    if (ts.Days == 0)
                    {
                        cantidadDias = ts.Days + 1;
                    }
                    else
                    {
                        cantidadDias = ts.Days;
                    }
                }
            }
            else
            {
                if (fechaIni != null)
                {
                    DateTime oldDate = fechaIni.Value.Date;
                    DateTime newDate = DateTime.Now.Date;

                    // Difference in days, hours, and minutes.
                    TimeSpan ts = newDate - oldDate;

                    // Difference in days.
                    if (ts.Days == 0)
                    {
                        cantidadDias = ts.Days + 1;
                    }
                    else
                    {
                        cantidadDias = ts.Days;
                    }
                }
                    //cantidadDias = int.Parse((DateTime.Today.AddTicks(-fechaIni.Value.Ticks).Day + 1).ToString());
            }

            return decimal.Round((decimal)precioHabitacion * (cantidadDias),2);
        }

        private List<HospitalizacionHabitacionList> BuscarHospitalizacionHabitaciones_old(string hospitalizacionId)
        {
            try
            {
                SigesoftEntitiesModel dbContext = new SigesoftEntitiesModel();
                var habitaciones = (from A in dbContext.hospitalizacionhabitacion
                    join B in dbContext.hospitalizacion on A.v_HopitalizacionId equals B.v_HopitalizacionId
                    join D in dbContext.systemparameter on new { a = A.i_HabitacionId.Value, b = 309 } equals new { a = D.i_ParameterId, b = D.i_GroupId }
                    where A.v_HopitalizacionId == hospitalizacionId && A.i_IsDeleted == 0
                    select new HospitalizacionHabitacionList
                    {
                        v_HospitalizacionHabitacionId = A.v_HospitalizacionHabitacionId,
                        v_HopitalizacionId = A.v_HopitalizacionId,
                        i_HabitacionId = A.i_HabitacionId.Value,
                        NroHabitacion = D.v_Value1,
                        d_StartDate = A.d_StartDate,
                        d_EndDate = A.d_EndDate,
                        i_conCargoA = A.i_ConCargoA,
                        d_Precio = A.d_Precio.Value,
                        d_FechaAlta = B.d_FechaAlta
                    }).ToList();
                List<HospitalizacionHabitacionList> obj = habitaciones;

                return obj;
            }
            catch (Exception ex)
            {
                return null;
            }
            
        }

        public List<HospitalizacionHabitacionList> BuscarHospitalizacionHabitaciones(string hospitalizacionId)
        {
            try
            {
                SigesoftEntitiesModel dbContext = new SigesoftEntitiesModel();
                var habitaciones = (from A in dbContext.buscarhospitalizacionhabitaciones(hospitalizacionId)
                                    select new HospitalizacionHabitacionList
                                    {
                                        v_HospitalizacionHabitacionId = A.v_HospitalizacionHabitacionId,
                                        v_HopitalizacionId = A.v_HopitalizacionId,
                                        i_HabitacionId = A.i_HabitacionId.Value,
                                        NroHabitacion = A.NroHabitacion,
                                        d_StartDate = A.d_StartDate,
                                        d_EndDate = A.d_EndDate,
                                        i_conCargoA = A.i_conCargoA.Value,
                                        d_Precio = A.d_Precio.Value,
                                        i_isdelete = A.i_isdelete,
                                        d_FechaAlta = A.d_FechaAlta,
                                        Total = A.d_Precio == null ? 0 : CalcularCostoHabitacion(A.d_Precio.ToString(), A.d_StartDate, A.d_EndDate)

                                    }).ToList();

                return habitaciones;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        private List<HospitalizacionServiceList> BuscarServiciosHospitalizacion(string hospitalizacionId)
        {
            try
            {
                //acá hace un select a la tabla hospitalizacionService y buscas todos que tengan foranea HospitalizacionId
            SigesoftEntitiesModel dbContext = new SigesoftEntitiesModel();
            var queryservice = from A in dbContext.hospitalizacion
                        join C in dbContext.hospitalizacionservice on A.v_HopitalizacionId equals C.v_HopitalizacionId
                        join D in dbContext.service on C.v_ServiceId equals D.v_ServiceId
                        join E in dbContext.protocol on D.v_ProtocolId equals E.v_ProtocolId
                        join F in dbContext.person on D.v_PersonId equals F.v_PersonId
                        where A.v_HopitalizacionId == hospitalizacionId && A.i_IsDeleted == 0

                        select new HospitalizacionServiceList
                        {
                           v_HospitalizacionServiceId = C.v_HospitalizacionServiceId,
                           v_HopitalizacionId = C.v_HopitalizacionId,
                           v_ServiceId = C.v_ServiceId,
                           d_ServiceDate = D.d_ServiceDate.Value,
                           v_ProtocolName = E.v_Name,
                           v_ProtocolId = E.v_ProtocolId,
                           v_DocNumber = F.v_DocNumber,
                           d_FechaAlta = A.d_FechaAlta
                           
                        };
            List<HospitalizacionServiceList> objData = queryservice.ToList();
            var hospitalizacionesservicios = (from a in objData
                                              select new HospitalizacionServiceList
                                     {
                                        v_HospitalizacionServiceId = a.v_HospitalizacionServiceId,
                                        v_HopitalizacionId = a.v_HopitalizacionId,
                                        v_ServiceId = a.v_ServiceId,
                                        d_ServiceDate = a.d_ServiceDate,
                                        v_ProtocolName = a.v_ProtocolName,
                                        v_ProtocolId = a.v_ProtocolId,
                                        v_DocNumber = a.v_DocNumber,
                                        d_FechaAlta = a.d_FechaAlta
                                     }).ToList();

            List<HospitalizacionServiceList> obj = hospitalizacionesservicios;


            HospitalizacionServiceList tickets;
            List<HospitalizacionServiceList> Lista = new List<HospitalizacionServiceList>();

            foreach (var item in obj)
            {
                tickets = new HospitalizacionServiceList();

                tickets.v_HospitalizacionServiceId = item.v_HospitalizacionServiceId;
                tickets.v_HopitalizacionId = item.v_HopitalizacionId;
                tickets.v_ServiceId = item.v_ServiceId;
                tickets.d_ServiceDate = item.d_ServiceDate;
                tickets.v_ProtocolName = item.v_ProtocolName;
                tickets.v_ProtocolId = item.v_ProtocolId;
                tickets.v_DocNumber = item.v_DocNumber;
                tickets.d_FechaAlta = item.d_FechaAlta;
                #region Tickets

                // estos son los hijos de 1 hopitalización
                var ticketss = BuscarTickets(item.v_ServiceId).ToList();

                List<TicketList> Tickets = new List<TicketList>();
                if (ticketss.Count > 0)
                {
                    TicketList ticketslist;
                    foreach (var tick in ticketss)
                    {
                        ticketslist = new TicketList();
                        // acá vas poblando la entidad hijo hospitalización
                        ticketslist.v_TicketId = tick.v_TicketId;
                        ticketslist.v_ServiceId = tick.v_ServiceId;
                        ticketslist.d_Fecha = tick.d_Fecha;
                        ticketslist.i_conCargoA = tick.i_conCargoA;
                        ticketslist.i_tipoCuenta = tick.i_tipoCuenta;
                        ticketslist.i_TicketInterno = tick.i_TicketInterno;
                        ticketslist.TicketInterno = tick.i_TicketInterno == 1 ? "SI" : "NO";
                        ticketslist.Productos = tick.Productos;
                        ticketslist.d_FechaAlta = tick.d_FechaAlta;
                        // acá estoy agregando a las lista
                        Tickets.Add(ticketslist);
                    }
                    tickets.Tickets = Tickets;
                }

                #endregion

                #region Componentes

                OperationResult pobjOperationResult = new OperationResult();
                ServiceBL oServiceBL = new ServiceBL();
                var componentes = oServiceBL.GetServiceComponents_(ref pobjOperationResult, item.v_ServiceId).FindAll(p => p.r_Price != 0);
                ComponentesHospitalizacion oComponentesHospitalizacion;

                List<ComponentesHospitalizacion> listaComponentes = new List<ComponentesHospitalizacion>();
                foreach (var componente in componentes)
                {
                    oComponentesHospitalizacion = new ComponentesHospitalizacion();
                    oComponentesHospitalizacion.v_ServiceId = componente.v_ServiceId;
                    oComponentesHospitalizacion.ServiceComponentId = componente.v_ServiceComponentId;
                    oComponentesHospitalizacion.Categoria = componente.v_CategoryName;
                    oComponentesHospitalizacion.Componente = componente.v_ComponentName;
                    oComponentesHospitalizacion.Precio = decimal.Round((decimal)componente.r_Price, 2);
                    oComponentesHospitalizacion.MedicoTratante = componente.MedicoTratante;
                    oComponentesHospitalizacion.Ingreso = componente.d_InsertDate.Value;
                    oComponentesHospitalizacion.i_conCargoA = componente.i_ConCargoA;
                    oComponentesHospitalizacion.d_FechaAlta = componente.d_FechaAlta;
                    oComponentesHospitalizacion.GrupoAtencion = componente.GrupoAtencion == null ? "CLINICA" : componente.GrupoAtencion;
                    listaComponentes.Add(oComponentesHospitalizacion);
                }
                tickets.Componentes = listaComponentes;

                #endregion

                Lista.Add(tickets);

         

            }

            return Lista;
            }
            catch (Exception ex)
            {
                return null;
            }
            
        }

        public List<TicketList> BuscarTickets_old(string v_ServiceId)
        {
            //acá hace un select a la tabla hospitalizacionService y buscas todos que tengan foranea HospitalizacionId
            SigesoftEntitiesModel dbContext = new SigesoftEntitiesModel();
            var queryticket = from A in dbContext.hospitalizacion
                               join C in dbContext.hospitalizacionservice on A.v_HopitalizacionId equals C.v_HopitalizacionId
                               join D in dbContext.service on C.v_ServiceId equals D.v_ServiceId
                               join E in dbContext.ticket on D.v_ServiceId equals E.v_ServiceId

                               where E.v_ServiceId == v_ServiceId && E.i_IsDeleted == 0

                               select new TicketList
                               {
                                   v_ServiceId = E.v_ServiceId,
                                   v_TicketId = E.v_TicketId,
                                   d_Fecha = E.d_Fecha,
                                   i_conCargoA = E.i_ConCargoA,
                                   i_tipoCuenta = E.i_TipoCuentaId,
                                  i_TicketInterno = E.i_TicketInterno,
                                   d_FechaAlta = A.d_FechaAlta
                               };
            List<TicketList> objData = queryticket.ToList();
            // en hospitalizaciones tienes los padres
            var ticket = (from a in objData
                                              select new TicketList
                                              {
                                                  v_TicketId=a.v_TicketId,
                                                  v_ServiceId = a.v_ServiceId,
                                                  d_Fecha = a.d_Fecha,
                                                  i_conCargoA = a.i_conCargoA,
                                                  i_tipoCuenta = a.i_tipoCuenta,
                                                  i_TicketInterno = a.i_TicketInterno,
                                                  d_FechaAlta = a.d_FechaAlta
                                              }).ToList();

            var objtData = ticket.AsEnumerable()
                    .Where(a => a.v_TicketId != null)
                    .GroupBy(b => b.v_TicketId)
                    .Select(group => group.First());

            List<TicketList> obj = objtData.ToList();

            TicketList tickets;
            List<TicketList> Lista = new List<TicketList>();

            foreach (var item in obj)
            {
                tickets = new TicketList();

                tickets.v_TicketId = item.v_TicketId;
                tickets.v_ServiceId = item.v_ServiceId;
                tickets.d_Fecha = item.d_Fecha;
                tickets.i_conCargoA = item.i_conCargoA;
                tickets.i_tipoCuenta = item.i_tipoCuenta;
                tickets.i_TicketInterno = item.i_TicketInterno;
                tickets.d_FechaAlta = item.d_FechaAlta;
                // estos son los hijos de 1 hopitalización
                var ticketssdetalle = BuscarTicketsDetalle(item.v_TicketId).ToList();

                List<TicketDetalleList> Ticketsdetalle = new List<TicketDetalleList>();
                if (ticketssdetalle.Count > 0)
                {
                    TicketDetalleList ticketsdetallelist;
                    foreach (var tickdetalle in ticketssdetalle)
                    {
                        ticketsdetallelist = new TicketDetalleList();
                        // acá vas poblando la entidad hijo hospitalización
                        ticketsdetallelist.v_TicketId = tickdetalle.v_TicketId;
                        ticketsdetallelist.v_TicketDetalleId = tickdetalle.v_TicketDetalleId;
                        ticketsdetallelist.v_IdProductoDetalle = tickdetalle.v_IdProductoDetalle;
                        ticketsdetallelist.v_Descripcion = tickdetalle.v_Descripcion;
                        ticketsdetallelist.EsDespachado = tickdetalle.EsDespachado;
                        ticketsdetallelist.d_Cantidad = decimal.Round(tickdetalle.d_Cantidad,0);
                        ticketsdetallelist.d_PrecioVenta = decimal.Round(tickdetalle.d_PrecioVenta,2);
                        ticketsdetallelist.Total = decimal.Round(tickdetalle.d_Cantidad * tickdetalle.d_PrecioVenta,2);
                        // acá estoy agregando a las lista
                        Ticketsdetalle.Add(ticketsdetallelist);
                    }
                    tickets.Productos = Ticketsdetalle;
                }
                Lista.Add(tickets);
            }
           
            return Lista;
        }

        public List<TicketList> BuscarTickets(string v_ServiceId)
        {
            //acá hace un select a la tabla hospitalizacionService y buscas todos que tengan foranea HospitalizacionId
            SigesoftEntitiesModel dbContext = new SigesoftEntitiesModel();
            var queryticket = (from A in dbContext.buscartickets_1(v_ServiceId)
                               select new TicketList
                               {
                                   v_ServiceId = A.v_ServiceId,
                                   v_TicketId = A.v_TicketId,
                                   d_Fecha = A.d_Fecha,
                                   i_conCargoA = A.i_conCargoA,
                                   i_tipoCuenta = A.i_tipoCuenta,
                                   i_TicketInterno = A.i_TicketInterno,
                                   d_FechaAlta = A.d_FechaAlta
                               }).ToList();

            TicketList tickets;
            List<TicketList> Lista = new List<TicketList>();

            foreach (var item in queryticket)
            {
                tickets = new TicketList();

                tickets.v_TicketId = item.v_TicketId;
                tickets.v_ServiceId = item.v_ServiceId;
                tickets.d_Fecha = item.d_Fecha;
                tickets.i_conCargoA = item.i_conCargoA;
                tickets.i_tipoCuenta = item.i_tipoCuenta;
                tickets.i_TicketInterno = item.i_TicketInterno;
                tickets.d_FechaAlta = item.d_FechaAlta;
                // estos son los hijos de 1 hopitalización
                var ticketssdetalle = BuscarTicketsDetalle(item.v_TicketId).ToList();

                List<TicketDetalleList> Ticketsdetalle = new List<TicketDetalleList>();
                if (ticketssdetalle.Count > 0)
                {
                    TicketDetalleList ticketsdetallelist;
                    foreach (var tickdetalle in ticketssdetalle)
                    {
                        ticketsdetallelist = new TicketDetalleList();
                        // acá vas poblando la entidad hijo hospitalización
                        ticketsdetallelist.v_TicketId = tickdetalle.v_TicketId;
                        ticketsdetallelist.v_TicketDetalleId = tickdetalle.v_TicketDetalleId;
                        ticketsdetallelist.v_IdProductoDetalle = tickdetalle.v_IdProductoDetalle;
                        ticketsdetallelist.v_Descripcion = tickdetalle.v_Descripcion;
                        ticketsdetallelist.EsDespachado = tickdetalle.EsDespachado;
                        ticketsdetallelist.d_Cantidad = decimal.Round(tickdetalle.d_Cantidad, 0);
                        ticketsdetallelist.d_PrecioVenta = decimal.Round(tickdetalle.d_PrecioVenta, 2);
                        ticketsdetallelist.Total = decimal.Round(tickdetalle.d_Cantidad * tickdetalle.d_PrecioVenta, 2);
                        // acá estoy agregando a las lista
                        Ticketsdetalle.Add(ticketsdetallelist);
                    }
                    tickets.Productos = Ticketsdetalle;
                }
                Lista.Add(tickets);
            }

            return Lista;
        }


        public void AddHospitalizacion(ref OperationResult pobjOperationResult, hospitalizacionDto pobjDtoEntity, List<string> ClientSession)
        {
            //mon.IsActive = true;
            string NewId = "(No generado)";
            try
            {
                SigesoftEntitiesModel dbContext = new SigesoftEntitiesModel();
                hospitalizacion objEntity = hospitalizacionAssembler.ToEntity(pobjDtoEntity);

                objEntity.d_InsertDate = DateTime.Now;
                objEntity.i_InsertUserId = Int32.Parse(ClientSession[2]);
                objEntity.i_IsDeleted = 0;

                // Autogeneramos el Pk de la tabla                 
                int intNodeId = int.Parse(ClientSession[0]);
                NewId = Common.Utils.GetNewId(intNodeId, Utils.GetNextSecuentialId(intNodeId, 350), "HP"); ;
                objEntity.v_HopitalizacionId = NewId;

                dbContext.AddTohospitalizacion(objEntity);
                dbContext.SaveChanges();

                pobjOperationResult.Success = 1;
            }
            catch (Exception ex)
            {
                pobjOperationResult.Success = 0;
                pobjOperationResult.ExceptionMessage = Common.Utils.ExceptionFormatter(ex);
            }
        }


        public void AddHospitalizacionService(ref OperationResult pobjOperationResult, hospitalizacionserviceDto pobjDtoEntity, List<string> ClientSession)
        {
            //mon.IsActive = true;
            string NewId = "(No generado)";
            try
            {
                SigesoftEntitiesModel dbContext = new SigesoftEntitiesModel();
                hospitalizacionservice objEntity = hospitalizacionserviceAssembler.ToEntity(pobjDtoEntity);

                objEntity.d_InsertDate = DateTime.Now;
                objEntity.i_InsertUserId = Int32.Parse(ClientSession[2]);
                objEntity.i_IsDeleted = 0;

                // Autogeneramos el Pk de la tabla                 
                int intNodeId = int.Parse(ClientSession[0]);
                NewId = Common.Utils.GetNewId(intNodeId, Utils.GetNextSecuentialId(intNodeId, 351), "HS"); ;
                objEntity.v_HospitalizacionServiceId = NewId;

                dbContext.AddTohospitalizacionservice(objEntity);
                dbContext.SaveChanges();

                pobjOperationResult.Success = 1;
            }
            
            catch (Exception ex)
            {
                pobjOperationResult.Success = 0;
                pobjOperationResult.ExceptionMessage = Common.Utils.ExceptionFormatter(ex);
            }
        }


        public void UpdateHospitalizacion(ref OperationResult pobjOperationResult, hospitalizacionDto pobjDtoEntity, List<string> ClientSession)
        {
            //mon.IsActive = true;
            try
            {
                SigesoftEntitiesModel dbContext = new SigesoftEntitiesModel();

                // Obtener la entidad fuente
                var objEntitySource = (from a in dbContext.hospitalizacion
                                       where a.v_HopitalizacionId == pobjDtoEntity.v_HopitalizacionId
                                       select a).FirstOrDefault();

                // Crear la entidad con los datos actualizados
                pobjDtoEntity.d_UpdateDate = DateTime.Now;
                pobjDtoEntity.i_IsDeleted = 0;
                pobjDtoEntity.i_UpdateUserId = Int32.Parse(ClientSession[2]);

                hospitalizacion objEntity = hospitalizacionAssembler.ToEntity(pobjDtoEntity);

                // Copiar los valores desde la entidad actualizada a la Entidad Fuente
                dbContext.hospitalizacion.ApplyCurrentValues(objEntity);

                // Guardar los cambios
                dbContext.SaveChanges();

                pobjOperationResult.Success = 1;
            }
            catch (Exception ex)
            {
                pobjOperationResult.Success = 0;
                pobjOperationResult.ExceptionMessage = Common.Utils.ExceptionFormatter(ex);
            }
        }

        public hospitalizacionDto GetHospitalizacion(ref OperationResult pobjOperationResult, string v_HopitalizacionId)
        {
            //mon.IsActive = true;
            try
            {
                SigesoftEntitiesModel dbContext = new SigesoftEntitiesModel();
                hospitalizacionDto objDtoEntity = null;

                var objEntity = (from a in dbContext.hospitalizacion
                                 where a.v_HopitalizacionId == v_HopitalizacionId
                                 select a).FirstOrDefault();

                if (objEntity != null)
                    objDtoEntity = hospitalizacionAssembler.ToDTO(objEntity);

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


        public List<TicketDetalleList> BuscarTicketsDetalle_OLD(string v_TicketId)
        {
            SigesoftEntitiesModel dbContext = new SigesoftEntitiesModel();
            var queryticketdetalle = from A in dbContext.hospitalizacion
                                     join C in dbContext.hospitalizacionservice on A.v_HopitalizacionId equals C.v_HopitalizacionId
                                     join D in dbContext.service on C.v_ServiceId equals D.v_ServiceId
                                     join E in dbContext.ticket on D.v_ServiceId equals E.v_ServiceId
                                     join F in dbContext.ticketdetalle on E.v_TicketId equals F.v_TicketId
                                     join G in dbContext.systemuser on E.i_InsertUserId equals  G.i_SystemUserId
                                     join H in dbContext.person on G.v_PersonId equals H.v_PersonId
                                     //join G in dbContext.productsformigration on F.v_IdProductoDetalle equals G.v_ProductId
                                     where E.v_TicketId == v_TicketId && F.i_IsDeleted == 0 && E.i_IsDeleted == 0
                                     && A.i_IsDeleted == 0 && C.i_IsDeleted == 0 && D.i_IsDeleted == 0
                                     //E.v_TicketId == v_TicketId &&
                              select new TicketDetalleList
                              {
                                  v_TicketDetalleId = F.v_TicketDetalleId,
                                  v_TicketId = F.v_TicketId,
                                  d_Cantidad = F.d_Cantidad.Value,
                                  v_Descripcion = F.v_Descripcion,
                                  v_IdProductoDetalle = F.v_IdProductoDetalle,
                                  i_EsDespachado = F.i_EsDespachado.Value,
                                  d_PrecioVenta = F.d_PrecioVenta.Value,
                                  UsuarioCrea = H.v_FirstLastName + " " + H.v_SecondLastName + ", " + H.v_FirstName
                              };
            List<TicketDetalleList> objData = queryticketdetalle.ToList();
            var ticketdetalle = (from a in objData
                                 select new TicketDetalleList
                          {
                              v_TicketId = a.v_TicketId,
                              v_IdProductoDetalle = a.v_IdProductoDetalle,
                              v_TicketDetalleId = a.v_TicketDetalleId,
                              d_Cantidad = a.d_Cantidad,
                              v_Descripcion = a.v_Descripcion,
                              i_EsDespachado = a.i_EsDespachado,
                              EsDespachado = a.i_EsDespachado == 0 ? "NO" : "SI",
                              d_PrecioVenta = a.d_PrecioVenta,
                              UsuarioCrea = a.UsuarioCrea
                          }).ToList();

            return ticketdetalle;
        }

        public List<TicketDetalleList> BuscarTicketsDetalle(string v_TicketId)
        {
            SigesoftEntitiesModel dbContext = new SigesoftEntitiesModel();
            var ticketdetalle = (from A in dbContext.buscarticketsdetalle_1(v_TicketId)
                                 select new TicketDetalleList
                                 {
                                     v_TicketDetalleId = A.v_TicketDetalleId,
                                     v_TicketId = A.v_TicketId,
                                     d_Cantidad = A.d_Cantidad.Value,
                                     v_Descripcion = A.v_Descripcion,
                                     v_IdProductoDetalle = A.v_IdProductoDetalle,
                                     i_EsDespachado = A.i_EsDespachado.Value,
                                     d_PrecioVenta = A.d_PrecioVenta.Value,
                                     UsuarioCrea = A.UsuarioCrea,
                                     EsDespachado = A.i_EsDespachado == 0 ? "NO" : "SI",
                                 }).ToList();
            return ticketdetalle;
        }

        public List<MedicoList> GetMedicosGrid(string pstrFilterExpression)
        {
            try
            {
                SigesoftEntitiesModel dbContext = new SigesoftEntitiesModel();

                var query = from A in dbContext.medico
                            join B in dbContext.systemuser on A.i_SystemUserId equals B.i_SystemUserId
                            join C in dbContext.person on B.v_PersonId equals C.v_PersonId
                             //join D in dbContext.systemparameter on new { a = A.i_GrupoId.Value, b = 119 } equals new { a = D.i_ParameterId, b = D.i_GroupId } into D_join
                             //from D in D_join.DefaultIfEmpty()
                            where A.i_IsDeleted == 0
                            select new MedicoList
                            {
                                v_MedicoId = A.v_MedicoId,
                                Medico = C.v_FirstName + " " + C.v_FirstLastName + " " + C.v_SecondLastName,
                                i_SystemUserId = B.i_SystemUserId,
                                //i_GrupoId = A.i_GrupoId.Value,
                                //Grupo = D.v_Value1,
                                r_Clinica = A.r_Clinica.Value,
                                r_Medico = A.r_Medico.Value,
                                Usuario = B.v_UserName,
                                Observaciones =  A.v_ComentaryUpdate,
                                Tipo = A.i_TipoComisionAfecta == 1 ? "M. Tratante" : A.i_TipoComisionAfecta == 2 ? "M. Solicitante" : "SIN CONFIGURAR"
                            };

                if (!string.IsNullOrEmpty(pstrFilterExpression))
                {
                    query = query.Where(pstrFilterExpression);
                }

                return query.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<MedicoConfList> GetMedicosConfiguracionPago(string pstrFilterExpression)
        {
            try
            {
                SigesoftEntitiesModel dbContext = new SigesoftEntitiesModel();

                var query = from  A in dbContext.configuracionpago
                            join B in dbContext.systemuser on A.i_SystemUserId equals B.i_SystemUserId
                            join C in dbContext.person on B.v_PersonId equals C.v_PersonId

                            join F in dbContext.systemuser on A.i_InsertUserId equals F.i_SystemUserId into F_join
                            from F in F_join.DefaultIfEmpty()

                            //join G in dbContext.person on F.v_PersonId equals G.v_PersonId

                            join H in dbContext.systemuser on A.i_UpdateUserId equals H.i_SystemUserId into H_join
                            from H in H_join.DefaultIfEmpty()

                            //join I in dbContext.person on F.v_PersonId equals I.v_PersonId


                            where A.i_IsDeleted == 0
                            select new MedicoConfList
                            {
                                v_IdConfPago = A.v_IdConfPago,
                                Usuario = B.v_UserName,
                                Medico = C.v_FirstName + " " + C.v_FirstLastName + " " + C.v_SecondLastName,
                                i_SystemUserId = B.i_SystemUserId,
                                i_TipoPago = A.i_TipoPago.Value,
                                v_TipoPago = A.i_TipoPago == 1 ? "X. TURNO" : A.i_TipoPago == 2 ? "X. HORA " : "X. EXAMEN",
                                d_MontoxTurno = A.d_MontoxTurno.Value,
                                d_MonoxHora = A.d_MonoxHora.Value,
                                i_OrdenExam = A.i_OrdenExam.Value,
                                v_OrdenExam = A.i_OrdenExam == 1 ? "M. Tratante" : A.i_OrdenExam == 2 ? "M. Solicitante" : "",
                                d_PorcClinicaExam = A.d_PorcClinicaExam.Value,
                                d_PorcMedicoExam = A.d_PorcMedicoExam.Value,
                                i_DescontarBoletaExam = A.i_DescontarBoletaExam.Value,
                                v_DescontarBoletaExam = A.i_DescontarBoletaExam == 1 ? "X" : "",
                                i_DescontarFactExam = A.i_DescontarFactExam.Value,
                                v_DescontarFactExam = A.i_DescontarFactExam == 1 ? "X" : "",
                                i_DescontarRecbExam = A.i_DescontarRecbExam.Value,
                                v_DescontarRecbExam = A.i_DescontarRecbExam == 1 ? "X" : "",
                                Observaciones = A.v_Observaciones,
                                v_ObservacionesCambios = A.v_ObservacionesCambios,
                                i_IsDeleted = A.i_IsDeleted,
                                i_InsertUserId = A.i_InsertUserId,
                                v_InsertUserId = F.v_UserName,
                                d_InsertDate = A.d_InsertDate.Value,
                                i_UpdateUserId = A.i_UpdateUserId,
                                v_UpdateUserId = H.v_UserName,
                                d_UpdateDate = A.d_UpdateDate.Value,
                                i_TipoDescuentoHoraMin = A.i_TipoDescuentoHoraMin.Value,
                                v_TipoDescuentoHoraMin = A.i_TipoDescuentoHoraMin == 1 ? "HORAS" : A.i_TipoDescuentoHoraMin == 2 ? "MINUTOS" : "",
                                i_DesucuentodeHorario = A.i_DesucuentodeHorario.Value,

                            };

                if (!string.IsNullOrEmpty(pstrFilterExpression))
                {
                    query = query.Where(pstrFilterExpression);
                }

                return query.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<MedicoConfExamenList> GetMedicosConfiguracionExamenesPago(string v_IdConfPago)
        {
            try
            {
                SigesoftEntitiesModel dbContext = new SigesoftEntitiesModel();

                var query = from A in dbContext.configuracionexamenpago
                            join B in dbContext.component on A.v_ComponentId equals B.v_ComponentId

                            join F in dbContext.systemuser on A.i_InsertUserId equals F.i_SystemUserId into F_join
                            from F in F_join.DefaultIfEmpty()

                            join H in dbContext.systemuser on A.i_UpdateUserId equals H.i_SystemUserId into H_join
                            from H in H_join.DefaultIfEmpty()


                            where A.i_IsDeleted == 0 && A.v_IdConfPago == v_IdConfPago
                            select new MedicoConfExamenList
                            {
                                v_idPagoExam = A.v_idPagoExam,
                                v_IdConfPago = A.v_IdConfPago,
                                v_ComponentId = A.v_ComponentId,
                                Examen = B.v_Name,
                                
                                v_Observaciones = A.v_Observaciones,
                                v_ObservacionesCambios = A.v_ObservacionesCambios,
                                i_IsDeleted = A.i_IsDeleted,
                                i_InsertUserId = A.i_InsertUserId,
                                v_InsertUserId = F.v_UserName,
                                d_InsertDate = A.d_InsertDate.Value,
                                i_UpdateUserId = A.i_UpdateUserId,
                                v_UpdateUserId = H.v_UserName,
                                d_UpdateDate = A.d_UpdateDate.Value
                            };

                return query.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public medicoDto GetMedico(ref OperationResult pobjOperationResult, string v_MedicoId)
        {
            //mon.IsActive = true;
            try
            {
                SigesoftEntitiesModel dbContext = new SigesoftEntitiesModel();
                medicoDto objDtoEntity = null;

                var objEntity = (from a in dbContext.medico
                                 where a.v_MedicoId == v_MedicoId
                                 select a).FirstOrDefault();

                if (objEntity != null)
                    objDtoEntity = medicoAssembler.ToDTO(objEntity);

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

        public void AddMedico(ref OperationResult pobjOperationResult, medicoDto pobjDtoEntity, List<string> ClientSession)
        {
            //mon.IsActive = true;
            string NewId = "(No generado)";
            try
            {
                SigesoftEntitiesModel dbContext = new SigesoftEntitiesModel();
                medico objEntity = medicoAssembler.ToEntity(pobjDtoEntity);

                objEntity.d_InsertDate = DateTime.Now;
                objEntity.i_InsertUserId = Int32.Parse(ClientSession[2]);
                objEntity.i_IsDeleted = 0;

                // Autogeneramos el Pk de la tabla                 
                int intNodeId = int.Parse(ClientSession[0]);
                NewId = Common.Utils.GetNewId(intNodeId, Utils.GetNextSecuentialId(intNodeId, 341), "MD"); ;
                objEntity.v_MedicoId = NewId;

                dbContext.AddTomedico(objEntity);
                dbContext.SaveChanges();

                pobjOperationResult.Success = 1;
                // Llenar entidad Log
                LogBL.SaveLog(ClientSession[0], ClientSession[1], ClientSession[2], LogEventType.CREACION, "MEDICO", "v_MedicoId=" + NewId.ToString(), Success.Ok, null);
                return;
            }
            catch (Exception ex)
            {
                pobjOperationResult.Success = 0;
                pobjOperationResult.ExceptionMessage = Common.Utils.ExceptionFormatter(ex);
                // Llenar entidad Log
                LogBL.SaveLog(ClientSession[0], ClientSession[1], ClientSession[2], LogEventType.CREACION, "MEDICO", "v_MedicoId=" + NewId.ToString(), Success.Failed, pobjOperationResult.ExceptionMessage);
                return;
            }
        }

        public void UpdateMedico(ref OperationResult pobjOperationResult, medicoDto pobjDtoEntity, List<string> ClientSession)
        {
            //mon.IsActive = true;
            try
            {
                SigesoftEntitiesModel dbContext = new SigesoftEntitiesModel();

                // Obtener la entidad fuente
                var objEntitySource = (from a in dbContext.medico
                                       where a.v_MedicoId == pobjDtoEntity.v_MedicoId
                                       select a).FirstOrDefault();

                // Crear la entidad con los datos actualizados
                pobjDtoEntity.d_UpdateDate = DateTime.Now;
                pobjDtoEntity.i_IsDeleted = 0;
                pobjDtoEntity.i_UpdateUserId = Int32.Parse(ClientSession[2]);

                medico objEntity = medicoAssembler.ToEntity(pobjDtoEntity);

                // Copiar los valores desde la entidad actualizada a la Entidad Fuente
                dbContext.medico.ApplyCurrentValues(objEntity);

                // Guardar los cambios
                dbContext.SaveChanges();

                pobjOperationResult.Success = 1;
                // Llenar entidad Log
                LogBL.SaveLog(ClientSession[0], ClientSession[1], ClientSession[2], LogEventType.ACTUALIZACION, "MEDICO", "v_MedicoId=" + objEntity.v_MedicoId.ToString(), Success.Ok, null);
                return;
            }
            catch (Exception ex)
            {
                pobjOperationResult.Success = 0;
                pobjOperationResult.ExceptionMessage = Common.Utils.ExceptionFormatter(ex);
                // Llenar entidad Log
                LogBL.SaveLog(ClientSession[0], ClientSession[1], ClientSession[2], LogEventType.ACTUALIZACION, "MEDICO", "v_MedicoId=" + pobjDtoEntity.v_MedicoId.ToString(), Success.Failed, pobjOperationResult.ExceptionMessage);
                return;
            }
        }

        public void DeleteMedico(ref OperationResult pobjOperationResult, string v_MedicoId, List<string> ClientSession)
        {
            //mon.IsActive = true;

            try
            {
                SigesoftEntitiesModel dbContext = new SigesoftEntitiesModel();

                // Obtener la entidad fuente
                var objEntitySource = (from a in dbContext.medico
                                       where a.v_MedicoId == v_MedicoId
                                       select a).FirstOrDefault();

                // Crear la entidad con los datos actualizados
                objEntitySource.d_UpdateDate = DateTime.Now;
                objEntitySource.i_UpdateUserId = Int32.Parse(ClientSession[2]);
                objEntitySource.i_IsDeleted = 1;

                // Guardar los cambios
                dbContext.SaveChanges();

                pobjOperationResult.Success = 1;
                // Llenar entidad Log
                LogBL.SaveLog(ClientSession[0], ClientSession[1], ClientSession[2], LogEventType.ELIMINACION, "MEDICO", "", Success.Ok, null);
                return;
            }
            catch (Exception ex)
            {
                pobjOperationResult.Success = 0;
                pobjOperationResult.ExceptionMessage = Common.Utils.ExceptionFormatter(ex);
                // Llenar entidad Log
                LogBL.SaveLog(ClientSession[0], ClientSession[1], ClientSession[2], LogEventType.ELIMINACION, "MEDICO", "", Success.Failed, pobjOperationResult.ExceptionMessage);
                return;
            }
        }

        public List<LiquidacionMedicoList> LiquidacionMedicos(string pstrFilterExpression, DateTime? pdatBeginDate, DateTime? pdatEndDate, int? pagados)
        {
            try
            {
                SigesoftEntitiesModel dbContext = new SigesoftEntitiesModel();

                var query = (from A in dbContext.servicecomponent
                            join A1 in dbContext.service on A.v_ServiceId equals  A1.v_ServiceId
                            join B in dbContext.systemuser on A.i_MedicoTratanteId equals B.i_SystemUserId
                            join C in dbContext.person on B.v_PersonId equals C.v_PersonId
                            join BB in dbContext.professional on C.v_PersonId equals BB.v_PersonId
                            join D in dbContext.person on A1.v_PersonId equals D.v_PersonId
                            join E in dbContext.systemparameter on new { a = A1.i_MasterServiceId.Value, b = 119 } equals new { a = E.i_ParameterId, b = E.i_GroupId } into E_join
                            from E in E_join.DefaultIfEmpty()
                            join pro in dbContext.protocol on A1.v_ProtocolId equals  pro.v_ProtocolId
                            join F in dbContext.component on A.v_ComponentId equals F.v_ComponentId
                            join L in dbContext.calendar on A1.v_ServiceId equals L.v_ServiceId into L_join
                            from L in L_join.DefaultIfEmpty()

                            where A.i_IsDeleted == 0 && A1.i_MasterServiceId != 2 && (A.r_Price != 0.00 || A.r_Price != 0) && A1.i_MedicoPagado == pagados && A1.i_IsDeleted != 1
                                  && A.i_IsRequiredId == 1
                            //&& L.i_LineStatusId == (int)LineStatus.EnCircuito

                            select new LiquidacionMedicoList
                            {
                                i_MasterServiceId = pro.i_MasterServiceId,
                                i_MasterServiceTypeId = pro.i_MasterServiceTypeId,
                                MedicoTratanteId = B.i_SystemUserId,
                                MedicoTratante = C.v_FirstName + " " + C.v_FirstLastName + " " + C.v_SecondLastName,
                                Direccion = C.v_AdressLocation,
                                Telefono = C.v_TelephoneNumber,
                                CMP= BB.v_ProfessionalCode,
                                Paciente = D.v_FirstName + " " + D.v_FirstLastName + " " + D.v_SecondLastName,
                                d_ServiceDate = A1.d_ServiceDate,
                                v_ServiceId = A.v_ServiceId,
                                Tipo = E.v_Value1,
                                v_ServiceComponentId = A.v_ServiceComponentId,
                                r_CostoComponente = A.r_Price.Value,
                                Componente = F.v_Name,
                                TipoPagoMedico =  1
                            }).Union(
                            from A in dbContext.servicecomponent
                            join A1 in dbContext.service on A.v_ServiceId equals A1.v_ServiceId
                            join B in dbContext.systemuser on A.i_MedicoRealizanteId equals B.i_SystemUserId
                            join C in dbContext.person on B.v_PersonId equals C.v_PersonId
                            join BB in dbContext.professional on C.v_PersonId equals BB.v_PersonId
                            join D in dbContext.person on A1.v_PersonId equals D.v_PersonId
                            join E in dbContext.systemparameter on new { a = A1.i_MasterServiceId.Value, b = 119 } equals new { a = E.i_ParameterId, b = E.i_GroupId } into E_join
                            from E in E_join.DefaultIfEmpty()
                            join pro in dbContext.protocol on A1.v_ProtocolId equals pro.v_ProtocolId
                            join F in dbContext.component on A.v_ComponentId equals F.v_ComponentId
                            join L in dbContext.calendar on A1.v_ServiceId equals L.v_ServiceId into L_join
                            from L in L_join.DefaultIfEmpty()

                            where A.i_IsDeleted == 0 && A1.i_MasterServiceId != 2 && (A.r_Price != 0.00 || A.r_Price != 0) && A1.i_MedicoPagado == pagados && A1.i_IsDeleted != 1
                                  && A.i_IsRequiredId == 1    
                            //&& L.i_LineStatusId == (int)LineStatus.EnCircuito

                            select new LiquidacionMedicoList
                            {
                                i_MasterServiceId = pro.i_MasterServiceId,
                                i_MasterServiceTypeId = pro.i_MasterServiceTypeId,
                                MedicoTratanteId = B.i_SystemUserId,
                                MedicoTratante = C.v_FirstName + " " + C.v_FirstLastName + " " + C.v_SecondLastName,
                                Direccion = C.v_AdressLocation,
                                Telefono = C.v_TelephoneNumber,
                                CMP = BB.v_ProfessionalCode,
                                Paciente = D.v_FirstName + " " + D.v_FirstLastName + " " + D.v_SecondLastName,
                                d_ServiceDate = A1.d_ServiceDate,
                                v_ServiceId = A.v_ServiceId,
                                Tipo = E.v_Value1,
                                v_ServiceComponentId = A.v_ServiceComponentId,
                                r_CostoComponente = A.r_Price.Value,
                                Componente = F.v_Name,
                                TipoPagoMedico = 2 
                            });

                if (!string.IsNullOrEmpty(pstrFilterExpression))
                {
                    query = query.Where(pstrFilterExpression);
                }
                if (pdatBeginDate.HasValue && pdatEndDate.HasValue)
                {
                    query = query.Where("d_ServiceDate >= @0 && d_ServiceDate <= @1", pdatBeginDate.Value, pdatEndDate.Value);
                }

                var medicos = query.ToList().GroupBy(g => g.MedicoTratanteId).Select(s => s.First()).ToList();
                
                List<LiquidacionMedicoList> listaFinal = new List<LiquidacionMedicoList>();
                LiquidacionMedicoList oLiquidacionMedicoList;
                foreach (var medico in medicos)
                {
                    oLiquidacionMedicoList = new LiquidacionMedicoList();
                    oLiquidacionMedicoList.MedicoTratante = medico.MedicoTratante;
                    oLiquidacionMedicoList.MedicoTratanteId = medico.MedicoTratanteId;
                    var servicioMedico = query.ToList().FindAll(p => p.MedicoTratanteId == medico.MedicoTratanteId).ToList();
                    var listaServicios = new List<LiquidacionServicios>();
                    foreach (var servicio in servicioMedico)
                    {
                        var oLiquidacionServicios = new LiquidacionServicios();
                        oLiquidacionServicios.Paciente = servicio.Paciente;
                        oLiquidacionServicios.v_ServiceId = servicio.v_ServiceId;
                        oLiquidacionServicios.d_ServiceDate = servicio.d_ServiceDate;
                        oLiquidacionServicios.Tipo = servicio.Tipo;
                        oLiquidacionServicios.Componente = servicio.Componente;
                        //obtener datos de costo y comisiones
                        if (medico.MedicoTratanteId != null)
                        {
                            //var pagos = ObtenerPagos(servicio.v_ServiceId, medico.MedicoTratanteId.Value, servicio.r_CostoComponente);//ObtenerPagosMedicoNew
                            var pagos = ObtenerPagosMedicoNew(medico.MedicoTratanteId.Value, servicio.r_CostoComponente, servicio.i_MasterServiceId.Value, servicio.i_MasterServiceTypeId.Value, servicio.TipoPagoMedico);
                            oLiquidacionServicios.r_costo = pagos.r_costo;
                            oLiquidacionServicios.r_Comision = pagos.r_Comision;
                            oLiquidacionServicios.r_Total = pagos.r_Total;
                            if (servicio.TipoPagoMedico == 1)
                            {
                                oLiquidacionServicios.TipoPagoMed = "ATENDIDO";
                            }
                            else if (servicio.TipoPagoMedico == 2)
                            {
                                oLiquidacionServicios.TipoPagoMed = "REFERIDO";
                            }
                            else
                            {
                                oLiquidacionServicios.TipoPagoMed = "- - -";
                            }
                        }
                        listaServicios.Add(oLiquidacionServicios);
                    }

                    oLiquidacionMedicoList.Servicios = listaServicios;

                    listaFinal.Add(oLiquidacionMedicoList);
                }

                return listaFinal;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private PagosComisiones ObtenerPagos(string serviceId, int medicoTratanteId, float costoComponente)
        {
             SigesoftEntitiesModel dbContext = new SigesoftEntitiesModel();

            var comisionMedico = (from A in dbContext.medico
                where A.i_IsDeleted == 0 && A.i_SystemUserId == medicoTratanteId
                select A).FirstOrDefault();
            var oPagosComisiones = new PagosComisiones();
            if (comisionMedico != null)
            {
                //var costoServicio = new ServiceBL().GetServiceCost(serviceId);
                oPagosComisiones.r_costo = decimal.Parse(costoComponente.ToString()); //decimal.Parse(costoServicio);
                oPagosComisiones.r_Comision = oPagosComisiones.r_costo * comisionMedico.r_Medico.Value / 100;
                oPagosComisiones.r_Total = oPagosComisiones.r_costo * comisionMedico.r_Clinica.Value / 100; ;

            }
            else
            {
                oPagosComisiones.r_costo = 0;
                oPagosComisiones.r_Comision = 0;
                oPagosComisiones.r_Total = 0;
            }
            
            return oPagosComisiones;
        }

        private PagosComisiones ObtenerPagosMedicoNew(int medicoTratanteId, float costoComponente, int i_MasterServiceId, int i_MasterServiceTypeId, int i_TipoComisionAfecta)
        {
            SigesoftEntitiesModel dbContext = new SigesoftEntitiesModel();

            var comisionMedico = (from A in dbContext.medico
                                  where A.i_IsDeleted == 0 && A.i_SystemUserId == medicoTratanteId && A.i_MasterServiceId == i_MasterServiceId
                                  && A.i_MasterServiceTypeId == i_MasterServiceTypeId && A.i_TipoComisionAfecta == i_TipoComisionAfecta
                select A).FirstOrDefault();
            var oPagosComisiones = new PagosComisiones();
            if (comisionMedico != null)
            {
                oPagosComisiones.r_costo = decimal.Parse(costoComponente.ToString());
                oPagosComisiones.r_Comision = comisionMedico.r_Medico == null
                    ? 0
                    : decimal.Round(((oPagosComisiones.r_costo / (decimal)1.18) * comisionMedico.r_Medico.Value / 100), 2);
                oPagosComisiones.r_Total = comisionMedico.r_Clinica == null
                    ? 0
                    : decimal.Round(((oPagosComisiones.r_costo / (decimal)1.18) * comisionMedico.r_Clinica.Value / 100), 2);
            }
            else
            {
                oPagosComisiones.r_costo = 0;
                oPagosComisiones.r_Comision = 0;
                oPagosComisiones.r_Total = 0;
            }

            return oPagosComisiones;
        }


        public hospitalizacionserviceDto GetHospitServ( string hospitalizacionId)
        {
            try
            {
                SigesoftEntitiesModel dbContext = new SigesoftEntitiesModel();
                hospitalizacionserviceDto objDtoEntity = null;

                var objEntity = (from a in dbContext.hospitalizacionservice
                                 where a.v_HopitalizacionId == hospitalizacionId
                                 select a).FirstOrDefault();

                if (objEntity != null)
                    objDtoEntity = hospitalizacionserviceAssembler.ToDTO(objEntity);

                return objDtoEntity;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public ticketDto GetHospitServTicket(string ticketId)
        {
            try
            {
                SigesoftEntitiesModel dbContext = new SigesoftEntitiesModel();
                ticketDto objDtoEntity = null;

                var objEntity = (from a in dbContext.ticket
                                 where a.v_TicketId == ticketId
                    select a).FirstOrDefault();

                if (objEntity != null)
                    objDtoEntity = ticketAssembler.ToDTO(objEntity);

                return objDtoEntity;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public hospitalizacionserviceDto GetHospitServwithTicekt(string serviceId)
        {
            try
            {
                SigesoftEntitiesModel dbContext = new SigesoftEntitiesModel();
                hospitalizacionserviceDto objDtoEntity = null;

                var objEntity = (from a in dbContext.hospitalizacionservice
                    where a.v_ServiceId == serviceId
                    select a).FirstOrDefault();

                if (objEntity != null)
                    objDtoEntity = hospitalizacionserviceAssembler.ToDTO(objEntity);

                return objDtoEntity;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public serviceDto GetService(string servideId)
        {
            try
            {
                SigesoftEntitiesModel dbContext = new SigesoftEntitiesModel();
                serviceDto objDtoEntity = null;

                var objEntity = (from a in dbContext.service
                                 where a.v_ServiceId == servideId
                    select a).FirstOrDefault();

                if (objEntity != null)
                    objDtoEntity = serviceAssembler.ToDTO(objEntity);

                return objDtoEntity;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public protocolDto GetProtocol(string protocolId)
        {
            try
            {
                SigesoftEntitiesModel dbContext = new SigesoftEntitiesModel();
                protocolDto objDtoEntity = null;

                var objEntity = (from a in dbContext.protocol
                                 where a.v_ProtocolId == protocolId
                    select a).FirstOrDefault();

                if (objEntity != null)
                    objDtoEntity = protocolAssembler.ToDTO(objEntity);

                return objDtoEntity;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public hospitalizacionhabitacionDto GetHospitalizacionHabitacion(ref OperationResult pobjOperationResult, string v_HopitalizacionId)
        {
            //mon.IsActive = true;
            try
            {
                SigesoftEntitiesModel dbContext = new SigesoftEntitiesModel();
                hospitalizacionhabitacionDto objDtoEntity = null;

                var objEntity = (from a in dbContext.hospitalizacionhabitacion
                                 where a.v_HopitalizacionId == v_HopitalizacionId
                                 orderby a.d_InsertDate descending
                                 select a).FirstOrDefault();

                if (objEntity != null)
                    objDtoEntity = hospitalizacionhabitacionAssembler.ToDTO(objEntity);

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

        
        public void ActualizarPagoMedico(string serviceId)
        {
            try
            {
                 SigesoftEntitiesModel dbContext = new SigesoftEntitiesModel();

                // Obtener la entidad fuente
                var objEntitySource = (from a in dbContext.service
                                       where a.v_ServiceId == serviceId
                                       select a).FirstOrDefault();

                objEntitySource.i_MedicoPagado = 1;

                // Guardar los cambios
                dbContext.SaveChanges();

                return;
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }


        public string GetComentaryUpdateByMedicoId(string medicoId)
        {
            using (var dbContext = new SigesoftEntitiesModel())
            {
                return dbContext.medico.FirstOrDefault(p => p.v_MedicoId == medicoId).v_ComentaryUpdate;
            }
        }


        public List<HospitalizacionServiceListNew> BuscarServiciosHospitalizacionNew(string hospitalizacionId)
        {
            try
            {
                //acá hace un select a la tabla hospitalizacionService y buscas todos que tengan foranea HospitalizacionId
                SigesoftEntitiesModel dbContext = new SigesoftEntitiesModel();
                List<HospitalizacionServiceListNew> queryservice = (from A in dbContext.buscarservicioshospitalizacion_1(hospitalizacionId)
                                                                    select new HospitalizacionServiceListNew
                                                                    {
                                                                        v_HospitalizacionServiceId = A.v_HospitalizacionServiceId,
                                                                        v_HopitalizacionId = A.v_HopitalizacionId,
                                                                        v_ServiceId = A.v_ServiceId,
                                                                        d_ServiceDate = A.d_ServiceDate.Value,
                                                                        v_ProtocolName = A.v_ProtocolName,
                                                                        v_ProtocolId = A.v_ProtocolId,
                                                                        v_DocNumber = A.v_DocNumber,
                                                                        d_FechaAlta = A.d_FechaAlta
                                                                    }).ToList();

                return queryservice;
            }
            catch (Exception ex)
            {
                return null;
            }


        }

        public hospitalizacionDto GetHospitalizacionDx(string v_HospitalizacionId)
        {
             try
            {
                              SigesoftEntitiesModel dbContext = new SigesoftEntitiesModel();
                hospitalizacionDto objDtoEntity = null;

                var objEntity = (from a in dbContext.hospitalizacion
                                 where a.v_HopitalizacionId == v_HospitalizacionId
                                 select a).FirstOrDefault();

                if (objEntity != null)
                    objDtoEntity = hospitalizacionAssembler.ToDTO(objEntity);

                return objDtoEntity;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public configuracionpagoDto GetConfPago(ref OperationResult pobjOperationResult, string v_IdConfPago)
        {
            //mon.IsActive = true;
            try
            {
                SigesoftEntitiesModel dbContext = new SigesoftEntitiesModel();
                configuracionpagoDto objDtoEntity = null;

                var objEntity = (from a in dbContext.configuracionpago
                                 where a.v_IdConfPago == v_IdConfPago
                                 select a).FirstOrDefault();

                if (objEntity != null)
                    objDtoEntity = configuracionpagoAssembler.ToDTO(objEntity);

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

        public string  AddConfiguracionPago(ref OperationResult pobjOperationResult, configuracionpagoDto pobjDtoEntity, List<string> ClientSession, List<AdditionalExamCustom> componentes)
        {
            //mon.IsActive = true;
            string NewId = "(No generado)";
            try
            {
                SigesoftEntitiesModel dbContext = new SigesoftEntitiesModel();
                configuracionpago objEntity = configuracionpagoAssembler.ToEntity(pobjDtoEntity);

                objEntity.d_InsertDate = DateTime.Now;
                objEntity.i_InsertUserId = Int32.Parse(ClientSession[2]);
                objEntity.i_IsDeleted = 0;

                // Autogeneramos el Pk de la tabla                 
                int intNodeId = int.Parse(ClientSession[0]);
                NewId = Common.Utils.GetNewId(intNodeId, Utils.GetNextSecuentialId(intNodeId, 451), "CP"); ;
                objEntity.v_IdConfPago = NewId;

                dbContext.AddToconfiguracionpago(objEntity);
                dbContext.SaveChanges();

                foreach (var item in componentes)
                {
                    configuracionexamenpagoDto _configuracionexamenpagoDto = new configuracionexamenpagoDto();
                    _configuracionexamenpagoDto.v_IdConfPago = NewId;
                    _configuracionexamenpagoDto.v_ComponentId = item.ComponentId;
                    AddConfiguracionPagoeXAMEN(ref pobjOperationResult, _configuracionexamenpagoDto, ClientSession);
                }
                pobjOperationResult.Success = 1;
                // Llenar entidad Log
                LogBL.SaveLog(ClientSession[0], ClientSession[1], ClientSession[2], LogEventType.CREACION, "CONFIGURACION_PAGO", "v_IdConfPago=" + NewId.ToString(), Success.Ok, null);
                return NewId;
            }
            catch (Exception ex)
            {
                pobjOperationResult.Success = 0;
                pobjOperationResult.ExceptionMessage = Common.Utils.ExceptionFormatter(ex);
                // Llenar entidad Log
                LogBL.SaveLog(ClientSession[0], ClientSession[1], ClientSession[2], LogEventType.CREACION, "CONFIGURACION_PAGO", "v_IdConfPago=" + NewId.ToString(), Success.Failed, pobjOperationResult.ExceptionMessage);
                return NewId;
            }
        }

        public void UpdateConfiguracionPago(ref OperationResult pobjOperationResult, configuracionpagoDto pobjDtoEntity, List<string> ClientSession, List<AdditionalExamCustom> componentes)
        {
            //mon.IsActive = true;
            try
            {
                SigesoftEntitiesModel dbContext = new SigesoftEntitiesModel();

                // Obtener la entidad fuente
                var objEntitySource = (from a in dbContext.configuracionpago
                                       where a.v_IdConfPago == pobjDtoEntity.v_IdConfPago
                                       select a).FirstOrDefault();

                // Crear la entidad con los datos actualizados
                pobjDtoEntity.d_UpdateDate = DateTime.Now;
                pobjDtoEntity.i_IsDeleted = 0;
                pobjDtoEntity.i_UpdateUserId = Int32.Parse(ClientSession[2]);

                configuracionpago objEntity = configuracionpagoAssembler.ToEntity(pobjDtoEntity);

                // Copiar los valores desde la entidad actualizada a la Entidad Fuente
                dbContext.configuracionpago.ApplyCurrentValues(objEntity);

                // Guardar los cambios
                dbContext.SaveChanges();

                foreach (var item in componentes)
                {
                    configuracionexamenpagoDto _configuracionexamenpagoDto = new configuracionexamenpagoDto();
                    _configuracionexamenpagoDto.v_IdConfPago = pobjDtoEntity.v_IdConfPago;
                    _configuracionexamenpagoDto.v_ComponentId = item.ComponentId;
                    AddConfiguracionPagoeXAMEN(ref pobjOperationResult, _configuracionexamenpagoDto, ClientSession);
                }

                pobjOperationResult.Success = 1;
                // Llenar entidad Log
                LogBL.SaveLog(ClientSession[0], ClientSession[1], ClientSession[2], LogEventType.ACTUALIZACION, "CONFIGURACION_PAGO", "v_IdConfPago=" + objEntity.v_IdConfPago.ToString(), Success.Ok, null);
                return;
            }
            catch (Exception ex)
            {
                pobjOperationResult.Success = 0;
                pobjOperationResult.ExceptionMessage = Common.Utils.ExceptionFormatter(ex);
                // Llenar entidad Log
                LogBL.SaveLog(ClientSession[0], ClientSession[1], ClientSession[2], LogEventType.ACTUALIZACION, "CONFIGURACION_PAGO", "v_IdConfPago=" + pobjDtoEntity.v_IdConfPago.ToString(), Success.Failed, pobjOperationResult.ExceptionMessage);
                return;
            }
        }

        public void DeleteConfHorario(ref OperationResult pobjOperationResult, string _IdConfPago, List<string> ClientSession)
        {
            //mon.IsActive = true;

            try
            {
                SigesoftEntitiesModel dbContext = new SigesoftEntitiesModel();

                // Obtener la entidad fuente
                var objEntitySource = (from a in dbContext.configuracionpago
                                       where a.v_IdConfPago == _IdConfPago
                                       select a).FirstOrDefault();

                // Crear la entidad con los datos actualizados
                objEntitySource.d_UpdateDate = DateTime.Now;
                objEntitySource.i_UpdateUserId = Int32.Parse(ClientSession[2]);
                objEntitySource.i_IsDeleted = 1;

                // Guardar los cambios
                dbContext.SaveChanges();

                pobjOperationResult.Success = 1;
                // Llenar entidad Log
                LogBL.SaveLog(ClientSession[0], ClientSession[1], ClientSession[2], LogEventType.ELIMINACION, "CONFIGURACION_PAGO", "v_IdConfPago=" + _IdConfPago, Success.Ok, null);
                return;
            }
            catch (Exception ex)
            {
                pobjOperationResult.Success = 0;
                pobjOperationResult.ExceptionMessage = Common.Utils.ExceptionFormatter(ex);
                // Llenar entidad Log
                LogBL.SaveLog(ClientSession[0], ClientSession[1], ClientSession[2], LogEventType.ELIMINACION, "CONFIGURACION_PAGO", "v_IdConfPago=" + _IdConfPago, Success.Failed, pobjOperationResult.ExceptionMessage);
                return;
            }
        }

        public void AddConfiguracionPagoeXAMEN(ref OperationResult pobjOperationResult, configuracionexamenpagoDto pobjDtoEntity, List<string> ClientSession)
        {
            //mon.IsActive = true;
            string NewId = "(No generado)";
            try
            {
                SigesoftEntitiesModel dbContext = new SigesoftEntitiesModel();
                configuracionexamenpago objEntity = configuracionexamenpagoAssembler.ToEntity(pobjDtoEntity);

                objEntity.d_InsertDate = DateTime.Now;
                objEntity.i_InsertUserId = Int32.Parse(ClientSession[2]);
                objEntity.i_IsDeleted = 0;

                // Autogeneramos el Pk de la tabla                 
                int intNodeId = int.Parse(ClientSession[0]);
                NewId = Common.Utils.GetNewId(intNodeId, Utils.GetNextSecuentialId(intNodeId, 452), "PE"); ;
                objEntity.v_idPagoExam = NewId;

                dbContext.AddToconfiguracionexamenpago(objEntity);
                dbContext.SaveChanges();

                pobjOperationResult.Success = 1;
                // Llenar entidad Log
                LogBL.SaveLog(ClientSession[0], ClientSession[1], ClientSession[2], LogEventType.CREACION, "CONFIGURACION_PAGO_EXAMEN", "v_idPagoExam=" + NewId.ToString(), Success.Ok, null);
                return;
            }
            catch (Exception ex)
            {
                pobjOperationResult.Success = 0;
                pobjOperationResult.ExceptionMessage = Common.Utils.ExceptionFormatter(ex);
                // Llenar entidad Log
                LogBL.SaveLog(ClientSession[0], ClientSession[1], ClientSession[2], LogEventType.CREACION, "CONFIGURACION_PAGO_EXAMEN", "v_idPagoExam=" + NewId.ToString(), Success.Failed, pobjOperationResult.ExceptionMessage);
                return;
            }
        }

        public void DeleteExamenConf(ref OperationResult pobjOperationResult, string v_idPagoExam, List<string> ClientSession)
        {
            //mon.IsActive = true;

            try
            {
                SigesoftEntitiesModel dbContext = new SigesoftEntitiesModel();

                // Obtener la entidad fuente
                var objEntitySource = (from a in dbContext.configuracionexamenpago
                                       where a.v_idPagoExam == v_idPagoExam
                                       select a).FirstOrDefault();

                // Crear la entidad con los datos actualizados
                objEntitySource.d_UpdateDate = DateTime.Now;
                objEntitySource.i_UpdateUserId = Int32.Parse(ClientSession[2]);
                objEntitySource.i_IsDeleted = 1;

                // Guardar los cambios
                dbContext.SaveChanges();

                pobjOperationResult.Success = 1;
                // Llenar entidad Log
                LogBL.SaveLog(ClientSession[0], ClientSession[1], ClientSession[2], LogEventType.ELIMINACION, "CONFIGURACION_PAGO_EXAMEN", "v_idPagoExam=" + v_idPagoExam, Success.Ok, null);
                return;
            }
            catch (Exception ex)
            {
                pobjOperationResult.Success = 0;
                pobjOperationResult.ExceptionMessage = Common.Utils.ExceptionFormatter(ex);
                // Llenar entidad Log
                LogBL.SaveLog(ClientSession[0], ClientSession[1], ClientSession[2], LogEventType.ELIMINACION, "CONFIGURACION_PAGO_EXAMEN", "v_idPagoExam=" + v_idPagoExam, Success.Failed, pobjOperationResult.ExceptionMessage);
                return;
            }
        }

        public List<LiquidacionMedicoListPay> GetListServicesPay_SP(DateTime pdatBeginDate, DateTime pdatEndDate, int Medico, int TipoServicio)
        {
            try
            {
                SigesoftEntitiesModel dbContext = new SigesoftEntitiesModel();

                var query = (from A in dbContext.getlistservicespay_sp(pdatBeginDate, pdatEndDate, Medico, 0)

                             select new LiquidacionMedicoListPay
                             {
                                 i_MasterServiceId = A.i_MasterServiceId,
                                 i_MasterServiceTypeId = A.i_MasterServiceTypeId,
                                 MedicoTratanteId = A.MedicoTratanteId  ,
                                 MedicoTratante = A.MedicoTratante,
                                 Direccion = A.Direccion,
                                 Telefono = A.Telefono,
                                 CMP = A.CMP,
                                 Paciente = A.Paciente,
                                 d_ServiceDate = A.d_ServiceDate,
                                 v_ServiceId = A.v_ServiceId,
                                 Tipo = A.Tipo,
                                 v_ServiceComponentId = A.v_ServiceComponentId,
                                 r_CostoComponente = A.r_CostoComponente.Value,
                                 Componente = A.Componente,
                                 TipoProtocolo = A.TipoProtocolo,
                                 TipoComprobante = A.TipoComprobante,
                                 Comprobante = A.Comprobante,
                                 d_Total = A.d_Total.Value,
                                 GrupoId = A.GrupoId,
                                 Turno = A.Turno,
                                 CodigoId = A.CodigoId,
                                 Grupo = A.Grupo,
                                 TipoMed = A.TipoMed
                             }).ToList();



                return query;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public List<LiquidacionMedicoListPay> GetListServicesPaySolicitante_SP(DateTime pdatBeginDate, DateTime pdatEndDate, int Medico, int TipoServicio)
        {
            try
            {
                SigesoftEntitiesModel dbContext = new SigesoftEntitiesModel();

                var query = (from A in dbContext.getlistservicespaysolicitante_sp(pdatBeginDate, pdatEndDate, Medico, 0)

                             select new LiquidacionMedicoListPay
                             {
                                 i_MasterServiceId = A.i_MasterServiceId,
                                 i_MasterServiceTypeId = A.i_MasterServiceTypeId,
                                 MedicoTratanteId = A.MedicoTratanteId,
                                 MedicoTratante = A.MedicoTratante,
                                 Direccion = A.Direccion,
                                 Telefono = A.Telefono,
                                 CMP = A.CMP,
                                 Paciente = A.Paciente,
                                 d_ServiceDate = A.d_ServiceDate,
                                 v_ServiceId = A.v_ServiceId,
                                 Tipo = A.Tipo,
                                 v_ServiceComponentId = A.v_ServiceComponentId,
                                 r_CostoComponente = A.r_CostoComponente.Value,
                                 Componente = A.Componente,
                                 TipoProtocolo = A.TipoProtocolo,
                                 TipoComprobante = A.TipoComprobante,
                                 Comprobante = A.Comprobante,
                                 d_Total = A.d_Total.Value,
                                 GrupoId = A.GrupoId,
                                 Turno = A.Turno,
                                 CodigoId = A.CodigoId,
                                 Grupo = A.Grupo,
                                 TipoMed = A.TipoMed
                             }).ToList();



                return query;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public List<MedicoConfListExamen> ObtenerConfPagoTurno(int medicoTratanteId, int i_TipoPago)
        {
            SigesoftEntitiesModel dbContext = new SigesoftEntitiesModel();

            var query = (from A in dbContext.configuracionpago
                        join B in dbContext.systemuser on A.i_SystemUserId equals B.i_SystemUserId
                        join C in dbContext.person on B.v_PersonId equals C.v_PersonId

                        join F in dbContext.systemuser on A.i_InsertUserId equals F.i_SystemUserId into F_join
                        from F in F_join.DefaultIfEmpty()

                        join H in dbContext.systemuser on A.i_UpdateUserId equals H.i_SystemUserId into H_join
                        from H in H_join.DefaultIfEmpty()

                        join I in dbContext.configuracionexamenpago on A.v_IdConfPago equals I.v_IdConfPago
                        join J in dbContext.component on I.v_ComponentId equals J.v_ComponentId


                        where A.i_IsDeleted == 0 && A.i_TipoPago == i_TipoPago && A.i_SystemUserId == medicoTratanteId
                         select new MedicoConfListExamen
                        {
                            v_IdConfPago = A.v_IdConfPago,
                            Usuario = B.v_UserName,
                            Medico = C.v_FirstName + " " + C.v_FirstLastName + " " + C.v_SecondLastName,
                            i_SystemUserId = B.i_SystemUserId,
                            i_TipoPago = A.i_TipoPago.Value,
                            v_TipoPago = A.i_TipoPago == 1 ? "X. TURNO" : A.i_TipoPago == 2 ? "X. HORA " : "X. EXAMEN",
                            d_MontoxTurno = A.d_MontoxTurno.Value,
                            d_MonoxHora = A.d_MonoxHora.Value,
                            i_OrdenExam = A.i_OrdenExam.Value,
                            v_OrdenExam = A.i_OrdenExam == 1 ? "M. Tratante" : A.i_OrdenExam == 2 ? "M. Solicitante" : "",
                            d_PorcClinicaExam = A.d_PorcClinicaExam.Value,
                            d_PorcMedicoExam = A.d_PorcMedicoExam.Value,
                            i_DescontarBoletaExam = A.i_DescontarBoletaExam.Value,
                            v_DescontarBoletaExam = A.i_DescontarBoletaExam == 1 ? "X" : "",
                            i_DescontarFactExam = A.i_DescontarFactExam.Value,
                            v_DescontarFactExam = A.i_DescontarFactExam == 1 ? "X" : "",
                            i_DescontarRecbExam = A.i_DescontarRecbExam.Value,
                            v_DescontarRecbExam = A.i_DescontarRecbExam == 1 ? "X" : "",
                            Observaciones = A.v_Observaciones,
                            v_ObservacionesCambios = A.v_ObservacionesCambios,
                            i_IsDeleted = A.i_IsDeleted,
                            i_InsertUserId = A.i_InsertUserId,
                            v_InsertUserId = F.v_UserName,
                            d_InsertDate = A.d_InsertDate.Value,
                            i_UpdateUserId = A.i_UpdateUserId,
                            v_UpdateUserId = H.v_UserName,
                            d_UpdateDate = A.d_UpdateDate.Value,
                            v_ComponentId = I.v_ComponentId,
                            Examen = J.v_Name,
                            i_TipoDescuentoHoraMin = A.i_TipoDescuentoHoraMin.Value,
                            v_TipoDescuentoHoraMin = A.i_TipoDescuentoHoraMin.Value == 1 ? "HORAS" : A.i_TipoDescuentoHoraMin == 2 ? "MINUTOS" : "",
                            i_DesucuentodeHorario = A.i_DesucuentodeHorario.Value,
                        }).ToList();


            return query;
        }
        public List<SystemParameterTurno> ObtenerSpTurno(int grupo)
        {
            SigesoftEntitiesModel dbContext = new SigesoftEntitiesModel();

            var query = (from A in dbContext.systemparameter

                         where A.i_IsDeleted == 0 && A.i_GroupId == grupo && A.i_ParentParameterId != -1
                         select new SystemParameterTurno
                         {
                             GrupoId = A.i_GroupId,
                             ParameterId = A.i_ParameterId,
                             Value1 = A.v_Value1
                         }).ToList();


            return query;
        }

        


    }
}
