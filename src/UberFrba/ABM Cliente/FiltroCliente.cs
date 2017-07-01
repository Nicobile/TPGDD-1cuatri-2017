using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using UberFrba.Modelo;
using UberFrba.DataProvider;
using UberFrba.Abm_Cliente;

namespace UberFrba.ABM_Cliente
{
    public partial class FiltroCliente : Form
    {
        private Mapper mapper = new Mapper();

        public FiltroCliente()
        {
            InitializeComponent();
        }

        private void FiltroCliente_Load(object sender, EventArgs e)
        {
          //  CargarDocumento();
            CargarClientes();
            OcultarColumnasQueNoDebenVerse();
        }

        private void CargarDocumento()
        {          
           // comboBox_Dni.Items.Add("DNI - Documento Nacional de Identidad");
                
        }

        private void OcultarColumnasQueNoDebenVerse()
        {
            dataGridView_Cliente.Columns["cliente_id"].Visible = false;
        }

        private void CargarClientes()
        {
            dataGridView_Cliente.DataSource = mapper.SelectClientesParaFiltro();
            CargarColumnaModificacion();
            CargarColumnaEliminar();
        }

        private void CargarColumnaModificacion()
        {
            if (dataGridView_Cliente.Columns.Contains("Modificar"))
                dataGridView_Cliente.Columns.Remove("Modificar");
            DataGridViewButtonColumn botonColumnaModificar = new DataGridViewButtonColumn();
            botonColumnaModificar.Text = "Modificar";
            botonColumnaModificar.Name = "Modificar";
            botonColumnaModificar.UseColumnTextForButtonValue = true;
            dataGridView_Cliente.Columns.Add(botonColumnaModificar);
        }

        private void CargarColumnaEliminar()
        {
            if (dataGridView_Cliente.Columns.Contains("Eliminar"))
                dataGridView_Cliente.Columns.Remove("Eliminar");
            DataGridViewButtonColumn botonColumnaEliminar = new DataGridViewButtonColumn();
            botonColumnaEliminar.Text = "Eliminar";
            botonColumnaEliminar.Name = "Eliminar";
            botonColumnaEliminar.UseColumnTextForButtonValue = true;
            dataGridView_Cliente.Columns.Add(botonColumnaEliminar);
        }

        private void button_Buscar_Click(object sender, EventArgs e)
        {
            String filtro = CalcularFiltro();
            dataGridView_Cliente.DataSource = mapper.SelectClientesParaFiltroConFiltro(filtro);
        }

        private String CalcularFiltro()
        {
            String filtro = "";
            if (textBox_Nombre.Text != "") filtro += "AND " + "cli.cliente_nombre LIKE '" + textBox_Nombre.Text + "%'";
            if (textBox_Apellido.Text != "") filtro += "AND " + "cli.cliente_apellido LIKE '" + textBox_Apellido.Text + "%'";
            if (textBox_DNI.Text != "") filtro += "AND " + "cli.cliente_dni LIKE '" + textBox_DNI.Text + "%'";
            return filtro;
        }

        private void button_Limpiar_Click(object sender, EventArgs e)
        {
            textBox_Nombre.Text = "";
            textBox_Apellido.Text = "";
            textBox_DNI.Text = "";
            CargarClientes();
        }

        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MenuCliente().ShowDialog();
            this.Close();
        }

        private void dataGridView_Cliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Controla que la celda que se clickeo fue la de modificar
            if (e.ColumnIndex == dataGridView_Cliente.Columns["Modificar"].Index && e.RowIndex >= 0)
            {
                String idClienteAModificar = dataGridView_Cliente.Rows[e.RowIndex].Cells["cliente_id"].Value.ToString();
                new EditarCliente(idClienteAModificar).ShowDialog();
                CargarClientes();
                return;
            }
            if (e.ColumnIndex == dataGridView_Cliente.Columns["Eliminar"].Index && e.RowIndex >= 0)
            {
                String idClienteAEliminar = dataGridView_Cliente.Rows[e.RowIndex].Cells["cliente_id"].Value.ToString();
                Boolean resultado = mapper.EliminarCliente(Convert.ToInt32(idClienteAEliminar), "Cliente");
                dataGridView_Cliente.Rows[e.RowIndex].Cells["Habilitado"].Value = false;
                if (resultado) MessageBox.Show("Se elimino correctamente");

                CargarClientes();
                return;
            }
        }
    }
}