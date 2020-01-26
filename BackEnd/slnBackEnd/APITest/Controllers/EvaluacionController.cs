using APITest.Models;
using Dominio.Test.BusinessLogic;
using Dominio.Test.Entities;
using Dominio.Test.Interfaces;
using Infraestructura.Transversal.Exepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using static Infraestructura.Transversal.Recursos.Constantes;

namespace APITest.Controllers
{
    [RoutePrefix("api/v1/evaluacion")]
    public class EvaluacionController : ApiController
    {

        [HttpGet]
        [Route("listar")]
        /// <summary>
        /// Permite la búsqueda de Evaluaciones
        /// </summary>
        /// <param name="strCorreoElectronico">Correo Electrónico</param>
        /// <param name="strFechaInicio">Fecha de Inicio</param>
        /// <param name="strFechaFin">Fecha Fin</param>
        /// <returns>Lista de Evaluaciones</returns> 
        public IHttpActionResult Listar(string strCorreoElectronico, string strFechaInicio, string strFechaFin)
        {
            try
            {
                IEvaluacionService oEvaluacion = new EvaluacionBL();
                var lstEvaluacion = oEvaluacion.Listar(strCorreoElectronico,Convert.ToDateTime(strFechaInicio), Convert.ToDateTime(strFechaFin));

                return Ok(new
                {
                    data = lstEvaluacion,
                    success = true
                });

            }
            catch (TestException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(MensajesError.Inesperado.ERROR_INESPERADO);
            }
        }

        [HttpGet]
        [Route("listarporcorreo")]
        /// <summary>
        /// Permite la búsqueda de Evaluaciones por correo electrónico
        /// </summary>
        /// <param name="strCorreoElectronico">Correo Electrónico</param>
        /// <returns>Lista de Evaluaciones</returns> 
        public IHttpActionResult ListarPorCorreoElectronico(string strCorreoElectronico)
        {
            try
            {
                IEvaluacionService oEvaluacion = new EvaluacionBL();
                var lstEvaluacion = oEvaluacion.ListarPorCorreoElectronico(strCorreoElectronico);

                return Ok(new
                {
                    data = lstEvaluacion,
                    success = true
                });

            }
            catch (TestException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(MensajesError.Inesperado.ERROR_INESPERADO);
            }
        }

        [HttpPost]
        [Route("grabar")]
        /// <summary>
        /// Permite Registrar Evaluaciones
        /// </summary>
        /// <param name="oEvaluacion">Objeto de Entidad de Evaluaciones</param>
        /// <returns>1 si se registró correctamente</returns>
        public IHttpActionResult RegistrarEvaluacion(EvaluacionModel objEvaluacionModel)
        {
            try
            {
                IEvaluacionService oEvaluacion = new EvaluacionBL();
                int respuesta = oEvaluacion.Registrar(MapearModelAEntity(objEvaluacionModel));

                return Ok(new
                {
                    success = respuesta
                });
            }
            catch (TestException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                //Generar Log de Evetos
                // .....

                return BadRequest(MensajesError.Inesperado.ERROR_INESPERADO);
            }
        }

        [HttpPut]
        [Route("actualizar")]
        /// <summary>
        /// Permite Actualizar Evaluaciones
        /// </summary>
        /// <param name="oEvaluacion">Objeto de Entidad de Evaluaciones</param>
        /// <returns>1 si se actualizó correctamente</returns> 
        public IHttpActionResult ActualizarEvaluacion(EvaluacionModel objEvaluacionModel)
        {
            try
            {
                IEvaluacionService oEvaluacion = new EvaluacionBL();
                int respuesta = oEvaluacion.Actualizar(MapearModelAEntity(objEvaluacionModel));

                return Ok(new
                {
                    success = respuesta
                });
            }
            catch (TestException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                //Generar Log de Evetos
                // .....

                return BadRequest(MensajesError.Inesperado.ERROR_INESPERADO);
            }
        }

        private EvaluacionEntity MapearModelAEntity(EvaluacionModel objModel)
        {
            EvaluacionEntity objEntity = new EvaluacionEntity();
            objEntity.intIdEvaluacion = objModel.intIdEvaluacion;
            objEntity.strCorreoElectronico = objModel.strCorreoElectronico;
            objEntity.strNombreCompleto = objModel.strNombreCompleto;
            objEntity.intCalificacion = objModel.intCalificacion;
            return objEntity;
        }
    }
}
