using MENSAJESDLL;
using System;
using System.Collections.Generic;
using System.Text;

namespace ENTIDADESDLL.FormularioProceso
{
    public class FormularioProcesoE
    {
        public Int64 Id { get; set; }
        public ProcesoE Proceso { get; set; }
        public FormularioE Formulario { get; set; }
        public string Observacion { get; set; }
        public Mensaje Mensaje { get; set; }

    }

    public class FormularioE
    {
        public Int64 Id { get; set; }
        public Int64 MnuNombre { get; set; }
        public string Nombre { get; set; }
        public string Observacion { get; set; }
        public Boolean Estado { get; set; }
        public Mensaje Mensaje { get; set; }
    }

    public class ProcesoE
    {
        public Int64 Id { get; set; }
        public string Nombre { get; set; }
        public Boolean Estado { get; set; }
        public Mensaje Mensaje { get; set; }
    }
}
