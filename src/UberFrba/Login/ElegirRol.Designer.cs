namespace UberFrba.Login
{
    partial class ElegirRol
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ElegirRol));
            this.comboBoxRol = new System.Windows.Forms.ComboBox();
            this.botonAceptar = new System.Windows.Forms.Button();
            this.labelEnunciado = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxRol
            // 
            this.comboBoxRol.BackColor = System.Drawing.Color.Tan;
            this.comboBoxRol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRol.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxRol.FormattingEnabled = true;
            this.comboBoxRol.Location = new System.Drawing.Point(129, 68);
            this.comboBoxRol.Name = "comboBoxRol";
            this.comboBoxRol.Size = new System.Drawing.Size(240, 32);
            this.comboBoxRol.TabIndex = 0;
            // 
            // botonAceptar
            // 
            this.botonAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonAceptar.Location = new System.Drawing.Point(171, 134);
            this.botonAceptar.Name = "botonAceptar";
            this.botonAceptar.Size = new System.Drawing.Size(145, 40);
            this.botonAceptar.TabIndex = 1;
            this.botonAceptar.Text = "Aceptar";
            this.botonAceptar.UseVisualStyleBackColor = true;
            this.botonAceptar.Click += new System.EventHandler(this.botonAceptar_Click);
            // 
            // labelEnunciado
            // 
            this.labelEnunciado.AutoSize = true;
            this.labelEnunciado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEnunciado.Location = new System.Drawing.Point(76, 27);
            this.labelEnunciado.Name = "labelEnunciado";
            this.labelEnunciado.Size = new System.Drawing.Size(345, 20);
            this.labelEnunciado.TabIndex = 2;
            this.labelEnunciado.Text = "Seleccione el rol con el cual quiere iniciar sesion";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::UberFrba.Properties.Resources.logouber6;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(54, 53);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // ElegirRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::UberFrba.Properties.Resources.HUAYI_triaxial_space_wood_floor_photography_backdrops_font_b_pine_b_font_font_b_plank_b;
            this.ClientSize = new System.Drawing.Size(462, 212);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labelEnunciado);
            this.Controls.Add(this.botonAceptar);
            this.Controls.Add(this.comboBoxRol);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ElegirRol";
            this.Text = "ElegirRol";
            this.Load += new System.EventHandler(this.ElegirRol_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxRol;
        private System.Windows.Forms.Button botonAceptar;
        private System.Windows.Forms.Label labelEnunciado;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}