namespace UberFrba.Rendicion_Viajes
{
    partial class RendicionViaje
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RendicionViaje));
            this.groupBox_datosViaje = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_importe = new System.Windows.Forms.TextBox();
            this.label_Importe = new System.Windows.Forms.Label();
            this.button_FechaDeRendicion = new System.Windows.Forms.Button();
            this.comboBox_Turnos = new System.Windows.Forms.ComboBox();
            this.comboBox_chofer = new System.Windows.Forms.ComboBox();
            this.textBox_Fecha = new System.Windows.Forms.TextBox();
            this.label_FHinicio = new System.Windows.Forms.Label();
            this.label_Turno = new System.Windows.Forms.Label();
            this.label_Chofer = new System.Windows.Forms.Label();
            this.monthCalendar_Fecha = new System.Windows.Forms.MonthCalendar();
            this.dataGridView_Viajes_Rendidos = new System.Windows.Forms.DataGridView();
            this.button_Cancelar = new System.Windows.Forms.Button();
            this.button_Limpiar = new System.Windows.Forms.Button();
            this.btnFacturar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox_datosViaje.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Viajes_Rendidos)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox_datosViaje
            // 
            this.groupBox_datosViaje.Controls.Add(this.label1);
            this.groupBox_datosViaje.Controls.Add(this.textBox_importe);
            this.groupBox_datosViaje.Controls.Add(this.label_Importe);
            this.groupBox_datosViaje.Controls.Add(this.button_FechaDeRendicion);
            this.groupBox_datosViaje.Controls.Add(this.comboBox_Turnos);
            this.groupBox_datosViaje.Controls.Add(this.comboBox_chofer);
            this.groupBox_datosViaje.Controls.Add(this.textBox_Fecha);
            this.groupBox_datosViaje.Controls.Add(this.label_FHinicio);
            this.groupBox_datosViaje.Controls.Add(this.label_Turno);
            this.groupBox_datosViaje.Controls.Add(this.label_Chofer);
            this.groupBox_datosViaje.Controls.Add(this.monthCalendar_Fecha);
            this.groupBox_datosViaje.Location = new System.Drawing.Point(12, 12);
            this.groupBox_datosViaje.Name = "groupBox_datosViaje";
            this.groupBox_datosViaje.Size = new System.Drawing.Size(833, 176);
            this.groupBox_datosViaje.TabIndex = 1;
            this.groupBox_datosViaje.TabStop = false;
            this.groupBox_datosViaje.Text = "Datos";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(6, 160);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(625, 13);
            this.label1.TabIndex = 45;
            this.label1.Text = "AVISO: Se deben cargar todos los campos, antes de ingresar un turno deberan estar" +
    " cargados previamente Chofer(DNI) y la Fecha";
            // 
            // textBox_importe
            // 
            this.textBox_importe.Location = new System.Drawing.Point(105, 126);
            this.textBox_importe.Name = "textBox_importe";
            this.textBox_importe.ReadOnly = true;
            this.textBox_importe.Size = new System.Drawing.Size(273, 20);
            this.textBox_importe.TabIndex = 44;
            // 
            // label_Importe
            // 
            this.label_Importe.AutoSize = true;
            this.label_Importe.Location = new System.Drawing.Point(6, 126);
            this.label_Importe.Name = "label_Importe";
            this.label_Importe.Size = new System.Drawing.Size(42, 13);
            this.label_Importe.TabIndex = 43;
            this.label_Importe.Text = "Importe";
            // 
            // button_FechaDeRendicion
            // 
            this.button_FechaDeRendicion.Location = new System.Drawing.Point(298, 26);
            this.button_FechaDeRendicion.Name = "button_FechaDeRendicion";
            this.button_FechaDeRendicion.Size = new System.Drawing.Size(80, 20);
            this.button_FechaDeRendicion.TabIndex = 41;
            this.button_FechaDeRendicion.Text = "Seleccionar";
            this.button_FechaDeRendicion.UseVisualStyleBackColor = true;
            this.button_FechaDeRendicion.Click += new System.EventHandler(this.button_FechaDeRendicion_Click);
            // 
            // comboBox_Turnos
            // 
            this.comboBox_Turnos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Turnos.FormattingEnabled = true;
            this.comboBox_Turnos.Location = new System.Drawing.Point(105, 90);
            this.comboBox_Turnos.Name = "comboBox_Turnos";
            this.comboBox_Turnos.Size = new System.Drawing.Size(273, 21);
            this.comboBox_Turnos.TabIndex = 38;
            this.comboBox_Turnos.SelectedIndexChanged += new System.EventHandler(this.comboBox_Turnos_SelectedIndexChanged);
            // 
            // comboBox_chofer
            // 
            this.comboBox_chofer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_chofer.FormattingEnabled = true;
            this.comboBox_chofer.Location = new System.Drawing.Point(105, 58);
            this.comboBox_chofer.Name = "comboBox_chofer";
            this.comboBox_chofer.Size = new System.Drawing.Size(273, 21);
            this.comboBox_chofer.TabIndex = 37;
            // 
            // textBox_Fecha
            // 
            this.textBox_Fecha.Location = new System.Drawing.Point(105, 26);
            this.textBox_Fecha.Name = "textBox_Fecha";
            this.textBox_Fecha.ReadOnly = true;
            this.textBox_Fecha.Size = new System.Drawing.Size(177, 20);
            this.textBox_Fecha.TabIndex = 32;
            // 
            // label_FHinicio
            // 
            this.label_FHinicio.AutoSize = true;
            this.label_FHinicio.Location = new System.Drawing.Point(6, 26);
            this.label_FHinicio.Name = "label_FHinicio";
            this.label_FHinicio.Size = new System.Drawing.Size(37, 13);
            this.label_FHinicio.TabIndex = 31;
            this.label_FHinicio.Text = "Fecha";
            // 
            // label_Turno
            // 
            this.label_Turno.AutoSize = true;
            this.label_Turno.Location = new System.Drawing.Point(6, 90);
            this.label_Turno.Name = "label_Turno";
            this.label_Turno.Size = new System.Drawing.Size(35, 13);
            this.label_Turno.TabIndex = 27;
            this.label_Turno.Text = "Turno";
            // 
            // label_Chofer
            // 
            this.label_Chofer.AutoSize = true;
            this.label_Chofer.Location = new System.Drawing.Point(6, 58);
            this.label_Chofer.Name = "label_Chofer";
            this.label_Chofer.Size = new System.Drawing.Size(66, 13);
            this.label_Chofer.TabIndex = 22;
            this.label_Chofer.Text = "Chofer (DNI)";
            // 
            // monthCalendar_Fecha
            // 
            this.monthCalendar_Fecha.Location = new System.Drawing.Point(390, 0);
            this.monthCalendar_Fecha.Name = "monthCalendar_Fecha";
            this.monthCalendar_Fecha.TabIndex = 42;
            this.monthCalendar_Fecha.Visible = false;
            this.monthCalendar_Fecha.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar_FechaDeRendicion_DateSelected);
            // 
            // dataGridView_Viajes_Rendidos
            // 
            this.dataGridView_Viajes_Rendidos.AllowUserToAddRows = false;
            this.dataGridView_Viajes_Rendidos.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_Viajes_Rendidos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_Viajes_Rendidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Viajes_Rendidos.EnableHeadersVisualStyles = false;
            this.dataGridView_Viajes_Rendidos.Location = new System.Drawing.Point(12, 287);
            this.dataGridView_Viajes_Rendidos.MultiSelect = false;
            this.dataGridView_Viajes_Rendidos.Name = "dataGridView_Viajes_Rendidos";
            this.dataGridView_Viajes_Rendidos.ReadOnly = true;
            this.dataGridView_Viajes_Rendidos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Viajes_Rendidos.Size = new System.Drawing.Size(949, 180);
            this.dataGridView_Viajes_Rendidos.TabIndex = 5;
            // 
            // button_Cancelar
            // 
            this.button_Cancelar.Location = new System.Drawing.Point(12, 473);
            this.button_Cancelar.Name = "button_Cancelar";
            this.button_Cancelar.Size = new System.Drawing.Size(100, 30);
            this.button_Cancelar.TabIndex = 6;
            this.button_Cancelar.Text = "Volver";
            this.button_Cancelar.UseVisualStyleBackColor = true;
            this.button_Cancelar.Click += new System.EventHandler(this.button_Cancelar_Click);
            // 
            // button_Limpiar
            // 
            this.button_Limpiar.Location = new System.Drawing.Point(428, 473);
            this.button_Limpiar.Name = "button_Limpiar";
            this.button_Limpiar.Size = new System.Drawing.Size(100, 30);
            this.button_Limpiar.TabIndex = 7;
            this.button_Limpiar.Text = "Limpiar";
            this.button_Limpiar.UseVisualStyleBackColor = true;
            this.button_Limpiar.Click += new System.EventHandler(this.button_Limpiar_Click);
            // 
            // btnFacturar
            // 
            this.btnFacturar.Location = new System.Drawing.Point(861, 473);
            this.btnFacturar.Name = "btnFacturar";
            this.btnFacturar.Size = new System.Drawing.Size(100, 30);
            this.btnFacturar.TabIndex = 8;
            this.btnFacturar.Text = "Generar";
            this.btnFacturar.UseVisualStyleBackColor = true;
            this.btnFacturar.Click += new System.EventHandler(this.btnFacturar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(17, 264);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 20);
            this.label4.TabIndex = 45;
            this.label4.Text = "Viajes a Rendir :";
            // 
            // RendicionViaje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::UberFrba.Properties.Resources.HUAYI_triaxial_space_wood_floor_photography_backdrops_font_b_pine_b_font_font_b_plank_b;
            this.ClientSize = new System.Drawing.Size(973, 551);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnFacturar);
            this.Controls.Add(this.button_Limpiar);
            this.Controls.Add(this.button_Cancelar);
            this.Controls.Add(this.dataGridView_Viajes_Rendidos);
            this.Controls.Add(this.groupBox_datosViaje);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RendicionViaje";
            this.Text = "Rendicion de Viajes";
            this.Load += new System.EventHandler(this.RendicionViaje_Load);
            this.groupBox_datosViaje.ResumeLayout(false);
            this.groupBox_datosViaje.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Viajes_Rendidos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_datosViaje;
        private System.Windows.Forms.TextBox textBox_importe;
        private System.Windows.Forms.Label label_Importe;
        private System.Windows.Forms.Button button_FechaDeRendicion;
        private System.Windows.Forms.ComboBox comboBox_Turnos;
        private System.Windows.Forms.ComboBox comboBox_chofer;
        private System.Windows.Forms.TextBox textBox_Fecha;
        private System.Windows.Forms.Label label_FHinicio;
        private System.Windows.Forms.Label label_Turno;
        private System.Windows.Forms.Label label_Chofer;
        private System.Windows.Forms.MonthCalendar monthCalendar_Fecha;
        private System.Windows.Forms.DataGridView dataGridView_Viajes_Rendidos;
        private System.Windows.Forms.Button button_Cancelar;
        private System.Windows.Forms.Button button_Limpiar;
        private System.Windows.Forms.Button btnFacturar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
    }
}