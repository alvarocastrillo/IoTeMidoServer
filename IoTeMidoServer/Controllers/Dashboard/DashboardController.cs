using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ENTIDADESDLL.Dashboard;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NEGOCIODLL.Dashboard;

namespace WebCoreGemesisII.Controllers.Dashboard
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : Controller
    {
       // [Produces("application/json")]
       // [Route("api/Dashboard/GetDashboardLista/{id_emp:int}")]
        [HttpGet("GetDashboardLista/{id_emp:int}")] //Obtener Imágen
        public List<DashboardE> GetDashboardLista(int id_emp)
        {
            List<DashboardE> result = new List<DashboardE>();


            result = DashboardN.GetDashboardLista(new Object[] {
                new SqlParameter("@Accion","GETLIST"),
                new SqlParameter("@Id_empresa", id_emp)
            });

            return result;
        }


        [HttpPost("GetIdSelected")]
        public DashboardE GetIdSelected([FromBody]  DashboardE Dashboard)
        {
            DashboardE result = null;
            SqlParameter _accion = new SqlParameter("@Accion", "GETSELECT");
            SqlParameter _id = new SqlParameter("@Id_empresa", Dashboard.Red.Id_empresa);

            Object[] Objeto = new Object[]
            {
                _accion,
                _id
            };

            result = DashboardN.GetIdSelected(Objeto);
            return result;
        }



        [HttpPost("GetDashboard")]
        public DashboardE GetDashboard([FromBody]  DashboardE Dashboard)
        {
            DashboardE result = null;
            SqlParameter _accion = new SqlParameter("@Accion", "GETID");
            SqlParameter _id = new SqlParameter("@Id", Dashboard.Id);

            Object[] Objeto = new Object[]
            {
                _accion,
                _id
            };

            result = DashboardN.GetDashboard(Objeto);
            return result;
        }


        [HttpPost("InsertDashboard")]
        public DashboardE InsertDashboard([FromBody]  DashboardE Dashboard)
        {
            DashboardE result = new DashboardE();


            result = DashboardN.SetDashboard(new Object[] {
                new SqlParameter("@Accion", "INGRESAR"),
                new SqlParameter("@Id_red", Dashboard.Red.Id),
                new SqlParameter("@Nombre", Dashboard.Nombre),
                new SqlParameter("@Descripcion", Dashboard.Descripcion),
                new SqlParameter("@Selected", Dashboard.Selected),
            });
            return result;
        }


        [HttpPost("EditarDashboard")]
        public DashboardE UpdateDashboard([FromBody]  DashboardE Dashboard)
        {
            DashboardE result = new DashboardE();


            result = DashboardN.SetDashboard(new Object[] {
                new SqlParameter("@Accion", "ACTUALIZAR"),
                new SqlParameter("@Id", Dashboard.Id),
                new SqlParameter("@Id_red", Dashboard.Red.Id),
                new SqlParameter("@Nombre", Dashboard.Nombre),
                new SqlParameter("@Descripcion", Dashboard.Descripcion),
                new SqlParameter("@Selected", Dashboard.Selected),

            });
            return result;
        }

        [HttpPost("SelectedDashboard")]
        public DashboardE SelectedDashboard([FromBody]  DashboardE Dashboard)
        {
            DashboardE result = new DashboardE();


            result = DashboardN.SetDashboard(new Object[] {
                new SqlParameter("@Accion", "SELECTED"),
                new SqlParameter("@Id", Dashboard.Id),
                new SqlParameter("@Id_empresa", Dashboard.Red.Id_empresa),
                new SqlParameter("@Selected", Dashboard.Selected),

            });
            return result;
        }


        [HttpPost("DeleteDashboard")]
        public DashboardE DeleteDashboard([FromBody]  DashboardE Dashboard)
        {
            DashboardE result = null;
            SqlParameter _accion = new SqlParameter("@Accion", "ELIMINAR");
            SqlParameter _id = new SqlParameter("@Id", Dashboard.Id);

            Object[] Objeto = new Object[]
            {
                _accion,
                _id
            };

            result = DashboardN.DeleteDashboard(Objeto);
            return result;
        }

    }
}