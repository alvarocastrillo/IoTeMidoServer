using ENTIDADESDLL.Red;
using MENSAJESDLL;
using System;
using System.Collections.Generic;
using System.Text;

namespace ENTIDADESDLL.Dashboard
{
    public class DashboardE
    {
        public Int64 Id { get; set; }
        public RedE Red { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public Boolean Selected { get; set; }
        public Mensaje Mensaje { get; set; }
    }
}
