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
namespace UberFrba.Registro_Viajes
{
    public partial class RegistrarViaje : Form
    {

        private Mapper mapper = new Mapper();
        int idAutomovilSeleccionado;


        public RegistrarViaje()
        {
            InitializeComponent();
            DateTime FECHA_ACTUAL = DateTime.Parse(ConfigurationManager.AppSettings["Fecha"]);
            this.monthCalendar_FechaDeViaje.TodayDate = FECHA_ACTUAL;
            this.monthCalendar_FechaDeViaje.MaxDate = FECHA_ACTUAL;
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
            comboBox_Cliente.Text = "";
            textBox_Fecha.Text = "";
            comboBox_TurnosAutmovilSeleccionado.Text = "";
            horaInicio.Text = "00:00";
            horaFin.Text = "00:00";
            comboBox_chofer.Items.Clear();
            comboBox_Cliente.Items.Clear();
            comboBox_TurnosAutmovilSeleccionado.Items.Clear();
            this.CargarComboBoxChoferes();
            this.CargarComboBoxTurnosDeAutomovil(idAutomovilSeleccionado);
            this.CargarComboBoxClientes();
        }

        private void RegistrarViaje_Load(object sender, EventArgs e)
        {
            this.CargarComboBoxChoferes();
            this.CargarComboBoxClientes();
        }
       

        private void comboBox_chofer_SelectionChangeCommitted(object sender, EventArgs e)
        {
           int idChofer  = this.mapper.obtenerIdChoferApartirDelDNI(comboBox_chofer.Text);

           textBox_Automovil.Text = mapper.ObtenerPatenteAutomovil(idChofer);

           idAutomovilSeleccionado = mapper.obtenerIdAutomovilApartirDeLaPatente(textBox_Automovil.Text);

           this.CargarComboBoxTurnosDeAutomovil(idAutomovilSeleccionado);
         }


        
        private void CargarComboBoxChoferes()
        {
            
            DataTable dniChoferes = mapper.SelectDataTable("chofer_dni", "PUSH_IT_TO_THE_LIMIT.Chofer", " chofer_id IN (SELECT chofer_id FROM PUSH_IT_TO_THE_LIMIT.ChoferporAuto WHERE auto_chofer_estado=1) AND Chofer.chofer_estado=1");


            foreach (DataRow fila in dniChoferes.Rows)
            {
                string chofer_dni = fila["chofer_dni"].ToString();
                comboBox_chofer.Items.Add(chofer_dni);

            }
            
          }
     
        private void CargarComboBoxClientes()
        {

            DataTable dniClientes = mapper.SelectDataTable("cliente_dni", "PUSH_IT_TO_THE_LIMIT.Cliente c", "  c.cliente_id IN (SELECT c.cliente_id FROM PUSH_IT_TO_THE_LIMIT.Usuario u WHERE u.usuario_habilitado=1 and c.cliente_id=u.usuario_id) AND c.cliente_estado=1");


            foreach (DataRow fila in dniClientes.Rows)
            {
                string cliente_dni = fila["cliente_dni"].ToString();
                
                comboBox_Cliente.Items.Add(cliente_dni);

            }

        }



        public String obtenerIdTurnoaPartirDeCombobox(String turno)
        {
            if (turno == "")
            {
                throw new CampoVacioException("Turno");
            }
            string[] turnoSeparado1;
            string[] turnoSeparado2;
            turnoSeparado1 = turno.Split('(');
            turnoSeparado2 = turnoSeparado1[1].Split(')');
            return turnoSeparado2[0];
        }


