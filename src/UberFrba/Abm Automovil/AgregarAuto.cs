using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UberFrba.Exceptions;
using UberFrba.Modelo;

namespace UberFrba.Abm_Automovil
{
    public partial class AgregarAuto : Form
    {
        private DBMapper mapper = new DBMapper();
        private int idAuto;
        private int idTurno;
        private int idChofer;

        public AgregarAuto()
        {
            InitializeComponent();
        }

        private void AgregarAuto_Load(object sender, EventArgs e)
        {
            comboBox_Marca.Items.Add("Porsche");
            comboBox_Marca.Items.Add("Chevrolet");
            comboBox_Marca.Items.Add("Renault");
            comboBox_Marca.Items.Add("Peugeot");
            comboBox_Marca.Items.Add("Ford");
            comboBox_Marca.Items.Add("Fiat");
            comboBox_Marca.Items.Add("Volkswagen");
            comboBox_Marca.Items.Add("Toyota");
            comboBox_Marca.Items.Add("Citroën");
        }

        private void button_Guardar_Click(object sender, EventArgs e)
        {
            String Marca =comboBox_Marca.Text;
            String Modelo = textBox_Modelo.Text;
            String Patente = textBox_Patente.Text;
            String Turno = textBox_Turno.Text;
            String Chofer = textBox_Chofer.Text;
            String IDTurno = textBox_Turno.Text;
            String DniChofer = textBox_Chofer.Text;
            try {

                Automoviles auto = new Automoviles();

                auto.SetMarca(Marca);
                auto.SetModelo(Modelo);
                auto.SetPatente(Patente);
                auto.SetActivo(true);
                this.SetIdTurno(IDTurno);
                this.SetIdChofer(DniChofer);
                MessageBox.Show(Convert.ToString(idChofer));
                idAuto = mapper.CrearAutomoviles(auto);
                if (idAuto > 0) {
                    MessageBox.Show("Automovil agregado correctamente");
                    this.Close();
                }
                 
            }
            catch (CampoVacioException exceptionCampoVacio)
            {
                MessageBox.Show("Falta completar campo: " + exceptionCampoVacio.Message);
                return;
            }
            catch (FormatoInvalidoException exceptionFormato)
            {
                MessageBox.Show("Los datos fueron mal ingresados en: " + exceptionFormato.Message);
                return;
            }
            catch (ChoferInexistenteException exceptionChofer)
            {
                MessageBox.Show( exceptionChofer.Message + DniChofer);
                return;
            }








           
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        public void SetIdTurno(String idTurno)
        {
            if (idTurno == "") throw new CampoVacioException("Turno");
            this.idTurno = Convert.ToInt32(idTurno);
        }

        public void SetIdChofer(String dniChofer)
        {
            if (dniChofer == "") throw new CampoVacioException("DNI Chofer");
            int idChoferObtenidoApartirDelDNI=Convert.ToInt32(mapper.SelectFromWhere("chofer_id","Chofer","chofer_dni",Convert.ToInt32(dniChofer)));
            if(idChoferObtenidoApartirDelDNI==0) throw new ChoferInexistenteException("No existe un chofer con DNI igual a :");
            this.idChofer = idChoferObtenidoApartirDelDNI;
        }





    }
}
