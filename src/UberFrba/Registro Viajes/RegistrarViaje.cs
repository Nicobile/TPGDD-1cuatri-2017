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
            textBox_FHfin.Text = "";
            textBox_FHinicio.Text = "";
            comboBox_TurnosAutmovilSeleccionado.Text = "";    
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

            DataTable turnosAutomovil = mapper.ObtenerTurnosHabilitadosAutmovil(idAutomovilSeleccionado);


            foreach (DataRow fila in turnosAutomovil.Rows)
            {
                string horaInicio = fila["Hora Inicio"].ToString();
                string horaFin = fila["Hora Fin"].ToString();
                string idTurnoCombo = fila["Turno N°"].ToString();
                comboBox_TurnosAutmovilSeleccionado.Items.Add("El turno N° " + idTurnoCombo + " comienza a las " + horaInicio + " y finaliza a las " + horaFin);

            }

        }

                            
       }
}
