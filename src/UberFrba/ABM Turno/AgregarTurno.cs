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
            String valorKilometro = textBox_ValorKilometro.Text;
            String PrecioBase = textBox_PrecioBase.Text;
            Boolean Habilitado = checkBox_Habilitado.Checked;


            // Crea Chofer
            try
            {
                Turnos turno = new Turnos();

                turno.SetHoraInicio(HoraInicio);
                turno.SetHoraFin(HoraFin);
                turno.SetDescripcion(Descripcion);
                turno.SetValorKilometro(valorKilometro);
                turno.SetPrecioBaseTurno(PrecioBase);
                turno.SetActivo(Habilitado);

                idTurno = mapper.Crear(turno);
                if (idTurno > 0) MessageBox.Show("Turno agregado correctamente");
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
 

            // Si al turno lo crea el admin, crea un nuevo usuario predeterminado.
   /*         if (idUsuario == 0)
            {
                idUsuario = CrearUsuario();
                Boolean resultado = mapper.AsignarUsuarioAChofer(idChofer, idUsuario);
                if (resultado) MessageBox.Show("El usuario fue creado correctamente");
            }

            mapper.AsignarRolAUsuario(this.idUsuario, "Chofer");
            */
            VolverAlMenuPrincipal();
        }
   /*     private int CrearUsuario()
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
    */

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
            textBox_HoraInicio.Text = "";
            textBox_HoraFin.Text = "";
            textBox_Descripcion.Text = "";
            textBox_ValorKilometro.Text = "";
            textBox_PrecioBase.Text = "";
            checkBox_Habilitado.Checked = false;

        }

        private void button_Cancelar_Click(object sender, EventArgs e)
        {

                VolverAlMenuPrincipal();

        }

        private void VolverAlMenuPrincipal()
        {
            this.Hide();
            new MenuPrincipal().ShowDialog();
            this.Close();
        }

    
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }
    }
}
