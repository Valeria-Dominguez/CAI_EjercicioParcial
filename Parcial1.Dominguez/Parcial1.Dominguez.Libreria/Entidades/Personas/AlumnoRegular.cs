using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial1.Dominguez.Libreria.Entidades
{
    public class AlumnoRegular : Alumno
    {
        string _email;
        public AlumnoRegular(int registro, string nombre, string apellido, string email) : base(registro, nombre, apellido)
        {
            this._email = email;
        }

    }
}
