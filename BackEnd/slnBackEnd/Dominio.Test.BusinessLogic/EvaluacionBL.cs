using Dominio.Test.Entities;
using Dominio.Test.Interfaces;
using Infraestructura.Data.Test.Interfaces;
using Infraestructura.Data.Test.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Test.BusinessLogic
{
    public class EvaluacionBL : IEvaluacionService
    {
        IEvaluacionRepository objAtencion = new EvaluacionRepository();

        /// <summary>
        /// Permite la búsqueda de Evaluaciones
        /// </summary>
        /// <param name="strCorreoElectronico">Correo Electrónico</param>
        /// <param name="strFechaInicio">Fecha de Inicio</param>
        /// <param name="strFechaFin">Fecha Fin</param>
        /// <returns>Lista de Evaluaciones</returns> 
        public ICollection<EvaluacionEntity> Listar(string strCorreoElectronico, DateTime? dtFechaInicio, DateTime? dtFechaFin)
        {
            return objAtencion.Listar(strCorreoElectronico, dtFechaInicio, dtFechaFin);
        }

        /// <summary>
        /// Permite la búsqueda de Evaluaciones por correo electrónico
        /// </summary>
        /// <param name="strCorreoElectronico">Correo Electrónico</param>
        /// <returns>Lista de Evaluaciones</returns> 
        public ICollection<EvaluacionEntity> ListarPorCorreoElectronico(string strCorreoElectronico)
        {
            return objAtencion.ListarPorCorreoElectronico(strCorreoElectronico);
        }

        /// <summary>
        /// Permite Registrar Evaluaciones
        /// </summary>
        /// <param name="oEvaluacion">Objeto de Entidad de Evaluaciones</param>
        /// <returns>1 si se registró correctamente</returns>
        public int Registrar(EvaluacionEntity oEvaluacionEntitity)
        {
            return objAtencion.Registrar(oEvaluacionEntitity);
        }

        /// <summary>
        /// Permite Actualizar Evaluaciones
        /// </summary>
        /// <param name="oEvaluacion">Objeto de Entidad de Evaluaciones</param>
        /// <returns>1 si se actualizó correctamente</returns> 
        public int Actualizar(EvaluacionEntity oEvaluacionEntitity)
        {
            return objAtencion.Actualizar(oEvaluacionEntitity);
        }
    }
}
