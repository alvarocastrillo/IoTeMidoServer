using DATOSDLL.Red;
using ENTIDADESDLL.Red;
using System;
using System.Collections.Generic;
using System.Text;

namespace NEGOCIODLL.Red
{
    public class RedN
    {
        public static List<RedE> GetRedLista(Object[] parametros)
        {
            RedD red = new RedD();

            return red.GetRedLista(parametros);
        }

        public static List<RedE> getRedesTipoCom(Object[] parametros)
        {
            RedD red = new RedD();

            return red.getRedesTipoCom(parametros);
        }

        public static RedE GetRed(Object[] parametros)
        {
            RedD Red = new RedD();

            return Red.GetRed(parametros);

        }

        public static RedE SetRed(Object[] parametros)
        {
            RedD Red = new RedD();

            return Red.SetRed(parametros);

        }

        public static RedE DeleteRed(Object[] parametros)
        {
            RedD Red = new RedD();

            return Red.DeleteRed(parametros);

        }
    }
}
