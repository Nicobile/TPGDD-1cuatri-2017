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
using UberFrba.ABM_Rol;
using UberFrba.DataProvider;

namespace UberFrba.Abm_Rol
{
    public partial class AsignarRolesUsuario : Form
    {

        private DBMapper mapper = new DBMapper();
        IList<SqlParameter> parametros = new List<SqlParameter>();
        int IDUSUARIO;

        public AsignarRolesUsuario()
        {
            InitializeComponent();
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            this.volverAlMenuTurno();
        }

        private void AsignarRolesUsuario_Load(object sender, EventArgs e)
        {
            CargarComboBoxUsuarios();
            CargarRoles();
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
        private void CargarRoles()
        {
            DataTable rolesHabilitados = mapper.obtenerRolesHabilitados();
            checkedListBoxRoles.DataSource = rolesHabilitados.DefaultView;
            checkedListBoxRoles.ValueMember = "rol_nombre";
        }



        private void comboBox_Usuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.IDUSUARIO = Convert.ToInt32(mapper.SelectFromWhere("usuario_id", "Usuario", "usuario_name", comboBox_Usuarios.Text));
            MarcarRoles();

        }
        
        

         private void MarcarRoles()
         {
             parametros = new List<SqlParameter>();
             SqlDataAdapter adapter = new SqlDataAdapter();
             List<int> rolesAMarcar = new List<int>();
             DesmarcarRoles();

             foreach (DataRowView rol in this.checkedListBoxRoles.Items)
             {
                 parametros.Clear();
                 parametros.Add(new SqlParameter("@rol", rol.Row["rol_nombre"] as String));

                 if (verificarSiLaTiene(rol.Row["rol_nombre"] as String,IDUSUARIO))
                 {
                     int i = checkedListBoxRoles.Items.IndexOf(rol);
                     rolesAMarcar.Add(i);

                 }
             }

             foreach (int index in rolesAMarcar)
             {
                 checkedListBoxRoles.SetItemChecked(index, true);
             }
         }



         private void DesmarcarRoles()
         {
             for (int i = 0; i < checkedListBoxRoles.Items.Count; i++)
             {
                 checkedListBoxRoles.SetItemChecked(i, false);
             }
         }



         private bool verificarSiLaTiene(String rol,int IDUsuario)
         {
             parametros = new List<SqlParameter>();
             parametros.Clear();
             parametros.Add(new SqlParameter("@idUsuario", IDUsuario));
             parametros.Add(new SqlParameter("@rol", rol));

             String queryCantidadRolXUsuario = "SELECT COUNT(*) from PUSH_IT_TO_THE_LIMIT.rol r join PUSH_IT_TO_THE_LIMIT.RolporUsuario p on(r.rol_id=p.rol_id) join PUSH_IT_TO_THE_LIMIT.Usuario u ON(p.usuario_id = u.usuario_id) where u.usuario_id=@idUsuario and r.rol_nombre=@rol";
             int tieneElRol = (int)QueryBuilder.Instance.build(queryCantidadRolXUsuario, parametros).ExecuteScalar();

             if (tieneElRol == 1)
             {
                 return true;
             }
             else
             {
                 return false;
             }
         }

         private void botonGuardar_Click(object sender, EventArgs e)
         {
             if (comboBox_Usuarios.Text == "")
             {
                 MessageBox.Show("Falta selecionar el campo usuario", "Error al agregar roles", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }
             else
             {
                 AgregarRoles();
                 QuitarRoles();
                 MessageBox.Show("Roles asignados correctamente al usuario con Username  : " + comboBox_Usuarios.Text, "Roles agregados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 this.volverAlMenuTurno();
             }
         }

         private void AgregarRoles()
         {

             foreach (DataRowView rol in this.checkedListBoxRoles.CheckedItems)
             {
                 if (verificarSiLaTiene(rol.Row["rol_nombre"] as String,IDUSUARIO))
                 {

                 }
                 else
                 {
                     parametros.Clear();
                     parametros.Add(new SqlParameter("@idUsuario",this.IDUSUARIO));
                     parametros.Add(new SqlParameter("@rol", rol.Row["rol_nombre"] as String));

                     String queryRolXUsuario = "INSERT INTO PUSH_IT_TO_THE_LIMIT.RolporUsuario(usuario_id, rol_id) VALUES (@idUsuario,(SELECT r.rol_id FROM PUSH_IT_TO_THE_LIMIT.Rol r WHERE r.rol_nombre=@rol))";

                     QueryBuilder.Instance.build(queryRolXUsuario, parametros).ExecuteNonQuery();
                 }
             }
         }
         private void QuitarRoles()
         {

             foreach (DataRowView rol in this.checkedListBoxRoles.Items)
             {
                 int index = checkedListBoxRoles.Items.IndexOf(rol);
                 String estado = this.checkedListBoxRoles.GetItemCheckState(index).ToString();

                 if (estado == "Unchecked")
                 {
                     parametros.Clear();
                     parametros.Add(new SqlParameter("@idUsuario", this.IDUSUARIO));
                     parametros.Add(new SqlParameter("@rol", rol.Row["rol_nombre"] as String));

                     String queryBorrarRolXUsuario = "DELETE PUSH_IT_TO_THE_LIMIT.RolporUsuario WHERE rol_id = (SELECT r.rol_id FROM PUSH_IT_TO_THE_LIMIT.Rol r WHERE r.rol_nombre = @rol) AND usuario_id =@idUsuario";

                     QueryBuilder.Instance.build(queryBorrarRolXUsuario, parametros).ExecuteNonQuery();
                 }
             }
         }




         public void volverAlMenuTurno() {
             
             this.Hide();
             new RolForm().ShowDialog();
             this.Close();
        }



















        
    }
}
