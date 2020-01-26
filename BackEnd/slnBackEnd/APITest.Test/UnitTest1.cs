using System;
using System.Collections.Generic;
using Dominio.Test.BusinessLogic;
using Dominio.Test.Entities;
using Dominio.Test.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace APITest.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void verificarDatosEnListaEvaluacion()
        {
            IEvaluacionService oEvaluacion = new EvaluacionBL();
            ICollection<EvaluacionEntity> lstEvaluacion;
            string strCorreoElectronico = "fernando.llanos1@gmail.com";
            string strFechaInicio = "25/01/2019";
            string strFechaFin = "26/01/2019";
            lstEvaluacion = oEvaluacion.Listar(strCorreoElectronico, Convert.ToDateTime(strFechaInicio), Convert.ToDateTime(strFechaFin));

            Assert.IsNotNull(lstEvaluacion);
        }

        [TestMethod]
        public void verificarRegistroDeEvaluacion()
        {
            Boolean respuestaTest = false;
            IEvaluacionService oEvaluacion = new EvaluacionBL();
            EvaluacionEntity objEvaluacion = new EvaluacionEntity();
            

            objEvaluacion.strCorreoElectronico = "fernando.llanos1@gmail.com";
            objEvaluacion.strNombreCompleto = "Fernando Llanos";
            objEvaluacion.intCalificacion = 10;
            int respuesta = oEvaluacion.Registrar(objEvaluacion);

            if (respuesta > 0) { respuestaTest = true; }

            Assert.IsTrue(respuestaTest);
        }

        [TestMethod]
        public void verificarActualizacionDeCalificacion()
        {
            Boolean respuestaTest = false;
            IEvaluacionService oEvaluacion = new EvaluacionBL();
            EvaluacionEntity objEvaluacion = new EvaluacionEntity();


            objEvaluacion.intIdEvaluacion = 3; // ID si existe
            objEvaluacion.intCalificacion = 10;
            int respuesta = 0;
            try{respuesta = oEvaluacion.Actualizar(objEvaluacion);}
            catch(Exception ex){ respuesta = 0; }

            if (respuesta > 0) { respuestaTest = true; }

            Assert.IsTrue(respuestaTest);
        }
    }
}
