namespace UberFrba.Listado_Estadistico
{
    partial class ListadoEstadistico
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListadoEstadistico));
            this.label1 = new System.Windows.Forms.Label();
            this.seleccionAño = new System.Windows.Forms.DateTimePicker();
            this.año = new System.Windows.Forms.Label();
            this.listado = new System.Windows.Forms.DataGridView();
            this.btnVolver = new System.Windows.Forms.Button();
            this.seleccionTrimestre = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SeleccionEstadistica = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_Limpiar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.listado)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Seleccione una Estadistica";
            // 
            // seleccionAño
            // 
            this.seleccionAño.CustomFormat = "yyyy";
            this.seleccionAño.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.seleccionAño.Location = new System.Drawing.Point(152, 95);
            this.seleccionAño.Name = "seleccionAño";
            this.seleccionAño.ShowUpDown = true;
            this.seleccionAño.Size = new System.Drawing.Size(82, 20);
            this.seleccionAño.TabIndex = 6;
            // 
            // año
            // 
            this.año.AutoSize = true;
            this.año.Location = new System.Drawing.Point(12, 95);
            this.año.Name = "año";
            this.año.Size = new System.Drawing.Size(97, 13);
            this.año.TabIndex = 7;
            this.año.Text = "Seleccione un Año";
            // 
            // listado
            // 
            this.listado.AllowUserToAddRows = false;
            this.listado.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.listado.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.listado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listado.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.listado.EnableHeadersVisualStyles = false;
            this.listado.Location = new System.Drawing.Point(58, 208);
            this.listado.MultiSelect = false;
            this.listado.Name = "listado";
            this.listado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.listado.Size = new System.Drawing.Size(494, 172);
            this.listado.TabIndex = 10;
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(35, 386);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(95, 25);
            this.btnVolver.TabIndex = 11;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // seleccionTrimestre
            // 
            this.seleccionTrimestre.AutoCompleteCustomSource.AddRange(new string[] {
            "Choferes con mayor recaudación",
            "Choferes con viajes mas largos",
            "Clientes con mayor consumo",
            "Clientes con mayor cantidad de veces utilizado el mismo vehiculo"});
            this.seleccionTrimestre.DisplayMember = "0";
            this.seleccionTrimestre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.seleccionTrimestre.FormattingEnabled = true;
            this.seleccionTrimestre.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.seleccionTrimestre.Items.AddRange(new object[] {
            "Primer trimestre",
            "Segundo trimestre",
            "Tercer trimestre",
            "Cuarto trimestre"});
            this.seleccionTrimestre.Location = new System.Drawing.Point(152, 57);
            this.seleccionTrimestre.Name = "seleccionTrimestre";
            this.seleccionTrimestre.Size = new System.Drawing.Size(250, 21);
            this.seleccionTrimestre.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Seleccione un Trimestre";
            // 
            // SeleccionEstadistica
            // 
            this.SeleccionEstadistica.AutoCompleteCustomSource.AddRange(new string[] {
            "Choferes con mayor recaudación",
            "Choferes con viajes mas largos",
            "Clientes con mayor consumo",
            "Clientes con mayor cantidad de veces utilizado el mismo vehiculo"});
            this.SeleccionEstadistica.DisplayMember = "0";
            this.SeleccionEstadistica.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SeleccionEstadistica.FormattingEnabled = true;
            this.SeleccionEstadistica.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.SeleccionEstadistica.Items.AddRange(new object[] {
            "Choferes con mayor recaudación",
            "Choferes que realizaron viajes más largos",
            "Clientes de mayor consumo",
            "Clientes que viajaron mayor cantidad de veces en un mismo auto"});
            this.SeleccionEstadistica.Location = new System.Drawing.Point(152, 30);
            this.SeleccionEstadistica.Name = "SeleccionEstadistica";
            this.SeleccionEstadistica.Size = new System.Drawing.Size(250, 21);
            this.SeleccionEstadistica.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(457, 386);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 25);
            this.button1.TabIndex = 14;
            this.button1.Text = "Calcular";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(12, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(212, 13);
            this.label2.TabIndex = 46;
            this.label2.Text = "AVISO: Se deben cargar todos los campos.";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.seleccionTrimestre);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.año);
            this.groupBox1.Controls.Add(this.SeleccionEstadistica);
            this.groupBox1.Controls.Add(this.seleccionAño);
            this.groupBox1.Location = new System.Drawing.Point(35, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(426, 155);
            this.groupBox1.TabIndex = 47;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seleccionar Datos";
            // 
            // button_Limpiar
            // 
            this.button_Limpiar.Location = new System.Drawing.Point(236, 386);
            this.button_Limpiar.Name = "button_Limpiar";
            this.button_Limpiar.Size = new System.Drawing.Size(100, 25);
            this.button_Limpiar.TabIndex = 47;
            this.button_Limpiar.Text = "Limpiar";
            this.button_Limpiar.UseVisualStyleBackColor = true;
            this.button_Limpiar.Click += new System.EventHandler(this.button_Limpiar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(31, 185);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 20);
            this.label4.TabIndex = 48;
            this.label4.Text = "Estadísticas :";
            // 
            // ListadoEstadistico
            // 
            this.BackgroundImage = global::UberFrba.Properties.Resources.HUAYI_triaxial_space_wood_floor_photography_backdrops_font_b_pine_b_font_font_b_plank_b;
            this.ClientSize = new System.Drawing.Size(564, 419);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button_Limpiar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.listado);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ListadoEstadistico";
            this.Text = "Listado Estadistico";
            ((System.ComponentModel.ISupportInitialize)(this.listado)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker seleccionAño;
        private System.Windows.Forms.Label año;
        private System.Windows.Forms.DataGridView listado;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.ComboBox seleccionTrimestre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox SeleccionEstadistica;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_Limpiar;
        private System.Windows.Forms.Label label4;

  
    }
}