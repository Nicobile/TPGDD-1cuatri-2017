using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberFrba.Exceptions;

namespace UberFrba.Modelo
{
    class Factura : Objeto, Mapeable
    {
        private Mapper mapper = new Mapper();
        DateTime fechaInicioFactura;
        DateTime fechaFinFactura;
        int idCliente;
        float importeTotalFactura;
        int cantidadViajesFacturados;

        public void SetFechaInicioFactura(String fechaInicio)
        {

            if (fechaInicio == "")
            {
                throw new CampoVacioException("Fecha Inicio");
            }
            else
            {
                this.fechaInicioFactura = Convert.ToDateTime(fechaInicio);

            }

        }
        public DateTime GetFechaInicioFactura()
        {
            return this.fechaInicioFactura;
        }

        public void SetFechaFinFactura(String fechaFin)
        {
            if (fechaFin == "")
            {
                throw new CampoVacioException("Fecha Inicio");
            }
            else
            {
                this.fechaFinFactura = Convert.ToDateTime(fechaFin);
            }

        }
        public DateTime GetFechaFinFactura()
        {
            return this.fechaFinFactura;
        }
        public void SetIdCliente(String DniCliente)
        {

            if (DniCliente == "")
            {

                throw new CampoVacioException("Cliente");

            }
            else
            {
                this.idCliente = mapper.obtenerIdClienteApartirDelDNI(DniCliente);
            
            }
        }

        public int GetIdCliente()
        {
            return this.idCliente;
        }
        public void SetImporteTotalFactura(String TotalFactura)
        {
            this.importeTotalFactura=Convert.ToSingle(TotalFactura);
        }

        public Double GetImporteTotalFactura()
        {
            return this.importeTotalFactura;
        }

        public void SetCantidadViajesFacturados(String CantidadViajes)
        {
            this.cantidadViajesFacturados =Convert.ToInt32(CantidadViajes);
        }

        public int GetCantidadViajesFacturados()
        {
            return this.cantidadViajesFacturados;
        }


        #region Metodos de Mapeable
        
        
        public string GetQueryCrear()
        {
            return "[PUSH_IT_TO_THE_LIMIT].pr_agregar_factura";
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
            parametros.Add(new SqlParameter("@FechaInicio", this.fechaInicioFactura));
            parametros.Add(new SqlParameter("@FechaFin", this.fechaFinFactura));
            parametros.Add(new SqlParameter("@idCliente", this.idCliente));
            parametros.Add(new SqlParameter("@ImporteTotal", this.importeTotalFactura));
            return parametros;
        }
        #endregion
    }
}
