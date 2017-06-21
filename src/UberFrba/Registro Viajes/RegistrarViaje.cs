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

namespace UberFrba.Registro_Viajes
{
    public partial class RegistrarViaje : Form
    {

        private DBMapper mapper = new DBMapper();
        private String idTurno;


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
            comboBox_chofer.Text = "";
            textBox_Cliente.Text = "";
            textBox_Fecha.Text = "";
            comboBox_TurnosAutmovilSeleccionado.Text = "";
            horaInicio.Text = "00:00";
            horaFin.Text = "00:00";
        }

        private void RegistrarViaje_Load(object sender, EventArgs e)
        {
            this.CargarComboBoxChoferes();

        }

        private void comboBox_chofer_SelectionChangeCommitted(object sender, EventArgs e)
        {

                
           int idChofer  = this.mapper.obtenerIdChoferApartirDelDNI(comboBox_chofer.Text);

           textBox_Automovil.Text = mapper.ObtenerPatenteAutomovil(idChofer);

           int idAutomovilSeleccionado = mapper.obtenerIdAutomovilApartirDeLaPatente(textBox_Automovil.Text);

           this.CargarComboBoxTurnosDeAutomovil(idAutomovilSeleccionado);




         }


        
        private void CargarComboBoxChoferes()
        {
            
            DataTable dniChoferes = mapper.SelectDataTable("chofer_dni", "PUSH_IT_TO_THE_LIMIT.Chofer", " chofer_id IN (SELECT chofer_id FROM PUSH_IT_TO_THE_LIMIT.ChoferporAuto WHERE auto_chofer_estado=1)");


            foreach (DataRow fila in dniChoferes.Rows)
            {
                string chofer_dni = fila["chofer_dni"].ToString();
                comboBox_chofer.Items.Add(chofer_dni);

            }
            
          }

        private void CargarComboBoxTurnosDeAutomovil(int idAutomovilSeleccionado)
        {
            comboBox_TurnosAutmovilSeleccionado.Items.Clear(); 
            DataTable turnosAutomovil = mapper.ObtenerTurnosHabilitadosAutmovil(idAutomovilSeleccionado);


            foreach (DataRow fila in turnosAutomovil.Rows)
            {
                string horaInicio = fila["Hora Inicio"].ToString();
                string horaFin = fila["Hora Fin"].ToString();
                string idTurnoCombo = fila["Turno N°"].ToString();
                idTurno = idTurnoCombo;
                comboBox_TurnosAutmovilSeleccionado.Items.Add("El turno N° " + idTurnoCombo + " comienza a las " + horaInicio + " y finaliza a las " + horaFin);

            }

        }

        private void button_FechaDeNacimiento_Click(object sender, EventArgs e)
        {
            monthCalendar_FechaDeViaje.Visible = true;
        }

        private void monthCalendar_FechaDeViaje_DateSelected(object sender, System.Windows.Forms.DateRangeEventArgs e)
        {
            textBox_Fecha.Text = e.Start.ToShortDateString();
            monthCalendar_FechaDeViaje.Visible = false;
        }

        private void button_Guardar_Click(object sender, EventArgs e)
        {
            int cantKm = Convert.ToInt32(textBox_CantidadKm.Text);
            DateTime fecha = Convert.ToDateTime(textBox_Fecha.Text);
            DateTime horarioIni = horaInicio.Value;
            DateTime horarioFin = horaFin.Value;
            int idChofer = mapper.obtenerIdChoferApartirDelDNI(comboBox_chofer.Text);
            int idAuto = mapper.obtenerIdAutomovilApartirDeLaPatente(textBox_Automovil.Text);
            int idCliente = mapper.obtenerIdClienteApartirDelDNI(textBox_Cliente.Text);

            String query = "[PUSH_IT_TO_THE_LIMIT].pr_agregar_registro";
            IList<SqlParameter> parametros = new List<SqlParameter>();
            SqlParameter parametroOutput;
            SqlCommand command;


            parametros.Add(new SqlParameter("@Cantidad_km", cantKm));
            parametros.Add(new SqlParameter("@Fecha", fecha));
            parametros.Add(new SqlParameter("@HoraInicio", horarioIni));
            parametros.Add(new SqlParameter("@HoraFin", horarioFin));
            parametros.Add(new SqlParameter("@idChofer", idChofer));
            parametros.Add(new SqlParameter("@idAuto", idAuto));
            parametros.Add(new SqlParameter("@idCliente", idCliente));
            parametros.Add(new SqlParameter("@idTurno", idTurno));


            parametroOutput = new SqlParameter("@id", SqlDbType.Int);
            parametroOutput.Direction = ParameterDirection.Output;
            parametros.Add(parametroOutput);
            command = QueryBuilder.Instance.build(query, parametros);
            command.CommandType = CommandType.StoredProcedure;
            command.ExecuteNonQuery();


            int id = (int)parametroOutput.Value;
            
            if(id > 0) {
                MessageBox.Show("Registro de viaje agregado correctamente");
            }
        }
                            
       }
}
