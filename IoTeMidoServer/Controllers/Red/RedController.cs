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

        [HttpGet("GetRedLista/{id_emp:int}")]
        public List<RedE> GetRedLista(int id_emp)
        {
            List<RedE> result = new List<RedE>();


            result = RedN.GetRedLista(new Object[] {
                new SqlParameter("@Accion","GETLIST"),
                new SqlParameter("@Id_empresa", id_emp)
            });

            return result;
        }




        [HttpPost("GetRed")]
        public RedE GetRed([FromBody]  RedE Red)
        {
            RedE result = null;
            SqlParameter _accion = new SqlParameter("@Accion", "GETID");
            SqlParameter _id = new SqlParameter("@Id", Red.Id);

            Object[] Objeto = new Object[]
            {
                _accion,
                _id
            };

            result = RedN.GetRed(Objeto);
            return result;
        }

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

        [HttpPost("EditarRed")]
        public RedE UpdateRed([FromBody]  RedE Red)
        {
            RedE result = new RedE();


            result = RedN.SetRed(new Object[] {
                new SqlParameter("@Accion", "ACTUALIZAR"),
                new SqlParameter("@Id", Red.Id),
                new SqlParameter("@Nombre", Red.Nombre),
                new SqlParameter("@Tipo_com", Red.Tipo_com),

            });
            return result;
        }


        [HttpPost("DeleteRed")]
        public RedE DeleteRed([FromBody]  RedE Red)
        {
            RedE result = null;
            SqlParameter _accion = new SqlParameter("@Accion", "ELIMINAR");
            SqlParameter _id = new SqlParameter("@Id", Red.Id);

            Object[] Objeto = new Object[]
            {
                _accion,
                _id
            };

            result = RedN.DeleteRed(Objeto);
            return result;
        }


        [HttpPost("getRedesTipoCom")]
        public List<RedE> getRedesTipoCom([FromBody]  RedE Red)
        {
            List<RedE> result = new List<RedE>();


            result = RedN.getRedesTipoCom(new Object[] {
                new SqlParameter("@Accion","GETREDCOM"),
                new SqlParameter("@Tipo_com", Red.Tipo_com),
                new SqlParameter("@Id_empresa", Red.Id_empresa),
            });

            return result;
        }


    }
}