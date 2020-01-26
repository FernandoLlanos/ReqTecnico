using Dominio.Test.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Data.Test.Interfaces
{
    public interface IEvaluacionRepository
    {
        ICollection<EvaluacionEntity> Listar(string strCorreoElectronico, DateTime? dtFechaInicio, DateTime? dtFechaFin);
        ICollection<EvaluacionEntity> ListarPorCorreoElectronico(string strCorreoElectronico);
        int Registrar(EvaluacionEntity oEvaluacionEntitity);
        int Actualizar(EvaluacionEntity oEvaluacionEntitity);
    }
}
