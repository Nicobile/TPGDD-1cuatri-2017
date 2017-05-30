using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace UberFrba.ABM_Chofer
{
    public partial class FiltroChofer : Form
    {
        private DBMapper mapper = new DBMapper();

        public FiltroChofer()
        {
            InitializeComponent();
        }

        private void FiltroEmpresa_Load(object sender, EventArgs e)
        {
            CargarChoferes();
            OcultarColumnasQueNoDebenVerse();
        }

        private void OcultarColumnasQueNoDebenVerse()
        {
            dataGridView_Chofer.Columns["emp_id"].Visible = false;
        }

        private void CargarChoferes()
        {
            dataGridView_Chofer.DataSource = mapper.SelectChoferParaFiltro();
            CargarColumnaModificacion();
            CargarColumnaEliminar();
        }

        private void CargarColumnaModificacion()
        {
            if (dataGridView_Chofer.Columns.Contains("Modificar"))
                dataGridView_Chofer.Columns.Remove("Modificar");
            DataGridViewButtonColumn botonColumnaModificar = new DataGridViewButtonColumn();
            botonColumnaModificar.Text = "Modificar";
            botonColumnaModificar.Name = "Modificar";
            botonColumnaModificar.UseColumnTextForButtonValue = true;
            dataGridView_Chofer.Columns.Add(botonColumnaModificar);

        }

        private void CargarColumnaEliminar()
        {
            if (dataGridView_Chofer.Columns.Contains("Eliminar"))
                dataGridView_Chofer.Columns.Remove("Eliminar");
            DataGridViewButtonColumn botonColumnaEliminar = new DataGridViewButtonColumn();
            botonColumnaEliminar.Text = "Eliminar";
            botonColumnaEliminar.Name = "Eliminar";
            botonColumnaEliminar.UseColumnTextForButtonValue = true;
            dataGridView_Chofer.Columns.Add(botonColumnaEliminar);
        }

        private void button_Buscar_Click(object sender, EventArgs e)
        {
            String filtro = CalcularFiltro();
            dataGridView_Chofer.DataSource = mapper.SelectChoferesParaFiltroConFiltro(filtro);
        }

        private String CalcularFiltro()
        {
            String filtro = "";
            if (textBox_Nombre.Text != "") filtro += "AND " + "emp.emp_razon_social LIKE '" + textBox_Nombre.Text + "%'";
            if (textBox_Apellido.Text != "") filtro += "AND " + "emp.emp_cuit LIKE '" + textBox_Apellido.Text + "%'";
            if (textBox_DNI.Text != "") filtro += "AND " + "cont.cont_mail LIKE '" + textBox_DNI.Text + "%'";
            return filtro;
        }

        private void button_Limpiar_Click(object sender, EventArgs e)
        {
            textBox_Nombre.Text = "";
            textBox_Apellido.Text = "";
            textBox_DNI.Text = "";
            CargarChoferes();
        }

        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MenuPrincipal().ShowDialog();
            this.Close();
        }

        private void dataGridView_Empresa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Controla que la celda que se clickeo fue la de modificar
            if (e.ColumnIndex == dataGridView_Chofer.Columns["Modificar"].Index && e.RowIndex >= 0)
            {
                String idChoferAModificar = dataGridView_Chofer.Rows[e.RowIndex].Cells["chofer_id"].Value.ToString();
                new EditarChofer(idChoferAModificar).ShowDialog();
                CargarChoferes();
                return;
            }
            if (e.ColumnIndex == dataGridView_Chofer.Columns["Eliminar"].Index && e.RowIndex >= 0)
            {
                String idEmpresaAEliminar = dataGridView_Chofer.Rows[e.RowIndex].Cells["chofer_id"].Value.ToString();
                Boolean resultado = mapper.EliminarChofer(Convert.ToInt32(idEmpresaAEliminar), "Chofer");
                if (resultado) MessageBox.Show("Se elimino correctamente");
                CargarChoferes();
                return;
            }
        }
    }
}