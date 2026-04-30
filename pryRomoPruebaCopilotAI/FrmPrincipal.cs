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
    public partial class FrmPrincipal : Form
    {
        private AccesoDatos accesoDatos;

        public FrmPrincipal()
        {
            InitializeComponent();
            accesoDatos = new AccesoDatos();
            this.IsMdiContainer = true;
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            accesoDatos.CrearBaseDatos();
            
            if (!accesoDatos.VerificarConexion())
            {
                MessageBox.Show("No se pudo conectar a la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            else
            {
                lblEstado.Text = "CONECTADO / CONECTADO";
                lblEstado.ForeColor = Color.LimeGreen;
            }
        }

        private void EspecialidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(typeof(FrmEspecialidades), "Registro de Especialidades");
        }

        private void MedicosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(typeof(FrmMedicos), "Registro de Médicos");
        }

        private void ConsultasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(typeof(FrmConsultas), "Consultas de Personal Médico");
        }

        private void MantenimientoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(typeof(FrmMantenimiento), "Eliminación y Modificación de Médicos");
        }

        private void AbrirFormulario(Type tipo, string titulo)
        {
            Form frm = null;
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == tipo)
                {
                    f.Activate();
                    return;
                }
            }

            frm = (Form)Activator.CreateInstance(tipo);
            frm.MdiParent = this;
            frm.Text = titulo;
            frm.Show();
        }
    }
}
