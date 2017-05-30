using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UberFrba.Exceptions;
using System.Data.SqlClient;

namespace UberFrba.Modelo
{
    class Clientes : Objeto, Mapeable
    {/*faltan getters y setters*/
        private int id;
        private String DNI; 
        private String nombre;
        private String apellido;   
        private String mail;
        private String telefono;
        private String direccion;
        private String codigoPostal;
        private DateTime fechaDeNacimiento;
        private Boolean activo;
        private int idUsuario;


        public void SetId(int id)
        {
            this.id = id;
        }

        public int GetId()
        {
            return this.id;
        }


        public void SetDNI(String DNI)
        {
            if (DNI == "")
                throw new CampoVacioException("DNI");

            if (!esNumero(DNI))
                throw new FormatoInvalidoException("DNI, Ingrese todos los numeros seguidos.");
            SetDNIChofer(DNI); 
        }

        private void SetDNICliente(string DNI)
        {
            this.DNI = Convert.ToInt32(DNI);
        }

        public String GetDNI() 
        {
            return Convert.ToString(this.DNI);
        }


        public void SetNombre(String nombre)
        {
            if (nombre == "")
                throw new CampoVacioException("Nombre");
            this.nombre = nombre;
        }

        public String GetNombre()
        {
            return this.nombre;
        }


        public void SetApellido(String apellido)
        {
            if (apellido == "")
                throw new CampoVacioException("Apellido");
            this.apellido = apellido;
        }

        public String GetApellido()
        {
            return this.apellido;
        }


        public void SetMail(String mail)
        {
            this.mail = mail;
        }

        public String GetMail()
        {
            return  this.mail;
        }


        public void SetTelefono(String telefono)
        {
           if (telefono == "")
                throw new CampoVacioException("Telefono"); 

            if (!esNumero(telefono))
            throw new FormatoInvalidoException("Telefono, Ingrese todos los numeros seguidos.");    

            SetTelefonoCliente(telefono);
        }

        private void SetTelefonoCliente(string telefono)
        {
            this.telefono = Convert.ToInt32(telefono);
        }

        public String GetTelefono()
        {
            return Convert.ToString(this.telefono);
        }


        public void SetDireccion(String direccion)
        {
            if (direccion == "")
                throw new CampoVacioException("Direccion");
            this.direccion = direccion;
        }

        public string GetDireccion()
        {
           return this.direccion;
        }


        public void SetCodigoPostal(String codigoPostal)
        {
            if (codigoPostal == "")
                throw new CampoVacioException("Codigo Postal"); 

            if (!esNumero(codigoPostal))
                throw new FormatoInvalidoException("Codigo Postal, Ingrese todos los numeros seguidos.");    

            SetCPCliente(codigoPostal);
        }

        private void SetCPCliente(string codigoPostal)
        {
            this.codigoPostal = Convert.ToInt32(codigoPostal);
        }

        public String GetCodigoPostal()
        {
            return Convert.ToString(this.codigoPostal);
        }


        public void SetFechaDeNacimiento(DateTime fechaDeNacimiento)
        {
            if (fechaDeNacimiento.Equals(DateTime.MinValue))
                throw new CampoVacioException("Fecha de nacimiento");

            if (!esFechaPasada(fechaDeNacimiento))
                throw new FechaPasadaException();

            this.fechaDeNacimiento = fechaDeNacimiento;
        }

        public DateTime GetFechaDeNacimiento()
        {
            return this.fechaDeNacimiento;
        }


        public void SetActivo(Boolean activo)
        {
            this.activo = activo;
        }

        public Boolean GetActivo()
        {
            return this.activo;
        }


        public void SetIdUsuario(int idUsuario)
        {
            this.idUsuario = idUsuario;
        }

        public int GetIdUsuario()
        {
            return this.idUsuario;
        }


        #region Miembros de Comunicable

        string Mapeable.GetQueryCrear()
        {
            return "PUSH_IT_TO_THE_LIMIT.pr_crear_cliente";
        }

        string Mapeable.GetQueryModificar()
        {
            if (activo == true)
            {
               
                return "UPDATE PUSH_IT_TO_THE_LIMIT.Clientes SET cli_nombre = @nombre, cli_apellido = @apellido, cli_dni = @documento, cli_mail = @mail, cli_telefono = @telefono, cli_direccion = @direccion, cli_codigoPostal = @codigoPostal, cli_fecha_nac = @fecha_nacimiento, cli_activo = @activo WHERE cli_id = @id " +
                " UPDATE PUSH_IT_TO_THE_LIMIT.Usuarios SET usr_intentos = 0 WHERE usr_id = (SELECT cli_usr_id FROM PUSH_IT_TO_THE_LIMIT.Clientes WHERE cli_id = @id) ";
            }
            else
            {
                return "UPDATE PUSH_IT_TO_THE_LIMIT.Clientes SET cli_nombre = @nombre, cli_apellido = @apellido, cli_dni = @documento, cli_mail = @mail, cli_telefono = @telefono, cli_direccion = @direccion, cli_codigoPostal = @codigoPostal, cli_fecha_nac = @fecha_nacimiento, cli_activo = @activo WHERE cli_id = @id";
            }

            
        }

        string Mapeable.GetQueryObtener()
        {
            return "SELECT * FROM PUSH_IT_TO_THE_LIMIT.Clientes WHERE cli_id = @id";
        }

        IList<System.Data.SqlClient.SqlParameter> Mapeable.GetParametros()
        {
            IList<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Clear();
            parametros.Add(new SqlParameter("@nombre", this.nombre));
            parametros.Add(new SqlParameter("@apellido", this.apellido));
            parametros.Add(new SqlParameter("@documento", this.DNI));
            parametros.Add(new SqlParameter("@mail", this.mail));
            parametros.Add(new SqlParameter("@telefono", this.telefono));
            parametros.Add(new SqlParameter("@direccion", this.direccion));
            parametros.Add(new.SqlParameter("@codigoPostal", this.codigoPostal));
            parametros.Add(new SqlParameter("@fecha_nacimiento", this.fechaDeNacimiento));
            parametros.Add(new SqlParameter("@activo", this.activo));
            return parametros;
        }

        void Mapeable.CargarInformacion(SqlDataReader reader)
        {
            this.nombre = Convert.ToString(reader["cli_nombre"]);
            this.apellido = Convert.ToString(reader["cli_apellido"]);
            this.DNI = Convert.ToInt32(reader["cli_dni"]);
            this.mail = Convert.ToString(reader["cli_mail"]);
            this.telefono = Convert.ToInt32(reader["cli_telefono"]);
            this.direccion = Convert.ToString(reader["cli_direccion"]);
            this.codigoPostal = Convert.ToInt32(reader["cli_codigoPostal"]);
            this.fechaDeNacimiento = Convert.ToDateTime(reader["cli_fecha_nac"]);
            this.activo = Convert.ToBoolean(reader["cli_activo"]);
            this.idUsuario = Convert.ToInt32(reader["cli_usr_id"]);
        }

        #endregion
    }
}

private String codigoPostal;