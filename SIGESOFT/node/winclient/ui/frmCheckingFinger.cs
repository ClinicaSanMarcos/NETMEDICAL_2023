using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Speech.Synthesis;
using Sigesoft.Common;
using Sigesoft.Node.WinClient.BLL;
using Sigesoft.Node.WinClient.BE;
using System.Data.SqlClient;
using Microsoft.Speech.Synthesis;
using System.Configuration;


namespace Sigesoft.Node.WinClient.UI
{
    public partial class frmCheckingFinger : Form
    {
        public string NamePerson;
        public string dni;
        //SpeechSynthesizer synth = new SpeechSynthesizer();
        private int FMatchType, fpcHandle;
        private bool FAutoIdentify;
        byte[] _FingerPrintImage;
        PacientBL objPacienteBL = new PacientBL();
        public string _PacientId = string.Empty;
        private string _personName;
        private string _dni;
        //private Microsoft.Speech.Synthesis.SpeechSynthesizer synth = new Microsoft.Speech.Synthesis.SpeechSynthesizer();
        public frmCheckingFinger(string dni)
        {
            _dni = dni;
            InitializeComponent();
        }

        private void frmCheckingFinger_Load(object sender, EventArgs e)
        {
            // Iniciar el componente huellero
            InitFingerPrint();
            FAutoIdentify = false;

            OperationResult objOperationResult = new OperationResult();
            //var person = objPacienteBL.GetPersonByNroDocument(ref objOperationResult, _dni);
            
            //_PacientId = person.v_PersonId;
            //var objPersonDto = objPacienteBL.GetPerson(ref objOperationResult, _PacientId);
            //_personName = objPersonDto.v_FirstName + " " + objPersonDto.v_FirstLastName + " " + objPersonDto.v_SecondLastName;
            //_FingerPrintImage = objPersonDto.b_FingerPrintTemplate;
              
          
        }


        //Show fingerprint image
        private void ZKFPEngX1_OnImageReceived(object sender, AxZKFPEngXControl.IZKFPEngXEvents_OnImageReceivedEvent e)
        {
            ShowHintImage(0);
            Graphics g = pbFingerPrint.CreateGraphics();
            Bitmap bmp = new Bitmap(pbFingerPrint.Width, pbFingerPrint.Height);
            g = Graphics.FromImage(bmp);
            int dc = g.GetHdc().ToInt32();
            ZKFPEngX1.PrintImageAt(dc, 0, 0, bmp.Width, bmp.Height);
            g.Dispose();
            pbFingerPrint.Image = bmp;
        }      

        private void ZKFPEngX1_OnFeatureInfo(object sender, AxZKFPEngXControl.IZKFPEngXEvents_OnFeatureInfoEvent e)
        {
            String strTemp = "Fingerprint calidad";
            if (e.aQuality != 0)
            {
                strTemp = strTemp + " No buena";
                lblresult.Text = strTemp;
                ShowHintImage(2);
            }
            else
            {
                strTemp = strTemp + " Bueno";
            }
            if (ZKFPEngX1.EnrollIndex != 1)
            {
                if (ZKFPEngX1.IsRegister)
                {
                    if (ZKFPEngX1.EnrollIndex - 1 > 0)
                    {
                        strTemp = strTemp + '\n' + "Estado de Registro: pulse su dedo " + Convert.ToString(ZKFPEngX1.EnrollIndex - 1) + " veces!";
                        lblresult.Text = strTemp;
                        ShowHintImage(3);
                    }
                }
            }
          
        }

