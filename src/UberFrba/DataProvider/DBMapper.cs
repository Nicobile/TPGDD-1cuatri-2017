using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using UberFrba.Modelo;
using UberFrba.Exceptions;
using UberFrba.DataProvider;
using UberFrba.Utils;
using System.Data;

namespace UberFrba
{
    class DBMapper
    {
        private String query;
        private IList<SqlParameter> parametros = new List<SqlParameter>();
        private SqlParameter parametroOutput;
        private SqlCommand command;


        /*
        *
        *   GENERIC CRUD
        *
        */


        public int Crear(Mapeable objeto)
        {
            query = objeto.GetQueryCrear();
            parametros.Clear();
            parametros = objeto.GetParametros();
            parametroOutput = new SqlParameter("@id", SqlDbType.Int);
            parametroOutput.Direction = ParameterDirection.Output;
            parametros.Add(parametroOutput);
            command = QueryBuilder.Instance.build(query, parametros);
            command.CommandType = CommandType.StoredProcedure;
            command.ExecuteNonQuery();
            return (int)parametroOutput.Value;
        }

        public Boolean Modificar(Decimal id, Mapeable objeto)
        {
            query = objeto.GetQueryModificar();
            parametros.Clear();
            parametros = objeto.GetParametros();
            parametros.Add(new SqlParameter("@id", id));
            
            int filasAfectadas = QueryBuilder.Instance.build(query, parametros).ExecuteNonQuery();
            if (filasAfectadas == 1) return true;
            if (filasAfectadas == 2) return true;
            return false;
        }

        public Mapeable Obtener(Decimal id, Type clase)
        {
            Mapeable objeto = (Mapeable)Activator.CreateInstance(clase);
            query = objeto.GetQueryObtener();
            parametros.Clear();
            parametros.Add(new SqlParameter("@id", id));
            SqlDataReader reader = QueryBuilder.Instance.build(query, parametros).ExecuteReader();
            if (reader.Read())
            {
                objeto.CargarInformacion(reader);
                return objeto;
            }
            return objeto;
        }

        /* public Boolean Eliminar(String idParameter, Decimal id, String enDonde)
         {
             query = "UPDATE NET_A_CERO." + enDonde + " SET dado_de_baja = 1 WHERE id = @id";
             parametros.Clear();
             parametros.Add(new SqlParameter("@"+idParameter, id));
             int filasAfectadas = QueryBuilder.Instance.build(query, parametros).ExecuteNonQuery();
             if (filasAfectadas == 1) return true;
             return false;
         }
         * */

        /*
        *
        *   CREATE TABLE QUERYS
        *
        */


        /** Usuarios **/

        public int CrearUsuario()
        {
            
                query = "PUSH_IT_TO_THE_LIMIT.pr_crear_usuario";
                parametros.Clear();
                parametroOutput = new SqlParameter("@usuario_id", SqlDbType.Int);
                parametroOutput.Direction = ParameterDirection.Output;
                parametros.Add(parametroOutput);
                command = QueryBuilder.Instance.build(query, parametros);
                command.CommandType = CommandType.StoredProcedure;
                command.ExecuteNonQuery();
                return (int)parametroOutput.Value;
           
        }

        public int CrearUsuarioConValores(String username, String password)
        {
            query = "PUSH_IT_TO_THE_LIMIT.pr_crear_usuario_con_valores";
            parametros.Clear();
            parametroOutput = new SqlParameter("@usuario_id", SqlDbType.Int);
            parametroOutput.Direction = ParameterDirection.Output;
            parametros.Add(new SqlParameter("@username", username));
            parametros.Add(new SqlParameter("@password", HashSha256.getHash(password)));
            parametros.Add(parametroOutput);
            command = QueryBuilder.Instance.build(query, parametros);
            command.CommandType = CommandType.StoredProcedure;
            command.ExecuteNonQuery();
            return (int)parametroOutput.Value;
        }

        /** Clientes **/

        public int CrearCliente(Clientes cliente)
        {

     /*       if (!esClienteUnico(cliente.GetTipoDeDocumento(), cliente.GetId()))
                throw new ClienteYaExisteException();    */

            return this.Crear(cliente);

        }

        /** Empresas **/

        public int CrearChofer(Choferes chofer)
        {


            return this.Crear(chofer);
        }

        /** Turnos **/
        public int CrearTurno(Turnos turno)
        {


            return this.Crear(turno);
        }

        /*
        *
        *   GET TABLE QUERYS
        *
        */


        /** Usuarios **/

