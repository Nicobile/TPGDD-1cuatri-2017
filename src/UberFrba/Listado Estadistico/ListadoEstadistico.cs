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
using System.Configuration;
using UberFrba.Exceptions;


namespace UberFrba.Listado_Estadistico
{
    public partial class ListadoEstadistico : Form
    {

       
        public ListadoEstadistico()
        {
            InitializeComponent();
            DateTime FECHA_ACTUAL = DateTime.Parse(ConfigurationManager.AppSettings["FechaInicio"]);
            seleccionAño.MaxDate = FECHA_ACTUAL;
            seleccionAño.Value = FECHA_ACTUAL;
            seleccionTrimestre.Text = "";
            SeleccionEstadistica.Text = "";

        }


        private void button1_Click(object sender, EventArgs e)
        {
            
            String funcion = this.getTipoEstadistica();
            int trimestre = this.getTrimestre();
            String error = errorEnCampo(trimestre,funcion);
            
                
            if (error==""){

                /* me conectto con la base para obtener el resultado de aplocar la funcion*/
                String config = ConfigurationManager.AppSettings["archConexionConSQL"];
                SqlConnection conexion = new SqlConnection(config);
                try
                {
                    conexion.Open();
                }
                catch (Exception) { MessageBox.Show("Error en conexion"); }

                string query = "SELECT * From [PUSH_IT_TO_THE_LIMIT]." + funcion + "(@anio, @trimestre)";
                SqlCommand command = new SqlCommand(query, conexion);

                command.Parameters.AddWithValue("@anio", seleccionAño.Value.Year);
                

                command.Parameters.AddWithValue("@trimestre", trimestre);
                /*para mostrar el resultado*/
                DataTable tabla = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(tabla);
                listado.DataSource = tabla;
                
               
            }
            else {
                MessageBox.Show(error, "Faltan completar campos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }
        private String errorEnCampo(int trimestre, String estadistica){
            String error = "";
            if (trimestre==-1) { error+="-Debe ingresar un trimestre\n";}
            if (estadistica ==null) { error += "-Debe ingresar una estadistica\n"; }
            return error;
        }

        private int getTrimestre()
        {
            switch (seleccionTrimestre.SelectedIndex)
            {
                case 0: return 1;
                case 1: return 2;
                case 2: return 3;
                case 3: return 4;
            }
            
            return -1;
        }
    
        private string getTipoEstadistica()
        {         
            switch (SeleccionEstadistica.SelectedIndex)
            {
                case 0: return "fx_Top5DechoferesMayorRecaudacionEnUnTrimeste";
                case 1: return "fx_Top5choferesViajesMasLargosEnUnTrimestre";
                case 2: return "fx_Top5clientesMayorConsumoEnUnTrimestre";
                case 3: return "fx_Top5clientesQueviajaronEnUnMismoAutoEnUnTrimestre";
            }
            
            return null;
        }
      
        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MenuPrincipal().ShowDialog();
            this.Close();
        }
   
        
       
     
 


  

    }
}
