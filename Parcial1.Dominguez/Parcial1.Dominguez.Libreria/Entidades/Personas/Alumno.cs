using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial1.Dominguez.Libreria.Entidades
{
    public abstract class Alumno: Persona
    {
        int _registro;

        protected Alumno(int registro, string nombre, string apellido) : base(nombre, apellido)
        {
            this._registro = registro;
        }

        internal override string Display()
        {
            return $"{ this._nombre} ({ this._registro})";
        }
    }
}
