using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using UberFrba.Exceptions;
using UberFrba.DataProvider;
using UberFrba.Modelo;


namespace UberFrba.Rendicion_Viajes
{
    public partial class RendicionViaje : Form
    {
        private DBMapper mapper = new DBMapper();
        int ideTurno = 0;

        public RendicionViaje()
        {
            InitializeComponent();
        }

        public void RendicionViaje_Load(object sender, EventArgs e)
        {
            CargarComboBoxChoferes();
            CargarComboBoxTurnos();
        }


        private void CargarComboBoxChoferes()
        {
            DataTable choferesHabilitados = mapper.SelectDataTable(" chofer_dni,chofer_nombre,chofer_apellido ", " PUSH_IT_TO_THE_LIMIT.Chofer ", "chofer_estado=1");

            foreach (DataRow fila in choferesHabilitados.Rows)
            {
                string chofer_dni = fila["chofer_dni"].ToString();
                string chofer_nombre = fila["chofer_nombre"].ToString();
                string chofer_apellido = fila["chofer_apellido"].ToString();
                comboBox_chofer.Items.Add(chofer_nombre + "," + chofer_apellido + " DNI :" + chofer_dni);

            }

        }

        private void CargarComboBoxTurnos()
        {

            DataTable turnosAutomovil = mapper.SelectDataTable(" turno_id 'Turno Nº',turno_hora_inicio 'Hora Inicio',turno_hora_fin 'Hora Fin' ", " PUSH_IT_TO_THE_LIMIT.Turno ");


            foreach (DataRow fila in turnosAutomovil.Rows)
            {
                string horaInicio = fila["Hora Inicio"].ToString();
                string horaFin = fila["Hora Fin"].ToString();
                string idTurnoCombo = fila["Turno Nº"].ToString();
                comboBox_Turnos.Items.Add("El turno N° " + idTurnoCombo + " comienza a las " + horaInicio + " y finaliza a las " + horaFin);

            }

        }

        private void button_Limpiar_Click(object sender, EventArgs e)
        {
            textBox_Fecha.Text = "";
            comboBox_Turnos.Text = "";
            comboBox_chofer.Text = "";
            textBox_importe.Text = "";
        }

        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MenuPrincipal().ShowDialog();
            this.Close();

        }

        private void monthCalendar_FechaDeRendicion_DateSelected(object sender, System.Windows.Forms.DateRangeEventArgs e)
        {
            textBox_Fecha.Text = e.Start.ToShortDateString();
            monthCalendar_Fecha.Visible = false;
        }

        private void button_FechaDeRendicion_Click(object sender, EventArgs e)
        {
            monthCalendar_Fecha.Visible = true;
        }

        public String obtenerDNIaPartirDetextBox(String cliente)
        {
            string[] separadas;
            separadas = comboBox_chofer.Text.Split(':');
            String DniCliente = separadas[1];
            return DniCliente;
        }



        private void btnFacturar_Click(object sender, EventArgs e)
        {
            String ChoferDNI = this.obtenerDNIaPartirDetextBox(comboBox_chofer.Text);
            String Turno = comboBox_Turnos.Text;
            String Fecha = textBox_Fecha.Text;
            String Total = textBox_importe.Text;


            try
            {

                Rendicion rendicion = new Rendicion();
                rendicion.SetIdChofer(ChoferDNI);
                rendicion.SetFechaRendicion(Fecha);
                rendicion.SetImporteTotalRendicion(Total);
                rendicion.SetIdTurno(Convert.ToString(ideTurno));

                int idRendicion = mapper.Crear(rendicion);



                if (idRendicion > 0)
                {
                    MessageBox.Show("Se creo correctamente la Rendición");

                    mapper.ActualizarRendicionIdenRegistrViaje(idRendicion, rendicion.GetFechaRendicion(), rendicion.GetIdChofer(),ideTurno);
                }

            }
            catch (CampoVacioException exception)
            {
                MessageBox.Show("Falta completar campo: " + exception.Message);
                return;
            }

        }

        private void OcultarColumnasQueNoDebenVerse()
        {
            dataGridView_Viajes_Rendidos.Columns["auto_id"].Visible = false;
            dataGridView_Viajes_Rendidos.Columns["chofer_id"].Visible = false;
            dataGridView_Viajes_Rendidos.Columns["cliente_id"].Visible = false;
            dataGridView_Viajes_Rendidos.Columns["turno_id"].Visible = false;
            dataGridView_Viajes_Rendidos.Columns["factura_id"].Visible = false;
            dataGridView_Viajes_Rendidos.Columns["rendicion_id"].Visible = false;
        }

        private void cargar()
        {
            if (comboBox_chofer.Text == "")
            {
                throw new CampoVacioException("Chofer");
            }
            if (textBox_Fecha.Text == "")
            {
                throw new CampoVacioException("Fecha");
            }
            String DNIChofer = this.obtenerDNIaPartirDetextBox(comboBox_chofer.Text);
            int idChofer = mapper.obtenerIdChoferApartirDelDNI(DNIChofer);

            switch (comboBox_Turnos.SelectedIndex)
            {
                case 0: ideTurno = 1; break;
                case 1: ideTurno = 2; break;
                case 2: ideTurno = 3; break;
            }

            //ACA LA FUNCION SELECTDATA.... ES LA QUE TRAE LA GRILLA CON LOS VIAJES QUE NO ESTOY PUDIENDO HACER QUE DEPENDA DE TURNO
            dataGridView_Viajes_Rendidos.DataSource = mapper.SelectDataTableRegistroViajeparaRendi(textBox_Fecha.Text, idChofer, ideTurno);
            OcultarColumnasQueNoDebenVerse();
            //ACA SE LLENA EL CAMPO DEL IMPORTE DE LA RENDICION CON LA MISMA QUERI PERO CON UN SUM, SI MODIFICAS LA DE ARRIBA, TENES QUE MODIFICAR ESTA
            textBox_importe.Text = mapper.TotalRendicion(textBox_Fecha.Text, idChofer, ideTurno);


        }

        private void comboBox_Turnos_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargar();
        }
    }
}
