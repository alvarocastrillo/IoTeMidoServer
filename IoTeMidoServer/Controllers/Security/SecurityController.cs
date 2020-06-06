using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DATOSDLL.Persona;
using ENTIDADESDDL.Persona;
using ENTIDADESDLL.Auth;
using MENSAJESDLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NEGOCIODLL.Empresa;
using NEGOCIODLL.Persona;
using Newtonsoft.Json;

namespace IoTeMidoServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : BaseApiController
    {

        private JwtSettings _settings;

        public SecurityController(JwtSettings settings)
        {
            _settings = settings;
        }

        [HttpPost("ValidarUsuario")]
        public IActionResult ValidarUsuario([FromBody]PersonaE user)
        {// puede tener diferentes retornos
            IActionResult ret = null;
            PersonaE auth = new PersonaE();
           

            auth = PersonaN.ValidarUsuario(new Object[] {
                new SqlParameter("@Accion","ValidarUsuario"),
                new SqlParameter("@Usuario",user.Usuario),
                new SqlParameter("@Clave",PersonaN.CreateMD5(user.Clave))
            }, _settings);

            /*
            if (auth.IsAuthenticated)
            {
                ret = StatusCode(200, auth);
            }
            else
            {
                ret = StatusCode(404, "Invalid User Name/Password.");
            }
            */
         


            if (auth.Mensaje.Cuerpo == "")
            {
                string usuariomd5 = PersonaN.CreateMD5(auth.Usuario);
                if (usuariomd5 == auth.Clave)
                {
                    auth.Clave = "cambiarclave";
                }
                else
                {
                    auth.Clave = "";
                }

                Permisos permisoEmpresas = (from x in auth.Permisos where x.Formulario == "Empresa" && x.Proceso == "Ver Lista" && x.Seleccionado == true select x).FirstOrDefault<Permisos>();

                // es para saber si puede ver todas las empresas que estan disponibles
                if (permisoEmpresas != null)
                {
                    auth.Empresas = EmpresaN.GetEmpresaLista(new Object[] {
                            new SqlParameter("@Accion","GETALLLIST")
                    });
                }
                // solo puede ver su empresa(tabla empresapersona vacia) 
                /* else
                 {
                     result.Empresas = PersonaN.Empresas(new Object[] {
                     new SqlParameter("@Accion","Empresas"),
                     new SqlParameter("@Id",IdPersona)

                      });
                 }
                 */
                //result = nombres,apellidos,email, lista de empresas o solo una empresa, id, id_empresa, usuario,lista permisos
                return Ok(new
                {
                    token = auth.BearerToken,
                    mensaje = new Mensaje { Titulo = "" }
                });
                
            }
            else
            {
                // no esta registrado
                return Ok(auth);
            }


        }
      
    }
}