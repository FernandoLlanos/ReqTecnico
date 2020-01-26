using Dominio.Test.Entities;
using System;
using System.Collections.Generic;

namespace Dominio.Test.Interfaces
{
    public interface IEvaluacionService
    {
        ICollection<EvaluacionEntity> Listar(string strCorreoElectronico, DateTime? dtFechaInicio, DateTime? dtFechaFin);
        ICollection<EvaluacionEntity> ListarPorCorreoElectronico(string strCorreoElectronico);
        int Registrar(EvaluacionEntity oEvaluacionEntitity);
        int Actualizar(EvaluacionEntity oEvaluacionEntitity);
    }
}
