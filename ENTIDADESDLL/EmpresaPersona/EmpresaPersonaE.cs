using MENSAJESDLL;
using System;
using System.Collections.Generic;
using System.Text;

namespace ENTIDADESDLL.EmpresaPersona
{
    public class EmpresaPersonaE
    {
        public Int64 Id_Empresa { get; set; }
        public Int64 Id_Persona { get; set; }

        public String RazonSocial { get; set; }

        public Mensaje Mensaje { get; set; }
    }
}
