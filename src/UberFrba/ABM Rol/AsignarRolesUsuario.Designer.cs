namespace UberFrba.Abm_Rol
{
    partial class AsignarRolesUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AsignarRolesUsuario));
            this.labelRol = new System.Windows.Forms.Label();
            this.comboBox_Usuarios = new System.Windows.Forms.ComboBox();
            this.checkedListBoxFuncionalidades = new System.Windows.Forms.CheckedListBox();
            this.labelFuncionalidades = new System.Windows.Forms.Label();
            this.botonVolver = new System.Windows.Forms.Button();
            this.botonLimpiar = new System.Windows.Forms.Button();
            this.botonGuardar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelRol
            // 
            this.labelRol.AutoSize = true;
            this.labelRol.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRol.Location = new System.Drawing.Point(26, 29);
            this.labelRol.Name = "labelRol";
            this.labelRol.Size = new System.Drawing.Size(159, 20);
            this.labelRol.TabIndex = 3;
            this.labelRol.Text = "Seleccionar Usuario :";
            // 
            // comboBox_Usuarios
            // 
            this.comboBox_Usuarios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Usuarios.Location = new System.Drawing.Point(203, 28);
            this.comboBox_Usuarios.Name = "comboBox_Usuarios";
            this.comboBox_Usuarios.Size = new System.Drawing.Size(184, 21);
            this.comboBox_Usuarios.TabIndex = 0;
            this.comboBox_Usuarios.SelectedIndexChanged += new System.EventHandler(this.comboBox_Usuarios_SelectedIndexChanged);
            // 
            // checkedListBoxFuncionalidades
            // 
            this.checkedListBoxFuncionalidades.BackColor = System.Drawing.Color.Wheat;
            this.checkedListBoxFuncionalidades.FormattingEnabled = true;
            this.checkedListBoxFuncionalidades.Location = new System.Drawing.Point(203, 67);
            this.checkedListBoxFuncionalidades.Name = "checkedListBoxFuncionalidades";
            this.checkedListBoxFuncionalidades.Size = new System.Drawing.Size(193, 199);
            this.checkedListBoxFuncionalidades.TabIndex = 4;
            // 
            // labelFuncionalidades
            // 
            this.labelFuncionalidades.AutoSize = true;
            this.labelFuncionalidades.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFuncionalidades.Location = new System.Drawing.Point(26, 67);
            this.labelFuncionalidades.Name = "labelFuncionalidades";
            this.labelFuncionalidades.Size = new System.Drawing.Size(62, 20);
            this.labelFuncionalidades.TabIndex = 5;
            this.labelFuncionalidades.Text = "Roles  :";
            // 
            // botonVolver
            // 
            this.botonVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonVolver.Location = new System.Drawing.Point(12, 306);
            this.botonVolver.Name = "botonVolver";
            this.botonVolver.Size = new System.Drawing.Size(141, 30);
            this.botonVolver.TabIndex = 6;
            this.botonVolver.Text = "< Volver a menu de rol";
            this.botonVolver.UseVisualStyleBackColor = true;
            this.botonVolver.Click += new System.EventHandler(this.botonVolver_Click);
            // 
            // botonLimpiar
            // 
            this.botonLimpiar.Location = new System.Drawing.Point(205, 305);
            this.botonLimpiar.Name = "botonLimpiar";
            this.botonLimpiar.Size = new System.Drawing.Size(96, 30);
            this.botonLimpiar.TabIndex = 7;
            this.botonLimpiar.Text = "Limpiar";
            this.botonLimpiar.UseVisualStyleBackColor = true;
            // 
            // botonGuardar
            // 
            this.botonGuardar.Location = new System.Drawing.Point(355, 306);
            this.botonGuardar.Name = "botonGuardar";
            this.botonGuardar.Size = new System.Drawing.Size(96, 30);
            this.botonGuardar.TabIndex = 8;
            this.botonGuardar.Text = "Guardar";
            this.botonGuardar.UseVisualStyleBackColor = true;
            // 
            // AsignarRolesUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::UberFrba.Properties.Resources.HUAYI_triaxial_space_wood_floor_photography_backdrops_font_b_pine_b_font_font_b_plank_b;
            this.ClientSize = new System.Drawing.Size(463, 352);
            this.Controls.Add(this.botonGuardar);
            this.Controls.Add(this.botonLimpiar);
            this.Controls.Add(this.botonVolver);
            this.Controls.Add(this.labelFuncionalidades);
            this.Controls.Add(this.checkedListBoxFuncionalidades);
            this.Controls.Add(this.comboBox_Usuarios);
            this.Controls.Add(this.labelRol);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AsignarRolesUsuario";
            this.Text = "AsignarRolesUsuario";
            this.Load += new System.EventHandler(this.AsignarRolesUsuario_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelRol;
        private System.Windows.Forms.ComboBox comboBox_Usuarios;
        private System.Windows.Forms.CheckedListBox checkedListBoxFuncionalidades;
        private System.Windows.Forms.Label labelFuncionalidades;
        private System.Windows.Forms.Button botonVolver;
        private System.Windows.Forms.Button botonLimpiar;
        private System.Windows.Forms.Button botonGuardar;
    }
}