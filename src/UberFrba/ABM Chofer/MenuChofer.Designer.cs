﻿namespace UberFrba.ABM_Chofer
{
    partial class MenuChofer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuChofer));
            this.labelRoles = new System.Windows.Forms.Label();
            this.botonAgregarChofer = new System.Windows.Forms.Button();
            this.botonEditarChofer = new System.Windows.Forms.Button();
            this.botonVolver = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelRoles
            // 
            this.labelRoles.AutoSize = true;
            this.labelRoles.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRoles.Location = new System.Drawing.Point(95, 24);
            this.labelRoles.Name = "labelRoles";
            this.labelRoles.Size = new System.Drawing.Size(92, 25);
            this.labelRoles.TabIndex = 8;
            this.labelRoles.Text = "Choferes";
            // 
            // botonAgregarChofer
            // 
            this.botonAgregarChofer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonAgregarChofer.Location = new System.Drawing.Point(70, 79);
            this.botonAgregarChofer.Name = "botonAgregarChofer";
            this.botonAgregarChofer.Size = new System.Drawing.Size(135, 54);
            this.botonAgregarChofer.TabIndex = 9;
            this.botonAgregarChofer.Text = "Agregar Chofer";
            this.botonAgregarChofer.UseVisualStyleBackColor = true;
            this.botonAgregarChofer.Click += new System.EventHandler(this.botonAgregarChofer_Click);
            // 
            // botonEditarChofer
            // 
            this.botonEditarChofer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonEditarChofer.Location = new System.Drawing.Point(70, 169);
            this.botonEditarChofer.Name = "botonEditarChofer";
            this.botonEditarChofer.Size = new System.Drawing.Size(135, 54);
            this.botonEditarChofer.TabIndex = 10;
            this.botonEditarChofer.Text = "Editar Chofer";
            this.botonEditarChofer.UseVisualStyleBackColor = true;
            this.botonEditarChofer.Click += new System.EventHandler(this.botonEditarChofer_Click);
            // 
            // botonVolver
            // 
            this.botonVolver.Location = new System.Drawing.Point(12, 293);
            this.botonVolver.Name = "botonVolver";
            this.botonVolver.Size = new System.Drawing.Size(144, 35);
            this.botonVolver.TabIndex = 11;
            this.botonVolver.Text = "< Volver al Menú Principal";
            this.botonVolver.UseVisualStyleBackColor = true;
            this.botonVolver.Click += new System.EventHandler(this.botonVolver_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::UberFrba.Properties.Resources.logouber6;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(54, 53);
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // MenuChofer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackgroundImage = global::UberFrba.Properties.Resources.HUAYI_triaxial_space_wood_floor_photography_backdrops_font_b_pine_b_font_font_b_plank_b;
            this.ClientSize = new System.Drawing.Size(309, 386);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.botonVolver);
            this.Controls.Add(this.botonEditarChofer);
            this.Controls.Add(this.botonAgregarChofer);
            this.Controls.Add(this.labelRoles);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MenuChofer";
            this.Text = "MenuChofer";
            this.Load += new System.EventHandler(this.MenuChofer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelRoles;
        private System.Windows.Forms.Button botonAgregarChofer;
        private System.Windows.Forms.Button botonEditarChofer;
        private System.Windows.Forms.Button botonVolver;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}