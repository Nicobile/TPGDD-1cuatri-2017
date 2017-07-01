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
using System.Configuration;
using System.Windows.Forms;
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
            if (filasAfectadas == 3) return true;
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




        public void ActualizarUsuarioyPassword(int idUsuario, String nombre, String password)
        {
            String contrasenia = HashSha256.getHash(password);

            query = "PUSH_IT_TO_THE_LIMIT.pr_usuario_nombre_password";
            parametros.Clear();
            parametros.Add(new SqlParameter("@idUsuario", idUsuario));
            parametros.Add(new SqlParameter("@nombreUsuario", nombre));
            parametros.Add(new SqlParameter("@passwordUsuario", contrasenia));
            command = QueryBuilder.Instance.build(query, parametros);
            command.CommandType = CommandType.StoredProcedure;
            command.ExecuteNonQuery();
        }


        public void ActualizarFacturaIdenRegistrViaje(int idFactura,DateTime fechaInicio,DateTime fechaFin,int idCliente)
        {

            query = "PUSH_IT_TO_THE_LIMIT.pr_actualizar_factura_registroviaje";
            parametros.Clear();
            parametros.Add(new SqlParameter("@idFactura", idFactura));
            parametros.Add(new SqlParameter("@FechaInicio", fechaInicio));
            parametros.Add(new SqlParameter("@FechaFin", fechaFin));
            parametros.Add(new SqlParameter("@idCliente", idCliente));
            command = QueryBuilder.Instance.build(query, parametros);
            command.CommandType = CommandType.StoredProcedure;
            command.ExecuteNonQuery();
        }

        public void ActualizarRendicionIdenRegistrViaje(int idRendicion,DateTime fecha,int idChofer,String idTurno)
        {

            int IDTurno = Convert.ToInt32(idTurno);

            query = "PUSH_IT_TO_THE_LIMIT.pr_actualizar_rendicion_registroviaje";
            parametros.Clear();
            parametros.Add(new SqlParameter("@idRendicion", idRendicion));
            parametros.Add(new SqlParameter("@Fecha", fecha));
            parametros.Add(new SqlParameter("@idChofer", idChofer));
            parametros.Add(new SqlParameter("@idTurno",IDTurno));
            command = QueryBuilder.Instance.build(query, parametros);
            command.CommandType = CommandType.StoredProcedure;
            command.ExecuteNonQuery();
        }


        public DataTable SelectDataTableRegistroViaje(int idCliente,int idTurno)
        {
            parametros.Clear();
            parametros.Add(new SqlParameter("@idTurno",idTurno));
            parametros.Add(new SqlParameter("@idChofer", idCliente));
            command = QueryBuilder.Instance.build("select viaje_id 'Viaje N°',chofer_id,auto_id,factura_id,T.turno_id,viaje_cantidad_km 'Cantidad Km',rendicion_id,viaje_fecha'Fecha',viaje_hora_inicio'Hora Inicio',viaje_hora_fin'Hora Fin',cliente_id ,'Total Viaje'=CASE WHEN (viaje_cantidad_km * T.turno_valor_kilometro) < T.turno_precio_base THEN T.turno_precio_base ELSE viaje_cantidad_km * T.turno_valor_kilometro	END,T.turno_descripcion 'Turno'	from PUSH_IT_TO_THE_LIMIT.RegistroViaje R JOIN PUSH_IT_TO_THE_LIMIT.Turno T ON(R.turno_id = T.turno_id) WHERE (@idTurno = turno_id) AND  AND factura_id IS NULL AND chofer_id =@idChofer", parametros);
            DataSet datos = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            adapter.Fill(datos);
            return datos.Tables[0];
        }
        public DataTable AplicarEstadistica(int anio, int trimestre, String funcion)
        {
            /* me conectto con la base para obtener el resultado de aplocar la funcion*/
            String config = ConfigurationManager.AppSettings["archConexionConSQL"];
            SqlConnection conexion = new SqlConnection(config);
                 try
            {
                conexion.Open();
            }
            catch (Exception) { MessageBox.Show("Error en conexion"); }


            string query = "SELECT * From [PUSH_IT_TO_THE_LIMIT]." + funcion + "(@anio, @trimestre)";
            SqlCommand command = new SqlCommand(query, conexion);

            command.Parameters.AddWithValue("@anio", anio);


            command.Parameters.AddWithValue("@trimestre", trimestre);
            /*para mostrar el resultado*/
            DataTable tabla = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(tabla);
            return tabla;
        }

        public bool ExisteRendicion(String fecha, int idchofer)
        {
                        
            this.query = "SELECT * From [PUSH_IT_TO_THE_LIMIT].fx_verificarRendicion(@fecha,@idchofer)";
            parametros.Clear();            
            parametros.Add(new SqlParameter("@fecha", fecha));
            parametros.Add(new SqlParameter("@idchofer", idchofer));
            int filasAfectadas = Convert.ToInt32(QueryBuilder.Instance.build(this.query, parametros).ExecuteScalar());
            if (filasAfectadas == 0)
                return false;
            else
                return true;
        }








        /** Clientes **/

        public int CrearCliente(Clientes cliente)
        {

     /*       if (!esClienteUnico(cliente.GetTipoDeDocumento(), cliente.GetId()))
                throw new ClienteYaExisteException();    */

            return this.Crear(cliente);

        }

        /** Chofer **/

        public int CrearChofer(Choferes chofer)
        {


            return this.Crear(chofer);
        }

        /** Turnos **/
        public int CrearTurno(Turnos turno)
        {


            return this.Crear(turno);
        }
        
        /** Automoviles **/
        public int CrearAutomoviles(Automoviles automovil)
        {
          return this.Crear(automovil);
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

        /* Automoviles */
        public Automoviles ObtenerAutomovil(int idAutomovil)
        {
            Automoviles objeto = new Automoviles();
            Type clase = objeto.GetType();
            return (Automoviles)this.Obtener(idAutomovil, clase);
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
            if (filasAfectadas == 2)//dejar en dos es la cantidad que retorna la base (lo volvi a poner en 1 por que el triger actualizacion turno no esta funcionando)
            {
                return true;
            }
            return false;
        }

        public Boolean EliminarAutomovil(Decimal id, String enDonde)
        {
            query = "UPDATE PUSH_IT_TO_THE_LIMIT." + enDonde + " SET auto_estado = 0 WHERE auto_id = @id";
            parametros.Clear();
            parametros.Add(new SqlParameter("@id", id));
            int filasAfectadas = QueryBuilder.Instance.build(query, parametros).ExecuteNonQuery();
            if (filasAfectadas == 1)
            {
                return true;
            }
            return false;
        }











        public Boolean EliminarAutoFisicamenteDelaBase(int id, String enDonde)
        {
            query = "DELETE PUSH_IT_TO_THE_LIMIT." + enDonde + " WHERE auto_id = @id";
            parametros.Clear();
            parametros.Add(new SqlParameter("@id", id));
            int filasAfectadas = QueryBuilder.Instance.build(query, parametros).ExecuteNonQuery();
            if (filasAfectadas == 1)
            {
                return true;
            }
            return false;
        }



        //traer Registros 

                public DataTable SelectDataTableRegistroViaje(String fechaInicio, String fechaFin, int idCliente)
         {
             parametros.Clear();
             parametros.Add(new SqlParameter("@fechaInicio", fechaInicio));
             parametros.Add(new SqlParameter("@fechaFin", fechaFin));
             parametros.Add(new SqlParameter("@idCliente", idCliente));
             command = QueryBuilder.Instance.build("select viaje_id 'Viaje N°',chofer_id,auto_id,factura_id,T.turno_id,viaje_cantidad_km 'Cantidad Km',rendicion_id,viaje_fecha'Fecha',viaje_hora_inicio'Hora Inicio',viaje_hora_fin'Hora Fin',cliente_id ,'Total Viaje'=CASE WHEN (viaje_cantidad_km * T.turno_valor_kilometro) < T.turno_precio_base THEN T.turno_precio_base ELSE viaje_cantidad_km * T.turno_valor_kilometro	END,T.turno_descripcion 'Turno'	from PUSH_IT_TO_THE_LIMIT.RegistroViaje R JOIN PUSH_IT_TO_THE_LIMIT.Turno T ON(R.turno_id = T.turno_id) WHERE viaje_fecha>=@fechaInicio AND viaje_fecha<=@fechaFin AND factura_id IS NULL AND cliente_id =@idCliente", parametros);
             DataSet datos = new DataSet();
             SqlDataAdapter adapter = new SqlDataAdapter();
             adapter.SelectCommand = command;
             adapter.Fill(datos);
             return datos.Tables[0];
         }



        public DataTable SelectDataTableRegistroViajeparaRendi(String fecha, int idChofer, String idTurno)
        {
            int IDTurno = Convert.ToInt32(idTurno);
            parametros.Clear();
            parametros.Add(new SqlParameter("@fecha", fecha));
            parametros.Add(new SqlParameter("@idChofer", idChofer));
            parametros.Add(new SqlParameter("@idTurno", IDTurno));
            command = QueryBuilder.Instance.build("select viaje_id 'Viaje N°',chofer_id,auto_id,factura_id,T.turno_id,viaje_cantidad_km 'Cantidad Km',rendicion_id,viaje_fecha'Fecha',viaje_hora_inicio'Hora Inicio',viaje_hora_fin'Hora Fin',cliente_id ,'Total Viaje'=CASE WHEN (viaje_cantidad_km * T.turno_valor_kilometro) < T.turno_precio_base THEN T.turno_precio_base ELSE viaje_cantidad_km * T.turno_valor_kilometro	END,T.turno_descripcion 'Turno'	from PUSH_IT_TO_THE_LIMIT.RegistroViaje R JOIN PUSH_IT_TO_THE_LIMIT.Turno T ON R.turno_id = T.turno_id AND R.turno_id = @idTurno AND T.turno_id = @idTurno WHERE viaje_fecha = @fecha AND rendicion_id IS NULL AND chofer_id = @idChofer", parametros);
            DataSet datos = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            adapter.Fill(datos);
            return datos.Tables[0];
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

        public Boolean ActualizarEstadoTurnoAutomovil(int idAutomovil, int idTurno , int estado)
        {
            parametros.Clear();
            parametros.Add(new SqlParameter("@idAutomovil", idAutomovil));
            parametros.Add(new SqlParameter("@idTurno", idTurno));
            parametros.Add(new SqlParameter("@estado",estado));
            query = "UPDATE PUSH_IT_TO_THE_LIMIT.AutoporTurno SET auto_turno_estado =@estado WHERE auto_id=@idAutomovil AND turno_id=@idTurno";
            int filasAfectadas = QueryBuilder.Instance.build(query, parametros).ExecuteNonQuery();

            if (filasAfectadas == 1) return true;
            return false;
        }


        public Boolean ExisteEstadoTunoAutomovil(int idAutomovil, int idTurno)
        {
            parametros.Clear();
            parametros.Add(new SqlParameter("@idAutomovil", idAutomovil));
            parametros.Add(new SqlParameter("@idTurno", idTurno));
            query = "SELECT COUNT(*) FROM PUSH_IT_TO_THE_LIMIT.AutoporTurno WHERE auto_id=@idAutomovil AND turno_id=@idTurno";
            object existe=  QueryBuilder.Instance.build(query, parametros).ExecuteScalar();
             existe.ToString();

            if (existe.ToString() == "1") return true;
            return false;
        }


        public String CantidadDeViajesFactura(String fechaInicio,String fechaFin, int idCliente)
        {
            parametros.Clear();
            parametros.Add(new SqlParameter("@fechaInicio", fechaInicio));
            parametros.Add(new SqlParameter("@fechaFin", fechaFin));
            parametros.Add(new SqlParameter("@idCliente", idCliente));
            query = "SELECT COUNT(*) FROM (SELECT viaje_id 'Viaje N°',chofer_id,auto_id,factura_id,turno_id,viaje_cantidad_km 'Cantidad Km',rendicion_id,viaje_fecha'Fecha',viaje_hora_inicio'Hora Inicio',viaje_hora_fin'Hora Fin',cliente_id from PUSH_IT_TO_THE_LIMIT.RegistroViaje WHERE viaje_fecha>=@fechaInicio AND viaje_fecha<=@fechaFin AND factura_id IS NULL AND cliente_id =@idCliente) viajes ";
            object cantidadViajes = QueryBuilder.Instance.build(query, parametros).ExecuteScalar();
              String viajes = cantidadViajes.ToString();

            return viajes;
        }

        public String TotalFactura(String fechaInicio, String fechaFin,int idCliente)
        {
            parametros.Clear();
            parametros.Add(new SqlParameter("@fechaInicio", fechaInicio));
            parametros.Add(new SqlParameter("@fechaFin", fechaFin));
            parametros.Add(new SqlParameter("@idCliente", idCliente));
            query = "SELECT SUM(VIAJES.[Total Viaje]) FROM (select viaje_id 'Viaje N°',chofer_id,auto_id,factura_id,T.turno_id,viaje_cantidad_km 'Cantidad Km',rendicion_id,viaje_fecha'Fecha',viaje_hora_inicio'Hora Inicio',viaje_hora_fin'Hora Fin',cliente_id ,'Total Viaje'= CASE WHEN (viaje_cantidad_km * T.turno_valor_kilometro) < T.turno_precio_base THEN T.turno_precio_base ELSE viaje_cantidad_km * T.turno_valor_kilometro END from PUSH_IT_TO_THE_LIMIT.RegistroViaje R JOIN PUSH_IT_TO_THE_LIMIT.Turno T ON(R.turno_id = T.turno_id) WHERE viaje_fecha>=@fechaInicio AND viaje_fecha<=@fechaFin AND factura_id IS NULL AND cliente_id =@idCliente) VIAJES";
            object cantidadViajes = QueryBuilder.Instance.build(query, parametros).ExecuteScalar();
            String viajes = cantidadViajes.ToString();
            return viajes;
        }

        public String TotalRendicion(String fecha, int idChofer, String idTurno)
        {
            int IDTurno = Convert.ToInt32(idTurno);
            parametros.Clear();
            parametros.Add(new SqlParameter("@fecha", fecha));
            parametros.Add(new SqlParameter("@idChofer", idChofer));
            parametros.Add(new SqlParameter("@idTurno", IDTurno));
            query = "SELECT (SUM(VIAJES.[Total Viaje]))*0.3 FROM (select viaje_id 'Viaje N°',chofer_id,auto_id,factura_id,T.turno_id,viaje_cantidad_km 'Cantidad Km',rendicion_id,viaje_fecha'Fecha',viaje_hora_inicio'Hora Inicio',viaje_hora_fin'Hora Fin',cliente_id ,'Total Viaje'= CASE WHEN (viaje_cantidad_km * T.turno_valor_kilometro) < T.turno_precio_base THEN T.turno_precio_base ELSE viaje_cantidad_km * T.turno_valor_kilometro END from PUSH_IT_TO_THE_LIMIT.RegistroViaje R JOIN PUSH_IT_TO_THE_LIMIT.Turno T ON(R.turno_id = T.turno_id AND R.turno_id = @idTurno AND T.turno_id = @idTurno) WHERE @fecha = viaje_fecha AND rendicion_id IS NULL AND chofer_id =@idChofer) VIAJES";
            object cantidadViajes = QueryBuilder.Instance.build(query, parametros).ExecuteScalar();
            String viajes = cantidadViajes.ToString();
            return viajes;
        }





        public String ObtenerPatenteAutomovil(int idChofer)
        {
            parametros.Clear();
            parametros.Add(new SqlParameter("@idChofer", idChofer));
            query = "SELECT auto_patente FROM PUSH_IT_TO_THE_LIMIT.Auto WHERE auto_id = (SELECT auto_id FROM PUSH_IT_TO_THE_LIMIT.ChoferporAuto where chofer_id=@idChofer AND auto_chofer_estado=1)";
            object patenteAutomovil = QueryBuilder.Instance.build(query, parametros).ExecuteScalar();
            return patenteAutomovil.ToString();
        }





        public Boolean ExisteChoferAutomovil(int idAutomovil, int idChofer)
        {
            parametros.Clear();
            parametros.Add(new SqlParameter("@idAutomovil", idAutomovil));
            parametros.Add(new SqlParameter("@idChofer", idChofer));
            query = "SELECT COUNT(*) FROM PUSH_IT_TO_THE_LIMIT.ChoferporAuto WHERE auto_id=@idAutomovil AND chofer_id=@idChofer";
            object existe = QueryBuilder.Instance.build(query, parametros).ExecuteScalar();
            existe.ToString();

            if (existe.ToString() == "1") return true;
            return false;
        }
        public Boolean ExisteChoferAutomovilActivo(int idChofer,int idAutomovil,int estado)
        {
            parametros.Clear();
            parametros.Add(new SqlParameter("@idChofer", idChofer));
            parametros.Add(new SqlParameter("@estado", estado));
            parametros.Add(new SqlParameter("@idAutomovil", idAutomovil));
            query = "SELECT COUNT(*) FROM PUSH_IT_TO_THE_LIMIT.ChoferporAuto WHERE  chofer_id=@idChofer AND auto_chofer_estado=@estado AND auto_id <> @idAutomovil";
            object existe = QueryBuilder.Instance.build(query, parametros).ExecuteScalar();
            existe.ToString();

            if (existe.ToString() == "1") return true;
            return false;
        }


        public Boolean ActualizarEstadoChoferAutomovil(int idAutomovil, int idChofer, int estado)
        {
            parametros.Clear();
            parametros.Add(new SqlParameter("@idAutomovil", idAutomovil));
            parametros.Add(new SqlParameter("@idChofer", idChofer));
            parametros.Add(new SqlParameter("@estado", estado));
            query = "UPDATE PUSH_IT_TO_THE_LIMIT.ChoferporAuto SET auto_chofer_estado =@estado WHERE auto_id=@idAutomovil AND chofer_id=@idChofer";
            int filasAfectadas = QueryBuilder.Instance.build(query, parametros).ExecuteNonQuery();

            if (filasAfectadas == 1) return true;
            return false;
        }


        public Boolean AgregarChoferAutomovil(int idAutomovil, int idChofer)
        {
            parametros.Clear();
            parametros.Add(new SqlParameter("@idAutomovil", idAutomovil));
            parametros.Add(new SqlParameter("@idChofer", idChofer));

            query = "INSERT INTO PUSH_IT_TO_THE_LIMIT.ChoferporAuto (auto_id,chofer_id) values(@idAutomovil,@idChofer)";

            int filasAfectadas = QueryBuilder.Instance.build(query, parametros).ExecuteNonQuery();
            if (filasAfectadas == 1) return true;
            return false;
        }


        public int obtenerIdChoferApartirDelDNI(String dniChofer)
        {


            int idChoferObtenidoApartirDelDNI = Convert.ToInt32(this.SelectFromWhere("chofer_id", "Chofer", "chofer_dni", Convert.ToInt32(dniChofer)));
            if (idChoferObtenidoApartirDelDNI == 0) throw new ChoferInexistenteException("No existe un chofer con DNI igual a : "+dniChofer);
            return idChoferObtenidoApartirDelDNI;

        }

        public int obtenerIdAutomovilApartirDeLaPatente(String patenteAuto)
        {

            int idAutomovilObtenidoApartirDelDNI = Convert.ToInt32(this.SelectFromWhere("auto_id", "Auto", "auto_patente", patenteAuto));
            if (idAutomovilObtenidoApartirDelDNI == 0) throw new PatenteAutomovilInexistente("No existe un Automovil con Patente igual a : " +patenteAuto);
            return idAutomovilObtenidoApartirDelDNI;

        }

        public int obtenerIdClienteApartirDelDNI(String dniCliente)
        {

            int idClienteObtenidoApartirDelDNI = Convert.ToInt32(this.SelectFromWhere("cliente_id", "Cliente", "cliente_dni", Convert.ToInt32(dniCliente)));
            if (idClienteObtenidoApartirDelDNI == 0) throw new ClienteInexistenteException("No existe un Cliente con DNI N° : " +dniCliente) ;
            return idClienteObtenidoApartirDelDNI;

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







        public Boolean AsignarTurnoaAutomovil(int idAuto, int idTurno)
        {
            query = "PUSH_IT_TO_THE_LIMIT.pr_agregar_turno_a_automovil";
            parametros.Clear();
            parametros.Add(new SqlParameter("@turno_id", idTurno));
            parametros.Add(new SqlParameter("@auto_id", idAuto));
            command = QueryBuilder.Instance.build(query, parametros);
            command.CommandType = CommandType.StoredProcedure;
            int filasAfectadas = command.ExecuteNonQuery();
            if (filasAfectadas == 1) return true;
            return false;
        }


        public Boolean AsignarChoferaAutomovil(int idAuto, int idChofer)
        {
            query = "PUSH_IT_TO_THE_LIMIT.pr_agregar_chofer_a_automovil";
            parametros.Clear();
            parametros.Add(new SqlParameter("@chofer_id", idChofer));
            parametros.Add(new SqlParameter("@auto_id", idAuto));
            command = QueryBuilder.Instance.build(query, parametros);
            command.CommandType = CommandType.StoredProcedure;
            int filasAfectadas = command.ExecuteNonQuery();
            if (filasAfectadas == 1) return true;
            return false;
        }


        public Boolean AgregarTurnoAutomovil(int idAutomovil, int idTurno)
        {
            parametros.Clear();
            parametros.Add(new SqlParameter("@idAutomovil", idAutomovil));
            parametros.Add(new SqlParameter("@idTurno", idTurno));
            
            query = "INSERT INTO PUSH_IT_TO_THE_LIMIT.AutoporTurno (auto_id,turno_id) values(@idAutomovil,@idTurno)";

            int filasAfectadas = QueryBuilder.Instance.build(query, parametros).ExecuteNonQuery();
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


        public DataTable ObtenerTurnosHabilitadosAutmovil(int idAutomovil)
        {

            DataSet turnosAutomovil = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            parametros = new List<SqlParameter>();
            parametros.Clear();
            parametros.Add(new SqlParameter("@idAutomovil",idAutomovil));
            command = QueryBuilder.Instance.build("SELECT t.turno_id 'Turno N°',t.turno_hora_inicio 'Hora Inicio',t.turno_hora_fin 'Hora Fin',t.turno_descripcion 'Descripcion',t.turno_valor_Kilometro 'Valor Kilometro',t.turno_precio_base 'Precio Base',(t.turno_habilitado & A.auto_turno_estado) 'Habilitado'FROM  PUSH_IT_TO_THE_LIMIT.Turno t JOIN    PUSH_IT_TO_THE_LIMIT.AutoporTurno A ON(T.turno_id=A.turno_id) where t.turno_id IN (SELECT turno_id FROM PUSH_IT_TO_THE_LIMIT.AutoporTurno WHERE auto_id=@idAutomovil) AND auto_id=@idAutomovil AND auto_turno_estado=1 ", parametros);
            adapter.SelectCommand = command;
            adapter.Fill(turnosAutomovil);
            return turnosAutomovil.Tables[0];

         }

        public DataTable ObtenerClientesHabilitados()
        {

            DataSet turnosAutomovil = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            parametros = new List<SqlParameter>();
            parametros.Clear();
            command = QueryBuilder.Instance.build("SELECT cliente_dni,cliente_nombre,cliente_apellido FROM PUSH_IT_TO_THE_LIMIT.Cliente WHERE cliente_estado=1", parametros);
            adapter.SelectCommand = command;
            adapter.Fill(turnosAutomovil);
            return turnosAutomovil.Tables[0];

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


        /* Automovil */

        public DataTable SelectAutomovilParaFiltro()
        {
            return this.SelectAutomovilParaFiltroConFiltro("");
        }

        public DataTable SelectAutomovilParaFiltroConFiltro(String filtro)
        {
            return this.SelectDataTable("a.auto_id 'Auto N°',a.auto_patente 'Patente',a.auto_marca 'Marca',a.auto_modelo 'Modelo',(a.auto_estado & p.auto_chofer_estado) 'Habilitado',a.auto_licencia 'Licencia',a.auto_rodado 'Rodado',c.chofer_dni 'DNI chofer'  "
              , "PUSH_IT_TO_THE_LIMIT.Auto a, PUSH_IT_TO_THE_LIMIT.Chofer c ,PUSH_IT_TO_THE_LIMIT.ChoferporAuto p "
              , "a.auto_id = p.auto_id AND c.chofer_id = p.chofer_id " + filtro + "ORDER BY 'Auto N°'");
        }

        public DataTable ObtenerTurnosHabilitadosAutmovilParaRegistroViaje(int idAutomovil)
        {

            DataSet turnosAutomovil = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            parametros = new List<SqlParameter>();
            parametros.Clear();
            parametros.Add(new SqlParameter("@idAutomovil", idAutomovil));
            command = QueryBuilder.Instance.build("SELECT t.turno_id 'Turno N°',t.turno_hora_inicio 'Hora Inicio',t.turno_hora_fin 'Hora Fin',t.turno_descripcion 'Descripcion',t.turno_valor_Kilometro 'Valor Kilometro',t.turno_precio_base 'Precio Base',(t.turno_habilitado & A.auto_turno_estado) 'Habilitado'FROM  PUSH_IT_TO_THE_LIMIT.Turno t JOIN    PUSH_IT_TO_THE_LIMIT.AutoporTurno A ON(T.turno_id=A.turno_id) where t.turno_id IN (SELECT turno_id FROM PUSH_IT_TO_THE_LIMIT.AutoporTurno WHERE auto_id=@idAutomovil) AND auto_id=@idAutomovil AND auto_turno_estado=1 AND t.turno_habilitado=1", parametros);
            adapter.SelectCommand = command;
            adapter.Fill(turnosAutomovil);
            return turnosAutomovil.Tables[0];

        }
        //Usuarios 

       public DataTable obtenerRolesDeUnUsuario(int IdUsuario) { 

            DataSet turnosAutomovil = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            parametros = new List<SqlParameter>();
            parametros.Clear();
            parametros.Add(new SqlParameter("@idUsuario",IdUsuario));
            command = QueryBuilder.Instance.build("select rol_nombre from PUSH_IT_TO_THE_LIMIT.rol r join PUSH_IT_TO_THE_LIMIT.RolporUsuario p on(r.rol_id=p.rol_id) join PUSH_IT_TO_THE_LIMIT.Usuario u ON(p.usuario_id = u.usuario_id) where u.usuario_id=@idUsuario", parametros);
            adapter.SelectCommand = command;
            adapter.Fill(turnosAutomovil);
            return turnosAutomovil.Tables[0];
        
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