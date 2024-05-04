using Sigesoft.Node.WinClient.BLL;
using Sigesoft.Node.WinClient.UI.Operations;
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
    public partial class frmPacientInformacion : Form
    {
        PacientBL _PacientBL = new PacientBL();
        string personId;
        public frmPacientInformacion(string _personId)
        {
            personId = _personId;
            InitializeComponent();
        }

        private void frmPacientInformacion_Load(object sender, EventArgs e)
        {
            var data = _PacientBL.GetPersonPersonalInformationESO(personId);
            lblHistoriaClinica.Text = data.Historia;
            txtPaciente.Text = data.Paciente;
            txtDni.Text = data.Dni;
            txtGenero.Text = data.Genero;
            txtLugarNacimiento.Text = data.FNacimiento;
            txtEstadoCivil.Text = data.EstadoCivil;
            txtNivelEstudios.Text = data.NivelEstudios;
            txtEmail.Text = data.Email;
            txtTelefono.Text = data.Telefono;
            txtDireccion.Text = data.Direccion;
            pbFoto.Image = null;
            pbFoto.ImageLocation = null;
            pbFoto.Image = Common.Utils.BytesArrayToImage(data.Foto, pbFoto);
            txtDistrito.Text = data.Distrito;
            txtProvincia.Text = data.Provincia;
            txtDepartamento.Text = data.Departamento;
            txtReligion.Text = data.Religion;
            txtHijos.Text = data.Hijos.ToString();
            txtOcupacion.Text = data.Ocupacion;
            txtNacionalidad.Text = data.Nacionalidad;
            txtContactoEm.Text = data.ContactoEm;
            txtTelefonoEm.Text = data.TelefonoEm;

            lblPersonId.Text = data.IdPersona;
        }

        private void btnAnexoHistoriaManual_Click(object sender, EventArgs e)
        {
            try
            {
                string pacientId = lblPersonId.Text;

                string Person = txtPaciente.Text;


                frmAnexoHistoriaManual frm = new frmAnexoHistoriaManual(Person, pacientId);
                frm.ShowDialog();
            }
            catch (Exception)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string pacientId = lblPersonId.Text;

                frmHistorialAtenciones frm = new frmHistorialAtenciones(pacientId);
                frm.ShowDialog();
            }
            catch (Exception)
            {

            }
        }

        private void btnAntecedentes_Click(object sender, EventArgs e)
        {
            try
            {
                string pstrPacientId = lblPersonId.Text;

                frmHistory frm = new frmHistory(pstrPacientId);
                frm.ShowDialog();
            }
            catch (Exception)
            {

            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                string pstrPacientId = lblPersonId.Text;

                frmPacient frm = new frmPacient(pstrPacientId);
                frm.ShowDialog();
            }
            catch (Exception)
            {

            }
        }

    }
}
