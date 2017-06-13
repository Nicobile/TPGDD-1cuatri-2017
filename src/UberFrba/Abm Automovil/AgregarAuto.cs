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
    public partial class AgregarAuto : Form
    {
        private DBMapper mapper = new DBMapper();
        private int idAuto;

        public AgregarAuto()
        {
            InitializeComponent();
        }

        private void button_Guardar_Click(object sender, EventArgs e)
        {
            String Marca = comboBox_Marca.SelectedValue.ToString();
            String Modelo = textBox_Modelo.Text;
            String Patente = textBox_Patente.Text;
            String Turno = textBox_Turno.Text;
            String Chofer = textBox_Chofer.Text;

        }

        private void button_Limpiar_Click(object sender, EventArgs e)
        {

            
            textBox_Modelo.Text = "";
            textBox_Patente.Text = "";
            textBox_Turno.Text = "";
            textBox_Chofer.Text = "";

        }

        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MenuPrincipal().ShowDialog();
            this.Close();
        }





    }
}
