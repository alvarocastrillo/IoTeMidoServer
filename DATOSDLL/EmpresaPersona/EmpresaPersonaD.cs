using ENTIDADESDDL.Empresa;
using ENTIDADESDLL.EmpresaPersona;
using MENSAJESDLL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DATOSDLL.Empresa
{
    public class EmpresaPersonaD
    {
        /*
        public List<EmpresaPersonaE> GetEmpresaPersona(Object[] parametros)
        {
            List<EmpresaPersonaE> result = new List<EmpresaPersonaE>();
            Mensaje mensaje;

            AccesoDatos acceso = new AccesoDatos();
            SqlDataReader sqlDataReader = acceso.GetDataReader(out mensaje, parametros, "prEmpresa2");

            if (mensaje.Titulo == null)
            {
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        result.Add( new EmpresaPersonaE()
                        {                            
                            Id_Empresa = sqlDataReader.GetInt64(sqlDataReader.GetOrdinal("Id_Empresa")),
                            RazonSocial = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Nombre"))                            
                        });
                    }
                }
            }
            sqlDataReader.Close();
            sqlDataReader = null;

            acceso.Desconectar();

            return result;
        }*/
    }
}
