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
    public partial class CambiarContrasena : Form
    {
       
        public CambiarContrasena()
        {
            InitializeComponent();
        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            if (textBoxContraseña.Text == "")
            {
                MessageBox.Show("Debe ingresar una nueva contraseña");
                return;
            }

            if (textBoxRepetirContraseña.Text == "")
            {
                MessageBox.Show("Debe ingresar nuevamenta la contraseña");
                return;
            }
            if (textBoxContraseña.Text.Length < 8)
            {
                MessageBox.Show("La contraseña debe tener por lo menos 8 caracteres");
                return;
            }

            if (textBoxContraseña.Text != textBoxRepetirContraseña.Text)
            {
                MessageBox.Show("La contraseña no coincide, ingrese nuevamente");
                textBoxContraseña.Clear();
                textBoxRepetirContraseña.Clear();
                return;
            }
            

            // Actualiza contraseña
            IList<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@username", UsuarioSesion.Usuario.nombre));
            parametros.Add(new SqlParameter("@pass", HashSha256.getHash(textBoxContraseña.Text)));
            String nuevaPass = "UPDATE PUSH_IT_TO_THE_LIMIT.Usuario SET usuario_password = @pass WHERE usuario_name = @username";
            QueryBuilder.Instance.build(nuevaPass, parametros).ExecuteNonQuery();

            // Asigna el rol
            parametros.Clear();
            parametros.Add(new SqlParameter("@username", UsuarioSesion.Usuario.nombre));

            String consultaRoles = "SELECT COUNT(rol_id) from PUSH_IT_TO_THE_LIMIT.RolporUsuario WHERE (SELECT usuario_id FROM PUSH_IT_TO_THE_LIMIT.Usuario WHERE usuario_name = @username) = usuario_id";
            int cantidadDeRoles = (int)QueryBuilder.Instance.build(consultaRoles, parametros).ExecuteScalar();

            if (cantidadDeRoles > 1)
            {
                this.Hide();
                new ElegirRol().ShowDialog();
                this.Close();
            }
            else
            {
                parametros.Clear();
                parametros.Add(new SqlParameter("@username", UsuarioSesion.Usuario.nombre));
                String rolDeUsuario = "SELECT r.rol_nombre FROM PUSH_IT_TO_THE_LIMIT.Rol r, PUSH_IT_TO_THE_LIMIT.RolporUsuario ru, PUSH_IT_TO_THE_LIMIT.Usuario u WHERE r.rol_id = ru.rol_id and ru.usuario_id = u.usuario_id and u.usuario_name = @username";
                String rolUser = (String)QueryBuilder.Instance.build(rolDeUsuario, parametros).ExecuteScalar();

                UsuarioSesion.Usuario.rol = rolUser;

                this.Hide();
                new MenuPrincipal().ShowDialog();
                this.Close();
            }

        }

        private void CambiarContrasena_Load(object sender, EventArgs e)
        {

        }


    }
}