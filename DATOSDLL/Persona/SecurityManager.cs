using ENTIDADESDDL.Empresa;
using ENTIDADESDDL.Persona;
using ENTIDADESDLL.Auth;
using MENSAJESDLL;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DATOSDLL.Persona
{
    public class SecurityManager
    {
        private JwtSettings _settings = null;

        public SecurityManager(JwtSettings settings)
        {
            _settings = settings;
        }
        public PersonaE ValidarUsuario(Object[] parametros)
        {

            // AppUserAuth ret = new AppUserAuth();
            PersonaE result = new PersonaE();

            Mensaje mensaje;

            AccesoDatos acceso = new AccesoDatos();
            SqlDataReader sqlDataReader = acceso.GetDataReader(out mensaje, parametros, "prPersona2");

            if (mensaje.Titulo == null)
            {
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        if (sqlDataReader.GetString(sqlDataReader.GetOrdinal("MensajeError")) == "")
                        {
                            result = new PersonaE()
                            {
                                Mensaje = new Mensaje(sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("IdError")), "Validando Usuario", sqlDataReader.GetString(sqlDataReader.GetOrdinal("MensajeError")), "Validando"),
                                Id = sqlDataReader.GetInt64(sqlDataReader.GetOrdinal("Id")),
                                Id_Empresa = sqlDataReader.GetInt64(sqlDataReader.GetOrdinal("Id_empresa")),
                                Usuario = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Usuario")),
                                Email = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Email")),
                                Nombre = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Nombre")),
                                Apellido = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Apellido")),
                                Clave = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Clave")),
                            };
                        }
                        else
                        {
                            result = new PersonaE()
                            {
                                Mensaje = new Mensaje(sqlDataReader.GetInt64(sqlDataReader.GetOrdinal("IdError")), "Validando Usuario", sqlDataReader.GetString(sqlDataReader.GetOrdinal("MensajeError")), "Validando"),
                            };
                        }


                    }
                }

            }
            else
            {
                result = new PersonaE()
                {
                    Mensaje = new Mensaje(sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("IdError")), "Validando Usuario", sqlDataReader.GetString(sqlDataReader.GetOrdinal("MensajeError")), "Validando Usuario", TipoMensaje.Error),
                };
            }

            if (result.Usuario != null)
            {
                result = BuildUserAuthObject(result);
               
            }

            sqlDataReader.Close();
            sqlDataReader = null;

            acceso.Desconectar();

            return result;
        }


        protected PersonaE BuildUserAuthObject(PersonaE authUser)
        {
            PersonaE ret = new PersonaE();

            ret.Usuario = authUser.Usuario;
            ret.IsAuthenticated = true;

            ret.Permisos = Permiso(authUser);
            ret.Mensaje = authUser.Mensaje;
            ret.Clave = authUser.Clave;

            ret.BearerToken = BuildJwtToken(ret);



            return ret;
        }

        public List<Permisos> Permiso(PersonaE authUser)
        {
            Object[] parametros = (new Object[] {
                    new SqlParameter("@Accion","Permisos"),
                    new SqlParameter("@Id",authUser.Id)
                });
            PersonaE result = new PersonaE();
            result.Permisos = new List<Permisos>();
            Mensaje mensaje;

            AccesoDatos acceso = new AccesoDatos();
            SqlDataReader sqlDataReader = acceso.GetDataReader(out mensaje, parametros, "prPersona2");

            if (mensaje.Titulo == null)
            {
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        result.Permisos.Add(new Permisos()
                        {
                            Id = sqlDataReader.GetInt64(sqlDataReader.GetOrdinal("Id")),
                            Proceso = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Proceso")),
                            Formulario = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Formulario")),
                            Seleccionado = sqlDataReader.GetBoolean(sqlDataReader.GetOrdinal("Seleccionado")),
                        });
                    }
                }
            }
            sqlDataReader.Close();
            sqlDataReader = null;

            acceso.Desconectar();

            return result.Permisos;
        }

        protected string BuildJwtToken(PersonaE authUser)
        {
            SymmetricSecurityKey key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_settings.Key));

            List<Claim> jwtClaims = new List<Claim>();
            /*jwtClaims.Add(new Claim(JwtRegisteredClaimNames.Sub,
                authUser.Usuario));*/
            jwtClaims.Add(new Claim("IdUsuario", authUser.Id.ToString()));
            jwtClaims.Add(new Claim("NombreUsuario", authUser.Nombre + " " + authUser.Apellido));
            jwtClaims.Add(new Claim("IdEmpresa", authUser.Id_Empresa.ToString()));
            jwtClaims.Add(new Claim("ClaveInsegura", authUser.Clave));
            jwtClaims.Add(new Claim(JwtRegisteredClaimNames.Jti,
                Guid.NewGuid().ToString()));

            jwtClaims.Add(new Claim("isAuthenticated",
                authUser.IsAuthenticated.ToString().ToLower()));

            /* foreach (var claim in authUser.Permisos)
             {

                 jwtClaims.Add(new Claim(claim.Formulario, claim.Proceso));
             }
             */
            foreach (Permisos item in authUser.Permisos)
            {
                jwtClaims.Add(new Claim(item.Id.ToString(), item.Formulario + "," + item.Proceso));
            }

            var token = new JwtSecurityToken(
                issuer: _settings.Issuer,
                audience: _settings.Audience,
                claims: jwtClaims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(
                    _settings.MinutesToExpiration),
                signingCredentials: new SigningCredentials(key,
                SecurityAlgorithms.HmacSha256)
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        /*
        public List<EmpresaE> Empresas(Object[] parametros)
        {
            PersonaE result = new PersonaE();
            result.Empresas = new List<EmpresaE>();
            Mensaje mensaje;

            AccesoDatos acceso = new AccesoDatos();
            SqlDataReader sqlDataReader = acceso.GetDataReader(out mensaje, parametros, "prPersona2");

            if (mensaje.Titulo == null)
            {
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        result.Empresas.Add(new EmpresaE()
                        {
                            Id = sqlDataReader.GetInt64(sqlDataReader.GetOrdinal("Id")),
                            RazonSocial = sqlDataReader.GetString(sqlDataReader.GetOrdinal("RazonSocial"))
                        });
                    }
                }
            }
            sqlDataReader.Close();
            sqlDataReader = null;

            acceso.Desconectar();

            return result.Empresas;
        }
        */
    }
}
