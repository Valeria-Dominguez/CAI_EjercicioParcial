using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial1.Dominguez.Libreria.Entidades
{
    public abstract class Persona
    {
        protected string _nombre;
        protected string _apellido;

        protected Persona(string nombre, string apellido)
        {
            _nombre = nombre;
            _apellido = apellido;
        }

        public override string ToString()
        {
            return $"{this._nombre} {this._apellido}";
        }

        internal abstract string Display();
        
    }
}
