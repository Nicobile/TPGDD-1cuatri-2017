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
    public partial class AgregarChofer : Form
    {
        private String username;
        private String contrasena;
        private DBMapper mapper = new DBMapper();
        private int idUsuario;
        private int idChofer;

        public AgregarChofer(String username, String contrasena)
        {
            InitializeComponent();
            this.username = username;
            this.contrasena = contrasena;
            this.idUsuario = 0;
        }

   /*     private void AgregarChofer_Load(object sender, EventArgs e)
        {
            CargarRubros();
        }
        */
        private void button_Guardar_Click(object sender, EventArgs e)
        {
            // Guarda en variables todos los campos de entrada
            String Nombre = textBox_Nombre.Text;
            String Apellido = textBox_Apellido.Text;
            String DNI = textBox_DNI.Text;
            String Direccion = textBox_Direccion.Text;
            String Telefono = textBox_Telefono.Text;
            String Mail = textBox_Mail.Text;
            DateTime fechaDeNacimiento;
            DateTime.TryParse(textBox_FechaDeNacimiento.Text, out fechaDeNacimiento);
           
           /*
            // Crea una contacto y se guarda su id
            Contacto contacto = new Contacto();
            try
            {
                contacto.setMail(mail);
                contacto.setTelefono(telefono);
                contacto.SetCalle(calle);
                contacto.SetNumeroCalle(numeroCalle);
                contacto.SetPiso(piso);
                contacto.SetDepartamento(departamento);
                contacto.SetLocalidad(localidad);
                contacto.SetCodigoPostal(codigoPostal);

            }
            catch (CampoVacioException exception)
            {
                MessageBox.Show("Falta completar campo: " + exception.Message);
                return;
            }
            catch (FormatoInvalidoException exception)
            {
                MessageBox.Show("Los datos fueron mal ingresados en: " + exception.Message);
                return;
            }

            // Controla que no se haya creado ya el contacto
            if (this.idContacto == 0)
            {
                this.idContacto = mapper.CrearContacto(contacto);
            }
            */

            // Crea Chofer
            try
            {
                Choferes chofer = new Choferes();

                chofer.SetNombre(Nombre);
                chofer.SetApellido(Apellido);
                chofer.SetDNI(DNI);
                chofer.SetDireccion(Direccion);
                chofer.SetTelefono(Telefono);
                chofer.SetMail(Mail);
                chofer.SetFechaDeNacimiento(fechaDeNacimiento);

                idChofer = mapper.CrearChofer(chofer);
                if (idChofer > 0) MessageBox.Show("Chofer agregado correctamente");
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
            catch (TelefonoYaExisteException exceptionTelefono)
            {
                MessageBox.Show("Telefono ya existe");
                return;
            }

          /*Excepciones no creadas, hay que verlo tambien, realmente quiero estar muerto*/

          /*  catch (CuitYaExisteException exceptionCuit)
            {
                MessageBox.Show("Cuit ya existe");
                return;
            }                             
            catch (RazonSocialYaExisteException exceptionRazonSocial)
            {
                MessageBox.Show("RazonSocial ya existe");
                return;
            } */
            catch (FechaPasadaException exceptionFecha)
            {
                MessageBox.Show("Fecha no valida");
                return;
            }

            // Si al chofer lo crea el admin, crea un nuevo usuario predeterminado.
            if (idUsuario == 0)
            {
                idUsuario = CrearUsuario();
                Boolean resultado = mapper.AsignarUsuarioAChofer(idChofer, idUsuario);
                if (resultado) MessageBox.Show("El usuario fue creado correctamente");
            }

            mapper.AsignarRolAUsuario(this.idUsuario, "Chofer");

            VolverAlMenuPrincipal();
        }

        private int CrearUsuario()
        {
            if (username == "choferCreadoPorAdmin")
            {
                return mapper.CrearUsuario(); //Se crean con los parametros default
            }
            else
            {
                return mapper.CrearUsuarioConValores(username, contrasena); //Si es por registro de usuario, segun los parametros dados
            }
        }

       /* private void CargarRubros()
        {
            string query = "SELECT rubro_id, rubro_desc_larga from NET_A_CERO.Rubros";

            SqlCommand cmd = new SqlCommand(query, ConnectionManager.Instance.getConnection());

            SqlDataAdapter data_adapter = new SqlDataAdapter(cmd);
            DataTable rubros = new DataTable();
            data_adapter.Fill(rubros);

            comboBox_Direccion.ValueMember = "rubro_id";
            comboBox_Direccion.DisplayMember = "rubro_desc_larga";
            comboBox_Direccion.DataSource = rubros;
            comboBox_Direccion.SelectedIndex = -1;
        }
        */
        private void button_Limpiar_Click(object sender, EventArgs e)
        {
            textBox_Nombre.Text = "";
            textBox_Mail.Text = "";
            textBox_DNI.Text = "";
            textBox_Apellido.Text = "";
            textBox_Direccion.Text = "";
            textBox_FechaDeNacimiento.Text = "";
            textBox_Mail.Text = "";
            textBox_Telefono.Text = "";

        }

        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            if (UsuarioSesion.Usuario.rol != "Administrativo")
            {
                this.Hide();
                new Registro_de_Usuario.RegistrarUsuario().ShowDialog();
                this.Close();
            }
            else
            {
                VolverAlMenuPrincipal();
            }
        }

        private void VolverAlMenuPrincipal()
        {
            this.Hide();
            new MenuPrincipal().ShowDialog();
            this.Close();
        }

        private void button_FechaDeCreacion_Click(object sender, EventArgs e)
        {
            monthCalendar_FechaDeNacimiento.Visible = true;
        }

        private void monthCalendar_FechaDeCreacion_DateSelected(object sender, System.Windows.Forms.DateRangeEventArgs e)
        {
            textBox_FechaDeNacimiento.Text = e.Start.ToShortDateString();
            monthCalendar_FechaDeNacimiento.Visible = false;
        }
    }
}