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
using System.Configuration;
namespace UberFrba.Facturacion
{
    public partial class CrearFacturaCliente : Form
    {

        private Mapper mapper = new Mapper();
        public CrearFacturaCliente()
        {
            InitializeComponent();
            DateTime FECHA_ACTUAL = DateTime.Parse(ConfigurationManager.AppSettings["Fecha"]);
            this.monthCalendar_FechaDeFacturaInicio.MaxDate = FECHA_ACTUAL;
            this.monthCalendar_FechaDeFacturaInicio.TodayDate = FECHA_ACTUAL;
            this.monthCalendar_FechaDeFacturaFin.MaxDate = FECHA_ACTUAL;
            this.monthCalendar_FechaDeFacturaFin.TodayDate = FECHA_ACTUAL;
        }
        
        private void CrearFacturaCliente_Load(object sender, EventArgs e)
        {
            CargarComboBoxClientes();
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
           
            String FechaInicio = textBox_FechaInicio.Text;
            String FechaFin = textBox_FechaFin.Text;
            String Total = textBox_TotalFactutado.Text;
            String CantViajes = textBox_CantidadViajes.Text;


            try {

                String ClienteDNI = this.obtenerDNIaPartirDetextBox(comboBox_Cliente.Text);//lo pongo aca para captuarar la excepcion

                Factura factura = new Factura();
                factura.SetIdCliente(ClienteDNI);
                factura.SetFechaInicioFactura(FechaInicio);
                factura.SetFechaFinFactura(FechaFin);
                factura.SetImporteTotalFactura(Total);
                factura.SetCantidadViajesFacturados(CantViajes);

                int idFactura = mapper.Crear(factura);

                if(idFactura > 0)
                {
                    MessageBox.Show("Se creo correctamente la  Factura");

                    mapper.ActualizarFacturaIdenRegistrViaje(idFactura, factura.GetFechaInicioFactura(), factura.GetFechaFinFactura(), factura.GetIdCliente());
                }
                this.Hide();
                new MenuPrincipal().ShowDialog();
                this.Close();
            
            }
            catch (CampoVacioException exception)
            {
                MessageBox.Show("Falta completar campo: " + exception.Message);
                return;
            }
            catch (NoHayViajesException exception)
            {
                MessageBox.Show(exception.Message,"Error al crear Factura",MessageBoxButtons.OK,MessageBoxIcon.Error);
                LimpiarDatosVista();
                return;
            }


        }

        private void button_volver_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            new MenuPrincipal().ShowDialog();
            this.Close();
            
        }
        
        private void button_limpiar_Click(object sender, EventArgs e)
        {
            LimpiarDatosVista();
        }

        public void LimpiarDatosVista() 
        {
            comboBox_Cliente.Items.Clear();
            CargarComboBoxClientes();
            textBox_FechaFin.Text = "";
            textBox_FechaInicio.Text = "";
            textBox_TotalFactutado.Text = "";
            textBox_CantidadViajes.Text = "";
            dataGridView_Viajes_Facturados.DataSource = null;
        }

        private void OcultarColumnasQueNoDebenVerse()
        {
            dataGridView_Viajes_Facturados.Columns["auto_id"].Visible = false;
            dataGridView_Viajes_Facturados.Columns["chofer_id"].Visible = false;
            dataGridView_Viajes_Facturados.Columns["cliente_id"].Visible = false;
            dataGridView_Viajes_Facturados.Columns["turno_id"].Visible = false;
            dataGridView_Viajes_Facturados.Columns["factura_id"].Visible = false;
            dataGridView_Viajes_Facturados.Columns["rendicion_id"].Visible = false;
        }
        public String obtenerDNIaPartirDetextBox(String cliente) {

            if (cliente == "")
            {
                throw new CampoVacioException("Cliente");
            }
            else {
                string[] separadas;
                separadas = cliente.Split(':');
                String DniCliente = separadas[1];
                return DniCliente;
            }
        }

        public void validarYCargar() {
            if (comboBox_Cliente.Text == "") {
                throw new CampoVacioException("Cliente");
            }
            if (textBox_FechaInicio.Text == "") {
                throw new CampoVacioException("Fecha Inicio");
            }

            lasFechasCorrespondenAunMes(textBox_FechaInicio.Text ,textBox_FechaFin.Text);

            String DNICliente = this.obtenerDNIaPartirDetextBox(comboBox_Cliente.Text);
            int idCliente = mapper.obtenerIdClienteApartirDelDNI(DNICliente);

            dataGridView_Viajes_Facturados.DataSource = mapper.SelectDataTableRegistroViaje(textBox_FechaInicio.Text,textBox_FechaFin.Text,idCliente);
            OcultarColumnasQueNoDebenVerse();
            textBox_CantidadViajes.Text = mapper.CantidadDeViajesFactura(textBox_FechaInicio.Text, textBox_FechaFin.Text,idCliente);
            textBox_TotalFactutado.Text = mapper.TotalFactura(textBox_FechaInicio.Text, textBox_FechaFin.Text,idCliente);
        }


        public void lasFechasCorrespondenAunMes(String fechaInicio, String fechaFin) {

            DateTime fechaIniciofac = Convert.ToDateTime(fechaInicio);
            DateTime fechaFinfac = Convert.ToDateTime(fechaFin);

            int resultado = fechaIniciofac.CompareTo(fechaFinfac);
            if (resultado >=0) {
                throw new FechaInvalidaException("La fecha inicio no puede ser mayor a la fecha fin");
            
            }
            if (fechaIniciofac.Month != fechaFinfac.Month) {

                throw new FechaInvalidaException("La fecha inicio  y la fecha fin tienen meses distintos ");
            
            }

            if (fechaIniciofac.Year != fechaFinfac.Year)
            {

                throw new FechaInvalidaException("La fecha inicio  y la fecha fin tienen Años distintos ");

            }
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
            
            try
            {
                this.validarYCargar();
            }
            catch (FechaInvalidaException error) {

                MessageBox.Show(error.Message, "Error en fecha", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LimpiarDatosVista();
                monthCalendar_FechaDeFacturaFin.Visible = false;
                return;
            
            }
            catch (CampoVacioException exception)
            {
                MessageBox.Show("Falta completar campo: " + exception.Message);
                monthCalendar_FechaDeFacturaFin.Visible = false;
                return;
            }

            monthCalendar_FechaDeFacturaFin.Visible = false;
        }
        #endregion

    }

    
}
