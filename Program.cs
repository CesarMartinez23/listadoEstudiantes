using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace listadoEstudiantes
{
    class Program
    {
        static void Main(string[] args)
        {
            //Variable Booleana, la cual indicara si debe o no mostrarse el menu.
            bool mostrarMenu = true;

            while (mostrarMenu)
            {
                //La variable mostrarMenu, indicara cuando el metodo menu se active o se desactive para que ya pueda o no ser visto en pantalla.
                mostrarMenu = Menu();
            }
            Console.ReadKey();
        }

        private static bool Menu()
        {
            //Creacion del menu principal a mostrar en pantalla.
            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine("        Bienvenido al Sistema de Registros de estudiantes UGB.");
            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine("Seleccione el numero que corresponda a la accion que desea realizar.");
            Console.WriteLine("\n");
            Console.WriteLine("1- Registrar un nuevo estudiante.");
            Console.WriteLine("2- Actualizar datos del estudiante.");
            Console.WriteLine("3- Eliminar registro de un estudiante.");
            Console.WriteLine("4- Mostrar estudiantes registrados.");
            Console.WriteLine("5- Salir");
            Console.WriteLine("\nOpcion: ");

            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1:
                    registrarAlumno();
                    return true;
                case 2:
                    actualizarDatosAlumno();
                    Console.ReadKey();
                    return true;
                case 3:
                    eliminarAlumno();
                    Console.ReadKey();
                    return true;
                case 4:
                    Console.WriteLine("Listado de Estudiantes");
                    foreach (KeyValuePair<string, string> data in readFile())
                    {
                        Console.WriteLine("{0}: {1}", data.Key, data.Value);
                    }
                    Console.ReadKey();
                    return true;
                case 5:
                    Console.WriteLine("Que tenga un Feliz Dia!");
                    return false;
                default:
                    return false;

            }
        }
        private static string getPath()
        {
            string path = @"E:\ListadoAlumnos\listado.txt";
            return path;
        }

        private static void registrarAlumno()
        {
            Console.WriteLine("----------------------");
            Console.WriteLine("Registro de Estudiante");
            Console.WriteLine("----------------------");
            Console.Write("Nombre Completo: ");
            string nombre = Console.ReadLine();
            Console.Write("Carrera: ");
            string carrera = Console.ReadLine();

            using (StreamWriter sw = File.AppendText(getPath()))
            {
                sw.WriteLine("{0}, {1}", nombre, carrera);
                sw.Close();
            }
        }

        private static Dictionary<string, string> readFile()
        {
            Dictionary<string, string> listData = new Dictionary<string, string>();

            using (var reader = new StreamReader(getPath()))
            {
                string lines;

                while ((lines = reader.ReadLine()) != null)
                {
                    string[] keyvalue = lines.Split(',');
                    if (keyvalue.Length == 2)
                    {
                        listData.Add(keyvalue[0], keyvalue[1]);
                    }
                }

            }
            return listData;
        }
    }
}