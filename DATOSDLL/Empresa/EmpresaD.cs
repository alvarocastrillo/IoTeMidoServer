using ENTIDADESDDL.Empresa;
using MENSAJESDLL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DATOSDLL.Empresa
{
    public class EmpresaD
    {
        public List<EmpresaE> GetEmpresaLista(Object[] parametros)
        {
            List<EmpresaE> result = new List<EmpresaE>();
            Mensaje mensaje;

            AccesoDatos acceso = new AccesoDatos();
            SqlDataReader sqlDataReader = acceso.GetDataReader(out mensaje, parametros, "prEmpresa");

            if (mensaje.Titulo == null)
            {
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        result.Add(new EmpresaE()
                        {
                            Id = sqlDataReader.GetInt64(sqlDataReader.GetOrdinal("Id")),
                            RazonSocial = sqlDataReader.GetString(sqlDataReader.GetOrdinal("NombreEmpresa")),
                            //Nombres = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Nombres")),
                            //Apellidos = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Apellidos")),
                            Identificacion = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Identificacion")),
                            Direccion = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Direccion")),
                            Telefono = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Telefono")),
                            Estado = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Estado")),
                        });
                    }
                }
            }
            sqlDataReader.Close();
            sqlDataReader = null;

            acceso.Desconectar();

            return result;
        }
    }
}
