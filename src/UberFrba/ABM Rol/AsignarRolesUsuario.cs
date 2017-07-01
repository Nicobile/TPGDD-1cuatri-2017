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
            MarcarFuncionalidades();
        }
        
        

         private void MarcarFuncionalidades()
         {
             int idUsuario = Convert.ToInt32(mapper.SelectFromWhere("usuario_id", "Usuario", "usuario_name", comboBox_Usuarios.Text));
             IList<SqlParameter> parametros = new List<SqlParameter>();
             SqlDataAdapter adapter = new SqlDataAdapter();
             List<int> funcionalidadesAMarcar = new List<int>();
             DesmarcarFuncionalidades();

             foreach (DataRowView funcionalidad in this.checkedListBoxFuncionalidades.Items)
             {
                 parametros.Clear();
                 parametros.Add(new SqlParameter("@funcionalidad", funcionalidad.Row["rol_nombre"] as String));

                 if (verificarSiLaTiene(funcionalidad.Row["rol_nombre"] as String,idUsuario))
                 {
                     int i = checkedListBoxFuncionalidades.Items.IndexOf(funcionalidad);
                     funcionalidadesAMarcar.Add(i);

                 }
             }

             foreach (int index in funcionalidadesAMarcar)
             {
                 checkedListBoxFuncionalidades.SetItemChecked(index, true);
             }
         }



         private void DesmarcarFuncionalidades()
         {
             for (int i = 0; i < checkedListBoxFuncionalidades.Items.Count; i++)
             {
                 checkedListBoxFuncionalidades.SetItemChecked(i, false);
             }
         }



         private bool verificarSiLaTiene(String funcionalidad,int IDUsuario)
         {
             IList<SqlParameter> parametros = new List<SqlParameter>();
             parametros.Clear();
             parametros.Add(new SqlParameter("@idUsuario", IDUsuario));
             parametros.Add(new SqlParameter("@funcionalidad", funcionalidad));

             String queryCantidadRolXFuncionalidad = "SELECT COUNT(*) from PUSH_IT_TO_THE_LIMIT.rol r join PUSH_IT_TO_THE_LIMIT.RolporUsuario p on(r.rol_id=p.rol_id) join PUSH_IT_TO_THE_LIMIT.Usuario u ON(p.usuario_id = u.usuario_id) where u.usuario_id=@idUsuario and r.rol_nombre=@funcionalidad";
             int tieneLaFuncionalidad = (int)QueryBuilder.Instance.build(queryCantidadRolXFuncionalidad, parametros).ExecuteScalar();

             if (tieneLaFuncionalidad == 1)
             {
                 return true;
             }
             else
             {
                 return false;
             }
         }

        
    }
}
