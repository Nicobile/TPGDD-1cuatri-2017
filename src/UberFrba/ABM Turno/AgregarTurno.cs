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
using UberFrba.Exceptions;
using UberFrba.DataProvider;
using System.Data.SqlClient;

namespace UberFrba.ABM_Turno
{
    public partial class AgregarTurno : Form
    {

        private Mapper mapper = new Mapper();
        private int idTurno;

        public AgregarTurno()
        {
            InitializeComponent();
        }

        private void button_Guardar_Click_1(object sender, EventArgs e)
        {
                 
            // Guarda en variables todos los campos de entrada
            String HoraInicio = textBox_HoraInicio.Text;
            String HoraFin = textBox_HoraFin.Text;
            String Descripcion = textBox_Descripcion.Text;
            String valorKilometro = textBox_ValorKilometro.Text;
            String PrecioBase = textBox_PrecioBase.Text;
            Boolean Habilitado = checkBox_Habilitado.Checked;


            // Crea Turno
            try
            {
                Turnos turno = new Turnos();

                turno.SetHoraInicio(HoraInicio);
                turno.SetHoraFin(HoraFin);
                turno.SetDescripcion(Descripcion);
                turno.SetValorKilometro(valorKilometro);
                turno.SetPrecioBaseTurno(PrecioBase);
                turno.SetActivo(Habilitado);

                idTurno = mapper.Crear(turno);
                if (idTurno > 0) MessageBox.Show("Turno agregado correctamente");
            }
            catch (CampoVacioException exceptionCampoVacio)
            {
                MessageBox.Show("Falta completar campo: " + exceptionCampoVacio.Message);
                return;
            }
            catch (FormatoInvalidoException exceptionFormato)
            {
                MessageBox.Show("Los datos fueron mal ingresados en: " + exceptionFormato.Message);
                return;
            }
            catch (SqlException error)
            {

                switch (error.Number)
                {
                    case 51000: MessageBox.Show("El turno ingresado se superpone con otro", "Turno Superpuesto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    case 51001: MessageBox.Show("El turno ingresado se superpone con otro", "Turno Superpuesto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    case 51002: MessageBox.Show("El turno ingresado ya existe y esta Activo", "Turno Existente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    case 51003: MessageBox.Show("El turno ingresado ya existe y esta Deshabilitado", "Turno Existente Deshabilitado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    case 51004: MessageBox.Show("El horario ingresado es mayor a un dia o es invalido", "Turno Horario Invalido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                }
            }
    

            VolverAlMenu();
        }

        private void VolverAlMenu()
        {
            this.Hide();
            new MenuTurno().ShowDialog();
            this.Close();
        }

        private void button_Cancelar_Click_1(object sender, EventArgs e)
        {
            VolverAlMenu();
        }

        private void button_Limpiar_Click_1(object sender, EventArgs e)
        {
            textBox_HoraInicio.Text = "";
            textBox_HoraFin.Text = "";
            textBox_Descripcion.Text = "";
            textBox_ValorKilometro.Text = "";
            textBox_PrecioBase.Text = "";
            checkBox_Habilitado.Checked = false;

        }

        private void AgregarTurno_Load(object sender, EventArgs e)
        {
            this.checkBox_Habilitado.Checked = true;
        }


    
    }
}
