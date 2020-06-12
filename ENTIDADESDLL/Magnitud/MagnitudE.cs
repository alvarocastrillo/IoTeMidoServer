using MENSAJESDLL;
using System;
using System.Collections.Generic;
using System.Text;

namespace ENTIDADESDLL.Magnitud
{
    public class MagnitudE
    {
        public Int64 Id { get; set; }

        public String Nombre { get; set; }
        public String Abreviatura { get; set; }
        public Boolean Estado { get; set; }
        public Mensaje Mensaje { get; set; }
    }
}
