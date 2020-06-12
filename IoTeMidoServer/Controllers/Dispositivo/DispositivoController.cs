using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ENTIDADESDLL.Dispositivo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NEGOCIODLL.Dispositivo;

namespace WebCoreGemesisII.Controllers.Dispositivo
{
    [Route("api/[controller]")]
    [ApiController]
    public class DispositivoController : Controller
    {

        [HttpPost("getListaDispositivoxRed")]
        public List<DispositivoE> GetDispositivoListaxRed([FromBody]  DispositivoE Dispositivo)
        {
            List<DispositivoE> result = new List<DispositivoE>();


            result = DispositivoN.getListaDispositivoxRed(new Object[] {
                new SqlParameter("@Accion","GETALLLISTXRED"),
                new SqlParameter("@Id_red", Dispositivo.Id_red)
            });

            return result;
        }


        [HttpPost("getListaNodoxRed")]
        public List<DispositivoE> getListaNodoxRed([FromBody]  DispositivoE Dispositivo)
        {
            List<DispositivoE> result = new List<DispositivoE>();


            result = DispositivoN.getListaDispositivoxRed(new Object[] {
                new SqlParameter("@Accion","GETNODOXRED"),
                new SqlParameter("@Id_red", Dispositivo.Id_red)
            });

            return result;
        }


        [HttpPost("verificarImei")]
        public List<DispositivoE> verificarImei([FromBody]  DispositivoE Dispositivo)
        {
            List<DispositivoE> result = new List<DispositivoE>();


            result = DispositivoN.VerificarImei(new Object[] {
                new SqlParameter("@Accion","VERIFICARIMEI"),
                new SqlParameter("@IMEI", Dispositivo.IMEI)
            });

            return result;
        }


        [HttpPost("verificarEui")]
        public List<DispositivoE> verificarEui([FromBody]  DispositivoE Dispositivo)
        {
            List<DispositivoE> result = new List<DispositivoE>();


            result = DispositivoN.VerificarImei(new Object[] {
                new SqlParameter("@Accion","VERIFICAREUI"),
                new SqlParameter("@EUI", Dispositivo.EUI)
            });

            return result;
        }


        [HttpPost("GetDispositivo")]
        public DispositivoE GetDispositivo([FromBody]  DispositivoE Dispositivo)
        {
            DispositivoE result = null;
            SqlParameter _accion = new SqlParameter("@Accion", "GETONE");
            SqlParameter _id = new SqlParameter("@Id", Dispositivo.Id);
            SqlParameter _Parentid= new SqlParameter("@Parentid", Dispositivo.Parentid);

            Object[] Objeto = new Object[]
            {
                _accion,
                _id,
                _Parentid
            };

            result = DispositivoN.GetDispositivo(Objeto);
            return result;
        }


        [HttpPost("GetEuigat")]
        public DispositivoE GetEuiGat([FromBody]  DispositivoE Dispositivo)
        {
            DispositivoE result = null;
            SqlParameter _accion = new SqlParameter("@Accion", "GETEUIGAT");
            SqlParameter _Parentid = new SqlParameter("@Parentid", Dispositivo.Parentid);

            Object[] Objeto = new Object[]
            {
                _accion,
                _Parentid
            };

            result = DispositivoN.GetEuigat(Objeto);
            return result;
        }


        [HttpPost("GetDisp")]
        public DispositivoE GetDisp([FromBody]  DispositivoE Dispositivo)
        {
            DispositivoE result = null;
            SqlParameter _accion = new SqlParameter("@Accion", "GETDISP");
            SqlParameter _id = new SqlParameter("@Id", Dispositivo.Id);

            Object[] Objeto = new Object[]
            {
                _accion,
                _id,
            };

            result = DispositivoN.GetDisp(Objeto);
            return result;
        }


