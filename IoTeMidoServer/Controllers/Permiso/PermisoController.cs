using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ENTIDADESDLL.Permiso;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NEGOCIODLL.Permiso;
using Newtonsoft.Json.Linq;

namespace WebCoreGemesisII.Controllers.Permiso
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermisoController : Controller
    {
        //[produces("application/json")]
        //[route("api/permiso/getpermisolista/{id_emp:int}")]
        //public list<permisoe> getpermisolista(int id_emp)
        //{
        //    list<permisoe> result = new list<permisoe>();


        //    result = permison.getpermisolista(new object[] {
        //        new sqlparameter("@accion","getlist"),
        //        new sqlparameter("@id_empresa", id_emp)
        //    });

        //    return result;
        //}



        //[HttpPost] //Obtener Permiso
        //[Produces("application/json")]
        //[Route("api/Permiso/GetPermiso")]
        //public PermisoE GetPermiso([FromBody]  PermisoE Permiso)
        //{
        //    PermisoE result = null;
        //    SqlParameter _accion = new SqlParameter("@Accion", "GETID");
        //    SqlParameter _id = new SqlParameter("@Id", Permiso.Id);

        //    Object[] Objeto = new Object[]
        //    {
        //        _accion,
        //        _id
        //    };

        //    result = PermisoN.GetPermiso(Objeto);
        //    return result;
        //}

        //[HttpPost] //Insertar Permiso
        //[Produces("application/json")]
        //[Route("api/Permiso/InsertPermiso")]
        //public PermisoE InsertPermiso([FromBody]  PermisoE Permiso)
        //{
        //    PermisoE result = new PermisoE();


        //    result = PermisoN.SetPermiso(new Object[] {
        //        new SqlParameter("@Accion", "INGRESAR"),
        //        new SqlParameter("@Id_FormularioProceso", Permiso.FormularioProceso.Id),
        //        new SqlParameter("@Id_Persona", Permiso.Persona.Id)
        //    });
        //    return result;
        //}

       // [HttpPost] //Insertar Permiso
       // [Produces("application/json")]
       // [Route("api/Permiso/GetPermisos/{id_persona:int}")]
        [HttpGet("GetPermisos/{id_persona:int}")]
        public List<PermisoE> GetPermisos(int id_persona)
        {
            List<PermisoE> result = new List<PermisoE>();

            result = PermisoN.GetPermisos(new Object[] {
                new SqlParameter("@Accion", "Permisos"),
                new SqlParameter("@Id_Persona", id_persona)
            });
            return result;
        }

        //[HttpPost]
        //[Produces("application/json")]
        //[Route("api/Permiso/EditarPermiso")]
        //public PermisoE UpdatePermiso([FromBody]  PermisoE Permiso)
        //{
        //    PermisoE result = new PermisoE();


        //    result = PermisoN.SetPermiso(new Object[] {
        //        new SqlParameter("@Accion", "ACTUALIZAR"),
        //        new SqlParameter("@Id", Permiso.Id),
        //        new SqlParameter("@Nombre", Permiso.Nombre),
        //        new SqlParameter("@Tipo_com", Permiso.Tipo_com),

        //    });
        //    return result;
        //}


        [HttpPost("InsertPermiso")]
        public JsonResult InsertPermiso()
        {
            var stream = HttpContext.Request.Body;
            PermisosE resultq = new PermisosE();
            List<PermisosE> lista = new List<PermisosE>();

            string json = new StreamReader(stream).ReadToEnd();
            lista = Newtonsoft.Json.JsonConvert.DeserializeObject<List<PermisosE>>(json);
            int user_id;
            user_id = int.Parse(lista[0].name);
            SqlParameter _accion = new SqlParameter("@Accion", "LIMPIAR");
            SqlParameter _id_pers = new SqlParameter("@Id_Persona", user_id);

            PermisoE result = null;
            Object[] Objeto = new Object[]
            {
                _accion,
                _id_pers
            };

            result = PermisoN.DeletePermiso(Objeto);
            if(result.Mensaje.Titulo == "")
            {
                foreach (PermisosE element in lista)
                {
                  PermisoE result1 = new PermisoE();
                  result1 = PermisoN.SetPermiso(new Object[] {
                      new SqlParameter("@Accion", "INGRESAR"),
                      new SqlParameter("@Id_FormularioProceso", int.Parse(element.value)),
                      new SqlParameter("@Id_Persona", int.Parse(element.name))
                  });

                }
            }
            JsonResult r = Json(new { data = lista });
            return r;
        }


        [HttpPost("LimpiarPermiso")]
        public JsonResult LimpiarPermiso()
        {
            var stream = HttpContext.Request.Body;
            PermisosE resultp = new PermisosE();
            List<PermisosE> lista = new List<PermisosE>();

            string json = new StreamReader(stream).ReadToEnd();
            //json = json.Substring(3, 5);
            resultp = Newtonsoft.Json.JsonConvert.DeserializeObject<PermisosE>(json);
            int user_id;
            user_id = int.Parse(resultp.value);
            SqlParameter _accion = new SqlParameter("@Accion", "LIMPIAR");
            SqlParameter _id_pers = new SqlParameter("@Id_Persona", user_id);

            PermisoE result = null;
            Object[] Objeto = new Object[]
            {
                _accion,
                _id_pers
            };

            result = PermisoN.DeletePermiso(Objeto);
            JsonResult r = Json(new { data = lista });
            return r;
        }

    }
}