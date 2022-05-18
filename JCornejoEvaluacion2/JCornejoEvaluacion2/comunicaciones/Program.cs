using Evaluacion2Model.DAL;
using JCornejoEvaluacion2.comunicaciones;
using Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JCornejoEvaluacion2
{
    public partial class Program
    {
        private static InterfazLecturasDAL lecturaDAL = LecturasDALArchivos.GetInstancia();
        private static List<Medidor> medidores = new List<Medidor>();

        static void IniciarServidorConPuerto(int puerto)
        {

            HebraServidor hebra = new HebraServidor(puerto);
            Thread t = new Thread(new ThreadStart(hebra.Ejecutar));
            t.IsBackground = true;
            t.Start();
        }

        static void IngresarMedidor()
        {
            int numeromedidor;
            DateTime fechamedicion = DateTime.Now;
            double valorconsumo;

            Console.WriteLine("S:Ingresando datos del medidor...");
            bool esValido;
            string fechamedicionf = String.Format("{0:yyyy-MM-dd-HH-mm-ss}", fechamedicion);
            do
            {
                Console.WriteLine("Ingrese numero del medidor");

                esValido = Int32.TryParse(Console.ReadLine().Trim(), out numeromedidor);
            } while (!esValido);

            do
            {
                Console.WriteLine("Ingrese el valor del consumo");
                esValido = double.TryParse(Console.ReadLine().Trim(), out valorconsumo);
            } while (!esValido);

            Medidor m = new Medidor()
            {
                NumeroMedidor = numeromedidor,
                ValorConsumo = valorconsumo,
                FechaMedicion = fechamedicionf,

            };
            Console.WriteLine("OK");

            lecturaDAL.AgregarMedidores(m);
            //  lecturaDAL.AgregarLectura(m);
        }

        static void MostrarMedidores()
        {


            List<Medidor> medidores = lecturaDAL.ObtenerMedidores();
            for (int i = 0; i < medidores.Count; i++)
            {

                Medidor actual = medidores[i];
                Console.WriteLine(" Numero de medidor:{0}, Fecha de medicion:{1}, y el valor de la medicion es:{2}", actual.NumeroMedidor, actual.FechaMedicion, actual.ValorConsumo
                );
            }
        }
        static void IngresarLectura()
        {

            DateTime fechamedicion = DateTime.Now;
            string fechamedicionf = String.Format("{0:yyyy-MM-dd-HH-mm-ss}", fechamedicion);
            Console.WriteLine("Ingrese numero del medidor");
            string numeromedidor = Console.ReadLine();

            Console.WriteLine("Ingrese el valor del consumo para el medidor {0}", numeromedidor);
            string valorconsumo = Console.ReadLine();

            //    if (int.Parse(numeromedidor) == 1)   
          //  for (int i = 0; i < medidores.Count; i++)
          //  {

                //  Medidor actual = medidores[i];
               //   if (actual.NumeroMedidor == int.Parse(numeromedidor))
               //   {
                    Lectura l = new Lectura()
                    {
                        CadenaLectura = numeromedidor + "|" + fechamedicionf + "|" + valorconsumo
                        
                     };
                    lecturaDAL.AgregarLectura(l);
                  //  Console.WriteLine(" Numero de medidor:{0}, Fecha de medicion:{1}, y el valor de la medicion es:{2}", actual.NumeroMedidor, actual.FechaMedicion, actual.ValorConsumo);

               //   }
              //    else
               //   {
               //     Console.WriteLine("No se encontro un memdidor con el id{0}", numeromedidor);
               //   }
           //  }     
        }



        static void MostrarLecturas()
        {
            List<Lectura> lecturas = lecturaDAL.ObtenerLecturas();
            for (int i = 0; i < lecturas.Count; i++)
            {
                Lectura actual = lecturas[i];
                Console.WriteLine("{0}", actual.CadenaLectura);
            }

        }

    }
}
