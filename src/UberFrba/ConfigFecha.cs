using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Configuration;


namespace UberFrba
{
    public class ConfigFecha
    {
        private static ConfigFecha instance;
        
        public static ConfigFecha getInstance()
        {
            if (instance == null)
            {
                instance = new ConfigFecha();
            }

            return instance;
        }
       
        public DateTime getCurrentDate()
        {
            if (!String.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["CurrentDate"]))
          {
              return DateTime.Parse(ConfigurationManager.AppSettings["CurrentDate"]);
          }

          return DateTime.Now;
        }
    }
}
