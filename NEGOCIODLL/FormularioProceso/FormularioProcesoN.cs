using DATOSDLL.FormularioProceso;
using ENTIDADESDLL.FormularioProceso;
using System;
using System.Collections.Generic;
using System.Text;

namespace NEGOCIODLL.FormularioProceso
{
    public class FormularioProcesoN
    {
        public static List<FormularioProcesoE> GetLista(Object[] parametros)
        {
            FormularioProcesoD FormularioProceso = new FormularioProcesoD();

            return FormularioProceso.GetLista(parametros);
        }

        public static List<FormularioProcesoE> getFormularioProcesoesTipoCom(Object[] parametros)
        {
            FormularioProcesoD FormularioProceso = new FormularioProcesoD();

            return FormularioProceso.getFormularioProcesoesTipoCom(parametros);
        }

        public static FormularioProcesoE GetFormularioProceso(Object[] parametros)
        {
            FormularioProcesoD FormularioProceso = new FormularioProcesoD();

            return FormularioProceso.GetFormularioProceso(parametros);

        }

        public static FormularioProcesoE SetFormularioProceso(Object[] parametros)
        {
            FormularioProcesoD FormularioProceso = new FormularioProcesoD();

            return FormularioProceso.SetFormularioProceso(parametros);

        }

        public static FormularioProcesoE DeleteFormularioProceso(Object[] parametros)
        {
            FormularioProcesoD FormularioProceso = new FormularioProcesoD();

            return FormularioProceso.DeleteFormularioProceso(parametros);

        }
    }
}
