using Sigesoft.Node.WinClient.BE.Custom;
using Sigesoft.Node.WinClient.BLL;
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
    public partial class frmAdministracionCamas : Form
    {
        List<HabitacionCustom> _HabitacionCustomList = new List<HabitacionCustom>();
        List<HabitacionCustom> _HabitacionCustomListTemp = new List<HabitacionCustom>();

        public frmAdministracionCamas()
        {
            InitializeComponent();
        }

        private void frmAdministracionCamas_Load(object sender, EventArgs e)
        {
            BindingGrid();
        }

        private void BindingGrid()
        {

            _HabitacionCustomList = new HabitacionBL().GetHabitacionesViewEdit("");

            grdDataHabitaciones.DataSource = _HabitacionCustomList;

        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtBusqueda.Text != string.Empty)
            {
                List<HabitacionCustom> listnew = new List<HabitacionCustom>();

                listnew = new List<HabitacionCustom>(_HabitacionCustomList.Where(p => p.Habitacion.Contains(txtBusqueda.Text.ToUpper())));

                var listBinding = new BindingList<HabitacionCustom>(listnew);

                grdDataHabitaciones.DataSource = listBinding;

                if (listBinding != null)
                {
                    lblRecordCountCalendar.Text = string.Format("Se encontraron {0} registros.", listBinding.Count());

                }

            }
            else
            {
                grdDataHabitaciones.DataSource = _HabitacionCustomList;
                if (grdDataHabitaciones != null)
                {
                    lblRecordCountCalendar.Text = string.Format("Se encontraron {0} registros.", _HabitacionCustomList.Count());

                }
            }
        }

        private void btnAsignarHabitacion_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new AgregarEditarCama("Nuevo", "", "","",null);
                frm.ShowDialog();
                BindingGrid();

            }
            catch (Exception)
            {
                MessageBox.Show("Error para guardar Cama", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BindingGrid();
        }

        private void btnEditarHabitacion_Click(object sender, EventArgs e)
        {
            try
            {
                var cama = grdDataHabitaciones.Selected.Rows[0].Cells["Habitacion"].Value.ToString();
                var precio = grdDataHabitaciones.Selected.Rows[0].Cells["Precio"].Value.ToString();
                var comentarios = grdDataHabitaciones.Selected.Rows[0].Cells["Comentarios"].Value.ToString();
                var id = int.Parse(grdDataHabitaciones.Selected.Rows[0].Cells["i_HabitacionId"].Value.ToString());

                var frm = new AgregarEditarCama("Nuevo", cama, precio, comentarios, id);
                frm.ShowDialog();
            }
            catch (Exception)
            {
                MessageBox.Show("Seleccione una Camna parae Editar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }
    }
}
