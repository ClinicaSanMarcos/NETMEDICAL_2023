using Sigesoft.Common;
using Sigesoft.Node.WinClient.BLL;
using Sigesoft.Server.WebClientAdmin.BE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sigesoft.Node.WinClient.UI.Hospitalizacion
{
    public partial class frmAddEditProcedimientos : Form
    {
        TramasBL _objTramasBL = new TramasBL();
        private string HospiId;
        private string ProdT;
        object listaproc;
        private hospitalizacionDto _HospiDto = null;

        private string Proced;
        private string Codigo;

        public frmAddEditProcedimientos(string _HospiId, string _Proced, string _Codigo)
        {
            HospiId = _HospiId;
            Proced = _Proced;
            Codigo = _Codigo;
            InitializeComponent();
        }

        private void frmAddEditProcedimientos_Load(object sender, EventArgs e)
        {
            OperationResult objOperationResult = new OperationResult();
            listaproc = new PacientBL().LlenarListaProc(ref objOperationResult);

            cbProcedimiento.DataSource = listaproc;
            cbProcedimiento.DisplayMember = "v_Value1";
            cbProcedimiento.ValueMember = "i_ParameterId";
            cbProcedimiento.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            cbProcedimiento.AutoSuggestFilterMode = Infragistics.Win.AutoSuggestFilterMode.Contains;
            this.cbProcedimiento.DropDownWidth = 590;
            cbProcedimiento.DisplayLayout.Bands[0].Columns[0].Width = 550;
            cbProcedimiento.DisplayLayout.Bands[0].Columns[1].Width = 40;

            if (Proced != "- - -")
            {
                cbProcedimiento.Text = Proced;
            }

            if (Codigo != "- - -")
            {
                txtProcedId.Text = Codigo;
            }
        }

        private void cbProcedimiento_MouseDown(object sender, MouseEventArgs e)
        {
            if (cbProcedimiento.Text != "")
            {
                cbProcedimiento.SelectionStart = 0;
                cbProcedimiento.SelectionLength = cbProcedimiento.Text.Length;
            }
        }

        private void cbProcedimiento_RowSelected(object sender, Infragistics.Win.UltraWinGrid.RowSelectedEventArgs e)
        {
            #region Conexion SAM
            ConexionSigesoft conectasam = new ConexionSigesoft();
            conectasam.opensigesoft();
            #endregion

            string proced = cbProcedimiento.Text;
            var cadena1 = "select i_ParameterId from systemparameter where v_Value1='" + proced + "'";
            SqlCommand comando = new SqlCommand(cadena1, connection: conectasam.conectarsigesoft);
            SqlDataReader lector = comando.ExecuteReader();
            while (lector.Read())
            {
                txtProcedId.Text = lector.GetValue(0).ToString();
            }
            lector.Close();
            conectasam.closesigesoft();
        }

        private void btnGuardarTicket_Click(object sender, EventArgs e)
        {
            OperationResult objOperationResult = new OperationResult();

            if (cbProcedimiento.Text == "")
            {
                MessageBox.Show("Seleccione un Procidimiento correctamente.", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ConexionSigesoft conectasam = new ConexionSigesoft();
            conectasam.opensigesoft();
            var cadena1 =
                " UPDATE hospitalizacion SET i_ProcedimientoSOP = " + int.Parse(txtProcedId.Text) +
                " , v_ProcedimientoSOP = '" + cbProcedimiento.Text + "' " +
                "  where v_HopitalizacionId =  '" + HospiId + "'";
            SqlCommand comando = new SqlCommand(cadena1, connection: conectasam.conectarsigesoft);
            SqlDataReader lector1 = comando.ExecuteReader();
            lector1.Close();
            conectasam.closesigesoft();

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
