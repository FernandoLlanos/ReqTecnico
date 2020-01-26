using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APITest.Models
{
    public class EvaluacionModel
    {
        public int intIdEvaluacion { get; set; }
        public string strCorreoElectronico { get; set; }
        public string strNombreCompleto { get; set; }
        public int intCalificacion { get; set; }
    }
}