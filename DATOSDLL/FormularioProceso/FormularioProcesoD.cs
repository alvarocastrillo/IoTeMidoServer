
using ENTIDADESDLL.FormularioProceso;
using MENSAJESDLL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DATOSDLL.FormularioProceso
{
    public class FormularioProcesoD
    {
        public List<FormularioProcesoE> GetLista(Object[] parametros)
        {
            List<FormularioProcesoE> result = new List<FormularioProcesoE>();
            Mensaje mensaje;

        AccesoDatos acceso = new AccesoDatos();
            SqlDataReader sqlDataReader = acceso.GetDataReader(out mensaje, parametros, "prFormularioProceso");

            if (mensaje.Titulo == null)
            {
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {

                            result.Add(new FormularioProcesoE()
                            {
                                Id = sqlDataReader.GetInt64(sqlDataReader.GetOrdinal("Id")),
                                Observacion = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Observacion")),
                                Formulario = new FormularioE()
                                {
                                    Nombre = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Form")),

                                }
                            });

                    }
                }
            }
            else
            {
                result.Add(new FormularioProcesoE()
                {
                    Mensaje = new Mensaje(sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("IdError")), "Listado de Permisos", sqlDataReader.GetString(sqlDataReader.GetOrdinal("MensajeError")), "Listado de FormularioProcesoes", TipoMensaje.Error),
                });
            }
            sqlDataReader.Close();
            sqlDataReader = null;

            acceso.Desconectar();

            return result;
        }

        public FormularioProcesoE SetFormularioProceso(Object[] parametros)
        {
            FormularioProcesoE result = new FormularioProcesoE();
            Mensaje mensaje;

            AccesoDatos acceso = new AccesoDatos();
            SqlDataReader sqlDataReader = acceso.GetDataReader(out mensaje, parametros, "prFormularioProceso");

            if (mensaje.Titulo == null)
            {
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        result = new FormularioProcesoE()
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

        public FormularioProcesoE GetFormularioProceso(Object[] parametros)
        {
            Mensaje mensaje;
            FormularioProcesoE result = new FormularioProcesoE();
            AccesoDatos acceso = new AccesoDatos();
            SqlDataReader sqlDataReader = acceso.GetDataReader(out mensaje, parametros, "prFormularioProceso");

            while (sqlDataReader.Read())
            {


                if (mensaje.Titulo == null)
                {
                    if (sqlDataReader.HasRows)
                    {
                        result = new FormularioProcesoE()
                        {
                            Id = sqlDataReader.GetInt64(sqlDataReader.GetOrdinal("Id")),


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

        public List<FormularioProcesoE> getFormularioProcesoesTipoCom(Object[] parametros)
        {
            List<FormularioProcesoE> result = new List<FormularioProcesoE>();
            Mensaje mensaje;

            AccesoDatos acceso = new AccesoDatos();
            SqlDataReader sqlDataReader = acceso.GetDataReader(out mensaje, parametros, "prFormularioProceso");

            if (mensaje.Titulo == null)
            {
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                            result.Add(new FormularioProcesoE()
                            {
                                Id = sqlDataReader.GetInt64(sqlDataReader.GetOrdinal("Id")),

                            });
                    }
                }
            }
            
            sqlDataReader.Close();
            sqlDataReader = null;

            acceso.Desconectar();

            return result;
        }


        public FormularioProcesoE DeleteFormularioProceso(Object[] parametros)
        {
            FormularioProcesoE result = new FormularioProcesoE();
            Mensaje mensaje;

            AccesoDatos acceso = new AccesoDatos();
            SqlDataReader sqlDataReader = acceso.GetDataReader(out mensaje, parametros, "prFormularioProceso");

            if (mensaje.Titulo == null)
            {
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        result = new FormularioProcesoE()
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

        public FormularioProcesoE getListaFormularioProcesoGateway(Object[] parametros)
        {
            FormularioProcesoE result = new FormularioProcesoE();
            Mensaje mensaje;

            AccesoDatos acceso = new AccesoDatos();
            SqlDataReader sqlDataReader = acceso.GetDataReader(out mensaje, parametros, "prFormularioProceso");

            if (mensaje.Titulo == null)
            {
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        result = new FormularioProcesoE()
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
