using Sigesoft.Common;
using Sigesoft.Node.WinClient.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sigesoft.Node.WinClient.UI.Operations
{
    public partial class frmAntecedentes : Form
    {
        private string personId;
        private string antPersonales;
        private string antFamiliares;


        public frmAntecedentes(string _personId, string _antPersonales, string _antFamiliares)
        {
            personId = _personId;
            antPersonales = _antPersonales;
            antFamiliares = _antFamiliares;
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAntecedentes_Load(object sender, EventArgs e)
        {
            txtAntPersonales.Text = antPersonales;
            txtAntFamiliares.Text = antFamiliares;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

           var verificacion = new ServiceBL().UpdatePersonAntecedentes(personId, txtAntPersonales.Text, txtAntFamiliares.Text, Globals.ClientSession.GetAsList());
           if (verificacion == 1 )
           {
               MessageBox.Show("GUARDADO CORRECTAMENTE", "¡AVISO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
               this.Close();
           }
           else
               MessageBox.Show("NO SE PUDO GUARDAR LA INFORMACIÓN, VERIFIQUE QUE HAYA LLENADO CORRECTAMENTE", "¡AVISO!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
           this.Close();
        }
    }
}
