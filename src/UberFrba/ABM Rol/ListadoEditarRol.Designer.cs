namespace UberFrba.ABM_Rol
{
    partial class ListadoEditarRol
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListadoEditarRol));
            this.dataGridViewResultadosBusqueda = new System.Windows.Forms.DataGridView();
            this.labelNombreDelRol = new System.Windows.Forms.Label();
            this.botonCancelar = new System.Windows.Forms.Button();
            this.botonBuscar = new System.Windows.Forms.Button();
            this.botonVolver = new System.Windows.Forms.Button();
            this.textBox_NombreRol = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResultadosBusqueda)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewResultadosBusqueda
            // 
            this.dataGridViewResultadosBusqueda.AllowUserToAddRows = false;
            this.dataGridViewResultadosBusqueda.AllowUserToDeleteRows = false;
            this.dataGridViewResultadosBusqueda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewResultadosBusqueda.Location = new System.Drawing.Point(9, 108);
            this.dataGridViewResultadosBusqueda.Name = "dataGridViewResultadosBusqueda";
            this.dataGridViewResultadosBusqueda.ReadOnly = true;
            this.dataGridViewResultadosBusqueda.Size = new System.Drawing.Size(394, 235);
            this.dataGridViewResultadosBusqueda.TabIndex = 0;
            // 
            // labelNombreDelRol
            // 
            this.labelNombreDelRol.AutoSize = true;
            this.labelNombreDelRol.Location = new System.Drawing.Point(22, 21);
            this.labelNombreDelRol.Name = "labelNombreDelRol";
            this.labelNombreDelRol.Size = new System.Drawing.Size(80, 13);
            this.labelNombreDelRol.TabIndex = 2;
            this.labelNombreDelRol.Text = "Nombre del Rol";
            // 
            // botonCancelar
            // 
            this.botonCancelar.Location = new System.Drawing.Point(191, 74);
            this.botonCancelar.Name = "botonCancelar";
            this.botonCancelar.Size = new System.Drawing.Size(73, 23);
            this.botonCancelar.TabIndex = 3;
            this.botonCancelar.Text = "Cancelar";
            this.botonCancelar.UseVisualStyleBackColor = true;
            this.botonCancelar.Click += new System.EventHandler(this.botonCancelar_Click);
            // 
            // botonBuscar
            // 
            this.botonBuscar.Location = new System.Drawing.Point(291, 76);
            this.botonBuscar.Name = "botonBuscar";
            this.botonBuscar.Size = new System.Drawing.Size(94, 21);
            this.botonBuscar.TabIndex = 4;
            this.botonBuscar.Text = "Buscar";
            this.botonBuscar.UseVisualStyleBackColor = true;
            this.botonBuscar.Click += new System.EventHandler(this.botonBuscar_Click);
            // 
            // botonVolver
            // 
            this.botonVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonVolver.Location = new System.Drawing.Point(25, 74);
            this.botonVolver.Name = "botonVolver";
            this.botonVolver.Size = new System.Drawing.Size(141, 23);
            this.botonVolver.TabIndex = 5;
            this.botonVolver.Text = "< Volver a menu de rol";
            this.botonVolver.UseVisualStyleBackColor = true;
            this.botonVolver.Click += new System.EventHandler(this.botonVolver_Click);
            // 
            // textBox_NombreRol
            // 
            this.textBox_NombreRol.Location = new System.Drawing.Point(108, 18);
            this.textBox_NombreRol.Name = "textBox_NombreRol";
            this.textBox_NombreRol.Size = new System.Drawing.Size(285, 20);
            this.textBox_NombreRol.TabIndex = 6;
            // 
            // ListadoEditarRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::UberFrba.Properties.Resources.HUAYI_triaxial_space_wood_floor_photography_backdrops_font_b_pine_b_font_font_b_plank_b;
            this.ClientSize = new System.Drawing.Size(406, 348);
            this.Controls.Add(this.textBox_NombreRol);
            this.Controls.Add(this.botonVolver);
            this.Controls.Add(this.botonBuscar);
            this.Controls.Add(this.botonCancelar);
            this.Controls.Add(this.labelNombreDelRol);
            this.Controls.Add(this.dataGridViewResultadosBusqueda);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ListadoEditarRol";
            this.Text = "ListadoEditarRol";
            this.Load += new System.EventHandler(this.ListadoEditarRol_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResultadosBusqueda)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewResultadosBusqueda;
        private System.Windows.Forms.Label labelNombreDelRol;
        private System.Windows.Forms.Button botonCancelar;
        private System.Windows.Forms.Button botonBuscar;
        private System.Windows.Forms.Button botonVolver;
        private System.Windows.Forms.TextBox textBox_NombreRol;
    }
}