using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial1.Dominguez.Libreria.Excepciones
{
    public class AsistenciaExistenteEseDiaException : Exception
    {
        public AsistenciaExistenteEseDiaException(string message) : base(message)
        {
        }
        public AsistenciaExistenteEseDiaException() : base("Asistencia inexistente para ese día")
        {
        }
    }
}
