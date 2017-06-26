using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UberFrba.DataProvider;

namespace UberFrba.Rendicion_Viajes
{
    public partial class RendicionViaje : Form
    {
        private DBMapper mapper = new DBMapper();

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
            //"SELECT t.turno_id 'Turno N°',t.turno_hora_inicio 'Hora Inicio',t.turno_hora_fin 'Hora Fin',t.turno_descripcion 'Descripcion',t.turno_valor_Kilometro 'Valor Kilometro',t.turno_precio_base 'Precio Base',(t.turno_habilitado & A.auto_turno_estado) 'Habilitado'FROM  PUSH_IT_TO_THE_LIMIT.Turno t JOIN    PUSH_IT_TO_THE_LIMIT.AutoporTurno A ON(T.turno_id=A.turno_id) where t.turno_id IN (SELECT turno_id FROM PUSH_IT_TO_THE_LIMIT.AutoporTurno WHERE auto_id=@idAutomovil) AND auto_id=@idAutomovil AND auto_turno_estado=1 "
            DataTable turnosAutomovil = mapper.SelectDataTable(" turno_id 'Turno Nº',turno_hora_inicio 'Hora Inicio',turno_hora_fin 'Hora Fin' "," PUSH_IT_TO_THE_LIMIT.Turno ");


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
    }
}
