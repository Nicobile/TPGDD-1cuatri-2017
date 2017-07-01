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

namespace UberFrba.Login
{
    public partial class ElegirRol : Form
    {
        private SqlCommand command { get; set; }
        private IList<SqlParameter> parametros = new List<SqlParameter>();
        private DBMapper mapper = new DBMapper();
        private int IDUsuario;


        
        public Object SelectedItem { get; set; }

        public ElegirRol(int IdUsuario)
        {
            InitializeComponent();
            this.IDUsuario = IdUsuario;

            
        }

        private void ElegirRol_Load(object sender, EventArgs e)
        {
            CargarRoles();
        }

        private void CargarRoles()
        {
            DataTable rolesUsuario = mapper.obtenerRolesDeUnUsuario(IDUsuario);

            foreach (DataRow fila in rolesUsuario.Rows)
            {
                string nombre_rol = fila["rol_nombre"].ToString();
                comboBoxRol.Items.Add(nombre_rol);
            }
        }

        private void botonAceptar_Click(object sender, EventArgs e)
        {
            if (comboBoxRol.Text == "")
            {
                MessageBox.Show("Debe ingresar un rol para poder continuar", "Seleccionar Rol", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            else
            {
                String rolElegido = comboBoxRol.Text;

                UsuarioSesion.Usuario.rol = rolElegido;

                this.Hide();
                new MenuPrincipal().ShowDialog();
                this.Close();
            }
        }

    }
}