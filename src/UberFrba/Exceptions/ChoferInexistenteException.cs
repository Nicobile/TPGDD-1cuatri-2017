using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba.Exceptions
{
    class ChoferInexistenteException : Exception
    {
         public ChoferInexistenteException(String mensaje) : base(mensaje)
        {
            Console.WriteLine("se ejecuto la excepcion");
        }
    }
}
