using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Data.Test.Sql.Util
{
    public static class Conexion
    {
        private static string strCadenaConexion { get; set; }
        private static DateTime? dtmFechaConexion { get; set; }

        private static string strCadenaConexionSuc { get; set; }

        public static string ObtenerConexion()
        {
            if (strCadenaConexion == null || dtmFechaConexion == null || DateTime.Now.ToShortDateString() != dtmFechaConexion.Value.ToShortDateString())
            {
                strCadenaConexion = "Data Source=.;Initial Catalog=BD_Evaluacion;User ID=Desarrollo;Password=Desa$1420;";
                dtmFechaConexion = DateTime.Now;
            }
            return strCadenaConexion;
        }
    }
}
