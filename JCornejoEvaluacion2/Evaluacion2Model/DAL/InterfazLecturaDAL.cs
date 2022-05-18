using Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluacion2Model.DAL
{
    public interface InterfazLecturasDAL
    {
        void AgregarLectura(Lectura lectura);

        List<Lectura> ObtenerLecturas();
        List<Medidor> ObtenerMedidores();

        void AgregarMedidores(Medidor medidor);

    }
}
