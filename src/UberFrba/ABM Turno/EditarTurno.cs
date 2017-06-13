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

namespace UberFrba.ABM_Turno
{
    public partial class EditarTurno : Form
    {
        private int idTurno;
        
        private DBMapper mapper = new DBMapper();

        public EditarTurno(String idTurno)
        {
            InitializeComponent();
            this.idTurno = Convert.ToInt32(idTurno);
        }

        private void EditarTurno_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }


        private void CargarDatos()
        {
            Turnos turno = mapper.ObtenerTurnos(idTurno);


            // idUsuario = chofer.GetIdUsuario();


            textBox_HoraInicio.Text = Convert.ToString(turno.GetHoraInicio());
            textBox_HoraFin.Text = Convert.ToString(turno.GetHoraFin());
            textBox_Descripcion.Text = Convert.ToString(turno.GetDescripcion());
            textBox_ValorKilometro.Text = Convert.ToString(turno.GetValorKilometro());
            textBox_PrecioBase.Text = Convert.ToString(turno.GetPrecioBaseTurno());
            checkBox_Habilitado.Checked = Convert.ToBoolean(mapper.SelectFromWhere("turno_habilitado", "Turno", "turno_id",this.idTurno));

        }

        

        private void button_Guardar_Click(object sender, EventArgs e)
        {

            // Guarda en variables todos los campos de entrada
            String hora_inicio = textBox_HoraInicio.Text;
            String hora_fin = textBox_HoraFin.Text;
            String descripcion = textBox_Descripcion.Text;
            String valor_Kilometro = textBox_ValorKilometro.Text;
            String precio_base = textBox_PrecioBase.Text;
            Boolean activo = checkBox_Habilitado.Checked; //La variable activo que esta en el checkbox es para saber si esta habilitado a nivel usuario
            
            Boolean pudoModificar;

            // Update Turno
            try
            {
                Turnos turno = new Turnos();
                
                turno.SetHoraInicio(hora_inicio);
                turno.SetHoraFin(hora_fin);
                turno.SetDescripcion(descripcion);
                turno.SetValorKilometro(valor_Kilometro);
                turno.SetPrecioBaseTurno(precio_base);
                turno.SetActivo(activo);
                //MessageBox.Show(hora_inicio + " " + hora_fin + " " + descripcion + " " + valor_Kilometro + " " + precio_base + " " + activo);   
                
                pudoModificar = mapper.Modificar(idTurno, turno);
                
       
               if (pudoModificar) { 
                   MessageBox.Show("El Turno se modifico correctamente"); 
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
            catch (SqlException error)
            {

                switch (error.Number)
                {
                    case 51000: MessageBox.Show("El turno ingresado se superpone con otro", "Turno Superpuesto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case 51001: MessageBox.Show("El turno ingresado se superpone con otro", "Turno Superpuesto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case 51002: MessageBox.Show("El turno ingresado ya existe y esta Activo", "Turno Existente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case 51003: MessageBox.Show("El turno ingresado ya existe y esta Deshabilitado", "Turno Existente Deshabilitado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case 51004: MessageBox.Show("El horario ingresado es mayor a un dia o es invalido", "Turno Horario Invalido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
            this.Close();
                   


        }

        private void button_Limpiar_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
