namespace UberFrba.ABM_Turno
{
    partial class MenuTurno
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuTurno));
            this.labelTurnos = new System.Windows.Forms.Label();
            this.botonAgregarTurno = new System.Windows.Forms.Button();
            this.botonEditarTurno = new System.Windows.Forms.Button();
            this.botonVolver = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelTurnos
            // 
            this.labelTurnos.AutoSize = true;
            this.labelTurnos.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTurnos.Location = new System.Drawing.Point(112, 19);
            this.labelTurnos.Name = "labelTurnos";
            this.labelTurnos.Size = new System.Drawing.Size(74, 25);
            this.labelTurnos.TabIndex = 9;
            this.labelTurnos.Text = "Turnos";
            // 
            // botonAgregarTurno
            // 
            this.botonAgregarTurno.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonAgregarTurno.Location = new System.Drawing.Point(85, 83);
            this.botonAgregarTurno.Name = "botonAgregarTurno";
            this.botonAgregarTurno.Size = new System.Drawing.Size(135, 54);
            this.botonAgregarTurno.TabIndex = 10;
            this.botonAgregarTurno.Text = "Agregar Turno";
            this.botonAgregarTurno.UseVisualStyleBackColor = true;
            this.botonAgregarTurno.Click += new System.EventHandler(this.botonAgregarTurno_Click);
            // 
            // botonEditarTurno
            // 
            this.botonEditarTurno.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonEditarTurno.Location = new System.Drawing.Point(85, 189);
            this.botonEditarTurno.Name = "botonEditarTurno";
            this.botonEditarTurno.Size = new System.Drawing.Size(135, 54);
            this.botonEditarTurno.TabIndex = 11;
            this.botonEditarTurno.Text = "Editar Turno";
            this.botonEditarTurno.UseVisualStyleBackColor = true;
            this.botonEditarTurno.Click += new System.EventHandler(this.botonEditarTurno_Click);
            // 
            // botonVolver
            // 
            this.botonVolver.Location = new System.Drawing.Point(12, 311);
            this.botonVolver.Name = "botonVolver";
            this.botonVolver.Size = new System.Drawing.Size(144, 35);
            this.botonVolver.TabIndex = 12;
            this.botonVolver.Text = "< Volver al Menú Principal";
            this.botonVolver.UseVisualStyleBackColor = true;
            this.botonVolver.Click += new System.EventHandler(this.botonVolver_Click);
            // 
            // MenuTurno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::UberFrba.Properties.Resources.HUAYI_triaxial_space_wood_floor_photography_backdrops_font_b_pine_b_font_font_b_plank_b;
            this.ClientSize = new System.Drawing.Size(309, 386);
            this.Controls.Add(this.botonVolver);
            this.Controls.Add(this.botonEditarTurno);
            this.Controls.Add(this.botonAgregarTurno);
            this.Controls.Add(this.labelTurnos);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MenuTurno";
            this.Text = "MenuTurno";
            this.Load += new System.EventHandler(this.MenuTurno_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTurnos;
        private System.Windows.Forms.Button botonAgregarTurno;
        private System.Windows.Forms.Button botonEditarTurno;
        private System.Windows.Forms.Button botonVolver;
    }
}