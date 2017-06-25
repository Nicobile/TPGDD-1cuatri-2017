using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba.Modelo
{
    class Factura : Objeto, Mapeable
    {

        DateTime fechaInicioFactura;
        DateTime fechaFinFactura;
        int idCliente;
        int importeTotalFactura;
        int cantidadViajesFacturados;

        public void SetFechaInicioFactura(String fechaInicio)
        {
                this.fechaInicioFactura= Convert.ToDateTime(fechaInicio);
        }

        public DateTime GetFechaInicioFactura()
        {
            return this.fechaInicioFactura;
        }

        public void SetFechaFinFactura(String fechaFin)
        {
            this.fechaFinFactura = Convert.ToDateTime(fechaFin);
        }

        public DateTime GetFechaFinFactura()
        {
            return this.fechaFinFactura;
        }
        public void SetIdCliente(String DniCliente)
        {
            this.idCliente = Convert.ToInt32(DniCliente);
        }

        public int GetIdCliente()
        {
            return this.idCliente;
        }
        public void SetImporteTotalFactura(int TotalFactura)
        {
            this.importeTotalFactura=TotalFactura;
        }

        public int GetImporteTotalFactura()
        {
            return this.importeTotalFactura;
        }

        public void SetCantidadViajesFacturados(int CantidadViajes)
        {
            this.cantidadViajesFacturados = CantidadViajes;
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

            //IList<SqlParameter> parametros = new List<SqlParameter>();
            //parametros.Clear();
            //parametros.Add(new SqlParameter("@Cantidad_km", this.cantidadKm));
            //parametros.Add(new SqlParameter("@Fecha", this.fechaViaje));
            //parametros.Add(new SqlParameter("@HoraInicio", this.horarioInicio));
            //parametros.Add(new SqlParameter("@HoraFin", this.horarioFin));
            //parametros.Add(new SqlParameter("@idChofer", this.idChofer));
            //parametros.Add(new SqlParameter("@idAuto", this.idAuto));
            //parametros.Add(new SqlParameter("@idCliente", this.idCliente));
            //parametros.Add(new SqlParameter("@idTurno", this.idTurno));
            //return parametros;
            throw new NotImplementedException();
        
        
        
        
        
        
        
        
        
        
        
        }
        #endregion
    }
}