        private void ZKFPEngX1_OnCapture(object sender, AxZKFPEngXControl.IZKFPEngXEvents_OnCaptureEvent e)
        {
            #region Huella OLD

            //string stmp = "";
            //string Template = ZKFPEngX1.GetTemplateAsString();
            //bool ddd = false;
            //if (_FingerPrintImage == null)
            //{
            //    MessageBox.Show("El trabajador no tiene registrado su huella digital", "!INFORMACIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Information);            
            //    return;
            //}
            //stmp = System.Convert.ToBase64String(_FingerPrintImage);

            //if (ZKFPEngX1.VerFingerFromStr(ref Template, stmp, false, ref ddd))
            //{
            //    ShowHintImage(3);
            //    MessageBox.Show("Huella dáctilar correcta", "!INFORMACIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //                   
              
            //}
            //else
            //{
            //    ShowHintImage(3);
            //    MessageBox.Show("Huella dáctilar incorrecta. Vuelva a intentar", "!ERROR DE VALIDACIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    pbFingerPrint.Image = null;
            //    //this.DialogResult = DialogResult.Cancel; 
           
            //}

            #endregion

            bool find = false;
            List<byte[]> fingers = ObtenerHuellas();
            List<PersonFinger> person = ObtenerNombres();
            foreach (var item2 in person)
            {
                if (find){break;}
                string compare = Convert.ToBase64String(item2.b_FingerPrintTemplate);
                foreach (byte[] item in fingers)
                {
                    string stmp2 = System.Convert.ToBase64String(item);
                    if (stmp2 == compare)
                    {
                        NamePerson = item2.PersonName;
                        dni = item2.docNumber;
                        //MessageBox.Show("Huella dáctilar correcta \nColaborador: "+NamePerson, "!INFORMACIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        find = true;
                        break;
                    }
                }
            }

            if (!find)
            {
                //MessageBox.Show("Usuario no encontrado ", "!INFORMACIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private List<PersonFinger> ObtenerNombres()
        {
            ConexionSigesoft conectasam = new ConexionSigesoft();
            conectasam.opensigesoft();
            var cadena = "select b_FingerPrintTemplate,  v_FirstLastName + ' '+v_SecondLastName+', '+v_FirstName, v_DocNumber from person where b_FingerPrintTemplate IS NOT NULL";
            SqlCommand comando = new SqlCommand(cadena, connection: conectasam.conectarsigesoft);
            SqlDataReader lector = comando.ExecuteReader();
            List<PersonFinger> objHuellas = new List<PersonFinger>();
            while (lector.Read())
            {
                PersonFinger huella = new PersonFinger();
                huella.b_FingerPrintTemplate = (byte[])lector.GetValue(0);
                huella.PersonName = lector.GetValue(1).ToString();
                huella.docNumber = lector.GetValue(2).ToString();
                objHuellas.Add(huella);
            }
            lector.Close();
            conectasam.closesigesoft();
            return objHuellas;
        }

        private List<byte[]> ObtenerHuellas()
        {
            ConexionSigesoft conectasam = new ConexionSigesoft();
            conectasam.opensigesoft();
            var cadena = "select b_FingerPrintTemplate from person where b_FingerPrintTemplate IS NOT NULL";
            SqlCommand comando = new SqlCommand(cadena, connection: conectasam.conectarsigesoft);
            SqlDataReader lector = comando.ExecuteReader();
            List<PersonFinger> objHuellas = new List<PersonFinger>();
            List<byte[]> finger = new List<byte[]>();
            while (lector.Read())
            {
                //PersonFinger huella = new PersonFinger();
                //huella.b_FingerPrintImage = (byte[]) lector.GetValue(0);
                //huella.b_FingerPrintTemplate = (byte[]) lector.GetValue(1);
                //objHuellas.Add(huella);
                byte[] finger1 = (byte[])lector.GetValue(0);
                finger.Add(finger1);
            }
            lector.Close();
            conectasam.closesigesoft();
            return finger;
        }

        private void ZKFPEngX1_OnFingerTouching(object sender, EventArgs e)
        {
           
        }

        private void ZKFPEngX1_OnFingerLeaving(object sender, EventArgs e)
        {
         
        }

        private void frmCheckingFinger_FormClosing(object sender, FormClosingEventArgs e)
        {
            DisconnectFingerPrint();
        }
      

        //Show hint image
        private void ShowHintImage(int iType)
        {
            if (iType == 0)
            {
                imgNO.Visible = false;
                imgOK.Visible = false;
                imgInfo.Visible = false;
            }
            else if (iType == 1)
            {
                imgNO.Visible = false;
                imgOK.Visible = true;
                imgInfo.Visible = false;
            }
            else if (iType == 2)
            {
                imgNO.Visible = true;
                imgOK.Visible = false;
                imgInfo.Visible = false;
            }
            else if (iType == 3)
            {
                imgNO.Visible = false;
                imgOK.Visible = false;
                imgInfo.Visible = true;
            }

            this.Refresh();
        }

        // Initilization FingerPrint
        private void InitFingerPrint()
        {
            if (ZKFPEngX1.InitEngine() == 0)
            {
                //btnInit.Enabled = false;
                FMatchType = 2;              
                lblresult.Text = "Sensor de Huella conectado y Listo.";
                ShowHintImage(3);
                ZKFPEngX1.FPEngineVersion = "9";           
            }
            else
            {
                lblresult.Text = "Error al conectar el sensor de Huella";
            }
        }

        //desconectar
        private void DisconnectFingerPrint()
        {
            ZKFPEngX1.EndEngine();
            //btnInit.Enabled = true;
            //button1.Enabled = false;
        }

        private void btnMarcar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;        
        }
      

    }
}
