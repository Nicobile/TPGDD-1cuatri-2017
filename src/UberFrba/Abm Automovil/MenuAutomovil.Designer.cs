﻿namespace UberFrba.Abm_Automovil
{
    partial class MenuAutomovil
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
            this.labelRoles = new System.Windows.Forms.Label();
            this.botonAgregarAutomovil = new System.Windows.Forms.Button();
            this.botonEditarAutomovil = new System.Windows.Forms.Button();
            this.botonVolver = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelRoles
            // 
            this.labelRoles.AutoSize = true;
            this.labelRoles.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRoles.Location = new System.Drawing.Point(97, 9);
            this.labelRoles.Name = "labelRoles";
            this.labelRoles.Size = new System.Drawing.Size(119, 25);
            this.labelRoles.TabIndex = 9;
            this.labelRoles.Text = "Automoviles";
            // 
            // botonAgregarAutomovil
            // 
            this.botonAgregarAutomovil.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonAgregarAutomovil.Location = new System.Drawing.Point(93, 84);
            this.botonAgregarAutomovil.Name = "botonAgregarAutomovil";
            this.botonAgregarAutomovil.Size = new System.Drawing.Size(135, 54);
            this.botonAgregarAutomovil.TabIndex = 10;
            this.botonAgregarAutomovil.Text = "Agregar Automovil";
            this.botonAgregarAutomovil.UseVisualStyleBackColor = true;
            this.botonAgregarAutomovil.Click += new System.EventHandler(this.botonAgregarAutomovil_Click);
            // 
            // botonEditarAutomovil
            // 
            this.botonEditarAutomovil.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonEditarAutomovil.Location = new System.Drawing.Point(93, 174);
            this.botonEditarAutomovil.Name = "botonEditarAutomovil";
            this.botonEditarAutomovil.Size = new System.Drawing.Size(135, 54);
            this.botonEditarAutomovil.TabIndex = 11;
            this.botonEditarAutomovil.Text = "Editar Automovil";
            this.botonEditarAutomovil.UseVisualStyleBackColor = true;
            this.botonEditarAutomovil.Click += new System.EventHandler(this.botonEditarAutomovil_Click);
            // 
            // botonVolver
            // 
            this.botonVolver.Location = new System.Drawing.Point(12, 294);
            this.botonVolver.Name = "botonVolver";
            this.botonVolver.Size = new System.Drawing.Size(144, 35);
            this.botonVolver.TabIndex = 12;
            this.botonVolver.Text = "< Volver al Menú Principal";
            this.botonVolver.UseVisualStyleBackColor = true;
            this.botonVolver.Click += new System.EventHandler(this.botonVolver_Click);
            // 
            // MenuAutomovil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 386);
            this.Controls.Add(this.botonVolver);
            this.Controls.Add(this.botonEditarAutomovil);
            this.Controls.Add(this.botonAgregarAutomovil);
            this.Controls.Add(this.labelRoles);
            this.Name = "MenuAutomovil";
            this.Text = "MenuAutomovil";
            this.Load += new System.EventHandler(this.MenuAutomovil_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelRoles;
        private System.Windows.Forms.Button botonAgregarAutomovil;
        private System.Windows.Forms.Button botonEditarAutomovil;
        private System.Windows.Forms.Button botonVolver;
    }
}