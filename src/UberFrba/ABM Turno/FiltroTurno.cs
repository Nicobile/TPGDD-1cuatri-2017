using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UberFrba.ABM_Turno
{
    public partial class FiltroTurno : Form
    {
        private DBMapper mapper = new DBMapper();
        public FiltroTurno()
        {
            InitializeComponent();
        }

        private void FiltroTurno_Load(object sender, EventArgs e)
        {
            CargarTurnos();
        }

        private void CargarTurnos() {

            dataGridView_Turno.DataSource = mapper.SelectTurnoParaFiltro();
            CargarColumnaModificacion();
            CargarColumnaEliminar();

        }

        private void CargarColumnaModificacion()
        {
            if (dataGridView_Turno.Columns.Contains("Modificar"))
                dataGridView_Turno.Columns.Remove("Modificar");
            DataGridViewButtonColumn botonColumnaModificar = new DataGridViewButtonColumn();
            botonColumnaModificar.Text = "Modificar";
            botonColumnaModificar.Name = "Modificar";
            botonColumnaModificar.UseColumnTextForButtonValue = true;
            dataGridView_Turno.Columns.Add(botonColumnaModificar);

        }

        private void CargarColumnaEliminar()
        {
            if (dataGridView_Turno.Columns.Contains("Eliminar"))
                dataGridView_Turno.Columns.Remove("Eliminar");
            DataGridViewButtonColumn botonColumnaEliminar = new DataGridViewButtonColumn();
            botonColumnaEliminar.Text = "Eliminar";
            botonColumnaEliminar.Name = "Eliminar";
            botonColumnaEliminar.UseColumnTextForButtonValue = true;
            dataGridView_Turno.Columns.Add(botonColumnaEliminar);
        }

        private void button_Buscar_Click(object sender, EventArgs e)
        {
            String filtro = CalcularFiltro();
            dataGridView_Turno.DataSource = mapper.SelectTurnosParaFiltroConFiltro(filtro);
        }

        private String CalcularFiltro()
        {
            String filtro = "";
            if (textBox_DescripcionTurno.Text != "") filtro += "WHERE " + "t.turno_descripcion LIKE '" +"%"+ textBox_DescripcionTurno.Text + "%'";
 
            return filtro;
        }

        private void button_Limpiar_Click(object sender, EventArgs e)
        {
            textBox_DescripcionTurno.Text = "";
            CargarTurnos();
        }

        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MenuPrincipal().ShowDialog();
            this.Close();
        }

        private void dataGridView_Turno_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView_Chofer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Controla que la celda que se clickeo fue la de modificar
            if (e.ColumnIndex == dataGridView_Turno.Columns["Modificar"].Index && e.RowIndex >= 0)
            {
                //String idChoferAModificar = dataGridView_Chofer.Rows[e.RowIndex].Cells["chofer_id"].Value.ToString();
                //String idUsuarioChoferAModificar = dataGridView_Chofer.Rows[e.RowIndex].Cells["usuario_id"].Value.ToString();
                //new EditarChofer(idChoferAModificar, idUsuarioChoferAModificar).ShowDialog();
                //CargarChoferes();
                //return;
            }
            if (e.ColumnIndex == dataGridView_Turno.Columns["Eliminar"].Index && e.RowIndex >= 0)
            {
                //String idChoferAEliminar = dataGridView_Chofer.Rows[e.RowIndex].Cells["chofer_id"].Value.ToString();
                //Boolean resultado = mapper.EliminarChofer(Convert.ToInt32(idChoferAEliminar), "Chofer");
                //dataGridView_Chofer.Rows[e.RowIndex].Cells["Habilitado"].Value = false;
                //if (resultado) MessageBox.Show("Se elimino correctamente");
                //CargarChoferes();
                //return;
            }
        }



    }
}