        [HttpPost("InsertDispositivo")]
        public DispositivoE InsertDispositivo([FromBody]  DispositivoE Dispositivo)
        {
            DispositivoE result = new DispositivoE();


            result = DispositivoN.SetDispositivo(new Object[] {
                new SqlParameter("@Accion", "INSERT"),
                new SqlParameter("@Direccionamiento", Dispositivo.Direccionamiento),
                new SqlParameter("@EUI", Dispositivo.EUI),
                new SqlParameter("@AppEUI", Dispositivo.AppEUI),
                new SqlParameter("@AppKEY", Dispositivo.AppKEY),
                new SqlParameter("@Id_red", Dispositivo.Id_red),
                new SqlParameter("@Latitud", Dispositivo.Latitud),
                new SqlParameter("@Longitud", Dispositivo.Longitud),
                new SqlParameter("@Modelo", Dispositivo.Modelo),
                new SqlParameter("@Nombre", Dispositivo.Nombre),
                new SqlParameter("@Tipo_disp", Dispositivo.Tipo_disp),
                new SqlParameter("@Parentid", Dispositivo.Parentid),
                new SqlParameter("@Version", Dispositivo.Version_SO),
                new SqlParameter("@Serial", Dispositivo.Serial),
                new SqlParameter("@Marca", Dispositivo.Marca),
                new SqlParameter("@Referencia", Dispositivo.Referencia),
                new SqlParameter("@Tag", Dispositivo.Tag),
                new SqlParameter("@Tipo_com", Dispositivo.Tipo_com),
                new SqlParameter("@APN", Dispositivo.APN),
                new SqlParameter("@Puerto", Dispositivo.Puerto),
                new SqlParameter("@IMEI", Dispositivo.IMEI),
                new SqlParameter("@Clase", Dispositivo.Clase),
                new SqlParameter("@Unidad_tiempo", Dispositivo.Unidad_tiempo),
                new SqlParameter("@Valor_UT", Dispositivo.Valor_UT),
                new SqlParameter("@Batch", Dispositivo.Batch),



            });
            return result;
        }


        [HttpPost("UpdateDispositivo")]
        public DispositivoE UpdateDispositivo([FromBody]  DispositivoE Dispositivo)
        {
            DispositivoE result = new DispositivoE();


            result = DispositivoN.SetDispositivo(new Object[] {
                new SqlParameter("@Accion", "UPDATE"),
                new SqlParameter("@Id", Dispositivo.Id),
                new SqlParameter("@Direccionamiento", Dispositivo.Direccionamiento),
                new SqlParameter("@EUI", Dispositivo.EUI),
                new SqlParameter("@AppEUI", Dispositivo.AppEUI),
                new SqlParameter("@AppKEY", Dispositivo.AppKEY),
                new SqlParameter("@Latitud", Dispositivo.Latitud),
                new SqlParameter("@Longitud", Dispositivo.Longitud),
                new SqlParameter("@Modelo", Dispositivo.Modelo),
                new SqlParameter("@Nombre", Dispositivo.Nombre),
                new SqlParameter("@Version", Dispositivo.Version_SO),
                new SqlParameter("@Serial", Dispositivo.Serial),
                new SqlParameter("@Marca", Dispositivo.Marca),
                new SqlParameter("@Referencia", Dispositivo.Referencia),
                new SqlParameter("@Tag", Dispositivo.Tag),
                new SqlParameter("@Tipo_com", Dispositivo.Tipo_com),
                new SqlParameter("@APN", Dispositivo.APN),
                new SqlParameter("@Puerto", Dispositivo.Puerto),
                new SqlParameter("@IMEI", Dispositivo.IMEI),
                new SqlParameter("@Clase", Dispositivo.Clase),
                new SqlParameter("@Unidad_tiempo", Dispositivo.Unidad_tiempo),
                new SqlParameter("@Valor_UT", Dispositivo.Valor_UT),
                new SqlParameter("@Batch", Dispositivo.Batch),





            });
            return result;
        }


        [HttpPost("DeleteDispositivo")]
        public DispositivoE DeleteDispositivo([FromBody]  DispositivoE Dispositivo)
        {
            DispositivoE result = null;
            SqlParameter _accion = new SqlParameter("@Accion", "DELETE");
            SqlParameter _id = new SqlParameter("@Id", Dispositivo.Id);

            Object[] Objeto = new Object[]
            {
                _accion,
                _id
            };

            result = DispositivoN.DeleteDispositivo(Objeto);
            return result;
        }



        [HttpPost("CountDispositivoChildren")]
        public DispositivoE CountDispositivoChildren([FromBody]  DispositivoE Dispositivo)
        {
            DispositivoE result = null;
            SqlParameter _accion = new SqlParameter("@Accion", "COUNTCHILDREN");
            SqlParameter _id = new SqlParameter("@Id", Dispositivo.Id);

            Object[] Objeto = new Object[]
            {
                _accion,
                _id
            };

            result = DispositivoN.CountDispositivoChildren(Objeto);
            return result;
        }


        [HttpPost("UpdateFechaAct")]
        public DispositivoE UpdateFechaAct([FromBody]  DispositivoE dispositivo)
        {
            DispositivoE result = new DispositivoE();


            result = DispositivoN.UpdateFechaAct(new Object[] {
                new SqlParameter("@Accion", "UPDATEFECHAACT"),
                new SqlParameter("@Id", dispositivo.Id),
                new SqlParameter("@FechaNodoAct", dispositivo.FechaNodoAct)

            });

            return result;
        }



    }
}