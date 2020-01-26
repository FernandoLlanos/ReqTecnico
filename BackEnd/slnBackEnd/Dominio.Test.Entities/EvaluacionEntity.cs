using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Test.Entities
{
    public class EvaluacionEntity
    {
        public int intIdEvaluacion { get; set; }
        public int intIdPersona { get; set; }
        public string strCorreoElectronico { get; set; }
        public string strNombreCompleto { get; set; }
        public int intCalificacion { get; set; }
        public char chEstado  { get; set; }
        public string strUsuarioCreacion { get; set; }
        public DateTime dtFechaCreacion { get; set; }
    }
}
