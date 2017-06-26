namespace UberFrba.Registro_Viajes
{
    partial class RegistrarViaje
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistrarViaje));
            this.groupBox_datosViaje = new System.Windows.Forms.GroupBox();
            this.horaFin = new System.Windows.Forms.DateTimePicker();
            this.horaInicio = new System.Windows.Forms.DateTimePicker();
            this.monthCalendar_FechaDeViaje = new System.Windows.Forms.MonthCalendar();
            this.button_FechaDeRegistroViaje = new System.Windows.Forms.Button();
            this.label_Hinicio = new System.Windows.Forms.Label();
            this.comboBox_TurnosAutmovilSeleccionado = new System.Windows.Forms.ComboBox();
            this.comboBox_chofer = new System.Windows.Forms.ComboBox();
            this.textBox_Cliente = new System.Windows.Forms.TextBox();
            this.label_Cliente = new System.Windows.Forms.Label();
            this.textBox_Fecha = new System.Windows.Forms.TextBox();
            this.label_FHinicio = new System.Windows.Forms.Label();
            this.label_Hfin = new System.Windows.Forms.Label();
            this.textBox_CantidadKm = new System.Windows.Forms.TextBox();
            this.label_CantidadKm = new System.Windows.Forms.Label();
            this.label_Turno = new System.Windows.Forms.Label();
            this.textBox_Automovil = new System.Windows.Forms.TextBox();
            this.label_Automovil = new System.Windows.Forms.Label();
            this.label_Chofer = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.button_Cancelar = new System.Windows.Forms.Button();
            this.button_Limpiar = new System.Windows.Forms.Button();
            this.button_Guardar = new System.Windows.Forms.Button();
            this.groupBox_datosViaje.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_datosViaje
            // 
            this.groupBox_datosViaje.Controls.Add(this.horaFin);
            this.groupBox_datosViaje.Controls.Add(this.horaInicio);
            this.groupBox_datosViaje.Controls.Add(this.monthCalendar_FechaDeViaje);
            this.groupBox_datosViaje.Controls.Add(this.button_FechaDeRegistroViaje);
            this.groupBox_datosViaje.Controls.Add(this.label_Hinicio);
            this.groupBox_datosViaje.Controls.Add(this.comboBox_TurnosAutmovilSeleccionado);
            this.groupBox_datosViaje.Controls.Add(this.comboBox_chofer);
            this.groupBox_datosViaje.Controls.Add(this.textBox_Cliente);
            this.groupBox_datosViaje.Controls.Add(this.label_Cliente);
            this.groupBox_datosViaje.Controls.Add(this.textBox_Fecha);
            this.groupBox_datosViaje.Controls.Add(this.label_FHinicio);
            this.groupBox_datosViaje.Controls.Add(this.label_Hfin);
            this.groupBox_datosViaje.Controls.Add(this.textBox_CantidadKm);
            this.groupBox_datosViaje.Controls.Add(this.label_CantidadKm);
            this.groupBox_datosViaje.Controls.Add(this.label_Turno);
            this.groupBox_datosViaje.Controls.Add(this.textBox_Automovil);
            this.groupBox_datosViaje.Controls.Add(this.label_Automovil);
            this.groupBox_datosViaje.Controls.Add(this.label_Chofer);
            this.groupBox_datosViaje.Location = new System.Drawing.Point(12, 12);
            this.groupBox_datosViaje.Name = "groupBox_datosViaje";
            this.groupBox_datosViaje.Size = new System.Drawing.Size(437, 242);
            this.groupBox_datosViaje.TabIndex = 0;
            this.groupBox_datosViaje.TabStop = false;
            this.groupBox_datosViaje.Text = "Datos del Viaje";
            // 
            // horaFin
            // 
            this.horaFin.CustomFormat = "HH:mm";
            this.horaFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.horaFin.Location = new System.Drawing.Point(321, 207);
            this.horaFin.Name = "horaFin";
            this.horaFin.ShowUpDown = true;
            this.horaFin.Size = new System.Drawing.Size(92, 20);
            this.horaFin.TabIndex = 44;
            this.horaFin.Value = new System.DateTime(2017, 5, 1, 0, 0, 0, 0);
            // 
            // horaInicio
            // 
            this.horaInicio.CustomFormat = "HH:mm";
            this.horaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.horaInicio.Location = new System.Drawing.Point(128, 207);
            this.horaInicio.Name = "horaInicio";
            this.horaInicio.ShowUpDown = true;
            this.horaInicio.Size = new System.Drawing.Size(92, 20);
            this.horaInicio.TabIndex = 43;
            this.horaInicio.Value = new System.DateTime(2017, 5, 1, 0, 0, 0, 0);
            // 
            // monthCalendar_FechaDeViaje
            // 
            this.monthCalendar_FechaDeViaje.Location = new System.Drawing.Point(239, 6);
            this.monthCalendar_FechaDeViaje.Name = "monthCalendar_FechaDeViaje";
            this.monthCalendar_FechaDeViaje.TabIndex = 42;
            this.monthCalendar_FechaDeViaje.Visible = false;
            this.monthCalendar_FechaDeViaje.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar_FechaDeViaje_DateSelected);
            // 
            // button_FechaDeRegistroViaje
            // 
            this.button_FechaDeRegistroViaje.Location = new System.Drawing.Point(321, 146);
            this.button_FechaDeRegistroViaje.Name = "button_FechaDeRegistroViaje";
            this.button_FechaDeRegistroViaje.Size = new System.Drawing.Size(80, 20);
            this.button_FechaDeRegistroViaje.TabIndex = 41;
            this.button_FechaDeRegistroViaje.Text = "Seleccionar";
            this.button_FechaDeRegistroViaje.UseVisualStyleBackColor = true;
            this.button_FechaDeRegistroViaje.Click += new System.EventHandler(this.button_FechaDeRegistroViaje_Click);
            // 
            // label_Hinicio
            // 
            this.label_Hinicio.AutoSize = true;
            this.label_Hinicio.Location = new System.Drawing.Point(6, 207);
            this.label_Hinicio.Name = "label_Hinicio";
            this.label_Hinicio.Size = new System.Drawing.Size(99, 13);
            this.label_Hinicio.TabIndex = 39;
            this.label_Hinicio.Text = "Hora inicio del viaje";
            // 
            // comboBox_TurnosAutmovilSeleccionado
            // 
            this.comboBox_TurnosAutmovilSeleccionado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_TurnosAutmovilSeleccionado.FormattingEnabled = true;
            this.comboBox_TurnosAutmovilSeleccionado.Location = new System.Drawing.Point(127, 86);
            this.comboBox_TurnosAutmovilSeleccionado.Name = "comboBox_TurnosAutmovilSeleccionado";
            this.comboBox_TurnosAutmovilSeleccionado.Size = new System.Drawing.Size(273, 21);
            this.comboBox_TurnosAutmovilSeleccionado.TabIndex = 38;
            // 
            // comboBox_chofer
            // 
            this.comboBox_chofer.BackColor = System.Drawing.Color.White;
            this.comboBox_chofer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_chofer.FormattingEnabled = true;
            this.comboBox_chofer.Location = new System.Drawing.Point(127, 27);
            this.comboBox_chofer.Name = "comboBox_chofer";
            this.comboBox_chofer.Size = new System.Drawing.Size(273, 21);
            this.comboBox_chofer.TabIndex = 37;
            this.comboBox_chofer.SelectedIndexChanged += new System.EventHandler(this.comboBox_chofer_SelectionChangeCommitted);
            // 
            // textBox_Cliente
            // 
            this.textBox_Cliente.Location = new System.Drawing.Point(128, 172);
            this.textBox_Cliente.Name = "textBox_Cliente";
            this.textBox_Cliente.Size = new System.Drawing.Size(273, 20);
            this.textBox_Cliente.TabIndex = 35;
            // 
            // label_Cliente
            // 
            this.label_Cliente.AutoSize = true;
            this.label_Cliente.Location = new System.Drawing.Point(6, 172);
            this.label_Cliente.Name = "label_Cliente";
            this.label_Cliente.Size = new System.Drawing.Size(67, 13);
            this.label_Cliente.TabIndex = 34;
            this.label_Cliente.Text = "Cliente (DNI)";
            // 
            // textBox_Fecha
            // 
            this.textBox_Fecha.Location = new System.Drawing.Point(128, 145);
            this.textBox_Fecha.Name = "textBox_Fecha";
            this.textBox_Fecha.ReadOnly = true;
            this.textBox_Fecha.Size = new System.Drawing.Size(177, 20);
            this.textBox_Fecha.TabIndex = 32;
            // 
            // label_FHinicio
            // 
            this.label_FHinicio.AutoSize = true;
            this.label_FHinicio.Location = new System.Drawing.Point(6, 145);
            this.label_FHinicio.Name = "label_FHinicio";
            this.label_FHinicio.Size = new System.Drawing.Size(37, 13);
            this.label_FHinicio.TabIndex = 31;
            this.label_FHinicio.Text = "Fecha";
            // 
            // label_Hfin
            // 
            this.label_Hfin.AutoSize = true;
            this.label_Hfin.Location = new System.Drawing.Point(229, 207);
            this.label_Hfin.Name = "label_Hfin";
            this.label_Hfin.Size = new System.Drawing.Size(86, 13);
            this.label_Hfin.TabIndex = 30;
            this.label_Hfin.Text = "Hora fin del viaje";
            // 
            // textBox_CantidadKm
            // 
            this.textBox_CantidadKm.Location = new System.Drawing.Point(127, 116);
            this.textBox_CantidadKm.Name = "textBox_CantidadKm";
            this.textBox_CantidadKm.Size = new System.Drawing.Size(273, 20);
            this.textBox_CantidadKm.TabIndex = 29;
            // 
            // label_CantidadKm
            // 
            this.label_CantidadKm.AutoSize = true;
            this.label_CantidadKm.Location = new System.Drawing.Point(6, 116);
            this.label_CantidadKm.Name = "label_CantidadKm";
            this.label_CantidadKm.Size = new System.Drawing.Size(115, 13);
            this.label_CantidadKm.TabIndex = 28;
            this.label_CantidadKm.Text = "Cantidad de Kilometros";
            // 
            // label_Turno
            // 
            this.label_Turno.AutoSize = true;
            this.label_Turno.Location = new System.Drawing.Point(6, 86);
            this.label_Turno.Name = "label_Turno";
            this.label_Turno.Size = new System.Drawing.Size(35, 13);
            this.label_Turno.TabIndex = 27;
            this.label_Turno.Text = "Turno";
            // 
            // textBox_Automovil
            // 
            this.textBox_Automovil.Location = new System.Drawing.Point(128, 57);
            this.textBox_Automovil.Name = "textBox_Automovil";
            this.textBox_Automovil.ReadOnly = true;
            this.textBox_Automovil.Size = new System.Drawing.Size(273, 20);
            this.textBox_Automovil.TabIndex = 25;
            // 
            // label_Automovil
            // 
            this.label_Automovil.AutoSize = true;
            this.label_Automovil.Location = new System.Drawing.Point(6, 57);
            this.label_Automovil.Name = "label_Automovil";
            this.label_Automovil.Size = new System.Drawing.Size(112, 13);
            this.label_Automovil.TabIndex = 24;
            this.label_Automovil.Text = "Automovil (PATENTE)";
            // 
            // label_Chofer
            // 
            this.label_Chofer.AutoSize = true;
            this.label_Chofer.Location = new System.Drawing.Point(6, 27);
            this.label_Chofer.Name = "label_Chofer";
            this.label_Chofer.Size = new System.Drawing.Size(66, 13);
            this.label_Chofer.TabIndex = 22;
            this.label_Chofer.Text = "Chofer (DNI)";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(12, 277);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(174, 13);
            this.label14.TabIndex = 36;
            this.label14.Text = "* Debe completar todos los campos";
            // 
            // button_Cancelar
            // 
            this.button_Cancelar.Location = new System.Drawing.Point(21, 305);
            this.button_Cancelar.Name = "button_Cancelar";
            this.button_Cancelar.Size = new System.Drawing.Size(100, 30);
            this.button_Cancelar.TabIndex = 37;
            this.button_Cancelar.Text = "Volver";
            this.button_Cancelar.UseVisualStyleBackColor = true;
            this.button_Cancelar.Click += new System.EventHandler(this.button_Cancelar_Click);
            // 
            // button_Limpiar
            // 
            this.button_Limpiar.Location = new System.Drawing.Point(170, 305);
            this.button_Limpiar.Name = "button_Limpiar";
            this.button_Limpiar.Size = new System.Drawing.Size(100, 30);
            this.button_Limpiar.TabIndex = 38;
            this.button_Limpiar.Text = "Limpiar";
            this.button_Limpiar.UseVisualStyleBackColor = true;
            this.button_Limpiar.Click += new System.EventHandler(this.button_Limpiar_Click);
            // 
            // button_Guardar
            // 
            this.button_Guardar.Location = new System.Drawing.Point(325, 305);
            this.button_Guardar.Name = "button_Guardar";
            this.button_Guardar.Size = new System.Drawing.Size(100, 30);
            this.button_Guardar.TabIndex = 39;
            this.button_Guardar.Text = "Guardar";
            this.button_Guardar.UseVisualStyleBackColor = true;
            this.button_Guardar.Click += new System.EventHandler(this.button_Guardar_Click);
            // 
            // RegistrarViaje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::UberFrba.Properties.Resources.HUAYI_triaxial_space_wood_floor_photography_backdrops_font_b_pine_b_font_font_b_plank_b;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(461, 352);
            this.Controls.Add(this.button_Guardar);
            this.Controls.Add(this.button_Limpiar);
            this.Controls.Add(this.button_Cancelar);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.groupBox_datosViaje);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RegistrarViaje";
            this.Text = "RegistrarViaje";
            this.Load += new System.EventHandler(this.RegistrarViaje_Load);
            this.groupBox_datosViaje.ResumeLayout(false);
            this.groupBox_datosViaje.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_datosViaje;
        private System.Windows.Forms.Label label_Chofer;
        private System.Windows.Forms.Label label_Automovil;
        private System.Windows.Forms.Label label_Turno;
        private System.Windows.Forms.TextBox textBox_Automovil;
        private System.Windows.Forms.Label label_CantidadKm;
        private System.Windows.Forms.TextBox textBox_CantidadKm;
        private System.Windows.Forms.TextBox textBox_Cliente;
        private System.Windows.Forms.Label label_Cliente;
        private System.Windows.Forms.TextBox textBox_Fecha;
        private System.Windows.Forms.Label label_FHinicio;
        private System.Windows.Forms.Label label_Hfin;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button button_Cancelar;
        private System.Windows.Forms.Button button_Limpiar;
        private System.Windows.Forms.ComboBox comboBox_chofer;
        private System.Windows.Forms.ComboBox comboBox_TurnosAutmovilSeleccionado;
        private System.Windows.Forms.Label label_Hinicio;
        private System.Windows.Forms.Button button_FechaDeRegistroViaje;
        private System.Windows.Forms.MonthCalendar monthCalendar_FechaDeViaje;
        private System.Windows.Forms.DateTimePicker horaFin;
        private System.Windows.Forms.DateTimePicker horaInicio;
        private System.Windows.Forms.Button button_Guardar;
    }
}