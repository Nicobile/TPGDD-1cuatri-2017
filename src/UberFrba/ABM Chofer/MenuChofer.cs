using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UberFrba.ABM_Chofer
{
    public partial class MenuChofer : Form
    {
        public MenuChofer()
        {
            InitializeComponent();
        }

        private void MenuChofer_Load(object sender, EventArgs e)
        {


        }

        private void botonAgregarChofer_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AgregarChofer("chofer","ok").ShowDialog();
            this.Close();
        }

        private void botonEditarChofer_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FiltroChofer().ShowDialog();
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
