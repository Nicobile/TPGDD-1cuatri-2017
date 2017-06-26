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


namespace UberFrba.Listado_Estadistico
{
    public partial class ListadoEstadistico : Form
    {
        String config = ConfigurationManager.AppSettings["configuracionSQL"];
        DateTime FECHA_ACTUAL;
       
        class Buscador
        {                                                // Singleton para facilitar las consultas a la base
            private static Buscador instancia { get; set; }                      // Crea SqlCommands
            public SqlConnection conexion { get; set; }
            private string ESQUEMA = "[PUSH_IT_TO_THE_LIMIT]";

            private Buscador()
            {                           //Se conecta con la base al ser creado
                String config = ConfigurationManager.AppSettings["configuracionSQL"];
                conexion = new SqlConnection(config);
                try
                {
                    conexion.Open();
                }
                catch (Exception)
                {
                    MessageBox.Show("Fallo la conexion");
                }
            }

            public static Buscador getInstancia()
            {
                if (instancia == null) instancia = new Buscador();
                return instancia;
            }
            public SqlCommand getCommandFunctionDeTabla(string funcion)
            {              // Para funciones de TABLA
                string query = "SELECT * From " + ESQUEMA + ".";                             // Recibe el nombre de la funcion
                query += funcion;
                SqlCommand command = new SqlCommand(query, conexion);
                return command;
            }
        }
        public ListadoEstadistico()
        {
            InitializeComponent();
            FECHA_ACTUAL = DateTime.Parse(ConfigurationManager.AppSettings["currentDate"]);
            seleccionAño.MaxDate = FECHA_ACTUAL;
            seleccionAño.Value = FECHA_ACTUAL;

        }


        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection(config);
            int trimestre = this.getTrimestre();
            string funcion = this.getTipoEstadistica();
            SqlCommand command = Buscador.getInstancia().getCommandFunctionDeTabla(funcion + "(@anio, @trimestre)");

            /*string query = "SELECT * From " + "[PUSH_IT_TO_THE_LIMIT]" + "." + "funcion(@anio, @trimestre)";
            SqlCommand command = new SqlCommand(query, conexion);*/

            command.Parameters.AddWithValue("@anio", seleccionAño.Value.Year);
            command.Parameters.AddWithValue("@trimestre", trimestre);
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
               
            }
            return 4;
        }
    
        private string getTipoEstadistica()
        {         
            switch (SeleccionEstadistica.SelectedIndex)
            {
                case 0: return "fx_Top5DechoferesMayorRecaudacionEnUnTrimeste";
                case 1: return "fx_Top5choferesViajesMasLargosEnUnTrimestre";
                case 2: return "fx_Top5clientesMayorConsumoEnUnTrimestre";
                case 3: return "fx_Top5clientesQueviajronEnUnMismoAutoEnUnTrimestre";
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
