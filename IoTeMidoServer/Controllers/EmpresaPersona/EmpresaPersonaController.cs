using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using NEGOCIODLL.EmpresaPersona;
using System.Data.SqlClient;
using ENTIDADESDLL.EmpresaPersona;

namespace WebCoreGemesisII.Controllers.EmpresaPersona
{
    [Produces("application/json")]
    
    public class EmpresaPersonaController : Controller
    {
        /*
        [HttpPost]
        [Authorize]
        [Route("api/EmpresaPersona/GetEmpresaPersona")]
        public List<EmpresaPersonaE> GetEmpresaPersona(EmpresaPersonaE persona)
        {
            List<EmpresaPersonaE> empresaPersona = new List<EmpresaPersonaE>();

            empresaPersona = EmpresaPersonaN.GetEmpresaPersona(new Object[]
            {
                new SqlParameter("@Accion","SELECT"),
                new SqlParameter("@Id_Persona",persona.Id_Persona)
            });

            return empresaPersona;
        }*/
    }
}