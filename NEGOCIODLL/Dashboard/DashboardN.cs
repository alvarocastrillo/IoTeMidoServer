using DATOSDLL.Dashboard;
using ENTIDADESDLL.Dashboard;
using System;
using System.Collections.Generic;
using System.Text;

namespace NEGOCIODLL.Dashboard
{
    public class DashboardN
    {
        public static List<DashboardE> GetDashboardLista(Object[] parametros)
        {
            DashboardD Dashboard = new DashboardD();

            return Dashboard.GetDashboardLista(parametros);
        }


        public static DashboardE GetDashboard(Object[] parametros)
        {
            DashboardD Dashboard = new DashboardD();

            return Dashboard.GetDashboard(parametros);

        }

        public static DashboardE GetIdSelected(Object[] parametros)
        {
            DashboardD Dashboard = new DashboardD();

            return Dashboard.GetIdSelected(parametros);

        }

        public static DashboardE SetDashboard(Object[] parametros)
        {
            DashboardD Dashboard = new DashboardD();

            return Dashboard.SetDashboard(parametros);

        }

        public static DashboardE DeleteDashboard(Object[] parametros)
        {
            DashboardD Dashboard = new DashboardD();

            return Dashboard.DeleteDashboard(parametros);

        }
    }
    
}
