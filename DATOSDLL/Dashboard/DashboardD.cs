
using ENTIDADESDLL.Dashboard;
using ENTIDADESDLL.Red;
using MENSAJESDLL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DATOSDLL.Dashboard
{
    public class DashboardD
    {
        public List<DashboardE> GetDashboardLista(Object[] parametros)
        {
            List<DashboardE> result = new List<DashboardE>();
            Mensaje mensaje;
            AccesoDatos acceso = new AccesoDatos();
            SqlDataReader sqlDataReader = acceso.GetDataReader(out mensaje, parametros, "prDashboard");

            if (mensaje.Titulo == null)
            {
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        if (sqlDataReader.GetString(sqlDataReader.GetOrdinal("MensajeError")) == "")
                        {
                            result.Add(new DashboardE()
                            {
                                Id = sqlDataReader.GetInt64(sqlDataReader.GetOrdinal("Id")),
                                Nombre = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Nombre")),
                                Descripcion = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Descripcion")),
                                Selected = (Boolean)sqlDataReader["Selected"],
                                Red = new RedE()
                                {
                                    Id = sqlDataReader.GetInt64(sqlDataReader.GetOrdinal("idred")),
                                    Nombre = sqlDataReader.GetString(sqlDataReader.GetOrdinal("nomred")),
                                }
                            });
                        }
                        else
                        {
                            result.Add(new DashboardE()
                            {
                                Mensaje = new Mensaje(sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("IdError")), "Listado Dashboards", sqlDataReader.GetString(sqlDataReader.GetOrdinal("MensajeError")), "Listando Dashboardes", TipoMensaje.Error),
                            }
                            );
                        }
                    }
                }
            }
            else
            {
                result.Add(new DashboardE()
                {
                    Mensaje = new Mensaje(sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("IdError")), "Listado de Dashboards", sqlDataReader.GetString(sqlDataReader.GetOrdinal("MensajeError")), "Listado de Dashboardes", TipoMensaje.Error),
                });
            }
            sqlDataReader.Close();
            sqlDataReader = null;

            acceso.Desconectar();

            return result;
        }


        public DashboardE SetDashboard(Object[] parametros)
        {
            DashboardE result = new DashboardE();
            Mensaje mensaje;

            AccesoDatos acceso = new AccesoDatos();
            SqlDataReader sqlDataReader = acceso.GetDataReader(out mensaje, parametros, "prDashboard");

            if (mensaje.Titulo == null)
            {
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        result = new DashboardE()
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

        public DashboardE GetIdSelected(Object[] parametros)
        {
            Mensaje mensaje;
            DashboardE result = new DashboardE();

            AccesoDatos acceso = new AccesoDatos();
            SqlDataReader sqlDataReader = acceso.GetDataReader(out mensaje, parametros, "prDashboard");

            while (sqlDataReader.Read())
            {


                if (mensaje.Titulo == null)
                {
                    if (sqlDataReader.HasRows)
                    {
                        result = new DashboardE()
                        {
                            Id = sqlDataReader.GetInt64(sqlDataReader.GetOrdinal("iddas")),
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

        public DashboardE GetDashboard(Object[] parametros)
        {
            Mensaje mensaje;
            DashboardE result = new DashboardE();
      
            AccesoDatos acceso = new AccesoDatos();
            SqlDataReader sqlDataReader = acceso.GetDataReader(out mensaje, parametros, "prDashboard");

            while (sqlDataReader.Read())
            {


                if (mensaje.Titulo == null)
                {
                    if (sqlDataReader.HasRows)
                    {
                        result = new DashboardE()
                        {
                            Id = sqlDataReader.GetInt64(sqlDataReader.GetOrdinal("Id")),
                            Nombre = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Nombre")),
                            Descripcion = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Descripcion")),
                            Selected = (Boolean)sqlDataReader["Selected"],
                            Red = new RedE() {
                                Id = sqlDataReader.GetInt64(sqlDataReader.GetOrdinal("Id_red")),
                                Tipo_com = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Tipo_com"))
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


        public DashboardE DeleteDashboard(Object[] parametros)
        {
            DashboardE result = new DashboardE();
            Mensaje mensaje;

            AccesoDatos acceso = new AccesoDatos();
            SqlDataReader sqlDataReader = acceso.GetDataReader(out mensaje, parametros, "prDashboard");

            if (mensaje.Titulo == null)
            {
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        result = new DashboardE()
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
