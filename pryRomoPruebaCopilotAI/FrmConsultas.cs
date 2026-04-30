using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryRomoPruebaCopilotAI
{
    public partial class FrmConsultas : Form
    {
        private AccesoDatos accesoDatos;

        public FrmConsultas()
        {
            InitializeComponent();
            accesoDatos = new AccesoDatos();
        }

        private void FrmConsultas_Load(object sender, EventArgs e)
        {
            CargarMedicos();
        }

        private void CargarMedicos()
        {
            string query = @"
                SELECT m.Matricula, m.Nombre_Completo, 
                       GROUP_CONCAT(e.Nombre_Especialidad, ', ') AS Especialidades
                FROM Medicos m
                LEFT JOIN Medico_Especialidad me ON m.Matricula = me.Matricula
                LEFT JOIN Especialidades e ON me.ID_Especialidad = e.ID_Especialidad
                GROUP BY m.Matricula, m.Nombre_Completo
                ORDER BY m.Nombre_Completo
            ";

            // Access no soporta GROUP_CONCAT, usar alternativa
            DataTable dt = accesoDatos.EjecutarConsulta("SELECT Matricula, Nombre_Completo FROM Medicos ORDER BY Nombre_Completo");
            
            if (dt != null)
            {
                DataTable dtCompleta = new DataTable();
                dtCompleta.Columns.Add("Matricula");
                dtCompleta.Columns.Add("Nombre Médico");
                dtCompleta.Columns.Add("Especialidades Asignadas");

                foreach (DataRow row in dt.Rows)
                {
                    string matricula = row["Matricula"].ToString();
                    string nombre = row["Nombre_Completo"].ToString();

                    DataTable dtEsp = accesoDatos.EjecutarConsulta($"SELECT e.Nombre_Especialidad FROM Medico_Especialidad me JOIN Especialidades e ON me.ID_Especialidad = e.ID_Especialidad WHERE me.Matricula = '{matricula}'");
                    
                    string especialidades = "";
                    if (dtEsp != null && dtEsp.Rows.Count > 0)
                    {
                        especialidades = string.Join(", ", dtEsp.AsEnumerable().Select(r => r["Nombre_Especialidad"].ToString()));
                    }

                    dtCompleta.Rows.Add(matricula, nombre, especialidades);
                }

                dgvMedicos.DataSource = dtCompleta;
                dgvMedicos.Columns[0].Width = 80;
                dgvMedicos.Columns[1].Width = 150;
                dgvMedicos.Columns[2].Width = 250;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                CargarMedicos();
                return;
            }

            string busqueda = txtBuscar.Text.Trim();
            DataTable dt = accesoDatos.EjecutarConsulta($"SELECT Matricula, Nombre_Completo FROM Medicos WHERE Matricula LIKE '%{busqueda}%' OR Nombre_Completo LIKE '%{busqueda}%' ORDER BY Nombre_Completo");
            
            if (dt != null)
            {
                DataTable dtCompleta = new DataTable();
                dtCompleta.Columns.Add("Matricula");
                dtCompleta.Columns.Add("Nombre Médico");
                dtCompleta.Columns.Add("Especialidades Asignadas");

                foreach (DataRow row in dt.Rows)
                {
                    string matricula = row["Matricula"].ToString();
                    string nombre = row["Nombre_Completo"].ToString();

                    DataTable dtEsp = accesoDatos.EjecutarConsulta($"SELECT e.Nombre_Especialidad FROM Medico_Especialidad me JOIN Especialidades e ON me.ID_Especialidad = e.ID_Especialidad WHERE me.Matricula = '{matricula}'");
                    
                    string especialidades = "";
                    if (dtEsp != null && dtEsp.Rows.Count > 0)
                    {
                        especialidades = string.Join(", ", dtEsp.AsEnumerable().Select(r => r["Nombre_Especialidad"].ToString()));
                    }

                    dtCompleta.Rows.Add(matricula, nombre, especialidades);
                }

                dgvMedicos.DataSource = dtCompleta;
            }
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnBuscar_Click(null, null);
                e.Handled = true;
            }
        }
    }
}
