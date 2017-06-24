namespace UberFrba.Abm_Cliente
{
    partial class MenuCliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuCliente));
            this.labelClientes = new System.Windows.Forms.Label();
            this.botonAgregarCliente = new System.Windows.Forms.Button();
            this.botonEditarCliente = new System.Windows.Forms.Button();
            this.botonVolver = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelClientes
            // 
            this.labelClientes.AutoSize = true;
            this.labelClientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelClientes.Location = new System.Drawing.Point(108, 21);
            this.labelClientes.Name = "labelClientes";
            this.labelClientes.Size = new System.Drawing.Size(83, 25);
            this.labelClientes.TabIndex = 9;
            this.labelClientes.Text = "Clientes";
            this.labelClientes.Click += new System.EventHandler(this.labelRoles_Click);
            // 
            // botonAgregarCliente
            // 
            this.botonAgregarCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonAgregarCliente.Location = new System.Drawing.Point(85, 70);
            this.botonAgregarCliente.Name = "botonAgregarCliente";
            this.botonAgregarCliente.Size = new System.Drawing.Size(135, 54);
            this.botonAgregarCliente.TabIndex = 10;
            this.botonAgregarCliente.Text = "Agregar Cliente";
            this.botonAgregarCliente.UseVisualStyleBackColor = true;
            this.botonAgregarCliente.Click += new System.EventHandler(this.botonAgregarCliente_Click);
            // 
            // botonEditarCliente
            // 
            this.botonEditarCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonEditarCliente.Location = new System.Drawing.Point(85, 183);
            this.botonEditarCliente.Name = "botonEditarCliente";
            this.botonEditarCliente.Size = new System.Drawing.Size(135, 54);
            this.botonEditarCliente.TabIndex = 11;
            this.botonEditarCliente.Text = "Editar Cliente";
            this.botonEditarCliente.UseVisualStyleBackColor = true;
            this.botonEditarCliente.Click += new System.EventHandler(this.botonEditarCliente_Click);
            // 
            // botonVolver
            // 
            this.botonVolver.Location = new System.Drawing.Point(12, 326);
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
            // MenuCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::UberFrba.Properties.Resources.HUAYI_triaxial_space_wood_floor_photography_backdrops_font_b_pine_b_font_font_b_plank_b;
            this.ClientSize = new System.Drawing.Size(309, 386);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.botonVolver);
            this.Controls.Add(this.botonEditarCliente);
            this.Controls.Add(this.botonAgregarCliente);
            this.Controls.Add(this.labelClientes);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MenuCliente";
            this.Text = "MenuCliente";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelClientes;
        private System.Windows.Forms.Button botonAgregarCliente;
        private System.Windows.Forms.Button botonEditarCliente;
        private System.Windows.Forms.Button botonVolver;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}