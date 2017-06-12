using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UberFrba.ABM_Turno
{
    public partial class MenuTurno : Form
    {
        public MenuTurno()
        {
            InitializeComponent();
        }

        private void MenuTurno_Load(object sender, EventArgs e)
        {

        }

        private void botonAgregarTurno_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AgregarTurno().ShowDialog();
            this.Close();
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MenuPrincipal().ShowDialog();
            this.Close();
        }

        private void botonEditarTurno_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FiltroTurno().ShowDialog();
            this.Close();
        }
    }
}
