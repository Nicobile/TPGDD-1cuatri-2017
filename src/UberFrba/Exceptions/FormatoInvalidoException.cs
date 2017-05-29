using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UberFrba.Exceptions
{
    class FormatoInvalidoException : Exception
    {
        public FormatoInvalidoException(String mensaje)
            : base(mensaje)
        {

        }
    }
}