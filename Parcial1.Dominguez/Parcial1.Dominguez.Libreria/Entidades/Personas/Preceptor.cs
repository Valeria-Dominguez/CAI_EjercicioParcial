using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial1.Dominguez.Libreria.Entidades
{
    public class Preceptor : Persona
    {
        int _legajo;
        bool _activo;

        //Acá en realidad no debería ir propiedad pública según UML        
        public bool Activo { get => _activo; }

        public Preceptor(int legajo, string nombre, string apellido, bool activo) : base(nombre, apellido)
        {
            this._legajo = legajo;
            this._activo = activo;
        }

        internal override string Display()
        {
            return $"{this._apellido} - { this._legajo}";
        }
    }
}
