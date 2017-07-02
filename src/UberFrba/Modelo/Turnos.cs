using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UberFrba.Exceptions;
using System.Data.SqlClient;

namespace UberFrba.Modelo
{
    class Turnos : Objeto, Mapeable
    {
        private int id;
        private int horaInicio;
        private int horaFin;
        private String descripcion;
        private Double valorKilometro;
        private Double precioBaseTurno;
        private Boolean activo;

        public void SetId(int id)
        {
            this.id = id;
        }

        public int GetId()
        {
            return this.id;
        }
        
        public void SetHoraInicio(String hora){
            if (hora == "")
            {
                throw new CampoVacioException("Hora inicio");
            }
              
            if (!esNumero(hora)){
                throw new FormatoInvalidoException("Hora Inicio");
                 }
           this.horaInicio = Convert.ToInt32(hora);
        }

        public int GetHoraInicio(){
            return this.horaInicio;
        }

        public void SetHoraFin(String hora)
        {
            if (hora == "")
            {
                throw new CampoVacioException("Hora fin");
            }

            if (!esNumero(hora))
            {
                throw new FormatoInvalidoException("Hora FIn");
            }
            this.horaFin = Convert.ToInt32(hora);
  
        }

        public int GetHoraFin()
        {
            return this.horaFin;
        }

        public void SetDescripcion(String desc)
        {
            if (desc == "")
                throw new CampoVacioException("Descripcion");
            this.descripcion = desc;
        }

        public String GetDescripcion()
        {
            return this.descripcion;
        }

        public void SetValorKilometro(String value)
        {
            if (value == "")
            {
                throw new CampoVacioException("Valor del Kilometro");
            }
            if (!esDouble(value))
            {
                throw new FormatoInvalidoException("Valor del Kilometro. Ingrese todos los numeros seguidos.");
            }
            this.valorKilometro = Convert.ToDouble(value);
        }

        public Double GetValorKilometro()
        {
            return this.valorKilometro;
        }

        public void SetPrecioBaseTurno(String precio)
        {
            if (precio == "")
                throw new CampoVacioException("Precio base del turno");
            if (!esDouble(precio))
            {
                throw new FormatoInvalidoException("Precio base del turno. Ingrese todos los numeros seguidos.");
            }
            this.precioBaseTurno = Convert.ToDouble(precio);
        }

        public Double GetPrecioBaseTurno()
        {
            return this.precioBaseTurno;
        }

        public void SetActivo(Boolean turno_habilitado)
        {
            this.activo = turno_habilitado;
        }

        public Boolean GetActivo()
        {
            return this.activo;
        }

        #region Miembros de Comunicable

        string Mapeable.GetQueryCrear()
        {
            return "PUSH_IT_TO_THE_LIMIT.crear_turno";
        }

        string Mapeable.GetQueryModificar()
        {
            if (activo == true)
            {

                return "UPDATE PUSH_IT_TO_THE_LIMIT.Turno SET turno_hora_inicio = @hora_inicio, turno_hora_fin = @hora_fin, turno_descripcion = @descripcion, turno_valor_kilometro = @valor_km, turno_precio_base = @precio_base, turno_habilitado = @habilitado WHERE turno_id = @id ";
            }
            else
            {
                return "UPDATE PUSH_IT_TO_THE_LIMIT.Turno SET turno_hora_inicio = @hora_inicio, turno_hora_fin = @hora_fin, turno_descripcion = @descripcion, turno_valor_kilometro = @valor_km, turno_precio_base = @precio_base, turno_habilitado = @habilitado WHERE turno_id = @id ";
            }


        }

        string Mapeable.GetQueryObtener()
        {
            return "SELECT * FROM PUSH_IT_TO_THE_LIMIT.Turno WHERE turno_id = @id";
        }

        IList<System.Data.SqlClient.SqlParameter> Mapeable.GetParametros()
        {
            IList<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Clear();
            parametros.Add(new SqlParameter("@hora_inicio", this.horaInicio));
            parametros.Add(new SqlParameter("@hora_fin", this.horaFin));
            parametros.Add(new SqlParameter("@descripcion", this.descripcion));
            parametros.Add(new SqlParameter("@valor_km", this.valorKilometro));
            parametros.Add(new SqlParameter("@precio_base", Convert.ToDouble(this.precioBaseTurno)));
            parametros.Add(new SqlParameter("@habilitado", this.activo));

            return parametros;
        }

        void Mapeable.CargarInformacion(SqlDataReader reader)
        {
            this.horaInicio = Convert.ToInt32(reader["turno_hora_inicio"]);
            this.horaFin = Convert.ToInt32(reader["turno_hora_fin"]);
            this.descripcion = Convert.ToString(reader["turno_descripcion"]);
            this.valorKilometro = Convert.ToInt32(reader["turno_valor_kilometro"]);
            this.precioBaseTurno = Convert.ToInt32(reader["turno_precio_base"]);
            this.activo = Convert.ToBoolean(reader["turno_habilitado"]);
        }

        #endregion
    }
}
