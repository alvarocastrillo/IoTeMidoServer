using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ENTIDADESDLL.FormularioProceso;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NEGOCIODLL.FormularioProceso;

namespace WebCoreGemesisII.Controllers.FormularioProceso
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormularioProcesoController : Controller
    {

        [HttpPost("GetLista")]
        public List<FormularioProcesoE> GetLista()
        {
            List<FormularioProcesoE> result = new List<FormularioProcesoE>();


            result = FormularioProcesoN.GetLista(new Object[] {
                new SqlParameter("@Accion","GETLISTA"),
            });

            return result;
        }




        [HttpPost("GetFormularioProceso")]
        public FormularioProcesoE GetFormularioProceso([FromBody]  FormularioProcesoE FormularioProceso)
        {
            FormularioProcesoE result = null;
            SqlParameter _accion = new SqlParameter("@Accion", "GETID");
            SqlParameter _id = new SqlParameter("@Id", FormularioProceso.Id);

            Object[] Objeto = new Object[]
            {
                _accion,
                _id
            };

            result = FormularioProcesoN.GetFormularioProceso(Objeto);
            return result;
        }


        [HttpPost("InsertFormularioProceso")]
        public FormularioProcesoE InsertFormularioProceso([FromBody]  FormularioProcesoE FormularioProceso)
        {
            FormularioProcesoE result = new FormularioProcesoE();


            result = FormularioProcesoN.SetFormularioProceso(new Object[] {
                new SqlParameter("@Accion", "INGRESAR"),
                //new SqlParameter("@Id_Empresa", FormularioProceso.Id_empresa),
                new SqlParameter("@Observacion", FormularioProceso.Observacion)
            });
            return result;
        }


        [HttpPost("EditarFormularioProceso")]
        public FormularioProcesoE UpdateFormularioProceso([FromBody]  FormularioProcesoE FormularioProceso)
        {
            FormularioProcesoE result = new FormularioProcesoE();


            result = FormularioProcesoN.SetFormularioProceso(new Object[] {
                new SqlParameter("@Accion", "ACTUALIZAR"),
                new SqlParameter("@Id", FormularioProceso.Id),
                new SqlParameter("@Observacion", FormularioProceso.Observacion)
 

            });
            return result;
        }


        [HttpPost("DeleteFormularioProceso")]
        public FormularioProcesoE DeleteFormularioProceso([FromBody]  FormularioProcesoE FormularioProceso)
        {
            FormularioProcesoE result = null;
            SqlParameter _accion = new SqlParameter("@Accion", "ELIMINAR");
            SqlParameter _id = new SqlParameter("@Id", FormularioProceso.Id);

            Object[] Objeto = new Object[]
            {
                _accion,
                _id
            };

            result = FormularioProcesoN.DeleteFormularioProceso(Objeto);
            return result;
        }


    }
}