using Dominio.Test.Entities;
using Infraestructura.Data.Test.Interfaces;
using Infraestructura.Data.Test.Sql.Util;
using Infraestructura.Transversal.Exepciones;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Data.Test.Sql
{
    public class EvaluacionRepository : IEvaluacionRepository
    {
        /// <summary>
        /// Permite la búsqueda de Evaluaciones
        /// </summary>
        /// <param name="strCorreoElectronico">Correo Electrónico</param>
        /// <param name="strFechaInicio">Fecha de Inicio</param>
        /// <param name="strFechaFin">Fecha Fin</param>
        /// <returns>Lista de Evaluaciones</returns> 
        public ICollection<EvaluacionEntity> Listar(string strCorreoElectronico, DateTime? dtFechaInicio, DateTime? dtFechaFin)
        {
            List<EvaluacionEntity> lst = new List<EvaluacionEntity>();

            using (SqlConnection con = new SqlConnection(Conexion.ObtenerConexion()))
            {
                using (SqlCommand command = con.CreateCommand())
                {
                    command.CommandText = "Usp_Listar_Evaluacion";
                    command.CommandType = CommandType.StoredProcedure;
                    SqlParameter[] parameters = new SqlParameter[3];

                    parameters[0] = new SqlParameter("@strCorreoElectronico", SqlDbType.VarChar);
                    parameters[0].Value = strCorreoElectronico;

                    parameters[1] = new SqlParameter("@dtFechaInicio", SqlDbType.Date);
                    parameters[1].Value = dtFechaInicio;

                    parameters[2] = new SqlParameter("@dtFechaFin", SqlDbType.Date);
                    parameters[2].Value = dtFechaFin;


                    foreach (SqlParameter parameter in parameters)
                    {
                        command.Parameters.Add(parameter);
                    }

                    con.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lst.Add(MapearEntity(reader));
                        }
                    }
                }
            }

            return lst;
        }

        /// <summary>
        /// Permite la búsqueda de Evaluaciones por correo electrónico
        /// </summary>
        /// <param name="strCorreoElectronico">Correo Electrónico</param>
        /// <returns>Lista de Evaluaciones</returns> 
        public ICollection<EvaluacionEntity> ListarPorCorreoElectronico(string strCorreoElectronico)
        {
            List<EvaluacionEntity> lst = new List<EvaluacionEntity>();

            using (SqlConnection con = new SqlConnection(Conexion.ObtenerConexion()))
            {
                using (SqlCommand command = con.CreateCommand())
                {
                    command.CommandText = "Usp_Listar_Evaluacion_Por_Correo";
                    command.CommandType = CommandType.StoredProcedure;
                    SqlParameter[] parameters = new SqlParameter[1];

                    parameters[0] = new SqlParameter("@strCorreoElectronico", SqlDbType.VarChar);
                    parameters[0].Value = strCorreoElectronico;

                    foreach (SqlParameter parameter in parameters)
                    {
                        command.Parameters.Add(parameter);
                    }

                    con.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lst.Add(MapearEntity(reader));
                        }
                    }
                }
            }

            return lst;
        }

        /// <summary>
        /// Permite Registrar Evaluaciones
        /// </summary>
        /// <param name="oEvaluacion">Objeto de Entidad de Evaluaciones</param>
        /// <returns>1 si se registró correctamente</returns>
        public int Registrar(EvaluacionEntity oInteresEntity)
        {
            int resultado = 0;
            using (SqlConnection con = new SqlConnection(Conexion.ObtenerConexion()))
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "Usp_Registrar_Evaluacion";
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter[] parameters = new SqlParameter[3];

                    parameters[0] = new SqlParameter("@strCorreoElectronico", SqlDbType.VarChar);
                    parameters[0].Value = oInteresEntity.strCorreoElectronico;

                    parameters[1] = new SqlParameter("@strNombreCompleto", SqlDbType.VarChar);
                    parameters[1].Value = oInteresEntity.strNombreCompleto;

                    parameters[2] = new SqlParameter("@intCalificacion", SqlDbType.Int);
                    parameters[2].Value = oInteresEntity.intCalificacion;


                    foreach (SqlParameter parameter in parameters)
                    {
                        cmd.Parameters.Add(parameter);
                    }

                    con.Open();
                    resultado = cmd.ExecuteNonQuery();

                    if (resultado < 1)
                    {
                        throw new TestException("Ocurrio un error en la BD");
                    }
                }
            }
            return resultado;
        }

        /// <summary>
        /// Permite Actualizar Evaluaciones
        /// </summary>
        /// <param name="oEvaluacion">Objeto de Entidad de Evaluaciones</param>
        /// <returns>1 si se actualizó correctamente</returns> 
        public int Actualizar(EvaluacionEntity oInteresEntity)
        {
            int resultado = 0;
            using (SqlConnection con = new SqlConnection(Conexion.ObtenerConexion()))
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "Usp_Actualizar_Evaluacion";
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter[] parameters = new SqlParameter[2];

                    parameters[0] = new SqlParameter("@intIdEvaluacion", SqlDbType.Int);
                    parameters[0].Value = oInteresEntity.intIdEvaluacion;

                    parameters[1] = new SqlParameter("@intCalificacion", SqlDbType.VarChar);
                    parameters[1].Value = oInteresEntity.intCalificacion;


                    foreach (SqlParameter parameter in parameters)
                    {
                        cmd.Parameters.Add(parameter);
                    }

                    con.Open();
                    resultado = cmd.ExecuteNonQuery();

                    if (resultado < 1)
                    {
                        throw new TestException("Ocurrio un Error en la BD");
                    }
                }
            }
            return resultado;
        }

        public EvaluacionEntity MapearEntity(SqlDataReader reader)
        {
            EvaluacionEntity objEvaluacionEntity = new EvaluacionEntity();

            objEvaluacionEntity.intIdEvaluacion = HelperDAL.Int32(reader["intIdEvaluacion"]);
            objEvaluacionEntity.intIdPersona = HelperDAL.Int32(reader["intIdPersona"]);
            objEvaluacionEntity.strCorreoElectronico = HelperDAL.String(reader["strCorreoElectronico"]);
            objEvaluacionEntity.strNombreCompleto = HelperDAL.String(reader["strNombreCompleto"]);
            objEvaluacionEntity.intCalificacion = HelperDAL.Int32(reader["intCalificacion"]);
            objEvaluacionEntity.dtFechaCreacion = HelperDAL.DateTime(reader["dtFechaCreacion"]);
            objEvaluacionEntity.chEstado = HelperDAL.Char(reader["chEstado"]);

            return objEvaluacionEntity;
        }

    }
}
