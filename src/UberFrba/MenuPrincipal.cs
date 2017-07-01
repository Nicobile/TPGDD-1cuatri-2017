using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using UberFrba.DataProvider;
using UberFrba;

namespace UberFrba
{
    public partial class MenuPrincipal : Form
    {
        private SqlCommand command { get; set; }
        private Dictionary<String, Form> funcionalidades = new Dictionary<String, Form>();
     
        public MenuPrincipal()
        {
            InitializeComponent();

            funcionalidades.Add("ABM de Rol", new ABM_Rol.RolForm());
            funcionalidades.Add("ABM de Choferes", new ABM_Chofer.MenuChofer());
            funcionalidades.Add("ABM de Clientes", new Abm_Cliente.MenuCliente());
            funcionalidades.Add("ABM de Turnos", new ABM_Turno.MenuTurno());
            funcionalidades.Add("ABM de Automoviles", new Abm_Automovil.MenuAutomovil());
            funcionalidades.Add("Registro de Viajes", new Registro_Viajes.RegistrarViaje()); 
            funcionalidades.Add("Rendicion de Viajes", new Rendicion_Viajes.RendicionViaje());
            funcionalidades.Add("Facturacion de Clientes", new Facturacion.CrearFacturaCliente());
            funcionalidades.Add("Listado Estadistico", new Listado_Estadistico.ListadoEstadistico());
            funcionalidades.Add("Registro de Usuario", new Registro_de_Usuario.RegistrarUsuario());


        
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            DataSet actions = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();

            String funcionalidadesUsuario = "select f.funcionalidad_descripcion from PUSH_IT_TO_THE_LIMIT.ROL r, PUSH_IT_TO_THE_LIMIT.RolporFunciones fr, PUSH_IT_TO_THE_LIMIT.Funcionalidad f where r.rol_id = fr.rol_id and f.funcionalidad_id = fr.funcionalidad_id and r.rol_nombre = @rol";
            IList<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@rol", UsuarioSesion.Usuario.rol));
            command = ConstructorQuery.Instance.build(funcionalidadesUsuario, parametros);

            adapter.SelectCommand = command;
            adapter.Fill(actions, "Funcionalidad");
            comboBoxAccion.DataSource = actions.Tables[0].DefaultView;
            comboBoxAccion.ValueMember = "funcionalidad_descripcion";

        }

        private void botonAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                String accionElegida = comboBoxAccion.SelectedValue.ToString();
                this.Hide();
                funcionalidades[accionElegida].ShowDialog();
                this.Close();
            }
            catch (NullReferenceException ) { 
            
                MessageBox.Show("La opcion ingresada es incorrecta","Accion elegida Incorrecta",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

          
        }

        private void botonCerrarSesion_Click(object sender, EventArgs e)
        {
            // Relleno la sesion con datos inexistentes para que no queden datos cacheados de un usuario del sistema
            UsuarioSesion.Usuario.id = 0;
            UsuarioSesion.Usuario.nombre = null;
            UsuarioSesion.Usuario.rol = null;

            // Redirect al Login
            this.Hide();
            new Login.LoginForm().ShowDialog();
            this.Close();

        }

        
    }
}