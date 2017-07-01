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
        private Mapper mapper = new Mapper();
        private int idUsuario;
        private int idChofer;
        private Boolean creadoDesdeRegistrarUsuario;

        public AgregarChofer(String username, String contrasena,Boolean creadoDesdeRegistrar)
        {
            InitializeComponent();
            this.username = username;
            this.contrasena = contrasena;
            this.idUsuario = 0;
            this.creadoDesdeRegistrarUsuario = creadoDesdeRegistrar;
        }

          private void AgregarChofer_Load(object sender, EventArgs e)
        {

        }

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
                chofer.SetActivo(true);
                if (username != "" && contrasena != "")
                {


                    idUsuario = mapper.CrearUsuarioConValores(username, contrasena);

                }
                else 
                {
                    idUsuario = mapper.CrearUsuarioConValores(DNI, DNI);
                
                }
               
                chofer.SetFechaDeNacimiento(fechaDeNacimiento);
                chofer.SetIdUsuario(idUsuario);
                idChofer = mapper.CrearChofer(chofer);
                

                if (idChofer > 0)
                {
                    MessageBox.Show("Chofer agregado correctamente");
                
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
            catch (TelefonoYaExisteException )
            {
                MessageBox.Show("Telefono ya existe");
                return;
            }
            catch (SqlException error)
            {
                switch (error.Number)
                {
                    case 2627: MessageBox.Show("El DNI o el Telefono ya se encuentra registrado", "DNI Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Error); //Violacion de restriccion UNIQUE 
                        return;
                    case 8114: MessageBox.Show("Error de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); //ERROR de conversion de datos
                        return;
                       
                }
            }

            catch (FechaInvalidaException )
            {
                MessageBox.Show("Fecha no valida");
                return;
            }
            if (idUsuario != 0)
            {
                mapper.AsignarRolAUsuario(this.idUsuario, "Chofer");

            }

            if (creadoDesdeRegistrarUsuario)
            {
                this.Hide();
                new Login.LoginForm().ShowDialog();
                this.Close();
            }
            else
            {
                VolverAlMenu();
            }
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
                VolverAlMenu();
            }
        }

        private void VolverAlMenu()
        {
            this.Hide();
            new MenuChofer().ShowDialog();
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