﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using Sigesoft.Node.WinClient.BE;
using Sigesoft.Node.WinClient.BE.Custom;

namespace NetPdf
{
    public class AtencionIntegral
    {
        private static void RunFile(string filePDF)
        {
            Process proceso = Process.Start(filePDF);
            proceso.WaitForExit();
            proceso.Close();
        }

        public static void CreateAtencionIntegral(string filePDF,
            DatosDoctorMedicina medico,
            PacientList datosPac,
            organizationDto infoEmpresaPropietaria,
            List<ServiceComponentList> exams,
            List<DiagnosticRepositoryList> Diagnosticos, 
            List<recetadespachoDto> medicina,
            MedicoTratanteAtenciones medicoo,
            UsuarioGrabo DatosGrabo, List<Categoria> DataSource, 
            string edadActual)
        {
            Document document = new Document(PageSize.A4, 30f, 30f, 45f, 41f);

            
            document.SetPageSize(iTextSharp.text.PageSize.A4);

            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(filePDF, FileMode.Create));
            pdfPage page = new pdfPage();
            writer.PageEvent = page;
            document.Open();

            #region Declaration Tables
            var subTitleBackGroundColor = new BaseColor(System.Drawing.Color.Gray);
            string include = string.Empty;
            List<PdfPCell> cells = null;
            List<PdfPCell> cells2 = null;
            float[] columnWidths = null;
            string[] columnValues = null;
            string[] columnHeaders = null;
            PdfPTable header2 = new PdfPTable(6);
            header2.HorizontalAlignment = Element.ALIGN_CENTER;
            header2.WidthPercentage = 100;
            float[] widths1 = new float[] { 16.6f, 18.6f, 16.6f, 16.6f, 16.6f, 16.6f };
            header2.SetWidths(widths1);
            PdfPTable companyData = new PdfPTable(6);
            companyData.HorizontalAlignment = Element.ALIGN_CENTER;
            companyData.WidthPercentage = 100;
            float[] widthscolumnsCompanyData = new float[] { 16.6f, 16.6f, 16.6f, 16.6f, 16.6f, 16.6f };
            companyData.SetWidths(widthscolumnsCompanyData);
            PdfPTable filiationWorker = new PdfPTable(4);
            PdfPTable table = null;
            PdfPCell cell = null;
            PdfPCell cell2 = null;
            document.Add(new Paragraph("\r\n"));
            #endregion

            #region Fonts
            Font fontTitle1 = FontFactory.GetFont("Calibri", 10, iTextSharp.text.Font.BOLD, new BaseColor(System.Drawing.Color.Black));
            Font fontTitle1_1 = FontFactory.GetFont("Calibri", 8, iTextSharp.text.Font.NORMAL, new BaseColor(System.Drawing.Color.Black));
            Font fontTitle2 = FontFactory.GetFont("Calibri", 7, iTextSharp.text.Font.NORMAL, new BaseColor(System.Drawing.Color.Black));
            Font fontTitleTable = FontFactory.GetFont("Calibri", 6, iTextSharp.text.Font.BOLD, new BaseColor(System.Drawing.Color.Black));
            Font fontTitleTableNegro = FontFactory.GetFont("Calibri", 6, iTextSharp.text.Font.BOLD, new BaseColor(System.Drawing.Color.Black));
            Font fontSubTitle = FontFactory.GetFont("Calibri", 6, iTextSharp.text.Font.BOLD, new BaseColor(System.Drawing.Color.White));
            Font fontSubTitleNegroNegrita = FontFactory.GetFont("Calibri", 6, iTextSharp.text.Font.BOLD, new BaseColor(System.Drawing.Color.Black));

            Font fontColumnValue = FontFactory.GetFont("Calibri", 7, iTextSharp.text.Font.NORMAL, new BaseColor(System.Drawing.Color.Black));
            Font fontColumnValueBold = FontFactory.GetFont("Calibri", 7, iTextSharp.text.Font.BOLD, new BaseColor(System.Drawing.Color.Black));
            Font fontColumnValueBold1 = FontFactory.GetFont("Calibri", 7, iTextSharp.text.Font.BOLD, new BaseColor(System.Drawing.Color.White));

            Font fontColumnValueApendice = FontFactory.GetFont("Calibri", 5, iTextSharp.text.Font.BOLD, new BaseColor(System.Drawing.Color.Black));
            #endregion

            #region TÍTULO

            cells = new List<PdfPCell>();

            if (infoEmpresaPropietaria.b_Image != null)
            {
                iTextSharp.text.Image imagenEmpresa = iTextSharp.text.Image.GetInstance(HandlingItextSharp.GetImage(infoEmpresaPropietaria.b_Image));
                imagenEmpresa.ScalePercent(38);
                imagenEmpresa.SetAbsolutePosition(40, 765);
                document.Add(imagenEmpresa);
            }
            //iTextSharp.text.Image imagenMinsa = iTextSharp.text.Image.GetInstance("C:/Banner/Minsa.png");
            //imagenMinsa.ScalePercent(10);
            //imagenMinsa.SetAbsolutePosition(400, 785);
            //document.Add(imagenMinsa);
            string[] servicio = datosPac.FechaServicio.ToString().Split(' ');

            var cellsTit = new List<PdfPCell>()
            { 
                new PdfPCell(new Phrase(servicio[0] + "               ", fontTitle1_1)) {HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT, VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE, FixedHeight = 12f},

                new PdfPCell(new Phrase("HISTORIA CLÍNICA", fontTitle1)) {HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER, VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE, FixedHeight = 20f},
            };
            columnWidths = new float[] { 100f };
            table = HandlingItextSharp.GenerateTableFromCells(cellsTit, columnWidths, PdfPCell.NO_BORDER, null, fontTitleTable);
            document.Add(table);
            #endregion

            #region Valores
            var tamaño_celda = 13f;
            #endregion

            #region Datos del Servicio

            string fechaInforme = DateTime.Now.ToString().Split(' ')[0];
            string[] fechaNac = datosPac.d_Birthdate.ToString().Split(' ');
            string med = "";
            if (medicoo != null)
            {
                med = medicoo.Nombre;
            }
            else
            {
                med = "CLINICA SAN MARCOS";
            }

