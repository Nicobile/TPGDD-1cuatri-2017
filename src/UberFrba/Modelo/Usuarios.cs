using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UberFrba.Modelo
{
    class Usuarios
    {
        private int id;
        private String username;
        private String password;
        private Boolean activo;
        private int intentos;
        private Boolean admin;

        public void SetId(int id)
        {
            this.id = id;
        }

        public int GetId()
        {
            return this.id;
        }

        public void SetUsername(String username)
        {
            this.username = username;
        }

        public String GetUsername()
        {
            return this.username;
        }

        public void SetPassword(String password)
        {
            this.password = password;
        }

        public String GetPassword()
        {
            return this.password;
        }

        public void SetActivo(Boolean activo)
        {
            this.activo = activo;
        }

        public Boolean GetActivo()
        {
            return this.activo;
        }


         public void SetIntentos(int intentos)
        {
            this.intentos = intentos;
        }

        public int GetIntentos()
        {
            return this.intentos;
        }


        public void SetAdmin(Boolean activo)
        {
            this.admin = activo;
        }

        public Boolean GetAdmin()
        {
            return this.admin;
        }

    }
}
