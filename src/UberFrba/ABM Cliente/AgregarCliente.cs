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
using UberFrba.Utils;
using UberFrba.DataProvider;
using UberFrba.Abm_Cliente;
using System.Configuration;
namespace UberFrba.ABM_Cliente
{

    public partial class AgregarCliente : Form
    {

        private IList<SqlParameter> parametros = new List<SqlParameter>();
        private String username;
        private String contrasena;
        private Mapper mapper = new Mapper();
        private int idUsuario;
        private int idCliente;
        private Boolean creadoDesdeRegistrarUsuario;

        public AgregarCliente(String username, String contrasena,Boolean creadoDesdeRegistrar)
        {
            InitializeComponent();
            DateTime FECHA_ACTUAL = DateTime.Parse(ConfigurationManager.AppSettings["Fecha"]);
            this.monthCalendar_FechaDeNacimiento.MaxDate = FECHA_ACTUAL;
            this.username = username;
            this.contrasena = contrasena;
            this.creadoDesdeRegistrarUsuario = creadoDesdeRegistrar;
            this.idUsuario = 0;
        }

        private void AgregarCliente_Load(object sender, EventArgs e)
        {
        }


        private void button_Guardar_Click(object sender, EventArgs e)
        {
            // Guarda en variables todos los campos de entrada
     
            String nombre = textBox_Nombre.Text;
            String apellido = textBox_Apellido.Text;
            String numeroDeDocumento = textBox_DNI.Text;
            DateTime fechaDeNacimiento;
            DateTime.TryParse(textBox_FechaDeNacimiento.Text, out fechaDeNacimiento);
            String mail = textBox_Mail.Text;
            String telefono = textBox_Telefono.Text;
            String direccion = textBox_Direccion.Text;
            String codigoPostal = textBox_CodigoPostal.Text;

            
            // Crear cliente
            try
            {
                Clientes cliente = new Clientes();
                Usuarios usuario = new Usuarios();     
           
                
                cliente.SetNombre(nombre);
                cliente.SetApellido(apellido);
                cliente.SetDNI(numeroDeDocumento);

                cliente.SetFechaDeNacimiento(fechaDeNacimiento);
                cliente.SetMail(mail);
                cliente.SetTelefono(telefono);
                cliente.SetDireccion(direccion);
                cliente.SetCodigoPostal(codigoPostal);
                cliente.SetIdUsuario(idUsuario);
                cliente.SetActivo(true);
                if (username != "" && contrasena != "")
                {
                    idUsuario = mapper.CrearUsuarioConValores(username, contrasena);
                }
                else
                {
                    idUsuario = mapper.CrearUsuarioConValores(numeroDeDocumento, numeroDeDocumento); 
                }
                
                cliente.SetIdUsuario(idUsuario);
                idCliente = mapper.CrearCliente(cliente);
                if (idCliente > 0) 
                { 
                    MessageBox.Show("Se agrego el cliente correctamente"); 
                }
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
            catch (ClienteYaExisteException )
            {
                MessageBox.Show("El documento ya existe");
                return;
            }
            catch (TelefonoYaExisteException )
            {
                MessageBox.Show("El telefono ya existe");
                return;
            }
            catch (FechaInvalidaException )
            {
                MessageBox.Show("Fecha no valida");
                return;
            }
            catch (SqlException error)
            {
                switch (error.Number)
                {
                    case 2627: MessageBox.Show("El DNI o el Telefono ya se encuentra registrado", "DNI Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Error); //Violacion de restriccion UNIQUE 
                        return;
                  
                    case 8114: MessageBox.Show("Error de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);  //ERROR de conversion de datos
                        return;
                }
            }


            if (idUsuario == 0)
            {
                idUsuario = CrearUsuario();
                Boolean seCreoBien = mapper.AsignarUsuarioACliente(idCliente, idUsuario);
                if (seCreoBien) MessageBox.Show("Se creo el usuario correctamente");
            }

     


            if (idUsuario != 0)
            {
                mapper.AsignarRolAUsuario(this.idUsuario, "Cliente");

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
            if (username == "clienteCreadoPorAdmin") 
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
            textBox_Apellido.Text = "";
            textBox_DNI.Text = "";
            textBox_FechaDeNacimiento.Text = "";
            textBox_Mail.Text = "";
            textBox_Direccion.Text = "";
            textBox_Telefono.Text = "";
            textBox_CodigoPostal.Text = "";
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
            new MenuCliente().ShowDialog();
            this.Close();
        }

        private void button_FechaDeNacimiento_Click(object sender, EventArgs e)
        {
            monthCalendar_FechaDeNacimiento.Visible = true;
        }

        private void monthCalendar_FechaDeNacimiento_DateSelected(object sender, System.Windows.Forms.DateRangeEventArgs e)
        {
            textBox_FechaDeNacimiento.Text = e.Start.ToShortDateString();
            monthCalendar_FechaDeNacimiento.Visible = false;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}