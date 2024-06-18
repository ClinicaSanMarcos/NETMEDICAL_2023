using Sigesoft.Common;
using Sigesoft.Node.WinClient.BE;
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
    public partial class AgregarEditarCama : Form
    {
        string _modo;
        string _habitacion;
        string _precio;
        string _Comentarios;
        int? _IdCama;

        public AgregarEditarCama(string modo, string habitacion, string precio, string Comentarios, int? IdCama)
        {
            _modo = modo;
            _habitacion = habitacion;
            _precio = precio;
            _Comentarios = Comentarios;
            _IdCama = IdCama;

            InitializeComponent();
        }

        private void AgregarEditarCama_Load(object sender, EventArgs e)
        {
            if (_modo == "Editar")
            {
                txtNombreHab.Text = _habitacion;
                txtPrecio.Text = _precio;
                txtComentario.Text = _Comentarios;
            }
                
       }

        private void btnGuardarTicket_Click(object sender, EventArgs e)
        {
            OperationResult objOperationResult = new OperationResult();

            if (_modo == "Nuevo")
            {
                DialogResult Result = MessageBox.Show("¿Desea Guardar Ticket?", "ADVERTENCIA!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (Result == System.Windows.Forms.DialogResult.Yes)
                {
                    systemparameterDto _spObj = new systemparameterDto();

                    _spObj.v_Value1 = txtNombreHab.Text;
                    _spObj.v_Value2 = txtPrecio.Text;
                    _spObj.v_ComentaryUpdate = txtComentario.Text;

                    var ticketId = new HabitacionBL().AddCama(ref objOperationResult, _spObj, Globals.ClientSession.GetAsList());
                    this.Close();
                }
                else
                {
                    this.Close();
                }
                
            }
            else if (_modo == "Editar")
            {
                
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
