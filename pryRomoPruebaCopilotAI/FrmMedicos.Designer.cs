namespace pryRomoPruebaCopilotAI
{
    partial class FrmMedicos
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblMatricula = new System.Windows.Forms.Label();
            this.txtMatricula = new System.Windows.Forms.TextBox();
            this.lblNombreCompleto = new System.Windows.Forms.Label();
            this.txtNombreCompleto = new System.Windows.Forms.TextBox();
            this.lblAsignacionEspecialidades = new System.Windows.Forms.Label();
            this.chkEspecialidades = new System.Windows.Forms.CheckedListBox();
            this.btnGuardarRegistro = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.SuspendLayout();

            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(20, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(253, 26);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Registro de Nuevo Médico";

            this.lblMatricula.AutoSize = true;
            this.lblMatricula.ForeColor = System.Drawing.Color.White;
            this.lblMatricula.Location = new System.Drawing.Point(20, 65);
            this.lblMatricula.Name = "lblMatricula";
            this.lblMatricula.Size = new System.Drawing.Size(59, 13);
            this.lblMatricula.TabIndex = 1;
            this.lblMatricula.Text = "Nº Matrícula:";

            this.txtMatricula.Location = new System.Drawing.Point(20, 82);
            this.txtMatricula.Name = "txtMatricula";
            this.txtMatricula.Size = new System.Drawing.Size(200, 20);
            this.txtMatricula.TabIndex = 2;

            this.lblNombreCompleto.AutoSize = true;
            this.lblNombreCompleto.ForeColor = System.Drawing.Color.White;
            this.lblNombreCompleto.Location = new System.Drawing.Point(20, 115);
            this.lblNombreCompleto.Name = "lblNombreCompleto";
            this.lblNombreCompleto.Size = new System.Drawing.Size(98, 13);
            this.lblNombreCompleto.TabIndex = 3;
            this.lblNombreCompleto.Text = "Nombre Completo:";

            this.txtNombreCompleto.Location = new System.Drawing.Point(20, 132);
            this.txtNombreCompleto.Name = "txtNombreCompleto";
            this.txtNombreCompleto.Size = new System.Drawing.Size(350, 20);
            this.txtNombreCompleto.TabIndex = 4;

            this.lblAsignacionEspecialidades.AutoSize = true;
            this.lblAsignacionEspecialidades.ForeColor = System.Drawing.Color.White;
            this.lblAsignacionEspecialidades.Location = new System.Drawing.Point(20, 165);
            this.lblAsignacionEspecialidades.Name = "lblAsignacionEspecialidades";
            this.lblAsignacionEspecialidades.Size = new System.Drawing.Size(275, 13);
            this.lblAsignacionEspecialidades.TabIndex = 5;
            this.lblAsignacionEspecialidades.Text = "Asignación de Especialidades (Pre-cargadas):";

            this.chkEspecialidades.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(90)))));
            this.chkEspecialidades.ForeColor = System.Drawing.Color.White;
            this.chkEspecialidades.Location = new System.Drawing.Point(20, 182);
            this.chkEspecialidades.Name = "chkEspecialidades";
            this.chkEspecialidades.Size = new System.Drawing.Size(350, 150);
            this.chkEspecialidades.TabIndex = 6;

            this.btnGuardarRegistro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(100)))));
            this.btnGuardarRegistro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarRegistro.ForeColor = System.Drawing.Color.White;
            this.btnGuardarRegistro.Location = new System.Drawing.Point(20, 345);
            this.btnGuardarRegistro.Name = "btnGuardarRegistro";
            this.btnGuardarRegistro.Size = new System.Drawing.Size(100, 35);
            this.btnGuardarRegistro.TabIndex = 7;
            this.btnGuardarRegistro.Text = "Guardar Registro";
            this.btnGuardarRegistro.UseVisualStyleBackColor = false;
            this.btnGuardarRegistro.Click += new System.EventHandler(this.btnGuardarRegistro_Click);

            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.Location = new System.Drawing.Point(130, 345);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(100, 35);
            this.btnLimpiar.TabIndex = 8;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(32)))), ((int)(((byte)(71)))));
            this.ClientSize = new System.Drawing.Size(400, 410);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnGuardarRegistro);
            this.Controls.Add(this.chkEspecialidades);
            this.Controls.Add(this.lblAsignacionEspecialidades);
            this.Controls.Add(this.txtNombreCompleto);
            this.Controls.Add(this.lblNombreCompleto);
            this.Controls.Add(this.txtMatricula);
            this.Controls.Add(this.lblMatricula);
            this.Controls.Add(this.lblTitulo);
            this.Name = "FrmMedicos";
            this.Text = "Médicos";
            this.Load += new System.EventHandler(this.FrmMedicos_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblMatricula;
        private System.Windows.Forms.TextBox txtMatricula;
        private System.Windows.Forms.Label lblNombreCompleto;
        private System.Windows.Forms.TextBox txtNombreCompleto;
        private System.Windows.Forms.Label lblAsignacionEspecialidades;
        private System.Windows.Forms.CheckedListBox chkEspecialidades;
        private System.Windows.Forms.Button btnGuardarRegistro;
        private System.Windows.Forms.Button btnLimpiar;
    }
}
