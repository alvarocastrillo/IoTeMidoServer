using ENTIDADESDDL.Empresa;
using ENTIDADESDDL.Lista;
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


        public EmpresaE SetEmpresa(Object[] parametros)
        {
            EmpresaE result = new EmpresaE();
            Mensaje mensaje;

            AccesoDatos acceso = new AccesoDatos();
            SqlDataReader sqlDataReader = acceso.GetDataReader(out mensaje, parametros, "prEmpresa");

            if (mensaje.Titulo == null)
            {
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        result = new EmpresaE()
                        {
                            Mensaje = new Mensaje()
                            {
                                Titulo = sqlDataReader.GetString(sqlDataReader.GetOrdinal("MENSAJEERROR")),
                                Id = sqlDataReader.GetInt64(sqlDataReader.GetOrdinal("IDERROR"))
                            }
                        };
                    };
                }
            }
            sqlDataReader.Close();
            sqlDataReader = null;
            acceso.Desconectar();
            return result;
        }

        public EmpresaE GetEmpresa(Object[] parametros)
        {
            Mensaje mensaje;
            EmpresaE result = new EmpresaE();
            AccesoDatos acceso = new AccesoDatos();
            SqlDataReader sqlDataReader = acceso.GetDataReader(out mensaje, parametros, "prEmpresa");

            while (sqlDataReader.Read())
            {


                if (mensaje.Titulo == null)
                {
                    if (sqlDataReader.HasRows)
                    {
                        result = new EmpresaE()
                        {
                            Id = sqlDataReader.GetInt64(sqlDataReader.GetOrdinal("Id")),
                            Id_Identificacion = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Id_Identificacion")),
                            Id_Departamento = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Id_Departamento")),
                            Id_Ciudad = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Id_Ciudad")),
                            Identificacion = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Identificacion")),
                            Naturaleza = new ListaE()
                            {
                                IdString = String.IsNullOrEmpty(sqlDataReader["Id_Naturaleza"].ToString()) ? "" : (String)sqlDataReader["Id_Naturaleza"],
                                Nombre = String.IsNullOrEmpty(sqlDataReader["Id_Naturaleza"].ToString()) ? "" : (String)sqlDataReader["Id_Naturaleza"],

                            },

                            RazonSocial = sqlDataReader.GetString(sqlDataReader.GetOrdinal("RazonSocial")),
                            Nombres = String.IsNullOrEmpty(sqlDataReader["Nombres"].ToString()) ? " " : (String)sqlDataReader["Nombres"],
                            Apellidos = String.IsNullOrEmpty(sqlDataReader["Apellidos"].ToString()) ? " " : (String)sqlDataReader["Apellidos"],
                            Direccion = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Direccion")),
                            Telefono = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Telefono")),
                            Contacto = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Contacto")),
                            Cargo = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Cargo")),
                            Observacion = String.IsNullOrEmpty(sqlDataReader["Observacion"].ToString()) ? " " : (String)sqlDataReader["Observacion"],
                            Estado = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Estado")),
                        };
                    }
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
