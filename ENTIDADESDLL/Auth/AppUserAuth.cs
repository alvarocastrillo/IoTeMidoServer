using ENTIDADESDDL.Persona;
using System;
using System.Collections.Generic;
using System.Text;

namespace ENTIDADESDLL.Auth
{
    public class AppUserAuth
    {
        public AppUserAuth() : base()
        {
            UserName = "Not authorized";
            BearerToken = string.Empty;
        }

        public string UserName { get; set; }
        public string BearerToken { get; set; }
        public bool IsAuthenticated { get; set; }

        public List<Permisos> Claims { get; set; }
    }
}
