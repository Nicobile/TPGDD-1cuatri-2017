namespace UberFrba.Facturacion
{
    partial class CrearFacturaCliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CrearFacturaCliente));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox_CantidadViajes = new System.Windows.Forms.TextBox();
            this.textBox_TotalFactutado = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button_FechaDeFinFactura = new System.Windows.Forms.Button();
            this.button_FechaDeInicioFactura = new System.Windows.Forms.Button();
            this.textBox_FechaFin = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_FechaInicio = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_Cliente = new System.Windows.Forms.ComboBox();
            this.monthCalendar_FechaDeFacturaInicio = new System.Windows.Forms.MonthCalendar();
            this.monthCalendar_FechaDeFacturaFin = new System.Windows.Forms.MonthCalendar();
            this.dataGridView_Viajes_Facturados = new System.Windows.Forms.DataGridView();
            this.button_CrearFactura = new System.Windows.Forms.Button();
            this.button_limpiar = new System.Windows.Forms.Button();
            this.button_volver = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Viajes_Facturados)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_CantidadViajes);
            this.groupBox1.Controls.Add(this.textBox_TotalFactutado);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.button_FechaDeFinFactura);
            this.groupBox1.Controls.Add(this.button_FechaDeInicioFactura);
            this.groupBox1.Controls.Add(this.textBox_FechaFin);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox_FechaInicio);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBox_Cliente);
            this.groupBox1.Location = new System.Drawing.Point(27, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(449, 198);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos Factura";
            // 
            // textBox_CantidadViajes
            // 
            this.textBox_CantidadViajes.Location = new System.Drawing.Point(107, 146);
            this.textBox_CantidadViajes.Name = "textBox_CantidadViajes";
            this.textBox_CantidadViajes.ReadOnly = true;
            this.textBox_CantidadViajes.Size = new System.Drawing.Size(315, 20);
            this.textBox_CantidadViajes.TabIndex = 47;
            // 
            // textBox_TotalFactutado
            // 
            this.textBox_TotalFactutado.Location = new System.Drawing.Point(107, 116);
            this.textBox_TotalFactutado.Name = "textBox_TotalFactutado";
            this.textBox_TotalFactutado.ReadOnly = true;
            this.textBox_TotalFactutado.Size = new System.Drawing.Size(315, 20);
            this.textBox_TotalFactutado.TabIndex = 46;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 149);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 13);
            this.label6.TabIndex = 45;
            this.label6.Text = "Cantidad Viajes ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 13);
            this.label5.TabIndex = 44;
            this.label5.Text = "Total Facturado";
            // 
            // button_FechaDeFinFactura
            // 
            this.button_FechaDeFinFactura.Location = new System.Drawing.Point(348, 89);
            this.button_FechaDeFinFactura.Name = "button_FechaDeFinFactura";
            this.button_FechaDeFinFactura.Size = new System.Drawing.Size(80, 20);
            this.button_FechaDeFinFactura.TabIndex = 43;
            this.button_FechaDeFinFactura.Text = "Seleccionar";
            this.button_FechaDeFinFactura.UseVisualStyleBackColor = true;
            this.button_FechaDeFinFactura.Click += new System.EventHandler(this.button_FechaDeFinFactura_Click);
            // 
            // button_FechaDeInicioFactura
            // 
            this.button_FechaDeInicioFactura.Location = new System.Drawing.Point(348, 60);
            this.button_FechaDeInicioFactura.Name = "button_FechaDeInicioFactura";
            this.button_FechaDeInicioFactura.Size = new System.Drawing.Size(80, 20);
            this.button_FechaDeInicioFactura.TabIndex = 42;
            this.button_FechaDeInicioFactura.Text = "Seleccionar";
            this.button_FechaDeInicioFactura.UseVisualStyleBackColor = true;
            this.button_FechaDeInicioFactura.Click += new System.EventHandler(this.button_FechaDeInicioFactura_Click);
            // 
            // textBox_FechaFin
            // 
            this.textBox_FechaFin.Location = new System.Drawing.Point(107, 85);
            this.textBox_FechaFin.Name = "textBox_FechaFin";
            this.textBox_FechaFin.ReadOnly = true;
            this.textBox_FechaFin.Size = new System.Drawing.Size(235, 20);
            this.textBox_FechaFin.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Fecha Fin";
            // 
            // textBox_FechaInicio
            // 
            this.textBox_FechaInicio.Location = new System.Drawing.Point(107, 60);
            this.textBox_FechaInicio.Name = "textBox_FechaInicio";
            this.textBox_FechaInicio.ReadOnly = true;
            this.textBox_FechaInicio.Size = new System.Drawing.Size(235, 20);
            this.textBox_FechaInicio.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Fecha Inicio";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cliente";
            // 
            // comboBox_Cliente
            // 
            this.comboBox_Cliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Cliente.FormattingEnabled = true;
            this.comboBox_Cliente.Location = new System.Drawing.Point(107, 32);
            this.comboBox_Cliente.Name = "comboBox_Cliente";
            this.comboBox_Cliente.Size = new System.Drawing.Size(321, 21);
            this.comboBox_Cliente.TabIndex = 0;
            // 
            // monthCalendar_FechaDeFacturaInicio
            // 
            this.monthCalendar_FechaDeFacturaInicio.Location = new System.Drawing.Point(488, 68);
            this.monthCalendar_FechaDeFacturaInicio.Name = "monthCalendar_FechaDeFacturaInicio";
            this.monthCalendar_FechaDeFacturaInicio.TabIndex = 44;
            this.monthCalendar_FechaDeFacturaInicio.Visible = false;
            this.monthCalendar_FechaDeFacturaInicio.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar_FechaDeFacturaInicio_DateSelected);
            // 
            // monthCalendar_FechaDeFacturaFin
            // 
            this.monthCalendar_FechaDeFacturaFin.Location = new System.Drawing.Point(576, 68);
            this.monthCalendar_FechaDeFacturaFin.Name = "monthCalendar_FechaDeFacturaFin";
            this.monthCalendar_FechaDeFacturaFin.TabIndex = 45;
            this.monthCalendar_FechaDeFacturaFin.Visible = false;
            this.monthCalendar_FechaDeFacturaFin.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar_FechaDeFacturaFin_DateSelected);
            // 
            // dataGridView_Viajes_Facturados
            // 
            this.dataGridView_Viajes_Facturados.AllowUserToAddRows = false;
            this.dataGridView_Viajes_Facturados.AllowUserToDeleteRows = false;
            this.dataGridView_Viajes_Facturados.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_Viajes_Facturados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Viajes_Facturados.Location = new System.Drawing.Point(54, 242);
            this.dataGridView_Viajes_Facturados.Name = "dataGridView_Viajes_Facturados";
            this.dataGridView_Viajes_Facturados.ReadOnly = true;
            this.dataGridView_Viajes_Facturados.Size = new System.Drawing.Size(838, 207);
            this.dataGridView_Viajes_Facturados.TabIndex = 46;
            // 
            // button_CrearFactura
            // 
            this.button_CrearFactura.Location = new System.Drawing.Point(749, 455);
            this.button_CrearFactura.Name = "button_CrearFactura";
            this.button_CrearFactura.Size = new System.Drawing.Size(100, 30);
            this.button_CrearFactura.TabIndex = 51;
            this.button_CrearFactura.Text = "Crear Factura";
            this.button_CrearFactura.UseVisualStyleBackColor = true;
            this.button_CrearFactura.Click += new System.EventHandler(this.button_CrearFactura_Click_1);
            // 
            // button_limpiar
            // 
            this.button_limpiar.Location = new System.Drawing.Point(355, 455);
            this.button_limpiar.Name = "button_limpiar";
            this.button_limpiar.Size = new System.Drawing.Size(100, 30);
            this.button_limpiar.TabIndex = 52;
            this.button_limpiar.Text = "Limpiar";
            this.button_limpiar.UseVisualStyleBackColor = true;
            this.button_limpiar.Click += new System.EventHandler(this.button_limpiar_Click);
            // 
            // button_volver
            // 
            this.button_volver.Location = new System.Drawing.Point(27, 455);
            this.button_volver.Name = "button_volver";
            this.button_volver.Size = new System.Drawing.Size(100, 30);
            this.button_volver.TabIndex = 53;
            this.button_volver.Text = "Volver";
            this.button_volver.UseVisualStyleBackColor = true;
            this.button_volver.Click += new System.EventHandler(this.button_volver_Click_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(30, 217);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 20);
            this.label4.TabIndex = 44;
            this.label4.Text = "Viajes a Facturar :";
            // 
            // CrearFacturaCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::UberFrba.Properties.Resources.HUAYI_triaxial_space_wood_floor_photography_backdrops_font_b_pine_b_font_font_b_plank_b;
            this.ClientSize = new System.Drawing.Size(904, 508);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button_volver);
            this.Controls.Add(this.button_limpiar);
            this.Controls.Add(this.button_CrearFactura);
            this.Controls.Add(this.monthCalendar_FechaDeFacturaInicio);
            this.Controls.Add(this.monthCalendar_FechaDeFacturaFin);
            this.Controls.Add(this.dataGridView_Viajes_Facturados);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CrearFacturaCliente";
            this.Text = "Crear Factura Cliente";
            this.Load += new System.EventHandler(this.CrearFacturaCliente_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Viajes_Facturados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBox_Cliente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_FechaInicio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_FechaFin;
        private System.Windows.Forms.Button button_FechaDeFinFactura;
        private System.Windows.Forms.Button button_FechaDeInicioFactura;
        private System.Windows.Forms.MonthCalendar monthCalendar_FechaDeFacturaInicio;
        private System.Windows.Forms.MonthCalendar monthCalendar_FechaDeFacturaFin;
        private System.Windows.Forms.DataGridView dataGridView_Viajes_Facturados;
        private System.Windows.Forms.Button button_CrearFactura;
        private System.Windows.Forms.Button button_limpiar;
        private System.Windows.Forms.Button button_volver;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_CantidadViajes;
        private System.Windows.Forms.TextBox textBox_TotalFactutado;
        private System.Windows.Forms.Label label6;
    }
}