using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using UberFrba.DataProvider;

namespace UberFrba.Registro_de_Usuario
{
    public partial class RegistrarUsuario : Form
    {
        private SqlCommand command { get; set; }
        private IList<SqlParameter> parametros = new List<SqlParameter>();
        private Mapper mapper = new Mapper();

        public Object SelectedItem { get; set; }

        public RegistrarUsuario()
        {
            InitializeComponent();
        }

        private void RegistrarUsuario_Load(object sender, EventArgs e)
        {
            CargarRoles();
        }

        private void CargarRoles()
        {
            DataSet roles = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            parametros = new List<SqlParameter>();
            command = ConstructorQuery.Instance.build("SELECT DISTINCT rol_nombre FROM PUSH_IT_TO_THE_LIMIT.Rol WHERE rol_estado = 1 AND rol_nombre != 'Administrador'", parametros);
            adapter.SelectCommand = command;
            adapter.Fill(roles, "Rol");
            comboBoxRol.DataSource = roles.Tables[0].DefaultView;
            comboBoxRol.ValueMember = "rol_nombre";
            comboBoxRol.SelectedIndex = -1;
        }

        private void botonSiguiente_Click(object sender, EventArgs e)
        {

            String rolElegido = comboBoxRol.Text;
            String usuario = textBoxUsuario.Text;
            String contraseña = textBoxPass.Text;
            String repetirContraseña = textBoxPass2.Text;

            if (usuario == "")
            {
                MessageBox.Show("El campo Usuario es obligatorio");
                return;
            }

            if (contraseña == "")
            {
                MessageBox.Show("El campo Contraseña es obligatorio");
                return;
            }
            if (repetirContraseña == "")
            {
                MessageBox.Show("El campo Repetir contraseña es obligatorio");
                return;
            }

            if (rolElegido == "")
            {
                MessageBox.Show("El rol es obligatorio");
                return;
            }


            if (textBoxPass.Text != textBoxPass2.Text)
            {
                MessageBox.Show("La contraseña no coincide");
                return;
            }

            parametros.Clear();
            parametros.Add(new SqlParameter("@username", usuario));

            // Buscamos si el username ya se encuentra registrado
            String queryUsuario = "SELECT usuario_id FROM PUSH_IT_TO_THE_LIMIT.Usuario WHERE usuario_name= @username";

            SqlDataReader reader = ConstructorQuery.Instance.build(queryUsuario, parametros).ExecuteReader();

            if (reader.Read())
            {
                MessageBox.Show("El usuario ya existe","Error al Registrar",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            if (rolElegido != "Administrador" )
            {
                this.Hide();
                
               UsuarioSesion.Usuario.nombre = usuario;

                String idUsuario = "SELECT TOP 1 usuario_id"
                                + " FROM PUSH_IT_TO_THE_LIMIT.Usuario"
                                + " ORDER BY usuario_id DESC";

                // Limpio parametros
                parametros.Clear();

                int id = (int)ConstructorQuery.Instance.build(idUsuario, parametros).ExecuteScalar();

                UsuarioSesion.Usuario.id = id;

                if (rolElegido == "Cliente")
                {
                    UsuarioSesion.Usuario.rol = "Cliente";
                    new ABM_Cliente.AgregarCliente(usuario, contraseña,true).ShowDialog();
                }
                else if (rolElegido == "Chofer")
                {
                    UsuarioSesion.Usuario.rol = "Chofer";

                    new ABM_Chofer.AgregarChofer(usuario, contraseña,true).ShowDialog();
                }

            }
           
            else
            {
                Int32 idUsuario = mapper.CrearUsuarioConValores(usuario, contraseña);
                mapper.AsignarRolAUsuario(idUsuario, rolElegido);
                UsuarioSesion.Usuario.rol = rolElegido;
                UsuarioSesion.Usuario.nombre = usuario;
                UsuarioSesion.Usuario.id = idUsuario;
                this.Hide();
                new MenuPrincipal().ShowDialog();
            }

            this.Close();
            

        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Login.LoginForm().ShowDialog();
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

       
    }
}