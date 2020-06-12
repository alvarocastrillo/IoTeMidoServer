
using ENTIDADESDLL.Aparato;
using ENTIDADESDLL.Dispositivo;
using ENTIDADESDLL.Magnitud;
using ENTIDADESDLL.Unidad;
using MENSAJESDLL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;


namespace DATOSDLL.AparatoD
{
    public  class AparatoD
    {
        public List<AparatoE> GetAllAparatos(Object[] parametros)
        {
            List<AparatoE> result = new List<AparatoE>();
            Mensaje mensaje;

            AccesoDatos acceso = new AccesoDatos();
            SqlDataReader sqlDataReader = acceso.GetDataReader(out mensaje, parametros, "prAparato");

            if (mensaje.Titulo == null)
            {
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        result.Add(new AparatoE()
                        {
                            Id = sqlDataReader.GetInt64(sqlDataReader.GetOrdinal("Id")),
                            Nombre = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Nombre")),
                            Modelo = String.IsNullOrEmpty(sqlDataReader["Modelo"].ToString()) ? "" : (String)sqlDataReader["Modelo"],
                            Fabricante = String.IsNullOrEmpty(sqlDataReader["Fabricante"].ToString()) ? "" : (String)sqlDataReader["Fabricante"],
                            Serial = String.IsNullOrEmpty(sqlDataReader["Serial"].ToString()) ? "" : (String)sqlDataReader["Serial"],
                            Codigo = sqlDataReader.GetString(sqlDataReader.GetOrdinal("TagApa")),
                            Tipo = sqlDataReader.GetString(sqlDataReader.GetOrdinal("TipoMec")),
                            Tipo_aparato = String.IsNullOrEmpty(sqlDataReader["Tipo_aparato"].ToString()) ? "" : (String)sqlDataReader["Tipo_aparato"],
                            Posicion = sqlDataReader.IsDBNull(sqlDataReader.GetOrdinal("Posicion")) ? 0 : sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("Posicion")),
                            Orden = sqlDataReader.IsDBNull(sqlDataReader.GetOrdinal("Orden")) ? 0 : sqlDataReader.GetInt64(sqlDataReader.GetOrdinal("Orden")),
                            // UltimaVerificacion = sqlDataReader.IsDBNull(sqlDataReader.GetOrdinal("UltimaVerificacion")) ? (DateTime?)null : sqlDataReader.GetDateTime(sqlDataReader.GetOrdinal("UltimaVerificacion")),
                            // ProximaVerificacion = sqlDataReader.IsDBNull(sqlDataReader.GetOrdinal("ProximaVerificacion")) ? (DateTime?)null : sqlDataReader.GetDateTime(sqlDataReader.GetOrdinal("ProximaVerificacion")),
                            Magnitud = new MagnitudE()
                            {
                                Id = sqlDataReader.GetInt64(sqlDataReader.GetOrdinal("IdMagnitud")),
                                Nombre = sqlDataReader.GetString(sqlDataReader.GetOrdinal("NombreMagnitud")),
                            },
                            Dispositivo = new DispositivoE()
                            {
                                Id = sqlDataReader.GetInt64(sqlDataReader.GetOrdinal("IdNodo")),
                                Nombre = sqlDataReader.GetString(sqlDataReader.GetOrdinal("NombreNodo")),
                                EUI = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Eui")),
                                Tipo_com = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Tipo_com")),
                                IMEI = sqlDataReader.GetString(sqlDataReader.GetOrdinal("IMEI")),
                                Clase = String.IsNullOrEmpty(sqlDataReader["Clase"].ToString()) ? " " : (String)sqlDataReader["Clase"],
                                
                            },
                            Unidad = new UnidadE()
                            {
                                Id = sqlDataReader.GetInt64(sqlDataReader.GetOrdinal("IdUnidad")),
                                Nombre = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Unidad"))
                            },
                            Imagen = String.IsNullOrEmpty(sqlDataReader["Imagen"].ToString()) ? "" : (String)sqlDataReader["Imagen"],


                        });
                    }
                }
            }
            sqlDataReader.Close();
            sqlDataReader = null;

            acceso.Desconectar();

            return result;
        }

        public List<AparatoE> GetAllAparatosMeca(Object[] parametros)
        {
            List<AparatoE> result = new List<AparatoE>();
            Mensaje mensaje;

            AccesoDatos acceso = new AccesoDatos();
            SqlDataReader sqlDataReader = acceso.GetDataReader(out mensaje, parametros, "prAparato");

            if (mensaje.Titulo == null)

            {
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        result.Add(new AparatoE()
                        {
                            Id = sqlDataReader.GetInt64(sqlDataReader.GetOrdinal("Id")),
                            Nombre = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Nombre")),
                            Codigo = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Codigo")),
                            Orden = sqlDataReader.GetInt64(sqlDataReader.GetOrdinal("Orden")),
                            Magnitud = new MagnitudE()
                            {
                              Id = sqlDataReader.GetInt64(sqlDataReader.GetOrdinal("IdMagnitud")),
                              Nombre = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Magnitud")),
                            }
                            
                            

                        });
                    }
                }
            }
            sqlDataReader.Close();
            sqlDataReader = null;

            acceso.Desconectar();

            return result;
        }

       //Metodos para el grafico chart, hacer filtros para agregar parametros
        public List<AparatoE> GetAllMagSensores(Object[] parametros)
        {
            List<AparatoE> result = new List<AparatoE>();
            Mensaje mensaje;

            AccesoDatos acceso = new AccesoDatos();
            SqlDataReader sqlDataReader = acceso.GetDataReader(out mensaje, parametros, "prAparato");

            if (mensaje.Titulo == null)

            {
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        result.Add(new AparatoE()
                        {
                            Magnitud = new MagnitudE()
                            {
                                Id = sqlDataReader.GetInt64(sqlDataReader.GetOrdinal("IdMagnitud")),
                                Nombre = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Magnitud")),
                            }
                        });
                    }
                }
            }
            sqlDataReader.Close();
            sqlDataReader = null;

            acceso.Desconectar();

            return result;
        }
        public List<UnidadE> GetAllUnidadXSen(Object[] parametros)
        {
            List<UnidadE> result = new List<UnidadE>();
            Mensaje mensaje;

            AccesoDatos acceso = new AccesoDatos();
            SqlDataReader sqlDataReader = acceso.GetDataReader(out mensaje, parametros, "prAparato");

            if (mensaje.Titulo == null)

            {
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        result.Add(new UnidadE()
                        {
                            Id = sqlDataReader.GetInt64(sqlDataReader.GetOrdinal("Id")),
                            Nombre = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Nombre")),
                        });
                    }
                }
            }
            sqlDataReader.Close();
            sqlDataReader = null;

            acceso.Desconectar();

            return result;
        }
        public List<AparatoE> GetAllSensordXUnidad(Object[] parametros)
        {
            List<AparatoE> result = new List<AparatoE>();
            Mensaje mensaje;

            AccesoDatos acceso = new AccesoDatos();
            SqlDataReader sqlDataReader = acceso.GetDataReader(out mensaje, parametros, "prAparato");

            if (mensaje.Titulo == null)

            {
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        result.Add(new AparatoE()
                        {
                            Id = sqlDataReader.GetInt64(sqlDataReader.GetOrdinal("Id")),
                            Nombre = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Nombre")),
                            Codigo = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Codigo")),
                            Orden = sqlDataReader.GetInt64(sqlDataReader.GetOrdinal("Orden")),
                            Magnitud = new MagnitudE()
                            {
                                Id = sqlDataReader.GetInt64(sqlDataReader.GetOrdinal("IdMagnitud")),
                                Nombre = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Magnitud")),
                            }



                        });
                    }
                }
            }
            sqlDataReader.Close();
            sqlDataReader = null;

            acceso.Desconectar();

            return result;
        }

        //----
        public List<AparatoE> GetAllApaSensores(Object[] parametros)
        {
            List<AparatoE> result = new List<AparatoE>();
            Mensaje mensaje;

            AccesoDatos acceso = new AccesoDatos();
            SqlDataReader sqlDataReader = acceso.GetDataReader(out mensaje, parametros, "prAparato");

            if (mensaje.Titulo == null)
            {
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        result.Add(new AparatoE()
                        {
                            Id = sqlDataReader.GetInt64(sqlDataReader.GetOrdinal("Id")),
                            Nombre = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Nombre")),

                        });
                    }
                }
            }
            sqlDataReader.Close();
            sqlDataReader = null;

            acceso.Desconectar();

            return result;
        }
        public AparatoE SetAparato(Object[] parametros)
        {
            AparatoE result = new AparatoE();
            Mensaje mensaje;

            AccesoDatos acceso = new AccesoDatos();
            SqlDataReader sqlDataReader = acceso.GetDataReader(out mensaje, parametros, "prAparato");

            if (mensaje.Titulo == null)
            {
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        result = new AparatoE()
                        {
                            Mensaje = new Mensaje()
                            {
                                Titulo = sqlDataReader.GetString(sqlDataReader.GetOrdinal("MensajeError")),
                                Id = sqlDataReader.GetInt64(sqlDataReader.GetOrdinal("IdError"))
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

        public AparatoE SetUpdatePosicion(Object[] parametros)
        {
            AparatoE result = new AparatoE();
            Mensaje mensaje;

            AccesoDatos acceso = new AccesoDatos();
            SqlDataReader sqlDataReader = acceso.GetDataReader(out mensaje, parametros, "prAparato");

            if (mensaje.Titulo == null)
            {
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        result = new AparatoE()
                        {
                            Mensaje = new Mensaje()
                            {
                                Titulo = sqlDataReader.GetString(sqlDataReader.GetOrdinal("MensajeError")),
                                Id = sqlDataReader.GetInt64(sqlDataReader.GetOrdinal("IdError"))
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


        public List<AparatoE> GetAparatos(Object[] parametros)
        {
            List<AparatoE> result = new List<AparatoE>();
            Mensaje mensaje;

            AccesoDatos acceso = new AccesoDatos();
            SqlDataReader sqlDataReader = acceso.GetDataReader(out mensaje, parametros, "prAparato");

            if (mensaje.Titulo == null)
            {
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        result.Add(new AparatoE()
                        {
                            Id = sqlDataReader.GetInt64(sqlDataReader.GetOrdinal("Id")),
                            Nombre = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Nombre"))
                        });
                    }
                }
            }
            sqlDataReader.Close();
            sqlDataReader = null;
            acceso.Desconectar();
            return result;
        }

        public AparatoE GetAparato(Object[] parametros)
        {
            Mensaje mensaje;
            AparatoE result = new AparatoE();
            AccesoDatos acceso = new AccesoDatos();
            SqlDataReader sqlDataReader = acceso.GetDataReader(out mensaje, parametros, "prAparato");

            while (sqlDataReader.Read())
            {


                if (mensaje.Titulo == null)
                {
                    if (sqlDataReader.HasRows)
                    {
                        result = new AparatoE()
                        {
                            Id = (Int64)(sqlDataReader["Id"]),
                            Id_Nodo = (Int64)(sqlDataReader["Id_Nodo"]),

                           // Estacion = new EstacionE()
                           // {
                           //     Id = (Int64)(sqlDataReader["Id_Estacion"]),
                           //     Nombre = (String)sqlDataReader["Estacion"],
                           //     Id_TipoEstacion = (long)sqlDataReader["Id_TipoEstacion"]
                           // },
                            Id_Magnitud = (Int64)(sqlDataReader["Id_Magnitud"]),
                            Nombre = String.IsNullOrEmpty(sqlDataReader["Nombre"].ToString()) ? "" : (String)sqlDataReader["Nombre"],                 
                            Modelo = String.IsNullOrEmpty(sqlDataReader["Modelo"].ToString()) ? "" : (String)sqlDataReader["Modelo"],
                            Serial = String.IsNullOrEmpty(sqlDataReader["Serial"].ToString()) ? "" : (String)sqlDataReader["Serial"],
                            Fabricante = String.IsNullOrEmpty(sqlDataReader["Fabricante"].ToString()) ? "" : (String)sqlDataReader["Fabricante"],
                            //ProximaCalibracion = sqlDataReader.IsDBNull(sqlDataReader.GetOrdinal("ProximaCalibracion")) ? (DateTime?)null : sqlDataReader.GetDateTime(sqlDataReader.GetOrdinal("ProximaCalibracion")),
                            //UltimaCalibracion = sqlDataReader.IsDBNull(sqlDataReader.GetOrdinal("UltimaCalibracion")) ? (DateTime?)null : sqlDataReader.GetDateTime(sqlDataReader.GetOrdinal("UltimaCalibracion")),
                            //ProximaVerificacion = sqlDataReader.IsDBNull(sqlDataReader.GetOrdinal("ProximaVerificacion")) ? (DateTime?)null : sqlDataReader.GetDateTime(sqlDataReader.GetOrdinal("ProximaVerificacion")),
                            //FrecuenciaCalibracion = sqlDataReader.IsDBNull(sqlDataReader.GetOrdinal("FrecuenciaCalibracion")) ? 0 : sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("FrecuenciaCalibracion")),
                            //FrecuenciaVerificacion = sqlDataReader.IsDBNull(sqlDataReader.GetOrdinal("FrecuenciaVerificacion")) ? 0 : sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("FrecuenciaVerificacion")),
                            //Limite = (Decimal)(sqlDataReader["Limite"]),

                            Id_Unidad_Limite = (Int64)(sqlDataReader["Id_Unidad_Limite"]),
                            FechaIngreso = (DateTime)sqlDataReader["FechaIngreso"],
                            Codigo = String.IsNullOrEmpty(sqlDataReader["Codigo"].ToString()) ? "" : (String)sqlDataReader["Codigo"],
                            //Rango = String.IsNullOrEmpty(sqlDataReader["Rango"].ToString()) ? "" : (String)sqlDataReader["Rango"],
                            //Unidad = String.IsNullOrEmpty(sqlDataReader["Unidad"].ToString()) ? "" : (String)sqlDataReader["Unidad"],
                            //EscalaMin = String.IsNullOrEmpty(sqlDataReader["EscalaMin"].ToString()) ? "" : (String)sqlDataReader["EscalaMin"],
                            Descripcion = String.IsNullOrEmpty(sqlDataReader["Descripcion"].ToString()) ? "" : (String)sqlDataReader["Descripcion"],
                            Observacion = String.IsNullOrEmpty(sqlDataReader["Observacion"].ToString()) ? "" : (String)sqlDataReader["Observacion"],
                            Estado = (Boolean)sqlDataReader["Estado"],
                            Parametro = (Boolean)sqlDataReader["Parametro"],
                            Imagen = String.IsNullOrEmpty(sqlDataReader["Imagen"].ToString()) ? "" : (String)sqlDataReader["Imagen"],                      
                            Tipo = String.IsNullOrEmpty(sqlDataReader["Tipo"].ToString()) ? "" : (String)sqlDataReader["Tipo"],
                            Direccionamiento = String.IsNullOrEmpty(sqlDataReader["Direccionamiento"].ToString()) ? "" : (String)sqlDataReader["Direccionamiento"],
                            Tipo_aparato = String.IsNullOrEmpty(sqlDataReader["Tipo_aparato"].ToString()) ? "" : (String)sqlDataReader["Tipo_aparato"],
                
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

        public AparatoE DeleteAparato(Object[] parametros)
        {
            AparatoE result = new AparatoE();
            Mensaje mensaje;

            AccesoDatos acceso = new AccesoDatos();
            SqlDataReader sqlDataReader = acceso.GetDataReader(out mensaje, parametros, "prAparato");

            if (mensaje.Titulo == null)
            {
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        result = new AparatoE()
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
