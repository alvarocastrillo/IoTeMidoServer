using DATOSDLL.GraficodispD;
using ENTIDADESDLL.Graficodisp;
using System;
using System.Collections.Generic;
using System.Text;

namespace NEGOCIODLL.Graficodisp
{
    public class GraficodispN
    {
        public static List<GraficodispE> GetGraficodispLista(Object[] parametros)
        {
            GraficodispD Graficodisp = new GraficodispD();

            return Graficodisp.GetGraficodispLista(parametros);
        }

        public static List<GraficodispE> GetRegistroGrafdisp(Object[] parametros)
        {
            GraficodispD Graficodisp = new GraficodispD();

            return Graficodisp.GetRegistroGrafdisp(parametros);
        }


        public static GraficodispE GetGraficodisp(Object[] parametros)
        {
            GraficodispD Graficodisp = new GraficodispD();

            return Graficodisp.GetGraficodisp(parametros);

        }



        public static GraficodispE SetGraficodisp(Object[] parametros)
        {
            GraficodispD Graficodisp = new GraficodispD();

            return Graficodisp.SetGraficodisp(parametros);

        }

        public static GraficodispE DeleteGraficodisp(Object[] parametros)
        {
            GraficodispD Graficodisp = new GraficodispD();

            return Graficodisp.DeleteGraficodisp(parametros);

        }
    }
}
