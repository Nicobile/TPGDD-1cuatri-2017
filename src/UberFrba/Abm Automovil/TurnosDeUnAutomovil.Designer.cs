namespace UberFrba.Abm_Automovil
{
    partial class TurnosDeUnAutomovil
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
            this.dataGridView_Automovil = new System.Windows.Forms.DataGridView();
            this.button_Cancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Automovil)).BeginInit();
            this.SuspendLayout();
            // 
            // labelRoles
            // 
            this.labelRoles.AutoSize = true;
            this.labelRoles.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRoles.Location = new System.Drawing.Point(22, 18);
            this.labelRoles.Name = "labelRoles";
            this.labelRoles.Size = new System.Drawing.Size(162, 25);
            this.labelRoles.TabIndex = 10;
            this.labelRoles.Text = "Sus Turnos son :";
            // 
            // dataGridView_Automovil
            // 
            this.dataGridView_Automovil.AllowUserToAddRows = false;
            this.dataGridView_Automovil.AllowUserToDeleteRows = false;
            this.dataGridView_Automovil.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_Automovil.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Automovil.Location = new System.Drawing.Point(15, 73);
            this.dataGridView_Automovil.Name = "dataGridView_Automovil";
            this.dataGridView_Automovil.ReadOnly = true;
            this.dataGridView_Automovil.Size = new System.Drawing.Size(742, 123);
            this.dataGridView_Automovil.TabIndex = 11;
            // 
            // button_Cancelar
            // 
            this.button_Cancelar.Location = new System.Drawing.Point(657, 214);
            this.button_Cancelar.Name = "button_Cancelar";
            this.button_Cancelar.Size = new System.Drawing.Size(100, 30);
            this.button_Cancelar.TabIndex = 18;
            this.button_Cancelar.Text = "Volver";
            this.button_Cancelar.UseVisualStyleBackColor = true;
            this.button_Cancelar.Click += new System.EventHandler(this.button_Cancelar_Click);
            // 
            // TurnosDeUnAutomovil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 256);
            this.Controls.Add(this.button_Cancelar);
            this.Controls.Add(this.dataGridView_Automovil);
            this.Controls.Add(this.labelRoles);
            this.Name = "TurnosDeUnAutomovil";
            this.Text = "TurnosDeUnAutomovil";
            this.Load += new System.EventHandler(this.TurnosDeUnAutomovil_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Automovil)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelRoles;
        private System.Windows.Forms.DataGridView dataGridView_Automovil;
        private System.Windows.Forms.Button button_Cancelar;
    }
}