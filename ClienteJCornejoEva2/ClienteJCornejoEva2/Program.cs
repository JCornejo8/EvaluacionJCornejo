using ClienteJCornejoEva2.comunicacion;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClienteJCornejoEva2
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
        
            int puerto = Convert.ToInt32(ConfigurationManager.AppSettings["puerto"]);
            
            string servidor = (ConfigurationManager.AppSettings["servidor"]);
        


            Console.WriteLine("Conectado a Servidor {0} en puerto {1}", servidor, puerto);
            ClienteSocket clienteSocket = new ClienteSocket(servidor, puerto);
            bool estado = true;
            if ( clienteSocket.conectar())
            {
                do
                {
                    string mensajeServidor = clienteSocket.Leer();
                    Console.WriteLine("Servidor: {0}", mensajeServidor);
                   
                    string mensajeCliente = Console.ReadLine().Trim();
                    clienteSocket.Escribir(mensajeCliente);

                    mensajeServidor = clienteSocket.Leer();
                    Console.WriteLine("Servidor:{0}", mensajeServidor);
                    mensajeCliente = Console.ReadLine().Trim();
                    clienteSocket.Escribir(mensajeCliente);
                    mensajeServidor = clienteSocket.Leer();
                    Console.WriteLine("Servidor:{0}", mensajeServidor);
                    clienteSocket.Desconectar();
                    estado = false;

                } while (estado);
            
            }
            else
            {
                Console.WriteLine("Error de comunicacion");
            }
            Console.ReadKey();
        }
    }
}
