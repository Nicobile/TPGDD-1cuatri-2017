using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UberFrba.Exceptions
{
    class CampoVacioException : Exception
    {
        public CampoVacioException(String mensaje) : base(mensaje)
        {
            Console.WriteLine("se ejecuto la excepcion");
        }
    }
}