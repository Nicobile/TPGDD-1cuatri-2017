﻿namespace UberFrba
{
    partial class MenuPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuPrincipal));
            this.labelTitulo = new System.Windows.Forms.Label();
            this.comboBoxAccion = new System.Windows.Forms.ComboBox();
            this.botonAceptar = new System.Windows.Forms.Button();
            this.botonCerrarSesion = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitulo.Location = new System.Drawing.Point(95, 82);
            this.labelTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(246, 24);
            this.labelTitulo.TabIndex = 0;
            this.labelTitulo.Text = "Seleccione accion a realizar";
            // 
            // comboBoxAccion
            // 
            this.comboBoxAccion.BackColor = System.Drawing.Color.Tan;
            this.comboBoxAccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxAccion.FormattingEnabled = true;
            this.comboBoxAccion.Location = new System.Drawing.Point(63, 121);
            this.comboBoxAccion.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxAccion.Name = "comboBoxAccion";
            this.comboBoxAccion.Size = new System.Drawing.Size(319, 28);
            this.comboBoxAccion.TabIndex = 1;
//            this.comboBoxAccion.SelectedIndexChanged += new System.EventHandler(this.comboBoxAccion_SelectedIndexChanged);
            // 
            // botonAceptar
            // 
            this.botonAceptar.Location = new System.Drawing.Point(179, 173);
            this.botonAceptar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.botonAceptar.Name = "botonAceptar";
            this.botonAceptar.Size = new System.Drawing.Size(99, 37);
            this.botonAceptar.TabIndex = 2;
            this.botonAceptar.Text = "Aceptar";
            this.botonAceptar.UseVisualStyleBackColor = true;
            this.botonAceptar.Click += new System.EventHandler(this.botonAceptar_Click);
            // 
            // botonCerrarSesion
            // 
            this.botonCerrarSesion.ForeColor = System.Drawing.Color.Red;
            this.botonCerrarSesion.Location = new System.Drawing.Point(312, 14);
            this.botonCerrarSesion.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.botonCerrarSesion.Name = "botonCerrarSesion";
            this.botonCerrarSesion.Size = new System.Drawing.Size(118, 35);
            this.botonCerrarSesion.TabIndex = 3;
            this.botonCerrarSesion.Text = "Cerrar Sesion";
            this.botonCerrarSesion.UseVisualStyleBackColor = true;
            this.botonCerrarSesion.Click += new System.EventHandler(this.botonCerrarSesion_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::UberFrba.Properties.Resources.logouber6;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(54, 53);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // MenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::UberFrba.Properties.Resources.HUAYI_triaxial_space_wood_floor_photography_backdrops_font_b_pine_b_font_font_b_plank_b;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(443, 255);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.botonCerrarSesion);
            this.Controls.Add(this.botonAceptar);
            this.Controls.Add(this.comboBoxAccion);
            this.Controls.Add(this.labelTitulo);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MenuPrincipal";
            this.Text = "MenuPrincipal";
            this.Load += new System.EventHandler(this.MenuPrincipal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.ComboBox comboBoxAccion;
        private System.Windows.Forms.Button botonAceptar;
        private System.Windows.Forms.Button botonCerrarSesion;
        private System.Windows.Forms.PictureBox pictureBox1;




    }
}
