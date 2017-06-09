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
                MessageBox.Show("Debe ingresar un usuario");
                return;
            }

            if (this.textBoxContaseña.Text == "")
            {
                MessageBox.Show("Debe ingresar una contraseña");
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
                MessageBox.Show("Bienvenido " + reader["usuario_name"] + "!");

                UsuarioSesion.Usuario.nombre = (String)reader["usuario_name"];
                UsuarioSesion.Usuario.id = (Int32)reader["usuario_id"];

                // Usuario logueado correctamente (intentos fallidos = 0)
                parametros.Clear();
                parametros.Add(new SqlParameter("@username", usuario));
                String clearIntentosFallidos = "UPDATE PUSH_IT_TO_THE_LIMIT.Usuario SET usuario_intentos = 0 WHERE usuario_name = @username";
                QueryBuilder.Instance.build(clearIntentosFallidos, parametros).ExecuteNonQuery();

                // Se fija si es el primer inicio de sesion del usuario
                parametros.Clear();
                parametros.Add(new SqlParameter("@username", usuario));
                String sesion = "SELECT usuario_password FROM PUSH_IT_TO_THE_LIMIT.Usuario WHERE usuario_name = @username"; 
                String primerInicio = (String)QueryBuilder.Instance.build(sesion, parametros).ExecuteScalar();
                //El primer inicio la contraseña es fija (OK)
                if (primerInicio == "565339bc4d33d72817b583024112eb7f5cdf3e5eef0252d6ec1b9c9a94e12bb3") //  QUEDA PENDIENTE PONER ACA LA CONTRASEÑA QUE VIENE POR DEFECTO EN LA BASE!!!!!!!!!!!
                {
                    this.Hide();
                    //new CambiarContrasena().ShowDialog();
                    this.Close();
                }

                parametros.Clear();
                parametros.Add(new SqlParameter("@username", usuario));

                String consultaRoles = "SELECT COUNT(rol_id) FROM PUSH_IT_TO_THE_LIMIT.RolporUsuario WHERE (SELECT usuario_id FROM PUSH_IT_TO_THE_LIMIT.Usuario WHERE usuario_name = 'admin') = usuario_id";
                int cantidadDeRoles = (int)QueryBuilder.Instance.build(consultaRoles, parametros).ExecuteScalar();

                if(cantidadDeRoles > 1)
                {
                    this.Hide();
                    new ElegirRol().ShowDialog();
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
                  
                    // Para testear si elige bien el rol: MessageBox.Show("Rol: " + UsuarioSesion.Usuario.rol);

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
                    MessageBox.Show("Contraseña incorrecta." + '\n' + '\n' + "La contraseña distingue mayusculas y minusculas." + '\n' + '\n' + "Fallidos del usuario: " + intentosFallidos);
                }
                else 
                {
                    MessageBox.Show("El usuario no existe");
                }
       
                
            }
        }

        private void textBoxContaseña_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void botonRegistrarse_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Registro_de_Usuario.RegistrarUsuario().ShowDialog();
            this.Close();
        }
    }
}