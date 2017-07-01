using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using UberFrba.Utils;
using UberFrba.DataProvider;

namespace UberFrba.Login
{
    public partial class LoginForm : Form
    {

        private DBMapper mapper = new DBMapper();

        public LoginForm()
        {
            InitializeComponent();
        }


        private void LoginForm_Load(object sender, EventArgs e)
        {
            
        }

        private void botonIngresar_Click(object sender, EventArgs e)
        {
            //Validamos que ingrese usuario y contraseña
            if (this.textBoxUsuario.Text == "")
            {
                MessageBox.Show("Debe ingresar un usuario","Error en el login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (this.textBoxContaseña.Text == "")
            {
                MessageBox.Show("Debe ingresar una contraseña", "Error en el login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            // Nos fijamos si el usuario y contraseña existen y esta habilitado
            String query = "SELECT * FROM PUSH_IT_TO_THE_LIMIT.Usuario WHERE usuario_name = @username AND usuario_password = @password AND usuario_habilitado = 1";

            String usuario = this.textBoxUsuario.Text;
            // valida contraseña encriptada
            String contraseña = HashSha256.getHash(this.textBoxContaseña.Text);
            IList<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@username", usuario));
            parametros.Add(new SqlParameter("@password", contraseña));

            SqlDataReader reader = QueryHelper.Instance.exec(query, parametros);

            //Chequea el ingreso
            if (QueryHelper.Instance.readFrom(reader))
            {
                 MessageBox.Show("Bienvenido " + reader["usuario_name"] + "!", "Bienvenido", MessageBoxButtons.OK, MessageBoxIcon.Information);

                UsuarioSesion.Usuario.nombre = (String)reader["usuario_name"];
                UsuarioSesion.Usuario.id = (Int32)reader["usuario_id"];

                // Usuario logueado correctamente (intentos fallidos = 0)
                parametros.Clear();
                parametros.Add(new SqlParameter("@username", usuario));
                String clearIntentosFallidos = "UPDATE PUSH_IT_TO_THE_LIMIT.Usuario SET usuario_intentos = 0 WHERE usuario_name = @username";
                QueryBuilder.Instance.build(clearIntentosFallidos, parametros).ExecuteNonQuery();
                
                parametros.Clear();
                parametros.Add(new SqlParameter("@username", usuario));

                String consultaRoles = "SELECT COUNT(rol_id) FROM PUSH_IT_TO_THE_LIMIT.RolporUsuario WHERE (SELECT usuario_id FROM PUSH_IT_TO_THE_LIMIT.Usuario WHERE usuario_name =@username) = usuario_id";
                int cantidadDeRoles = (int)QueryBuilder.Instance.build(consultaRoles, parametros).ExecuteScalar();

               int idUsuario=Convert.ToInt32(mapper.SelectFromWhere("usuario_id", "Usuario", "usuario_name", textBoxUsuario.Text));

                if(cantidadDeRoles > 1)
                {
                    this.Hide();
                    new ElegirRol(idUsuario).ShowDialog();
                    this.Close();
                }
                else
                {
                    parametros.Clear();
                    parametros.Add(new SqlParameter("@username", usuario));
                    String rolDeUsuario = "SELECT r.rol_nombre FROM PUSH_IT_TO_THE_LIMIT.Rol r, PUSH_IT_TO_THE_LIMIT.RolporUsuario ru, PUSH_IT_TO_THE_LIMIT.Usuario u WHERE r.rol_id = ru.rol_id AND ru.usuario_id = u.usuario_id AND u.usuario_name = @username";
                    String rolUser = (String)QueryBuilder.Instance.build(rolDeUsuario, parametros).ExecuteScalar();

                    UsuarioSesion.Usuario.rol = rolUser;
                    if(UsuarioSesion.Usuario.rol == null)
                    {
                        MessageBox.Show("No existen roles para iniciar sesion");
                        return;
                    }
                  

                    this.Hide();
                    new MenuPrincipal().ShowDialog();
                    this.Close();
                }

            }
            else
            {
                // Se fija si el usuario era correcto
                parametros.Clear();
                parametros.Add(new SqlParameter("@username", usuario));
                String buscaUsuario = "SELECT * FROM PUSH_IT_TO_THE_LIMIT.Usuario WHERE usuario_name = @username";
                SqlDataReader lector = QueryBuilder.Instance.build(buscaUsuario, parametros).ExecuteReader();

                if (lector.Read())
                {

                    // Se fija si el usuario esta inhabilitado
                    parametros.Clear();
                    parametros.Add(new SqlParameter("@username", usuario));
                    parametros.Add(new SqlParameter("@password", contraseña));
                    String estaDeshabilitado = "SELECT * FROM PUSH_IT_TO_THE_LIMIT.Usuario WHERE usuario_name = @username AND usuario_habilitado = 0";

                    SqlDataReader userDeshabilitado = QueryBuilder.Instance.build(estaDeshabilitado, parametros).ExecuteReader();

                    if (userDeshabilitado.Read())
                    {
                        MessageBox.Show("El usuario no esta habilitado");
                        return;
                    }

                    // Suma un fallido
                    parametros.Clear();
                    parametros.Add(new SqlParameter("@username", usuario));
                    String sumaFallido = "UPDATE PUSH_IT_TO_THE_LIMIT.Usuario SET usuario_intentos = usuario_intentos + 1 WHERE usuario_name = @username";
                    QueryBuilder.Instance.build(sumaFallido, parametros).ExecuteNonQuery();


                    // Si es el tercer fallido se deshabilita al usuario
                    parametros.Clear();
                    parametros.Add(new SqlParameter("@username", usuario));
                    String cantidadFallidos = "SELECT usuario_intentos FROM PUSH_IT_TO_THE_LIMIT.Usuario WHERE usuario_name = @username";
                    int intentosFallidos = Convert.ToInt32(QueryBuilder.Instance.build(cantidadFallidos, parametros).ExecuteScalar());

                    if (intentosFallidos == 3)
                    {
                        parametros.Clear();
                        parametros.Add(new SqlParameter("@username", usuario));
                        String deshabilitar = "UPDATE PUSH_IT_TO_THE_LIMIT.Usuario SET usuario_habilitado = 0 WHERE usuario_name = @username";
                        QueryBuilder.Instance.build(deshabilitar, parametros).ExecuteNonQuery();
                    }
                    MessageBox.Show("Contraseña incorrecta , Fallidos del usuario: " + intentosFallidos+"  (Al tercer intento sera bloqueado)");
                }
                else 
                {
                    MessageBox.Show("El usuario no existe","Error en el login",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
       
                
            }
        }

        private void botonRegistrarse_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Registro_de_Usuario.RegistrarUsuario().ShowDialog();
            this.Close();
        }
    }
}