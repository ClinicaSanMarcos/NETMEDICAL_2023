using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sigesoft.Node.WinClient.UI.Hospitalizacion
{
    public partial class frmTipoBuquedaProducto : Form
    {
        public int TipoBusqueda = -1;
        public frmTipoBuquedaProducto()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (rdoBusqProd.Checked)
            {
                TipoBusqueda = 0;
            }
            else
            {
                TipoBusqueda = 1;
            }
            this.Close();
        }
    }
}
