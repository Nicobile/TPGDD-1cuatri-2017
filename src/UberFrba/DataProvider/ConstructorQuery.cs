using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;


namespace UberFrba.DataProvider
{
    class ConstructorQuery
    {

        /// <summary>
        /// Singleton attribute
        /// </summary>
        private static ConstructorQuery instance;

        public static ConstructorQuery Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ConstructorQuery();
                }
                return instance;
            }
        }

        private SqlCommand command { get; set; }
        private AdministradorDeConexion conexion = new AdministradorDeConexion();

        public SqlCommand build(string sqlText, IList<SqlParameter> parameters)
        {
            this.command = new SqlCommand();
            this.command.CommandText = sqlText;
            if (parameters != null)
            {
                foreach (SqlParameter parameter in parameters)
                {
                    this.command.Parameters.Add(parameter);
                }
            }
            if (this.command.Connection == null) this.command.Connection = conexion.connect();

            return this.command;
        }
    }
}