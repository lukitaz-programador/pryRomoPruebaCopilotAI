namespace pryRomoPruebaCopilotAI
{
    partial class FrmMantenimiento
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTituloConsultas = new System.Windows.Forms.Label();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dgvMedicos = new System.Windows.Forms.DataGridView();
            this.lblTituloModificacion = new System.Windows.Forms.Label();
            this.lblNombreMedicoSeleccionado = new System.Windows.Forms.Label();
            this.lblEspecialidades = new System.Windows.Forms.Label();
            this.chkEspecialidades = new System.Windows.Forms.CheckedListBox();
            this.btnActualizarEspecialidades = new System.Windows.Forms.Button();
            this.btnEliminarMedica = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicos)).BeginInit();
            this.SuspendLayout();

            this.lblTituloConsultas.AutoSize = true;
            this.lblTituloConsultas.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblTituloConsultas.ForeColor = System.Drawing.Color.White;
            this.lblTituloConsultas.Location = new System.Drawing.Point(20, 20);
            this.lblTituloConsultas.Name = "lblTituloConsultas";
            this.lblTituloConsultas.Size = new System.Drawing.Size(289, 24);
            this.lblTituloConsultas.TabIndex = 0;
            this.lblTituloConsultas.Text = "Consultas de Personal Médico";

            this.lblBuscar.AutoSize = true;
            this.lblBuscar.ForeColor = System.Drawing.Color.White;
            this.lblBuscar.Location = new System.Drawing.Point(20, 60);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(40, 13);
            this.lblBuscar.TabIndex = 1;
            this.lblBuscar.Text = "Buscar";

            this.txtBuscar.Location = new System.Drawing.Point(20, 77);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(350, 20);
            this.txtBuscar.TabIndex = 2;

            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(200)))));
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(375, 77);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(70, 20);
            this.btnBuscar.TabIndex = 3;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);

            this.dgvMedicos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(90)))));
            this.dgvMedicos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMedicos.Location = new System.Drawing.Point(20, 110);
            this.dgvMedicos.Name = "dgvMedicos";
            this.dgvMedicos.ReadOnly = true;
            this.dgvMedicos.Size = new System.Drawing.Size(1000, 220);
            this.dgvMedicos.TabIndex = 4;

            this.lblTituloModificacion.AutoSize = true;
            this.lblTituloModificacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblTituloModificacion.ForeColor = System.Drawing.Color.White;
            this.lblTituloModificacion.Location = new System.Drawing.Point(20, 350);
            this.lblTituloModificacion.Name = "lblTituloModificacion";
            this.lblTituloModificacion.Size = new System.Drawing.Size(288, 24);
            this.lblTituloModificacion.TabIndex = 5;
            this.lblTituloModificacion.Text = "Modificar Doctor Seleccionado";

            this.lblNombreMedicoSeleccionado.AutoSize = true;
            this.lblNombreMedicoSeleccionado.ForeColor = System.Drawing.Color.White;
            this.lblNombreMedicoSeleccionado.Location = new System.Drawing.Point(20, 390);
            this.lblNombreMedicoSeleccionado.Name = "lblNombreMedicoSeleccionado";
            this.lblNombreMedicoSeleccionado.Size = new System.Drawing.Size(74, 13);
            this.lblNombreMedicoSeleccionado.TabIndex = 6;
            this.lblNombreMedicoSeleccionado.Text = "Nº Matrícula: ";

            this.lblEspecialidades.AutoSize = true;
            this.lblEspecialidades.ForeColor = System.Drawing.Color.White;
            this.lblEspecialidades.Location = new System.Drawing.Point(20, 415);
            this.lblEspecialidades.Name = "lblEspecialidades";
            this.lblEspecialidades.Size = new System.Drawing.Size(95, 13);
            this.lblEspecialidades.TabIndex = 7;
            this.lblEspecialidades.Text = "Actualizar su Especialidades (Pre-cargadas):";

            this.chkEspecialidades.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(90)))));
            this.chkEspecialidades.ForeColor = System.Drawing.Color.White;
            this.chkEspecialidades.Location = new System.Drawing.Point(20, 432);
            this.chkEspecialidades.Name = "chkEspecialidades";
            this.chkEspecialidades.Size = new System.Drawing.Size(350, 80);
            this.chkEspecialidades.TabIndex = 8;

            this.btnActualizarEspecialidades.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(100)))));
            this.btnActualizarEspecialidades.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizarEspecialidades.ForeColor = System.Drawing.Color.White;
            this.btnActualizarEspecialidades.Location = new System.Drawing.Point(20, 520);
            this.btnActualizarEspecialidades.Name = "btnActualizarEspecialidades";
            this.btnActualizarEspecialidades.Size = new System.Drawing.Size(150, 35);
            this.btnActualizarEspecialidades.TabIndex = 9;
            this.btnActualizarEspecialidades.Text = "Actualizar Especialidades";
            this.btnActualizarEspecialidades.UseVisualStyleBackColor = false;
            this.btnActualizarEspecialidades.Click += new System.EventHandler(this.btnActualizarEspecialidades_Click);

            this.btnEliminarMedica.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnEliminarMedica.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarMedica.ForeColor = System.Drawing.Color.White;
            this.btnEliminarMedica.Location = new System.Drawing.Point(180, 520);
            this.btnEliminarMedica.Name = "btnEliminarMedica";
            this.btnEliminarMedica.Size = new System.Drawing.Size(150, 35);
            this.btnEliminarMedica.TabIndex = 10;
            this.btnEliminarMedica.Text = "Eliminar Médica";
            this.btnEliminarMedica.UseVisualStyleBackColor = false;
            this.btnEliminarMedica.Click += new System.EventHandler(this.btnEliminarMedica_Click);

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(32)))), ((int)(((byte)(71)))));
            this.ClientSize = new System.Drawing.Size(1050, 580);
            this.Controls.Add(this.btnEliminarMedica);
            this.Controls.Add(this.btnActualizarEspecialidades);
            this.Controls.Add(this.chkEspecialidades);
            this.Controls.Add(this.lblEspecialidades);
            this.Controls.Add(this.lblNombreMedicoSeleccionado);
            this.Controls.Add(this.lblTituloModificacion);
            this.Controls.Add(this.dgvMedicos);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.lblBuscar);
            this.Controls.Add(this.lblTituloConsultas);
            this.Name = "FrmMantenimiento";
            this.Text = "Mantenimiento";
            this.Load += new System.EventHandler(this.FrmMantenimiento_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTituloConsultas;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridView dgvMedicos;
        private System.Windows.Forms.Label lblTituloModificacion;
        private System.Windows.Forms.Label lblNombreMedicoSeleccionado;
        private System.Windows.Forms.Label lblEspecialidades;
        private System.Windows.Forms.CheckedListBox chkEspecialidades;
        private System.Windows.Forms.Button btnActualizarEspecialidades;
        private System.Windows.Forms.Button btnEliminarMedica;
    }
}
