using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial1.Dominguez.Libreria.Excepciones
{
    public class SinAlumnosRegistradosException : Exception
    {
        public SinAlumnosRegistradosException(string message) : base(message)
        {
        }
        public SinAlumnosRegistradosException() : base("No hay alumnos registrados")
        {
        }
    }
}
