using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UberFrba.Modelo;

namespace UberFrba.Abm_Automovil
{
    public partial class EditarAutomovil : Form
    {
        private int idAutomovil;
        private String dniChoferAutomovil;
        private DBMapper mapper = new DBMapper();

        public EditarAutomovil(String idAutomovil, String idChofer)
        {
            InitializeComponent();
            this.idAutomovil = Convert.ToInt32(idAutomovil);
            this.dniChoferAutomovil = idChofer;
            
        }

        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditarAutomovil_Load(object sender, EventArgs e)
        {
            CargarDatos();
            comboBox_Marca.Items.Add("Porsche");
            comboBox_Marca.Items.Add("Chevrolet");
            comboBox_Marca.Items.Add("Renault");
            comboBox_Marca.Items.Add("Peugeot");
            comboBox_Marca.Items.Add("Ford");
            comboBox_Marca.Items.Add("Fiat");
            comboBox_Marca.Items.Add("Volkswagen");
            comboBox_Marca.Items.Add("Toyota");
            comboBox_Marca.Items.Add("Citroën");
            CargarComboBoxTurno();
            
        }




        private void CargarDatos()
        {
            Automoviles automovil = mapper.ObtenerAutomovil(idAutomovil);


            comboBox_Marca.Text = automovil.GetMarca();
            textBox_Modelo.Text = automovil.GetModelo();
            textBox_Patente.Text = automovil.GetPatente();
            textBox_Chofer.Text = Convert.ToString(this.dniChoferAutomovil);
            checkBox_Habilitado.Checked = Convert.ToBoolean(mapper.SelectFromWhere("auto_estado", "Auto", "auto_id", automovil.GetId()));


        }

        private void button_Limpiar_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarComboBoxTurno()
        {//ComboBox comboTurno) {

            DataTable turnos = mapper.SelectDataTable("*", "PUSH_IT_TO_THE_LIMIT.Turno");//aca traigo todos los turnos habilitados o deshabilitados , si se quiere traer solo los habilitados descomentar la linea de abajo
            //DataTable turnos = mapper.SelectDataTable("*", "PUSH_IT_TO_THE_LIMIT.Turno","turno_habilitado = 1");aca traigo los turnos habilitados nada mas , si se quiere esta opcion comentar la linea de arriba y  descomentar esta


            foreach (DataRow fila in turnos.Rows)
            {
                string horaInicio = fila["turno_hora_inicio"].ToString();
                string horaFin = fila["turno_hora_fin"].ToString();
                string idTurnoCombo = fila["turno_id"].ToString();
                comboBox_Turno.Items.Add("El turno N° " + idTurnoCombo + " comienza a las " + horaInicio + " y finaliza a las " + horaFin);

            }


        }







    }
}
