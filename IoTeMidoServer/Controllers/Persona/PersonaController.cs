using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ENTIDADESDDL.Persona;
using NEGOCIODLL.Persona;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using ENTIDADESDDL.Empresa;
using Newtonsoft.Json;
using NEGOCIODLL.Empresa;
using MENSAJESDLL;
using NEGOCIODLL.Permiso;
using ENTIDADESDLL.Permiso;

namespace WebCoreGemesisII.Controllers.Persona
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PersonaController : Controller
    {

        public readonly IConfiguration _configuration;

        public PersonaController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }


        
       





        [HttpPost("getPersonaEmpresa")]
        public PersonaE getPersonaEmpresa([FromBody]  PersonaE persona)
        {
            PersonaE result = null;
            SqlParameter _accion = new SqlParameter("@Accion", "GETIDPEREMPRESA");
            SqlParameter _id = new SqlParameter("@Id", persona.Id);

            Object[] Objeto = new Object[]
            {
                _accion,
                _id
            };

            result = PersonaN.getPersonaEmpresa(Objeto);
            return result;
        }


        [HttpGet("GetListaPersonasEmp/{id_emp:int}")]
        public List<PersonaE> GetListaPersonasEmp(int id_emp)
        {
            List<PersonaE> result = new List<PersonaE>();


            result = PersonaN.GetListaPersonas(new Object[] {
                new SqlParameter("@Accion","PERSOEMP"),
                new SqlParameter("@Id_Empresa", id_emp)
            });

            return result;
        }


        [HttpPost("GetListaPersonas")]
        public List<PersonaE> GetListaPersonas()
        {
            List<PersonaE> result = new List<PersonaE>();


            result = PersonaN.GetListaPersonas(new Object[] {
                new SqlParameter("@Accion","GETLISTA"),
            });

            return result;
        }


        [HttpPost("GetPersona")]
        public PersonaE GetPersona([FromBody]  PersonaE Persona)
        {
            PersonaE result = null;
            SqlParameter _accion = new SqlParameter("@Accion", "GETPERSONA");
            SqlParameter _id = new SqlParameter("@Id", Persona.Id);

            Object[] Objeto = new Object[]
            {
                _accion,
                _id
            };

            result = PersonaN.GetPersona(Objeto);
            return result;
        }


        [HttpPost("VerificarUsuario")]
        public PersonaE VerificarUsuario([FromBody]  PersonaE Persona)
        {
            PersonaE result = null;
            SqlParameter _accion = new SqlParameter("@Accion", "USUREP");
            SqlParameter _usu = new SqlParameter("@Usuario", Persona.Usuario);

            Object[] Objeto = new Object[]
            {
                _accion,
                _usu
            };

            result = PersonaN.verificarUsuario(Objeto);
            return result;
        }


        [HttpPost("verificarEmail")]
        public PersonaE verificarEmail([FromBody]  PersonaE Persona)
        {
            PersonaE result = null;
            SqlParameter _accion = new SqlParameter("@Accion", "EMAILREG");
            SqlParameter _usu = new SqlParameter("@Email", Persona.Email);

            Object[] Objeto = new Object[]
            {
                _accion,
                _usu
            };

            result = PersonaN.verificarEmail(Objeto);
            return result;
        }



        [HttpPost("InsertPersona")]
        public PersonaE InsertPersona([FromBody]  PersonaE Persona)
        {
            PersonaE result = new PersonaE();


            result = PersonaN.SetPersona(new Object[] {
                new SqlParameter("@Accion", "INGRESAR"),
                new SqlParameter("@Nombre", Persona.Nombre),
                new SqlParameter("@Apellido", Persona.Apellido),
                new SqlParameter("@Id_Identificacion", Persona.Id_Identificacion),
                new SqlParameter("@Identificacion", Persona.Identificacion),
                new SqlParameter("@Id_Empresa", Persona.Id_Empresa),
                new SqlParameter("@Direccion", Persona.Direccion),
                new SqlParameter("@Telefono", Persona.Telefono),
                new SqlParameter("@Email", Persona.Email),
                new SqlParameter("@Cargo", Persona.Cargo),
                new SqlParameter("@Usuario", Persona.Usuario),
                new SqlParameter("@Clave", PersonaN.CreateMD5(Persona.Clave)),
                new SqlParameter("@Estado", Persona.Estado),
            });
            return result;
        }


        [HttpPost("EditarPersona")]
        public PersonaE UpdatePersona([FromBody]  PersonaE Persona)
        {
            PersonaE result = new PersonaE();


            result = PersonaN.SetPersona(new Object[] {
                new SqlParameter("@Accion", "ACTUALIZAR"),
                new SqlParameter("@Id", Persona.Id),
                new SqlParameter("@Nombre", Persona.Nombre),
                new SqlParameter("@Apellido", Persona.Apellido),
                new SqlParameter("@Id_Identificacion", Persona.Id_Identificacion),
                new SqlParameter("@Identificacion", Persona.Identificacion),
                new SqlParameter("@Id_Empresa", Persona.Id_Empresa),
                new SqlParameter("@Direccion", Persona.Direccion),
                new SqlParameter("@Telefono", Persona.Telefono),
                new SqlParameter("@Email", Persona.Email),
                new SqlParameter("@Cargo", Persona.Cargo),
                new SqlParameter("@Usuario", Persona.Usuario),
                new SqlParameter("@Estado", Persona.Estado),
               // new SqlParameter("@Clave", PersonaN.CreateMD5(Persona.Clave)),

            });
            return result;
        }



        [HttpPost("editarRegistro")]
        public PersonaE editarRegistro([FromBody]  PersonaE Persona)
        {
            PersonaE result = new PersonaE();


            result = PersonaN.SetPersona(new Object[] {
                new SqlParameter("@Accion", "EDIREG"),
                new SqlParameter("@Id", Persona.Id),
                new SqlParameter("@Nombre", Persona.Nombre),
                new SqlParameter("@Apellido", Persona.Apellido),
                new SqlParameter("@Id_Identificacion", Persona.Id_Identificacion),
                new SqlParameter("@Identificacion", Persona.Identificacion),
                new SqlParameter("@Id_Empresa", Persona.Id_Empresa),
                new SqlParameter("@Direccion", Persona.Direccion),
                new SqlParameter("@Telefono", Persona.Telefono),
                new SqlParameter("@Email", Persona.Email),
                new SqlParameter("@Cargo", Persona.Cargo),
                new SqlParameter("@Usuario", Persona.Usuario),
                new SqlParameter("@Estado", Persona.Estado),
                new SqlParameter("@Clave", PersonaN.CreateMD5(Persona.Clave)),

            });
            return result;
        }


        [HttpPost("DeletePersona")]
        public PersonaE DeletePersona([FromBody]  PersonaE Persona)
        {
            PersonaE result = null;
            PermisoE resultPermiso = null;
            SqlParameter _limpiar = new SqlParameter("@Accion", "LIMPIAR");
            SqlParameter _idpersona = new SqlParameter("@Id_Persona", Persona.Id);

            Object[] Objeto1 = new Object[]
            {
                _limpiar,
                _idpersona
            };

            resultPermiso = PermisoN.DeletePermiso(Objeto1);
            if (resultPermiso.Mensaje.Titulo == "")
            {
                SqlParameter _accion = new SqlParameter("@Accion", "ELIMINAR");
                SqlParameter _id = new SqlParameter("@Id", Persona.Id);

                Object[] Objeto = new Object[]
                {
                _accion,
                _id
                };

                result = PersonaN.DeletePersona(Objeto);
            }

            return result;
        }


        [HttpPost("ChangedPassword")]
        public PersonaE ChangedPassword([FromBody]  PersonaE Persona)
        {
            PersonaE result = null;
            SqlParameter _accion = new SqlParameter("@Accion", "CHANGEDPASS");
            SqlParameter _id = new SqlParameter("@Id", Persona.Id);
            SqlParameter _clave = new SqlParameter("@Clave", PersonaN.CreateMD5(Persona.Clave));

            Object[] Objeto = new Object[]
            {
                _accion,
                _id,
                _clave
            };

            result = PersonaN.ChangedPassword(Objeto);
            return result;
        }



    }
}