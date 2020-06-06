using System;
using System.Collections.Generic;

namespace MENSAJESDLL
{
    public enum TipoMensaje
    {
        Informacion,
        Advertencia,
        Error,
        CondicionSINO
    }

    public enum Tema
    {
        primary,
        accent,
        warn
    }

    public class Botones
    {
        public String Label { get; set; }
        // public Tema Tema { get; set; }
        public bool Visible { get; set; }
    }


    public class Mensaje
    {
        public Int64 Id { get; set; }
        public String Titulo { get; set; }
        public String Cuerpo { get; set; }
        public String Pie { get; set; }
        public TipoMensaje Tipo { get; set; }
        public string NVentana { get; set; }

        public List<Botones> Botones { get; set; }



        public Mensaje()
        {

        }


        public Mensaje(Int64 id, String titulo, String cuerpo, String pie = "", TipoMensaje tipo = TipoMensaje.Advertencia, string nVentana = "idVentana")
        {
            Id = id;
            Titulo = titulo;
            Cuerpo = cuerpo;
            Pie = pie;
            Tipo = tipo;
            Botones = new List<Botones>();
            NVentana = nVentana;

            switch (tipo)
            {
                case TipoMensaje.Informacion:

                    Botones.Add(new Botones { Label = "Aceptar", Visible = true });
                    Botones.Add(new Botones { Label = "Cancelar", Visible = false });
                    break;
                case TipoMensaje.Advertencia:
                    Botones.Add(new Botones { Label = "Aceptar", Visible = true });
                    Botones.Add(new Botones { Label = "Cancelar", Visible = false });
                    break;
                case TipoMensaje.Error:
                    Botones.Add(new Botones { Label = "Aceptar", Visible = true });
                    Botones.Add(new Botones { Label = "Cancelar", Visible = false });
                    break;
                case TipoMensaje.CondicionSINO:
                    Botones.Add(new Botones { Label = "SI", Visible = true });
                    Botones.Add(new Botones { Label = "NO", Visible = true });
                    break;
                default:
                    break;
            }
        }
    }
}
