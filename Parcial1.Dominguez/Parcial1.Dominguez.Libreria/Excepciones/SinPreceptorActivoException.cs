using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial1.Dominguez.Libreria.Excepciones
{
    public class SinPreceptorActivoException : Exception
    {
        public SinPreceptorActivoException(string message) : base(message)
        {
        }
        public SinPreceptorActivoException() : base("No hay preceptores activos")
        {
        }
    }
}
