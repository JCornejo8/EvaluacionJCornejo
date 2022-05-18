using Evaluacion2Model.DAL;
using Model.DTO;
using ServerSocketUtils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace JCornejoEvaluacion2.comunicaciones
{
    public class HebraServidor
    {
        int puerto;
       
        private static InterfazLecturasDAL lecturasDAL = LecturasDALArchivos.GetInstancia();
        public HebraServidor(int puerto)
        {
            this.puerto = puerto;
        }
        public void Ejecutar()
        {

          
            ServerSocket servidor = new ServerSocket(puerto);
            Console.WriteLine("S: Iniciando servidor en puerto {0}", puerto);
            if (servidor.Iniciar())
            {
                while (true)
                {
                    DateTime fechamedicion = DateTime.Now;
                    Console.WriteLine("S: Esperando Cliente...");
                    Socket cliente = servidor.ObtenerCliente();
                    Console.WriteLine("S: Cliente recibido");
                    ClienteCom clienteCom = new ClienteCom(cliente);
                    clienteCom.Escribir("S: Ingrese el numero del medidor");
                   
                    //recivir negativa o afirmativa
                    
                    string numeromedidor = clienteCom.Leer();
                    clienteCom.Escribir("S: Ingrese el valor del consumo");
                    string valormedicion = clienteCom.Leer();
                    string fechamedicionf = String.Format("{0:yyy-MM-dd-HH-mm-ss}", fechamedicion);
                    // Medidor medidor = new Medidor()
                    // {
                    //     NumeroMedidor = numeromedidor,
                    //      FechaMedicion = fechamedicionf,
                    //      ValorConsumo = valormedicion,

                    //   };
                    Lectura l = new Lectura()
                    {
                        CadenaLectura = numeromedidor + "|" + fechamedicionf + "|" + valormedicion

                    };
                    lecturasDAL.AgregarLectura(l);
                    clienteCom.Escribir("S: Valores ingresados correctamente, adios ");

                    clienteCom.Desconectar();
                }
            }
        }
    }
}
