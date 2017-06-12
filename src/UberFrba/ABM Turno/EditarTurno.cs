using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UberFrba.Modelo;

namespace UberFrba.ABM_Turno
{
    public partial class EditarTurno : Form
    {
        private int idTurno;
        private DBMapper mapper = new DBMapper();

        public EditarTurno(String idTurno)
        {
            InitializeComponent();
            this.idTurno = Convert.ToInt32(idTurno);
        }

        private void EditarTurno_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }


        private void CargarDatos()
        {
            Turnos turno = mapper.ObtenerTurnos(idTurno);


            // idUsuario = chofer.GetIdUsuario();


            textBox_HoraInicio.Text = Convert.ToString(turno.GetHoraInicio());
            textBox_HoraFin.Text = Convert.ToString(turno.GetHoraFin());
            textBox_Descripcion.Text = Convert.ToString(turno.GetDescripcion());
            textBox_ValorKilometro.Text = Convert.ToString(turno.GetValorKilometro());
            textBox_PrecioBase.Text = Convert.ToString(turno.GetPrecioBaseTurno());
            checkBox_Habilitado.Checked = Convert.ToBoolean(mapper.SelectFromWhere("turno_habilitado", "Turno", "turno_id",this.idTurno));

        }

        private void button_Limpiar_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }

















    }
}
