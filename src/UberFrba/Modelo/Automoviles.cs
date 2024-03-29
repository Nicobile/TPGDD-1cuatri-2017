﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberFrba.Exceptions;

namespace UberFrba.Modelo
{
    class Automoviles : Objeto, Mapeable
    {
        private int id;
        private String patente;
        private String marca;
        private String modelo;
        private Boolean activo;
        private int licencia;
        private String rodado;




        public void SetId(int id) {

            this.id = id;
        }


        public int GetId()
        {
            return this.id;
        }

        public void SetPatente(String patente)
        {
            if (patente == "") throw new CampoVacioException("patente");
            this.patente = patente;
        }

        public String GetPatente()
        {
            return this.patente;
        }

        public void SetMarca(String marca)
        {
            if (marca == "") throw new CampoVacioException("marca");
            this.marca = marca;
        }

        public String GetMarca()
        {
            return this.marca;
        }

        public void SetModelo(String modelo)
        {
            if (modelo == "") throw new CampoVacioException("modelo");
            this.modelo = modelo;
        }

        public String GetModelo()
        {
            return this.modelo;
        }


        public void SetActivo(Boolean activo)
        {
            this.activo = activo;
        }

        public Boolean GetActivo()
        {
            return this.activo;
        }

        public void SetLicencia(int licencia)
        {
            //no esta hecha la validacion por que este dato no lo pide el enunciado;
            this.licencia = licencia;
        }


        public int GetLicencia()
        {
            return this.licencia;
        }

        public void SetRodado(String rodado)
        {
            //no esta hecha la validacion por que este dato no lo pide el enunciado;
            this.rodado = rodado;
        }

        public String GetRodado()
        {
            return this.rodado;
        }

        public string GetQueryCrear()
        {
            return "[PUSH_IT_TO_THE_LIMIT].crear_automovil";
        }

        public string GetQueryModificar()
        {
            return "UPDATE PUSH_IT_TO_THE_LIMIT.Auto SET auto_patente = @Patente, auto_marca = @Marca, auto_modelo = @Modelo, auto_estado=@activo WHERE auto_id =  @id ";
        }

        public string GetQueryObtener()
        {
            return "SELECT * FROM PUSH_IT_TO_THE_LIMIT.Auto WHERE auto_id = @id";
        }





        void Mapeable.CargarInformacion(SqlDataReader reader)
        {
            this.patente = Convert.ToString(reader["auto_patente"]);
            this.marca = Convert.ToString(reader["auto_marca"]);
            this.modelo = Convert.ToString(reader["auto_modelo"]);
            this.activo = Convert.ToBoolean(reader["auto_estado"]);
            this.id = Convert.ToInt32(reader["auto_id"]);
        }

        public IList<System.Data.SqlClient.SqlParameter> GetParametros()
        {

            IList<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@Patente", this.patente));
            parametros.Add(new SqlParameter("@Marca", this.marca));
            parametros.Add(new SqlParameter("@Modelo", this.modelo));
            parametros.Add(new SqlParameter("@activo", this.activo));


            return parametros;
        }
    }
}
