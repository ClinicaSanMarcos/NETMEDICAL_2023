using Sigesoft.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sigesoft.Node.WinClient.UI.Hospitalizacion
{
    public partial class frmInformacionComplementaria : Form
    {
        public string HospitalizacionId;
        private OperationResult _objOperationResult = new OperationResult();

        string ServicioId = "";
        int Procedimiento = 0;
        int TipoIngreso = 0;

        public frmInformacionComplementaria(string _HospitalizacionId)
        {
            HospitalizacionId = _HospitalizacionId;

            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rbAmbulatorio_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void frmInformacionComplementaria_Load(object sender, EventArgs e)
        {
            OperationResult objOperationResult = new OperationResult();

            #region Conexion
            ConexionSigesoft conectasam = new ConexionSigesoft();
            conectasam.opensigesoft();
            #endregion
            var cadena1 = @"select ISNULL(i_TipoProcedimiento, 0) as Procedimiento,
                            ISNULL((select TOP 1 s.i_ProcedenciaAtencion from hospitalizacionservice hs JOIN service s on hs.v_ServiceId = s.v_ServiceId  where hs.v_HopitalizacionId = h.v_HopitalizacionId),0) as TipoIngreso, 
                            (select TOP 1 s.v_ServiceId from hospitalizacionservice hs JOIN service s on hs.v_ServiceId = s.v_ServiceId  where hs.v_HopitalizacionId = h.v_HopitalizacionId) as ServicioId
                            from hospitalizacion h
                            where v_HopitalizacionId =  '" + HospitalizacionId + "'";

            SqlCommand comando = new SqlCommand(cadena1, connection: conectasam.conectarsigesoft);
            SqlDataReader lector = comando.ExecuteReader();
            
            while (lector.Read())
            {
                Procedimiento = int.Parse(lector.GetValue(0).ToString());
                TipoIngreso = int.Parse(lector.GetValue(1).ToString());
                ServicioId = lector.GetValue(2).ToString();

            }
            lector.Close();
            conectasam.closesigesoft();

            if (TipoIngreso == 1)
            {
                rbAmbulatorio.Checked = true;
                rbEmergencia.Checked = false;
                rbAlquiler.Checked = false;

            }
            else if (TipoIngreso == 2)
            {
                rbAmbulatorio.Checked = false;
                rbEmergencia.Checked = true;
                rbAlquiler.Checked = false;
            }
            else if (TipoIngreso == 3)
            {
                rbAmbulatorio.Checked = false;
                rbEmergencia.Checked = false;
                rbAlquiler.Checked = true;
            }
            else
            {
                rbAmbulatorio.Checked = false;
                rbEmergencia.Checked = false;
                rbAlquiler.Checked = false;
            }


            if (Procedimiento == 1)
            {
                rbQuirurgico.Checked = true;
                rbNoQuirurgico.Checked = false;

            }
            else if (Procedimiento == 2)
            {
                rbQuirurgico.Checked = false;
                rbNoQuirurgico.Checked = true;
            }
            else
            {
                rbQuirurgico.Checked = false;
                rbNoQuirurgico.Checked = false;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            int tipoIngreso_ = 0;
            if (rbAmbulatorio.Checked == true)
            {
                tipoIngreso_ = 1;
            }
            else if (rbEmergencia.Checked == true)
            {
                tipoIngreso_ = 2;
            }
            else if (rbAlquiler.Checked == true)
            {
                tipoIngreso_ = 3;
            }
            else
            {
                MessageBox.Show("Seleccione Tipo de Ingreso.", "Advertencia!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int procedimiento_ = 0;

            if (rbQuirurgico.Checked == true)
            {
                procedimiento_ = 1;
            }
            else if (rbNoQuirurgico.Checked == true)
            {
                procedimiento_ = 2;
            }
            else
            {
                MessageBox.Show("Seleccione Tipo de Procedimiento.", "Advertencia!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            ConexionSigesoft conectasam = new ConexionSigesoft();
            conectasam.opensigesoft();

            var cadena1 = "update hospitalizacion set i_TipoProcedimiento = " + procedimiento_ + " where v_HopitalizacionId = '" + HospitalizacionId + "'";
            SqlCommand comando = new SqlCommand(cadena1, connection: conectasam.conectarsigesoft);
            SqlDataReader lector = comando.ExecuteReader();
            lector.Close();

            var cadena2 = "update service set i_ProcedenciaAtencion = " + tipoIngreso_ + " where v_ServiceId = '" + ServicioId + "'";
            SqlCommand comando2 = new SqlCommand(cadena2, connection: conectasam.conectarsigesoft);
            SqlDataReader lector2 = comando2.ExecuteReader();
            lector2.Close();
              
            conectasam.closesigesoft();
             


            this.Close();
            MessageBox.Show("Guardado con éxito.", "Guardado!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
