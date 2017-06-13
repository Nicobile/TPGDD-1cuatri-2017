using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberFrba.Exceptions;

namespace UberFrba.Modelo
{
    class Automoviles
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

        public String GetPatnte()
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









    }
}
