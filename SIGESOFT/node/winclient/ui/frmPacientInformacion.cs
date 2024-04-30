using Sigesoft.Node.WinClient.BLL;
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
        }

    }
}
