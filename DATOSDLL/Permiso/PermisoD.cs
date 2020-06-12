
using ENTIDADESDDL.Persona;
using ENTIDADESDLL.FormularioProceso;
using ENTIDADESDLL.Permiso;
using MENSAJESDLL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DATOSDLL.Permiso
{
    public class PermisoD
    {
        public List<PermisoE> GetPermisos(Object[] parametros)
        {
            List<PermisoE> result = new List<PermisoE>();
            Mensaje mensaje;

            AccesoDatos acceso = new AccesoDatos();
            SqlDataReader sqlDataReader = acceso.GetDataReader(out mensaje, parametros, "prPermiso");

            if (mensaje.Titulo == null)
            {
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                            result.Add(new PermisoE()
                            {
                                //FechaVencimiento = (DateTime)sqlDataReader["FechaVencimiento"],
                                FormularioProceso = new FormularioProcesoE()
                                {
                                    Id = sqlDataReader.GetInt64(sqlDataReader.GetOrdinal("Id")),
                                    Observacion = sqlDataReader.GetString(sqlDataReader.GetOrdinal("FormularioProce")),
                                },
                                //Formulario = new FormularioE()
                                //{
                                //    Nombre = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Formulario"))
                                //},
                                Seleccionado = (Boolean)sqlDataReader["Seleccionado"],
                                Proceso = new ProcesoE()
                                {
                                    Nombre = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Proceso"))
                                },
                                //Persona = new PersonaE()
                                //{
                                //    Id = sqlDataReader.GetInt64(sqlDataReader.GetOrdinal("Id_Persona")),
                                //}
                                


                            });
               
      
                    }
                }
            }
            else
            {
                result.Add(new PermisoE()
                {
                    Mensaje = new Mensaje(sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("IDERROR")), "Listado de Permisoes", sqlDataReader.GetString(sqlDataReader.GetOrdinal("MENSAJEERROR")), "Listado de Permisoes", TipoMensaje.Error),
                });
            }
            sqlDataReader.Close();
            sqlDataReader = null;

            acceso.Desconectar();

            return result;
        }


        public PermisoE SetPermiso(Object[] parametros)
        {
            PermisoE result = new PermisoE();
            Mensaje mensaje;

            AccesoDatos acceso = new AccesoDatos();
            SqlDataReader sqlDataReader = acceso.GetDataReader(out mensaje, parametros, "prPermiso");

            if (mensaje.Titulo == null)
            {
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        result = new PermisoE()
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

        //public PermisoE GetPermiso(Object[] parametros)
        //{
        //    Mensaje mensaje;
        //    PermisoE result = new PermisoE();
        //    AccesoDatos acceso = new AccesoDatos();
        //    SqlDataReader sqlDataReader = acceso.GetDataReader(out mensaje, parametros, "prPermiso");

        //    while (sqlDataReader.Read())
        //    {


        //        if (mensaje.Titulo == null)
        //        {
        //            if (sqlDataReader.HasRows)
        //            {
        //                result = new PermisoE()
        //                {
        //                    Id = sqlDataReader.GetInt64(sqlDataReader.GetOrdinal("Id")),
        //                    Nombre = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Nombre")),
        //                    Tipo_com = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Tipo_com"))

        //                };
        //            }
        //        }
        //    }

        //    if (sqlDataReader.IsClosed == false)
        //        sqlDataReader.Close();

        //    sqlDataReader = null;
        //    acceso.Desconectar();
        //    return result;
        //}



        public PermisoE DeletePermiso(Object[] parametros)
        {
            PermisoE result = new PermisoE();
            Mensaje mensaje;

            AccesoDatos acceso = new AccesoDatos();
            SqlDataReader sqlDataReader = acceso.GetDataReader(out mensaje, parametros, "prPermiso");

            if (mensaje.Titulo == null)
            {
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        result = new PermisoE()
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
