using DATOSDLL.AparatoD;
using ENTIDADESDLL.Aparato;
using ENTIDADESDLL.Unidad;
using System;
using System.Collections.Generic;
namespace NEGOCIODLL.Aparato
{
    public class AparatoN
    {
        public static List<AparatoE> GetAparatos(Object[] parametros)
        {
            AparatoD aparato = new AparatoD();

            return aparato.GetAparatos(parametros);

        }


        public static List<AparatoE> GetAllAparatos(Object[] parametros)
        {
            List<AparatoE> result = new List<AparatoE>();

            AparatoD Aparato = new AparatoD();

            result = Aparato.GetAllAparatos(parametros);

           // List<AparatoE> ordenada = (from x in result orderby x.Posicion ascending select x).ToList<AparatoE>();

            return result;

        }

        public static List<AparatoE> GetAllAparatosMeca(Object[] parametros)
        {
            List<AparatoE> result = new List<AparatoE>();

            AparatoD Aparato = new AparatoD();

            result = Aparato.GetAllAparatosMeca(parametros);

            return result;

        }

        //Metodos para el grafico chart, hacer filtros para agregar parametros
        public static List<AparatoE> GetAllMagSensores(Object[] parametros)
        {
            List<AparatoE> result = new List<AparatoE>();

            AparatoD Aparato = new AparatoD();

            result = Aparato.GetAllMagSensores(parametros);

            return result;

        }
        public static List<UnidadE> GetAllUnidadXSen(Object[] parametros)
        {
            List<UnidadE> result = new List<UnidadE>();

            AparatoD Aparato = new AparatoD();

            result = Aparato.GetAllUnidadXSen(parametros);

            return result;

        }
        public static List<AparatoE> GetAllSensordXUnidad(Object[] parametros)
        {
            List<AparatoE> result = new List<AparatoE>();

            AparatoD Aparato = new AparatoD();

            result = Aparato.GetAllSensordXUnidad(parametros);

            return result;

        }


        //

        public static List<AparatoE> GetAllApaSensores(Object[] parametros)
        {
            List<AparatoE> result = new List<AparatoE>();

            AparatoD Aparato = new AparatoD();

            result = Aparato.GetAllApaSensores(parametros);

            return result;

        }



        public static AparatoE GetAparato(Object[] parametros)
        {
            AparatoD Aparato = new AparatoD();

            return Aparato.GetAparato(parametros);

        }

        public static AparatoE SetAparato(Object[] parametros)
        {
            AparatoD Aparato = new AparatoD();

            return Aparato.SetAparato(parametros);

        }

        public static AparatoE SetUpdatePosicion(Object[] parametros)
        {
            AparatoD Aparato = new AparatoD();

            return Aparato.SetUpdatePosicion(parametros);

        }
        public static AparatoE DeleteAparato(Object[] parametros)
        {
            AparatoD Aparato = new AparatoD();

            return Aparato.DeleteAparato(parametros);

        }


    }
}
