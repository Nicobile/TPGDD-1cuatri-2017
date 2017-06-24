namespace UberFrba.Abm_Automovil
{
    partial class MenuAutomovil
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuAutomovil));
            this.labelRoles = new System.Windows.Forms.Label();
            this.botonAgregarAutomovil = new System.Windows.Forms.Button();
            this.botonEditarAutomovil = new System.Windows.Forms.Button();
            this.botonVolver = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelRoles
            // 
            this.labelRoles.AutoSize = true;
            this.labelRoles.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRoles.Location = new System.Drawing.Point(98, 23);
            this.labelRoles.Name = "labelRoles";
            this.labelRoles.Size = new System.Drawing.Size(119, 25);
            this.labelRoles.TabIndex = 9;
            this.labelRoles.Text = "Automoviles";
            this.labelRoles.UseWaitCursor = true;
            // 
            // botonAgregarAutomovil
            // 
            this.botonAgregarAutomovil.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonAgregarAutomovil.Location = new System.Drawing.Point(93, 84);
            this.botonAgregarAutomovil.Name = "botonAgregarAutomovil";
            this.botonAgregarAutomovil.Size = new System.Drawing.Size(135, 54);
            this.botonAgregarAutomovil.TabIndex = 10;
            this.botonAgregarAutomovil.Text = "Agregar Automovil";
            this.botonAgregarAutomovil.UseVisualStyleBackColor = true;
            this.botonAgregarAutomovil.Click += new System.EventHandler(this.botonAgregarAutomovil_Click);
            // 
            // botonEditarAutomovil
            // 
            this.botonEditarAutomovil.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonEditarAutomovil.Location = new System.Drawing.Point(93, 174);
            this.botonEditarAutomovil.Name = "botonEditarAutomovil";
            this.botonEditarAutomovil.Size = new System.Drawing.Size(135, 54);
            this.botonEditarAutomovil.TabIndex = 11;
            this.botonEditarAutomovil.Text = "Editar Automovil";
            this.botonEditarAutomovil.UseVisualStyleBackColor = true;
            this.botonEditarAutomovil.Click += new System.EventHandler(this.botonEditarAutomovil_Click);
            // 
            // botonVolver
            // 
            this.botonVolver.Location = new System.Drawing.Point(12, 294);
            this.botonVolver.Name = "botonVolver";
            this.botonVolver.Size = new System.Drawing.Size(144, 35);
            this.botonVolver.TabIndex = 12;
            this.botonVolver.Text = "< Volver al Menú Principal";
            this.botonVolver.UseVisualStyleBackColor = true;
            this.botonVolver.Click += new System.EventHandler(this.botonVolver_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::UberFrba.Properties.Resources.logouber6;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(12, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(54, 53);
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // MenuAutomovil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::UberFrba.Properties.Resources.HUAYI_triaxial_space_wood_floor_photography_backdrops_font_b_pine_b_font_font_b_plank_b;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(309, 386);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.botonVolver);
            this.Controls.Add(this.botonEditarAutomovil);
            this.Controls.Add(this.botonAgregarAutomovil);
            this.Controls.Add(this.labelRoles);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MenuAutomovil";
            this.Text = "MenuAutomovil";
            this.TransparencyKey = System.Drawing.Color.White;
            this.Load += new System.EventHandler(this.MenuAutomovil_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelRoles;
        private System.Windows.Forms.Button botonAgregarAutomovil;
        private System.Windows.Forms.Button botonEditarAutomovil;
        private System.Windows.Forms.Button botonVolver;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}