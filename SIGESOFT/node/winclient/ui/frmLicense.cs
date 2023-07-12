using Sigesoft.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sigesoft.Node.WinClient.UI
{
    public partial class frmLicense : Form
    {
        private string _PhysicalAdress;
        public frmLicense(string PhysicalAdress)
        {
            _PhysicalAdress = PhysicalAdress;
            InitializeComponent();
        }

        private void frmLicense_Load(object sender, EventArgs e)
        {
            frmLicense.ActiveForm.MinimizeBox = false;
            frmLicense.ActiveForm.MaximizeBox = false;
        }

        private void btnLicense_Click(object sender, EventArgs e)
        {
            string path=""; string line; string lic = "";
          
            using (var fd = new FolderBrowserDialog())
            {
                if (fd.ShowDialog() == System.Windows.Forms.DialogResult.OK && !string.IsNullOrWhiteSpace(fd.SelectedPath))
                {
                    path = fd.SelectedPath;
                }
            }
            System.IO.StreamReader file = new System.IO.StreamReader(path + @"\LicSanMarcos.lic");
            if (File.Exists(path + @"\LicSanMarcos.lic"))
            {
                while ((line = file.ReadLine()) != null)
                {
                    lic = line;
                }

                if (lic == "Alph@2536")
                {
                    ActualizarRegistro(_PhysicalAdress);
                    MessageBox.Show("La licencia ha sido aceptada", "Licencia aceptada!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                else
                {
                    MessageBox.Show("La licencia no es correcta", "Error de licencia !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("La licencia no existe", "No existe licencia !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            
        }

        private void ActualizarRegistro(string _PhysicalAdress)
        {
            using (new LoadingClass.PleaseWait(this.Location, "Generando..."))
            {
                ConexionSigesoft conectasam = new ConexionSigesoft();
                conectasam.opensigesoft();
                var cadena1 = "INSERT INTO [dbo].[Account] (Account) " +
                              "VALUES ('"+_PhysicalAdress+"');";
                SqlCommand comando = new SqlCommand(cadena1, connection: conectasam.conectarsigesoft);
                SqlDataReader lector = comando.ExecuteReader();
                lector.Close();
                conectasam.closesigesoft();
            };
        }
    }
}
