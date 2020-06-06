using MENSAJESDLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DATOSDLL
{
    public class AccesoDatos
    {
        SqlConnection SqlConection = new SqlConnection();

        /// <summary>
        /// Se Conecta a la base de datos devolviendo un resultado booleano de 
        /// éxito en la conexión
        /// </summary>
        /// <returns>true:Conexión exitosa, false:Falla la conexión</returns>
        private bool Conectar(Mensaje alerta)
        {
            bool result = true;

            alerta = new Mensaje();

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            builder.DataSource = "GMPS1\\SQLEXPRESS";
            builder.UserID = "sa";
            builder.Password = "123456";
            //builder.DataSource = "cdtdegas.database.windows.net";
            //builder.UserID = "usercdt";
            //builder.Password = "$CdtDeGas#";
            builder.InitialCatalog = "IOTEMIDO3";
            builder.PersistSecurityInfo = true;

            try
            {
                SqlConection.ConnectionString = builder.ConnectionString;

                if (SqlConection.State == ConnectionState.Closed)
                    SqlConection.Open();
            }
            catch (Exception ex)
            {

                alerta.Id = ex.HResult;
                alerta.Cuerpo = ex.Message;
                alerta.Botones = new List<Botones>();
                alerta.Botones.Add(new Botones { Label = "Aceptar" });
                result = false;
            }
            finally
            {

            }

            return result;
        }

        /// <summary>
        /// Desconexión a la base de datos
        /// </summary>
        /// <returns>true:Desconexión exitosa, false:Desconexión Fallida</returns>
        public bool Desconectar()
        {
            bool result = true;

            try
            {
                if (SqlConection.State == ConnectionState.Open)
                {
                    SqlConection.Close();
                    SqlConection.Dispose();

                }
            }
            catch (Exception error)
            {
                result = false;
                throw new Exception("Error : " + error.Message);
            }

            return result;
        }



        /// <summary>
        /// Obtiene los datos con la clase dataReader para ser mostrados como una lista genérica
        /// </summary>
        /// <param name="Parametros"></param>
        /// <param name="procedimiento"></param>
        /// <returns></returns>
        public SqlDataReader GetDataReader(out Mensaje alerta, Object[] Parametros, String procedimiento)
        {

            SqlDataReader result = null;
            SqlCommand Comando = null;
            Mensaje alertaConeccion = new Mensaje();
            alerta = new Mensaje();

            try
            {
                if (Conectar(alertaConeccion))
                {

                    Comando = new SqlCommand(procedimiento, SqlConection);
                    Comando.CommandType = CommandType.StoredProcedure;

                    foreach (Object Parametro in Parametros)
                    {
                        Comando.Parameters.Add(Parametro);
                    }

                    result = Comando.ExecuteReader();
                    // si entra aqui, es porque se conecto bien y devuelve un objeto

                }
                else
                {
                    // si entra aqui, fue porque no se pudo conectar a la base de datos y retorna null
                    alerta = alertaConeccion;
                    return null;
                }
            }
            catch (Exception ex)
            {
                //if (SqlConection.State == ConnectionState.Closed)
                //    Conectar();

                alertaConeccion.Id = ex.HResult;
                alertaConeccion.Titulo = "ERROR";
                alertaConeccion.Cuerpo = ex.Message;
                alertaConeccion.Botones = new List<Botones>();
                alertaConeccion.Botones.Add(new Botones { Label = "Aceptar" });

                alerta = alertaConeccion;
                return null;
                // GetDataReader(Parametros, procedimiento);
                //String SQL;
                //SQL = "SELECT '" + error.Message.Replace("'", "") + "' AS MENSAJEERROR, " + error.HResult + " As IDERROR ";
                //Comando = new SqlCommand(SQL, SqlConection);
                //result = Comando.ExecuteReader();
            }

            finally
            {
                if (Comando != null)
                    Comando.Dispose();
                Comando = null;
            }


            return result;
        }
    }
}
