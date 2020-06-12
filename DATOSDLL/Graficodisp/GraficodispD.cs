
using ENTIDADESDLL.Dashboard;
using ENTIDADESDLL.Dispositivo;
using ENTIDADESDLL.Graficodisp;
using ENTIDADESDLL.Red;
using MENSAJESDLL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DATOSDLL.GraficodispD
{
    public class GraficodispD
    {
        public List<GraficodispE> GetGraficodispLista(Object[] parametros)
        {
            List<GraficodispE> result = new List<GraficodispE>();
            Mensaje mensaje;
            AccesoDatos acceso = new AccesoDatos();
            SqlDataReader sqlDataReader = acceso.GetDataReader(out mensaje, parametros, "prGraficodisp");

            if (mensaje.Titulo == null)
            {
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        if (sqlDataReader.GetString(sqlDataReader.GetOrdinal("MensajeError")) == "")
                        {
                            result.Add(new GraficodispE()
                            {
                                Id = sqlDataReader.GetInt64(sqlDataReader.GetOrdinal("Id")),
                                Titulo = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Titulo")),
                                Tipo = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Tipo")),
                                Dispositivo = new DispositivoE()
                                {
                                    Id = sqlDataReader.GetInt64(sqlDataReader.GetOrdinal("Iddisp")),
                                    Nombre = sqlDataReader.GetString(sqlDataReader.GetOrdinal("nomdisp")),
                                    IMEI = sqlDataReader.GetString(sqlDataReader.GetOrdinal("IMEI")),
                                    EUI = sqlDataReader.GetString(sqlDataReader.GetOrdinal("EUI")),
                                    Tipo_com = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Tipo_com")),
                                    Batch = (Boolean)sqlDataReader["Batch"],
                                    Parentid = sqlDataReader.GetInt64(sqlDataReader.GetOrdinal("Parentid")),

                                },
                                Dashboard = new DashboardE()
                                {
                                    Id = sqlDataReader.GetInt64(sqlDataReader.GetOrdinal("Iddash")),
                                    Nombre = sqlDataReader.GetString(sqlDataReader.GetOrdinal("NomDash")),
                                    Red = new RedE()
                                    {
                                       Id = sqlDataReader.GetInt64(sqlDataReader.GetOrdinal("Idred")),
                                    }
                                   
                                }
                                
                            });
                        }
                        else
                        {
                            result.Add(new GraficodispE()
                            {
                                Mensaje = new Mensaje(sqlDataReader.GetInt64(sqlDataReader.GetOrdinal("IdError")), "Listado Graficodisps", sqlDataReader.GetString(sqlDataReader.GetOrdinal("MensajeError")), "Listando Graficodispes", TipoMensaje.Error),
                            }
                            );
                        }
                    }
                }
            }
            else
            {
                result.Add(new GraficodispE()
                {
                    Mensaje = new Mensaje(sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("IdError")), "Listado de Graficodisps", sqlDataReader.GetString(sqlDataReader.GetOrdinal("MensajeError")), "Listado de Graficodispes", TipoMensaje.Error),
                });
            }
            sqlDataReader.Close();
            sqlDataReader = null;

            acceso.Desconectar();

            return result;
        }

        public List<GraficodispE> GetRegistroGrafdisp(Object[] parametros)
        {
            List<GraficodispE> result = new List<GraficodispE>();
            Mensaje mensaje;
            AccesoDatos acceso = new AccesoDatos();
            SqlDataReader sqlDataReader = acceso.GetDataReader(out mensaje, parametros, "prGraficodisp");

            if (mensaje.Titulo == null)
            {
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        if (sqlDataReader.GetString(sqlDataReader.GetOrdinal("MensajeError")) == "")
                        {
                            result.Add(new GraficodispE()
                            {
                                Id = sqlDataReader.GetInt64(sqlDataReader.GetOrdinal("Id")),
                                Titulo = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Titulo")),

                            });
                        }
                        else
                        {
                            result.Add(new GraficodispE()
                            {
                                Mensaje = new Mensaje(sqlDataReader.GetInt64(sqlDataReader.GetOrdinal("IdError")), "Listado Graficodisps", sqlDataReader.GetString(sqlDataReader.GetOrdinal("MensajeError")), "Listando Graficodispes", TipoMensaje.Error),
                            }
                            );
                        }
                    }
                }
            }
            else
            {
                result.Add(new GraficodispE()
                {
                    Mensaje = new Mensaje(sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("IdError")), "Listado de Graficodisp", sqlDataReader.GetString(sqlDataReader.GetOrdinal("MensajeError")), "Listado de Graficodispes", TipoMensaje.Error),
                });
            }
            sqlDataReader.Close();
            sqlDataReader = null;

            acceso.Desconectar();

            return result;
        }

        public GraficodispE SetGraficodisp(Object[] parametros)
        {
            GraficodispE result = new GraficodispE();
            Mensaje mensaje;

            AccesoDatos acceso = new AccesoDatos();
            SqlDataReader sqlDataReader = acceso.GetDataReader(out mensaje, parametros, "prGraficodisp");

            if (mensaje.Titulo == null)
            {
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        result = new GraficodispE()
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

        public GraficodispE GetGraficodisp(Object[] parametros)
        {
            Mensaje mensaje;
            GraficodispE result = new GraficodispE();
            AccesoDatos acceso = new AccesoDatos();
            SqlDataReader sqlDataReader = acceso.GetDataReader(out mensaje, parametros, "prGraficodisp");

            while (sqlDataReader.Read())
            {


                if (mensaje.Titulo == null)
                {
                    if (sqlDataReader.HasRows)
                    {
                        result = new GraficodispE()
                        {
                            Id = sqlDataReader.GetInt64(sqlDataReader.GetOrdinal("Id")),
                            Titulo = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Titulo")),                     
                            //Dispositivo = new DispositivoE()
                            //{
                            //    Id = sqlDataReader.GetInt64(sqlDataReader.GetOrdinal("iddisp")),
                                
                            //}
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


        public GraficodispE DeleteGraficodisp(Object[] parametros)
        {
            GraficodispE result = new GraficodispE();
            Mensaje mensaje;

            AccesoDatos acceso = new AccesoDatos();
            SqlDataReader sqlDataReader = acceso.GetDataReader(out mensaje, parametros, "prGraficodisp");

            if (mensaje.Titulo == null)
            {
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        result = new GraficodispE()
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
