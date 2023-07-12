using Sigesoft.Node.WinClient.BE.Custom;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sigesoft.Node.WinClient.UI
{
    public partial class frmContratosVence : Form
    {
        private SaveFileDialog saveFileDialog = new SaveFileDialog();
        private List<ProfessionalCustom> _data = new List<ProfessionalCustom>();
        public frmContratosVence(List<ProfessionalCustom> data)
        {
            _data = data;
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmContratosVence_Load(object sender, EventArgs e)
        {
            grdData.DataSource = _data;
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            DateTime desde = DateTime.Now.Date;
            DateTime hasta = desde.AddDays(8);
            string NombreArchivo = "Reporte Contratos por vencer desde " + desde.ToString() + " a " + hasta.ToString();
            NombreArchivo = NombreArchivo.Replace("/", "_");
            NombreArchivo = NombreArchivo.Replace(":", "_");

            saveFileDialog.FileName = NombreArchivo;
            saveFileDialog.Filter = "Files (*.xls;*.xlsx;*)|*.xls;*.xlsx;*";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.ultraGridExcelExporter1.Export(this.grdData, saveFileDialog.FileName);
                MessageBox.Show("Se exportaron correctamente los datos.", " ¡ INFORMACIÓN !", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
