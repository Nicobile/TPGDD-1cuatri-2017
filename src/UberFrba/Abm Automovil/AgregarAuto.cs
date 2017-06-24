using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UberFrba.Exceptions;
using UberFrba.Modelo;

namespace UberFrba.Abm_Automovil
{
    public partial class AgregarAuto : Form
    {
        private DBMapper mapper = new DBMapper();
        private int idAuto;
        private int idTurno;
        private int idChofer;
        Boolean choferAutoAgregado;
        Boolean turnoAutoAgregado;

        public Boolean TurnoAutoAgregado
        {
            get { return turnoAutoAgregado; }
            set { turnoAutoAgregado = value; }
        }

        public Boolean ChoferAutoAgregado
        {
            get { return choferAutoAgregado; }
            set { choferAutoAgregado = value; }
        }

        public AgregarAuto()
        {
            InitializeComponent();
            //CargarComboBoxTurno();
        }

        private void AgregarAuto_Load(object sender, EventArgs e)
        {
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

        private void button_Guardar_Click(object sender, EventArgs e)
        {
            String Marca =comboBox_Marca.Text;
            String Modelo = textBox_Modelo.Text;
            String Patente = textBox_Patente.Text;
            //String Turno = textBox_Turno.Text;
            String Chofer = textBox_Chofer.Text;
            String IDTurno = comboBox_Turno.Text.Substring(12,1);
            MessageBox.Show(IDTurno);
            String DniChofer = textBox_Chofer.Text;

           

            try
            {

                Automoviles auto = new Automoviles();

                auto.SetMarca(Marca);
                auto.SetModelo(Modelo);
                auto.SetPatente(Patente);
                auto.SetActivo(true);
                this.SetIdTurno(IDTurno);
                this.SetIdChofer(DniChofer);
                //MessageBox.Show(Convert.ToString(idChofer));
                idAuto = mapper.CrearAutomoviles(auto);
                

                if (idAuto != 0)
                {
                     choferAutoAgregado = mapper.AsignarChoferaAutomovil(this.idAuto, this.idChofer);
                    turnoAutoAgregado = mapper.AsignarTurnoaAutomovil(this.idAuto, this.idTurno);

                   
             
                }
                if (idAuto > 0 && this.choferAutoAgregado==true && this.turnoAutoAgregado==true)
                {
                    MessageBox.Show("Automovil agregado correctamente");

                }


            }
            catch (CampoVacioException exceptionCampoVacio)
            {
                MessageBox.Show("Falta completar campo: " + exceptionCampoVacio.Message);
                return;
            }
            catch (FormatoInvalidoException exceptionFormato)
            {
                MessageBox.Show("Los datos fueron mal ingresados en: " + exceptionFormato.Message);
                return;
            }
            catch (ChoferInexistenteException exceptionChofer)
            {
                MessageBox.Show(exceptionChofer.Message);
                return;
            }
            catch (TurnoInexistenteException exceptionTurno)
            {
                MessageBox.Show(exceptionTurno.Message + IDTurno);
                return;
            }
            catch (SqlException error)
            {

                switch (error.Number)
                {
                    case 51005: MessageBox.Show(error.Message+" para agregarlo ingresarlo desmarcar el casillero de Habilitado", "Coche activo ya asignado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        mapper.EliminarAutoFisicamenteDelaBase(idAuto, "Auto");//esto es para eliminar el auto que se agrego arriba por que a pesar de que falle al agregar AutoChofer al al auto lo agrega
                        return;
                        break;

                }
            }

            VolverAlMenu();
           
        }

        private void button_Limpiar_Click(object sender, EventArgs e)
        {

            comboBox_Marca.Text = "";
            textBox_Modelo.Text = "";
            textBox_Patente.Text = "";
            comboBox_Turno.Text = "";
            textBox_Chofer.Text = "";

        }

        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            VolverAlMenu();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        public void SetIdTurno(String idTurno)
        {
            if (idTurno == "") throw new CampoVacioException("Turno");
            int existe = Convert.ToInt32(mapper.SelectFromWhere("COUNT(*)", "Turno", "turno_id", Convert.ToInt32(idTurno)));
            if (existe == 0) throw new TurnoInexistenteException("No existe un Turno con N° ");
            this.idTurno = Convert.ToInt32(idTurno);
        }

        public void SetIdChofer(String dniChofer)
        {
            if (dniChofer == "") throw new CampoVacioException("DNI Chofer");
            int idChoferObtenidoApartirDelDNI=Convert.ToInt32(mapper.SelectFromWhere("chofer_id","Chofer","chofer_dni",Convert.ToInt32(dniChofer)));
            if(idChoferObtenidoApartirDelDNI==0) throw new ChoferInexistenteException("No existe un chofer con DNI igual a : ");
            this.idChofer = idChoferObtenidoApartirDelDNI;
        }


        private void VolverAlMenu()
        {
            this.Hide();
            new MenuAutomovil().ShowDialog();
            this.Close();
        }

        private void CargarComboBoxTurno(){//ComboBox comboTurno) {

            DataTable turnos = mapper.SelectDataTable("*", "PUSH_IT_TO_THE_LIMIT.Turno");//aca traigo todos los turnos habilitados o deshabilitados , si se quiere traer solo los habilitados descomentar la linea de abajo
            //DataTable turnos = mapper.SelectDataTable("*", "PUSH_IT_TO_THE_LIMIT.Turno","turno_habilitado = 1");aca traigo los turnos habilitados nada mas , si se quiere esta opcion comentar la linea de arriba y  descomentar esta
            

            foreach (DataRow fila in turnos.Rows)
            {
                string horaInicio = fila["turno_hora_inicio"].ToString();
                string horaFin = fila["turno_hora_fin"].ToString();
                string idTurnoCombo = fila["turno_id"].ToString();
                comboBox_Turno.Items.Add("El turno N° "+ idTurnoCombo + " comienza a las "+horaInicio+" y finaliza a las " + horaFin);

            }
        
        
        }

    }
}
