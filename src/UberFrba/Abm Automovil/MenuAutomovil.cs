using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UberFrba.Abm_Automovil
{
    public partial class MenuAutomovil : Form
    {
        public MenuAutomovil()
        {
            InitializeComponent();
        }

        private void MenuAutomovil_Load(object sender, EventArgs e)
        {

        }

        private void botonAgregarAutomovil_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AgregarAuto().ShowDialog();
            this.Close();
        }

        private void botonEditarAutomovil_Click(object sender, EventArgs e)
        {

            this.Hide();
            new FiltroAutomovil().ShowDialog();
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
