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
using UberFrba.Modelo;

namespace UberFrba.Abm_Automovil
{
    public partial class EditarAutomovil : Form
    {
        private int idAutomovil;
        private String dniChoferAutomovil;
        private String idAutomovilString;
        private DBMapper mapper = new DBMapper();
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


        public EditarAutomovil(String idAutomovil, String idChofer)
        {
            InitializeComponent();
            this.idAutomovilString=idAutomovil;
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

        private void turnoActulaes_Click(object sender, EventArgs e)
        {
   
            new TurnosDeUnAutomovil(this.idAutomovilString).ShowDialog();
        }

        private void button_Guardar_Click(object sender, EventArgs e)
        {
            // Guarda en variables todos los campos de entrada
            String Marca = comboBox_Marca.Text;
            String Modelo = textBox_Modelo.Text;
            String Patente = textBox_Modelo.Text;
//            String IDTurno = comboBox_Turno.Text.Substring(12, 1); 
            String DniChofer = textBox_Chofer.Text;
            Boolean activo = checkBox_Habilitado.Checked; //La variable activo que esta en el checkbox es para saber si esta habilitado a nivel usuario --> ESTO QUE HICO EL PIBE NO ME CABE NI UN POCO
            Boolean pudoModificar;


            try
            {
                String IDTurno = comboBox_Turno.Text.Substring(12, 1); //lo hago aca para capturar la excepcion que lanza el substring al ser vacio el comboBox_turno

                Automoviles auto = new Automoviles();

                auto.SetMarca(Marca);
                auto.SetModelo(Modelo);
                auto.SetPatente(Patente);
                auto.SetActivo(activo);
                this.SetIdTurno(IDTurno);
                this.SetIdChofer(DniChofer);
                //MessageBox.Show(Convert.ToString(idChofer));
                //idAuto = mapper.CrearAutomoviles(auto);


                pudoModificar = mapper.Modificar(idAutomovil, auto);
                if (pudoModificar) MessageBox.Show("Automovil modificado correctamente");

                //if (idAuto != 0)
                //{
                //     choferAutoAgregado = mapper.AsignarChoferaAutomovil(this.idAuto, this.idChofer);
                //    turnoAutoAgregado = mapper.AsignarTurnoaAutomovil(this.idAuto, this.idTurno);



                //}
                //if (idAuto > 0 && this.choferAutoAgregado==true && this.turnoAutoAgregado==true)
                //{
                //    MessageBox.Show("Automovil agregado correctamente");

                //}
                this.Close();


            }
            catch (CampoVacioException exception)
            {
                MessageBox.Show("Falta completar campo : " + exception.Message);
                return;
            }
            catch (FormatoInvalidoException exception)
            {
                MessageBox.Show("Datos mal ingresados en: " + exception.Message);
                return;
            }
            catch (ArgumentOutOfRangeException exceptionNoSeIngresoUnTurno) {

                MessageBox.Show("Falta completar campo : Turno");
                return;
            
            }

            
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




        }

























    }

