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
    {/* getters y setters*/
        private int id;
        private String numeroDeDocumento;
        private String nombre;
        private String apellido;
        private String mail;
        private String telefono;
        private String direccion;
        private DateTime fechaDeNacimiento;
        private Boolean activo;
        private int idUsuario;
 

        private IList<SqlParameter> parametros = new List<SqlParameter>();
        private DBMapper mapper = new DBMapper();
        

        public void SetId(int id)
        {
            this.id = id;
        }

        public int GetId()
        {
            return this.id;
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
            return "NET_A_CERO.pr_crear_empresa";
        }

        string Mapeable.GetQueryModificar()
        {
            if (activo == true)
            {
                return "UPDATE NET_A_CERO.Empresas SET emp_razon_social = @razon_social, emp_ciudad = @ciudad, emp_cuit = @cuit, emp_nombre_contacto = @nombre_contacto, emp_rubro = @rubro, emp_fecha_alta = @fecha_alta, emp_activo = @activo WHERE emp_id = @id" +
                    " UPDATE NET_A_CERO.Usuarios SET usr_intentos = 0 WHERE usr_id = (SELECT emp_usr_id FROM NET_A_CERO.Empresas WHERE emp_id = @id) ";
            }
            else
            {
                return "UPDATE NET_A_CERO.Empresas SET emp_razon_social = @razon_social, emp_ciudad = @ciudad, emp_cuit = @cuit, emp_nombre_contacto = @nombre_contacto, emp_rubro = @rubro, emp_fecha_alta = @fecha_alta, emp_activo = @activo WHERE emp_id = @id";
            }

        }

        public string GetQueryObtener()
        {
            return "SELECT * FROM NET_A_CERO.Empresas WHERE emp_id = @id";
        }

        IList<System.Data.SqlClient.SqlParameter> Mapeable.GetParametros()
        {
            IList<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@razon_social", this.razonSocial));
            parametros.Add(new SqlParameter("@ciudad", this.ciudad));
            parametros.Add(new SqlParameter("@cuit", this.cuit));
            parametros.Add(new SqlParameter("@nombre_contacto", this.nombreDeContacto));
            parametros.Add(new SqlParameter("@rubro", this.rubro));
            parametros.Add(new SqlParameter("@fecha_alta", this.fechaDeCreacion));
            parametros.Add(new SqlParameter("@activo", true));
            parametros.Add(new SqlParameter("@cont_id", this.idContacto));
            return parametros;
        }

        public void CargarInformacion(SqlDataReader reader)
        {
            this.razonSocial = Convert.ToString(reader["emp_razon_social"]);
            this.ciudad = Convert.ToString(reader["emp_ciudad"]);
            this.cuit = Convert.ToString(reader["emp_cuit"]);
            this.nombreDeContacto = Convert.ToString(reader["emp_nombre_contacto"]);
            this.rubro = Convert.ToInt32(reader["emp_rubro"]);
            this.fechaDeCreacion = Convert.ToDateTime(reader["emp_fecha_alta"]);
            this.activo = Convert.ToBoolean(reader["emp_activo"]);
            this.idUsuario = Convert.ToInt32(reader["emp_usr_id"]);
            this.idContacto = Convert.ToInt32(reader["emp_cont_id"]);
        }

        #endregion
    }
}