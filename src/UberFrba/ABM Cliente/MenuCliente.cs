using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UberFrba.ABM_Cliente;

namespace UberFrba.Abm_Cliente
{
    public partial class MenuCliente : Form
    {
        public MenuCliente()
        {
            InitializeComponent();
        }

        private void labelRoles_Click(object sender, EventArgs e)
        {

        }

        private void botonAgregarCliente_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AgregarCliente("", "").ShowDialog();
            this.Close();
        }

        private void botonEditarCliente_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FiltroCliente().ShowDialog();
            this.Close();
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MenuPrincipal().ShowDialog();
            this.Close();
        }
    }
}
