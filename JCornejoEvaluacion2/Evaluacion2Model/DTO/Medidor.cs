using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO
{
    public class Medidor
    {
        private int numeroMedidor;
        private string fechaMedicion;
        private double valorConsumo;

        public int NumeroMedidor { get => numeroMedidor; set => numeroMedidor = value; }
        public string FechaMedicion { get => fechaMedicion; set => fechaMedicion = value; }
        public double ValorConsumo { get => valorConsumo; set => valorConsumo = value; }
    }
}
