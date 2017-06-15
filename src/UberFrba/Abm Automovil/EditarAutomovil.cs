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
    public partial class EditarAutomovil : Form
    {
        private int idAutomovil;

        public EditarAutomovil(String idAutomovil)
        {
            InitializeComponent();
            this.idAutomovil = Convert.ToInt32(idAutomovil);
            
        }

        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
    }
}
