using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sigesoft.Node.WinClient.BE.Custom;
using Sigesoft.Node.WinClient.BLL;

namespace Sigesoft.Node.WinClient.UI.Operations
{
    public partial class frmViewProductForPackage : Form
    {
        private string productId = "", otherProduct = "";
        public List<ProductPackageDetailCustom> listProductPackageDetailDtos = new List<ProductPackageDetailCustom>();

        public frmViewProductForPackage(string v_productId, List<ProductPackageDetailCustom> _listProductPackageDetailDtos)
        {
            listProductPackageDetailDtos = _listProductPackageDetailDtos;
            productId = v_productId;
            otherProduct = v_productId;
            InitializeComponent();
        }

        private void frmViewProductForPackage_Load(object sender, EventArgs e)
        {
            if (otherProduct != "")
            {
                var obj = new ProductPackageBL().GetProductoCustoms(otherProduct);
                grdProduct.DataSource = obj;
                grdProduct.Rows[0].Selected = true;
                grdProduct.Rows[0].Activated = true;
                grdProduct_AfterSelectChange(sender, null);
                btnFiltrar.Enabled = false;
                txtProductName.Enabled = false;
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            var obj = new ProductPackageBL().GetProductoCustoms(txtProductName.Text);
            grdProduct.DataSource = obj;      
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            ProductPackageDetailCustom odto = new ProductPackageDetailCustom();
            if (txtCantidad.Text == "" || txtCantidad.Text == null)
            {
                MessageBox.Show("Por favor, ingrese una cantidad para continuar", "VALIDACIÓN", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            if (grdProduct.Selected.Rows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione un producto para continuar", "VALIDACIÓN", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            odto.d_Cantidad = decimal.Parse(txtCantidad.Text);
            odto.v_ProductId = productId;
            odto.r_Price = float.Parse(txtPrecio.Text);
            odto.v_Descripcion = txtNombre.Text;
            var find = listProductPackageDetailDtos.Find(x => x.v_ProductId == productId);
            if (find == null)
            {
                listProductPackageDetailDtos.Add(odto);
            }
            else
            {
                listProductPackageDetailDtos.Find(x => x.v_ProductId == productId).d_Cantidad = odto.d_Cantidad;
            }
            MessageBox.Show("Se agregó correctamente", "HECHO", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
            LimpiarCampos();
            if (otherProduct != "")
            {
                this.Close();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LimpiarCampos()
        {
            txtNombre.Text = "";
            txtCantidad.Text = "";
            txtPrecio.Text = "";
        }

        private void grdProduct_AfterSelectChange(object sender, Infragistics.Win.UltraWinGrid.AfterSelectChangeEventArgs e)
        {
            if (grdProduct.Rows.Count > 0)
            {
                productId = grdProduct.Selected.Rows[0].Cells["v_IdProducto"].Value.ToString();
                var nombre = grdProduct.Selected.Rows[0].Cells["v_Descripcion"].Value.ToString();
                var precio = grdProduct.Selected.Rows[0].Cells["d_PrecioVenta"].Value.ToString();

                txtNombre.Text = nombre;
                txtPrecio.Text = precio;
            }

        }

    }
}
