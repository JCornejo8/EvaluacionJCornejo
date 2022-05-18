using JCornejoEvaluacion2.comunicaciones;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JCornejoEvaluacion2
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            bool continuar = true;
            Console.WriteLine("1.Ingresar puerto del servidor");
            Console.WriteLine("2.Iniciar en el puerto por defecto(3000)");
            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("Ingresar puerto del servidor");
                    int puerto = Convert.ToInt32(Console.ReadLine());
                    IniciarServidorConPuerto(puerto);
                    break;
                case "2":
                    int puerto3000 = Convert.ToInt32(ConfigurationManager.AppSettings["puerto"]);
                    HebraServidor hebra = new HebraServidor(puerto3000);
                    Thread t = new Thread(new ThreadStart(hebra.Ejecutar));
                    t.IsBackground = true;
                    t.Start();
                    break;
            }
            
            while (Menu()) ;
        }

        static bool Menu()
        {

            bool continuar = true;
            Console.WriteLine("1. Ingresar medidor");
            Console.WriteLine("2. Mostrar medidores");
            Console.WriteLine("3. Ingresar lectura");
            Console.WriteLine("4. Mostrar lecturas");
            Console.WriteLine("0. Salir");
            switch (Console.ReadLine().Trim())
            {
                case "1":
                    IngresarMedidor();
                    break;
                case "2":
                    MostrarMedidores();
                    break;
                case "3":
                    IngresarLectura();
                    break;
                case "4":
                    MostrarLecturas();
                    break;
                case "0":
                    continuar = false;
                    break;
                default:
                    Console.WriteLine("Aprete el teclado bien gil¡¡¡¡¡");
                    break;
            }
            return continuar;
        }
    }
}
