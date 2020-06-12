using ENTIDADESDLL.Aparato;
using ENTIDADESDLL.Dashboard;
using MENSAJESDLL;
using System;
using System.Collections.Generic;
using System.Text;

namespace ENTIDADESDLL.Grafico
{
    public class GraficoE
    {
        public Int64 Id { get; set; }
        public DashboardE Dashboard { get; set; }
        public AparatoE Aparato { get; set; }
        public string Titulo { get; set; }
        public string Tipo { get; set; }
        public double Maximo { get; set; }
        public double Minimo { get; set; }
        // public Int64 Orden { get; set; }
        public double UmbralMax { get; set; }
        public double UmbralMin { get; set; }
        public double Resolucion { get; set; }
        public Int32 Valor { get; set; }
        public string UnidadTiempo { get; set; }
        public string Serie { get; set; }
        public string Color { get; set; }
        public Int32 Semana { get; set; }
        public Mensaje Mensaje { get; set; }
        public List<AparatoE> listaSensor { get; set; }
    }

    public class MensajePosicion
    {
        public string ID { get; set; }
        public List<int> DATA { get; set; }
    }
    public class MensajeClaves
    {
        public string ID { get; set; }
        public List<Valores> DATA { get; set; }
    }

    public class Valores
    {
        int posicion { get; set; }
        int valor { get; set; }
    }
}
