using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sigesoft.Node.WinClient.UI.Operations
{
    public partial class frmAnexoHistoriaManual : Form
    {
        private string Paciente;
        private string PersonId;
        public frmAnexoHistoriaManual(string _Paciente, string _PersonId)
        {
            Paciente = _Paciente;
            PersonId = _PersonId;

            InitializeComponent();
        }

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = string.Empty;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var fileSize = Convert.ToInt32(Convert.ToSingle(Common.Utils.GetFileSizeInMegabytes(openFileDialog1.FileName)));

                if (fileSize > 12)
                {
                    MessageBox.Show("El archivo que esta tratando de subir es damasiado grande.\nEl tamaño maximo es de 12 MB.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                txtFileName.Text = Path.GetFileName(openFileDialog1.FileName);
                btnAceptar.Enabled = true;
            }
            else
            {
                return;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                string ruta = Common.Utils.GetApplicationConfigValue("HistoriasManuales").ToString();
                string destino = ruta + PersonId + "-" + Paciente + ".pdf";
                if (File.Exists(destino))
                {
                    System.IO.File.Delete(destino);
                    File.Copy(openFileDialog1.FileName, destino);
                }
                else { File.Copy(openFileDialog1.FileName, destino); }
                MessageBox.Show("El archivo se anexó correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //this.Close();
                HistoriasMedicasAdjuntas(PersonId);
                btnAceptar.Enabled = false;
            }
            catch (Exception)
            {
            }
        }

        private void HistoriasMedicasAdjuntas(string person)
        {
            try
            {
                var consolidado = Common.Utils.GetApplicationConfigValue("HistoriasManuales").ToString();
                string _rutaconsolidado = consolidado + "\\";

                string fileName = _rutaconsolidado + person + "-" + Paciente + ".pdf";

                if (File.Exists(fileName))
                {
                    try
                    {
                        panelMensaje.Visible = false;

                        pdfAnexoAdjunto.src = fileName;
                    }
                    catch (Exception f)
                    {
                        panelMensaje.Visible = true;
                    }
                }
                else
                {
                    panelMensaje.Visible = true;
                }

            }
            catch (Exception)
            {
                //panelMensaje.Visible = true;
                //panelMensaje.Dock = DockStyle.Fill;
                //throw;
            }


        }
        private void frmAnexoHistoriaManual_Load(object sender, EventArgs e)
        {
            HistoriasMedicasAdjuntas(PersonId);
        }
    }
}
