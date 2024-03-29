using System.Windows.Forms;
namespace UberFrba.ABM_Cliente
{
    partial class FiltroCliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FiltroCliente));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_DNI = new System.Windows.Forms.TextBox();
            this.textBox_Apellido = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_Nombre = new System.Windows.Forms.TextBox();
            this.button_Buscar = new System.Windows.Forms.Button();
            this.button_Limpiar = new System.Windows.Forms.Button();
            this.button_Cancelar = new System.Windows.Forms.Button();
            this.dataGridView_Cliente = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Cliente)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Wheat;
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox_DNI);
            this.groupBox1.Controls.Add(this.textBox_Apellido);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox_Nombre);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(368, 101);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtro de busquedad";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "DNI";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Apellido";
            // 
            // textBox_DNI
            // 
            this.textBox_DNI.Location = new System.Drawing.Point(77, 71);
            this.textBox_DNI.Name = "textBox_DNI";
            this.textBox_DNI.Size = new System.Drawing.Size(285, 20);
            this.textBox_DNI.TabIndex = 4;
            // 
            // textBox_Apellido
            // 
            this.textBox_Apellido.Location = new System.Drawing.Point(77, 45);
            this.textBox_Apellido.Name = "textBox_Apellido";
            this.textBox_Apellido.Size = new System.Drawing.Size(285, 20);
            this.textBox_Apellido.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre";
            // 
            // textBox_Nombre
            // 
            this.textBox_Nombre.Location = new System.Drawing.Point(77, 19);
            this.textBox_Nombre.Name = "textBox_Nombre";
            this.textBox_Nombre.Size = new System.Drawing.Size(285, 20);
            this.textBox_Nombre.TabIndex = 0;
            // 
            // button_Buscar
            // 
            this.button_Buscar.Location = new System.Drawing.Point(280, 119);
            this.button_Buscar.Name = "button_Buscar";
            this.button_Buscar.Size = new System.Drawing.Size(100, 30);
            this.button_Buscar.TabIndex = 1;
            this.button_Buscar.Text = "Buscar";
            this.button_Buscar.UseVisualStyleBackColor = true;
            this.button_Buscar.Click += new System.EventHandler(this.button_Buscar_Click);
            // 
            // button_Limpiar
            // 
            this.button_Limpiar.Location = new System.Drawing.Point(175, 119);
            this.button_Limpiar.Name = "button_Limpiar";
            this.button_Limpiar.Size = new System.Drawing.Size(100, 30);
            this.button_Limpiar.TabIndex = 2;
            this.button_Limpiar.Text = "Limpiar";
            this.button_Limpiar.UseVisualStyleBackColor = true;
            this.button_Limpiar.Click += new System.EventHandler(this.button_Limpiar_Click);
            // 
            // button_Cancelar
            // 
            this.button_Cancelar.Location = new System.Drawing.Point(12, 119);
            this.button_Cancelar.Name = "button_Cancelar";
            this.button_Cancelar.Size = new System.Drawing.Size(100, 30);
            this.button_Cancelar.TabIndex = 3;
            this.button_Cancelar.Text = "Volver";
            this.button_Cancelar.UseVisualStyleBackColor = true;
            this.button_Cancelar.Click += new System.EventHandler(this.button_Cancelar_Click);
            // 
            // dataGridView_Cliente
            // 
            this.dataGridView_Cliente.AllowUserToAddRows = false;
            this.dataGridView_Cliente.AllowUserToDeleteRows = false;
            this.dataGridView_Cliente.BackgroundColor = System.Drawing.Color.Wheat;
            this.dataGridView_Cliente.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_Cliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Cliente.Location = new System.Drawing.Point(12, 155);
            this.dataGridView_Cliente.Name = "dataGridView_Cliente";
            this.dataGridView_Cliente.RowTemplate.ReadOnly = true;
            this.dataGridView_Cliente.Size = new System.Drawing.Size(1258, 212);
            this.dataGridView_Cliente.TabIndex = 4;
            this.dataGridView_Cliente.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Cliente_CellClick);
            // 
            // FiltroCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::UberFrba.Properties.Resources.HUAYI_triaxial_space_wood_floor_photography_backdrops_font_b_pine_b_font_font_b_plank_b;
            this.ClientSize = new System.Drawing.Size(1282, 400);
            this.Controls.Add(this.dataGridView_Cliente);
            this.Controls.Add(this.button_Cancelar);
            this.Controls.Add(this.button_Limpiar);
            this.Controls.Add(this.button_Buscar);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FiltroCliente";
            this.Text = "Filtro de clientes";
            this.Load += new System.EventHandler(this.FiltroCliente_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Cliente)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_DNI;
        private System.Windows.Forms.TextBox textBox_Apellido;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_Nombre;
        private System.Windows.Forms.Button button_Buscar;
        private System.Windows.Forms.Button button_Limpiar;
        private System.Windows.Forms.Button button_Cancelar;
        private System.Windows.Forms.DataGridView dataGridView_Cliente;
    }
}