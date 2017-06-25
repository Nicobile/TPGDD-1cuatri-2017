using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UberFrba.Facturacion
{
    public partial class CrearFacturaCliente : Form
    {

        private DBMapper mapper = new DBMapper();
        public CrearFacturaCliente()
        {
            InitializeComponent();
        }


        private void CrearFacturaCliente_Load(object sender, EventArgs e)
        {
            CargarComboBoxClientes();
        }


        public void CargarViajesFacturados()
        {



            //dataGridView_Viajes_Facturados.DataSource = ; Aca hay que cargar  los viajes que vamos a facturar , hay que hacerlo cuando se carguen los otros campos


        }

        private void CargarComboBoxClientes()
        {
            DataTable clientesHabilitados = mapper.SelectDataTable(" cliente_dni,cliente_nombre,cliente_apellido ", " PUSH_IT_TO_THE_LIMIT.Cliente ","cliente_estado=1");

            foreach (DataRow fila in clientesHabilitados.Rows)
            {
                string cliente_dni = fila["cliente_dni"].ToString();
                string cliente_nombre = fila["cliente_nombre"].ToString();
                string cliente_apellido = fila["cliente_apellido"].ToString();
                comboBox_Cliente.Items.Add(cliente_nombre+","+cliente_apellido+" DNI :"+cliente_dni);

            }

        }

        private void button_CrearFactura_Click_1(object sender, EventArgs e)
        {

            string[] separadas;
            separadas = comboBox_Cliente.Text.Split(':');
            String DniCliente = separadas[1];//En la posicion 1 del vector separadas esta en dni del cliente asi es la forma de obtenerlo
            MessageBox.Show(DniCliente);
        }




        private void button_volver_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            new MenuPrincipal().ShowDialog();
            this.Close();
            
        }
        
        private void button_limpiar_Click(object sender, EventArgs e)
        {
            comboBox_Cliente.Items.Clear();
            CargarComboBoxClientes();
            textBox_FechaFin.Text = "";
            textBox_FechaInicio.Text = "";
        }






















        #region Month Calendar para las Fecha inicio y fin


        private void button_FechaDeInicioFactura_Click(object sender, EventArgs e)
        {
            monthCalendar_FechaDeFacturaInicio.Visible = true;
        }

        private void monthCalendar_FechaDeFacturaInicio_DateSelected(object sender, System.Windows.Forms.DateRangeEventArgs e)
        {
            textBox_FechaInicio.Text = e.Start.ToShortDateString();
            monthCalendar_FechaDeFacturaInicio.Visible = false;
        }

        private void button_FechaDeFinFactura_Click(object sender, EventArgs e)
        {
            monthCalendar_FechaDeFacturaFin.Visible = true;
        }

        private void monthCalendar_FechaDeFacturaFin_DateSelected(object sender, System.Windows.Forms.DateRangeEventArgs e)
        {
            textBox_FechaFin.Text = e.Start.ToShortDateString();
            monthCalendar_FechaDeFacturaFin.Visible = false;
        }
        #endregion

        

        

        

       

        
       

    }

    
}
