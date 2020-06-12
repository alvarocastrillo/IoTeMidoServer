using ENTIDADESDDL.Persona;
using ENTIDADESDLL.FormularioProceso;
using MENSAJESDLL;
using System;
using System.Collections.Generic;
using System.Text;

namespace ENTIDADESDLL.Permiso
{
    public class PermisoE
    {
        public FormularioProcesoE FormularioProceso { get; set; }
        public PersonaE Persona { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public FormularioE Formulario { get; set; }
        public ProcesoE Proceso { get; set; }
        public Boolean Seleccionado { get; set; }
        public Mensaje Mensaje { get; set; }
    }

    public class PermisosE
    {
        public String name { get; set; }
        public String value { get; set; }
    }
    public class ViewerStatsFormat
    {
        public List<PermisosE> id { get; set; }

    }
}
