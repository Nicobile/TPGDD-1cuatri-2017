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
        public CrearFacturaCliente()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void button_FechaDeInicioFactura_Click(object sender, EventArgs e)
        {
    
        }

        //private void monthCalendar_FechaDeFacturaInicio_DateSelected(object sender, System.Windows.Forms.DateRangeEventArgs e)
        //{
        //    textBox_FechaInicio.Text = e.Start.ToShortDateString();
        //    monthCalendar_FechaDeFacturaInicio.Visible = false;
        //}


        private void button_FechaDeFinFactura_Click(object sender, EventArgs e)
        {
            
        }

        //private void monthCalendar_FechaDeFacturaFin_DateSelected(object sender, System.Windows.Forms.DateRangeEventArgs e)
        //{
        //    textBox_FechaFin.Text = e.Start.ToShortDateString();
        //    monthCalendar_FechaDeFacturaFin.Visible = false;
        //}

        private void button_FechaDeInicioFactura_Click_1(object sender, EventArgs e)
        {
            monthCalendar_FechaDeFacturaInicio.Visible = true;
        }

        private void button_FechaDeFinFactura_Click_1(object sender, EventArgs e)
        {
            monthCalendar_FechaDeFacturaFin.Visible = true;
        }

        private void monthCalendar_FechaDeFacturaInicio_DateSelected(object sender, DateRangeEventArgs e)
        {

            textBox_FechaInicio.Text = e.Start.ToShortDateString();
            monthCalendar_FechaDeFacturaInicio.Visible = false;

        }

        private void monthCalendar_FechaDeFacturaFin_DateSelected(object sender, DateRangeEventArgs e)
        {
            textBox_FechaFin.Text = e.Start.ToShortDateString();
            monthCalendar_FechaDeFacturaFin.Visible = false;
        }
    
    
    
    
    
    }

    
}
