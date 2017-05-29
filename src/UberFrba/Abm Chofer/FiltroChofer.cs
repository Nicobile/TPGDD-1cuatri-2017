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
    public partial class FiltroEmpresa : Form
    {
        private DBMapper mapper = new DBMapper();

        public FiltroEmpresa()
        {
            InitializeComponent();
        }

        private void FiltroEmpresa_Load(object sender, EventArgs e)
        {
            CargarEmpresas();
            OcultarColumnasQueNoDebenVerse();
        }

        private void OcultarColumnasQueNoDebenVerse()
        {
            dataGridView_Empresa.Columns["emp_id"].Visible = false;
        }

        private void CargarEmpresas()
        {
            dataGridView_Empresa.DataSource = mapper.SelectEmpresasParaFiltro();
            CargarColumnaModificacion();
            CargarColumnaEliminar();
        }

        private void CargarColumnaModificacion()
        {
            if (dataGridView_Empresa.Columns.Contains("Modificar"))
                dataGridView_Empresa.Columns.Remove("Modificar");
            DataGridViewButtonColumn botonColumnaModificar = new DataGridViewButtonColumn();
            botonColumnaModificar.Text = "Modificar";
            botonColumnaModificar.Name = "Modificar";
            botonColumnaModificar.UseColumnTextForButtonValue = true;
            dataGridView_Empresa.Columns.Add(botonColumnaModificar);
          
        }
        
        private void CargarColumnaEliminar()
        {
            if (dataGridView_Empresa.Columns.Contains("Eliminar"))
                dataGridView_Empresa.Columns.Remove("Eliminar");
            DataGridViewButtonColumn botonColumnaEliminar = new DataGridViewButtonColumn();
            botonColumnaEliminar.Text = "Eliminar";
            botonColumnaEliminar.Name = "Eliminar";
            botonColumnaEliminar.UseColumnTextForButtonValue = true;
            dataGridView_Empresa.Columns.Add(botonColumnaEliminar);
        }

        private void button_Buscar_Click(object sender, EventArgs e)
        {
            String filtro = CalcularFiltro();
            dataGridView_Empresa.DataSource = mapper.SelectEmpresasParaFiltroConFiltro(filtro);
        }

        private String CalcularFiltro()
        {
            String filtro = "";
            if (textBox_RazonSocial.Text != "") filtro += "AND " + "emp.emp_razon_social LIKE '" + textBox_RazonSocial.Text + "%'";
            if (textBox_Cuit.Text != "") filtro += "AND " + "emp.emp_cuit LIKE '" + textBox_Cuit.Text + "%'";
            if (textBox_Mail.Text != "") filtro += "AND " + "cont.cont_mail LIKE '" + textBox_Mail.Text + "%'";
            return filtro;
        }

        private void button_Limpiar_Click(object sender, EventArgs e)
        {
            textBox_RazonSocial.Text = "";
            textBox_Cuit.Text = "";
            textBox_Mail.Text = "";
            CargarEmpresas();
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
            if (e.ColumnIndex == dataGridView_Empresa.Columns["Modificar"].Index && e.RowIndex >= 0)
            {
                String idEmpresaAModificar = dataGridView_Empresa.Rows[e.RowIndex].Cells["emp_id"].Value.ToString();
                new EditarChofer(idEmpresaAModificar).ShowDialog();
                CargarEmpresas();
                return;
            }
            if (e.ColumnIndex == dataGridView_Empresa.Columns["Eliminar"].Index && e.RowIndex >= 0)
            {
                String idEmpresaAEliminar = dataGridView_Empresa.Rows[e.RowIndex].Cells["emp_id"].Value.ToString();
                Boolean resultado = mapper.EliminarEmpresa(Convert.ToInt32(idEmpresaAEliminar), "Empresas");
                if (resultado) MessageBox.Show("Se elimino correctamente");
                CargarEmpresas();
                return;
            }
        }
    }
}