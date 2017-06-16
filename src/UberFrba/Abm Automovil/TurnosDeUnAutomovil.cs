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
using UberFrba.DataProvider;

namespace UberFrba.Abm_Automovil
{
    public partial class TurnosDeUnAutomovil : Form
    {

        private DBMapper mapper = new DBMapper();
        private int idAutomovilTurno;
        private String idAutomovilt;
        private SqlCommand command { get; set; }
        private IList<SqlParameter> parametros = new List<SqlParameter>();

        public TurnosDeUnAutomovil(String idAutomovil)
        {
            InitializeComponent();
            this.idAutomovilt = idAutomovil;
            this.idAutomovilTurno = Convert.ToInt32(idAutomovil);
        }

        private void TurnosDeUnAutomovil_Load(object sender, EventArgs e)
        {

            CargarTurnoAutomovil();
        }

        private void CargarTurnoAutomovil()
        {
            //dataGridView_Automovil.DataSource = mapper.SelectTurnosParaFiltroConFiltro("WHERE turno_id IN (SELECT turno_id FROM PUSH_IT_TO_THE_LIMIT.AutoporTurno WHERE auto_id=)"+this.idAutomovilTurno);
            //dataGridView_Automovil.DataSource = mapper.SelectTurnoParaFiltro();
           // dataGridView_Automovil.DataSource =mapper.SelectDataTable("*","PUSH_IT_TO_THE_LIMIT.AutoporTurn"," turno_id IN (SELECT turno_id FROM PUSH_IT_TO_THE_LIMIT.AutoporTurno WHERE auto_id=)"+this.idAutomovilTurno);

                       
            DataSet turnosAutomovil = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            parametros = new List<SqlParameter>();            
            parametros.Clear();
            parametros.Add(new SqlParameter("@idAutomovil", this.idAutomovilt));
            command = QueryBuilder.Instance.build("SELECT t.turno_id 'Turno N°',t.turno_hora_inicio 'Hora Inicio',t.turno_hora_fin 'Hora Fin',t.turno_descripcion 'Descripcion',t.turno_valor_Kilometro 'Valor Kilometro',t.turno_precio_base 'Precio Base',t.turno_habilitado 'Habilitado' FROM  PUSH_IT_TO_THE_LIMIT.Turno t  where t.turno_id IN (SELECT turno_id FROM PUSH_IT_TO_THE_LIMIT.AutoporTurno WHERE auto_id=@idAutomovil)" , parametros);
            adapter.SelectCommand = command;
            adapter.Fill(turnosAutomovil);
            dataGridView_Automovil.DataSource = turnosAutomovil.Tables[0].DefaultView;

         }

        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
