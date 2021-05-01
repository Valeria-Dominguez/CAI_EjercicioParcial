using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial1.Dominguez.Libreria.Excepciones
{
    public class AsistenciaInconsistenteException : Exception
    {
        public AsistenciaInconsistenteException(string message) : base(message)
        {
        }
        public AsistenciaInconsistenteException() : base("Asistencia inconsistente")
        {
        }
    }
}
