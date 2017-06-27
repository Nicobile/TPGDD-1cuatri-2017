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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.seleccionAño = new System.Windows.Forms.DateTimePicker();
            this.año = new System.Windows.Forms.Label();
            this.listado = new System.Windows.Forms.DataGridView();
            this.btnVolver = new System.Windows.Forms.Button();
            this.seleccionTrimestre = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SeleccionEstadistica = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.listado)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Seleccione una estadistica";
            // 
            // seleccionAño
            // 
            this.seleccionAño.CustomFormat = "yyyy";
            this.seleccionAño.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.seleccionAño.Location = new System.Drawing.Point(246, 70);
            this.seleccionAño.Name = "seleccionAño";
            this.seleccionAño.ShowUpDown = true;
            this.seleccionAño.Size = new System.Drawing.Size(82, 20);
            this.seleccionAño.TabIndex = 6;
            // 
            // año
            // 
            this.año.AutoSize = true;
            this.año.Location = new System.Drawing.Point(14, 77);
            this.año.Name = "año";
            this.año.Size = new System.Drawing.Size(96, 13);
            this.año.TabIndex = 7;
            this.año.Text = "Seleccione un año";
            // 
            // listado
            // 
            this.listado.AllowUserToAddRows = false;
            this.listado.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.listado.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.listado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listado.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.listado.EnableHeadersVisualStyles = false;
            this.listado.Location = new System.Drawing.Point(12, 189);
            this.listado.MultiSelect = false;
            this.listado.Name = "listado";
            this.listado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.listado.Size = new System.Drawing.Size(622, 172);
            this.listado.TabIndex = 10;
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(15, 386);
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
            this.seleccionTrimestre.Location = new System.Drawing.Point(246, 113);
            this.seleccionTrimestre.Name = "seleccionTrimestre";
            this.seleccionTrimestre.Size = new System.Drawing.Size(300, 21);
            this.seleccionTrimestre.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Seleccione un trimestre";
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
            this.SeleccionEstadistica.Location = new System.Drawing.Point(246, 35);
            this.SeleccionEstadistica.Name = "SeleccionEstadistica";
            this.SeleccionEstadistica.Size = new System.Drawing.Size(300, 21);
            this.SeleccionEstadistica.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(539, 158);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 25);
            this.button1.TabIndex = 14;
            this.button1.Text = "Calcular";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ListadoEstadistico
            // 
            this.BackgroundImage = global::UberFrba.Properties.Resources.HUAYI_triaxial_space_wood_floor_photography_backdrops_font_b_pine_b_font_font_b_plank_b;
            this.ClientSize = new System.Drawing.Size(648, 423);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.seleccionTrimestre);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.listado);
            this.Controls.Add(this.seleccionAño);
            this.Controls.Add(this.año);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SeleccionEstadistica);
            this.Name = "ListadoEstadistico";
            this.Text = "Listado Estadistico";
          
            ((System.ComponentModel.ISupportInitialize)(this.listado)).EndInit();
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

  
    }
}