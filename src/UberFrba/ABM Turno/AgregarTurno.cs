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
using UberFrba.Exceptions;
using UberFrba.DataProvider;

namespace UberFrba.ABM_Turno
{
    public partial class AgregarTurno : Form
    {

        private String username;
        private String contrasena;
        private DBMapper mapper = new DBMapper();
        private int idTurno;
        private int idUsuario;

        public AgregarTurno(String username, String contrasena)
        {
            InitializeComponent();
            this.username = username;
            this.contrasena = contrasena;
            this.idUsuario = 0;
        }

        private void button_Guardar_Click(object sender, EventArgs e)
        {
            // Guarda en variables todos los campos de entrada
            String HoraInicio = textBox_HoraInicio.Text;
            String HoraFin = textBox_HoraFin.Text;
            String Descripcion = textBox_Descripcion.Text;
            String PrecioBase = textBox_PrecioBase.Text;
            Boolean Habilitado = checkBox_Habilitado.Focused;
            String Mail = textBox_Mail.Text;
            DateTime fechaDeNacimiento;
            DateTime.TryParse(textBox_FechaDeNacimiento.Text, out fechaDeNacimiento);

            // Crea Chofer
            try
            {
                Turnos turno = new Turnos();

                chofer.SetNombre(HoraInicio);
                chofer.SetApellido(HoraFin);
                chofer.SetDNI(Descripcion);
                chofer.SetDireccion(PrecioBase);
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }
    }
}
