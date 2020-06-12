using ENTIDADESDDL.Empresa;
using ENTIDADESDDL.Persona;
using MENSAJESDLL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DATOSDLL.Persona
{
    public class PersonaD
    {
        /// <summary>
        /// Valida la autenticación del usuario
        /// </summary>
        /// <param name="parametros"></param>
        /// <param name="procedimiento"></param>
        /// <returns></returns>
        

      

        public List<EmpresaE> Empresas(Object[] parametros)
        {
            PersonaE result = new PersonaE();
            result.Empresas = new List<EmpresaE>();
            Mensaje mensaje;

            AccesoDatos acceso = new AccesoDatos();
            SqlDataReader sqlDataReader = acceso.GetDataReader(out mensaje, parametros, "prPersona2");

            if (mensaje.Titulo == null)
            {
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        result.Empresas.Add(new EmpresaE()
                        {
                            Id = sqlDataReader.GetInt64(sqlDataReader.GetOrdinal("Id")),
                            RazonSocial = sqlDataReader.GetString(sqlDataReader.GetOrdinal("RazonSocial"))
                        });
                    }
                }
            }
            sqlDataReader.Close();
            sqlDataReader = null;

            acceso.Desconectar();

            return result.Empresas;
        }


        public PersonaE getPersonaEmpresa(Object[] parametros)
        {
            Mensaje mensaje;
            PersonaE result = new PersonaE();
            AccesoDatos acceso = new AccesoDatos();
            SqlDataReader sqlDataReader = acceso.GetDataReader(out mensaje, parametros, "prPersona2");

            while (sqlDataReader.Read())
            {


                if (mensaje.Titulo == null)
                {
                    if (sqlDataReader.HasRows)
                    {
                        result = new PersonaE()
                        {
                            Id_Empresa = sqlDataReader.GetInt64(sqlDataReader.GetOrdinal("Id_Empresa"))

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

        public List<PersonaE> GetListaPersonas(Object[] parametros)
        {
            List<PersonaE> result = new List<PersonaE>();
            Mensaje mensaje;

            AccesoDatos acceso = new AccesoDatos();
            SqlDataReader sqlDataReader = acceso.GetDataReader(out mensaje, parametros, "prPersona2");

            if (mensaje.Titulo == null)
            {
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        if (sqlDataReader.GetString(sqlDataReader.GetOrdinal("MensajeError")) == "")
                        {
                            result.Add(new PersonaE()
                            {
                                Id = sqlDataReader.GetInt64(sqlDataReader.GetOrdinal("Id")),
                                Nombre = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Nombre")),
                                Apellido = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Apellido")),
                                Usuario = String.IsNullOrEmpty(sqlDataReader["Usuario"].ToString()) ? " " : (String)sqlDataReader["Usuario"],
                                Id_Identificacion = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Id_Identificacion")),
                                Identificacion = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Identificacion")),
                                Id_Empresa = sqlDataReader.GetInt64(sqlDataReader.GetOrdinal("Id_Empresa")),
                                Empresa = new EmpresaE()
                                {

                                    RazonSocial = sqlDataReader.GetString(sqlDataReader.GetOrdinal("NombreEmpresa"))
                                },
                                Direccion = String.IsNullOrEmpty(sqlDataReader["Direccion"].ToString()) ? " " : (String)sqlDataReader["Direccion"],
                                Telefono = String.IsNullOrEmpty(sqlDataReader["Telefono"].ToString()) ? " " : (String)sqlDataReader["Telefono"],
                                Cargo = String.IsNullOrEmpty(sqlDataReader["Cargo"].ToString()) ? " " : (String)sqlDataReader["Cargo"],
                                Email = String.IsNullOrEmpty(sqlDataReader["Email"].ToString()) ? " " : (String)sqlDataReader["Email"],
                                Estado = (Boolean)sqlDataReader["Estado"],
                            });
                        }
                    }
                }
            }
            sqlDataReader.Close();
            sqlDataReader = null;

            acceso.Desconectar();

            return result;
        }

        public PersonaE SetPersona(Object[] parametros)
        {
            PersonaE result = new PersonaE();
            Mensaje mensaje;

            AccesoDatos acceso = new AccesoDatos();
            SqlDataReader sqlDataReader = acceso.GetDataReader(out mensaje, parametros, "prPersona2");

            if (mensaje.Titulo == null)
            {
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        result = new PersonaE()
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

        public PersonaE GetPersona(Object[] parametros)
        {
            Mensaje mensaje;
            PersonaE result = new PersonaE();
            AccesoDatos acceso = new AccesoDatos();
            SqlDataReader sqlDataReader = acceso.GetDataReader(out mensaje, parametros, "prPersona2");

            while (sqlDataReader.Read())
            {


                if (mensaje.Titulo == null)
                {
                    if (sqlDataReader.HasRows)
                    {
                        result = new PersonaE()
                        {
                            Id = sqlDataReader.GetInt64(sqlDataReader.GetOrdinal("Id")),
                            Nombre = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Nombre")),
                            Apellido = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Apellido")),
                            Usuario = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Usuario")),
                            Id_Identificacion = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Id_Identificacion")),
                            Identificacion = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Identificacion")),
                            Id_Empresa = sqlDataReader.GetInt64(sqlDataReader.GetOrdinal("Id_Empresa")),
                            Direccion = String.IsNullOrEmpty(sqlDataReader["Direccion"].ToString()) ? " " : (String)sqlDataReader["Direccion"],
                            Telefono = String.IsNullOrEmpty(sqlDataReader["Telefono"].ToString()) ? " " : (String)sqlDataReader["Telefono"],
                            Cargo = String.IsNullOrEmpty(sqlDataReader["Cargo"].ToString()) ? " " : (String)sqlDataReader["Cargo"],
                            Email = String.IsNullOrEmpty(sqlDataReader["Email"].ToString()) ? " " : (String)sqlDataReader["Email"],
                            Estado = (Boolean)sqlDataReader["Estado"],

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

        public PersonaE VerificarUsuario(Object[] parametros)
        {
            Mensaje mensaje;
            PersonaE result = new PersonaE();
            AccesoDatos acceso = new AccesoDatos();
            SqlDataReader sqlDataReader = acceso.GetDataReader(out mensaje, parametros, "prPersona2");

            while (sqlDataReader.Read())
            {


                if (mensaje.Titulo == null)
                {
                    if (sqlDataReader.HasRows)
                    {
                        result = new PersonaE()
                        {
                            Usuario = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Usuario")),
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

        public PersonaE verificarEmail(Object[] parametros)
        {
            Mensaje mensaje;
            PersonaE result = new PersonaE();
            AccesoDatos acceso = new AccesoDatos();
            SqlDataReader sqlDataReader = acceso.GetDataReader(out mensaje, parametros, "prPersona2");

            while (sqlDataReader.Read())
            {


                if (mensaje.Titulo == null)
                {
                    if (sqlDataReader.HasRows)
                    {
                        result = new PersonaE()
                        {
                            Email = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Email")),
                            Id = sqlDataReader.GetInt64(sqlDataReader.GetOrdinal("Id")),
                            Id_Empresa = sqlDataReader.GetInt64(sqlDataReader.GetOrdinal("Id_Empresa")),
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

        public PersonaE DeletePersona(Object[] parametros)
        {
            PersonaE result = new PersonaE();
            Mensaje mensaje;

            AccesoDatos acceso = new AccesoDatos();
            SqlDataReader sqlDataReader = acceso.GetDataReader(out mensaje, parametros, "prPersona2");

            if (mensaje.Titulo == null)
            {
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        result = new PersonaE()
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

        public PersonaE ChangedPassword(Object[] parametros)
        {
            PersonaE result = new PersonaE();
            Mensaje mensaje;

            AccesoDatos acceso = new AccesoDatos();
            SqlDataReader sqlDataReader = acceso.GetDataReader(out mensaje, parametros, "prPersona2");

            if (mensaje.Titulo == null)
            {
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        result = new PersonaE()
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


    }
}
