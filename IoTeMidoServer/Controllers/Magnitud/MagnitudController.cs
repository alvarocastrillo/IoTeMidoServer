using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ENTIDADESDLL.Magnitud;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NEGOCIODLL.Magnitud;

namespace WebCoreGemesisII.Controllers.Magnitud
{
    [Route("api/[controller]")]
    [ApiController]
    public class MagnitudController : Controller
    {

        [HttpPost("GetMagnitudes")]
        public List<MagnitudE> GetMagnitudes()
        {
            List<MagnitudE> result = new List<MagnitudE>();


            result = MagnitudN.GetMagnitudes(new Object[] {
                new SqlParameter("@Accion","LIST")
            });

            return result;
        }


        [HttpPost("GetMagnitud")]
        public MagnitudE GetMagnitud([FromBody]  MagnitudE Magnitud)
        {
            MagnitudE result = null;
            SqlParameter _accion = new SqlParameter("@Accion", "GETID");
            SqlParameter _id = new SqlParameter("@Id", Magnitud.Id);

            Object[] Objeto = new Object[]
            {
                _accion,
                _id
            };

            result = MagnitudN.GetMagnitud(Objeto);
            return result;
        }


        [HttpPost("InsertMagnitud")]
        public MagnitudE InsertMagnitud([FromBody]  MagnitudE magnitud)
        {
            MagnitudE result = new MagnitudE();


            result = MagnitudN.SetMagnitud(new Object[] {
                new SqlParameter("@Accion", "INGRESAR"),
                new SqlParameter("@Nombre", magnitud.Nombre),
                new SqlParameter("@Abreviatura", magnitud.Abreviatura),
                new SqlParameter("@Estado", magnitud.Estado),
            });
            return result;
        }


        [HttpPost("EditarMagnitud")]
        public MagnitudE UpdateMagnitud([FromBody]  MagnitudE Magnitud)
        {
            MagnitudE result = new MagnitudE();


            result = MagnitudN.SetMagnitud(new Object[] {
                new SqlParameter("@Accion", "ACTUALIZAR"),
                new SqlParameter("@Id", Magnitud.Id),
                new SqlParameter("@Nombre", Magnitud.Nombre),
                new SqlParameter("@Abreviatura", Magnitud.Abreviatura),

            });
            return result;
        }


        [HttpPost("DeleteMagnitud")]
        public MagnitudE DeleteMagnitud([FromBody]  MagnitudE magnitud)
        {
            MagnitudE result = null;
            SqlParameter _accion = new SqlParameter("@Accion", "ELIMINAR");
            SqlParameter _id = new SqlParameter("@Id", magnitud.Id);

            Object[] Objeto = new Object[]
            {
                _accion,
                _id
            };

            result = MagnitudN.DeleteMagnitud(Objeto);
            return result;
        }






    }
}