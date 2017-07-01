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

namespace UberFrba.ABM_Rol
{

    public partial class BajaRol : Form
    {
        private SqlCommand command { get; set; }
        private IList<SqlParameter> parametros = new List<SqlParameter>();
        
        public Object SelectedItem { get; set; }        

        public BajaRol()
        {
            InitializeComponent();            
        }

        private void BajaForm_Load(object sender, EventArgs e)
        {
            CargarRoles();
        }

        private void CargarRoles()
        {
            DataSet roles = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            parametros = new List<SqlParameter>();
            command = ConstructorQuery.Instance.build("SELECT DISTINCT rol_nombre FROM PUSH_IT_TO_THE_LIMIT.Rol WHERE rol_estado = 1", parametros);
            adapter.SelectCommand = command;
            adapter.Fill(roles);
            comboBoxRol.DataSource = roles.Tables[0].DefaultView;
            comboBoxRol.ValueMember = "rol_nombre";
            comboBoxRol.SelectedIndex = -1;
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
            new RolForm().ShowDialog();
            this.Close();
        }

        private void botonDeshabilitar_Click(object sender, EventArgs e)
        {
            String rolElegido = this.comboBoxRol.Text;

            parametros.Clear();
            parametros.Add(new SqlParameter("@nombre", rolElegido));

            String sql = "UPDATE PUSH_IT_TO_THE_LIMIT.Rol SET rol_estado = 0 WHERE rol_nombre = @nombre";

            int filasAfectadas = 0;
                        
            filasAfectadas = ConstructorQuery.Instance.build(sql, parametros).ExecuteNonQuery();
            if (filasAfectadas != -1)
            {
                MessageBox.Show("El rol " + rolElegido + " fue deshabilitado");
            }
            else
            {
                MessageBox.Show("Ocurrio un error");
            }

            parametros.Clear();
            parametros.Add(new SqlParameter("@nombre", rolElegido));

            // Borramos el rol en los usuarios que lo tienen
            String queryBorrarRolUsuario = "DELETE PUSH_IT_TO_THE_LIMIT.RolporUsuario WHERE rol_id = (SELECT rol_id FROM PUSH_IT_TO_THE_LIMIT.Rol WHERE rol_nombre = @nombre AND rol_estado = 0)"; 

            filasAfectadas = ConstructorQuery.Instance.build(queryBorrarRolUsuario, parametros).ExecuteNonQuery();
            if (filasAfectadas != -1)
            {
                MessageBox.Show("Se elimino el rol " + rolElegido + " de " + filasAfectadas + " usuarios ya que fue deshabilitado");
            }
            else
            {
                MessageBox.Show("Ocurrio un error");
            }
            CargarRoles();
        }

        private void comboBoxRol_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void labelRol_Click(object sender, EventArgs e)
        {

        }
        
    }
}