        private void CargarComboBoxTurnosDeAutomovil(int idAutomovilSeleccionado)
        {
            comboBox_TurnosAutmovilSeleccionado.Items.Clear();
            DataTable turnosAutomovil = mapper.ObtenerTurnosHabilitadosAutmovilParaRegistroViaje(idAutomovilSeleccionado);


            foreach (DataRow fila in turnosAutomovil.Rows)
            {
                string horaInicio = fila["Hora Inicio"].ToString();
                string horaFin = fila["Hora Fin"].ToString();
                string idTurnoCombo = fila["Turno N°"].ToString();
                comboBox_TurnosAutmovilSeleccionado.Items.Add("El turno N° " + "("+idTurnoCombo + ")"+" comienza a las " + horaInicio + " y finaliza a las " + horaFin);

            }

        }

        private void button_FechaDeRegistroViaje_Click(object sender, EventArgs e)
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
            String DNICliente = comboBox_Cliente.Text; 
            String CantKm =textBox_CantidadKm.Text;
            String fecha = textBox_Fecha.Text;
            TimeSpan horarioIni = horaInicio.Value.TimeOfDay;
            TimeSpan horarioFin = horaFin.Value.TimeOfDay;
            String DNIChofer = comboBox_chofer.Text;
            String PatenteAuto = textBox_Automovil.Text;
          

            //Crear RegistroViaje
            try
            {
                

                RegistroViaje registroViaje = new RegistroViaje();
                registroViaje.SetIdChofer(DNIChofer);
                registroViaje.SetIdAuto(PatenteAuto);
                String idTurnoSeleccionado = this.obtenerIdTurnoaPartirDeCombobox(comboBox_TurnosAutmovilSeleccionado.Text);
                registroViaje.SetIdTurno(idTurnoSeleccionado);
                registroViaje.SetCantidadKm(CantKm);
                registroViaje.SetFechaViaje(fecha);
                registroViaje.SetIdCliente(DNICliente);


                Turnos turnoSeleccionado = mapper.ObtenerTurnos(Convert.ToInt32(idTurnoSeleccionado));
                            
                if (!(horaInicio.Value.TimeOfDay.Hours >= turnoSeleccionado.GetHoraInicio() && horaFin.Value.TimeOfDay.Hours <= turnoSeleccionado.GetHoraFin()))
                    {
                        throw new HorarioNoCoincideConTurno("El horario no corresponde al turno");
                    }

                if (horarioFin <= horarioIni)
                {
                    throw new DuracionViajeInvalidaException("La HoraFin no puede ser menor o igual que la HoraInicio");
                }
                else {
                    registroViaje.SetHoraInicio(horarioIni);
                    registroViaje.SetHoraFin(horarioFin);
                }
                
                int idRegistroViaje = mapper.Crear(registroViaje);

                if (idRegistroViaje > 0)
                {
                    MessageBox.Show("Registro de viaje agregado correctamente");
                    this.Hide();
                    new MenuPrincipal().ShowDialog();
                    this.Close();

                }


            }
            catch (NullReferenceException) { }

            catch (ClienteInexistenteException error)
            {

                MessageBox.Show(error.Message, "Cliente inexistente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (CampoVacioException exception)
            {
                MessageBox.Show("Falta completar campo: " + exception.Message);
                return;
            }
            catch (SqlException error)
            {
                if (error.Number == 51015)
                {
                    MessageBox.Show(error.Message, "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (error.Number == 51016)
                {
                    MessageBox.Show(error.Message, "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (DuracionViajeInvalidaException error) {

                MessageBox.Show(error.Message, "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            
            }
            catch (PatenteAutomovilInexistente error)
            {

                MessageBox.Show(error.Message, "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            catch (ChoferInexistenteException error)
            {

                MessageBox.Show(error.Message, "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            catch (CantidaKilometrosInvalidoException error)
            {

                MessageBox.Show(error.Message, "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            catch (ClienteInhabilitadoException error)
            {

                MessageBox.Show(error.Message, "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            catch (HorarioNoCoincideConTurno error)
            {

                MessageBox.Show(error.Message, "Error horario no coincide con el turno", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            catch (FormatoInvalidoException exceptionFormato)
            {
                MessageBox.Show("Los datos fueron mal ingresados en: " + exceptionFormato.Message);
                return;
            }
                        
        }

       
                            
       }
}
