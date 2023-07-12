using Sigesoft.Node.WinClient.BE.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sigesoft.Node.WinClient.BE;
using Sigesoft.Node.WinClient.DAL;

namespace Sigesoft.Node.WinClient.BLL
{
    public class VacationsBL
    {
        SigesoftEntitiesModel cnx = new SigesoftEntitiesModel();
        
        public List<VacationCustom> GetDataVacations()
        {
            try
            {
                var list = (from vac in cnx.vacations
                    join per in cnx.person on vac.v_PersonId equals per.v_PersonId
                    join prof in cnx.professional on per.v_PersonId equals  prof.v_PersonId
                    join dhy in cnx.datahierarchy on new { a = prof.i_ProfessionId.Value, b = 101} equals new { a = dhy.i_ItemId, b = dhy.i_GroupId }
                    where vac.i_IsProcessed == 0 && vac.i_IsDeleted == 0
                    select new VacationCustom
                    {

                        VacationId = vac.v_VacationId,
                        FullName = per.v_FirstLastName + " " + per.v_SecondLastName + " " + per.v_FirstName,
                        DocNumber = per.v_DocNumber,
                        ProfessionName = dhy.v_Value1,
                        StartVacation = vac.d_StartVacation,
                        EndVacation = vac.d_EndVacation
                    }).ToList();
                return list;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public vacationsDto GetDataVacationsById(string vacationId)
        {
            try
            {
                var entity = cnx.vacations.Where(x => x.v_VacationId == vacationId).FirstOrDefault();

                var obj = vacationsAssembler.ToDTO(entity);

                return obj;

            }
            catch (Exception e)
            {
                return null;
            }
        }

        public bool AddVacation(string personId, DateTime desde, DateTime hasta, int nodeId)
        {
            try
            {

                var obj = cnx.vacations.Where(x => x.v_PersonId == personId && x.i_IsDeleted == 0 && x.i_IsProcessed == 0).FirstOrDefault();
                if (obj == null)
                {
                    vacationsDto vac = new vacationsDto();
                    string newId = Common.Utils.GetNewId(nodeId, Utils.GetNextSecuentialId(nodeId, 51), "VA");
                    vac.v_VacationId = newId;
                    vac.i_IsProcessed = 0;
                    vac.i_IsDeleted = 0;
                    vac.v_PersonId = personId;
                    vac.d_StartVacation = desde.Date;
                    vac.d_EndVacation = hasta.Date;

                    vacations entity = vacationsAssembler.ToEntity(vac);
                    cnx.AddTovacations(entity);
                    cnx.SaveChanges();
                }
                else
                {
                    var dto = vacationsAssembler.ToDTO(obj);
                    bool ok = UpdateVacation(desde, hasta, dto.v_VacationId);
                    return ok;
                }

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool UpdateVacation(DateTime desde, DateTime hasta, string vacationId)
        {
            try
            {
                var obj = cnx.vacations.Where(x => x.v_VacationId == vacationId).FirstOrDefault();
                obj.d_StartVacation = desde.Date;
                obj.d_EndVacation = hasta.Date;
                cnx.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool DeleteVacation(string vacationId)
        {
            try
            {
                var obj = cnx.vacations.Where(x => x.v_VacationId == vacationId).FirstOrDefault();
                obj.i_IsDeleted = 1;
                cnx.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool GetVacation(string personId, DateTime date)
        {
            try
            {
                var obj = cnx.vacations.Where(x => x.v_PersonId == personId && x.i_IsDeleted == 0 && x.i_IsProcessed == 0 && x.d_EndVacation >= date && x.d_StartVacation <= date).FirstOrDefault();
                return obj != null;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool AutogenerarMarcaciones(string vacationId)
        {
            try
            {
                var entity = cnx.vacations.Where(x => x.v_VacationId == vacationId).FirstOrDefault();
                var obj = vacationsAssembler.ToDTO(entity);

                DateTime newEnd = obj.d_EndVacation.Value.AddDays(1);
                TimeSpan ts = newEnd - obj.d_StartVacation.Value;
                int totalDays = ts.Days;
                for (int i = 0; i < totalDays; i++)
                {
                    DateTime newDate = obj.d_StartVacation.Value.AddDays(i);
                    var entitySchedule = (from wrd in cnx.workersscheduledetail where wrd.d_Date == newDate && wrd.i_IsDeleted == 0 select wrd).FirstOrDefault();

                    if (entitySchedule != null)
                    {
                        var objSchedule = workersscheduledetailAssembler.ToDTO(entitySchedule);
                        int turno = objSchedule.t_StartDate.Value >= TimeSpan.Parse("20:00") ? 0 : 1;
                        DateTime newDateIngre = objSchedule.d_Date.Value + objSchedule.t_StartDate.Value;
                        markingsDto data = new markingsDto();
                        data.v_PersonId = objSchedule.v_PersonId;
                        data.d_DialingDate = newDateIngre;
                        data.v_ScheduleDetailId = objSchedule.v_ScheduleDetailId;
                        data.t_HoursAgainst = TimeSpan.Zero;
                        data.t_ExtraHours = TimeSpan.Zero;
                        data.i_PaidOut = 0;
                        data.v_TypeMarking = "INGRESO";
                        data.i_IsDeleted = 0;
                        data.i_InsertUserId = 11;
                        data.d_InsertDate = DateTime.Now;

                        var objMarking = cnx.markings.Where(x => x.d_DialingDate == data.d_DialingDate && x.v_PersonId == data.v_PersonId).FirstOrDefault();
                        if (objMarking == null)
                        {
                            markings entity1 = markingsAssembler.ToEntity(data);
                            cnx.AddTomarkings(entity1);
                            cnx.SaveChanges();
                        }
                       

                        if (objSchedule.t_StartBreak != null && objSchedule.t_StartBreak.Value != TimeSpan.Zero)
                        {
                            DateTime newDateRefri = objSchedule.d_Date.Value + objSchedule.t_StartBreak.Value;
                            DateTime newDateFinRefri = objSchedule.d_Date.Value + objSchedule.t_EndBreak.Value;
                            if (turno == 0)//Nocturno
                            {
                                newDateRefri = objSchedule.d_Date.Value.AddDays(1) + objSchedule.t_StartBreak.Value;
                                newDateFinRefri = objSchedule.d_Date.Value.AddDays(1) + objSchedule.t_EndBreak.Value;
                            }
                            markingsDto data2 = new markingsDto();
                            data2.v_PersonId = objSchedule.v_PersonId;
                            data2.d_DialingDate = newDateRefri;
                            data2.v_ScheduleDetailId = objSchedule.v_ScheduleDetailId;
                            data2.t_HoursAgainst = TimeSpan.Zero;
                            data2.t_ExtraHours = TimeSpan.Zero;
                            data2.i_PaidOut = 0;
                            data2.v_TypeMarking = "REFRIGERIO";
                            data2.i_IsDeleted = 0;
                            data2.i_InsertUserId = 11;
                            data2.d_InsertDate = DateTime.Now;

                            var objMarking2 = cnx.markings.Where(x => x.d_DialingDate == data2.d_DialingDate && x.v_PersonId == data2.v_PersonId).FirstOrDefault();
                            if (objMarking2 == null)
                            {
                                markings entity2 = markingsAssembler.ToEntity(data2);
                                cnx.AddTomarkings(entity2);
                                cnx.SaveChanges();
                            }
                            


                            markingsDto data3 = new markingsDto();
                            data3.v_PersonId = objSchedule.v_PersonId;
                            data3.d_DialingDate = newDateFinRefri;
                            data3.v_ScheduleDetailId = objSchedule.v_ScheduleDetailId;
                            data3.t_HoursAgainst = TimeSpan.Zero;
                            data3.t_ExtraHours = TimeSpan.Zero;
                            data3.i_PaidOut = 0;
                            data3.v_TypeMarking = "RETORNO REFRIGERIO";
                            data3.i_IsDeleted = 0;
                            data3.i_InsertUserId = 11;
                            data3.d_InsertDate = DateTime.Now;

                            var objMarking3 = cnx.markings.Where(x => x.d_DialingDate == data3.d_DialingDate && x.v_PersonId == data3.v_PersonId).FirstOrDefault();
                            if (objMarking3 == null)
                            {
                                markings entity3 = markingsAssembler.ToEntity(data3);
                                cnx.AddTomarkings(entity3);
                                cnx.SaveChanges();
                            }
                            
                        }

                        DateTime newDateSalida = objSchedule.d_Date.Value + objSchedule.t_EndDate.Value;
                        if (turno == 0)//Nocturno
                        {
                            newDateSalida = objSchedule.d_Date.Value.AddDays(1) + objSchedule.t_EndDate.Value;
                        }

                        markingsDto data4 = new markingsDto();
                        data4.v_PersonId = objSchedule.v_PersonId;
                        data4.d_DialingDate = newDateSalida;
                        data4.v_ScheduleDetailId = objSchedule.v_ScheduleDetailId;
                        data4.t_HoursAgainst = TimeSpan.Zero;
                        data4.t_ExtraHours = TimeSpan.Zero;
                        data4.i_PaidOut = 0;
                        data4.v_TypeMarking = "SALIDA";
                        data4.i_IsDeleted = 0;
                        data4.i_InsertUserId = 11;
                        data4.d_InsertDate = DateTime.Now;

                        var objMarking4 = cnx.markings.Where(x => x.d_DialingDate == data4.d_DialingDate && x.v_PersonId == data4.v_PersonId).FirstOrDefault();
                        if (objMarking4 == null)
                        {
                            markings entity4 = markingsAssembler.ToEntity(data4);
                            cnx.AddTomarkings(entity4);
                            cnx.SaveChanges();
                        }
                        

                        
                    }

                }

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            
        }

        public bool ProcessedVacation(string vacationId)
        {
            try
            {
                var obj = cnx.vacations.Where(x => x.v_VacationId == vacationId).FirstOrDefault();
                obj.i_IsProcessed = 1;
                cnx.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
