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

namespace UberFrba.Registro_Viajes
{
    public partial class RegistrarViaje : Form
    {

        private DBMapper mapper = new DBMapper();
      


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

            int cantKm;
            DateTime fecha = Convert.ToDateTime(textBox_Fecha.Text);
            DateTime horarioIni = horaInicio.Value;
            DateTime horarioFin = horaFin.Value;
            int idChofer = mapper.obtenerIdChoferApartirDelDNI(comboBox_chofer.Text);
            int idAuto = mapper.obtenerIdAutomovilApartirDeLaPatente(textBox_Automovil.Text);
           
            int idTurno = Convert.ToInt32(comboBox_TurnosAutmovilSeleccionado.Text.Substring(12, 1));


            //Crear RegistroViaje
            try
            {
                int idCliente = mapper.obtenerIdClienteApartirDelDNI(textBox_Cliente.Text);//lo hago aca para poder capturar la excepcion sin el dni del cliente no existe

                if (textBox_CantidadKm.Text == "")
                {
                    throw new CampoVacioException("CantidadKm");
                }
                else {

                     cantKm = Convert.ToInt32(textBox_CantidadKm.Text);    
                
                } 

                         

                RegistroViaje registroViaje = new RegistroViaje();
                registroViaje.SetCantidadKm(cantKm);
                registroViaje.SetFechaViaje(fecha);
                registroViaje.SetHoraInicio(horarioIni);
                registroViaje.SetHoraFin(horarioFin);
                registroViaje.SetIdChofer(idChofer);
                registroViaje.SetIdAuto(idAuto);
                registroViaje.SetIdCliente(idCliente);
                registroViaje.SetIdTurno(idTurno);

                int idRegistroViaje = mapper.Crear(registroViaje);



                if (idRegistroViaje > 0)
                {
                    MessageBox.Show("Registro de viaje agregado correctamente");
                    this.Close();
                }


            }
            catch (NullReferenceException) { }
            
           catch (ClienteInexistenteException error) {

                MessageBox.Show(error.Message , "Cliente inexistente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (CampoVacioException exception)
            {
                MessageBox.Show("Falta completar campo: " + exception.Message);
                return;
            }
            catch (SqlException error)
            {
                if (error.Number == 51001)
                {
                    MessageBox.Show(error.Message, "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
                       
        }
                            
       }
}
