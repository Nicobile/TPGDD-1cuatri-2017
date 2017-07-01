using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba.DataProvider
{
    class QueryHelper
    {

      
        private static QueryHelper instance;

        public static QueryHelper Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new QueryHelper();
                }
                return instance;
            }
        }

        
        public SqlDataReader exec(String query, IList<SqlParameter> parameters)
        {
            SqlCommand command = ConstructorQuery.Instance.build(query, parameters);
            SqlDataReader reader = command.ExecuteReader();
            return reader;
        }

        public bool readFrom(SqlDataReader reader_parameter)
        {
            return reader_parameter.Read();
        }


        public void closeReader(SqlDataReader reader)
        {
            reader.Close();
        }

    }
}
