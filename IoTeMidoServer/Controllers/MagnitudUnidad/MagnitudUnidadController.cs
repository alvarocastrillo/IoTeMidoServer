using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using NEGOCIODLL.MagnitudUnidad;
using ENTIDADESDLL.Unidad;

namespace WebCoreGemesisII.Controllers.MagnitudUnidad
{
    [Route("api/[controller]")]
    [ApiController]
    public class MagnitudUnidadController : Controller
    {


        [HttpPost("GetUnidad")]
        public List<UnidadE> GetUnidad([FromBody] UnidadE unidad)
        {

            Object[] parametros = new Object[]
            {
                new SqlParameter("@Accion","LISTUNIDAD"),
                new SqlParameter("@IdMagnitud",unidad.Id_Magnitud)
            };


            return MagnitudUnidadN.GetUnidades("prMagnitudUnidad", parametros);
        }

        [HttpPost("GetAllUnidad")]
        public List<UnidadE> GetAllUnidad()
        {

            Object[] parametros = new Object[]
            {
                new SqlParameter("@Accion","ALLUNIDAD")
            };


            return MagnitudUnidadN.GetUnidades("prMagnitudUnidad", parametros);
        }

        /// <summary>
        /// Obtiene todas las Unidades con IdMagnitud
        /// </summary>
        /// <param name="idMagnitud"></param>
        /// <returns></returns>

        [HttpPost("GetAllUnidadMagnitud")]
        public List<UnidadE> GetAllUnidadMagnitud()
        {

            Object[] parametros = new Object[]
            {
                new SqlParameter("@Accion","ALLUNIDAD")
            };


            return MagnitudUnidadN.GetAllUnidadMagnitud("prMagnitudUnidad", parametros);
        }
    }
}