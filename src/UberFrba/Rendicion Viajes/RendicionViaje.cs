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
using System.Configuration;

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
            if (comboBox_chofer.Text == "") { return comboBox_chofer.Text; }
            else
            {
                string[] separadas;
                separadas = comboBox_chofer.Text.Split(':');
                String DniCliente = separadas[1];
                return DniCliente;
            }
        }

        private String errorEnCampos( String fecha, String turno) {
            String error="";
           
            if (fecha == "")
            {
                error += "- Debe seleccionar una fecha\n";
               
            }

            if (turno == "")
            {
                error += "- Debe seleccionar una turno\n";
               
            }
            return error;
        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {
            if (this.obtenerDNIaPartirDetextBox(comboBox_chofer.Text) == "")
            {
                MessageBox.Show("Debe ingresar un chofer", "Faltan completar campos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            String ChoferDNI = this.obtenerDNIaPartirDetextBox(comboBox_chofer.Text);
                String Turno = comboBox_Turnos.Text;
                String Fecha = textBox_Fecha.Text;
                String Total = textBox_importe.Text;
                String error = errorEnCampos( textBox_Fecha.Text, comboBox_Turnos.Text);
          

            if (error == "")
            {
                Rendicion rendicion = new Rendicion();
                rendicion.SetIdChofer(ChoferDNI);
                rendicion.SetFechaRendicion(Fecha);
                rendicion.SetImporteTotalRendicion(Total);
                rendicion.SetIdTurno(Convert.ToString(ideTurno));
                if (!ExisteRendicion(rendicion.GetIdChofer(), Fecha))
                {
                    int idRendicion = mapper.Crear(rendicion);
                    if (idRendicion > 0)
                    {
                        MessageBox.Show("Se creo correctamente la Rendición");

                        mapper.ActualizarRendicionIdenRegistrViaje(idRendicion, rendicion.GetFechaRendicion(), rendicion.GetIdChofer(), ideTurno);
                    }
                     }
                    else { MessageBox.Show("Ya se ralizo la rendicion diaria para ese chofer", "Rendicion existente", MessageBoxButtons.OK, MessageBoxIcon.Error); }


               
            }
            else { MessageBox.Show(error, "Faltan completar campos", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            
           
        

        }
        private bool ExisteRendicion(int idchofer, String fecha)
        {
            String config = ConfigurationManager.AppSettings["archConexionConSQL"];
            SqlConnection conexion = new SqlConnection(config);
            try
            {
                conexion.Open();
            }
            catch (Exception) { MessageBox.Show("Error en conexion"); }
            string query = "SELECT * From [PUSH_IT_TO_THE_LIMIT].fx_verificarRendicion(@fecha,@idchofer)";
            SqlCommand cmd = new SqlCommand(query, conexion);
            cmd.Parameters.AddWithValue("@fecha", fecha);
            cmd.Parameters.AddWithValue("@idchofer", idchofer);
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count == 0)
                return false;
            else
               
                return true;
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
