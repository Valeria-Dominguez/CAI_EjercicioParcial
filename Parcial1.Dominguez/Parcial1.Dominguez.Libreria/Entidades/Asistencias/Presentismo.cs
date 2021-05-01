using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parcial1.Dominguez.Libreria.Excepciones;

namespace Parcial1.Dominguez.Libreria.Entidades
{
    public class Presentismo
    {
        List<Preceptor> _preceptores;
        List<Alumno> _alumnos;
        List<Asistencia> _asistencias;

        public Presentismo()
        {
            _preceptores = new List<Preceptor>();
            _alumnos = new List<Alumno>() ;
            _asistencias = new List<Asistencia>();

            _preceptores.Add(new Preceptor(5, "Jorgelina", "Ramos", true));
            _preceptores.Add(new Preceptor(6, "Juan", "Gutierrez", false));

            _alumnos.Add(new AlumnoRegular(123, "Carlos", "Juárez", "cj@gmail.com"));
            _alumnos.Add(new AlumnoRegular(124, "Carla", "Jaime", "carla@gmail.com"));
            _alumnos.Add(new AlumnoOyente(320, "Ramona", "Vals"));
            _alumnos.Add(new AlumnoOyente(321, "Alejandro", "Medina"));
        }

        bool AsistenciaRegistrada(string fecha)
        {
            foreach(Asistencia asistencia in this._asistencias)
                if(asistencia.FechaAsistencia==fecha)
                {
                    return true;
                }
            return false;
        }

        int GetCantidadAlumnosRegulares()
        {
            int cantidadAlumnosRegulares = 0;
            foreach (Alumno alumno in this._alumnos)
            {
                if (alumno is AlumnoRegular)
                {
                    cantidadAlumnosRegulares = cantidadAlumnosRegulares + 1;
                }
            }
            return cantidadAlumnosRegulares;
        }

        public Preceptor GetPreceptorActivo()
        {
            Preceptor preceptorActivo = null;
            foreach (Preceptor preceptor in this._preceptores)
            {
                if(preceptor.Activo)
                {
                    preceptorActivo = preceptor;
                }
            }
            return preceptorActivo;
        }

        public List<Alumno> GetListaAlumnos()
        {
            return this._alumnos;
        }

        public void AgregarAsistencia (List<Asistencia> asistencias)
        {
            if(this.AsistenciaRegistrada(asistencias.First().FechaAsistencia)==true)
            {
                throw new AsistenciaExistenteEseDiaException("Ya existe un registro de asistencia ingresado para esa fecha");
            }
            if (asistencias.Count!=this.GetCantidadAlumnosRegulares())
            {
                throw new AsistenciaInconsistenteException("La cantidad de alumnos regulares en la lista es distinta a la cantidad de alumnos regulares registrados");
            }
            foreach(Asistencia asistencia in asistencias)
            {
                this._asistencias.Add(asistencia);
            }
        }

        public List<Asistencia> GetAsistenciasPorFecha(DateTime fecha)
        {
            List<Asistencia> asistenciasFecha = new List<Asistencia>();
            foreach (Asistencia asistencia in this._asistencias)
            {
                if (asistencia.FechaAsistencia== fecha.ToString("yyyy-MM-dd"))
                {
                    asistenciasFecha.Add(asistencia);
                }
            }
            return asistenciasFecha;
        }
    }
}
