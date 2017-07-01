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
        private Mapper mapper = new Mapper();
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
            
            comboBox_Marca.Items.Add("Porsche");
            comboBox_Marca.Items.Add("Chevrolet");
            comboBox_Marca.Items.Add("Renault");
            comboBox_Marca.Items.Add("Peugeot");
            comboBox_Marca.Items.Add("Ford");
            comboBox_Marca.Items.Add("Fiat");
            comboBox_Marca.Items.Add("Volkswagen");
            comboBox_Marca.Items.Add("Toyota");
            comboBox_Marca.Items.Add("Citroën");
            CargarDatos();
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

        private void CargarComboBoxTurno(){

            //DataTable turnos = mapper.SelectDataTable("*", "PUSH_IT_TO_THE_LIMIT.Turno");//aca traigo todos los turnos habilitados o deshabilitados , si se quiere traer solo los habilitados descomentar la linea de abajo
            DataTable turnos = mapper.SelectDataTable("*", "PUSH_IT_TO_THE_LIMIT.Turno","turno_habilitado = 1");//aca traigo los turnos habilitados nada mas , si se quiere esta opcion comentar la linea de arriba y  descomentar esta


            foreach (DataRow fila in turnos.Rows)
            {
                string horaInicio = fila["turno_hora_inicio"].ToString();
                string horaFin = fila["turno_hora_fin"].ToString();
                string idTurnoCombo = fila["turno_id"].ToString();
                comboBox_Turno.Items.Add("El turno N° " + "("+idTurnoCombo +")"+ " comienza a las " + horaInicio + " y finaliza a las " + horaFin);

            }


        }

        private void turnoActulaes_Click(object sender, EventArgs e)
        {
   
            new TurnosDeUnAutomovil(this.idAutomovilString, false).ShowDialog();
        }

        private void button_Guardar_Click(object sender, EventArgs e)
        {
            // Guarda en variables todos los campos de entrada
            String Marca = comboBox_Marca.Text;
            String Modelo = textBox_Modelo.Text;
            String Patente = textBox_Patente.Text;
            String TurnoSeleccionado = comboBox_Turno.Text;
            String DniChofer = textBox_Chofer.Text;
            Boolean activo = checkBox_Habilitado.Checked; 
            Boolean pudoModificar;
            Boolean checkBoxActivoDeshabilitar_Chofer = checkBoxDeshabilitar_chofer.Checked;
            Boolean existeTurnoAutomovil;
            Boolean existeChoferAutomovil;

            try
            {
                
                Automoviles auto = new Automoviles();

                auto.SetMarca(Marca);
                auto.SetModelo(Modelo);
                auto.SetPatente(Patente);
                auto.SetActivo(activo);
                
                this.SetIdChofer(DniChofer);

                if (TurnoSeleccionado != "Ninguno" )
                {
                    String IDTurno = this.obtenerIdTurnoaPartirDeCombobox(comboBox_Turno.Text);
                    this.SetIdTurno(IDTurno);
                }


                existeTurnoAutomovil = mapper.ExisteEstadoTunoAutomovil(this.idAutomovil, idTurno);

                existeChoferAutomovil = mapper.ExisteChoferAutomovil(this.idAutomovil, this.idChofer);

                int idChoferViejo = mapper.obtenerIdChoferApartirDelDNI(dniChoferAutomovil);
                int idChoferNuevo = mapper.obtenerIdChoferApartirDelDNI(DniChofer);

                if (existeTurnoAutomovil)
                {
                    this.pudoActualizarTurnoAutomovil = mapper.ActualizarEstadoTurnoAutomovil(this.idAutomovil, idTurno, 1);

                }
                else
                {

                    if (TurnoSeleccionado != "Ninguno")
                    {
                        this.pudoActualizarTurnoAutomovil = mapper.AgregarTurnoAutomovil(this.idAutomovil, idTurno);
                    }
                    else
                    {


                        pudoActualizarTurnoAutomovil = true;
                    }
                }
                

                if (idChoferNuevo != idChoferViejo)
                {
                    if (existeChoferAutomovil)
                    {
                        //deshabilitar el chofer dni viejo
                        mapper.ActualizarEstadoChoferAutomovil(this.idAutomovil, idChoferViejo, 0);
                        //habilitar el chofer dni nuevo
                        this.pudoActualizarChoferAutomovil=mapper.ActualizarEstadoChoferAutomovil(this.idAutomovil, idChoferNuevo, 1);
                    }
                    else
                    {
                       
                        this.pudoActualizarChoferAutomovil = mapper.AsignarChoferaAutomovil(this.idAutomovil, idChoferNuevo);//aca llamo al procedure pr_agregar_chofer_a_automovil
                        if (pudoActualizarChoferAutomovil) {

                            mapper.ActualizarEstadoChoferAutomovil(this.idAutomovil, idChoferViejo, 0);
                        }

                    }
                }
                else {
                    Boolean existeChoferAutomovilActivo;
                    existeChoferAutomovilActivo = mapper.ExisteChoferAutomovilActivo(this.idChofer,this.idAutomovil,1);//Esto quiere decir que ya existe el chofer en la tabla choferporAuto con la columna auto_chofer_estado en 1


                    if (checkBoxActivoDeshabilitar_Chofer)
                    {

                        //deshabilitar  chofer
                        this.pudoActualizarChoferAutomovil = mapper.ActualizarEstadoChoferAutomovil(this.idAutomovil, idChoferViejo, 0);

                    }
                    else
                    {

                        if (existeChoferAutomovil)
                        {


                            if (existeChoferAutomovilActivo )
                            {

                                throw new ExisteChoferAutomovilHabilitadoException("Ya existe un Automovil activo para este Chofer");//Esto quiere decir que ya existe el chofer en la tabla choferporAuto con la columna auto_chofer_estado en 1

                            }
                            else
                            {

                                this.pudoActualizarChoferAutomovil = mapper.ActualizarEstadoChoferAutomovil(this.idAutomovil, idChoferViejo, 1);

                            }

                        }


                    }
                
                }
                pudoModificar = mapper.Modificar(idAutomovil, auto);
                
                if (pudoModificar && pudoActualizarTurnoAutomovil && pudoActualizarChoferAutomovil ) MessageBox.Show("Automovil modificado correctamente");

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
            
            catch (ChoferInexistenteException exceptionChoferNoexite)
            {

                MessageBox.Show(exceptionChoferNoexite.Message );
                return;

            }
            catch (ExisteChoferAutomovilHabilitadoException exceptionChoferAutoActivoexiste)
            {

                MessageBox.Show(exceptionChoferAutoActivoexiste.Message , "Coche activo ya asignado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
                 
            catch (SqlException error)
            {

                switch (error.Number)
                {
                    case 51005: MessageBox.Show(error.Message , "Coche activo ya asignado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;

                }
            }

            
        }

        public void SetIdTurno(String idTurno)
        {
            int existe = Convert.ToInt32(mapper.SelectFromWhere("COUNT(*)", "Turno", "turno_id", Convert.ToInt32(idTurno)));
            this.idTurno = Convert.ToInt32(idTurno);
        }

        public void SetIdChofer(String dniChofer)
        {
            if (dniChofer == "") throw new CampoVacioException("DNI Chofer");
            int idChoferObtenidoApartirDelDNI = mapper.obtenerIdChoferApartirDelDNI(dniChofer);
            this.idChofer = idChoferObtenidoApartirDelDNI;
        }

        public String obtenerIdTurnoaPartirDeCombobox(String turno)
        {
            if (turno == "")
            {
                throw new CampoVacioException("Turno , si no desea agregar un turno seleccione Ninguno");
            }
            string[] turnoSeparado1;
            string[] turnoSeparado2;
            turnoSeparado1 = turno.Split('(');
            turnoSeparado2 = turnoSeparado1[1].Split(')');
            return turnoSeparado2[0];
        }
      


        }

























    }

