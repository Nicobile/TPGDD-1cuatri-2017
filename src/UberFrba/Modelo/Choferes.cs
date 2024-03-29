using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UberFrba.Exceptions;
using UberFrba.DataProvider;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace UberFrba.Modelo
{
    class Choferes : Objeto, Mapeable
    {
        private int id;
        private int DNI;
        private String nombre;
        private String apellido;
        private String mail;
        private int telefono;
        private String direccion;
        private DateTime fechaDeNacimiento;
        private Boolean activo;
        private int idUsuario;
 

        private IList<SqlParameter> parametros = new List<SqlParameter>();
        private Mapper mapper = new Mapper();
        

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

        private void SetDNIChofer(string DNI)
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

            SetTelefonoChofer(telefono);
        }

        private void SetTelefonoChofer(string telefono)
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


        public void SetFechaDeNacimiento(DateTime fechaDeNacimiento)
        {
            if (fechaDeNacimiento.Equals(DateTime.MinValue))
                throw new CampoVacioException("Fecha De Nacimiento");

            if (!esFechaPasada(fechaDeNacimiento)) 
                throw new FechaInvalidaException();

            this.fechaDeNacimiento = fechaDeNacimiento;
        }

        public DateTime GetFechaDeNacimiento()
        {
           return this.fechaDeNacimiento;
        }


        public void SetActivo(Boolean chofer_activo)
        {
            this.activo = chofer_activo;
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
            return "PUSH_IT_TO_THE_LIMIT.crear_chofer";
        }

        string Mapeable.GetQueryModificar()
        {
            if (activo == true)
            {
                return "UPDATE PUSH_IT_TO_THE_LIMIT.Chofer SET chofer_dni=@DNI, chofer_nombre=@Nombre, chofer_apellido=@Apellido, chofer_mail=@Mail, chofer_direccion=@Direccion, chofer_telefono=@Telefono, chofer_fecha_Nacimiento=@Fecha_Nacimiento, chofer_estado=@Activo, usuario_id=@User_id WHERE chofer_id= @id " +
                       " UPDATE PUSH_IT_TO_THE_LIMIT.Usuario SET usuario_intentos = 0  WHERE usuario_id =  (SELECT usuario_id FROM PUSH_IT_TO_THE_LIMIT.Chofer WHERE chofer_id = @id)";
            }
            else
            {
                return "UPDATE PUSH_IT_TO_THE_LIMIT.Chofer SET chofer_dni = @DNI, chofer_nombre =@Nombre, chofer_apellido =@Apellido, chofer_mail =@Mail, chofer_direccion =@Direccion, chofer_telefono =@Telefono, chofer_fecha_Nacimiento =@Fecha_Nacimiento, chofer_estado =@Activo, usuario_id =@User_id WHERE chofer_id = @id";
            }

        }

        public string GetQueryObtener()
        {
            return "SELECT * FROM PUSH_IT_TO_THE_LIMIT.Chofer WHERE chofer_id = @id";
        }

        IList<System.Data.SqlClient.SqlParameter> Mapeable.GetParametros()
        {
            IList<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@Nombre", this.nombre));
            parametros.Add(new SqlParameter("@Apellido", this.apellido));
            parametros.Add(new SqlParameter("@Mail", this.mail));
            parametros.Add(new SqlParameter("@Telefono", this.telefono));
            parametros.Add(new SqlParameter("@Direccion", this.direccion));
            parametros.Add(new SqlParameter("@Fecha_Nacimiento", this.fechaDeNacimiento));
            parametros.Add(new SqlParameter("@DNI", this.DNI));
            parametros.Add(new SqlParameter("@Activo", this.activo));
            parametros.Add(new SqlParameter("@User_id", this.idUsuario));
            
            return parametros;
        }

        void Mapeable.CargarInformacion(SqlDataReader reader)
        {
            this.DNI = Convert.ToInt32(reader["chofer_dni"]);
            this.nombre = Convert.ToString(reader["chofer_nombre"]);
            this.apellido = Convert.ToString(reader["chofer_apellido"]);
            this.mail = Convert.ToString(reader["chofer_mail"]);
            this.direccion = Convert.ToString(reader["chofer_direccion"]);
            this.telefono = Convert.ToInt32(reader["chofer_telefono"]);
            this.fechaDeNacimiento = Convert.ToDateTime(reader["chofer_fecha_Nacimiento"]);
          //  this.activo = Convert.ToBoolean(reader["chofer_activo"]);
            this.idUsuario = Convert.ToInt32(reader["usuario_id"]);
        }

        #endregion
    }
}