        public Usuarios ObtenerUsuario(int idUsuario)
        {
            Usuarios objeto = new Usuarios();
            Type clase = objeto.GetType();
            return (Usuarios)this.Obtener(idUsuario, clase);
        }

        /** Clientes **/

        public Clientes ObtenerCliente(int idCliente)
        {
            Clientes objeto = new Clientes();
            Type clase = objeto.GetType();
            return (Clientes)this.Obtener(idCliente, clase);
        }

        /** Choferes **/

        public Choferes ObtenerChofer(int idChofer)
        {
            Choferes objeto = new Choferes();
            Type clase = objeto.GetType();
            return (Choferes)this.Obtener(idChofer, clase);
        }

        /** Turnos **/
        public Turnos ObtenerTurnos(int idTurno)
        {
            Turnos objeto = new Turnos();
            Type clase = objeto.GetType();
            return (Turnos)this.Obtener(idTurno, clase);
        }

        /** Contacto **/
/*
        public Contacto ObtenerContacto(int idContacto)
        {
            Contacto objeto = new Contacto();
            Type clase = objeto.GetType();
            return (Contacto)this.Obtener(idContacto, clase);
        }


*/

        /* 
        * 
        *   DELETE QUERYS
        *
        */


        /** Clientes **/

        public Boolean EliminarCliente(int id, String enDonde)
        {
            query = "UPDATE PUSH_IT_TO_THE_LIMIT." + enDonde + " SET cliente_estado = 0 WHERE cliente_id = @id";
            parametros.Clear();
            parametros.Add(new SqlParameter("@id", id));
            int filasAfectadas = QueryBuilder.Instance.build(query, parametros).ExecuteNonQuery();
            if (filasAfectadas == 1) return true;
            return false;
        }

        public Boolean EliminarChofer(Decimal id, String enDonde)
        {
            query = "UPDATE PUSH_IT_TO_THE_LIMIT." + enDonde + " SET chofer_estado = 0 WHERE chofer_id = @id";
            parametros.Clear();
            parametros.Add(new SqlParameter("@id", id));
            int filasAfectadas = QueryBuilder.Instance.build(query, parametros).ExecuteNonQuery();
            if (filasAfectadas == 1) return true;
            return false;
        }

        public Boolean EliminarTurno(Decimal id, String enDonde)
        {
            query = "UPDATE PUSH_IT_TO_THE_LIMIT." + enDonde + " SET turno_habilitado = 0 WHERE turno_id = @id";
            parametros.Clear();
            parametros.Add(new SqlParameter("@id", id));
            int filasAfectadas = QueryBuilder.Instance.build(query, parametros).ExecuteNonQuery();
            if (filasAfectadas == 1) return true;
            return false;
        }



        /*
         * 
         *  ENABLE/DISABLE QUERYS
         *  
         */

        public Boolean ActualizarEstadoUsuario(Decimal id, bool activo)
        {
            parametros.Clear();
            parametros.Add(new SqlParameter("@id", id));
            if (activo)
            {
                query = "UPDATE PUSH_IT_TO_THE_LIMIT.Chofer SET chofer_estado = 1 WHERE chofer_id = @id";
            }
            else
            {
                query = "UPDATE PUSH_IT_TO_THE_LIMIT.Chofer SET chofer_estado = 0 WHERE chofer_id = 8";
            }
            int filasAfectadas = QueryBuilder.Instance.build(query, parametros).ExecuteNonQuery();
                
            if (filasAfectadas == 1) return true;
            return false;
        }


        /* 
        * 
        *   ASSIGN QUERYS
        *
        */

        public Boolean AsignarUsuarioACliente(Decimal idCliente, Decimal idUsuario)
        {
            query = "UPDATE PUSH_IT_TO_THE_LIMIT.Cliente SET usuario_id = @idUsuario WHERE cliente_id = @idCliente";
            parametros.Clear();
            parametros.Add(new SqlParameter("@idUsuario", idUsuario));
            parametros.Add(new SqlParameter("@idCliente", idCliente));
            command = QueryBuilder.Instance.build(query, parametros);
            int filasAfectadas = command.ExecuteNonQuery();
            if (filasAfectadas == 1) return true;
            return false;
        }
        public Boolean AsignarUsuarioAChofer(Decimal idChofer, Decimal idUsuario)
        {
            query = "UPDATE PUSH_IT_TO_THE_LIMIT.Chofer SET usuario_id = @idUsuario WHERE chofer_id = @idChofer";
            parametros.Clear();
            parametros.Add(new SqlParameter("@idUsuario", idUsuario));
            parametros.Add(new SqlParameter("@idChofer", idChofer));
            command = QueryBuilder.Instance.build(query, parametros);
            int filasAfectadas = command.ExecuteNonQuery();
            if (filasAfectadas == 1) return true;
            return false;
        }


