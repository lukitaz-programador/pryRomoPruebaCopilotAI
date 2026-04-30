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
    public partial class FrmMantenimiento : Form
    {
        private AccesoDatos accesoDatos;
        private string matriculaActual = "";

        public FrmMantenimiento()
        {
            InitializeComponent();
            accesoDatos = new AccesoDatos();
        }

        private void FrmMantenimiento_Load(object sender, EventArgs e)
        {
            CargarMedicosEnDataGrid();
            CargarEspecialidades();
        }

        private void CargarMedicosEnDataGrid()
        {
            DataTable dt = accesoDatos.EjecutarConsulta("SELECT Matricula, Nombre_Completo FROM Medicos ORDER BY Nombre_Completo");
            
            if (dt != null)
            {
                DataTable dtCompleta = new DataTable();
                dtCompleta.Columns.Add("Matricula");
                dtCompleta.Columns.Add("Nombre Médico");
                dtCompleta.Columns.Add("Especialidades Asignadas");
                dtCompleta.Columns.Add("Acciones");

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

                    dtCompleta.Rows.Add(matricula, nombre, especialidades, "Editar / Eliminar");
                }

                dgvMedicos.DataSource = dtCompleta;
                dgvMedicos.Columns[0].Width = 80;
                dgvMedicos.Columns[1].Width = 150;
                dgvMedicos.Columns[2].Width = 250;
                dgvMedicos.Columns[3].Width = 120;
            }
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                MessageBox.Show("Por favor, ingrese una matrícula para buscar", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string matricula = txtBuscar.Text.Trim();
            DataTable dt = accesoDatos.EjecutarConsulta($"SELECT Nombre_Completo FROM Medicos WHERE Matricula = '{matricula}'");
            
            if (dt != null && dt.Rows.Count > 0)
            {
                matriculaActual = matricula;
                lblNombreMedicoSeleccionado.Text = $"Dra. {dt.Rows[0]["Nombre_Completo"]}";
                
                // Cargar especialidades actuales
                DataTable dtEsp = accesoDatos.EjecutarConsulta($"SELECT e.ID_Especialidad FROM Medico_Especialidad me JOIN Especialidades e ON me.ID_Especialidad = e.ID_Especialidad WHERE me.Matricula = '{matricula}'");
                
                for (int i = 0; i < chkEspecialidades.Items.Count; i++)
                {
                    chkEspecialidades.SetItemChecked(i, false);
                }

                if (dtEsp != null)
                {
                    foreach (DataRow row in dtEsp.Rows)
                    {
                        int idEsp = Convert.ToInt32(row["ID_Especialidad"]);
                        DataTable dtNombre = accesoDatos.EjecutarConsulta($"SELECT Nombre_Especialidad FROM Especialidades WHERE ID_Especialidad = {idEsp}");
                        if (dtNombre != null && dtNombre.Rows.Count > 0)
                        {
                            string nombre = dtNombre.Rows[0]["Nombre_Especialidad"].ToString();
                            for (int i = 0; i < chkEspecialidades.Items.Count; i++)
                            {
                                if (chkEspecialidades.Items[i].ToString().Contains(nombre))
                                {
                                    chkEspecialidades.SetItemChecked(i, true);
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No se encontró médico con esa matrícula", "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnActualizarEspecialidades_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(matriculaActual))
            {
                MessageBox.Show("Por favor, busque un médico primero", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Eliminar especialidades actuales
            accesoDatos.EjecutarComando($"DELETE FROM Medico_Especialidad WHERE Matricula = '{matriculaActual}'");

            // Agregar nuevas especialidades
            DataTable dtEspecialidades = accesoDatos.EjecutarConsulta("SELECT ID_Especialidad, Nombre_Especialidad FROM Especialidades ORDER BY Nombre_Especialidad");
            
            foreach (int index in chkEspecialidades.CheckedIndices)
            {
                int idEspecialidad = Convert.ToInt32(dtEspecialidades.Rows[index]["ID_Especialidad"]);
                string query = $"INSERT INTO Medico_Especialidad (Matricula, ID_Especialidad) VALUES ('{matriculaActual}', {idEspecialidad})";
                accesoDatos.EjecutarComando(query);
            }

            MessageBox.Show("Especialidades actualizadas correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CargarMedicosEnDataGrid();
        }

        private void btnEliminarMedica_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(matriculaActual))
            {
                MessageBox.Show("Por favor, busque un médico primero", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("¿Está seguro de que desea eliminar este médico?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                accesoDatos.EjecutarComando($"DELETE FROM Medico_Especialidad WHERE Matricula = '{matriculaActual}'");
                accesoDatos.EjecutarComando($"DELETE FROM Medicos WHERE Matricula = '{matriculaActual}'");

                MessageBox.Show("Médico eliminado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                txtBuscar.Clear();
                lblNombreMedicoSeleccionado.Text = "Nº Matrícula: ";
                matriculaActual = "";
                
                for (int i = 0; i < chkEspecialidades.Items.Count; i++)
                {
                    chkEspecialidades.SetItemChecked(i, false);
                }
                
                CargarMedicosEnDataGrid();
            }
        }
    }
}
