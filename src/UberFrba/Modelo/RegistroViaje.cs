using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberFrba.Exceptions;

namespace UberFrba.Modelo
{
    class RegistroViaje: Objeto, Mapeable
    {


        private Mapper mapper = new Mapper();
        int cantidadKm;
        DateTime fechaViaje;
        TimeSpan horarioInicio;
        TimeSpan horarioFin;
        int idChofer;
        int idAuto;
        int idCliente;
        int idTurno;




        public void SetCantidadKm(String km)
        {
            if (km == "")
            {
                throw new CampoVacioException("Cantidad Kilometros");
            }
            if (Convert.ToInt32(km)<=0)
            {
                throw new CantidaKilometrosInvalidoException("No se puede ingresar Cantidad de Kilometros menores a cero");
            }
            else
            {
                this.cantidadKm = Convert.ToInt32(km);
            }
        }

        public int GetCantidadKm()
        {
            return this.cantidadKm;
        }

        public void SetFechaViaje(String fecha)
        {
            if (fecha == "")
            {
                throw new CampoVacioException("Fecha Viaje");
            }
            else
            {
                this.fechaViaje = Convert.ToDateTime(fecha);
            }
        }

        public DateTime GetFechaViaje()
        {
            return this.fechaViaje;
        }

        public void SetHoraInicio(TimeSpan horaInicio)
        {
            this.horarioInicio =horaInicio ;
        }

        public TimeSpan GetHoraInicio()
        {
            return this.horarioInicio;
        }

        public void SetHoraFin(TimeSpan horaFin)
        {
            this.horarioFin= horaFin;
        }

        public TimeSpan GetHoraFin()
        {
            return this.horarioFin;
        }


        public void SetIdChofer(String DniChofer)
        {
            if (DniChofer == "")
            {
                throw new CampoVacioException("Chofer(DNI)");
            }
            else
            {
                this.idChofer = mapper.obtenerIdChoferApartirDelDNI(DniChofer);
            }
        }

        public int GetIdChofer()
        {
            return this.idChofer;
        }

        public void SetIdAuto(String PatenteAuto)
        {
            if (PatenteAuto == "")
            {
                throw new CampoVacioException("Patente");
            }
            else
            {
                this.idAuto = mapper.obtenerIdAutomovilApartirDeLaPatente(PatenteAuto);
            }
        }

        public int GetIdAuto()
        {
            return this.idAuto;
        }
        
        public void SetIdCliente(String DniCliente)
        {

            
            if (DniCliente == "")
            {
                throw new CampoVacioException("Cliente(DNI)");
            }

            int IDCliente = mapper.obtenerIdClienteApartirDelDNI(DniCliente);

            if (Convert.ToBoolean(mapper.SelectFromWhere("cliente_estado", "Cliente", "cliente_id", IDCliente) )== false)
            {

                throw new ClienteInhabilitadoException("El cliente  ingresado con DNI: " + DniCliente + " esta Deshabilitado");

            }
            else
            {
                this.idCliente = IDCliente;
            }
            
        }

        public int GetIdCliente()
        {
            return this.idCliente;
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