        public Boolean AsignarRolAUsuario(Decimal idUsuario, String rol)
        {
            Decimal idRol = Convert.ToDecimal(this.SelectFromWhere("rol_id", "Rol", "rol_nombre", rol));
            query = "PUSH_IT_TO_THE_LIMIT.pr_agregar_rol_a_usuario";
            parametros.Clear();
            parametros.Add(new SqlParameter("@usuario_id", idUsuario));
            parametros.Add(new SqlParameter("@rol_id", idRol));
            command = QueryBuilder.Instance.build(query, parametros);
            command.CommandType = CommandType.StoredProcedure;
            int filasAfectadas = command.ExecuteNonQuery();
            if (filasAfectadas == 1) return true;
            return false;
        }


        /* 
        * 
        *   SELECT QUERYS
        *
        */


        public Object SelectFromWhere(String que, String deDonde, String param1, String param2)
        {
            query = "SELECT " + que + " FROM PUSH_IT_TO_THE_LIMIT." + deDonde + " WHERE " + param1 + " = @" + param1;
            parametros.Clear();
            parametros.Add(new SqlParameter("@" + param1, param2));
            return QueryBuilder.Instance.build(query, parametros).ExecuteScalar();
        }

        public Object SelectFromWhere(String que, String deDonde, String param1, Decimal param2)
        {
            query = "SELECT " + que + " FROM PUSH_IT_TO_THE_LIMIT." + deDonde + " WHERE " + param1 + " = @" + param1;
            parametros.Clear();
            parametros.Add(new SqlParameter("@" + param1, param2));
            return QueryBuilder.Instance.build(query, parametros).ExecuteScalar();
        }

        public Object SelectFromWhere(String que, String deDonde, String param1, int param2)
        {
            query = "SELECT " + que + " FROM PUSH_IT_TO_THE_LIMIT." + deDonde + " WHERE " + param1 + " = @" + param1;
            parametros.Clear();
            parametros.Add(new SqlParameter("@" + param1, param2));
            return QueryBuilder.Instance.build(query, parametros).ExecuteScalar();
        }

        public DataTable SelectDataTable(String que, String deDonde)
        {
            parametros.Clear();
            command = QueryBuilder.Instance.build("SELECT " + que + " FROM " + deDonde, parametros);
            DataSet datos = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            adapter.Fill(datos);
            return datos.Tables[0];
        }

        public DataTable SelectDataTable(String que, String deDonde, String condiciones)
        {
            return this.SelectDataTableConUsuario(que, deDonde, condiciones);
        }

        public DataTable SelectDataTableConUsuario(String que, String deDonde, String condiciones)
        {
            parametros.Clear();
            parametros.Add(new SqlParameter("@idUsuario", UsuarioSesion.Usuario.id));
            command = QueryBuilder.Instance.build("SELECT " + que + " FROM " + deDonde + " WHERE " + condiciones, parametros);
            command.CommandTimeout = 0;
            DataSet datos = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            adapter.Fill(datos);
            return datos.Tables[0];
        }

        /*
        *
        *   SELECT TABLE QUERYS
        *
        */

        /** Clientes **/

        public DataTable SelectClientesParaFiltro()
        {
            return this.SelectClientesParaFiltroConFiltro("");
        }

        public DataTable SelectClientesParaFiltroConFiltro(String filtro)
        {

            return this.SelectDataTable("cli.cliente_id, usr.usuario_name Username, cli.cliente_nombre Nombre, cli.cliente_apellido Apellido, cli.cliente_dni Documento, cli.cliente_fecha_nacimiento 'Fecha de Nacimiento', cli.cliente_mail Mail, cli.cliente_telefono Telefono, cli.cliente_direccion Direccion,  cli.cliente_codigo_postal 'Codigo Postal', cli.cliente_estado 'Habilitado' "
                , "PUSH_IT_TO_THE_LIMIT.Cliente cli, PUSH_IT_TO_THE_LIMIT.Usuario usr"
                , "cli.usuario_id = usr.usuario_id  " + filtro);
        }

        /** Choferes **/

        public DataTable SelectChoferParaFiltro()
        {
            return this.SelectChoferesParaFiltroConFiltro("");
        }

