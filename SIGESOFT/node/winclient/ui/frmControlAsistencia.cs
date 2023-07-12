using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sigesoft.Node.WinClient.BLL;
using Sigesoft.Node.WinClient.BE;
using Sigesoft.Common;
using System.Data.SqlClient;
using Microsoft.Speech.Synthesis;
using Sigesoft.Node.WinClient.DAL;

namespace Sigesoft.Node.WinClient.UI
{
    public partial class frmControlAsistencia : Form
    {
        //SpeechSynthesizer synth = new SpeechSynthesizer();
        private SaveFileDialog saveFileDialog = new SaveFileDialog();
        private string[] rol = new string[2];
        private bool block;
        public frmControlAsistencia()
        {
            InitializeComponent();
        }

        private void frmControlAsistencia_Load(object sender, EventArgs e)
        {
            rol = ObtenerRol(Globals.ClientSession.i_SystemUserId);
            if (rol[0] == "ADMINISTRADOR DE SISTEMAS")
            {
                txtNroDoc.Text = "";
                block = true;
                BloquearControl(block);
            }
            else
            {
                txtNroDoc.Text = "";
                block = false;
                BloquearControl(block);
            }
            BloquearControl(block);
            BindingGrid();
            Timer timer1 = new Timer();
            timer1.Interval = 1000;
            timer1.Tick += (sender1, e1) => {
        
                lblTime.Text = DateTime.Now.ToString("dddd dd MMMM yyyy \n     hh:mm:ss tt");
            };

            timer1.Start();
            btnRegistrar_Click(sender, e);
        }

        private void BloquearControl(bool block)
        {
            txtNroDoc.Enabled = block;
            btnGrupos.Visible = block;
            btnPagarHoras.Visible = block;
            btnVacaciones.Visible = block;
            btnRecords.Visible = block;
            btnSystemUser.Visible = block;
        }

        private string[] ObtenerRol(int p)
        {
            ConexionSigesoft conectasam = new ConexionSigesoft();
            conectasam.opensigesoft();
            var cadenasam =
                "select v_Value1, v_DocNumber from person PP " +
                "inner join systemuser SU on PP.v_PersonId=SU.v_PersonId " +
                "inner join systemuserrolenode SUR on SU.i_SystemUserId=SUR.i_SystemUserId " +
                "inner join systemparameter SP on SUR.i_RoleId=SP.i_ParameterId and SP.i_GroupId=115 " +
                "where su.i_SystemUserId= "+p+" and SUR.i_IsDeleted=0";
            SqlCommand comando = new SqlCommand(cadenasam, connection: conectasam.conectarsigesoft);
            SqlDataReader lector = comando.ExecuteReader();
            string[] rol = new string[2];
            while (lector.Read())
            {
                rol[0] = lector.GetValue(0).ToString();
                rol[1] = lector.GetValue(1).ToString();
            }
            lector.Close();
            conectasam.closesigesoft();
            return rol;
        }

        private void BindingGrid()
        {
            if (txtNroDoc.Text != "")
            {
                var list = new WorkerScheduleBL().GetMarkingsForDay(dtDesde.Value.Date, dtHasta.Value.Date, txtNroDoc.Text);
                grdDataGroupControl.DataSource = list;
            }
            else
            {
                var list = new WorkerScheduleBL().GetMarkingsForDayDNI(dtDesde.Value.Date, dtHasta.Value.Date);
                grdDataGroupControl.DataSource = list;
            }
            
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            string dni = txtNroDoc.Text.Trim();
            //if (dni == null || dni == "")
            //{
            //    MessageBox.Show("Ingrese su DNI para continuar.", "VALIDACIÓN", MessageBoxButtons.OK,
            //        MessageBoxIcon.Warning);
            //    return;
            //}
            frmCheckingFinger frm = new frmCheckingFinger(dni);
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                MessageBox.Show("Huella dáctilar correcta \nColaborador: " + frm.NamePerson, "!INFORMACIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                markingsDto data = new markingsDto();
                string personId = new WorkerScheduleBL().GetPersonIdByDocNumber(frm.dni);
                if (personId == null)
                {
                    MessageBox.Show("Usuario: "+frm.NamePerson+"\nNo se encuentra registrado en el sistema.", "VALIDACIÓN", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                data.v_PersonId = personId;
                string datail = new WorkerScheduleBL().SaveMarking(data, frm.NamePerson);
                if (datail != null)
                {
                    if (datail != "OK")
                    {
                        MessageBox.Show(datail, "VALIDACIÓN", MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                    }
                    BindingGrid();
                }
                else
                {
                    MessageBox.Show("Sucedió un error, por favor vuelva a intentar.", "VALIDACIÓN", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

            }
            else
            {
                MessageBox.Show("Usuario: " + frm.NamePerson + "\nNo hay coincidencia", "INFORMACIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            btnRegistrar_Click(sender, e);
            //if (rol[0] != "ADMINISTRADOR DE SISTEMAS")
            //{
            //    btnRegistrar_Click(sender, e);
            //}
        }

        private void txtNroDoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnRegistrar_Click(sender, e);
            }
        }

        private void btnGrupos_Click(object sender, EventArgs e)
        {
            frmControlGrupos frm = new frmControlGrupos();
            frm.ShowDialog();
        }

        private void btnPagarHoras_Click(object sender, EventArgs e)
        {
            frmBandejaPagoTrabajador frm = new frmBandejaPagoTrabajador();
            frm.ShowDialog();
        }

        private void grdDataGroupControl_InitializeRow(object sender, Infragistics.Win.UltraWinGrid.InitializeRowEventArgs e)
        {
            if (grdDataGroupControl.Rows.Count > 0 )
            {
                grdDataGroupControl.Rows[0].Cells["MarkingId"].Column.Hidden = true;
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            BindingGrid();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            string NombreArchivo = "Reporte Marcaciones de " + dtDesde.Text + " a " + dtHasta.Text;
            NombreArchivo = NombreArchivo.Replace("/", "_");
            NombreArchivo = NombreArchivo.Replace(":", "_");

            saveFileDialog.FileName = NombreArchivo;
            saveFileDialog.Filter = "Files (*.xls;*.xlsx;*)|*.xls;*.xlsx;*";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.ultraGridExcelExporter1.Export(this.grdDataGroupControl, saveFileDialog.FileName);
                MessageBox.Show("Se exportaron correctamente los datos.", " ¡ INFORMACIÓN !", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnVacaciones_Click(object sender, EventArgs e)
        {
            frmPersonalEnVacaciones frm = new frmPersonalEnVacaciones();
            frm.ShowDialog();
        }

        private void btnRecords_Click(object sender, EventArgs e)
        {
            frmRecordsMarkings frm = new frmRecordsMarkings();
            frm.ShowDialog();
        }

        private void btnSystemUser_Click(object sender, EventArgs e)
        {
            frmSystemUser frm = new frmSystemUser();
            frm.ShowDialog();
        }
    }
}
