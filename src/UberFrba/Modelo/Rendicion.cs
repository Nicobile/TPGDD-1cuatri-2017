using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberFrba.Exceptions;

namespace UberFrba.Modelo
{
    class Rendicion : Objeto, Mapeable
    {
        private Mapper mapper = new Mapper();
        DateTime fechaRendicion;
        int idChofer;
        int idTurno;
        float importeTotalRendicion;

        public void SetFechaRendicion(String fechaInicio)
        {

            if (fechaInicio == "")
            {
                throw new CampoVacioException("Fecha");
            }
            else
            {
                this.fechaRendicion = Convert.ToDateTime(fechaInicio);

            }

        }
        public DateTime GetFechaRendicion()
        {
            return this.fechaRendicion;
        }


        public void SetIdChofer(String DniChofer)
        {

            
            
                this.idChofer = mapper.obtenerIdChoferApartirDelDNI(DniChofer);

            
        }

        public int GetIdChofer()
        {
            return this.idChofer;
        }

        public void SetIdTurno(String TurnoSeleccionado)
        {

            if (TurnoSeleccionado == "")
            {
                throw new CampoVacioException("Turno");
            }
            else
            {
                this.idTurno = Convert.ToInt32(TurnoSeleccionado);
            }
        }

        public int GetIdTurno()
        {
            return this.idTurno;
        }




        public void SetImporteTotalRendicion(String TotalRendicion)
        {
            if (TotalRendicion == "")
            {

                throw new NoHayViajesException("No posee viajes registrados en la fecha");
            }
            else
            {
                this.importeTotalRendicion = Convert.ToSingle(TotalRendicion);
            }
        }

        public Double GetImporteTotalRendicion()
        {
            return this.importeTotalRendicion;
        }

        #region Metodos de Mapeable


        public string GetQueryCrear()
        {
            return "[PUSH_IT_TO_THE_LIMIT].pr_agregar_rendicion";
        }

        public string GetQueryModificar()
        {
            throw new NotImplementedException();
        }

        public string GetQueryObtener()
        {
            throw new NotImplementedException();
        }

        public void CargarInformacion(System.Data.SqlClient.SqlDataReader reader)
        {
            throw new NotImplementedException();
        }

        public IList<System.Data.SqlClient.SqlParameter> GetParametros()
        {


            IList<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Clear();
            parametros.Add(new SqlParameter("@fecha", this.fechaRendicion));
            parametros.Add(new SqlParameter("@idChofer", this.idChofer));
            parametros.Add(new SqlParameter("@idTurno", this.idTurno));
            parametros.Add(new SqlParameter("@importeTotal", this.importeTotalRendicion));
            return parametros;
        }
        #endregion
    }
}
