using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ENTIDADESDDL.Empresa;
using System.Data.SqlClient;
using NEGOCIODLL.Empresa;

namespace WebCoreGemesisII.Controllers.Empresa
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : Controller
    {

        [HttpPost("GetEmpresaLista")]
        public List<EmpresaE> GetEmpresaLista()
        {
            List<EmpresaE> result = new List<EmpresaE>();


            result= EmpresaN.GetEmpresaLista(new Object[] {
                new SqlParameter("@Accion","GETALLLIST")                
            });

            return result;
        }


        [HttpPost("GetEmpresa")]
        public EmpresaE GetEmpresa([FromBody]  EmpresaE empresa)
        {
            EmpresaE result = null;
            SqlParameter _accion = new SqlParameter("@Accion", "GETID");
            SqlParameter _id = new SqlParameter("@Id", empresa.Id);

            Object[] Objeto = new Object[]
            {
                _accion,
                _id
            };

            result = EmpresaN.GetEmpresa(Objeto);
            return result;
        }


        [HttpPost("InsertEmpresa")]
        public EmpresaE InsertEmpresa([FromBody]  EmpresaE empresa)
        {
            EmpresaE result = new EmpresaE();


            result = EmpresaN.SetEmpresa(new Object[] {
                new SqlParameter("@Accion", "INGRESAR"),
                new SqlParameter("@Id_Identificacion", empresa.Id_Identificacion),
                new SqlParameter("@Id_Departamento", empresa.Id_Departamento),
                new SqlParameter("@Id_Ciudad", empresa.Id_Ciudad),
                new SqlParameter("@Identificacion", empresa.Identificacion),
                new SqlParameter("@Nombre", empresa.RazonSocial),
                new SqlParameter("@Nombres", empresa.Nombres),
                new SqlParameter("@Apellidos", empresa.Apellidos),
                new SqlParameter("@Naturaleza", empresa.Naturaleza.IdString),
                new SqlParameter("@Direccion", empresa.Direccion),
                new SqlParameter("@Telefono", empresa.Telefono),
                new SqlParameter("@Contacto", empresa.Contacto),
                new SqlParameter("@Cargo", empresa.Cargo),
                new SqlParameter("@Observacion", empresa.Observacion),
                new SqlParameter("@Id_Usuario", empresa.Id_Usuario),
                new SqlParameter("@Estado", empresa.Estado),


            });
            return result;
        }

        [HttpPost("UpdateEmpresa")]
        public EmpresaE UpdateEmpresa([FromBody]  EmpresaE empresa)
        {
            EmpresaE result = new EmpresaE();


            result = EmpresaN.SetEmpresa(new Object[] {
                new SqlParameter("@Accion", "ACTUALIZAR"),
                new SqlParameter("@Id", empresa.Id),
                new SqlParameter("@Id_Identificacion", empresa.Id_Identificacion),
                new SqlParameter("@Id_Departamento", empresa.Id_Departamento),
                new SqlParameter("@Id_Ciudad", empresa.Id_Ciudad),
                new SqlParameter("@Identificacion", empresa.Identificacion),
                new SqlParameter("@Nombre", empresa.RazonSocial),
                new SqlParameter("@Nombres", empresa.Nombres),
                new SqlParameter("@Apellidos", empresa.Apellidos),
                new SqlParameter("@Naturaleza", empresa.Naturaleza.IdString),
                new SqlParameter("@Direccion", empresa.Direccion),
                new SqlParameter("@Telefono", empresa.Telefono),
                new SqlParameter("@Contacto", empresa.Contacto),
                new SqlParameter("@Cargo", empresa.Cargo),
                new SqlParameter("@Observacion", empresa.Observacion),
                new SqlParameter("@Estado", empresa.Estado),
                new SqlParameter("@Id_Usuario", empresa.Id_Usuario)

            });
            //   result.Url_azure_img = VerImagen(result.Imagen);
            return result;
        }






    }




}