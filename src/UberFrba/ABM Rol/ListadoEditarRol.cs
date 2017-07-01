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
    public partial class ListadoEditarRol : Form
    {
        private SqlCommand command { get; set; }
        private IList<SqlParameter> parametros = new List<SqlParameter>();
        
        public Object SelectedItem { get; set; }      

        public ListadoEditarRol()
        {
            InitializeComponent();
            CargarRoles();
        }

        private void ListadoEditarRol_Load(object sender, EventArgs e)
        {
             
        }

        private void comboBoxEstadoRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void CargarRoles()
        {
            DataSet roles = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            parametros = new List<SqlParameter>();            
            
            parametros.Clear();
           

            command = ConstructorQuery.Instance.build("SELECT rol_id 'ID' , rol_nombre 'Nombre Rol', rol_estado 'Habilitado' FROM PUSH_IT_TO_THE_LIMIT.Rol", parametros);
            adapter.SelectCommand = command;
            adapter.Fill(roles);
            dataGridViewResultadosBusqueda.DataSource = roles.Tables[0].DefaultView;
            AgregarBotonEditar();
        }

        private void botonBuscar_Click(object sender, EventArgs e)
        {
            if (textBox_NombreRol.Text != "")
            {
                DataSet roles = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter();
                parametros = new List<SqlParameter>();
                parametros.Clear();
                parametros.Add(new SqlParameter("@nombre_Rol", textBox_NombreRol.Text));
                command = ConstructorQuery.Instance.build("SELECT rol_id 'ID' , rol_nombre 'Nombre Rol', rol_estado 'Habilitado' FROM PUSH_IT_TO_THE_LIMIT.Rol WHERE rol_nombre=@nombre_rol ", parametros);
                adapter.SelectCommand = command;
                adapter.Fill(roles);
                dataGridViewResultadosBusqueda.DataSource = roles.Tables[0].DefaultView;
                AgregarBotonEditar();
            }
            else {

                CargarRoles();
            
            }











        }

        
        private void AgregarBotonEditar()
        {
            if (dataGridViewResultadosBusqueda.Columns.Contains("Editar"))
                dataGridViewResultadosBusqueda.Columns.Remove("Editar");
            
            DataGridViewButtonColumn buttons = new DataGridViewButtonColumn();
            {
                buttons.HeaderText = "Editar";
                buttons.Text = "Editar";
                buttons.Name = "Editar";
                buttons.UseColumnTextForButtonValue = true;
                buttons.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                buttons.FlatStyle = FlatStyle.Standard;
                buttons.CellTemplate.Style.BackColor = Color.Honeydew;                
            }

            dataGridViewResultadosBusqueda.Columns.Add(buttons);
            dataGridViewResultadosBusqueda.CellClick += new DataGridViewCellEventHandler(dataGridView1_CellClick);

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == dataGridViewResultadosBusqueda.Columns["Editar"].Index)
            {
                String nombreRolAEditar = dataGridViewResultadosBusqueda.Rows[e.RowIndex].Cells["Nombre Rol"].Value.ToString();
                this.Hide();
                new EditarRol(nombreRolAEditar).ShowDialog();
            }
            
        }

        private void botonCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            new RolForm().ShowDialog();
            this.Close();
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
            new RolForm().ShowDialog();
            this.Close();
        }

    }
}