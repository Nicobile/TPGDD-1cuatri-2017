using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UberFrba.DataProvider;

namespace UberFrba.Abm_Rol
{
    public partial class AsignarRolesUsuario : Form
    {

        private DBMapper mapper = new DBMapper();


        public AsignarRolesUsuario()
        {
            InitializeComponent();
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {

        }

        private void AsignarRolesUsuario_Load(object sender, EventArgs e)
        {
            CargarComboBoxUsuarios();
            CargarFuncionalidades();
        }

        public void CargarComboBoxUsuarios()
        {

            DataTable usuarios = mapper.obtenerUsuariosHabilitados();

                foreach (DataRow fila in usuarios.Rows)
                {
                    string usuario = fila["usuario_name"].ToString();
                    comboBox_Usuarios.Items.Add(usuario);
                }

        }
        private void CargarFuncionalidades()
        {
            DataTable rolesHabilitados = mapper.obtenerRolesHabilitados();
            checkedListBoxFuncionalidades.DataSource = rolesHabilitados.DefaultView;
            checkedListBoxFuncionalidades.ValueMember = "rol_nombre";
        }

        

        private void comboBox_Usuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
                int idUsuario = Convert.ToInt32(mapper.SelectFromWhere("usuario_id", "Usuario", "usuario_name", comboBox_Usuarios.Text));
                List<SqlParameter> parametros = new List<SqlParameter>();
                parametros.Clear();
                parametros.Add(new SqlParameter("@idUsuario", idUsuario));
                SqlCommand command= QueryBuilder.Instance.build("select rol_nombre from PUSH_IT_TO_THE_LIMIT.rol r join PUSH_IT_TO_THE_LIMIT.RolporUsuario p on(r.rol_id=p.rol_id) join PUSH_IT_TO_THE_LIMIT.Usuario u ON(p.usuario_id = u.usuario_id) where u.usuario_id=@idUsuario AND r.rol_estado=1", parametros);        
              //  command.Parameters.AddWithValue("@idUsuario", idUsuario);
                int i = 0;
                while (i++<checkedListBoxFuncionalidades.Items.Count) {
                    checkedListBoxFuncionalidades.SetItemChecked(i-1, false);               
                }
                actualizarRoles(command);                       
        }
        
        // private void actualizarRoles (SqlCommand command) {                 
        //    SqlDataReader roles = command.ExecuteReader();
        //    while (roles.Read()) {
        //        string rol = (string)roles["rol_nombre"];
        //        int i = 0;
        //        bool encontrado=false;
        //        while (!encontrado) {
        //            if (checkedListBoxFuncionalidades.Va == rol) {
        //                checkedListBoxFuncionalidades.SetItemChecked(i, true);
        //                encontrado=true;
        //            }
        //            i++;
        //        }
        //    }
        //    roles.Close();
        //}

         private void actualizarRoles(SqlCommand command)
         {
             SqlDataReader roles = command.ExecuteReader();
             while (roles.Read())
             {
                 string rol = (string)roles["rol_nombre"];

                 for (int i = 0; i < checkedListBoxFuncionalidades.Items.Count; i++)
                 {


                     if (checkedListBoxFuncionalidades.Items[i].ToString() == rol)
                     {
                         checkedListBoxFuncionalidades.SetItemChecked(i, true);

                     }
                     else { checkedListBoxFuncionalidades.SetItemChecked(i, false); }


                 }
                 
             }
             roles.Close();
         }         
        
        
        

        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        //private void comboBox_Usuarios_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    int i = 0;
        //    while (i++ < checkedListBoxFuncionalidades.Items.Count)
        //    {
        //        checkedListBoxFuncionalidades.SetItemChecked(i - 1, false);               //Desactivo todos los roles
        //    }
        //    int idUsuario = Convert.ToInt32(mapper.SelectFromWhere("usuario_id", "Usuario", "usuario_name", comboBox_Usuarios.Text));
        //    DataTable rolesUsuario = mapper.obtenerRolesDeUnUsuario(idUsuario);
        //    actualizarRoles(rolesUsuario);                       //Activo los del usuario

        //}
        //private void actualizarRoles(DataTable rolesUser)
        //{
        //    CargarFuncionalidades();

        //    foreach (DataRow fila in rolesUser.Rows)
        //    {
        //        string rolNombre = fila["rol_nombre"].ToString();

        //        int i = 0;
        //        while ((checkedListBoxFuncionalidades.Items.Count) >= i)
        //        {
        //            bool encontrado = false;
        //            while (!encontrado)
        //            {
        //                String rolList = Convert.ToString(checkedListBoxFuncionalidades.Items[i]);
        //                // String chupala = convert.checkedListBoxFuncionalidades.SelectedItem;
        //                checkedListBoxFuncionalidades.DisplayMember = "NameAndScore";
        //                checkedListBoxFuncionalidades.ValueMember = "NameAndScore";
        //                //checkedListBoxFuncionalidades.DataSource = dSet.Tables[0];

        //                if (rolList == "Administrador")
        //                {

        //                    checkedListBoxFuncionalidades.SetItemChecked(i, true);
        //                    encontrado = true;
        //                }
        //                i++;
        //            }
        //        }

        //        lstNames.DisplayMember = "NameAndScore"; lstNames.ValueMember = "NameAndScore"; lstNames.DataSource = dSet.Tables[0];



        //    }

    //    }























        
    }
}
