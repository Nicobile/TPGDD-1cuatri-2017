﻿namespace UberFrba.Abm_Automovil
{
    partial class AgregarAuto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AgregarAuto));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox_Turno = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_Patente = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_Modelo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_Marca = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.button_Cancelar = new System.Windows.Forms.Button();
            this.button_Limpiar = new System.Windows.Forms.Button();
            this.button_Guardar = new System.Windows.Forms.Button();
            this.combo_Chofer = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Wheat;
            this.groupBox1.Controls.Add(this.combo_Chofer);
            this.groupBox1.Controls.Add(this.comboBox_Turno);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox_Patente);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox_Modelo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBox_Marca);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Location = new System.Drawing.Point(12, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(368, 181);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // comboBox_Turno
            // 
            this.comboBox_Turno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Turno.FormattingEnabled = true;
            this.comboBox_Turno.Location = new System.Drawing.Point(91, 99);
            this.comboBox_Turno.Name = "comboBox_Turno";
            this.comboBox_Turno.Size = new System.Drawing.Size(271, 21);
            this.comboBox_Turno.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Chofer(DNI)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Turno";
            // 
            // textBox_Patente
            // 
            this.textBox_Patente.Location = new System.Drawing.Point(91, 71);
            this.textBox_Patente.Name = "textBox_Patente";
            this.textBox_Patente.Size = new System.Drawing.Size(271, 20);
            this.textBox_Patente.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Patente";
            // 
            // textBox_Modelo
            // 
            this.textBox_Modelo.Location = new System.Drawing.Point(91, 45);
            this.textBox_Modelo.Name = "textBox_Modelo";
            this.textBox_Modelo.Size = new System.Drawing.Size(271, 20);
            this.textBox_Modelo.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Modelo";
            // 
            // comboBox_Marca
            // 
            this.comboBox_Marca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Marca.FormattingEnabled = true;
            this.comboBox_Marca.Location = new System.Drawing.Point(91, 16);
            this.comboBox_Marca.Name = "comboBox_Marca";
            this.comboBox_Marca.Size = new System.Drawing.Size(271, 21);
            this.comboBox_Marca.TabIndex = 14;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(37, 13);
            this.label11.TabIndex = 13;
            this.label11.Text = "Marca";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(12, 187);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(174, 13);
            this.label14.TabIndex = 16;
            this.label14.Text = "* Debe completar todos los campos";
            // 
            // button_Cancelar
            // 
            this.button_Cancelar.Location = new System.Drawing.Point(21, 242);
            this.button_Cancelar.Name = "button_Cancelar";
            this.button_Cancelar.Size = new System.Drawing.Size(100, 30);
            this.button_Cancelar.TabIndex = 17;
            this.button_Cancelar.Text = "Volver";
            this.button_Cancelar.UseVisualStyleBackColor = true;
            this.button_Cancelar.Click += new System.EventHandler(this.button_Cancelar_Click);
            // 
            // button_Limpiar
            // 
            this.button_Limpiar.Location = new System.Drawing.Point(143, 242);
            this.button_Limpiar.Name = "button_Limpiar";
            this.button_Limpiar.Size = new System.Drawing.Size(100, 30);
            this.button_Limpiar.TabIndex = 18;
            this.button_Limpiar.Text = "Limpiar";
            this.button_Limpiar.UseVisualStyleBackColor = true;
            this.button_Limpiar.Click += new System.EventHandler(this.button_Limpiar_Click);
            // 
            // button_Guardar
            // 
            this.button_Guardar.Location = new System.Drawing.Point(274, 242);
            this.button_Guardar.Name = "button_Guardar";
            this.button_Guardar.Size = new System.Drawing.Size(100, 30);
            this.button_Guardar.TabIndex = 19;
            this.button_Guardar.Text = "Guardar";
            this.button_Guardar.UseVisualStyleBackColor = true;
            this.button_Guardar.Click += new System.EventHandler(this.button_Guardar_Click);
            // 
            // combo_Chofer
            // 
            this.combo_Chofer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_Chofer.FormattingEnabled = true;
            this.combo_Chofer.Location = new System.Drawing.Point(91, 126);
            this.combo_Chofer.Name = "combo_Chofer";
            this.combo_Chofer.Size = new System.Drawing.Size(271, 21);
            this.combo_Chofer.TabIndex = 24;
            // 
            // AgregarAuto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::UberFrba.Properties.Resources.HUAYI_triaxial_space_wood_floor_photography_backdrops_font_b_pine_b_font_font_b_plank_b;
            this.ClientSize = new System.Drawing.Size(392, 308);
            this.Controls.Add(this.button_Guardar);
            this.Controls.Add(this.button_Limpiar);
            this.Controls.Add(this.button_Cancelar);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AgregarAuto";
            this.Text = "Agregar Auto";
            this.Load += new System.EventHandler(this.AgregarAuto_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox comboBox_Marca;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_Modelo;
        private System.Windows.Forms.TextBox textBox_Patente;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button button_Cancelar;
        private System.Windows.Forms.Button button_Limpiar;
        private System.Windows.Forms.Button button_Guardar;
        private System.Windows.Forms.ComboBox comboBox_Turno;
        private System.Windows.Forms.ComboBox combo_Chofer;

    }
}