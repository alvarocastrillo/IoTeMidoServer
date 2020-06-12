using ENTIDADESDLL.Red;
using MENSAJESDLL;
using System;
using System.Collections.Generic;
using System.Text;

namespace ENTIDADESDLL.Dispositivo
{
    public class DispositivoE
    {
        public Int64 Id { get; set; }
        public Int64 Id_red { get; set; }
        public Int64 Parentid { get; set; }
        public String Tipo_disp { get; set; }
        public String Nombre { get; set; }
        public String Latitud { get; set; }
        public String Longitud { get; set; }
        public String Serial { get; set; }
        public String Marca { get; set; }
        public String Referencia { get; set; }
        public String Tag { get; set; }
        public String Tipo_com { get; set; }
        public String Direccionamiento { get; set; }
        public String Modelo { get; set; }
        public String Version_SO { get; set; }
        public String EUI { get; set; }
        public String AppEUI { get; set; }
        public String AppKEY { get; set; }
        public Mensaje Mensaje { get; set; }
        public String APN { get; set; }
        public String Puerto { get; set; }
        public String IMEI { get; set; }
        public String Clase { get; set; }
        public String Unidad_tiempo { get; set; }
        public String Valor_UT { get; set; }
        public Int32 CountChildren { get; set; }
        public String EUIGAT { get; set; }
        public DateTime? FechaNodoAct { get; set; }
        public RedE red { get; set; }
        public Boolean Batch { get; set; }
    }
}
