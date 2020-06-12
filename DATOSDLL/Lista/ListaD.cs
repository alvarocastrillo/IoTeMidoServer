using ENTIDADESDDL.Lista;
using MENSAJESDLL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DATOSDLL.Lista
{
    public class ListaD
    {
        public List<ListaE> GetListas(String SQL, Object[] parametros)
        {
            int ntablas;
            Mensaje mensaje;
            List<ListaE> result = new List<ListaE>();
            AccesoDatos acceso = new AccesoDatos();
            ListaE list;
            SqlDataReader sqldatareader = acceso.GetDataReader(out mensaje,parametros,"prListas");

            if (mensaje.Titulo != null)
            {
                result.Add(new ListaE()
                {
                    Mensaje = mensaje
                });
            }

            else
            {
                String[] tablas = ((SqlParameter)parametros[0]).Value.ToString().Split(',');


                ntablas = 0;
                // DataTable sqlda = acceso.Get(parametros, SQL);
                while (sqldatareader.HasRows)
                {
                    list = new ListaE() { Id = ntablas, Nombre = tablas[ntablas] };
                    list.Listas = new List<ListaE>();
                    while (sqldatareader.Read())
                    {

                        if (sqldatareader.GetDataTypeName(0) == "bigint")

                            list.Listas.Add(new ListaE() { Id = sqldatareader.GetInt64(0), Nombre = sqldatareader.GetString(1) });
                        else

                            list.Listas.Add(new ListaE() { IdString = sqldatareader.GetString(0), Nombre = sqldatareader.GetString(1) });
                    }

                    result.Add(list);
                    ntablas = ntablas + 1;
                    sqldatareader.NextResult();
                }

                if (sqldatareader.IsClosed == false)
                    sqldatareader.Close();

                sqldatareader = null;

                acceso.Desconectar();
            }

            return result;

        }

       
    }
}
