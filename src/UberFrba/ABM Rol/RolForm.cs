using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UberFrba.Abm_Rol;

namespace UberFrba.ABM_Rol
{
    public partial class RolForm : Form
    {
        public RolForm()
        {
            InitializeComponent();
        }

        private void botonAgregarRol_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AgregarRol().ShowDialog();
            this.Close();
        }

        private void botonEditarRol_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ListadoEditarRol().ShowDialog();
            this.Close();
        }

        private void botonBajaRol_Click(object sender, EventArgs e)
        {
            this.Hide();
            new BajaRol().ShowDialog();
            this.Close();
        }

        private void RolForm_Load(object sender, EventArgs e)
        {
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MenuPrincipal().ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AsignarRolesUsuario().ShowDialog();
            this.Close();

        }
    }
}