using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba.Modelo
{
    class RegistroViaje: Objeto, Mapeable
    {
        int cantidadKm;
        DateTime fechaViaje;
        DateTime horarioInicio;
        DateTime horarioFin;
        int idChofer;
        int idAuto;
        int idCliente;
        int idTurno;




        public void SetCantidadKm(int km)
        {
            this.cantidadKm = km;
        }

        public int GetCantidadKm()
        {
            return this.cantidadKm;
        }

        public void SetFechaViaje(DateTime fecha)
        {
            this.fechaViaje = fecha;
        }

        public DateTime GetFechaViaje()
        {
            return this.fechaViaje;
        }

        public void SetHoraInicio(DateTime horaInicio)
        {
            this.horarioInicio =horaInicio ;
        }

        public DateTime GetHoraInicio()
        {
            return this.horarioInicio;
        }

        public void SetHoraFin(DateTime horaFin)
        {
            this.horarioFin= horaFin;
        }

        public DateTime GetHoraFin()
        {
            return this.horarioFin;
        }


        public void SetIdChofer(int idChofer)
        {
            this.idChofer = idChofer;
        }

        public int GetIdChofer()
        {
            return this.idChofer;
        }

        public void SetIdAuto(int idAuto)
        {
            this.idAuto = idAuto;
        }

        public int GetIdAuto()
        {
            return this.idAuto;
        }
        
        public void SetIdCliente(int idCliente)
        {
            this.idCliente = idCliente;
        }

        public int GetIdCliente()
        {
            return this.idCliente;
        }


        public void SetIdTurno(int idTurno)
        {
            this.idTurno = idTurno;
        }

        public int GetIdTurno()
        {
            return this.idTurno;
        }

              

        string Mapeable.GetQueryCrear()
        {
            return "[PUSH_IT_TO_THE_LIMIT].pr_agregar_registro";
        }
                
        public string GetQueryModificar()
        {
            throw new NotImplementedException();//

        }

        public string GetQueryObtener()
        {
            throw new NotImplementedException();
        }

        public void CargarInformacion(System.Data.SqlClient.SqlDataReader reader)
        {
            throw new NotImplementedException();
        }

        IList<System.Data.SqlClient.SqlParameter> Mapeable.GetParametros()
        {
            IList<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Clear();
            parametros.Add(new SqlParameter("@Cantidad_km", this.cantidadKm));
            parametros.Add(new SqlParameter("@Fecha", this.fechaViaje));
            parametros.Add(new SqlParameter("@HoraInicio", this.horarioInicio));
            parametros.Add(new SqlParameter("@HoraFin", this.horarioFin));
            parametros.Add(new SqlParameter("@idChofer", this.idChofer));
            parametros.Add(new SqlParameter("@idAuto", this.idAuto));
            parametros.Add(new SqlParameter("@idCliente", this.idCliente));
            parametros.Add(new SqlParameter("@idTurno", this.idTurno));
            return parametros;
        }
        
        
        
        
        public IList<System.Data.SqlClient.SqlParameter> GetParametros()
        {
            throw new NotImplementedException();
        }
    }
}
