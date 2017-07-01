using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
namespace UberFrba.Modelo
{
    class Objeto
    {
        public Boolean esNumero(String numString)
        {
            long number1 = 0;
            return long.TryParse(numString, out number1); 
        }

        public Boolean esDouble(String numString)
        {
            Double number1 = 0;
            return Double.TryParse(numString, out number1); 
        }

 
        public Boolean esFechaPasada(DateTime dateTime) // modificado habria que ver que siga funcionando
        {
              DateTime FECHA_ACTUAL = DateTime.Parse(ConfigurationManager.AppSettings["Fecha"]);
            int comparacion = dateTime.CompareTo(FECHA_ACTUAL);
            if (comparacion >= 0)
                return false;
            else
                return true;
        }
        public Object siEsNuloDevolverDBNull(String campo)
        {
            if (campo == "")
            {
                return DBNull.Value;
            }
            else
            {
                return campo;
            }
        }

        
    }
}