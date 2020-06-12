using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ENTIDADESDDL.Lista;
using System.Data.SqlClient;
using NEGOCIODLL.Lista;

namespace WebCoreGemesisII.Controllers.Lista
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListaController : Controller
    {

        [HttpPost("GetListas")]
        public List<ListaE> GetListas([FromBody] String[] datos)
        {

            String valores = String.Join(",", datos);

            String SQL;
            SQL = "prListas";

            Object[] parametros = new Object[] {

                new SqlParameter("@Accion",valores)

            };

            return ListaN.GetListas(SQL, parametros);
        }


    }
}