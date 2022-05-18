using Model.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluacion2Model.DAL
{
    public class LecturasDALArchivos : InterfazLecturasDAL
    {
        private LecturasDALArchivos()
        {

        }
        private static LecturasDALArchivos instancia;

        private static List<Medidor> medidores = new List<Medidor>();

        public static InterfazLecturasDAL GetInstancia()
        {
            if (instancia == null)
            {
                instancia = new LecturasDALArchivos();
            }
            return instancia;
        }
        private static string archivo = "lecturas.txt";
        private static string ruta = Directory.GetCurrentDirectory() + "/" + archivo;
        public void AgregarLectura(Lectura lectura)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(ruta, true))
                {                   
                   //recorer lista de objetos y validar por numero de medidor
                   string texto = lectura.CadenaLectura;
                    writer.WriteLine(texto);
                    writer.Flush();
                }
            }catch (Exception ex)
            {
                Console.WriteLine("ERROR");
            }


        }
        public List<Lectura> ObtenerLecturas()
        {
            string texto;
            List<Lectura> lecturas = new List<Lectura>();
            using (StreamReader reader = new StreamReader(ruta))
            {
                
                do
                {
                    texto = reader.ReadLine();
                    if (texto != null)
                    {
                        Lectura l = new Lectura()
                        {
                            CadenaLectura = texto

                        };
                        lecturas.Add(l);
                    }
                }while(texto != null);
                return lecturas;
            }
        }
        public void AgregarMedidores(Medidor m)
        {
            medidores.Add(m);
        }
        public List<Medidor> ObtenerMedidores()
        {
            return medidores;
        }
    }
}
