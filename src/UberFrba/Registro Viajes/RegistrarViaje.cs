using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UberFrba.Registro_Viajes
{
    public partial class RegistrarViaje : Form
    {
        public RegistrarViaje()
        {
            InitializeComponent();
        }

        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MenuPrincipal().ShowDialog();
            this.Close();
        }

        private void button_Limpiar_Click(object sender, EventArgs e)
        {
            textBox_Automovil.Text = "";
            textBox_CantidadKm.Text = "";
            //textBox_Chofer.Text = "";
            comboBox_chofer.Text = "";
            textBox_Cliente.Text = "";
            textBox_FHfin.Text = "";
            textBox_FHinicio.Text = "";
            textBox_Turno.Text = "";
        }

        private void RegistrarViaje_Load(object sender, EventArgs e)
        {
            comboBox_chofer.Items.Add("Hola");
            ///comboBox_chofer.Text = "Ingresar un Chofer";
        }

        private void comboBox_chofer_SelectionChangeCommitted(object sender, EventArgs e)
        {

            ComboBox senderComboBox = (ComboBox)sender;

            if (comboBox_chofer.Text == "Hola") {

                textBox_Automovil.Text = "Patente n°";//esto se setea al elegir la opcion del combobox
            
            }

         }
            
       }
}
