namespace UberFrba.ABM_Rol
{
    partial class AgregarRol
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AgregarRol));
            this.botonVolver = new System.Windows.Forms.Button();
            this.checkedListBoxFuncionalidades = new System.Windows.Forms.CheckedListBox();
            this.labelRol = new System.Windows.Forms.Label();
            this.textBoxRol = new System.Windows.Forms.TextBox();
            this.labelFuncionalidades = new System.Windows.Forms.Label();
            this.botonGuardar = new System.Windows.Forms.Button();
            this.botonLimpiar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // botonVolver
            // 
            this.botonVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonVolver.Location = new System.Drawing.Point(12, 334);
            this.botonVolver.Name = "botonVolver";
            this.botonVolver.Size = new System.Drawing.Size(141, 23);
            this.botonVolver.TabIndex = 0;
            this.botonVolver.Text = "< Volver a menu de rol";
            this.botonVolver.UseVisualStyleBackColor = true;
            this.botonVolver.Click += new System.EventHandler(this.botonVolver_Click);
            // 
            // checkedListBoxFuncionalidades
            // 
            this.checkedListBoxFuncionalidades.BackColor = System.Drawing.Color.Wheat;
            this.checkedListBoxFuncionalidades.FormattingEnabled = true;
            this.checkedListBoxFuncionalidades.Location = new System.Drawing.Point(146, 77);
            this.checkedListBoxFuncionalidades.Name = "checkedListBoxFuncionalidades";
            this.checkedListBoxFuncionalidades.Size = new System.Drawing.Size(193, 199);
            this.checkedListBoxFuncionalidades.TabIndex = 1;
            this.checkedListBoxFuncionalidades.SelectedIndexChanged += new System.EventHandler(this.checkedListBoxFuncionalidades_SelectedIndexChanged);
            // 
            // labelRol
            // 
            this.labelRol.AutoSize = true;
            this.labelRol.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRol.Location = new System.Drawing.Point(25, 28);
            this.labelRol.Name = "labelRol";
            this.labelRol.Size = new System.Drawing.Size(101, 20);
            this.labelRol.TabIndex = 2;
            this.labelRol.Text = "Nombre Rol :";
            // 
            // textBoxRol
            // 
            this.textBoxRol.Location = new System.Drawing.Point(146, 28);
            this.textBoxRol.Name = "textBoxRol";
            this.textBoxRol.Size = new System.Drawing.Size(94, 20);
            this.textBoxRol.TabIndex = 3;
            // 
            // labelFuncionalidades
            // 
            this.labelFuncionalidades.AutoSize = true;
            this.labelFuncionalidades.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFuncionalidades.Location = new System.Drawing.Point(21, 77);
            this.labelFuncionalidades.Name = "labelFuncionalidades";
            this.labelFuncionalidades.Size = new System.Drawing.Size(119, 17);
            this.labelFuncionalidades.TabIndex = 4;
            this.labelFuncionalidades.Text = "Funcionalidades :";
            // 
            // botonGuardar
            // 
            this.botonGuardar.Location = new System.Drawing.Point(229, 334);
            this.botonGuardar.Name = "botonGuardar";
            this.botonGuardar.Size = new System.Drawing.Size(96, 30);
            this.botonGuardar.TabIndex = 5;
            this.botonGuardar.Text = "Guardar";
            this.botonGuardar.UseVisualStyleBackColor = true;
            this.botonGuardar.Click += new System.EventHandler(this.botonGuardar_Click);
            // 
            // botonLimpiar
            // 
            this.botonLimpiar.Location = new System.Drawing.Point(230, 293);
            this.botonLimpiar.Name = "botonLimpiar";
            this.botonLimpiar.Size = new System.Drawing.Size(95, 26);
            this.botonLimpiar.TabIndex = 6;
            this.botonLimpiar.Text = "Limpiar";
            this.botonLimpiar.UseVisualStyleBackColor = true;
            this.botonLimpiar.Click += new System.EventHandler(this.botonLimpiar_Click);
            // 
            // AgregarRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::UberFrba.Properties.Resources.HUAYI_triaxial_space_wood_floor_photography_backdrops_font_b_pine_b_font_font_b_plank_b;
            this.ClientSize = new System.Drawing.Size(351, 376);
            this.Controls.Add(this.botonLimpiar);
            this.Controls.Add(this.botonGuardar);
            this.Controls.Add(this.labelFuncionalidades);
            this.Controls.Add(this.textBoxRol);
            this.Controls.Add(this.labelRol);
            this.Controls.Add(this.checkedListBoxFuncionalidades);
            this.Controls.Add(this.botonVolver);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AgregarRol";
            this.Text = "AgregarRol";
            this.Load += new System.EventHandler(this.AgregarRol_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button botonVolver;
        private System.Windows.Forms.CheckedListBox checkedListBoxFuncionalidades;
        private System.Windows.Forms.Label labelRol;
        private System.Windows.Forms.TextBox textBoxRol;
        private System.Windows.Forms.Label labelFuncionalidades;
        private System.Windows.Forms.Button botonGuardar;
        private System.Windows.Forms.Button botonLimpiar;
    }
}