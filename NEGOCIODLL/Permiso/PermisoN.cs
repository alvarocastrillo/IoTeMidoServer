using DATOSDLL.Permiso;

using ENTIDADESDLL.Permiso;
using System;
using System.Collections.Generic;
using System.Text;

namespace NEGOCIODLL.Permiso
{
    public class PermisoN
    {
        //public static List<PermisoE> GetPermisoLista(Object[] parametros)
        //{
        //    PermisoD Permiso = new PermisoD();

        //    return Permiso.GetPermisoLista(parametros);
        //}



        //public static PermisoE GetPermiso(Object[] parametros)
        //{
        //    PermisoD Permiso = new PermisoD();

        //    return Permiso.GetPermiso(parametros);

        //}

        public static PermisoE SetPermiso(Object[] parametros)
        {
            PermisoD Permiso = new PermisoD();

            return Permiso.SetPermiso(parametros);

        }

        public static List<PermisoE> GetPermisos(Object[] parametros)
        {
            PermisoD Permiso = new PermisoD();

            return Permiso.GetPermisos(parametros);
        }

        public static PermisoE DeletePermiso(Object[] parametros)
        {
            PermisoD Permiso = new PermisoD();

            return Permiso.DeletePermiso(parametros);

        }
    }
}
