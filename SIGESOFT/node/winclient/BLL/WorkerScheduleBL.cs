using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using Dapper;
using Sigesoft.Common;
using Sigesoft.Node.WinClient.BE;
using Sigesoft.Node.WinClient.BE.Custom;
using Sigesoft.Node.WinClient.DAL;
using Sigesoft.Node.WinClient.UI;

namespace Sigesoft.Node.WinClient.BLL
{
    public class WorkerScheduleBL
    {
        private SigesoftEntitiesModel cnx = new SigesoftEntitiesModel();

        private string GetMonthName(int month)
        {
            string mes = "";
            switch (month)
            {
                case 1:
                    mes = "Enero";
                    break;
                case 2:
                    mes = "Febrero";
                    break;
                case 3:
                    mes = "Marzo";
                    break;
                case 4:
                    mes = "Abril";
                    break;
                case 5:
                    mes = "Mayo";
                    break;
                case 6:
                    mes = "Junio";
                    break;
                case 7:
                    mes = "Julio";
                    break;
                case 8:
                    mes = "Agosto";
                    break;
                case 9:
                    mes = "Setiembre";
                    break;
                case 10:
                    mes = "Octubre";
                    break;
                case 11:
                    mes = "Noviembre";
                    break;
                case 12:
                    mes = "Diciembre";
                    break;
            }

            return mes;
        }

