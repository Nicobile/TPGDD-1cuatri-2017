using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UberFrba.Exceptions;
using System.Data.SqlClient;

namespace UberFrba.Modelo
{
    class Clientes : Objeto, Mapeable
    {
        private int id;
        private String nombre;
        private String apellido;
        private String mail;
        private int telefono;
        private String direccion;
        private int codigoPostal;
        private long DNI;
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
          /*  if (mail == "")
                throw new CampoVacioException("Mail"); */          /*Saco la excepcion de que el mail este vacio porque puede ser null*/
            this.mail = mail;
        }

        public String GetMail()
        {
            return this.mail;
        }

        public void SetTelefono(String telefono)
        {
            if (telefono == "")
                throw new CampoVacioException("Numero de telefono");
            if (!esNumero(telefono))
                throw new FormatoInvalidoException("Numero de telefono. Ingrese todos los numeros seguidos.");
            this.telefono = Convert.ToInt32(telefono);
        }

        public int GetTelefono()
        {
            return this.telefono;
        }


        public void SetDireccion(String direccion)
        {
            if (direccion == "")
                throw new CampoVacioException("Direccion");
            this.direccion = direccion;
        }

        public String GetDireccion()
        {
            return this.direccion;
        }

        public void SetCodigoPostal(String codPost)
        {
            if (codPost == "")
                throw new CampoVacioException("Codigo postal");

            if (!esNumero(codPost))
                throw new FormatoInvalidoException("Codigo postal. Ingrese todos los numeros seguidos.");  

            this.codigoPostal = Convert.ToInt32(codPost);
        }

        public int GetCodigoPostal()
        {
            return this.codigoPostal;
        }

        public void SetDNI(String numeroDeDocumento)
        {
            if (numeroDeDocumento == "")
                throw new CampoVacioException("Numero de documento");

            if (!esNumero(numeroDeDocumento))
                throw new FormatoInvalidoException("Numero de documento. Ingrese todos los numeros seguidos.");

            this.DNI = Convert.ToInt64(numeroDeDocumento);
        }

        public long GetDNI()
        {
            return this.DNI;
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

        public void SetIdUsuario(int idUsuario)
        {
            this.idUsuario = idUsuario;
        }

        public int GetIdUsuario()
        {
            return this.idUsuario;
        }

        public void SetActivo(Boolean cli_activo)
        {
            this.activo = cli_activo;
        }

        public Boolean GetActivo()
        {
            return this.activo;
        }


        #region Miembros de Comunicable

        string Mapeable.GetQueryCrear()
        {
            return "PUSH_IT_TO_THE_LIMIT.crear_cliente";
        }

        string Mapeable.GetQueryModificar()
        {
            if (activo == true)
            {

                return "UPDATE PUSH_IT_TO_THE_LIMIT.Cliente SET cliente_nombre = @Nombre, cliente_apellido = @Apellido, cliente_mail = @Mail, cliente_telefono = @Telefono, cliente_direccion = @Direccion, cliente_codigo_postal = @Codigo_Postal,cliente_dni = @DNI, cliente_fecha_nacimiento = @Fecha_Nacimiento, cliente_estado = @Activo WHERE cliente_id = @id " +
                " UPDATE PUSH_IT_TO_THE_LIMIT.Usuario SET usuario_intentos = 0 WHERE usuario_id = (SELECT c.usuario_id FROM PUSH_IT_TO_THE_LIMIT.Cliente c WHERE c.cliente_id = @id) ";
            }
            else
            {
                return "UPDATE PUSH_IT_TO_THE_LIMIT.Cliente SET cliente_nombre = @Nombre, cliente_apellido = @Apellido, cliente_mail = @Mail, cliente_telefono = @Telefono, cliente_direccion = @Direccion, cliente_codigo_postal = @Codigo_Postal,cliente_dni = @DNI, cliente_fecha_nacimiento = @Fecha_Nacimiento, cliente_estado = @Activo WHERE cliente_id = @id";
            }


        }

        string Mapeable.GetQueryObtener()
        {
            return "SELECT * FROM PUSH_IT_TO_THE_LIMIT.Cliente WHERE cliente_id = @id";
        }

        IList<System.Data.SqlClient.SqlParameter> Mapeable.GetParametros()
        {
            IList<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Clear();
            parametros.Add(new SqlParameter("@Nombre", this.nombre));
            parametros.Add(new SqlParameter("@Apellido", this.apellido));
            parametros.Add(new SqlParameter("@Mail",this.mail));
            parametros.Add(new SqlParameter("@Telefono", this.telefono));
            parametros.Add(new SqlParameter("@Direccion", this.direccion));
            parametros.Add(new SqlParameter("@Codigo_Postal", this.codigoPostal));
            parametros.Add(new SqlParameter("@Fecha_Nacimiento", this.fechaDeNacimiento));
            parametros.Add(new SqlParameter("@DNI", this.DNI));
            parametros.Add(new SqlParameter("@Activo", this.activo));
            parametros.Add(new SqlParameter("@User_id", this.idUsuario));
            return parametros;
        }

        void Mapeable.CargarInformacion(SqlDataReader reader)
        {
            this.nombre = Convert.ToString(reader["cliente_nombre"]);
            this.apellido = Convert.ToString(reader["cliente_apellido"]);
            this.mail = Convert.ToString(reader["cliente_mail"]);
            this.telefono = Convert.ToInt32(reader["cliente_telefono"]);
            this.direccion = Convert.ToString(reader["cliente_direccion"]);
            try
            {
                this.codigoPostal = Convert.ToInt32(reader["cliente_codigo_postal"]);
            }
            catch (InvalidCastException) { 
            
            //Aca no hace nada , esta asi para que muestre el resto de los datos cuando el cp es nulo ,por que sino no muestra el resto en la 
            //pantalla de editarCliente
            
            }
            this.fechaDeNacimiento = Convert.ToDateTime(reader["cliente_fecha_nacimiento"]);
            this.DNI = Convert.ToInt64(reader["cliente_dni"]);
            this.activo = Convert.ToBoolean(reader["cliente_estado"]);
            this.idUsuario = Convert.ToInt32(reader["usuario_id"]);

        }

        #endregion
    }
}