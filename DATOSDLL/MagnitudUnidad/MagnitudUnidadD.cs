
using ENTIDADESDLL.Unidad;
using MENSAJESDLL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DATOSDLL.MagnitudUnidad
{
    public class MagnitudUnidadD
    {

        public List<UnidadE> GetUnidades(String SQL, Object[] parametros)
        {
            List<UnidadE> result = new List<UnidadE>();
            Mensaje mensaje;
            AccesoDatos acceso = new AccesoDatos();
            SqlDataReader sqlDataReader = acceso.GetDataReader(out mensaje, parametros, "prMagnitudUnidad");
         

            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    result.Add(new UnidadE()
                    {
                        Id = (Int64)sqlDataReader["Id"],
                        Nombre = (String)sqlDataReader["Nombre"],
                        Id_Magnitud = (Int64)sqlDataReader["Id_Magnitud"]

                    });
                }
            }
            if (sqlDataReader.IsClosed == false)
                sqlDataReader.Close();

            sqlDataReader = null;

            acceso.Desconectar();


            return result;
        }

        /// <summary>
        /// Obtiene todas las unidades con el Id Magnitud
        /// </summary>
        /// <param name="SQL"></param>
        /// <param name="parametros"></param>
        /// <returns></returns>
        public List<UnidadE> GetAllUnidadMagnitud(String SQL, Object[] parametros)
        {
            List<UnidadE> result = new List<UnidadE>();

            Mensaje mensaje;
            AccesoDatos acceso = new AccesoDatos();
            SqlDataReader sqlDataReader = acceso.GetDataReader(out mensaje, parametros, "prMagnitudUnidad");


            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    result.Add(new UnidadE()
                    {
                        Id = (Int64)sqlDataReader["Id"],
                        Nombre = (String)sqlDataReader["Nombre"],
                        Id_Magnitud = (Int64)sqlDataReader["Id_Magnitud"]
                    });
                }
            }

            if (sqlDataReader.IsClosed == false)
                sqlDataReader.Close();

            sqlDataReader = null;

            acceso.Desconectar();

            return result;
        }

    }
}
