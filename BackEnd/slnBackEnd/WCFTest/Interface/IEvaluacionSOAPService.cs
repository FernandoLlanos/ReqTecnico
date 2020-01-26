using Dominio.Test.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFTest
{
    [ServiceContract]
    public interface IEvaluacionSOAPService
    {

        [OperationContract]
        ICollection<EvaluacionEntity> Listar(string strCorreoElectronico, string strFechaInicio, string strFechaFin);

        [OperationContract]
        ICollection<EvaluacionEntity> ListarPorCorreoElectronico(string strCorreoElectronico);

        [OperationContract]
        int RegistrarEvaluacion(EvaluacionEntity oEvaluacion);

        [OperationContract]
        int ActualizarEvaluacion(EvaluacionEntity oEvaluacion);
    }
}
