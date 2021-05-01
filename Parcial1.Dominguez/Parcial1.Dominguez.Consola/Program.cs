using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parcial1.Dominguez.Libreria.Entidades;
using Parcial1.Dominguez.Libreria.Excepciones;


namespace Parcial1.Dominguez.Consola
{
    public class Program
    {       
        
        private static Presentismo _presentismo;

        static Program()
        {
            _presentismo = new Presentismo();
        }
        static void Main(string[] args)
        {
            Preceptor preceptorActivo = _presentismo.GetPreceptorActivo();
            
            string opcionMenu = "";
            do
            {
                DesplegarOpcionesMenu();
                opcionMenu = Validaciones.Validaciones.ValidarStrNoVac("Ingrese una opción");
                switch (opcionMenu)
                {
                    case "1":
                        try
                        {
                            TomarAsistencia(preceptorActivo);
                        }
                        catch (AsistenciaExistenteEseDiaException asistExistEseDiaExcep)
                        {
                            Console.WriteLine(asistExistEseDiaExcep.Message);
                        }
                        catch (AsistenciaInconsistenteException asistInconstExcep)
                        {
                            Console.WriteLine(asistInconstExcep.Message);
                        }
                        catch (SinAlumnosRegistradosException sinAlumnRegExcep)
                        {
                            Console.WriteLine(sinAlumnRegExcep.Message);
                        }
                        catch (SinPreceptorActivoException sinPreceptorActivoExcep)
                        {
                            Console.WriteLine(sinPreceptorActivoExcep.Message);
                        }
                        break;
                    case "2":
                        MostrarAsistencia();
                        break;
                    case "X":
                        // SALIR
                        break;
                    default:
                        Console.WriteLine("Opción inválida");
                        break;
                }

            }
            while (opcionMenu != "X");
        }
        static void DesplegarOpcionesMenu()
        {
            Console.WriteLine("1) Tomar Asistencia");
            Console.WriteLine("2) Mostrar Asistencia");
            Console.WriteLine("X: Terminar");
        }
        static void TomarAsistencia(Preceptor p)
        {
            if (p == null) { throw new SinPreceptorActivoException(); }

            DateTime fechaAsist = Validaciones.Validaciones.PedirFecha("Ingrese fecha");
            
            List<Asistencia> listaAsistencia = new List<Asistencia>();
            List <Alumno> alumnos= _presentismo.GetListaAlumnos();
            
            if(alumnos.Count() == 0)
            {
                throw new SinAlumnosRegistradosException();
            }

            foreach (Alumno alumno in alumnos)
            {
                if(alumno is AlumnoOyente)
                {
                    Console.WriteLine($"El alumno {alumno.ToString()} es oyente");
                }
                else
                {
                    int opPresente;
                    do
                    {
                        opPresente = Validaciones.Validaciones.ValidarInt(alumno.ToString() + " ¿está presente?\n1.SI\n2.NO");
                        if (opPresente != 1 && opPresente != 2) { Console.WriteLine("Debe ingresar1 o 2"); }
                    }
                    while (opPresente != 1 && opPresente != 2);

                    bool estaPresente;
                    if (opPresente == 1)
                    {
                        estaPresente = true;
                    }
                    else
                    {
                        estaPresente = false;
                    }
                    Asistencia asistencia = new Asistencia(fechaAsist, DateTime.Today, p, alumno, estaPresente);
                    listaAsistencia.Add(asistencia);
                }
            }
            _presentismo.AgregarAsistencia(listaAsistencia);
        }
        static void MostrarAsistencia()
        {
            DateTime fechaAsist = Validaciones.Validaciones.PedirFecha("Ingrese fecha");
            List<Asistencia> asistencias = _presentismo.GetAsistenciasPorFecha(fechaAsist);
            if (asistencias.Count == 0)
            {
                Console.WriteLine("No hay registros para la fecha " + fechaAsist.ToString("yyyy-MM-dd"));
            }
            else
            {
                foreach (Asistencia asistencia in asistencias)
                {
                    Console.WriteLine(asistencia.ToString());
                }
            }
        }
    }
}

