using MENSAJESDLL;
using System;
using System.Collections.Generic;
using System.Text;

namespace ENTIDADESDDL.Lista
{
    public class ListaE
    {
        private Int64 id;
        private String idString;
        private String nombre;
        private Double? numero1;
        private List<ListaE> lista;
        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public Int64 Id
        {
            get { return id; }
            set { id = value; }
        }

        public String IdString
        {
            get { return idString; }
            set { idString = value; }
        }

        public Double? Numero1
        {
            get { return numero1; }
            set { numero1 = value; }
        }

        public List<ListaE> Listas
        {
            get { return lista; }
            set { lista = value; }
        }


        public Mensaje Mensaje { get; set; }
    }
}