            //Antropometria
            ServiceComponentList antro = exams.Find(p => p.v_ComponentId == Sigesoft.Common.Constants.ANTROPOMETRIA_ID);
            string peso = "", peso_unidad = "", talla = "", talla_unidad = "", imc = "", imc_unidad = "";
            if (antro != null)
            {
                peso =  antro.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.ANTROPOMETRIA_PESO_ID) == null ? "" : antro.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.ANTROPOMETRIA_PESO_ID).v_Value1;
                peso_unidad = antro.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.ANTROPOMETRIA_PESO_ID) == null ? "" : antro.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.ANTROPOMETRIA_PESO_ID).v_MeasurementUnitName;
                talla = antro.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.ANTROPOMETRIA_TALLA_ID) == null ? "" : antro.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.ANTROPOMETRIA_TALLA_ID).v_Value1;
                talla_unidad = antro.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.ANTROPOMETRIA_TALLA_ID) == null ? "" : antro.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.ANTROPOMETRIA_TALLA_ID).v_MeasurementUnitName;
                imc = antro.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.ANTROPOMETRIA_IMC_ID) == null ? "" : antro.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.ANTROPOMETRIA_IMC_ID).v_Value1;
                imc_unidad = antro.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.ANTROPOMETRIA_IMC_ID) == null ? "" : antro.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.ANTROPOMETRIA_IMC_ID).v_MeasurementUnitName;

            }
            else
            {
                peso = "";
                peso_unidad = "";
                talla = "";
                talla_unidad = "";
                imc = "";
                imc_unidad = "";
            }

            ServiceComponentList funcVit = exams.Find(p => p.v_ComponentId == Sigesoft.Common.Constants.FUNCIONES_VITALES_ID);
            string temp = "", temp_unidad = "", pres_Sist = "", pres_Diast = "", pres_Diast_unidad = "", frecCard = "", frecCard_unidad = "", frecResp = "", frecResp_unidad = "", spo2 = "", spo2_unidad = "";
            if (funcVit != null)
            {
                temp = funcVit.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.FUNCIONES_VITALES_TEMPERATURA_ID) == null ? "" : funcVit.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.FUNCIONES_VITALES_TEMPERATURA_ID).v_Value1;
                temp_unidad = funcVit.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.FUNCIONES_VITALES_TEMPERATURA_ID) == null ? "" : funcVit.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.FUNCIONES_VITALES_TEMPERATURA_ID).v_MeasurementUnitName;
                pres_Sist = funcVit.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.FUNCIONES_VITALES_PAS_ID) == null ? "" : funcVit.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.FUNCIONES_VITALES_PAS_ID).v_Value1;
                pres_Diast = funcVit.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.FUNCIONES_VITALES_PAD_ID) == null ? "" : funcVit.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.FUNCIONES_VITALES_PAD_ID).v_Value1;
                pres_Diast_unidad = funcVit.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.FUNCIONES_VITALES_PAD_ID) == null ? "" : funcVit.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.FUNCIONES_VITALES_PAD_ID).v_MeasurementUnitName;
                frecCard = funcVit.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.FUNCIONES_VITALES_FREC_CARDIACA_ID) == null ? "" : funcVit.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.FUNCIONES_VITALES_FREC_CARDIACA_ID).v_Value1;
                frecCard_unidad = funcVit.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.FUNCIONES_VITALES_FREC_CARDIACA_ID) == null ? "" : funcVit.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.FUNCIONES_VITALES_FREC_CARDIACA_ID).v_MeasurementUnitName;
                frecResp = funcVit.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.FUNCIONES_VITALES_FREC_RESPIRATORIA_ID) == null ? "" : funcVit.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.FUNCIONES_VITALES_FREC_RESPIRATORIA_ID).v_Value1;
                frecResp_unidad = funcVit.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.FUNCIONES_VITALES_FREC_RESPIRATORIA_ID) == null ? "" : funcVit.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.FUNCIONES_VITALES_FREC_RESPIRATORIA_ID).v_MeasurementUnitName;
                spo2 = funcVit.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.FUNCIONES_VITALES_SAT_O2_ID) == null ? "" : funcVit.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.FUNCIONES_VITALES_SAT_O2_ID).v_Value1;
                spo2_unidad = funcVit.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.FUNCIONES_VITALES_SAT_O2_ID) == null ? "" : funcVit.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.FUNCIONES_VITALES_SAT_O2_ID).v_MeasurementUnitName;

            }
            else
            {
                temp = "";
                temp_unidad = "";
                pres_Diast = "";
                pres_Diast_unidad = "";
                pres_Sist = "";
                frecCard = "";
                frecCard_unidad = "";
                frecResp = "";
                frecResp_unidad = "";
                spo2 = "";
                spo2_unidad = "";
            }

            ServiceComponentList atenInte = exams.Find(p => p.v_ComponentId == Sigesoft.Common.Constants.ATENCION_INTEGRAL_ID);

            cellsTit = new List<PdfPCell>()
                { 
                    new PdfPCell(new Phrase("CODIGO DE ATENCIÓN:", fontColumnValueBold)) { Colspan=4, HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT, VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE, MinimumHeight=15f, UseVariableBorders=true, BorderColorLeft=BaseColor.BLACK,  BorderColorRight=BaseColor.BLACK,  BorderColorBottom=BaseColor.BLACK, BorderColorTop=BaseColor.BLACK},
                    new PdfPCell(new Phrase(datosPac.v_IdService, fontColumnValue)) { Colspan = 6, HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT, VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE,FixedHeight = 15f, UseVariableBorders=true, BorderColorLeft=BaseColor.BLACK,  BorderColorRight=BaseColor.BLACK,  BorderColorBottom=BaseColor.BLACK, BorderColorTop=BaseColor.BLACK },    
                    new PdfPCell(new Phrase("MÉDICO TRATANTE:  ", fontColumnValueBold)) { Colspan=4, HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT, VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE, MinimumHeight=15f, UseVariableBorders=true, BorderColorLeft=BaseColor.BLACK,  BorderColorRight=BaseColor.BLACK,  BorderColorBottom=BaseColor.BLACK, BorderColorTop=BaseColor.BLACK},
                    new PdfPCell(new Phrase(med, fontColumnValue)) { Colspan = 6,HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT, VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE, FixedHeight = 15f, UseVariableBorders=true, BorderColorLeft=BaseColor.BLACK,  BorderColorRight=BaseColor.BLACK,  BorderColorBottom=BaseColor.BLACK, BorderColorTop=BaseColor.BLACK },    

                    new PdfPCell(new Phrase("PACIENTE:", fontColumnValueBold)) { Colspan=2, HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT, VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE, MinimumHeight=15f,UseVariableBorders=true, BorderColorLeft=BaseColor.BLACK,  BorderColorRight=BaseColor.WHITE,  BorderColorBottom=BaseColor.BLACK, BorderColorTop=BaseColor.BLACK},
                    new PdfPCell(new Phrase(datosPac.v_FirstLastName + " " + datosPac.v_SecondLastName + " " + datosPac.v_FirstName, fontColumnValue)) { Colspan = 8, HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT, VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE, FixedHeight = tamaño_celda , UseVariableBorders=true, BorderColorLeft=BaseColor.WHITE,  BorderColorRight=BaseColor.WHITE,  BorderColorBottom=BaseColor.BLACK, BorderColorTop=BaseColor.BLACK},    
                    new PdfPCell(new Phrase("FECHA IMPRESIÓN:", fontColumnValueBold)) { Colspan=5, HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT, VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE, MinimumHeight=15f, UseVariableBorders=true, BorderColorLeft=BaseColor.WHITE,  BorderColorRight=BaseColor.WHITE,  BorderColorBottom=BaseColor.BLACK, BorderColorTop=BaseColor.BLACK},
                    new PdfPCell(new Phrase(fechaInforme, fontColumnValue)) { Colspan = 5, HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT, VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE, FixedHeight = tamaño_celda, UseVariableBorders=true, BorderColorLeft=BaseColor.WHITE,  BorderColorRight=BaseColor.BLACK,  BorderColorBottom=BaseColor.BLACK, BorderColorTop=BaseColor.BLACK },    

                    new PdfPCell(new Phrase("EDAD:", fontColumnValueBold)) { Colspan=2, HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT, VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE, MinimumHeight=15f, UseVariableBorders=true, BorderColorLeft=BaseColor.BLACK,  BorderColorRight=BaseColor.WHITE,  BorderColorBottom=BaseColor.WHITE, BorderColorTop=BaseColor.BLACK},
                    new PdfPCell(new Phrase(datosPac.Edad.ToString() + " Años", fontColumnValue)) { Colspan = 3, HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT, VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE, FixedHeight = tamaño_celda, UseVariableBorders=true, BorderColorLeft=BaseColor.WHITE,  BorderColorRight=BaseColor.WHITE,  BorderColorBottom=BaseColor.WHITE, BorderColorTop=BaseColor.BLACK },    
                    new PdfPCell(new Phrase("SEXO:", fontColumnValueBold)) { Colspan=2, HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT, VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE, MinimumHeight=15f, UseVariableBorders=true, BorderColorLeft=BaseColor.WHITE,  BorderColorRight=BaseColor.WHITE,  BorderColorBottom=BaseColor.WHITE, BorderColorTop=BaseColor.BLACK},
                    new PdfPCell(new Phrase(datosPac.Genero, fontColumnValue)) { Colspan = 3, HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT, VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE, FixedHeight = tamaño_celda , UseVariableBorders=true, BorderColorLeft=BaseColor.WHITE,  BorderColorRight=BaseColor.WHITE,  BorderColorBottom=BaseColor.WHITE, BorderColorTop=BaseColor.BLACK},    
                    new PdfPCell(new Phrase("EST. CIVIL:", fontColumnValueBold)) { Colspan=2, HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT, VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE, MinimumHeight=15f, UseVariableBorders=true, BorderColorLeft=BaseColor.WHITE,  BorderColorRight=BaseColor.WHITE,  BorderColorBottom=BaseColor.WHITE, BorderColorTop=BaseColor.BLACK},
                    new PdfPCell(new Phrase(datosPac.v_MaritalStatus, fontColumnValue)) { Colspan = 3, HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT, VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE, FixedHeight = tamaño_celda , UseVariableBorders=true, BorderColorLeft=BaseColor.WHITE,  BorderColorRight=BaseColor.WHITE,  BorderColorBottom=BaseColor.WHITE, BorderColorTop=BaseColor.BLACK},    
                    new PdfPCell(new Phrase("N° Tel.:", fontColumnValueBold)) { Colspan=2, HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT, VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE, MinimumHeight=15f, UseVariableBorders=true, BorderColorLeft=BaseColor.WHITE,  BorderColorRight=BaseColor.WHITE,  BorderColorBottom=BaseColor.WHITE, BorderColorTop=BaseColor.BLACK},
                    new PdfPCell(new Phrase(datosPac.v_TelephoneNumber, fontColumnValue)) { Colspan = 3, HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT, VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE, FixedHeight = tamaño_celda , UseVariableBorders=true, BorderColorLeft=BaseColor.WHITE,  BorderColorRight=BaseColor.BLACK,  BorderColorBottom=BaseColor.WHITE, BorderColorTop=BaseColor.BLACK},    

                    new PdfPCell(new Phrase("Fecha Nacimiento:", fontColumnValueBold)) { Colspan=3, HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT, VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE, MinimumHeight=15f, UseVariableBorders=true, BorderColorLeft=BaseColor.BLACK,  BorderColorRight=BaseColor.WHITE,  BorderColorBottom=BaseColor.WHITE, BorderColorTop=BaseColor.WHITE},
                    new PdfPCell(new Phrase(fechaNac[0], fontColumnValue)) { Colspan = 2, HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT, VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE, FixedHeight = tamaño_celda, UseVariableBorders=true, BorderColorLeft=BaseColor.WHITE,  BorderColorRight=BaseColor.WHITE,  BorderColorBottom=BaseColor.WHITE, BorderColorTop=BaseColor.WHITE },    
                    new PdfPCell(new Phrase("DNI:", fontColumnValueBold)) { Colspan=1, HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT, VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE, MinimumHeight=15f, UseVariableBorders=true, BorderColorLeft=BaseColor.WHITE,  BorderColorRight=BaseColor.WHITE,  BorderColorBottom=BaseColor.WHITE, BorderColorTop=BaseColor.WHITE},
                    new PdfPCell(new Phrase(datosPac.v_DocNumber, fontColumnValue)) { Colspan = 3, HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT, VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE, FixedHeight = tamaño_celda, UseVariableBorders=true, BorderColorLeft=BaseColor.WHITE,  BorderColorRight=BaseColor.WHITE,  BorderColorBottom=BaseColor.WHITE, BorderColorTop=BaseColor.WHITE },    
                    new PdfPCell(new Phrase("N° HIST C:", fontColumnValueBold)) { Colspan=2, HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT, VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE, MinimumHeight=15f, UseVariableBorders=true, BorderColorLeft=BaseColor.WHITE,  BorderColorRight=BaseColor.WHITE,  BorderColorBottom=BaseColor.WHITE, BorderColorTop=BaseColor.WHITE},
                    new PdfPCell(new Phrase(datosPac.N_Informe, fontColumnValue)) { Colspan = 3, HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT, VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE, FixedHeight = tamaño_celda, UseVariableBorders=true, BorderColorLeft=BaseColor.WHITE,  BorderColorRight=BaseColor.WHITE,  BorderColorBottom=BaseColor.WHITE, BorderColorTop=BaseColor.WHITE },    
                    new PdfPCell(new Phrase("NACIONALIDAD:", fontColumnValueBold)) { Colspan=3, HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT, VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE, MinimumHeight=15f, UseVariableBorders=true, BorderColorLeft=BaseColor.WHITE,  BorderColorRight=BaseColor.WHITE,  BorderColorBottom=BaseColor.WHITE, BorderColorTop=BaseColor.WHITE},
                    new PdfPCell(new Phrase(datosPac.v_Nacionalidad, fontColumnValue)) { Colspan = 3, HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT, VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE, FixedHeight = tamaño_celda, UseVariableBorders=true, BorderColorLeft=BaseColor.WHITE,  BorderColorRight=BaseColor.BLACK,  BorderColorBottom=BaseColor.WHITE, BorderColorTop=BaseColor.WHITE },    

                    new PdfPCell(new Phrase("RESIDENCIA ACTUAL:", fontColumnValueBold)) { Colspan=4, HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT, VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE, MinimumHeight=15f, UseVariableBorders=true, BorderColorLeft=BaseColor.BLACK,  BorderColorRight=BaseColor.WHITE,  BorderColorBottom=BaseColor.WHITE, BorderColorTop=BaseColor.WHITE},
                    new PdfPCell(new Phrase(datosPac.v_AdressLocation, fontColumnValue)) { Colspan = 6, HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT, VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE, FixedHeight = tamaño_celda, UseVariableBorders=true, BorderColorLeft=BaseColor.WHITE,  BorderColorRight=BaseColor.WHITE,  BorderColorBottom=BaseColor.WHITE, BorderColorTop=BaseColor.WHITE },    
                    new PdfPCell(new Phrase("RESIDENCIA ANTERIOR:", fontColumnValueBold)) { Colspan=4, HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT, VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE, MinimumHeight=15f, UseVariableBorders=true, BorderColorLeft=BaseColor.WHITE,  BorderColorRight=BaseColor.WHITE,  BorderColorBottom=BaseColor.WHITE, BorderColorTop=BaseColor.WHITE},
                    new PdfPCell(new Phrase(datosPac.v_ResidenciaAnterior==""?"- - -":datosPac.v_ResidenciaAnterior==null?"- - -":datosPac.v_ResidenciaAnterior, fontColumnValue)) { Colspan = 6, HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT, VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE, FixedHeight = tamaño_celda , UseVariableBorders=true, BorderColorLeft=BaseColor.WHITE,  BorderColorRight=BaseColor.BLACK,  BorderColorBottom=BaseColor.WHITE, BorderColorTop=BaseColor.WHITE},    

                    new PdfPCell(new Phrase("G. DE INSTRUCCIÓN:", fontColumnValueBold)) { Colspan=3, HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT, VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE, MinimumHeight=15f, UseVariableBorders=true, BorderColorLeft=BaseColor.BLACK,  BorderColorRight=BaseColor.WHITE,  BorderColorBottom=BaseColor.BLACK, BorderColorTop=BaseColor.WHITE},
                    new PdfPCell(new Phrase(datosPac.GradoInstruccion, fontColumnValue)) { Colspan = 3, HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT, VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE, FixedHeight = tamaño_celda, UseVariableBorders=true, BorderColorLeft=BaseColor.WHITE,  BorderColorRight=BaseColor.WHITE,  BorderColorBottom=BaseColor.BLACK, BorderColorTop=BaseColor.WHITE },    
                    new PdfPCell(new Phrase("RELIGIÓN:", fontColumnValueBold)) { Colspan=2, HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT, VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE, MinimumHeight=15f, UseVariableBorders=true, BorderColorLeft=BaseColor.WHITE,  BorderColorRight=BaseColor.WHITE,  BorderColorBottom=BaseColor.BLACK, BorderColorTop=BaseColor.WHITE},
                    new PdfPCell(new Phrase(datosPac.v_Religion==""?"- - -":datosPac.v_Religion==null?"- - -":datosPac.v_Religion, fontColumnValue)) { Colspan = 4, HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT, VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE, FixedHeight = tamaño_celda, UseVariableBorders=true, BorderColorLeft=BaseColor.WHITE,  BorderColorRight=BaseColor.WHITE,  BorderColorBottom=BaseColor.BLACK, BorderColorTop=BaseColor.WHITE },    
                    new PdfPCell(new Phrase("OCUPACIÓN:", fontColumnValueBold)) { Colspan=2, HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT, VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE, MinimumHeight=15f, UseVariableBorders=true, BorderColorLeft=BaseColor.WHITE,  BorderColorRight=BaseColor.WHITE,  BorderColorBottom=BaseColor.BLACK, BorderColorTop=BaseColor.WHITE},
                    new PdfPCell(new Phrase(datosPac.v_CurrentOccupation==""?"- - -":datosPac.v_CurrentOccupation==null?"- - -":datosPac.v_CurrentOccupation, fontColumnValue)) { Colspan = 6, HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT, VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE, FixedHeight = tamaño_celda, UseVariableBorders=true, BorderColorLeft=BaseColor.WHITE,  BorderColorRight=BaseColor.BLACK,  BorderColorBottom=BaseColor.BLACK, BorderColorTop=BaseColor.WHITE },    
                   
                    new PdfPCell(new Phrase("", fontColumnValue)) {Colspan = 20, HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT,VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE, UseVariableBorders=true, BorderColorLeft=BaseColor.WHITE,  BorderColorRight=BaseColor.WHITE,  BorderColorBottom=BaseColor.BLACK, BorderColorTop=BaseColor.BLACK, MinimumHeight=4f },

                     new PdfPCell(new Phrase("Talla:", fontColumnValueBold)) {Colspan=2, HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT, VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE, MinimumHeight=18f},
                    new PdfPCell(new Phrase(talla + " "+ talla_unidad, fontColumnValue)) {Colspan=3, HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER, VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE, MinimumHeight=18f},
                    new PdfPCell(new Phrase("Peso:", fontColumnValueBold)) {Colspan=2, HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT, VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE, MinimumHeight=18f},
                    new PdfPCell(new Phrase(peso + " " + peso_unidad, fontColumnValue)) { Colspan=3, HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER, VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE , MinimumHeight=18f},
                    new PdfPCell(new Phrase("FR:", fontColumnValueBold)) {Colspan=1, HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT, VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE , MinimumHeight=18f},
                    new PdfPCell(new Phrase(frecResp + " " + frecResp_unidad, fontColumnValue)) {Colspan=4, HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER, VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE, MinimumHeight=18f},
                    new PdfPCell(new Phrase("IMC", fontColumnValueBold)) {Colspan=1, HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT, VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE, MinimumHeight=18f },
                    new PdfPCell(new Phrase(imc + " " + imc_unidad, fontColumnValue)) {Colspan=4, HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER, VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE, MinimumHeight=18f },

                    new PdfPCell(new Phrase("T°:", fontColumnValueBold)) {Colspan=2, HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT, VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE, MinimumHeight=18f },
                    new PdfPCell(new Phrase(temp + " " + temp_unidad, fontColumnValue)) {Colspan=3,HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER, VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE, MinimumHeight=18f },
                    new PdfPCell(new Phrase("PA:", fontColumnValueBold)) {Colspan=2, HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT, VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE, MinimumHeight=18f },
                    new PdfPCell(new Phrase(pres_Sist + " / " + pres_Diast + " " + pres_Diast_unidad, fontColumnValue)) { Colspan=4, HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER, VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE, MinimumHeight=18f },
                    new PdfPCell(new Phrase("FC", fontColumnValueBold)) {Colspan=1, HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT, VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE, MinimumHeight=18f },
                    new PdfPCell(new Phrase(frecCard + " " + frecCard_unidad, fontColumnValue)) {Colspan=3, HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER, VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE, MinimumHeight=18f},
                    new PdfPCell(new Phrase("SpO2", fontColumnValueBold)) {Colspan=1, HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT, VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE, MinimumHeight=18f },
                    new PdfPCell(new Phrase(spo2 + " " + spo2_unidad, fontColumnValue)) {Colspan=4, HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER, VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE, MinimumHeight=18f },

                };

            columnWidths = new float[] { 5f, 5f, 5f, 5f, 5f, 5f, 5f, 5f, 5f, 5f, 5f, 5f, 5f, 5f, 5f, 5f, 5f, 5f, 5f, 5f };
            table = HandlingItextSharp.GenerateTableFromCells(cellsTit, columnWidths, null, fontTitleTable);
            document.Add(table);
            #endregion

            #region MOTIVO DE CONSULTA
            var ATENCION_INTEGRAL_MOTIVO_CONSULTA = atenInte.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.ATENCION_INTEGRAL_MOTIVO_CONSULTA) == null ? "" : atenInte.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.ATENCION_INTEGRAL_MOTIVO_CONSULTA).v_Value1;

            var signos_sintomas = atenInte.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.ATENCION_INTEGRAL_SIGNOS_SINTOMAS) == null ? "" : atenInte.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.ATENCION_INTEGRAL_SIGNOS_SINTOMAS).v_Value1;
            var tiempoEnf = atenInte.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.ATENCION_INTEGRAL_TIEMPO_EMF) == null ? "" : atenInte.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.ATENCION_INTEGRAL_TIEMPO_EMF).v_Value1;
          
            cellsTit = new List<PdfPCell>()
                { 
                    new PdfPCell(new Phrase("MOTIVO DE CONSULTA", fontColumnValueBold1)) {Colspan = 20, HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT,VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE, BackgroundColor=BaseColor.GRAY, MinimumHeight=15F },
                    
                    new PdfPCell(new Phrase("", fontColumnValueBold)) {Colspan = 4, HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT,VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE, MinimumHeight=tamaño_celda  },
                    new PdfPCell(new Phrase(ATENCION_INTEGRAL_MOTIVO_CONSULTA, fontColumnValue)) {Colspan=16, HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT,VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE, MinimumHeight=tamaño_celda  },

                    new PdfPCell(new Phrase("SIGNOS Y SÍNTOMAS :", fontColumnValueBold)) {Colspan = 4, HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT,VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE, MinimumHeight=tamaño_celda  },
                    new PdfPCell(new Phrase(signos_sintomas, fontColumnValue)) {Colspan=16, HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT,VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE, MinimumHeight=tamaño_celda  },
                    new PdfPCell(new Phrase("Tiempo de enfermedad :", fontColumnValueBold)) {Colspan=4, HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT,VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE, MinimumHeight=tamaño_celda },
                    new PdfPCell(new Phrase(tiempoEnf, fontColumnValue)) {Colspan=16 , HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT,VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE, MinimumHeight=tamaño_celda  },
                };

            columnWidths = new float[] { 3f, 5f, 5f, 5f, 5f, 5f, 5f, 5f, 5f, 3f, 5f, 5f, 5f, 5f, 5f, 5f, 5f, 5f, 5f, 5f };
            table = HandlingItextSharp.GenerateTableFromCells(cellsTit, columnWidths, PdfPCell.NO_BORDER, null, fontTitleTable);
            document.Add(table);
            #endregion

            #region RELATO CRONOLÓGICO
            var relato_cronologico = atenInte.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.ATENCION_INTEGRAL_RELATO_PATOLOGICO_DESC) == null ? "" : atenInte.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.ATENCION_INTEGRAL_RELATO_PATOLOGICO_DESC).v_Value1;

            cellsTit = new List<PdfPCell>()
                { 
                    new PdfPCell(new Phrase("RELATO CRONOLÓGICO", fontColumnValueBold1)) {Colspan = 20, HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT,VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE, BackgroundColor=BaseColor.GRAY, MinimumHeight=15f },
                    new PdfPCell(new Phrase(relato_cronologico==""?"-":relato_cronologico, fontColumnValue)) {Colspan=20, HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT,VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE, MinimumHeight=30f  },
                };

            columnWidths = new float[] { 5f, 5f, 5f, 5f, 5f, 5f, 5f, 5f, 5f, 5f, 5f, 5f, 5f, 5f, 5f, 5f, 5f, 5f, 5f, 5f };
            table = HandlingItextSharp.GenerateTableFromCells(cellsTit, columnWidths, PdfPCell.NO_BORDER, null, fontTitleTable);
            document.Add(table);
            #endregion


            #region ANTECEDENTES
            
            #region ANTECEDENTES

            var antecedentesPersonales = datosPac.AntecedentesPersonales == null ? "NO REFIERE ANTECEDENTES" : datosPac.AntecedentesPersonales;
            var antecedentesFamiliares = datosPac.AntecedentesFamiliares == null ? "NO REFIERE ANTECEDENTES" : datosPac.AntecedentesFamiliares;

            var tamaño_celda2 = 17f;

            cellsTit = new List<PdfPCell>()
                {
                    new PdfPCell(new Phrase("ANTECEDENTES", fontColumnValueBold1))
                    {
                        Colspan = 20, HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT,
                        VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE, BackgroundColor = BaseColor.GRAY,
                        MinimumHeight = 15F
                    },
                    new PdfPCell(new Phrase("ANTECEDENTES PERSONALES :", fontColumnValueBold)){Colspan = 6, HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT, VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE, MinimumHeight = 20f},
                    new PdfPCell(new Phrase(antecedentesPersonales, fontColumnValue)){Colspan = 14, HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT, VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE, MinimumHeight = 20f},
                    new PdfPCell(new Phrase("ANTECEDENTES FAMILIARES :", fontColumnValueBold)){Colspan = 6, HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT, VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE, MinimumHeight = 20f},
                    new PdfPCell(new Phrase(antecedentesFamiliares, fontColumnValue)){Colspan = 14, HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT, VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE, MinimumHeight = 20f},
                    
                };

            columnWidths = new float[] { 5f, 5f, 5f, 5f, 5f, 5f, 5f, 5f, 5f, 5f, 5f, 5f, 5f, 5f, 5f, 5f, 5f, 5f, 5f, 5f };
            table = HandlingItextSharp.GenerateTableFromCells(cellsTit, columnWidths, PdfPCell.NO_BORDER, null,
                fontTitleTable);
            document.Add(table);

            #endregion

            #region EXAMEN FÍSICO

            var piel_faneras= atenInte.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.ATENCION_INTEGRAL_PIEL_FANERAS_TEJIDO_SUBCUTANEO) == null ? "" : atenInte.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.ATENCION_INTEGRAL_PIEL_FANERAS_TEJIDO_SUBCUTANEO).v_Value1;
            
            cellsTit = new List<PdfPCell>()
                { 
                    new PdfPCell(new Phrase("EXAMEN FISICO DIRIGIDO: ", fontColumnValueBold1)) {Colspan = 20, HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT,VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE, BackgroundColor=BaseColor.GRAY, MinimumHeight=15F },
                    
                    new PdfPCell(new Phrase("", fontColumnValueBold)) {Colspan = 2, HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT,VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE, MinimumHeight=tamaño_celda  },
                    new PdfPCell(new Phrase(piel_faneras, fontColumnValue)) {Colspan=18, HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT,VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE, MinimumHeight=35f  },
                    
                   
                };

            columnWidths = new float[] { 5f, 5f, 5f, 5f, 5f, 5f, 5f, 5f, 5f, 5f, 5f, 5f, 5f, 5f, 5f, 5f, 5f, 5f, 5f, 5f };
            table = HandlingItextSharp.GenerateTableFromCells(cellsTit, columnWidths, PdfPCell.NO_BORDER, null, fontTitleTable);
            document.Add(table);
    
            #endregion

            

            #region DIAGNOSTICOS

            var ATENCION_INTEGRAL_DIAGNOSTICO_CLINICO = atenInte.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.ATENCION_INTEGRAL_DIAGNOSTICO_CLINICO) == null ? "" : atenInte.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.ATENCION_INTEGRAL_DIAGNOSTICO_CLINICO).v_Value1;

            cells = new List<PdfPCell>()
                {
                    new PdfPCell(new Phrase("DIAGNOSTICOS", fontColumnValueBold1)) {Colspan=2, HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT, VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE, FixedHeight = tamaño_celda, BackgroundColor = BaseColor.GRAY },       

                    new PdfPCell(new Phrase("*Dx CLINICO", fontColumnValueBold1)) { Colspan=2, HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT, VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE, FixedHeight = tamaño_celda, BackgroundColor = BaseColor.GRAY },       
                    new PdfPCell(new Phrase(ATENCION_INTEGRAL_DIAGNOSTICO_CLINICO, fontColumnValue)) {Colspan=2, HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT,VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE, MinimumHeight=25f  },


                    new PdfPCell(new Phrase("*Dx CIE-10", fontColumnValueBold1)) { Colspan=2, HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT, VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE, FixedHeight = tamaño_celda, BackgroundColor = BaseColor.GRAY },       

                    new PdfPCell(new Phrase("CIE - 10", fontColumnValueBold)) {HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER, VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE, FixedHeight = tamaño_celda},       
                    new PdfPCell(new Phrase("DIAGNÓSTICO", fontColumnValueBold)) {HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER, VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE, FixedHeight = tamaño_celda},       

                };
            columnWidths = new float[] { 20.6f, 40.6f };
            filiationWorker = HandlingItextSharp.GenerateTableFromCells(cells, columnWidths, null, fontTitleTableNegro, null);
            document.Add(filiationWorker);
            cells = new List<PdfPCell>();

            var filterDiagnosticRepository = Diagnosticos.FindAll(p => p.i_FinalQualificationId != (int)Sigesoft.Common.FinalQualification.Descartado);

            if (filterDiagnosticRepository != null && filterDiagnosticRepository.Count > 0)
            {
                //columnWidths = new float[] { 0.7f, 23.6f };
                //include = "i_Item,Valor1";

                foreach (var item in filterDiagnosticRepository)
                {
                    cells.Add(new PdfPCell(new Phrase(item.v_Dx_CIE10, fontColumnValue)));

                    cells.Add(new PdfPCell(new Phrase(item.v_DiseasesName, fontColumnValue)));
                    columnWidths = new float[] { 20.6f, 40.6f };

                    //if (item.v_DiseasesId == "N009-DD000000029")
                    //{
                    //    cell = new PdfPCell(new Phrase("")) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
                    //    cells.Add(cell);
                    //}
                    //else
                    //{
                    //    cell = new PdfPCell(new Phrase(item.v_DiseasesName, fontColumnValue)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
                    //    cells.Add(cell);
                    //}

                    //ListaComun oListaComun = null;
                    //List<ListaComun> Listacomun = new List<ListaComun>();

                    //if (item.Recomendations.Count > 0)
                    //{
                    //    oListaComun = new ListaComun();
                    //    oListaComun.Valor1 = "RECOMENDACIONES";
                    //    oListaComun.i_Item = "#";
                    //    Listacomun.Add(oListaComun);
                    //}


                    //int Contador = 1;
                    //foreach (var Reco in item.Recomendations)
                    //{
                    //    oListaComun = new ListaComun();

                    //    oListaComun.Valor1 = Reco.v_RecommendationName;
                    //    oListaComun.i_Item = Contador.ToString();
                    //    Listacomun.Add(oListaComun);
                    //    Contador++;
                    //}


                    //// Crear tabla de recomendaciones para insertarla en la celda que corresponde
                    //table = HandlingItextSharp.GenerateTableFromList(Listacomun, columnWidths, include, fontColumnValue);
                    //cell = new PdfPCell(table);

                    //cells.Add(cell);
                }

                //columnWidths = new float[] { 20.6f, 40.6f };
            }
            else
            {
                cells.Add(new PdfPCell(new Phrase("", fontColumnValue)));
                columnWidths = new float[] { 100 };
            }

            table = HandlingItextSharp.GenerateTableFromCells(cells, columnWidths, null, null);
            document.Add(table);
            #endregion

            #region EXAMENES AUXILIARES

            //var a = atenInte.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.ATENCION_INTEGRAL_RELATO_PATOLOGICO_DESC) == null ? "" : atenInte.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.ATENCION_INTEGRAL_RELATO_PATOLOGICO_DESC).v_Value1;

            cellsTit = new List<PdfPCell>()
                { 
                    new PdfPCell(new Phrase("EXAMENES AUXILIARES", fontColumnValueBold1)) {Colspan = 20, HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT,VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE, BackgroundColor=BaseColor.GRAY, MinimumHeight=15F },
                };

            columnWidths = new float[] { 5f, 5f, 5f, 5f, 5f, 5f, 5f, 5f, 5f, 5f, 5f, 5f, 5f, 5f, 5f, 5f, 5f, 5f, 5f, 5f };
            table = HandlingItextSharp.GenerateTableFromCells(cellsTit, columnWidths, null, fontTitleTable);
            document.Add(table);
            if (DataSource.Count != 0)
            {
                foreach (var category in DataSource)
                {
                    //exámenes
                    cells = new List<PdfPCell>()
                {
                    new PdfPCell(new Phrase("* ", fontTitleTable)) {HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT, VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE, MinimumHeight = 20f,BorderColor= BaseColor.WHITE},
                    new PdfPCell(new Phrase(category.v_CategoryName, fontTitleTable)) {HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT, VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE, MinimumHeight = 20f,BorderColor= BaseColor.WHITE},
                };
                    columnWidths = new float[] { 10f, 90f };
                    table = HandlingItextSharp.GenerateTableFromCells(cells, columnWidths, null, fontTitleTable);
                    document.Add(table);
                    string examenes = "";
                    foreach (var component in category.Componentes)
                    {
                        examenes = examenes + " / " + component.v_ComponentName;
                    }
                    cells = new List<PdfPCell>()
                    {
                        new PdfPCell(new Phrase("- ", fontColumnValue)) {HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT, VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE, MinimumHeight = 20f,BorderColor= BaseColor.WHITE},
                        new PdfPCell(new Phrase(examenes , fontColumnValue)) {HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT, VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE, MinimumHeight = 20f,BorderColor= BaseColor.WHITE},
                    };
                    columnWidths = new float[] { 15f, 85f };
                    table = HandlingItextSharp.GenerateTableFromCells(cells, columnWidths, null, fontTitleTable);
                    document.Add(table);
                }

            }
            else
            {
                cellsTit = new List<PdfPCell>()
                { 
                    new PdfPCell(new Phrase("- - -", fontColumnValue)) {Colspan = 20, HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT,VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE, MinimumHeight=15F },
                };

                columnWidths = new float[] { 100f };
                table = HandlingItextSharp.GenerateTableFromCells(cellsTit, columnWidths, null, fontTitleTable);
                document.Add(table);
            }


            #endregion

            #region PERFIL TERAPEUTICO
            string planTera = "";
            if (atenInte != null)
            {
                planTera =
                    atenInte.ServiceComponentFields.Find(p =>
                        p.v_ComponentFieldsId == Sigesoft.Common.Constants.ATENCION_INTEGRAL_PLAN_TERAPEUTICO) == null
                        ? ""
                        : atenInte.ServiceComponentFields.Find(p =>
                            p.v_ComponentFieldsId == Sigesoft.Common.Constants.ATENCION_INTEGRAL_PLAN_TERAPEUTICO).v_Value1;

            }

            cellsTit = new List<PdfPCell>()
                { 
                    new PdfPCell(new Phrase("PLAN TERAPEUTICO", fontColumnValueBold1)) {Colspan = 20, HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT,VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE, BackgroundColor=BaseColor.GRAY, MinimumHeight=15F },
                    new PdfPCell(new Phrase("*** "+ planTera, fontColumnValueBold))
                    {
                        HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT,
                        VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE, MinimumHeight = tamaño_celda
                    },    
                };

            columnWidths = new float[] { 100F };
            table = HandlingItextSharp.GenerateTableFromCells(cellsTit, columnWidths, null, fontTitleTable);
            document.Add(table);
            cells2 = new List<PdfPCell>();
            if (medicina != null && medicina.Count > 0)
            {
                var count = 1;
                foreach (var item in medicina)
                {
                    cell = new PdfPCell(new Phrase(count.ToString(), fontColumnValue)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER, VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE, MinimumHeight = tamaño_celda };
                    cells2.Add(cell);

                    cell = new PdfPCell(new Phrase(item.Medicamento, fontColumnValue)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER, VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE, MinimumHeight = tamaño_celda };
                    cells2.Add(cell);

                    cell = new PdfPCell(new Phrase(item.CantidadRecetada.ToString(), fontColumnValue)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT, VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE, MinimumHeight = tamaño_celda };
                    cells2.Add(cell);

                    cell = new PdfPCell(new Phrase(item.Dosis, fontColumnValue)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT, VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE, MinimumHeight = tamaño_celda };
                    cells2.Add(cell);

                    cell = new PdfPCell(new Phrase(item.Duracion, fontColumnValue)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT, VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE, MinimumHeight = tamaño_celda };
                    cells2.Add(cell);

                    count += 1;
                }
                cell = new PdfPCell(new Phrase(null, fontColumnValue)) { Colspan = 5, BackgroundColor = BaseColor.GRAY, HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT, VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE, MinimumHeight = 2 };
                cells2.Add(cell);
                columnWidths = new float[] { 5F, 25f, 10f, 30f, 30f };
            }
            else
            {
                cells2.Add(new PdfPCell(new Phrase("- - -", fontColumnValue)) { Colspan = 5, HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT, VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE, FixedHeight = tamaño_celda });
                columnWidths = new float[] { 100f };
            }
            columnHeaders = new string[] { "N°", "MEDICAMENTO", "CANT", "DOSIS Y TIEMPO", "DURACIÓN TTO" };
            columnWidths = new float[] { 5F, 25f, 10f, 30f, 30f };
            table = HandlingItextSharp.GenerateTableFromCells(cells2, columnWidths, null, fontColumnValueBold, columnHeaders);
            document.Add(table);
            #endregion

            #region Firma

            #region Creando celdas de tipo Imagen y validando nulls
            PdfPCell cellFirmaTrabajador = null;
            PdfPCell cellHuellaTrabajador = null;
            PdfPCell cellFirma = null;

            // Firma del trabajador ***************************************************

            if (datosPac.FirmaTrabajador != null)
                cellFirmaTrabajador = new PdfPCell(HandlingItextSharp.GetImage(datosPac.FirmaTrabajador, null, null, 80, 40));
            else
                cellFirmaTrabajador = new PdfPCell(new Phrase(" ", fontColumnValue));

            cellFirmaTrabajador.HorizontalAlignment = Element.ALIGN_CENTER;
            cellFirmaTrabajador.VerticalAlignment = Element.ALIGN_MIDDLE;
            cellFirmaTrabajador.FixedHeight = 50F;
            // Huella del trabajador **************************************************

            if (datosPac.HuellaTrabajador != null)
                cellHuellaTrabajador = new PdfPCell(HandlingItextSharp.GetImage(datosPac.HuellaTrabajador, null, null, 30, 45));
            else
                cellHuellaTrabajador = new PdfPCell(new Phrase(" ", fontColumnValue));

            cellHuellaTrabajador.HorizontalAlignment = Element.ALIGN_CENTER;
            cellHuellaTrabajador.VerticalAlignment = Element.ALIGN_MIDDLE;
            cellHuellaTrabajador.FixedHeight = 50F;
            // Firma del doctor Auditor **************************************************
            if (DatosGrabo != null)
            {
                if (DatosGrabo.Firma != null)
                    cellFirma = new PdfPCell(HandlingItextSharp.GetImage(DatosGrabo.Firma, null, null, 120, 50)) { HorizontalAlignment = PdfPCell.ALIGN_CENTER };
                else
                    cellFirma = new PdfPCell(new Phrase(" ", fontColumnValue));
            }
            else
            {
                cellFirma = new PdfPCell(new Phrase(" ", fontColumnValue));
            }

            cellFirma.HorizontalAlignment = Element.ALIGN_CENTER;
            cellFirma.VerticalAlignment = Element.ALIGN_MIDDLE;
            cellFirma.FixedHeight = 50F;
            #endregion

            string observaciones_new = "";
            string final = "";
            string observaciones = "";

            string especialidadInterconsulta = "";

            if (atenInte != null)
            {
                var fechaControl = atenInte.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.ATENCION_INTEGRAL_PROX_CITA) == null ? "" : atenInte.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.ATENCION_INTEGRAL_PROX_CITA).v_Value1;
                var finalId = atenInte.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.ATENCION_INTEGRAL_RESULTADO) == null ? "" : atenInte.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.ATENCION_INTEGRAL_RESULTADO).v_Value1;

                final = atenInte.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.ATENCION_INTEGRAL_RESULTADO) == null ? "" : atenInte.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.ATENCION_INTEGRAL_RESULTADO).v_Value1Name;
                observaciones = atenInte.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.ATENCION_INTEGRAL_OBSERVACIONES) == null ? "" : atenInte.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.ATENCION_INTEGRAL_OBSERVACIONES).v_Value1;
                especialidadInterconsulta = atenInte.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.ATENCION_INTEGRAL_RESULTADO_INTERCONSULTA) == null ? "" : atenInte.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.ATENCION_INTEGRAL_RESULTADO_INTERCONSULTA).v_Value1Name;

                if (fechaControl == servicio[0])
                {
                    observaciones_new = "";
                }
                else
                {
                    observaciones_new = fechaControl;
                }

                if (finalId == "6" || finalId == "9" || finalId == "10")
                {
                    especialidadInterconsulta = " - " + especialidadInterconsulta;
                }
                else
                {
                    especialidadInterconsulta = "";
                }
            }

            cells = new List<PdfPCell>()
            {
                new PdfPCell(new Phrase("FECHA PROXIMA CITA: " + observaciones_new , fontColumnValueBold)){HorizontalAlignment = PdfPCell.ALIGN_LEFT,  VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE,  Colspan = 4, Rowspan = 2},
                new PdfPCell(new Phrase("INDICACIÓN: " + final + especialidadInterconsulta, fontColumnValueBold)){HorizontalAlignment = PdfPCell.ALIGN_LEFT,  VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE,  Colspan = 4, Rowspan = 2},
                new PdfPCell(new Phrase("OBSERVACIONES: " + observaciones, fontColumnValueBold)){HorizontalAlignment = PdfPCell.ALIGN_LEFT,  VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE,  Colspan = 4, Rowspan = 2},
     
                new PdfPCell(new Phrase("FIRMA Y SELLO DEL MÉDICO", fontColumnValueBold)) { Colspan = 2, Rowspan = 2, HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER, VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE, MinimumHeight = tamaño_celda},    
                new PdfPCell(cellFirma){Colspan = 2, Rowspan=2, HorizontalAlignment = PdfPCell.ALIGN_CENTER},

                //new PdfPCell(cellFirmaTrabajador){HorizontalAlignment = PdfPCell.ALIGN_CENTER},
                //new PdfPCell(cellHuellaTrabajador){HorizontalAlignment = PdfPCell.ALIGN_CENTER},
                //new PdfPCell(new Phrase("FIRMA Y SELLO DEL MÉDICO", fontColumnValueBold)) {Rowspan = 2, HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER, VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE, MinimumHeight = tamaño_celda},    
                //new PdfPCell(cellFirma){Rowspan=2, HorizontalAlignment = PdfPCell.ALIGN_CENTER},
 
                //new PdfPCell(new Phrase("FIRMA DEL EXAMINADO", fontColumnValueBold)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER, VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE, FixedHeight = 12f},    
                //new PdfPCell(new Phrase("HUELLA DEL EXAMINADO", fontColumnValueBold)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER, VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE, FixedHeight = 12f},    

                //new PdfPCell(new Phrase("¡GRACIAS POR ELEGIR CLINICA SAN LORENZO!", fontColumnValueBold)) {Colspan=4, HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER, VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE, FixedHeight = tamaño_celda},    

            };
            columnWidths = new float[] { 25f, 25f, 25f, 25f };

            filiationWorker = HandlingItextSharp.GenerateTableFromCells(cells, columnWidths, null, fontTitleTable);

            document.Add(filiationWorker);

            #endregion

            #endregion
            document.Close();
            writer.Close();
            writer.Dispose();
        }
    }
}
