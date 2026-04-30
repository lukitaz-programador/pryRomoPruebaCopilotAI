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
    public partial class FrmEspecialidades : Form
    {
        private AccesoDatos accesoDatos;

        public FrmEspecialidades()
        {
            InitializeComponent();
            accesoDatos = new AccesoDatos();
        }

        private void FrmEspecialidades_Load(object sender, EventArgs e)
        {
            CargarEspecialidades();
        }

        private void CargarEspecialidades()
        {
            DataTable dt = accesoDatos.EjecutarConsulta("SELECT ID_Especialidad, Nombre_Especialidad FROM Especialidades ORDER BY Nombre_Especialidad");
            
            if (dt != null)
            {
                dgvEspecialidades.DataSource = dt;
                dgvEspecialidades.Columns[0].HeaderText = "ID";
                dgvEspecialidades.Columns[1].HeaderText = "Nombre de Especialidad";
                dgvEspecialidades.Columns[0].Width = 50;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreEspecialidad.Text))
            {
                MessageBox.Show("Por favor, ingrese un nombre de especialidad", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nombre = txtNombreEspecialidad.Text.Trim();
            string query = $"INSERT INTO Especialidades (Nombre_Especialidad) VALUES ('{nombre.Replace("'", "''")}')";

            if (accesoDatos.EjecutarComando(query))
            {
                MessageBox.Show("Especialidad agregada correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNombreEspecialidad.Clear();
                CargarEspecialidades();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombreEspecialidad.Clear();
            txtNombreEspecialidad.Focus();
        }
    }
}
