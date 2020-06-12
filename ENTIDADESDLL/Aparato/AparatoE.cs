using ENTIDADESDLL.Dispositivo;
using ENTIDADESDLL.Magnitud;
using ENTIDADESDLL.Unidad;
using MENSAJESDLL;
using System;
using System.Collections.Generic;
using System.Text;

namespace ENTIDADESDLL.Aparato
{
    public class AparatoE
    {
        public Int64 Id { get; set; }
        public Int64? Id_Nodo { get; set; }
        public Int64 Id_Magnitud { get; set; }
        public String Nombre { get; set; }
        public String Modelo { get; set; }
        public String Serial { get; set; }
        public String Fabricante { get; set; }

        public DateTime? UltimaCalibracion { get; set; }
        public DateTime? ProximaCalibracion { get; set; }
        public DateTime? ProximaCalibracionSugerida { get; set; }
        public DateTime? UltimaVerificacion { get; set; }
        public DateTime? ProximaVerificacion { get; set; }

        public Int32 FrecuenciaCalibracion { get; set; }
        public Int32 FrecuenciaVerificacion { get; set; }

        public Decimal Limite { get; set; }
        public DateTime FechaIngreso { get; set; }
        public String Imagen { get; set; }
        public String Imagenant { get; set; }
        public String Url_azure_img { get; set; }
        public String Descripcion { get; set; }
        public String Observacion { get; set; }
        public DispositivoE Dispositivo { get; set; }
        public MagnitudE Magnitud { get; set; }
        public UnidadE Unidad { get; set; }
        public Int64 Id_Unidad_Limite { get; set; }
        public String Codigo { get; set; }
        public String Rango { get; set; }
        public Mensaje Mensaje { get; set; }
        public Int64 Id_Usuario { get; set; }
        public Boolean Estado { get; set; }
        public String Tipo { get; set; }
        public String Direccionamiento { get; set; }
        public String Tipo_aparato { get; set; }
        public Int32 Posicion { get; set; }
        public Int64 Orden { get; set; }
        public Boolean Parametro { get; set; }
        // public String Unidades { get; set; }
        // public String Sist_Unidades { get; set; }
    }
}