        public DataTable SelectChoferesParaFiltroConFiltro(String filtro)
        {
            return this.SelectDataTable("c.chofer_id,c.usuario_id , usr.usuario_name Username, c.chofer_nombre 'Nombre', c.chofer_dni 'DNI', c.chofer_apellido 'Apellido', c.chofer_direccion 'Direccion', c.chofer_telefono 'Telefono',c.chofer_mail 'Mail',c.chofer_fecha_Nacimiento 'Fecha Nacimiento', c.chofer_estado 'Habilitado' "
              , "PUSH_IT_TO_THE_LIMIT.Chofer c, PUSH_IT_TO_THE_LIMIT.Usuario usr"
              , "c.usuario_id = usr.usuario_id " + filtro);
        }

        /** Turnos **/

        public DataTable SelectTurnoParaFiltro()
        {
            return this.SelectTurnosParaFiltroConFiltro("");
        }

        public DataTable SelectTurnosParaFiltroConFiltro(String filtro)
        {
            return this.SelectDataTable("t.turno_id 'Turno N°',t.turno_hora_inicio 'Hora Inicio',t.turno_hora_fin 'Hora Fin',t.turno_descripcion 'Descripcion',t.turno_valor_Kilometro 'Valor Kilometro',t.turno_precio_base 'Precio Base',t.turno_habilitado 'Habilitado' "
              , "PUSH_IT_TO_THE_LIMIT.Turno t "
              + filtro);
        }

        /*
        *
        *   TABLE UNIQUE CONTROL 
        *
        */

        private bool ControlDeUnicidad(String query, IList<SqlParameter> parametros)
        {
            int cantidad = (int)QueryBuilder.Instance.build(query, parametros).ExecuteScalar();
            if (cantidad > 0)
            {
                return false;
            }
            return true;
        }

        //  TODO: QUITAR SI NO SE UTILIZA

        /*private bool esUnico(String que, String aQue, String enDonde)
        {
            query = "SELECT COUNT(*) FROM NET_A_CERO." + enDonde + " WHERE " + aQue + " = @" + aQue;
            parametros.Clear();
            parametros.Add(new SqlParameter("@" + aQue, que));
            return ControlDeUnicidad(query, parametros);
        }

        private bool esUnico(String que, String aQue, String enDonde, Decimal id)
        {
            query = "SELECT COUNT(*) FROM NET_A_CERO." + enDonde + " WHERE " + aQue + " = @" + aQue + " AND id != " + id;
            parametros.Clear();
            parametros.Add(new SqlParameter("@" + aQue, que));
            return ControlDeUnicidad(query, parametros);
        }
        */

        /** Clientes **/
        private bool esClienteUnico(String numeroDeDocumento, int idCliente)
        {
            query = "SELECT COUNT(*) FROM PUSH-IT-TO-THE-LIMIT.Cliente WHERE  AND cliente_dni = @numeroDeDocumento AND cliente_id != @idCliente";
            parametros.Clear();

            parametros.Add(new SqlParameter("@numeroDeDocumento", numeroDeDocumento));
            parametros.Add(new SqlParameter("@idCliente", idCliente));
            return ControlDeUnicidad(query, parametros);
        }


        private bool esClienteUnico(String numeroDeDocumento)
        {
            query = "SELECT COUNT(*) PUSH-IT-TO-THE-LIMIT.Cliente  AND cliente_dni = @numeroDeDocumento";
            parametros.Clear();

            parametros.Add(new SqlParameter("@numeroDeDocumento", Convert.ToDecimal(numeroDeDocumento)));
            return ControlDeUnicidad(query, parametros);
        }

      
        /** Choferes **/

        private bool esChoferUnico(String numeroDocumento)
        {
            query = "SELECT COUNT(*) PUSH-IT-TO-THE-LIMIT.Chofer  AND cliente_dni = @numeroDeDocumento";
            parametros.Clear();

            parametros.Add(new SqlParameter("@numeroDeDocumento", Convert.ToDecimal(numeroDocumento)));
            return ControlDeUnicidad(query, parametros);
        }

        private bool esChoferUnico(String numeroDeDocumento, int idChofer)
        {
            query = "SELECT COUNT(*) FROM PUSH-IT-TO-THE-LIMIT.Chofer WHERE  AND chofer_dni = @numeroDeDocumento AND chofer_id != @idChofer";
            parametros.Clear();

            parametros.Add(new SqlParameter("@numeroDeDocumento", numeroDeDocumento));
            parametros.Add(new SqlParameter("@idChofer", idChofer));
            return ControlDeUnicidad(query, parametros);
        }


    }
}