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

        }


        private void button1_Click(object sender, EventArgs e)
        {
            string funcion = this.getTipoEstadistica();         
            
         
         /* me conectto con la base para obtener el resultado de aplocar la funcion*/
           String config = ConfigurationManager.AppSettings["archConexionConSQL"];
           SqlConnection conexion = new SqlConnection(config);
           try
           {
               conexion.Open();
           }
           catch (Exception) { MessageBox.Show("Error en conexion"); }
            
            string query = "SELECT * From " + "[PUSH_IT_TO_THE_LIMIT]" + "." + funcion+"(@anio, @trimestre)";
            SqlCommand command = new SqlCommand(query, conexion);
           
            command.Parameters.AddWithValue("@anio", seleccionAño.Value.Year);
            int trimestre = this.getTrimestre();
            
            command.Parameters.AddWithValue("@trimestre", trimestre);
            /*para mostrar el resultado*/
            DataTable tabla = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(tabla);
            listado.DataSource = tabla;
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
            throw new CampoVacioException("Falto seleccionar un trimestre");
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
            throw new CampoVacioException("Falto seleccionar una estadistica");
        }
      
        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MenuPrincipal().ShowDialog();
            this.Close();
        }
   
        
       
     
 


  

    }
}
