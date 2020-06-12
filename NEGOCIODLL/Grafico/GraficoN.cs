using DATOSDLL.Grafico;
using ENTIDADESDLL.Grafico;
using System;
using System.Collections.Generic;
using System.Text;

namespace NEGOCIODLL.Grafico
{
    public class GraficoN
    {
        public static List<GraficoE> GetGraficoLista(Object[] parametros)
        {
            GraficoD Grafico = new GraficoD();

            return Grafico.GetGraficoLista(parametros);
        }

        public static List<GraficoE> GetRegistroGraf(Object[] parametros)
        {
            GraficoD Grafico = new GraficoD();

            return Grafico.GetRegistroGraf(parametros);
        }


        public static GraficoE GetGrafico(Object[] parametros)
        {
            GraficoD Grafico = new GraficoD();

            return Grafico.GetGrafico(parametros);

        }

        public static GraficoE SetGrafico(Object[] parametros)
        {
            GraficoD Grafico = new GraficoD();

            return Grafico.SetGrafico(parametros);

        }


        public static GraficoE DeleteGrafico(Object[] parametros)
        {
            GraficoD Grafico = new GraficoD();

            return Grafico.DeleteGrafico(parametros);

        }
    }
}
