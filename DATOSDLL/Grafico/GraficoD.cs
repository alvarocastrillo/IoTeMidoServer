
using ENTIDADESDLL.Aparato;
using ENTIDADESDLL.Dashboard;
using ENTIDADESDLL.Dispositivo;
using ENTIDADESDLL.Grafico;
using ENTIDADESDLL.Magnitud;
using ENTIDADESDLL.Red;
using ENTIDADESDLL.Unidad;
using MENSAJESDLL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DATOSDLL.Grafico
{
    public class GraficoD
    {
        public List<GraficoE> GetGraficoLista(Object[] parametros)
        {
            List<GraficoE> result = new List<GraficoE>();
            Mensaje mensaje;
            AccesoDatos acceso = new AccesoDatos();
            SqlDataReader sqlDataReader = acceso.GetDataReader(out mensaje, parametros, "prGrafico");

            if (mensaje.Titulo == null)
            {
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        if (sqlDataReader.GetString(sqlDataReader.GetOrdinal("MensajeError")) == "")
                        {
                            result.Add(new GraficoE()
                            {
                              
                                Id = sqlDataReader.GetInt64(sqlDataReader.GetOrdinal("Id")),
                                Titulo = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Titulo")),
                                Tipo = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Tipo")),
                                Maximo = sqlDataReader.GetDouble(sqlDataReader.GetOrdinal("Maximo")),
                                Minimo = sqlDataReader.GetDouble(sqlDataReader.GetOrdinal("Minimo")),
                                UmbralMax = sqlDataReader.GetDouble(sqlDataReader.GetOrdinal("UmbralMax")),
                                UmbralMin = sqlDataReader.GetDouble(sqlDataReader.GetOrdinal("UmbralMin")),
                                Resolucion = sqlDataReader.GetDouble(sqlDataReader.GetOrdinal("Resolucion")),
                                Valor = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("Valor")),
                                UnidadTiempo = sqlDataReader.GetString(sqlDataReader.GetOrdinal("UnidadTiempo")),
                                Color = String.IsNullOrEmpty(sqlDataReader["Color"].ToString()) ? "" : (String)sqlDataReader["Color"],
                                Serie = String.IsNullOrEmpty(sqlDataReader["Serie"].ToString()) ? "" : (String)sqlDataReader["Serie"],
                                Semana = sqlDataReader.IsDBNull(sqlDataReader.GetOrdinal("Semana")) ? 0 : sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("Semana")),

                                Aparato = new AparatoE()
                                {
                                    Id = sqlDataReader.GetInt64(sqlDataReader.GetOrdinal("Idapa")),
                                    Nombre = sqlDataReader.GetString(sqlDataReader.GetOrdinal("nomapa")),
                                    Orden = sqlDataReader.IsDBNull(sqlDataReader.GetOrdinal("Orden")) ? 0 : sqlDataReader.GetInt64(sqlDataReader.GetOrdinal("Orden")),
                                    Codigo = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Tag")),
                                    Tipo_aparato = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Tipo_aparato")),
                                    Dispositivo = new DispositivoE()
                                    {
                                        Id = sqlDataReader.GetInt64(sqlDataReader.GetOrdinal("Iddisp")),
                                        IMEI = sqlDataReader.GetString(sqlDataReader.GetOrdinal("IMEI")),
                                        EUI = sqlDataReader.GetString(sqlDataReader.GetOrdinal("EUI")),
                                        Tipo_com = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Tipo_com")),
                                        Batch = (Boolean)sqlDataReader["Batch"],
                                        Nombre = sqlDataReader.GetString(sqlDataReader.GetOrdinal("nomdisp")),
                                        Parentid = sqlDataReader.GetInt64(sqlDataReader.GetOrdinal("Parentid")),
                                        Unidad_tiempo = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Unidad_tiempo")),
                                        Valor_UT = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Valor_UT"))

                                    },
                                    Unidad = new UnidadE ()
                                    {
                                        Id = sqlDataReader.GetInt64(sqlDataReader.GetOrdinal("iduni")),
                                        Nombre = sqlDataReader.GetString(sqlDataReader.GetOrdinal("nomuni")),
                                    },
                                    Magnitud = new MagnitudE()
                                    {
                                        Id = sqlDataReader.GetInt64(sqlDataReader.GetOrdinal("idmag")),
                                        Nombre = sqlDataReader.GetString(sqlDataReader.GetOrdinal("nommag")),
                                    },

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
                            result.Add(new GraficoE()
                            {
                                Mensaje = new Mensaje(sqlDataReader.GetInt64(sqlDataReader.GetOrdinal("IdError")), "Listado Graficos", sqlDataReader.GetString(sqlDataReader.GetOrdinal("MensajeError")), "Listando Graficoes", TipoMensaje.Error),
                            }
                            );
                        }
                    }
                }
            }
            else
            {
                result.Add(new GraficoE()
                {
                    Mensaje = new Mensaje(sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("IdError")), "Listado de Graficos", sqlDataReader.GetString(sqlDataReader.GetOrdinal("MensajeError")), "Listado de Graficoes", TipoMensaje.Error),
                });
            }
            sqlDataReader.Close();
            sqlDataReader = null;

            acceso.Desconectar();

            return result;
        }

        public List<GraficoE> GetRegistroGraf(Object[] parametros)
        {
            List<GraficoE> result = new List<GraficoE>();
            Mensaje mensaje;
            AccesoDatos acceso = new AccesoDatos();
            SqlDataReader sqlDataReader = acceso.GetDataReader(out mensaje, parametros, "prGrafico");

            if (mensaje.Titulo == null)
            {
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        if (sqlDataReader.GetString(sqlDataReader.GetOrdinal("MensajeError")) == "")
                        {
                            result.Add(new GraficoE()
                            {
                                Id = sqlDataReader.GetInt64(sqlDataReader.GetOrdinal("Id")),
                                Titulo = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Titulo")),       

                            });
                        }
                        else
                        {
                            result.Add(new GraficoE()
                            {
                                Mensaje = new Mensaje(sqlDataReader.GetInt64(sqlDataReader.GetOrdinal("IdError")), "Listado Graficos", sqlDataReader.GetString(sqlDataReader.GetOrdinal("MensajeError")), "Listando Graficoes", TipoMensaje.Error),
                            }
                            );
                        }
                    }
                }
            }
            else
            {
                result.Add(new GraficoE()
                {
                    Mensaje = new Mensaje(sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("IdError")), "Listado de Graficos", sqlDataReader.GetString(sqlDataReader.GetOrdinal("MensajeError")), "Listado de Graficoes", TipoMensaje.Error),
                });
            }
            sqlDataReader.Close();
            sqlDataReader = null;

            acceso.Desconectar();

            return result;
        }

        public GraficoE SetGrafico(Object[] parametros)
        {
            GraficoE result = new GraficoE();
            Mensaje mensaje;

            AccesoDatos acceso = new AccesoDatos();
            SqlDataReader sqlDataReader = acceso.GetDataReader(out mensaje, parametros, "prGrafico");

            if (mensaje.Titulo == null)
            {
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        result = new GraficoE()
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

        public GraficoE GetGrafico(Object[] parametros)
        {
            Mensaje mensaje;
            GraficoE result = new GraficoE();
            AccesoDatos acceso = new AccesoDatos();
            SqlDataReader sqlDataReader = acceso.GetDataReader(out mensaje, parametros, "prGrafico");

            while (sqlDataReader.Read())
            {


                if (mensaje.Titulo == null)
                {
                    if (sqlDataReader.HasRows)
                    {
                        result = new GraficoE()
                        {
                            Id = sqlDataReader.GetInt64(sqlDataReader.GetOrdinal("Id")),
                            Titulo = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Titulo")),
                            Tipo = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Tipo")),
                            Maximo = sqlDataReader.IsDBNull(sqlDataReader.GetOrdinal("Maximo")) ? 0 : sqlDataReader.GetFloat(sqlDataReader.GetOrdinal("Maximo")),
                            Minimo = sqlDataReader.IsDBNull(sqlDataReader.GetOrdinal("Minimo")) ? 0 : sqlDataReader.GetFloat(sqlDataReader.GetOrdinal("Minimo")),
                            UmbralMax = sqlDataReader.IsDBNull(sqlDataReader.GetOrdinal("UmbralMax")) ? 0 : sqlDataReader.GetFloat(sqlDataReader.GetOrdinal("UmbralMax")),
                            UmbralMin = sqlDataReader.IsDBNull(sqlDataReader.GetOrdinal("UmbralMin")) ? 0 : sqlDataReader.GetFloat(sqlDataReader.GetOrdinal("UmbralMin")),
                            Resolucion = sqlDataReader.IsDBNull(sqlDataReader.GetOrdinal("Resolucion")) ? 0 : sqlDataReader.GetFloat(sqlDataReader.GetOrdinal("Resolucion")),
                            Valor = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("Valor")),
                            UnidadTiempo = sqlDataReader.GetString(sqlDataReader.GetOrdinal("UnidadTiempo")),

                            Aparato = new AparatoE()
                            {
                                Id = sqlDataReader.GetInt64(sqlDataReader.GetOrdinal("Id_apa")),
                                Id_Nodo = sqlDataReader.GetInt64(sqlDataReader.GetOrdinal("Id_Nodo")),
                                Orden = sqlDataReader.IsDBNull(sqlDataReader.GetOrdinal("Orden")) ? 0 : sqlDataReader.GetInt64(sqlDataReader.GetOrdinal("Orden")),

                            }
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


        public GraficoE DeleteGrafico(Object[] parametros)
        {
            GraficoE result = new GraficoE();
            Mensaje mensaje;

            AccesoDatos acceso = new AccesoDatos();
            SqlDataReader sqlDataReader = acceso.GetDataReader(out mensaje, parametros, "prGrafico");

            if (mensaje.Titulo == null)
            {
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        result = new GraficoE()
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
