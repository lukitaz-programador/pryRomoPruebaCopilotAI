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
    public partial class FrmMedicos : Form
    {
        private AccesoDatos accesoDatos;

        public FrmMedicos()
        {
            InitializeComponent();
            accesoDatos = new AccesoDatos();
        }

        private void FrmMedicos_Load(object sender, EventArgs e)
        {
            CargarEspecialidades();
        }

        private void CargarEspecialidades()
        {
            DataTable dt = accesoDatos.EjecutarConsulta("SELECT ID_Especialidad, Nombre_Especialidad FROM Especialidades ORDER BY Nombre_Especialidad");
            
            if (dt != null)
            {
                chkEspecialidades.Items.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    chkEspecialidades.Items.Add($"{row["Nombre_Especialidad"]}", false);
                }
            }
        }

        private void btnGuardarRegistro_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMatricula.Text))
            {
                MessageBox.Show("Por favor, ingrese la matrícula", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNombreCompleto.Text))
            {
                MessageBox.Show("Por favor, ingrese el nombre completo", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (chkEspecialidades.CheckedItems.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione al menos una especialidad", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string matricula = txtMatricula.Text.Trim();
            string nombre = txtNombreCompleto.Text.Trim();

            // Insertar médico
            string queryMedico = $"INSERT INTO Medicos (Matricula, Nombre_Completo) VALUES ('{matricula.Replace("'", "''")}', '{nombre.Replace("'", "''")}')";

            if (accesoDatos.EjecutarComando(queryMedico))
            {
                // Insertar especialidades
                DataTable dtEspecialidades = accesoDatos.EjecutarConsulta("SELECT ID_Especialidad, Nombre_Especialidad FROM Especialidades ORDER BY Nombre_Especialidad");
                
                foreach (int index in chkEspecialidades.CheckedIndices)
                {
                    int idEspecialidad = Convert.ToInt32(dtEspecialidades.Rows[index]["ID_Especialidad"]);
                    string queryAsignacion = $"INSERT INTO Medico_Especialidad (Matricula, ID_Especialidad) VALUES ('{matricula}', {idEspecialidad})";
                    accesoDatos.EjecutarComando(queryAsignacion);
                }

                MessageBox.Show("Médico registrado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormulario();
            }
        }

        private void LimpiarFormulario()
        {
            txtMatricula.Clear();
            txtNombreCompleto.Clear();
            
            for (int i = 0; i < chkEspecialidades.Items.Count; i++)
            {
                chkEspecialidades.SetItemChecked(i, false);
            }

            txtMatricula.Focus();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }
    }
}
