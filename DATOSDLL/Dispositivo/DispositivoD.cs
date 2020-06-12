
using ENTIDADESDLL.Dispositivo;
using ENTIDADESDLL.Red;
using MENSAJESDLL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DATOSDLL.Dispositivo
{
    public class DispositivoD
    {
        public List<DispositivoE> getListaDispositivoxRed(Object[] parametros)
        {
            List<DispositivoE> result = new List<DispositivoE>();
            Mensaje mensaje;

            AccesoDatos acceso = new AccesoDatos();
            SqlDataReader sqlDataReader = acceso.GetDataReader(out mensaje, parametros, "prDispositivo");

            if (mensaje.Titulo == null)
            {
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        result.Add(new DispositivoE()
                        {
                            Id = sqlDataReader.GetInt64(sqlDataReader.GetOrdinal("Id")),
                            Parentid = sqlDataReader.GetInt64(sqlDataReader.GetOrdinal("Parentid")),
                            Tipo_disp = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Tipo_disp")),
                            Nombre = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Nombre")),
                            Latitud = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Latitud")),
                            Longitud = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Longitud")),
                            Tipo_com = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Tipo_com")),
                            EUI = sqlDataReader.GetString(sqlDataReader.GetOrdinal("EUI")),
                            IMEI = String.IsNullOrEmpty(sqlDataReader["IMEI"].ToString()) ? " " : (String)sqlDataReader["IMEI"],
                            Batch = (Boolean)sqlDataReader["Batch"]

                        });
                    }
                }
            }
            sqlDataReader.Close();
            sqlDataReader = null;

            acceso.Desconectar();

            return result;
        }

        public List<DispositivoE> VerificarEui(Object[] parametros)
        {
            List<DispositivoE> result = new List<DispositivoE>();
            Mensaje mensaje;

            AccesoDatos acceso = new AccesoDatos();
            SqlDataReader sqlDataReader = acceso.GetDataReader(out mensaje, parametros, "prDispositivo");

            if (mensaje.Titulo == null)
            {
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        result.Add(new DispositivoE()
                        {
                            Id = sqlDataReader.GetInt64(sqlDataReader.GetOrdinal("Id"))            
                        });
                    }
                }
            }
            sqlDataReader.Close();
            sqlDataReader = null;

            acceso.Desconectar();

            return result;
        }

        public List<DispositivoE> VerificarImei(Object[] parametros)
        {
            List<DispositivoE> result = new List<DispositivoE>();
            Mensaje mensaje;

            AccesoDatos acceso = new AccesoDatos();
            SqlDataReader sqlDataReader = acceso.GetDataReader(out mensaje, parametros, "prDispositivo");

            if (mensaje.Titulo == null)
            {
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        result.Add(new DispositivoE()
                        {
                            Id = sqlDataReader.GetInt64(sqlDataReader.GetOrdinal("Id"))
                        });
                    }
                }
            }
            sqlDataReader.Close();
            sqlDataReader = null;

            acceso.Desconectar();

            return result;
        }
        public DispositivoE SetDispositivo(Object[] parametros)
        {
            DispositivoE result = new DispositivoE();
            Mensaje mensaje;

            AccesoDatos acceso = new AccesoDatos();
            SqlDataReader sqlDataReader = acceso.GetDataReader(out mensaje, parametros, "prDispositivo");

            if (mensaje.Titulo == null)
            {
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        result = new DispositivoE()
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

        public DispositivoE GetDispositivo(Object[] parametros)
        {
            Mensaje mensaje;
      
            DispositivoE result = new DispositivoE();
            AccesoDatos acceso = new AccesoDatos();
            SqlDataReader sqlDataReader = acceso.GetDataReader(out mensaje, parametros, "prDispositivo");

            while (sqlDataReader.Read())
            {


                if (mensaje.Titulo == null)
                {
                    if (sqlDataReader.HasRows)
                    {
                        result = new DispositivoE()
                        {
                            Id = sqlDataReader.GetInt64(sqlDataReader.GetOrdinal("Id")),
                            Direccionamiento = String.IsNullOrEmpty(sqlDataReader["Direccionamiento"].ToString()) ? " " : (String)sqlDataReader["Direccionamiento"],
                            EUI = String.IsNullOrEmpty(sqlDataReader["EUI"].ToString()) ? " " : (String)sqlDataReader["EUI"],
                            AppEUI = String.IsNullOrEmpty(sqlDataReader["AppEUI"].ToString()) ? " " : (String)sqlDataReader["AppEUI"],
                            AppKEY = String.IsNullOrEmpty(sqlDataReader["AppKEY"].ToString()) ? " " : (String)sqlDataReader["AppKEY"],
                            Latitud = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Latitud")),
                            Longitud = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Longitud")),
                            Modelo = String.IsNullOrEmpty(sqlDataReader["Modelo"].ToString()) ? " " : (String)sqlDataReader["Modelo"],
                            Nombre = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Nombre")),
                            Version_SO = String.IsNullOrEmpty(sqlDataReader["Version_SO"].ToString()) ? " " : (String)sqlDataReader["Version_SO"],
                            Tipo_disp = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Tipo_disp")),
                            Serial = String.IsNullOrEmpty(sqlDataReader["Serial"].ToString()) ? " " : (String)sqlDataReader["Serial"],
                            Marca = String.IsNullOrEmpty(sqlDataReader["Marca"].ToString()) ? " " : (String)sqlDataReader["Marca"],
                            Referencia = String.IsNullOrEmpty(sqlDataReader["Referencia"].ToString()) ? " " : (String)sqlDataReader["Referencia"],
                            Tag = String.IsNullOrEmpty(sqlDataReader["Tag"].ToString()) ? " " : (String)sqlDataReader["Tag"],
                            Tipo_com = String.IsNullOrEmpty(sqlDataReader["Tipo_com"].ToString()) ? " " : (String)sqlDataReader["Tipo_com"],
                            APN = String.IsNullOrEmpty(sqlDataReader["APN"].ToString()) ? " " : (String)sqlDataReader["APN"],
                            Puerto = String.IsNullOrEmpty(sqlDataReader["Puerto"].ToString()) ? " " : (String)sqlDataReader["Puerto"],
                            IMEI = String.IsNullOrEmpty(sqlDataReader["IMEI"].ToString()) ? " " : (String)sqlDataReader["IMEI"],
                            Clase = String.IsNullOrEmpty(sqlDataReader["Clase"].ToString()) ? " " : (String)sqlDataReader["Clase"],
                            Unidad_tiempo = String.IsNullOrEmpty(sqlDataReader["Unidad_tiempo"].ToString()) ? " " : (String)sqlDataReader["Unidad_tiempo"],
                            Valor_UT = String.IsNullOrEmpty(sqlDataReader["Valor_UT"].ToString()) ? " " : (String)sqlDataReader["Valor_UT"],
                            EUIGAT = String.IsNullOrEmpty(sqlDataReader["EUIGAT"].ToString()) ? " " : (String)sqlDataReader["EUIGAT"],
                            Id_red = sqlDataReader.GetInt64(sqlDataReader.GetOrdinal("Id_red")),
                            Parentid = sqlDataReader.GetInt64(sqlDataReader.GetOrdinal("Parentid")),
                            Batch = (Boolean)sqlDataReader["Batch"],
                            red = new RedE()
                            {
                                Nombre = String.IsNullOrEmpty(sqlDataReader["nomred"].ToString()) ? " " : (String)sqlDataReader["nomred"],
                            },

                            Mensaje = new Mensaje()
                            {
                                    Titulo = sqlDataReader.GetString(sqlDataReader.GetOrdinal("MENSAJEERROR")),
                                    Id = sqlDataReader.GetInt64(sqlDataReader.GetOrdinal("IDERROR"))
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

        public DispositivoE GetEuigat(Object[] parametros)
        {
            Mensaje mensaje;
            DispositivoE result = new DispositivoE();
            AccesoDatos acceso = new AccesoDatos();
            SqlDataReader sqlDataReader = acceso.GetDataReader(out mensaje, parametros, "prDispositivo");

            while (sqlDataReader.Read())
            {


                if (mensaje.Titulo == null)
                {
                    if (sqlDataReader.HasRows)
                    {
                        result = new DispositivoE()
                        {
                           
                            EUIGAT = String.IsNullOrEmpty(sqlDataReader["EUIGAT"].ToString()) ? " " : (String)sqlDataReader["EUIGAT"],
                            Mensaje = new Mensaje()
                            {
                                Titulo = sqlDataReader.GetString(sqlDataReader.GetOrdinal("MENSAJEERROR")),
                                Id = sqlDataReader.GetInt64(sqlDataReader.GetOrdinal("IDERROR"))
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

        public DispositivoE GetDisp(Object[] parametros)
        {
            Mensaje mensaje;
            DispositivoE result = new DispositivoE();
            AccesoDatos acceso = new AccesoDatos();
            SqlDataReader sqlDataReader = acceso.GetDataReader(out mensaje, parametros, "prDispositivo");

            while (sqlDataReader.Read())
            {


                if (mensaje.Titulo == null)
                {
                    if (sqlDataReader.HasRows)
                    {
                        result = new DispositivoE()
                        {

                            Nombre = String.IsNullOrEmpty(sqlDataReader["Nombre"].ToString()) ? " " : (String)sqlDataReader["Nombre"],              
                            Tipo_com = String.IsNullOrEmpty(sqlDataReader["Tipo_com"].ToString()) ? " " : (String)sqlDataReader["Tipo_com"],
                            EUI = String.IsNullOrEmpty(sqlDataReader["EUI"].ToString()) ? " " : (String)sqlDataReader["EUI"],
                            IMEI = String.IsNullOrEmpty(sqlDataReader["IMEI"].ToString()) ? " " : (String)sqlDataReader["IMEI"],
                            Batch = (Boolean)sqlDataReader["Batch"],
                            red = new RedE()
                            {
                                Nombre = String.IsNullOrEmpty(sqlDataReader["nomred"].ToString()) ? " " : (String)sqlDataReader["nomred"],
                            },
                            Mensaje = new Mensaje()
                            {
                                Titulo = sqlDataReader.GetString(sqlDataReader.GetOrdinal("MENSAJEERROR")),
                                Id = sqlDataReader.GetInt64(sqlDataReader.GetOrdinal("IDERROR"))
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


        public DispositivoE DeleteDispositivo(Object[] parametros)
        {
            DispositivoE result = new DispositivoE();
            Mensaje mensaje;

            AccesoDatos acceso = new AccesoDatos();
            SqlDataReader sqlDataReader = acceso.GetDataReader(out mensaje, parametros, "prDispositivo");

            if (mensaje.Titulo == null)
            {
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        result = new DispositivoE()
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


        public DispositivoE CountDispositivoChildren(Object[] parametros)
        {
            Mensaje mensaje;
            DispositivoE result = new DispositivoE();
            AccesoDatos acceso = new AccesoDatos();
            SqlDataReader sqlDataReader = acceso.GetDataReader(out mensaje, parametros, "prDispositivo");

            while (sqlDataReader.Read())
            {


                if (mensaje.Titulo == null)
                {
                    if (sqlDataReader.HasRows)
                    {
                        result = new DispositivoE()
                        {
                            CountChildren = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("contador")),
                            
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


        public DispositivoE UpdateFechaAct(Object[] parametros)
        {
            DispositivoE result = new DispositivoE();
            Mensaje mensaje;

            AccesoDatos acceso = new AccesoDatos();
            SqlDataReader sqlDataReader = acceso.GetDataReader(out mensaje, parametros, "prDispositivo");

            if (mensaje.Titulo == null)
            {
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        result = new DispositivoE()
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

    }
}
