using ENTIDADESDDL.Lista;
using MENSAJESDLL;
using System;
using System.Collections.Generic;
using System.Text;

namespace ENTIDADESDDL.Empresa
{
    public class EmpresaE
    {
        public Int64 Id { get; set; }
        public String Id_Identificacion { get; set; }
        public String Id_Departamento { get; set; }
        public String Id_Ciudad { get; set; }
        public String Identificacion { get; set; }
        public ListaE Naturaleza { get; set; }
        public String RazonSocial { get; set; }
        public String Nombres { get; set; }
        public String Apellidos { get; set; }
        public String Direccion { get; set; }
        public String Telefono { get; set; }
        public String Contacto { get; set; }
        public String Cargo { get; set; }
        public String Observacion { get; set; }
        public String Estado { get; set; }
        public Mensaje Mensaje { get; set; }
        public Int64 Id_Usuario { get; set; }



    }
}
