using System;
using System.Collections.Generic;
using System.Text;

namespace ENTIDADESDLL.Unidad
{
    public class UnidadE
    {

        private Int64 id;
        private String nombre;
        private Int64 idMagnitud;

        public Int64 Id_Magnitud
        {
            get { return idMagnitud; }
            set { idMagnitud = value; }
        }


        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public Int64 Id
        {
            get { return id; }
            set { id = value; }
        }


    }
}
