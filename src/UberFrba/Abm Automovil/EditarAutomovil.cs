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
        Boolean pudoActualizarTurnoAutomovil;
        Boolean pudoActualizarChoferAutomovil;

        public Boolean PudoActualizarChoferAutomovil
        {
            get { return pudoActualizarChoferAutomovil; }
            set { pudoActualizarChoferAutomovil = value; }
        }

        public Boolean PudoActualizarTurnoAutomovil
        {
            get { return pudoActualizarTurnoAutomovil; }
            set { pudoActualizarTurnoAutomovil = value; }
        }

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
            comboBox_Turno.Items.Add("Ninguno");
            
        }




        private void CargarDatos()
        {
            Automoviles automovil = mapper.ObtenerAutomovil(idAutomovil);


            comboBox_Marca.Text = automovil.GetMarca();
            textBox_Modelo.Text = automovil.GetModelo();
            textBox_Patente.Text = automovil.GetPatente();
            textBox_Chofer.Text = Convert.ToString(this.dniChoferAutomovil);
            checkBox_Habilitado.Checked = Convert.ToBoolean(mapper.SelectFromWhere("auto_estado", "Auto", "auto_id", automovil.GetId()));
            comboBox_Turno.Text = "Agregar un Turno";

        }

        private void button_Limpiar_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarComboBoxTurno()
        {//ComboBox comboTurno) {

            //DataTable turnos = mapper.SelectDataTable("*", "PUSH_IT_TO_THE_LIMIT.Turno");//aca traigo todos los turnos habilitados o deshabilitados , si se quiere traer solo los habilitados descomentar la linea de abajo
            DataTable turnos = mapper.SelectDataTable("*", "PUSH_IT_TO_THE_LIMIT.Turno","turno_habilitado = 1");//aca traigo los turnos habilitados nada mas , si se quiere esta opcion comentar la linea de arriba y  descomentar esta


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
   
            new TurnosDeUnAutomovil(this.idAutomovilString,false,this.idAutomovil).ShowDialog();
        }

        private void button_Guardar_Click(object sender, EventArgs e)
        {
            // Guarda en variables todos los campos de entrada
            String Marca = comboBox_Marca.Text;
            String Modelo = textBox_Modelo.Text;
            String Patente = textBox_Modelo.Text;
            String TurnoSeleccionado = comboBox_Turno.Text;
            String DniChofer = textBox_Chofer.Text;
            Boolean activo = checkBox_Habilitado.Checked; //La variable activo que esta en el checkbox es para saber si esta habilitado a nivel usuario --> ESTO QUE HICO EL PIBE NO ME CABE NI UN POCO
            Boolean pudoModificar;
            Boolean checkBoxActivoDeshabilitar_Chofer = checkBoxDeshabilitar_chofer.Checked;
            Boolean existeTurnoAutomovil;
            Boolean existeChoferAutomovil;

            try
            {
                if (TurnoSeleccionado != "Ninguno")
                {
                    String IDTurno = comboBox_Turno.Text.Substring(12, 1); //lo hago aca para capturar la excepcion que lanza el substring al ser vacio el comboBox_turno
                    this.SetIdTurno(IDTurno);
                }
                
                Automoviles auto = new Automoviles();

                auto.SetMarca(Marca);
                auto.SetModelo(Modelo);
                auto.SetPatente(Patente);
                auto.SetActivo(activo);
                
                this.SetIdChofer(DniChofer);
                //MessageBox.Show(Convert.ToString(idChofer));
                //idAuto = mapper.CrearAutomoviles(auto);


                pudoModificar = mapper.Modificar(idAutomovil, auto);

                existeTurnoAutomovil = mapper.ExisteEstadoTunoAutomovil(this.idAutomovil, idTurno);

                existeChoferAutomovil = mapper.ExisteChoferAutomovil(this.idAutomovil, this.idChofer);
                MessageBox.Show("idAutomovil"+Convert.ToString(this.idAutomovil));
                MessageBox.Show("idChofer" + Convert.ToString(this.idChofer));

                int idChoferViejo = this.obtenerIdChoferApartirDelDNI(dniChoferAutomovil);
                int idChoferNuevo = this.obtenerIdChoferApartirDelDNI(DniChofer);
                MessageBox.Show("idChoferViejo"+Convert.ToString(idChoferViejo));
                MessageBox.Show("idChoferNuevo" + Convert.ToString(idChoferNuevo));
                //MessageBox.Show("Existe chofer Autmovil " + Convert.ToString(existeChoferAutomovil));

                if (idChoferNuevo != idChoferViejo)
                {
                    MessageBox.Show("Existe chofer Autmovil "+Convert.ToString( existeChoferAutomovil));
                    if (existeChoferAutomovil)
                    {
                        MessageBox.Show("Pase por if(existeChoferAutomovil)");
                        //deshabilitar el chofer dni viejo
                        mapper.ActualizarEstadoChoferAutomovil(this.idAutomovil, idChoferViejo, 0);
                        //habilitar el chofer dni nuevo
                        this.pudoActualizarChoferAutomovil=mapper.ActualizarEstadoChoferAutomovil(this.idAutomovil, idChoferNuevo, 1);
                    }
                    else
                    {
                        MessageBox.Show("Pase por el else del if(existeChoferAutomovil)");
                       
                       // this.pudoActualizarChoferAutomovil = mapper.AgregarChoferAutomovil(this.idAutomovil, idChoferNuevo);
                        this.pudoActualizarChoferAutomovil = mapper.AsignarChoferaAutomovil(this.idAutomovil, idChoferNuevo);//aca llamo al procedure pr_agregar_chofer_a_automovil

                        if (pudoActualizarChoferAutomovil) {

                            mapper.ActualizarEstadoChoferAutomovil(this.idAutomovil, idChoferViejo, 0);
                        }

                    }
                }
                else {

                    if (checkBoxActivoDeshabilitar_Chofer) {
                        MessageBox.Show("Pase por el else del if(idchoferNuevo != idChoferViejo) y if (checkBoxActivoDeshabilitar_Chofer)");
                    
                    //deshabilitar  chofer
                        this.pudoActualizarChoferAutomovil = mapper.ActualizarEstadoChoferAutomovil(this.idAutomovil, idChoferViejo, 0);
                    
                    }
                
                
                
                
                
                }

                if (existeTurnoAutomovil)
                {
                    MessageBox.Show("Existe turno autovomil "+Convert.ToString(existeTurnoAutomovil));
                    this.pudoActualizarTurnoAutomovil = mapper.ActualizarEstadoTurnoAutomovil(this.idAutomovil, idTurno, 1);
                   
                }
                else
                {

                    if (TurnoSeleccionado != "Ninguno")
                    {
                        this.pudoActualizarTurnoAutomovil = mapper.AgregarTurnoAutomovil(this.idAutomovil, idTurno);
                    }
                    else {


                        pudoActualizarTurnoAutomovil = true;
                    }
                }
                
                








                if (pudoModificar && pudoActualizarTurnoAutomovil ) MessageBox.Show("Automovil modificado correctamente");

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
            catch (FormatException exceptionNoSeIngresoUnTurno)
            {

                MessageBox.Show("Si no desea agregar ningun Turno seleccione Ninguno");
                return;

            }
            catch (ChoferInexistenteException exceptionChoferNoexite)
            {

                MessageBox.Show(exceptionChoferNoexite.Message + DniChofer);
                return;

            }
            catch (SqlException error)
            {

                switch (error.Number)
                {
                    case 51005: MessageBox.Show(error.Message + " para agregarlo ingresarlo desmarcar el casillero de Habilitado", "Coche activo ya asignado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                       // mapper.EliminarAutoFisicamenteDelaBase(idAuto, "Auto");//esto es para eliminar el auto que se agrego arriba por que a pesar de que falle al agregar AutoChofer al al auto lo agrega
                        return;
                        break;

                }
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
            int idChoferObtenidoApartirDelDNI = this.obtenerIdChoferApartirDelDNI(dniChofer);
            //Convert.ToInt32(mapper.SelectFromWhere("chofer_id","Chofer","chofer_dni",Convert.ToInt32(dniChofer)));
            //if(idChoferObtenidoApartirDelDNI==0) throw new ChoferInexistenteException("No existe un chofer con DNI igual a : ");
            this.idChofer = idChoferObtenidoApartirDelDNI;
        }

        public int obtenerIdChoferApartirDelDNI(String dniChofer) {


            int idChoferObtenidoApartirDelDNI = Convert.ToInt32(mapper.SelectFromWhere("chofer_id", "Chofer", "chofer_dni", Convert.ToInt32(dniChofer)));
            if (idChoferObtenidoApartirDelDNI == 0) throw new ChoferInexistenteException("No existe un chofer con DNI igual a : ");

            return idChoferObtenidoApartirDelDNI;
        
        }


        }

























    }

