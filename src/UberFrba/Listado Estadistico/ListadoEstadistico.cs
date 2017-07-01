using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using UberFrba.Exceptions;


namespace UberFrba.Listado_Estadistico
{
    public partial class ListadoEstadistico : Form
    {
        private Mapper mapper = new Mapper();
       
        public ListadoEstadistico()
        {
            InitializeComponent();
            DateTime FECHA_ACTUAL = DateTime.Today;
            seleccionAño.MaxDate = FECHA_ACTUAL;// para que no se puedan hacer rendiciones mas alla del dia de hoy
            seleccionAño.Value = FECHA_ACTUAL;
            seleccionTrimestre.Text = "";
            SeleccionEstadistica.Text = "";

        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

            if (SeleccionEstadistica.Text == "") 
            {
                throw new CampoVacioException("Estadistica");
            
            }
            if (seleccionTrimestre.Text == "") 
            {
                throw new CampoVacioException("Trimestre");
            
            }


            String funcion = this.getTipoEstadistica();
            int trimestre = this.getTrimestre();

            listado.DataSource = mapper.AplicarEstadistica(seleccionAño.Value.Year, trimestre, funcion);
            }
            catch (CampoVacioException exception)
            {
                MessageBox.Show("Falta completar campo: " + exception.Message);
                return;
            }
        }

        private int getTrimestre()
        {
            switch (seleccionTrimestre.SelectedIndex)
            {
                case 0: return 1;
                case 1: return 2;
                case 2: return 3;
                case 3: return 4;
            }
            
            return -1;
        }
    
        private string getTipoEstadistica()
        {         
            switch (SeleccionEstadistica.SelectedIndex)
            {
                case 0: return "fx_Top5DechoferesMayorRecaudacionEnUnTrimeste";
                case 1: return "fx_Top5choferesViajesMasLargosEnUnTrimestre";
                case 2: return "fx_Top5clientesMayorConsumoEnUnTrimestre";
                case 3: return "fx_Top5clientesQueviajaronEnUnMismoAutoEnUnTrimestre";
            }
            
            return null;
        }
      
        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MenuPrincipal().ShowDialog();
            this.Close();
        }

        private void button_Limpiar_Click(object sender, EventArgs e)
        {
            SeleccionEstadistica.Items.Clear();
            CargarSeleccionEstadistica();
            seleccionTrimestre.Items.Clear();
            CargarSeleccionTrimestre();
            listado.DataSource = null;
            DateTime FECHA_ACTUAL = DateTime.Today;
            seleccionAño.MaxDate = FECHA_ACTUAL;// para que no se puedan hacer rendiciones mas alla del dia de hoy
            seleccionAño.Value = FECHA_ACTUAL;
           
            
        }

        public void CargarSeleccionEstadistica() { 

           SeleccionEstadistica.Items.Add("Choferes con mayor recaudación");
           SeleccionEstadistica.Items.Add("Choferes que realizaron viajes más largos");
           SeleccionEstadistica.Items.Add("Clientes de mayor consumo");
           SeleccionEstadistica.Items.Add("Clientes que viajaron mayor cantidad de veces en un mismo auto");     
        }

        public void CargarSeleccionTrimestre()
        {
            seleccionTrimestre.Items.Add("Primer trimestre");
            seleccionTrimestre.Items.Add("Segundo trimestre");
            seleccionTrimestre.Items.Add("Tercer trimestre");
            seleccionTrimestre.Items.Add("Cuarto trimestre");
        }

    }
}
