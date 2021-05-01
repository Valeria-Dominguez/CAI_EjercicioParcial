using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial1.Dominguez.Libreria.Entidades
{
    public class Asistencia
    {
        DateTime _fechaAsistencia;
        DateTime _fechaHoraReal;
        Preceptor _preceptor;
        Alumno _alumno;
        bool _estaPresente;

        public string FechaAsistencia
        {
            get
            {
                return _fechaAsistencia.ToString("yyyy-MM-dd");
            }
        }

        public Asistencia(DateTime fechaAsistencia, DateTime fechaHoraReal, Preceptor preceptor, Alumno alumno, bool estaPresente)
        {
            _fechaAsistencia = fechaAsistencia;
            _fechaHoraReal = fechaHoraReal;
            _preceptor = preceptor;
            _alumno = alumno;
            _estaPresente = estaPresente;
        }

        public override string ToString()
        {
            string presenteSiONo;
            if (this._estaPresente)
            {
                presenteSiONo = "SI";
            }
            else
            {
                presenteSiONo = "NO";
            }
            return $"{this.FechaAsistencia} {this._alumno.Display()} está presente {presenteSiONo} por {this._preceptor.Display()} registrado el {this._fechaHoraReal}";
        }
    }
}
