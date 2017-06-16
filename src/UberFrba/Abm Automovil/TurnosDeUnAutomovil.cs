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
        private Boolean ocultarBotonDeshabilitarTurno;
        private int idAutomovilSeleccionado;

        public TurnosDeUnAutomovil(String idAutomovil,Boolean botonDeshabilitarTurno,int idAutomovilSeleccionado)
        {
            InitializeComponent();
            this.idAutomovilt = idAutomovil;
            this.idAutomovilTurno = Convert.ToInt32(idAutomovil);
            this.ocultarBotonDeshabilitarTurno = botonDeshabilitarTurno;
            if (idAutomovilSeleccionado != 0)
            {
                this.idAutomovilSeleccionado = idAutomovilSeleccionado;
            }
            //this.OcultarColumnasQueNoDebenVerse("Deshabilitar  Turno al Automovil");
        }

        private void TurnosDeUnAutomovil_Load(object sender, EventArgs e)
        {

            CargarTurnoAutomovil();
            if (ocultarBotonDeshabilitarTurno)
            {
                this.OcultarColumnasQueNoDebenVerse("Deshabilitar  Turno al Automovil");
            }
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
            command = QueryBuilder.Instance.build("SELECT t.turno_id 'Turno N°',t.turno_hora_inicio 'Hora Inicio',t.turno_hora_fin 'Hora Fin',t.turno_descripcion 'Descripcion',t.turno_valor_Kilometro 'Valor Kilometro',t.turno_precio_base 'Precio Base',(t.turno_habilitado & A.auto_turno_estado) 'Habilitado'FROM  PUSH_IT_TO_THE_LIMIT.Turno t JOIN    PUSH_IT_TO_THE_LIMIT.AutoporTurno A ON(T.turno_id=A.turno_id) where t.turno_id IN (SELECT turno_id FROM PUSH_IT_TO_THE_LIMIT.AutoporTurno WHERE auto_id=@idAutomovil) AND auto_id=@idAutomovil", parametros);
            adapter.SelectCommand = command;
            adapter.Fill(turnosAutomovil);
            dataGridView_Automovil_Turnos_Actuales.DataSource = turnosAutomovil.Tables[0].DefaultView;
            CargarColumnaModificacion();
         }

        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void CargarColumnaModificacion()
        {
            if (dataGridView_Automovil_Turnos_Actuales.Columns.Contains("Deshabilitar este Turno al Automovil"))
                dataGridView_Automovil_Turnos_Actuales.Columns.Remove("Deshabilitar este Turno al Automovil");
            DataGridViewButtonColumn botonColumnaModificar = new DataGridViewButtonColumn();
            botonColumnaModificar.Text = "Deshabilitar este Turno al Automovil";
            botonColumnaModificar.Name = "Deshabilitar  Turno al Automovil";
            botonColumnaModificar.Width = 300;
            botonColumnaModificar.UseColumnTextForButtonValue = true;
            dataGridView_Automovil_Turnos_Actuales.Columns.Add(botonColumnaModificar);

        }

        private void OcultarColumnasQueNoDebenVerse(String Columna)
        {
            dataGridView_Automovil_Turnos_Actuales.Columns[Columna].Visible = false;
        }


        
        private void dataGridView_Automovil_Turnos_Actuales_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == dataGridView_Automovil_Turnos_Actuales.Columns["Deshabilitar  Turno al Automovil"].Index && e.RowIndex >= 0)
            {
                
                String idTurnoAModificar = dataGridView_Automovil_Turnos_Actuales.Rows[e.RowIndex].Cells["Turno N°"].Value.ToString();
                Boolean pudoModificar=mapper.ActualizarEstadoTutnoAutomovil(this.idAutomovilSeleccionado, Convert.ToInt32(idTurnoAModificar),0);
                if (pudoModificar) MessageBox.Show("Turno deshabilitado del automovil correctamente");
                dataGridView_Automovil_Turnos_Actuales.Rows[e.RowIndex].Cells["Habilitado"].Value = false;
                CargarTurnoAutomovil();
                return;
            }
         
        }

    }
}
