using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ENTIDADESDLL.Red;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NEGOCIODLL.Red;

namespace IoTeMidoServer.Controllers.Red
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RedController : ControllerBase
    {
  
        [HttpPost("InsertRed")] //Insertar Red
        [Authorize(Policy = "Redes-Insertar")]
        public RedE InsertRed([FromBody]  RedE Red)
        {
            RedE result = new RedE();


            result = RedN.SetRed(new Object[] {
                new SqlParameter("@Accion", "INGRESAR"),
                new SqlParameter("@Id_Empresa", Red.Id_empresa),
                new SqlParameter("@Nombre", Red.Nombre),
                new SqlParameter("@Tipo_com", Red.Tipo_com),
            });
            return result;
        }
    }
}