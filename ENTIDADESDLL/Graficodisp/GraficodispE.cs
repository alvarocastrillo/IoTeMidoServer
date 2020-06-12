using ENTIDADESDLL.Dashboard;
using ENTIDADESDLL.Dispositivo;
using MENSAJESDLL;
using System;
using System.Collections.Generic;
using System.Text;

namespace ENTIDADESDLL.Graficodisp
{
    public class GraficodispE
    {
        public Int64 Id { get; set; }
        public DashboardE Dashboard { get; set; }
        public DispositivoE Dispositivo { get; set; }
        public string Titulo { get; set; }
        public string Tipo { get; set; }
        public Mensaje Mensaje { get; set; }
    }
}
