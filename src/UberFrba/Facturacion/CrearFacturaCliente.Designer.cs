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
            this.button_FechaDeFinFactura = new System.Windows.Forms.Button();
            this.button_FechaDeInicioFactura = new System.Windows.Forms.Button();
            this.textBox_FechaFin = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_FechaInicio = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.monthCalendar_FechaDeFacturaInicio = new System.Windows.Forms.MonthCalendar();
            this.monthCalendar_FechaDeFacturaFin = new System.Windows.Forms.MonthCalendar();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_FechaDeFinFactura);
            this.groupBox1.Controls.Add(this.button_FechaDeInicioFactura);
            this.groupBox1.Controls.Add(this.monthCalendar_FechaDeFacturaInicio);
            this.groupBox1.Controls.Add(this.textBox_FechaFin);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox_FechaInicio);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Location = new System.Drawing.Point(27, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(428, 198);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos Factura";
            // 
            // button_FechaDeFinFactura
            // 
            this.button_FechaDeFinFactura.Location = new System.Drawing.Point(332, 89);
            this.button_FechaDeFinFactura.Name = "button_FechaDeFinFactura";
            this.button_FechaDeFinFactura.Size = new System.Drawing.Size(80, 20);
            this.button_FechaDeFinFactura.TabIndex = 43;
            this.button_FechaDeFinFactura.Text = "Seleccionar";
            this.button_FechaDeFinFactura.UseVisualStyleBackColor = true;
            this.button_FechaDeFinFactura.Click += new System.EventHandler(this.button_FechaDeFinFactura_Click_1);
            // 
            // button_FechaDeInicioFactura
            // 
            this.button_FechaDeInicioFactura.Location = new System.Drawing.Point(332, 60);
            this.button_FechaDeInicioFactura.Name = "button_FechaDeInicioFactura";
            this.button_FechaDeInicioFactura.Size = new System.Drawing.Size(80, 20);
            this.button_FechaDeInicioFactura.TabIndex = 42;
            this.button_FechaDeInicioFactura.Text = "Seleccionar";
            this.button_FechaDeInicioFactura.UseVisualStyleBackColor = true;
            this.button_FechaDeInicioFactura.Click += new System.EventHandler(this.button_FechaDeInicioFactura_Click_1);
            // 
            // textBox_FechaFin
            // 
            this.textBox_FechaFin.Location = new System.Drawing.Point(91, 89);
            this.textBox_FechaFin.Name = "textBox_FechaFin";
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
            this.textBox_FechaInicio.Location = new System.Drawing.Point(91, 60);
            this.textBox_FechaInicio.Name = "textBox_FechaInicio";
            this.textBox_FechaInicio.Size = new System.Drawing.Size(235, 20);
            this.textBox_FechaInicio.TabIndex = 3;
            this.textBox_FechaInicio.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
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
            this.label1.Location = new System.Drawing.Point(24, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cliente";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(91, 29);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(321, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // monthCalendar_FechaDeFacturaInicio
            // 
            this.monthCalendar_FechaDeFacturaInicio.Location = new System.Drawing.Point(39, 6);
            this.monthCalendar_FechaDeFacturaInicio.Name = "monthCalendar_FechaDeFacturaInicio";
            this.monthCalendar_FechaDeFacturaInicio.TabIndex = 44;
            this.monthCalendar_FechaDeFacturaInicio.Visible = false;
            this.monthCalendar_FechaDeFacturaInicio.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar_FechaDeFacturaInicio_DateSelected);
            // 
            // monthCalendar_FechaDeFacturaFin
            // 
            this.monthCalendar_FechaDeFacturaFin.Location = new System.Drawing.Point(253, 222);
            this.monthCalendar_FechaDeFacturaFin.Name = "monthCalendar_FechaDeFacturaFin";
            this.monthCalendar_FechaDeFacturaFin.TabIndex = 45;
            this.monthCalendar_FechaDeFacturaFin.Visible = false;
            this.monthCalendar_FechaDeFacturaFin.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar_FechaDeFacturaFin_DateSelected);
            // 
            // CrearFacturaCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::UberFrba.Properties.Resources.HUAYI_triaxial_space_wood_floor_photography_backdrops_font_b_pine_b_font_font_b_plank_b;
            this.ClientSize = new System.Drawing.Size(553, 380);
            this.Controls.Add(this.monthCalendar_FechaDeFacturaFin);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CrearFacturaCliente";
            this.Text = "Crear Factura Cliente";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_FechaInicio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_FechaFin;
        private System.Windows.Forms.Button button_FechaDeFinFactura;
        private System.Windows.Forms.Button button_FechaDeInicioFactura;
        private System.Windows.Forms.MonthCalendar monthCalendar_FechaDeFacturaInicio;
        private System.Windows.Forms.MonthCalendar monthCalendar_FechaDeFacturaFin;
    }
}