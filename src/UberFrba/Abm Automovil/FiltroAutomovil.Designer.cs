namespace UberFrba.Abm_Automovil
{
    partial class FiltroAutomovil
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox_Marca = new System.Windows.Forms.ComboBox();
            this.labelChoferDni = new System.Windows.Forms.Label();
            this.labePatente = new System.Windows.Forms.Label();
            this.labelModelo = new System.Windows.Forms.Label();
            this.textBox_Patente = new System.Windows.Forms.TextBox();
            this.textBox_Chofer_Dni = new System.Windows.Forms.TextBox();
            this.textBox_Modelo = new System.Windows.Forms.TextBox();
            this.labelMarca = new System.Windows.Forms.Label();
            this.button_Cancelar = new System.Windows.Forms.Button();
            this.button_Limpiar = new System.Windows.Forms.Button();
            this.button_Buscar = new System.Windows.Forms.Button();
            this.dataGridView_Automovil = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Automovil)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox_Marca);
            this.groupBox1.Controls.Add(this.labelChoferDni);
            this.groupBox1.Controls.Add(this.labePatente);
            this.groupBox1.Controls.Add(this.labelModelo);
            this.groupBox1.Controls.Add(this.textBox_Patente);
            this.groupBox1.Controls.Add(this.textBox_Chofer_Dni);
            this.groupBox1.Controls.Add(this.textBox_Modelo);
            this.groupBox1.Controls.Add(this.labelMarca);
            this.groupBox1.Location = new System.Drawing.Point(22, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(368, 125);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtro de busqueda";
            // 
            // comboBox_Marca
            // 
            this.comboBox_Marca.FormattingEnabled = true;
            this.comboBox_Marca.Location = new System.Drawing.Point(77, 18);
            this.comboBox_Marca.Name = "comboBox_Marca";
            this.comboBox_Marca.Size = new System.Drawing.Size(285, 21);
            this.comboBox_Marca.TabIndex = 15;
            // 
            // labelChoferDni
            // 
            this.labelChoferDni.AutoSize = true;
            this.labelChoferDni.Location = new System.Drawing.Point(6, 102);
            this.labelChoferDni.Name = "labelChoferDni";
            this.labelChoferDni.Size = new System.Drawing.Size(60, 13);
            this.labelChoferDni.TabIndex = 7;
            this.labelChoferDni.Text = "Chofer DNI";
            // 
            // labePatente
            // 
            this.labePatente.AutoSize = true;
            this.labePatente.Location = new System.Drawing.Point(6, 74);
            this.labePatente.Name = "labePatente";
            this.labePatente.Size = new System.Drawing.Size(44, 13);
            this.labePatente.TabIndex = 6;
            this.labePatente.Text = "Patente";
            // 
            // labelModelo
            // 
            this.labelModelo.AutoSize = true;
            this.labelModelo.Location = new System.Drawing.Point(6, 48);
            this.labelModelo.Name = "labelModelo";
            this.labelModelo.Size = new System.Drawing.Size(42, 13);
            this.labelModelo.TabIndex = 5;
            this.labelModelo.Text = "Modelo";
            // 
            // textBox_Patente
            // 
            this.textBox_Patente.Location = new System.Drawing.Point(77, 71);
            this.textBox_Patente.Name = "textBox_Patente";
            this.textBox_Patente.Size = new System.Drawing.Size(285, 20);
            this.textBox_Patente.TabIndex = 4;
            // 
            // textBox_Chofer_Dni
            // 
            this.textBox_Chofer_Dni.Location = new System.Drawing.Point(77, 95);
            this.textBox_Chofer_Dni.Name = "textBox_Chofer_Dni";
            this.textBox_Chofer_Dni.Size = new System.Drawing.Size(285, 20);
            this.textBox_Chofer_Dni.TabIndex = 0;
            // 
            // textBox_Modelo
            // 
            this.textBox_Modelo.Location = new System.Drawing.Point(77, 45);
            this.textBox_Modelo.Name = "textBox_Modelo";
            this.textBox_Modelo.Size = new System.Drawing.Size(285, 20);
            this.textBox_Modelo.TabIndex = 3;
            // 
            // labelMarca
            // 
            this.labelMarca.AutoSize = true;
            this.labelMarca.Location = new System.Drawing.Point(6, 22);
            this.labelMarca.Name = "labelMarca";
            this.labelMarca.Size = new System.Drawing.Size(37, 13);
            this.labelMarca.TabIndex = 1;
            this.labelMarca.Text = "Marca";
            // 
            // button_Cancelar
            // 
            this.button_Cancelar.Location = new System.Drawing.Point(22, 143);
            this.button_Cancelar.Name = "button_Cancelar";
            this.button_Cancelar.Size = new System.Drawing.Size(100, 30);
            this.button_Cancelar.TabIndex = 7;
            this.button_Cancelar.Text = "Cancelar";
            this.button_Cancelar.UseVisualStyleBackColor = true;
            this.button_Cancelar.Click += new System.EventHandler(this.button_Cancelar_Click);
            // 
            // button_Limpiar
            // 
            this.button_Limpiar.Location = new System.Drawing.Point(184, 143);
            this.button_Limpiar.Name = "button_Limpiar";
            this.button_Limpiar.Size = new System.Drawing.Size(100, 30);
            this.button_Limpiar.TabIndex = 8;
            this.button_Limpiar.Text = "Limpiar";
            this.button_Limpiar.UseVisualStyleBackColor = true;
            this.button_Limpiar.Click += new System.EventHandler(this.button_Limpiar_Click);
            // 
            // button_Buscar
            // 
            this.button_Buscar.Location = new System.Drawing.Point(290, 143);
            this.button_Buscar.Name = "button_Buscar";
            this.button_Buscar.Size = new System.Drawing.Size(100, 30);
            this.button_Buscar.TabIndex = 9;
            this.button_Buscar.Text = "Buscar";
            this.button_Buscar.UseVisualStyleBackColor = true;
            this.button_Buscar.Click += new System.EventHandler(this.button_Buscar_Click);
            // 
            // dataGridView_Automovil
            // 
            this.dataGridView_Automovil.AllowUserToAddRows = false;
            this.dataGridView_Automovil.AllowUserToDeleteRows = false;
            this.dataGridView_Automovil.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_Automovil.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Automovil.Location = new System.Drawing.Point(22, 179);
            this.dataGridView_Automovil.Name = "dataGridView_Automovil";
            this.dataGridView_Automovil.ReadOnly = true;
            this.dataGridView_Automovil.Size = new System.Drawing.Size(1160, 268);
            this.dataGridView_Automovil.TabIndex = 10;
            this.dataGridView_Automovil.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Automovil_CellClick);
            // 
            // FiltroAutomovil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1195, 459);
            this.Controls.Add(this.dataGridView_Automovil);
            this.Controls.Add(this.button_Buscar);
            this.Controls.Add(this.button_Limpiar);
            this.Controls.Add(this.button_Cancelar);
            this.Controls.Add(this.groupBox1);
            this.Name = "FiltroAutomovil";
            this.Text = "FiltroAutomovil";
            this.Load += new System.EventHandler(this.FiltroAutomovil_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Automovil)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labePatente;
        private System.Windows.Forms.Label labelModelo;
        private System.Windows.Forms.TextBox textBox_Patente;
        private System.Windows.Forms.TextBox textBox_Modelo;
        private System.Windows.Forms.Label labelMarca;
        private System.Windows.Forms.TextBox textBox_Chofer_Dni;
        private System.Windows.Forms.Button button_Cancelar;
        private System.Windows.Forms.Button button_Limpiar;
        private System.Windows.Forms.Button button_Buscar;
        private System.Windows.Forms.DataGridView dataGridView_Automovil;
        private System.Windows.Forms.Label labelChoferDni;
        private System.Windows.Forms.ComboBox comboBox_Marca;
        //private System.Windows.Forms.DataGridViewComboBoxColumn comboBoxTurnos;
    }
}