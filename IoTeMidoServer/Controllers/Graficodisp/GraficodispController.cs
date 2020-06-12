using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ENTIDADESDLL.Graficodisp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NEGOCIODLL.Graficodisp;

namespace WebCoreGemesisII.Controllers.Graficodisp
{
    [Route("api/[controller]")]
    [ApiController]
    public class GraficodispController : Controller
    {
        //[Produces("application/json")]
        //[Route("api/Graficodisp/GetGraficodispLista/{id_dash:int}")]
        [HttpGet("GetGraficodispLista/{id_dash:int}")] 
        public List<GraficodispE> GetGraficodispLista(int id_dash)
        {
            List<GraficodispE> result = new List<GraficodispE>();


            result = GraficodispN.GetGraficodispLista(new Object[] {
                new SqlParameter("@Accion","GETLIST"),
                new SqlParameter("@Id_dashboard", id_dash)
            });

            return result;
        }

        //[Produces("application/json")]
        //[Route("api/Graficodisp/GetRegistroGrafdisp/{id_dash:int}")]
        [HttpGet("GetRegistroGrafdisp/{id_dash:int}")]
        public List<GraficodispE> GetRegistroGrafdisp(int id_dash)
        {
            List<GraficodispE> result = new List<GraficodispE>();


            result = GraficodispN.GetRegistroGrafdisp(new Object[] {
                new SqlParameter("@Accion","GETLIST"),
                new SqlParameter("@Id_dashboard", id_dash)
            });

            return result;
        }



        [HttpPost("GetGraficodisp")]
        public GraficodispE GetGraficodisp([FromBody]  GraficodispE Graficodisp)
        {
            GraficodispE result = null;
            SqlParameter _accion = new SqlParameter("@Accion", "GETID");
            SqlParameter _id = new SqlParameter("@Id", Graficodisp.Id);

            Object[] Objeto = new Object[]
            {
                _accion,
                _id
            };


            result = GraficodispN.GetGraficodisp(Objeto);
            return result;
        }


        [HttpPost("InsertGraficodisp")]
        public GraficodispE InsertGraficodisp([FromBody]  GraficodispE Graficodisp)
        {
            GraficodispE result = new GraficodispE();


            result = GraficodispN.SetGraficodisp(new Object[] {
                new SqlParameter("@Accion", "INGRESAR"),
                new SqlParameter("@Id_dashboard", Graficodisp.Dashboard.Id),
                new SqlParameter("@Id_disp", Graficodisp.Dispositivo.Id),
                new SqlParameter("@Titulo", Graficodisp.Titulo),
                new SqlParameter("@Tipo", Graficodisp.Tipo),
            });
            return result;
        }


        [HttpPost("EditarGraficodisp")]
        public GraficodispE UpdateGraficodisp([FromBody]  GraficodispE Graficodisp)
        {
            GraficodispE result = new GraficodispE();


            result = GraficodispN.SetGraficodisp(new Object[] {
                new SqlParameter("@Accion", "ACTUALIZAR"),
                new SqlParameter("@Id", Graficodisp.Id),
                new SqlParameter("@Id_disp", Graficodisp.Dispositivo.Id),
                new SqlParameter("@Titulo", Graficodisp.Titulo),
                new SqlParameter("@Tipo", Graficodisp.Tipo),
                
            });
            return result;
        }


        [HttpPost("DeleteGraficodisp")]
        public GraficodispE DeleteGraficodisp([FromBody]  GraficodispE Graficodisp)
        {
            GraficodispE result = null;
            SqlParameter _accion = new SqlParameter("@Accion", "ELIMINAR");
            SqlParameter _id = new SqlParameter("@Id", Graficodisp.Id);

            Object[] Objeto = new Object[]
            {
                _accion,
                _id
            };

            result = GraficodispN.DeleteGraficodisp(Objeto);
            return result;
        }
    }
}