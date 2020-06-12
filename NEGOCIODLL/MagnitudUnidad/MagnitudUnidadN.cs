using DATOSDLL.MagnitudUnidad;
using ENTIDADESDLL.Unidad;
using System;
using System.Collections.Generic;
using System.Text;

namespace NEGOCIODLL.MagnitudUnidad
{
    public class MagnitudUnidadN
    {

        /// <summary>
        /// Obtiene todas las unidades
        /// </summary>
        /// <param name="SQL"></param>
        /// <param name="parametros"></param>
        /// <returns></returns>
        public static List<UnidadE> GetUnidades(String SQL, Object[] parametros)
        {
            MagnitudUnidadD unidad = new MagnitudUnidadD();

            return unidad.GetUnidades(SQL, parametros);
        }

        /// <summary>
        /// Obtiene todas las Unidades con Id Magnitud
        /// </summary>
        /// <param name="SQL"></param>
        /// <param name="parametros"></param>
        /// <returns></returns>
        public static List<UnidadE> GetAllUnidadMagnitud(String SQL, Object[] parametros)
        {
            MagnitudUnidadD unidad = new MagnitudUnidadD();

            return unidad.GetAllUnidadMagnitud(SQL, parametros);
        }


    }
}
