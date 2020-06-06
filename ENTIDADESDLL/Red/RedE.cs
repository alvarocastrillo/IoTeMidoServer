using MENSAJESDLL;
using System;
using System.Collections.Generic;
using System.Text;

namespace ENTIDADESDLL.Red
{
    public class RedE
    {
        public Int64 Id { get; set; }
        public Int64 Id_empresa { get; set; }
        public string Nombre { get; set; }
        public string Tipo_com { get; set; }
        public Mensaje Mensaje { get; set; }
    }
}