        public string AddWorkerSchedule(workersscheduleDto data, int userId, int nodeId)
        {
            try
            {
                string newId = Common.Utils.GetNewId(nodeId, Utils.GetNextSecuentialId(nodeId, 49), "WS");
                data.v_ScheduleId = newId;
                data.i_InsertUserId = userId;
                data.d_InsertDate = DateTime.Now;
                data.i_IsDeleted = 0;

                workersschedule objEntity = workersscheduleAssembler.ToEntity(data);
                cnx.AddToworkersschedule(objEntity);
                cnx.SaveChanges();

                return newId;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public void UpdateWorkerSchedule(workersscheduleDto data, int userId, int nodeId)
        {
            try
            {
                var obj = cnx.workersschedule.Where(x => x.v_ScheduleId == data.v_ScheduleId).FirstOrDefault();
                
                obj.i_UpdateUserId = userId;
                obj.d_UpdateDate = DateTime.Now;
                obj.v_Mes = data.v_Mes;
                obj.v_ScheduleDescription = data.v_ScheduleDescription;

                cnx.SaveChanges();

            }
            catch (Exception e)
            {
                throw;
            }
        }

        public bool AddWorkerScheduleDetail(workersscheduledetailDto data, int userId, int nodeId)
        {
            try
            {
                string newId = Common.Utils.GetNewId(nodeId, Utils.GetNextSecuentialId(nodeId, 50), "WD");
                data.v_ScheduleDetailId = newId;
                data.i_InsertUserId = userId;
                data.d_InsertDate = DateTime.Now;
                data.i_IsDeleted = 0;

                workersscheduledetail objEntity = workersscheduledetailAssembler.ToEntity(data);
                cnx.AddToworkersscheduledetail(objEntity);
                cnx.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public void UpdateWorkerScheduleDetail(workersscheduledetailDto data, int userId, int nodeId)
        {
            try
            {
                SigesoftEntitiesModel dbContext = new SigesoftEntitiesModel();

                // Obtener la entidad fuente
                var objEntitySource = (from a in dbContext.workersscheduledetail
                                       where a.v_ScheduleDetailId == data.v_ScheduleDetailId
                                        select a).FirstOrDefault();

                // Crear la entidad con los datos actualizados
                data.d_UpdateDate = DateTime.Now;
                data.i_IsDeleted = 0;
                data.i_InsertUserId = objEntitySource.i_InsertUserId;
                data.i_UpdateUserId = userId;
                workersscheduledetail objEntity = workersscheduledetailAssembler.ToEntity(data);

                // Copiar los valores desde la entidad actualizada a la Entidad Fuente
                dbContext.workersscheduledetail.ApplyCurrentValues(objEntity);

                // Guardar los cambios
                dbContext.SaveChanges();

            }
            catch (Exception e)
            {
                throw;
            }
        }

        public bool DeleteWorkerSchedule(string id)
        {
            try
            {
                var obj = cnx.workersschedule.Where(x => x.v_ScheduleId == id).FirstOrDefault();
                obj.i_IsDeleted = 1;
                cnx.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool DeleteWorkerScheduleDetail(string id)
        {
            try
            {
                var obj = cnx.workersscheduledetail.Where(x => x.v_ScheduleDetailId == id).FirstOrDefault();
                obj.i_IsDeleted = 1;
                cnx.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<WorkersScheduleCustom> GetSchedules(string value, string mes)
        {
            string year = DateTime.Now.Year.ToString();
            DateTime dateInicio = DateTime.Parse("01/01/" + year);
            try
            {
                var list = (from wor in cnx.workersschedule
                    join wrd in cnx.workersscheduledetail on wor.v_ScheduleId equals wrd.v_ScheduleId
                    join per in cnx.person on wrd.v_PersonId equals per.v_PersonId
                    join prof in cnx.professional on per.v_PersonId equals prof.v_PersonId
                    join dhy in cnx.datahierarchy on new {a = prof.i_ProfessionId.Value, b = 101} equals new
                        {a = dhy.i_ItemId, b = dhy.i_GroupId}
                    where wor.i_IsDeleted == 0 &&
                          (per.v_FirstName.Contains(value) || per.v_SecondLastName.Contains(value) || per.v_FirstName.Contains(value) ||
                           value == null || per.v_DocNumber.Contains(value)) && wor.v_Mes == mes && wrd.d_Date >= dateInicio
                    select new WorkersScheduleCustom
                    {
                        v_FullName = per.v_FirstLastName + " " + per.v_SecondLastName + ", " + per.v_FirstName,
                        v_Profesion = dhy.v_Value1,
                        v_ScheduleId = wor.v_ScheduleId,
                        v_Mes = wor.v_Mes,
                    }).ToList().GroupBy(x => x.v_ScheduleId).Select(x => x.First()).ToList();
                return list;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public List<WorkersScheduleDetailCustom> GetSchedulesDetail(string v_ScheduleId)
        {
            string year = DateTime.Now.Year.ToString();
            DateTime dateInicio = DateTime.Parse("01/01/" + year);
            try
            {
                var list = (from wrd in cnx.workersscheduledetail 
                    join per in cnx.person on wrd.v_PersonId equals per.v_PersonId
                    join prof in cnx.professional on per.v_PersonId equals prof.v_PersonId
                    join dhy in cnx.datahierarchy on new {a = prof.i_ProfessionId.Value, b = 101} equals new
                        {a = dhy.i_ItemId, b = dhy.i_GroupId}
                    where wrd.i_IsDeleted == 0 && wrd.v_ScheduleId == v_ScheduleId
                    select new WorkersScheduleDetailCustom
                    {
                        v_FullName = per.v_FirstLastName + " " + per.v_SecondLastName + ", " + per.v_FirstName,
                        v_ScheduleId = wrd.v_ScheduleId,
                        v_ScheduleDetailId = wrd.v_ScheduleDetailId,
                        d_StartDate = wrd.d_Date,
                        d_EndDate = wrd.d_Date,
                        v_PersonId = wrd.v_PersonId
                    }).ToList().GroupBy(x => x.v_ScheduleDetailId).Select(x => x.First()).ToList();
                return list;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public workersscheduledetailDto GetWorkerScheduleDetail(string v_ScheduleDetailId)
        {
            var objEntity = (from a in cnx.workersscheduledetail
                             where a.v_ScheduleDetailId == v_ScheduleDetailId
                            select a).FirstOrDefault();

            if (objEntity != null)
                return workersscheduledetailAssembler.ToDTO(objEntity);
            else return null;
        }

        public string GetPersonIdByDocNumber(string dni)
        {
            try
            {
                return cnx.person.Where(x => x.v_DocNumber == dni).FirstOrDefault().v_PersonId;
            }
            catch (Exception e)
            {
                return null;
            }
        }


        public StateMarking GetDataTypeMarking_(DateTime hoyServidor, int cantMark, TimeSpan? ini, TimeSpan? iniRefri, TimeSpan? finRefri, TimeSpan? salida)
        {
            StateMarking state = new StateMarking();
            state.PermiteAntes = true;
            state.TiempoTardanza = TimeSpan.Parse("00:00");
            state.SobreTiempo = TimeSpan.Parse("00:00");
            state.Tardanza = false;
            state.PerteneceDia = true;
            if (cantMark == 0)
            {
                state.HoraEstablecida = ini.Value;
                state.TypeMarking = "INGRESO";
                if (hoyServidor.TimeOfDay >= ini)
                {
                    state.Tardanza = true;
                    state.TiempoTardanza = hoyServidor.TimeOfDay - ini.Value;
                }
            }
            else if (cantMark == 1)
            {
                state.TypeMarking = "REFRIGERIO";
                
                if (iniRefri == null && finRefri == null)
                {
                    state.TypeMarking = "SALIDA";
                    state.HoraEstablecida = salida.Value;
                    if (hoyServidor.TimeOfDay < salida)
                        state.PermiteAntes = false;
                    else
                        state.SobreTiempo = hoyServidor.TimeOfDay - salida.Value;
                }
                else
                {
                    state.HoraEstablecida = iniRefri.Value;
                    if (hoyServidor.TimeOfDay < iniRefri) state.PermiteAntes = false;
                }


            }
            else if (cantMark == 2)
            {
                state.HoraEstablecida = finRefri.Value;
                state.TypeMarking = "RETORNO REFRIGERIO";
                if (hoyServidor.TimeOfDay > finRefri)
                {
                    state.Tardanza = true;
                    state.TiempoTardanza = hoyServidor.TimeOfDay - finRefri.Value;
                }

            }
            else if (cantMark == 3)
            {
                state.HoraEstablecida = salida.Value;
                state.TypeMarking = "SALIDA";
                if (hoyServidor.TimeOfDay < salida)
                {
                    state.PermiteAntes = false;
                }
                else
                {
                    state.SobreTiempo = hoyServidor.TimeOfDay - salida.Value;
                }
            }

            return state;
        }

        public StateMarking GetDataTypeMarking(DateTime hoyServidor, workersscheduledetailDto data, int cantMark, List<markingsDto> Lista)
        {
            StateMarking state = new StateMarking();
            state.PermiteAntes = true;
            state.TiempoTardanza = TimeSpan.Parse("00:00");
            state.SobreTiempo = TimeSpan.Parse("00:00");
            state.Tardanza = false;
            state.PerteneceDia = true;
            if (cantMark == 0)
            {
                state.HoraEstablecida = data.t_StartDate.Value;
                state.TypeMarking = "INGRESO";
                if (hoyServidor.TimeOfDay >= state.HoraEstablecida)
                {
                    state.Tardanza = true;
                    state.TiempoTardanza = hoyServidor.TimeOfDay - state.HoraEstablecida;
                }
            }
            else if (cantMark == 1)
            {
                state.TypeMarking = "REFRIGERIO";

                if (data.t_StartBreak == null && data.t_EndBreak == null)
                {
                    state.TypeMarking = "SALIDA";
                    state.HoraEstablecida = data.t_EndDate.Value;
                    if (hoyServidor.TimeOfDay < data.t_EndDate.Value)
                    {
                        state.PermiteAntes = true;
                        state.TiempoTardanza = data.t_EndDate.Value - hoyServidor.TimeOfDay;
                    }
                    else
                    {
                        state.SobreTiempo = hoyServidor.TimeOfDay - data.t_EndDate.Value;
                    }

                    
                }
                else
                {
                    state.HoraEstablecida = data.t_StartBreak.Value;                    
                }


            }
            else if (cantMark == 2)
            {
                state.HoraEstablecida = data.t_EndBreak.Value;
                state.TypeMarking = "RETORNO REFRIGERIO";
                var find = Lista.Find(x => x.v_TypeMarking == "REFRIGERIO");
                TimeSpan tiempo = data.t_EndBreak.Value - data.t_StartBreak.Value;
                tiempo = tiempo < TimeSpan.Parse("01:00") ? TimeSpan.Parse("01:00") : tiempo;
                TimeSpan tardanza = hoyServidor.TimeOfDay - find.d_DialingDate.Value.TimeOfDay - tiempo;
                if (tardanza > TimeSpan.Zero)
                {
                    state.Tardanza = true;
                    state.TiempoTardanza = tardanza;
                }

            }
            else if (cantMark == 3)
            {
                state.HoraEstablecida = data.t_EndDate.Value;
                state.TypeMarking = "SALIDA";
                if (hoyServidor.TimeOfDay < data.t_EndDate.Value)
                {
                    state.Tardanza = true;
                    //TimeSpan tiempo = data.t_EndBreak.Value - data.t_StartBreak.Value;
                    state.TiempoTardanza = data.t_EndDate.Value - hoyServidor.TimeOfDay;
                }
                else
                {
                    state.SobreTiempo = hoyServidor.TimeOfDay - data.t_EndDate.Value; 
                }
            }

            return state;
        }

        public string SaveMarking(markingsDto data, string name)
        {
            try
            {
                DateTime hoy = DateTime.Now.Date;
                DateTime ayer = hoy.AddDays(-1);
                StateMarking state = new StateMarking();
                using (var _ctx = ConnectionHelperSige.GetConnection)
                {
                    data.d_DialingDate = _ctx.Query<DateTime>("SELECT GETDATE()").FirstOrDefault();
                }

                ///Primero busco si es un horario nocturno
                var objNightSchedule = (from wrd in cnx.workersscheduledetail
                                        where wrd.v_PersonId == data.v_PersonId && wrd.i_IsDeleted == 0 && wrd.d_Date == ayer
                                        select wrd).FirstOrDefault();
                int cantMark = 0;
                bool nocturno = false;
                if (objNightSchedule != null)
                {
                    var objNightScheduleDto = workersscheduledetailAssembler.ToDTO(objNightSchedule);
                    if (objNightScheduleDto.t_StartDate == TimeSpan.Parse("20:00"))
                    {
                        //Nocturno
                        nocturno = true;
                        data.v_ScheduleDetailId = objNightScheduleDto.v_ScheduleDetailId;
                        cantMark = cnx.markings.Where(x => x.v_PersonId == data.v_PersonId && x.d_DialingDate.Value >= ayer.Date && x.d_DialingDate.Value < hoy).ToList().Count;
                    }

                }


                cantMark += cnx.markings.Where(x => x.v_PersonId == data.v_PersonId && x.d_DialingDate.Value >= hoy.Date).ToList().Count;
                if (!nocturno || cantMark >= 4)
                {
                    var objTodaySchedule = (from wrd in cnx.workersscheduledetail
                        where wrd.v_PersonId == data.v_PersonId && wrd.i_IsDeleted == 0 && wrd.d_Date == hoy
                        select wrd).FirstOrDefault();

                    if (objTodaySchedule == null)
                    {
                        return "Colaborador: "+name+"\nUsted no tiene un horario establecido para el día de hoy, por favor comuníquese con el area correspondiente.";
                    }
                    var objTodayWorkerScheduleDto = workersscheduledetailAssembler.ToDTO(objTodaySchedule);
                    if (cantMark >= 4 )
                    {
                        cantMark -= 4;
                    }
                    data.v_ScheduleDetailId = objTodayWorkerScheduleDto.v_ScheduleDetailId;
                    var listMarks = (from mrk in cnx.markings
                        where mrk.v_PersonId == data.v_PersonId && mrk.d_DialingDate.Value >= hoy.Date
                        select new markingsDto
                        {
                            d_DialingDate = mrk.d_DialingDate,
                            v_TypeMarking = mrk.v_TypeMarking,
                        }).ToList();
                    state = GetDataTypeMarking(data.d_DialingDate.Value, objTodayWorkerScheduleDto, cantMark, listMarks);

                }
                else
                {
                    var objNightScheduleDto = workersscheduledetailAssembler.ToDTO(objNightSchedule);
                    data.v_ScheduleDetailId = objNightScheduleDto.v_ScheduleDetailId;
                    var listMarks = (from mrk in cnx.markings
                        where mrk.v_PersonId == data.v_PersonId && mrk.d_DialingDate.Value >= hoy.Date
                        select new markingsDto
                        {
                            d_DialingDate = mrk.d_DialingDate,
                            v_TypeMarking = mrk.v_TypeMarking,
                        }).ToList();
                    state = GetDataTypeMarking(data.d_DialingDate.Value, objNightScheduleDto, cantMark, listMarks);
                }

                if (!state.PerteneceDia)
                {
                    return "Colaborador: " + name + "\nUsted no tiene asignado un horario para este día: " + state.Dia + ", por favor comuniquese con el área correspondiente.";
                }
                if (!state.PermiteAntes)
                {
                    return "Colaborador: " + name + "\nUsted no puede marcar antes de su hora establecida: " + state.HoraEstablecida.ToString();
                }

                if (state.Tardanza)
                {
                    data.t_HoursAgainst = state.TiempoTardanza;
                }
                if (state.TypeMarking == "SALIDA")
                {
                    data.t_ExtraHours = state.SobreTiempo;
                }
                markings entity = markingsAssembler.ToEntity(data);

                entity.i_PaidOut = 0;
                entity.v_TypeMarking = state.TypeMarking;
                entity.i_IsDeleted = 0;
                entity.i_InsertUserId = 11;
                entity.d_InsertDate = DateTime.Now;
                cnx.AddTomarkings(entity);
                cnx.SaveChanges();

                return "Colaborador: " + name + "\nOK";

                #region OldVer
                //var objTodaySchedule = (from wrd in cnx.workersscheduledetail
                //                        where wrd.v_PersonId == data.v_PersonId && wrd.i_IsDeleted == 0 &&
                //                              wrd.d_Date == hoy
                //                        select wrd).FirstOrDefault();

                //if (objTodaySchedule == null)
                //{
                //    #region Old
                //    var objWorkerScheduleDto = workersscheduledetailAssembler.ToDTO(objTodaySchedule);
                //    DateTime ayer = now.AddDays(-1);//En el caso de que sea domingo y trabaje de amanecida.
                //    var objScheduleAyer = (from wrd in cnx.workersscheduledetail
                //                           where wrd.v_PersonId == data.v_PersonId && wrd.i_IsDeleted == 0 &&
                //                                 wrd.d_StartDate <= ayer.Date && wrd.d_EndDate >= ayer.Date
                //                           select wrd).FirstOrDefault();

                //    if (objScheduleAyer == null)
                //    {
                //        return "Usted no tiene un horario establecido para esta semana, por favor comuniquese con el area correspondiente.";
                //    }
                //    else if (objWorkerScheduleDto.t_SundayStart.Value >= TimeSpan.Parse("20:00"))
                //    {
                //        var objWorkerScheduleDtoDomingo = workersscheduledetailAssembler.ToDTO(objScheduleAyer);
                //        DateTime ayerServidor = data.d_DialingDate.Value.AddDays(-1);
                //        cantMark = cnx.markings.Where(x => x.v_PersonId == data.v_PersonId && x.d_DialingDate.Value >= ayer.Date && x.d_DialingDate.Value <= now.Date).ToList().Count;
                //        StateMarking state = GetTypeMarking(ayerServidor, objWorkerScheduleDto, objWorkerScheduleDtoDomingo, cantMark);
                //        if (!state.PerteneceDia)
                //        {
                //            return "Usted no tiene asignado un horario para este día: " + state.Dia + ", por favor comuniquese con el área correspondiente.";
                //        }
                //        if (!state.PermiteAntes)
                //        {
                //            return "Usted no puede marcar antes de su hora establecida: " + state.HoraEstablecida.ToString();
                //        }

                //        if (state.Tardanza)
                //        {
                //            data.t_HoursAgainst = state.TiempoTardanza;
                //        }
                //        if (state.TypeMarking == "SALIDA")
                //        {
                //            data.t_ExtraHours = state.SobreTiempo;
                //        }
                //        markings entity = markingsAssembler.ToEntity(data);
                //        entity.i_PaidOut = 0;
                //        entity.v_TypeMarking = state.TypeMarking;
                //        entity.i_IsDeleted = 0;
                //        entity.i_InsertUserId = 11;
                //        entity.d_InsertDate = DateTime.Now;
                //        cnx.AddTomarkings(entity);
                //        cnx.SaveChanges();


                //    }
                //    return "OK";
                //    #endregion

                //}
                //else
                //{

                //    var objWorkerScheduleDto = workersscheduledetailAssembler.ToDTO(objSchedule);
                //    if (objWorkerScheduleDto == null) objWorkerScheduleDto = new workersscheduledetailDto();

                //    DateTime ayer = now.AddDays(-1);//En el caso de que sea domingo y trabaje de amanecida.

                //    var objScheduleDomingo = (from wrd in cnx.workersscheduledetail
                //                              where wrd.v_PersonId == data.v_PersonId && wrd.i_IsDeleted == 0 &&
                //                                    wrd.d_StartDate <= ayer.Date && wrd.d_EndDate >= ayer.Date
                //                              select wrd).FirstOrDefault();
                //    if (objScheduleDomingo != null)
                //    {
                //        if (objScheduleDomingo.t_SundayStart != null)
                //        {
                //            if (objScheduleDomingo.t_SundayStart.Value >= TimeSpan.Parse("20:00"))
                //            {
                //                DateTime ayerDate = ayer.Date;
                //                cantMark += cnx.markings.Where(x => x.v_PersonId == data.v_PersonId && x.d_DialingDate.Value >= ayer.Date && x.d_DialingDate.Value <= now.Date).ToList().Count;
                //            }
                //        }
                //    }
                //    var objWorkerScheduleDtoDomingo = new workersscheduledetailDto();

                //    if (objScheduleDomingo != null) objWorkerScheduleDtoDomingo = workersscheduledetailAssembler.ToDTO(objScheduleDomingo);

                //    StateMarking state = GetTypeMarking(data.d_DialingDate.Value, objWorkerScheduleDto, objWorkerScheduleDtoDomingo, cantMark);


                //    if (!state.PerteneceDia)
                //    {
                //        return "Usted no tiene asignado un horario para este día: " + state.Dia + ", por favor comuniquese con el área correspondiente.";
                //    }
                //    if (!state.PermiteAntes)
                //    {
                //        return "Usted no puede marcar antes de su hora establecida: " + state.HoraEstablecida.ToString();
                //    }

                //    if (state.Tardanza)
                //    {
                //        data.t_HoursAgainst = state.TiempoTardanza;
                //    }
                //    if (state.TypeMarking == "SALIDA")
                //    {
                //        data.t_ExtraHours = state.SobreTiempo;
                //    }
                //    markings entity = markingsAssembler.ToEntity(data);
                //    entity.i_PaidOut = 0;
                //    entity.v_TypeMarking = state.TypeMarking;
                //    entity.i_IsDeleted = 0;
                //    entity.i_InsertUserId = 11;
                //    entity.d_InsertDate = DateTime.Now;
                //    cnx.AddTomarkings(entity);
                //    cnx.SaveChanges();

                //    return "OK";
                //}



                

                

                #endregion

                

            }
            catch (Exception e)
            {
                return null;
            }
        }

        public List<MarkingsCustom> GetMarkingsByPersonId(string month, string personId)
        {
            try
            {
                DateTime newHasta = DateTime.Now;
                DateTime newDesde = DateTime.Now;
                int i_month = DateTime.Now.Month;
                int i_year = DateTime.Now.Year;
                switch (month)
                {
                    case "ENERO":
                        newDesde = DateTime.Parse("26/12/" + (i_year - 1).ToString());
                        newHasta = DateTime.Parse("26/1/" + i_year.ToString());
                        break;
                    case "FEBRERO":
                        newDesde = DateTime.Parse("26/1/" + i_year.ToString());
                        newHasta = DateTime.Parse("26/2/" + i_year.ToString());
                        break;
                    case "MARZO":
                        newDesde = DateTime.Parse("26/2/" + i_year.ToString());
                        newHasta = DateTime.Parse("26/3/" + i_year.ToString());
                        break;
                    case "ABRIL":
                        newDesde = DateTime.Parse("26/3/" + i_year.ToString());
                        newHasta = DateTime.Parse("26/4/" + i_year.ToString());
                        break;
                    case "MAYO":
                        newDesde = DateTime.Parse("26/4/" + i_year.ToString());
                        newHasta = DateTime.Parse("26/5/" + i_year.ToString());
                        break;
                    case "JUNIO":
                        newDesde = DateTime.Parse("26/5/" + i_year.ToString());
                        newHasta = DateTime.Parse("26/6/" + i_year.ToString());
                        break;
                    case "JULIO":
                        newDesde = DateTime.Parse("26/6/" + i_year.ToString());
                        newHasta = DateTime.Parse("26/7/" + i_year.ToString());
                        break;
                    case "AGOSTO":
                        newDesde = DateTime.Parse("26/7/" + i_year.ToString());
                        newHasta = DateTime.Parse("26/8/" + i_year.ToString());
                        break;
                    case "SETIEMBRE":
                        newDesde = DateTime.Parse("26/8/" + i_year.ToString());
                        newHasta = DateTime.Parse("26/9/" + i_year.ToString());
                        break;
                    case "OCTUBRE":
                        newDesde = DateTime.Parse("26/9/" + i_year.ToString());
                        newHasta = DateTime.Parse("26/10/" + i_year.ToString());
                        break;
                    case "NOVIEMBRE":
                        newDesde = DateTime.Parse("26/10/" + i_year.ToString());
                        newHasta = DateTime.Parse("26/11/" + i_year.ToString());
                        break;
                    case "DICIEMBRE":
                        newDesde = DateTime.Parse("26/11/" + i_year.ToString());
                        newHasta = DateTime.Parse("26/12/" + i_year.ToString());
                        break;
                }


                var list = (from mar in cnx.markings
                    join per in cnx.person on mar.v_PersonId equals per.v_PersonId
                    join sys in cnx.systemuser on per.v_PersonId equals sys.v_PersonId into sys_Join
                    join wrd in cnx.workersscheduledetail on mar.v_ScheduleDetailId equals wrd.v_ScheduleDetailId 
                    from sys in sys_Join.DefaultIfEmpty()
                            where mar.v_PersonId == personId && mar.i_PaidOut == 0 && wrd.d_Date >= newDesde.Date && wrd.d_Date <= newHasta.Date
                    select new MarkingsCustom
                    {
                        t_StartHour = wrd.t_StartDate,
                        t_StartBreakHour = wrd.t_StartBreak,
                        t_EndBreakHour = wrd.t_EndBreak,
                        t_EndHour = wrd.t_EndDate,
                        v_ScheduleId = wrd.v_ScheduleDetailId,
                        MarkingId = mar.i_DialingId,
                        v_PersonId = per.v_PersonId,
                        v_UserName = sys.v_UserName,
                        d_Dialing = mar.d_DialingDate,
                        v_PersonName = per.v_FirstLastName + " " + per.v_SecondLastName + ", " + per.v_FirstName,
                        v_TypeMarking = mar.v_TypeMarking,
                        t_HoursAgainst = mar.t_HoursAgainst == null ? TimeSpan.Zero : mar.t_HoursAgainst,
                        t_ExtraHours = mar.t_ExtraHours == null ? TimeSpan.Zero : mar.t_ExtraHours,
                    }).ToList().GroupBy(x => x.MarkingId).Select(x => x.First()).ToList();

                foreach (var item in list)
                {
                    item.t_ExtraHours = TimeSpan.Parse(item.t_ExtraHours.Value.ToString(@"dd\.hh\:mm"));
                    item.t_HoursAgainst = TimeSpan.Parse(item.t_HoursAgainst.Value.ToString(@"dd\.hh\:mm"));
                }
                return list;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public List<MarkingsCustom> GetMarkingsForDay(DateTime desde, DateTime hasta, string dni)
        {
            try
            {
                DateTime newHasta = hasta.AddDays(1);
                DateTime ahora = DateTime.Now.Date.AddDays(-1);
                var list = (from mar in cnx.markings
                    join per in cnx.person on mar.v_PersonId equals per.v_PersonId
                    join sys in cnx.systemuser on per.v_PersonId equals sys.v_PersonId into sys_Join
                    from sys in sys_Join.DefaultIfEmpty()
                            where mar.d_DialingDate >= desde && mar.d_DialingDate <= newHasta && per.v_DocNumber == dni
                    select new MarkingsCustom
                    {
                        v_PersonId = per.v_PersonId,
                        v_UserName = sys.v_UserName,
                        d_Dialing = mar.d_DialingDate,
                        v_PersonName = per.v_FirstLastName + " " + per.v_SecondLastName + ", " + per.v_FirstName,
                        v_TypeMarking = mar.v_TypeMarking,
                        t_HoursAgainst = mar.t_HoursAgainst == null ? TimeSpan.Zero : mar.t_HoursAgainst,
                        t_ExtraHours = mar.t_ExtraHours == null ? TimeSpan.Zero : mar.t_ExtraHours,
                    }).OrderByDescending(x => x.d_Dialing).ToList();

                foreach (var item in list)
                {
                    item.t_ExtraHours = TimeSpan.Parse(item.t_ExtraHours.Value.ToString(@"dd\.hh\:mm"));
                    item.t_HoursAgainst = TimeSpan.Parse(item.t_HoursAgainst.Value.ToString(@"dd\.hh\:mm"));
                }
                return list;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public bool PaidWorker(string scheduleDetailId)
        {
            try
            {
                var listMarking = cnx.markings.Where(x => x.v_ScheduleDetailId == scheduleDetailId).ToList();
                foreach (var item in listMarking)
                {
                    item.i_PaidOut = 1;
                    cnx.SaveChanges();
                }

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public string NumeroDoc(string personId)
        {
            return cnx.person.Where(x => x.v_PersonId == personId).FirstOrDefault().v_DocNumber;
        }

        public decimal? PagoTrabajador(string personId)
        {
            try
            {
                var obj = cnx.professional.Where(x => x.v_PersonId == personId).FirstOrDefault();
                if (obj.r_MonthlyPayment != null)
                {
                    return obj.r_MonthlyPayment.Value;
                }
                else
                {
                    return (decimal?)930;
                }
            }
            catch (Exception e)
            {
                return (decimal?)0;
            }
        }

        public DataBoletaCustom GetDiasProgramados(string scheduleDetailId)
        {
            try
            {
                DataBoletaCustom data = new DataBoletaCustom();
                string schedulegroupId = cnx.workersscheduledetail.Where(x => x.v_ScheduleDetailId == scheduleDetailId && x.i_IsDeleted == 0).FirstOrDefault().v_ScheduleId;

                var list = cnx.workersscheduledetail.Where(x => x.v_ScheduleId == schedulegroupId && x.i_IsDeleted == 0).ToList();
                var objSchedule = cnx.workersschedule.Where(x => x.v_ScheduleId == schedulegroupId && x.i_IsDeleted == 0).FirstOrDefault();



                TimeSpan Rango1 = TimeSpan.Zero;
                TimeSpan Rango2 = TimeSpan.Zero;
                int cumplidos = 0;
                string _scheduleDetailId = "";
                foreach (var item in list)
                {

                    if (_scheduleDetailId == "" || _scheduleDetailId != item.v_ScheduleDetailId)
                    {
                        if (item.t_StartBreak != null)
                        {

                            if (item.t_StartDate > item.t_StartBreak)
                            {

                                var startTemp = item.t_StartBreak + item.t_EndDate;
                                var EndTemp = item.t_EndBreak + item.t_EndDate;
                                Rango1 += startTemp.Value - item.t_EndDate.Value;
                                Rango2 += item.t_StartDate.Value - EndTemp.Value;
                            }
                            else
                            {
                                Rango1 += item.t_StartBreak.Value - item.t_StartDate.Value;
                                Rango2 += item.t_EndDate.Value - item.t_EndBreak.Value;
                            }
                        }
                        else
                        {
                            if (item.t_StartDate > item.t_EndDate)
                            {
                                Rango1 += item.t_StartDate.Value - item.t_EndDate.Value;
                            }
                            else
                            {
                                Rango1 += item.t_EndDate.Value - item.t_StartDate.Value;
                            }
                        }
                       
                        var objMark = cnx.markings.Where(x => x.v_ScheduleDetailId == item.v_ScheduleDetailId).ToList();
                        if (objMark.Count > 0)
                        {
                            cumplidos++;
                        }
                        
                        _scheduleDetailId = item.v_ScheduleDetailId;
                    }
                }

                data.TotalHorasAsignadas = Rango1 + Rango2;
                data.v_MesPago = objSchedule.v_Mes;
                data.DiasProgramados = list.Count;
                data.DiasCompletados = cumplidos;

                return data;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public List<ChartWorkercustom> GetDataChart(string month, int top, int type)
        {
            DateTime newHasta = DateTime.Now;
            DateTime newDesde = DateTime.Now;
            int i_month = DateTime.Now.Month;
            int i_year = DateTime.Now.Year;
            
            #region Month
            switch (month)
            {
                case "ENERO":
                    newDesde = DateTime.Parse("01/01/" + (i_year).ToString());
                    newHasta = newDesde.AddMonths(1);
                    break;
                case "FEBRERO":
                    newDesde = DateTime.Parse("01/02/" + (i_year).ToString());
                    newHasta = newDesde.AddMonths(1);
                    break;
                case "MARZO":
                    newDesde = DateTime.Parse("01/03/" + (i_year).ToString());
                    newHasta = newDesde.AddMonths(1);
                    break;
                case "ABRIL":
                    newDesde = DateTime.Parse("01/04/" + (i_year).ToString());
                    newHasta = newDesde.AddMonths(1);
                    break;
                case "MAYO":
                    newDesde = DateTime.Parse("01/05/" + (i_year).ToString());
                    newHasta = newDesde.AddMonths(1);
                    break;
                case "JUNIO":
                    newDesde = DateTime.Parse("01/06/" + (i_year).ToString());
                    newHasta = newDesde.AddMonths(1);
                    break;
                case "JULIO":
                    newDesde = DateTime.Parse("01/07/" + (i_year).ToString());
                    newHasta = newDesde.AddMonths(1);
                    break;
                case "AGOSTO":
                    newDesde = DateTime.Parse("01/08/" + (i_year).ToString());
                    newHasta = newDesde.AddMonths(1);
                    break;
                case "SETIEMBRE":
                    newDesde = DateTime.Parse("01/09/" + (i_year).ToString());
                    newHasta = newDesde.AddMonths(1);
                    break;
                case "OCTUBRE":
                    newDesde = DateTime.Parse("01/10/" + (i_year).ToString());
                    newHasta = newDesde.AddMonths(1);
                    break;
                case "NOVIEMBRE":
                    newDesde = DateTime.Parse("01/11/" + (i_year).ToString());
                    newHasta = newDesde.AddMonths(1);
                    break;
                case "DICIEMBRE":
                    newDesde = DateTime.Parse("01/12/" + (i_year).ToString());
                    newHasta = newDesde.AddMonths(1);
                    break;
            }
            #endregion

            var entityMarking = new List<markingsDto>();
            if (type == 1 || type == 0)
	        {
                entityMarking = (from mar in cnx.markings
                    where mar.i_IsDeleted == 0 && mar.d_DialingDate.Value >= newDesde && mar.d_DialingDate.Value < newHasta
                          && mar.t_HoursAgainst > TimeSpan.Zero
                    select new markingsDto
                    {
                        v_PersonId = mar.v_PersonId,
                        t_HoursAgainst = mar.t_HoursAgainst,

                    }).ToList();
	        }
            else if (type == 2)
	        {
                entityMarking = (from mar in cnx.markings
                    where mar.i_IsDeleted == 0 && mar.d_DialingDate.Value >= newDesde && mar.d_DialingDate.Value < newHasta
                          && mar.t_ExtraHours > TimeSpan.Zero
                    select new markingsDto
                    {
                        v_PersonId = mar.v_PersonId,
                        t_HoursAgainst = mar.t_ExtraHours,

                    }).ToList();
	        }
            
            List<ChartWorkercustom> list = new List<ChartWorkercustom>();
            foreach (var item in entityMarking)
            {
                var find = list.Find(x => x.PersonId == item.v_PersonId);
                if (find == null)
                {
                    ChartWorkercustom obj = new ChartWorkercustom();
                    obj.Hours = item.t_HoursAgainst;
                    obj.PersonId = item.v_PersonId;
                    list.Add(obj);
                }
                else
                {
                    find.Hours += item.t_HoursAgainst;
                }
            }

            foreach (var item2 in list)
            {
                var entityPerson = cnx.person.Where(x => x.v_PersonId == item2.PersonId).FirstOrDefault();
                var objPerson = personAssembler.ToDTO(entityPerson);
                item2.Name = objPerson.v_FirstLastName + " " + objPerson.v_SecondLastName + ", " +
                             objPerson.v_FirstName;
            }


            if (type == 0)
	        {
                list = list.OrderBy(x => x.Hours).Take(top).ToList();
	        }
            else if (type == 1 || type == 2)
            {
                list = list.OrderByDescending(x => x.Hours).Take(top).ToList();    
            }

            return list;
        }

        public object GetMarkingsForDayDNI(DateTime desde, DateTime hasta)
        {
            try
            {
                string[] fechaInicio = desde.ToShortDateString().Split('/');
                string[] fechaFin = hasta.ToShortDateString().Split('/');
                List<MarkingsCustom> listMarkings = new List<MarkingsCustom>();
                ConexionSigesoft conexion = new ConexionSigesoft();
                conexion.opensigesoft();
                string cadena =
                    "select pp.v_PersonId, SU.v_UserName, MK.d_DialingDate, PP.v_FirstLastName + ' ' + PP.v_SecondLastName + ', ' + PP.v_FirstName, " +
                    "MK.v_TypeMarking, MK.t_HoursAgainst, MK.t_ExtraHours  from markings MK " +
                    "inner join person PP on MK.v_PersonId=PP.v_PersonId " +
                    "inner join systemuser SU on PP.v_PersonId=SU.v_PersonId " +
                    "where YEAR(MK.d_DialingDate) >= " + fechaInicio[2] + " and MONTH(MK.d_DialingDate) >= " + fechaInicio[1] + " and DAY(MK.d_DialingDate) >= " + fechaInicio[0] + " " +
                    "and YEAR(MK.d_DialingDate) <= " + fechaFin[2] + " and MONTH(MK.d_DialingDate) <= " + fechaFin[1] + " and DAY(MK.d_DialingDate) <= " + fechaFin[0] + " " +
                    "order by MK.d_DialingDate desc ";
                SqlCommand comando = new SqlCommand(cadena, conexion.conectarsigesoft);
                SqlDataReader lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    MarkingsCustom marking = new MarkingsCustom();
                    marking.v_PersonId = lector.GetValue(0).ToString();
                    marking.v_UserName = lector.GetValue(1).ToString();
                    marking.d_Dialing = lector.GetValue(2) as DateTime?;
                    marking.v_PersonName = lector.GetValue(3).ToString();
                    marking.v_TypeMarking = lector.GetValue(4).ToString();
                    marking.t_HoursAgainst = lector.GetValue(5) as TimeSpan?;
                    marking.t_ExtraHours = lector.GetValue(6) as TimeSpan?;
                    listMarkings.Add(marking);
                }

                lector.Close();
                conexion.closesigesoft();
                foreach (var item in listMarkings)
                {
                    if (item.t_ExtraHours != null)
                    {
                        item.t_ExtraHours = TimeSpan.Parse(item.t_ExtraHours.Value.ToString(@"dd\.hh\:mm"));
                    }

                    if (item.t_HoursAgainst != null)
                    {
                        item.t_HoursAgainst = TimeSpan.Parse(item.t_HoursAgainst.Value.ToString(@"dd\.hh\:mm"));
                    }
                    
                }

                return listMarkings;
                
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }



    
}
