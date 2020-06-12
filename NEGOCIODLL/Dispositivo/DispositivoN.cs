using DATOSDLL.Dispositivo;
using ENTIDADESDLL.Dispositivo;
using System;
using System.Collections.Generic;
using System.Text;

namespace NEGOCIODLL.Dispositivo
{
    public class DispositivoN
    {
        public static List<DispositivoE> getListaDispositivoxRed(Object[] parametros)
        {
            DispositivoD dispositivo= new DispositivoD();

            return dispositivo.getListaDispositivoxRed(parametros);
        }

        public static DispositivoE GetDispositivo(Object[] parametros)
        {
            DispositivoD dispositivo = new DispositivoD();

            return dispositivo.GetDispositivo(parametros);

        }

        public static DispositivoE GetEuigat(Object[] parametros)
        {
            DispositivoD dispositivo = new DispositivoD();

            return dispositivo.GetEuigat(parametros);

        }

        public static List<DispositivoE> VerificarEui(Object[] parametros)
        {
            DispositivoD dispositivo = new DispositivoD();

            return dispositivo.VerificarEui(parametros);

        }
        public static List<DispositivoE> VerificarImei(Object[] parametros)
        {
            DispositivoD dispositivo = new DispositivoD();

            return dispositivo.VerificarImei(parametros);

        }
        public static DispositivoE GetDisp(Object[] parametros)
        {
            DispositivoD dispositivo = new DispositivoD();

            return dispositivo.GetDisp(parametros);

        }

        public static DispositivoE SetDispositivo(Object[] parametros)
        {
            DispositivoD dispositivo = new DispositivoD();

            return dispositivo.SetDispositivo(parametros);

        }

        public static DispositivoE DeleteDispositivo(Object[] parametros)
        {
            DispositivoD dispositivo = new DispositivoD();

            return dispositivo.DeleteDispositivo(parametros);

        }

        public static DispositivoE CountDispositivoChildren(Object[] parametros)
        {
            DispositivoD dispositivo = new DispositivoD();

            return dispositivo.CountDispositivoChildren(parametros);

        }

        public static DispositivoE UpdateFechaAct(Object[] parametros)
        {
            DispositivoD dispositivo = new DispositivoD();

            return dispositivo.UpdateFechaAct(parametros);

        }
    }
}
