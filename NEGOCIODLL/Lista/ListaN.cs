using DATOSDLL.Lista;
using ENTIDADESDDL.Lista;
using System;
using System.Collections.Generic;
using System.Text;

namespace NEGOCIODLL.Lista
{
    public class ListaN
    {
        public static List<ListaE> GetListas(String SQL, Object[] parametros)
        {
            ListaD lista = new ListaD();

            return lista.GetListas(SQL, parametros);
        }

    }
}
