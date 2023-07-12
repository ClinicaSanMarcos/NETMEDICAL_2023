using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Sigesoft.Node.WinClient.BLL;
using System.IO;

namespace Sigesoft.Node.WinClient.UI
{
    public partial class frmRecordsMarkings : Form
    {
        public frmRecordsMarkings()
        {
            InitializeComponent();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            BindingChart();
        }

        private void BindingChart()
        {
            int type = 0; //puntuales
            string title = "Top " + txtTopRegistros.Text + " de trabajadores más puntuales en el mes de " + cboMes.Text + ".";
            chart1.ChartAreas[0].AxisY.Title = "Horas no trabajas - Tardanzas";
            if (rdoTardanzas.Checked)
            {
                type = 1; //tardanzas
                title = "Top " + txtTopRegistros.Text + " de trabajadores con más tardanzas en el mes de " + cboMes.Text + ".";
            }
            else if (rdoHorasExtras.Checked)
            {
                chart1.ChartAreas[0].AxisY.Title = "Horas extras";
                type = 2; //horas extras
                title = "Top " + txtTopRegistros.Text + " de trabajadores con más hroas extras en el mes de " + cboMes.Text + ".";
            }

            int top = int.Parse(txtTopRegistros.Text);
            var records = new WorkerScheduleBL().GetDataChart(cboMes.Text, top, type);
            this.chart1.Palette = ChartColorPalette.SeaGreen;
            this.chart1.Titles.Clear();
            this.chart1.Titles.Add(title);
            this.chart1.Series.Clear();

            foreach (var item in records)
            {
                Series series = this.chart1.Series.Add(item.Name);
                series.Points.Add(item.Hours.Value.TotalHours);

                var str = item.Hours.Value.Days.ToString("00") + " días " + item.Hours.Value.Hours.ToString("00") + " hrs " + item.Hours.Value.Minutes.ToString("00") + " mn";
                if (type == 0)
                {
                    series.ToolTip = "Hrs Notrabajadas(" + str + "), #SERIESNAME";
                }
                else
                {
                    series.ToolTip = str + ", #SERIESNAME";
                }
            }
            
        }

        private void txtTopRegistros_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verify that the pressed key isn't CTRL or any non-numeric digit
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // If you want, you can allow decimal (float) numbers
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void frmRecordsMarkings_Load(object sender, EventArgs e)
        {
            int mes = DateTime.Now.Month - 1;
            cboMes.SelectedIndex = mes;
            BindingChart();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "JPeg Imagen|*.jpg|Bitmap Imagen|*.bmp|PNG Imagen|*.png";
            saveFileDialog1.Title = "Guardar gráfico";
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                FileStream fs = (FileStream)saveFileDialog1.OpenFile();
                switch (saveFileDialog1.FilterIndex)
                {
                    case 1:
                        this.chart1.SaveImage(fs, ChartImageFormat.Jpeg);
                        break;
                    case 2:
                        this.chart1.SaveImage(fs, ChartImageFormat.Bmp);
                        break;
                    case 3:
                        this.chart1.SaveImage(fs, ChartImageFormat.Png);
                        break;
                }
                fs.Close();
            }
        }
    }
}
