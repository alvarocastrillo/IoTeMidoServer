using DATOSDLL.Red;
using ENTIDADESDLL.Red;
using System;
using System.Collections.Generic;
using System.Text;

namespace NEGOCIODLL.Red
{
    public class RedN
    {
        public static RedE SetRed(Object[] parametros)
        {
            RedD Red = new RedD();

            return Red.SetRed(parametros);

        }
    }
}
