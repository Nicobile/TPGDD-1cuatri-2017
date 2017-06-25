using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba.Exceptions
{
    class ClienteInhabilitadoException : Exception
    {

        public ClienteInhabilitadoException(String mensaje)
            : base(mensaje)
        {
            Console.WriteLine("se ejecuto la excepcion");
        }



    }
}
