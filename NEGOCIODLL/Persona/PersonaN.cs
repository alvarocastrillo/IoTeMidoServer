using DATOSDLL.Persona;
using ENTIDADESDDL.Empresa;
using ENTIDADESDDL.Persona;
using ENTIDADESDLL.Auth;
using System;
using System.Collections.Generic;
using System.Text;

namespace NEGOCIODLL.Persona
{
    public class PersonaN
    {
        public static string CreateMD5(string valor)
        {

            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(valor);
                byte[] hashBytes = md5.ComputeHash(inputBytes);


                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
        public static PersonaE ValidarUsuario(Object[] parametros, JwtSettings mg_settingsr)
        {
            SecurityManager persona = new SecurityManager(mg_settingsr);
            return persona.ValidarUsuario(parametros);

        }

/*
        public static List<Permisos> Permiso(Object[] parametros)
        {
            SecurityManager persona = new SecurityManager(mgr);
            return persona.Permiso(parametros);

        }
  */
        /*
        public static List<EmpresaE> Empresas(Object[] parametros)
        {
            PersonaD persona = new PersonaD();
            return persona.Empresas(parametros);

        }
        */
    }
}
