using DATOSDLL.Magnitud;
using ENTIDADESDLL.Magnitud;
using System;
using System.Collections.Generic;
using System.Text;

namespace NEGOCIODLL.Magnitud
{
    public class MagnitudN
    {
        public static List<MagnitudE> GetMagnitudes(Object[] parametros)
        {
            MagnitudD magnitudD = new MagnitudD();

            return magnitudD.GetAllMagnitudes(parametros);

        }

        public static MagnitudE GetMagnitud(Object[] parametros)
        {
            MagnitudD MagnitudD = new MagnitudD();

            return MagnitudD.GetMagnitud(parametros);

        }

        public static MagnitudE SetMagnitud(Object[] parametros)
        {
            MagnitudD MagnitudD = new MagnitudD();

            return MagnitudD.SetMagnitud(parametros);

        }

        public static MagnitudE DeleteMagnitud(Object[] parametros)
        {
            MagnitudD MagnitudD = new MagnitudD();

            return MagnitudD.DeleteMagnitud(parametros);

        }
    }
}
