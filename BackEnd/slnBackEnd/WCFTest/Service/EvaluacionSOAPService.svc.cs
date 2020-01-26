using Dominio.Test.BusinessLogic;
using Dominio.Test.Entities;
using Dominio.Test.Interfaces;
using Infraestructura.Transversal.Exepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFTest
{
    public class EvaluacionSOAPService : IEvaluacionSOAPService
    {
        /// <summary>
        /// Permite la búsqueda de Evaluaciones
        /// </summary>
        /// <param name="strCorreoElectronico">Correo Electrónico</param>
        /// <param name="strFechaInicio">Fecha de Inicio</param>
        /// <param name="strFechaFin">Fecha Fin</param>
        /// <returns>Lista de Evaluaciones</returns> 
        public ICollection<EvaluacionEntity> Listar(string strCorreoElectronico, string strFechaInicio, string strFechaFin)
        {
            try
            {
                IEvaluacionService oEvaluacion = new EvaluacionBL();
                var lstEvaluacion = oEvaluacion.Listar(strCorreoElectronico, Convert.ToDateTime(strFechaInicio), Convert.ToDateTime(strFechaFin));

                return lstEvaluacion;

            }
            catch (TestException ex)
            {
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Permite la búsqueda de Evaluaciones por correo electrónico
        /// </summary>
        /// <param name="strCorreoElectronico">Correo Electrónico</param>
        /// <returns>Lista de Evaluaciones</returns> 
        public ICollection<EvaluacionEntity> ListarPorCorreoElectronico(string strCorreoElectronico)
        {
            try
            {
                IEvaluacionService oEvaluacion = new EvaluacionBL();
                var lstEvaluacion = oEvaluacion.ListarPorCorreoElectronico(strCorreoElectronico);

                return lstEvaluacion;

            }
            catch (TestException ex)
            {
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Permite Registrar Evaluaciones
        /// </summary>
        /// <param name="oEvaluacion">Objeto de Entidad de Evaluaciones</param>
        /// <returns>1 si se registró correctamente</returns> 
        public int RegistrarEvaluacion(EvaluacionEntity oEvaluacion)
        {
            try
            {
                IEvaluacionService objEvaluacion = new EvaluacionBL();
                var respuesta = objEvaluacion.Registrar(oEvaluacion);

                return respuesta;

            }
            catch (TestException ex)
            {
                return 0;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        /// <summary>
        /// Permite Actualizar Evaluaciones
        /// </summary>
        /// <param name="oEvaluacion">Objeto de Entidad de Evaluaciones</param>
        /// <returns>1 si se actualizó correctamente</returns> 
        public int ActualizarEvaluacion(EvaluacionEntity oEvaluacion)
        {
            try
            {
                IEvaluacionService objEvaluacion = new EvaluacionBL();
                var respuesta = objEvaluacion.Actualizar(oEvaluacion);

                return respuesta;

            }
            catch (TestException ex)
            {
                return 0;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
