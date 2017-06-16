using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UberFrba.Abm_Automovil
{
    public partial class FiltroAutomovil : Form
    {

        private DBMapper mapper = new DBMapper();
        public FiltroAutomovil()
        {
            InitializeComponent();
        }

        private void FiltroAutomovil_Load(object sender, EventArgs e)
        {
            CargarAutomoviles();
            comboBox_Marca.Items.Add("Porsche");
            comboBox_Marca.Items.Add("Chevrolet");
            comboBox_Marca.Items.Add("Renault");
            comboBox_Marca.Items.Add("Peugeot");
            comboBox_Marca.Items.Add("Ford");
            comboBox_Marca.Items.Add("Fiat");
            comboBox_Marca.Items.Add("Volkswagen");
            comboBox_Marca.Items.Add("Toyota");
            comboBox_Marca.Items.Add("Citroën");
        }
        

        private void button_Cancelar_Click(object sender, EventArgs e)
        {

            this.Hide();
            new MenuAutomovil().ShowDialog();
            this.Close();
        }

        private void button_Limpiar_Click(object sender, EventArgs e)
        {
            comboBox_Marca.Text = "";
            textBox_Modelo.Text = "";
            textBox_Patente.Text = "";
            textBox_Chofer_Dni.Text = "";
            CargarAutomoviles();
        }

        private void CargarAutomoviles()
        {
            dataGridView_Automovil.DataSource = mapper.SelectAutomovilParaFiltro();
            CargarColumnaTurnos();
            CargarColumnaModificacion();
            CargarColumnaEliminar();
            
        }

        private void CargarColumnaEliminar()
        {
            if (dataGridView_Automovil.Columns.Contains("Eliminar"))
                dataGridView_Automovil.Columns.Remove("Eliminar");
            DataGridViewButtonColumn botonColumnaEliminar = new DataGridViewButtonColumn();
            botonColumnaEliminar.Text = "Eliminar";
            botonColumnaEliminar.Name = "Eliminar";
            botonColumnaEliminar.UseColumnTextForButtonValue = true;
            dataGridView_Automovil.Columns.Add(botonColumnaEliminar);
        }

        private void CargarColumnaModificacion()
        {
            if (dataGridView_Automovil.Columns.Contains("Modificar"))
                dataGridView_Automovil.Columns.Remove("Modificar");
            DataGridViewButtonColumn botonColumnaModificar = new DataGridViewButtonColumn();
            botonColumnaModificar.Text = "Modificar";
            botonColumnaModificar.Name = "Modificar";
            botonColumnaModificar.UseColumnTextForButtonValue = true;
            dataGridView_Automovil.Columns.Add(botonColumnaModificar);

        }

        private void CargarColumnaTurnos()
        {

            if (dataGridView_Automovil.Columns.Contains("Turnos"))
                dataGridView_Automovil.Columns.Remove("Turnos");
            DataGridViewButtonColumn botonMostrarTurnos = new DataGridViewButtonColumn();
            botonMostrarTurnos.Text = "Ver Turnos";
            botonMostrarTurnos.Name = "Turnos";
            botonMostrarTurnos.UseColumnTextForButtonValue = true;
            dataGridView_Automovil.Columns.Add(botonMostrarTurnos);


        }        
        
        
        
        
        
        private void button_Buscar_Click(object sender, EventArgs e)
        {
            String filtro = CalcularFiltro();
            dataGridView_Automovil.DataSource = mapper.SelectAutomovilParaFiltroConFiltro(filtro);
        }

        private String CalcularFiltro()
        {
            String filtro = "";
            if (comboBox_Marca.Text != "") filtro += "AND " + "a.auto_marca LIKE '" + comboBox_Marca.Text + "%'";
            if (textBox_Modelo.Text != "") filtro += "AND " + "a.auto_modelo LIKE '" + textBox_Modelo.Text + "%'";
            if (textBox_Patente.Text != "") filtro += "AND " + "a.auto_patente LIKE '" + textBox_Patente.Text + "%'";
            if (textBox_Chofer_Dni.Text != "") filtro += "AND " + "c.chofer_dni LIKE '" + textBox_Chofer_Dni.Text + "%'";
            return filtro;
        }

        private void dataGridView_Automovil_CellClick(object sender, DataGridViewCellEventArgs e)
        {
                        // Controla que la celda que se clickeo fue la de modificar
            if (e.ColumnIndex == dataGridView_Automovil.Columns["Modificar"].Index && e.RowIndex >= 0)
            {
                String idAutomovilAModificar = dataGridView_Automovil.Rows[e.RowIndex].Cells["Auto N°"].Value.ToString();
                String dniChoferAutomovilAModificar = dataGridView_Automovil.Rows[e.RowIndex].Cells["DNI chofer"].Value.ToString();
               // int idChoferObtenidoApartirDelDNI = Convert.ToInt32(mapper.SelectFromWhere("chofer_id", "Chofer", "chofer_dni", Convert.ToInt32(dniChoferAutomovilAModificar)));

                new EditarAutomovil(idAutomovilAModificar,dniChoferAutomovilAModificar).ShowDialog();
                CargarAutomoviles();
                    return;
            }
            if (e.ColumnIndex == dataGridView_Automovil.Columns["Eliminar"].Index && e.RowIndex >= 0)
            {
                String idAutomovilAEliminar = dataGridView_Automovil.Rows[e.RowIndex].Cells["Auto N°"].Value.ToString();
                Boolean resultado = mapper.EliminarAutomovil(Convert.ToInt32(idAutomovilAEliminar), "Auto");
                dataGridView_Automovil.Rows[e.RowIndex].Cells["Habilitado"].Value = false;
                CargarColumnaTurnos();

                if (resultado) MessageBox.Show("Se elimino correctamente");
                CargarAutomoviles();
                return;
            }

            if (e.ColumnIndex == dataGridView_Automovil.Columns["Turnos"].Index && e.RowIndex >= 0)
            {
                String idAutomovilTurno = dataGridView_Automovil.Rows[e.RowIndex].Cells["Auto N°"].Value.ToString();
                //MessageBox.Show(idAutomovilTurno);
                new TurnosDeUnAutomovil(idAutomovilTurno,true,0).ShowDialog();
                
            //    //Boolean resultado = mapper.EliminarAutomovil(Convert.ToInt32(idAutomovilAEliminar), "Auto");
            //    //dataGridView_Automovil.Rows[e.RowIndex].Cells["Habilitado"].Value = false;
            //    //if (resultado) MessageBox.Show("Se elimino correctamente");
            //    //CargarAutomoviles();
            //    return;
            }

                      

        }






    }
}
