using ENTIDADESDDL.Empresa;
using MENSAJESDLL;
using System;
using System.Collections.Generic;
using System.Text;

namespace ENTIDADESDDL.Persona
{
    public class PersonaE
    {

        public PersonaE() : base()
        {
            Usuario = "Not authorized";
            BearerToken = string.Empty;
        }
        public Int64 Id { get; set; }
        public String Nombre { get; set; }
        public String Apellido { get; set; }
        public String Id_Identificacion { get; set; }
        public String Identificacion { get; set; }
        public String Direccion { get; set; }
        public String Telefono { get; set; }
        public String Email { get; set; }
        public String Usuario { get; set; }
        public String Clave { get; set; }
        public Int64 Id_Cargo { get; set; }
        public String Cargo { get; set; }
        public Boolean Estado { get; set; }
        public Int64 Id_Empresa { get; set; }
        public Mensaje Mensaje { get; set; }
        public String Token { get; set; }
        public EmpresaE Empresa { get; set; }

        public List<Permisos> Permisos { get; set; }
        public List<EmpresaE> Empresas { get; set; }

        public bool IsAuthenticated { get; set; }
        public string BearerToken { get; set; }
    }

    public class Permisos
    {
        public Int64 Id { get; set; }
        public String Proceso { get; set; }
        public String Formulario { get; set; }
        public Boolean Seleccionado { get; set; }

    }
}
