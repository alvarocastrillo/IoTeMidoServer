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
            SecurityManager security = new SecurityManager(mg_settingsr);
            return security.ValidarUsuario(parametros);

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
        public static PersonaE getPersonaEmpresa(Object[] parametros)
        {
            PersonaD persona = new PersonaD();
            return persona.getPersonaEmpresa(parametros);

        }

        public static PersonaE verificarUsuario(Object[] parametros)
        {
            PersonaD persona = new PersonaD();
            return persona.VerificarUsuario(parametros);

        }

        public static PersonaE verificarEmail(Object[] parametros)
        {
            PersonaD persona = new PersonaD();
            return persona.verificarEmail(parametros);

        }

        //public static List<PersonaE> GetListaPersonasEmp(Object[] parametros)
        //{
        //    PersonaD persona = new PersonaD();
        //    return persona.GetListaPersonasEmp(parametros);

        //}

        public static List<PersonaE> GetListaPersonas(Object[] parametros)
        {
            PersonaD persona = new PersonaD();
            return persona.GetListaPersonas(parametros);

        }

        public static PersonaE GetPersona(Object[] parametros)
        {
            PersonaD Persona = new PersonaD();

            return Persona.GetPersona(parametros);

        }

        public static PersonaE SetPersona(Object[] parametros)
        {
            PersonaD Persona = new PersonaD();

            return Persona.SetPersona(parametros);

        }

        public static PersonaE DeletePersona(Object[] parametros)
        {
            PersonaD Persona = new PersonaD();

            return Persona.DeletePersona(parametros);

        }
        public static PersonaE ChangedPassword(Object[] parametros)
        {
            PersonaD Persona = new PersonaD();

            return Persona.ChangedPassword(parametros);

        }
    }
}
