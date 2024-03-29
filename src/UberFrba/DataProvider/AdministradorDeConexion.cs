﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Security;
using System.Configuration;


namespace UberFrba.DataProvider
{
    class AdministradorDeConexion
    {

        private static String CONNECTION_STRING = "gd1C2017";
        private static String SCHEMA = "PUSH_IT_TO_THE_LIMIT";
        private static String DATABASE = "GD1C2017";
        private static String USER_ID = "gd";

        /// <summary>
        /// Singleton attribute
        /// </summary>
        private static AdministradorDeConexion instance;

        public static AdministradorDeConexion Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AdministradorDeConexion();
                }
                return instance;
            }
        }

        //DB connection instance
        private SqlConnection gd_connection;

        //Get DB connection
        public SqlConnection getConnection()
        {
            if (gd_connection == null)
            {
                connect();
            }
            return gd_connection;
        }


        //Get DB credentials
        public SqlCredential getCredentials()
        {

            SecureString password = new SecureString();
            password.AppendChar('g');
            password.AppendChar('d');
            password.AppendChar('2');
            password.AppendChar('0');
            password.AppendChar('1');
            password.AppendChar('7');

            password.MakeReadOnly();//hace a password solo de lectura!

            return new SqlCredential(USER_ID, password);
        }

        //Connect to DB
        public SqlConnection connect()
        {
            gd_connection = new SqlConnection(getConnectionString(CONNECTION_STRING));
            gd_connection.Open();

            new SqlCommand("USE [" + DATABASE + "] ", gd_connection).ExecuteNonQuery();
            return gd_connection;
        }


        //Close DB connection
        public void close()
        {
            // if (this.gd_connection != null)
            //{
            gd_connection.Close();
            //}
        }

        public String getSchema()
        {
            return SCHEMA;
        }

        public String getConnectionString(String name)
        {
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[name];

            if (settings != null)
                return settings.ConnectionString;

            return null;
        }
    }
}
