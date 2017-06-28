using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba.Exceptions
{
    class HorarioNoCoincideConTurno : Exception
    {
        public HorarioNoCoincideConTurno(String mensaje)
            : base(mensaje)
        {
            Console.WriteLine("se ejecuto la excepcion");
        }
    }
}
