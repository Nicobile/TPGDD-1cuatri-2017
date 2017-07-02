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
        private Mapper mapper = new Mapper();
        String ideTurno ;

        public RendicionViaje()
        {
            InitializeComponent();
            DateTime FECHA_ACTUAL = DateTime.Parse(ConfigurationManager.AppSettings["Fecha"]);
            this.monthCalendar_Fecha.MaxDate = FECHA_ACTUAL;
            this.monthCalendar_Fecha.TodayDate = FECHA_ACTUAL;
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
                comboBox_Turnos.Items.Add("El turno N° " + "("+idTurnoCombo + ")"+" comienza a las " + horaInicio + " y finaliza a las " + horaFin);
            }

        }

        private void button_Limpiar_Click(object sender, EventArgs e)
        {
            LimpiarDatos();
        }


        public void LimpiarDatos() 
        {
            textBox_Fecha.Text = "";
            comboBox_chofer.Items.Clear();
            this.CargarComboBoxChoferes();
            comboBox_Turnos.Items.Clear();
            this.CargarComboBoxTurnos();
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

        public String obtenerDNIaPartirDetextBox(String chofer)
        {
            if (chofer == "") {
                throw new CampoVacioException("Chofer");
            }
            else
            {
                string[] separadas;
                separadas = chofer.Split(':');
                String DniCliente = separadas[1];
                return DniCliente;
            }
        }


        private void btnFacturar_Click(object sender, EventArgs e)
        {
            String Fecha = textBox_Fecha.Text;
            String Total = textBox_importe.Text;

            try
            {
                {
                    Rendicion rendicion = new Rendicion();
                    rendicion.SetFechaRendicion(Fecha);
                    String ChoferDNI = this.obtenerDNIaPartirDetextBox(comboBox_chofer.Text);
                    rendicion.SetIdChofer(ChoferDNI);
                    this.ideTurno = this.obtenerIdTurnoaPartirDeCombobox(comboBox_Turnos.Text);
                    rendicion.SetIdTurno(ideTurno);
                    
                    
                    if (!mapper.ExisteRendicion( Fecha,rendicion.GetIdChofer()))
                    {
                        rendicion.SetImporteTotalRendicion(Total);
                        int idRendicion = mapper.Crear(rendicion);
                        if (idRendicion > 0)
                        {
                            MessageBox.Show("Se creo correctamente la Rendición");

                            mapper.ActualizarRendicionIdenRegistrViaje(idRendicion, rendicion.GetFechaRendicion(), rendicion.GetIdChofer(), ideTurno);

                            this.Hide();
                            new MenuPrincipal().ShowDialog();
                            this.Close();

                        }
                    }
                    else { 
                        MessageBox.Show("Ya se realizo la rendicion diaria para ese chofer o no posee registros en esa fecha ", "Rendicion existente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }

            }
            catch (CampoVacioException exception)
            {
                MessageBox.Show("Falta completar campo: " + exception.Message);
                return;
            }
            catch (NoHayViajesException exception)
            {
                MessageBox.Show(exception.Message,"Error al registrar",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
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

        private void OcultarColumnasQueNoDebenVerse()
        {
            dataGridView_Viajes_Rendidos.Columns["auto_id"].Visible = false;
            dataGridView_Viajes_Rendidos.Columns["chofer_id"].Visible = false;
            dataGridView_Viajes_Rendidos.Columns["cliente_id"].Visible = false;
            dataGridView_Viajes_Rendidos.Columns["turno_id"].Visible = false;
            dataGridView_Viajes_Rendidos.Columns["factura_id"].Visible = false;
            dataGridView_Viajes_Rendidos.Columns["rendicion_id"].Visible = false;
        }
       
        private void cargarTurnos()
        {

            try
            {
                String DNIChofer = this.obtenerDNIaPartirDetextBox(comboBox_chofer.Text);
                int idChofer = mapper.obtenerIdChoferApartirDelDNI(DNIChofer);
                this.ideTurno = this.obtenerIdTurnoaPartirDeCombobox(comboBox_Turnos.Text);
                dataGridView_Viajes_Rendidos.DataSource = mapper.SelectDataTableRegistroViajeparaRendi(textBox_Fecha.Text, idChofer, ideTurno);
                OcultarColumnasQueNoDebenVerse();
                textBox_importe.Text = mapper.TotalRendicion(textBox_Fecha.Text, idChofer, ideTurno);
            }
            catch (CampoVacioException exception)
            {
                MessageBox.Show("Falta completar campo: " + exception.Message);
                LimpiarDatos();               
                return;
            }
        }

        private void comboBox_Turnos_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarTurnos();
        }
    }
}
