using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using UberFrba.Modelo;
using UberFrba.Exceptions;
using UberFrba.DataProvider;

namespace UberFrba.ABM_Chofer
{
    public partial class EditarChofer : Form
    {
        private int idChofer;
        private int idContacto = 0;
        private int idUsuario = 0;
        private DBMapper mapper = new DBMapper();

        public EditarChofer(String idChofer,String idUsuarioChofer)
        {
            InitializeComponent();
            this.idChofer = Convert.ToInt32(idChofer);
            this.idUsuario = Convert.ToInt32(idUsuarioChofer);
        }

        private void EditarChofer_Load(object sender, EventArgs e)
        {
         
            CargarDatos();
        }

        private void CargarDatos()
        {
            Choferes chofer = mapper.ObtenerChofer(idChofer);

           
           // idUsuario = chofer.GetIdUsuario();


            textBox_Nombre.Text = chofer.GetNombre();
            textBox_Mail.Text = chofer.GetMail();
            textBox_DNI.Text = chofer.GetDNI();
            textBox_Apellido.Text = chofer.GetApellido();
            textBox_FechaDeNacimiento.Text = Convert.ToString(chofer.GetFechaDeNacimiento());
            textBox_Telefono.Text = chofer.GetTelefono();
            textBox_Direccion.Text = Convert.ToString(chofer.GetDireccion());
            checkBox_Habilitado.Checked = Convert.ToBoolean(mapper.SelectFromWhere("usuario_habilitado", "Usuario", "usuario_id", chofer.GetIdUsuario()));//creo que aca deberia traer chofer_estado cambiar

        }


        private void button_Guardar_Click(object sender, EventArgs e)
        {
            // Guarda en variables todos los campos de entrada
            String Nombre = textBox_Nombre.Text;
            String Mail = textBox_Mail.Text;
            String DNI = textBox_DNI.Text;
            String Apellido = textBox_Apellido.Text;
            DateTime fechaDeNacimiento;
            DateTime.TryParse(textBox_FechaDeNacimiento.Text, out fechaDeNacimiento);
            String telefono = textBox_Telefono.Text;
            Boolean activo = checkBox_Habilitado.Checked; //La variable activo que esta en el checkbox es para saber si esta habilitado a nivel usuario --> ESTO QUE HICO EL PIBE NO ME CABE NI UN POCO
            Boolean pudoModificar;
            String Direccion = textBox_Direccion.Text;
    /*        // Update contacto
            Contacto contacto = new Contacto();
            try
            {
                contacto.setMail(mail);
                contacto.setTelefono(telefono);
                contacto.SetCalle(calle);
                contacto.SetNumeroCalle(numero);
                contacto.SetPiso(piso);
                contacto.SetDepartamento(departamento);
                contacto.SetLocalidad(localidad);
                contacto.SetCodigoPostal(codigoPostal);
                mapper.Modificar(idContacto, contacto);
            }
            catch (CampoVacioException exception)
            {
                MessageBox.Show("Falta completar campo: " + exception.Message);
                return;
            }
            catch (FormatoInvalidoException exception)
            {
                MessageBox.Show("Datos mal ingresados en: " + exception.Message);
                return;
            }
            */
            // Update chofer
            try
            {
                Choferes chofer = new Choferes();

                chofer.SetNombre(Nombre);
                chofer.SetApellido(Mail);
                chofer.SetDNI(DNI);
                chofer.SetApellido(Apellido);
                chofer.SetFechaDeNacimiento(fechaDeNacimiento);
                chofer.SetActivo(activo);
                chofer.SetMail(Mail);
                chofer.SetDireccion(Direccion);
                chofer.SetIdUsuario(idUsuario);
                chofer.SetTelefono(telefono);
                mapper.ActualizarEstadoUsuario(idChofer, activo);
            //    MessageBox.Show(Convert.ToString(idChofer));
              //  MessageBox.Show(Convert.ToString(activo));

                pudoModificar = mapper.Modificar(idChofer, chofer);
                if (pudoModificar) MessageBox.Show("Chofer modificado correctamente");
            }
            catch (CampoVacioException exception)
            {
                MessageBox.Show("Falta completar campo: " + exception.Message);
                return;
            }
            catch (FormatoInvalidoException exception)
            {
                MessageBox.Show("Datos mal ingresados en: " + exception.Message);
                return;
            }
            catch (TelefonoYaExisteException exception)
            {
                MessageBox.Show("Telefono ya existe" + exception.Message);
                return;
            }
                /*Como antes, faltan estas excepciones, despues las veo son las 2 de la matina y estoy cansadito
     /*       catch (CuitYaExisteException exception)
            {
                MessageBox.Show("Cuit ya existe");
                return;
            }
            catch (RazonSocialYaExisteException exception)
            {
                MessageBox.Show("RazonSocial ya existe");
                return;
            } */
            catch (FechaPasadaException exception)
            {
                MessageBox.Show("Fecha no valida" + exception.Message);
                return;
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

        private void button_FechaDeNacimiento_Click(object sender, EventArgs e)
        {
            monthCalendar_FechaDeCreacion.Visible = true;
        }

        private void monthCalendar_FechaDeCreacion_DateSelected(object sender, System.Windows.Forms.DateRangeEventArgs e)
        {
              textBox_FechaDeNacimiento.Text = e.Start.ToShortDateString();
            monthCalendar_FechaDeCreacion.Visible = false;
        }
    }
}