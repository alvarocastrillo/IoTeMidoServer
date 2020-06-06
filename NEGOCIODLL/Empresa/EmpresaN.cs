using DATOSDLL.Empresa;
using ENTIDADESDDL.Empresa;
using System;
using System.Collections.Generic;
using System.Text;

namespace NEGOCIODLL.Empresa
{
    public class EmpresaN
    {
        public static List<EmpresaE> GetEmpresaLista(Object[] parametros)
        {
            EmpresaD empresa = new EmpresaD();

            return empresa.GetEmpresaLista(parametros);
        }
    }
}
