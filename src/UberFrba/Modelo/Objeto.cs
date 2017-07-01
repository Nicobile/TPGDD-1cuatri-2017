using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

 
        public Boolean esFechaPasada(DateTime dateTime)
        {
            DateTime dateNow = ConfigFecha.getInstance().getCurrentDate();
            int comparacion = dateTime.CompareTo(dateNow);
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