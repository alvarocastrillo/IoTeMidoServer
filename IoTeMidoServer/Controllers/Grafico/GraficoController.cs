using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ENTIDADESDLL.Aparato;
using ENTIDADESDLL.Grafico;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NEGOCIODLL.Grafico;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WebCoreGemesisII.Controllers.Grafico
{
    [Route("api/[controller]")]
    [ApiController]
    public class GraficoController : Controller
    {
        //LISTA TODO LOS GRÁFICOS CREADOS DE LOS APARATOS EJM SENSORES Y ACTUADORES
        //[Produces("application/json")]
        //[Route("api/Grafico/GetGraficoLista/{id_dash:int}")]
        [HttpGet("GetGraficoLista/{id_dash:int}")]
        public List<GraficoE> GetGraficoLista(int id_dash)
        {
            List<GraficoE> result = new List<GraficoE>();

            result = GraficoN.GetGraficoLista(new Object[] {
                new SqlParameter("@Accion","GETLIST"),
                new SqlParameter("@Id_dashboard", id_dash)
            });

            List<GraficoE> resultAuxGraficosIguales = new List<GraficoE>();
            List<GraficoE> resultGroup = new List<GraficoE>();
            List<AparatoE> listaAparato = new List<AparatoE>();
            Int64 idGrafAux = 0;
            Int64 idGrafActual;
            foreach (GraficoE graficoApa in result)
            {
                // LOS GRÁFICOS CHART QUE TIENE APARATOS DE TIPO SENSOR SE LE AGREGA UN ATRIBUTO, QUE SON LISTA DE SENSOR
                if (graficoApa.Tipo == "CHART" || graficoApa.Tipo == "CHARTSEM")
                {
                    idGrafActual = graficoApa.Id;
                    if(idGrafActual != idGrafAux)
                    {
                        resultAuxGraficosIguales = result.FindAll(x => x.Id == idGrafActual);
                        foreach (GraficoE grafico in resultAuxGraficosIguales)
                        {
                            listaAparato.Add(grafico.Aparato);
                        }
                        graficoApa.listaSensor = listaAparato;
                        resultGroup.Add(graficoApa);
                        idGrafAux = idGrafActual;
                        listaAparato = new List<AparatoE>();
                    }
                    
                } 
                else
                {
                    resultGroup.Add(graficoApa);
                }
                
            }

            return resultGroup;
        }


        //[Produces("application/json")]
        //[Route("api/Grafico/GetRegistroGraf/{id_dash:int}")]
        [HttpGet("GetRegistroGraf/{id_dash:int}")]
        public List<GraficoE> GetRegistroGraf(int id_dash)
        {
            List<GraficoE> result = new List<GraficoE>();


            result = GraficoN.GetRegistroGraf(new Object[] {
                new SqlParameter("@Accion","GETLIST"),
                new SqlParameter("@Id_dashboard", id_dash)
            });

            return result;
        }


        [HttpPost("GetGrafico")]
        public GraficoE GetGrafico([FromBody]  GraficoE Grafico)
        {
            GraficoE result = null;
            SqlParameter _accion = new SqlParameter("@Accion", "GETID");
            SqlParameter _id = new SqlParameter("@Id", Grafico.Id);

            Object[] Objeto = new Object[]
            {
                _accion,
                _id
            };


            result = GraficoN.GetGrafico(Objeto);
            return result;
        }


        [HttpPost("InsertGrafico")]//INSERTAR GRÁFICO DIFERENTE DE CHART
        public GraficoE InsertGrafico([FromBody]  GraficoE Grafico)
        {
            GraficoE result = new GraficoE();

                result = GraficoN.SetGrafico(new Object[] {
                new SqlParameter("@Accion", "INGRESAR"),
                new SqlParameter("@Id_dashboard", Grafico.Dashboard.Id),
                new SqlParameter("@Id_apa", Grafico.Aparato.Id),
                new SqlParameter("@Titulo", Grafico.Titulo),
                new SqlParameter("@Tipo", Grafico.Tipo),
                new SqlParameter("@Minimo", Grafico.Minimo),
                new SqlParameter("@Maximo", Grafico.Maximo),
                new SqlParameter("@UmbralMax", Grafico.UmbralMax),
                new SqlParameter("@UmbralMin", Grafico.UmbralMin),
                new SqlParameter("@Resolucion", Grafico.Resolucion),
                new SqlParameter("@Valor", Grafico.Valor),
                new SqlParameter("@UnidadTiempo", Grafico.UnidadTiempo),
                new SqlParameter("@Semana", Grafico.Semana),

            });
            GraficoE resultGrafApa = new GraficoE();
            if (Grafico.Tipo == "CHART" || Grafico.Tipo == "CHARTSEM")
            {
                foreach (AparatoE sensor in Grafico.listaSensor)
                {
                    resultGrafApa = GraficoN.SetGrafico(new Object[] {
                        new SqlParameter("@Accion", "INGGRAAPA"),
                        new SqlParameter("@Id", result.Mensaje.Id), // ID DEL NUEVO GRÁFICO CREADO
                        new SqlParameter("@Id_apa", sensor.Id),
                    });
                }
                result = resultGrafApa;
            }

        
            return result;
        }


        [HttpPost("InsertGraficoChart")]//INSERTAR GRÁFICO CHART
        public GraficoE InsertGraficoChart([FromBody]  GraficoE Grafico)
        {
            GraficoE result = new GraficoE();

            result = GraficoN.SetGrafico(new Object[] {
                new SqlParameter("@Accion", "INGRESAR"),
                new SqlParameter("@Id_dashboard", Grafico.Dashboard.Id),
                new SqlParameter("@Id_apa", Grafico.Aparato.Id),
                new SqlParameter("@Titulo", Grafico.Titulo),
                new SqlParameter("@Tipo", Grafico.Tipo),
                new SqlParameter("@Minimo", Grafico.Minimo),
                new SqlParameter("@Maximo", Grafico.Maximo),
                new SqlParameter("@UmbralMax", Grafico.UmbralMax),
                new SqlParameter("@UmbralMin", Grafico.UmbralMin),
                new SqlParameter("@Resolucion", Grafico.Resolucion),
                new SqlParameter("@Valor", Grafico.Valor),
                new SqlParameter("@UnidadTiempo", Grafico.UnidadTiempo),
                new SqlParameter("@Semana", Grafico.Semana),

            });


            return result;
        }


        [HttpPost("EditarGrafico")]
        public GraficoE UpdateGrafico([FromBody]  GraficoE Grafico)
        {
            GraficoE result = new GraficoE();

                result = GraficoN.SetGrafico(new Object[] {
                    new SqlParameter("@Accion", "ACTUALIZAR"),
                    new SqlParameter("@Id", Grafico.Id),
                    new SqlParameter("@Id_apa", Grafico.Aparato.Id),
                    new SqlParameter("@Titulo", Grafico.Titulo),
                    new SqlParameter("@Tipo", Grafico.Tipo),
                    new SqlParameter("@Minimo", Grafico.Minimo),
                    new SqlParameter("@Maximo", Grafico.Maximo),
                    new SqlParameter("@UmbralMax", Grafico.UmbralMax),
                    new SqlParameter("@UmbralMin", Grafico.UmbralMin),
                    new SqlParameter("@Resolucion", Grafico.Resolucion),
                    new SqlParameter("@Valor", Grafico.Valor),
                    new SqlParameter("@UnidadTiempo", Grafico.UnidadTiempo),
                    new SqlParameter("@Semana", Grafico.Semana),
                    // new SqlParameter("@Orden", Grafico.Orden),

                });

            //}
            GraficoE resultGrafApa = new GraficoE();
            if (Grafico.Tipo == "CHART" || Grafico.Tipo == "CHARTSEM")
            {
                foreach (AparatoE sensor in Grafico.listaSensor)
                {
                    resultGrafApa = GraficoN.SetGrafico(new Object[] {
                        new SqlParameter("@Accion", "INGGRAAPA"),
                        new SqlParameter("@Id", Grafico.Id), // ID DEL NUEVO GRÁFICO CREADO
                        new SqlParameter("@Id_apa", sensor.Id),
                    });
                }
                result = resultGrafApa;
            }

            return result;
        }


        [HttpPost("EditarGrafSerie")]
        public GraficoE UpdateGraficoSerie([FromBody]  GraficoE Grafico)
        {
            GraficoE result = new GraficoE();


            result = GraficoN.SetGrafico(new Object[] {
                new SqlParameter("@Accion", "UPSERIE"),
                new SqlParameter("@Id", Grafico.Id),
                new SqlParameter("@Serie", Grafico.Serie),

            });
            return result;
        }


        [HttpPost("EditarGrafColor")]
        public GraficoE UpdateGraficoColor([FromBody]  GraficoE Grafico)
        {
            GraficoE result = new GraficoE();


            result = GraficoN.SetGrafico(new Object[] {
                new SqlParameter("@Accion", "UPCOLOR"),
                new SqlParameter("@Id", Grafico.Id),
                new SqlParameter("@Color", Grafico.Color),

            });
            return result;
        }


        [HttpPost("DeleteGrafico")]
        public GraficoE DeleteGrafico([FromBody]  GraficoE Grafico)
        {
            GraficoE result = null;
            SqlParameter _accion = new SqlParameter("@Accion", "ELIMINAR");
            SqlParameter _id = new SqlParameter("@Id", Grafico.Id);

            Object[] Objeto = new Object[]
            {
                _accion,
                _id
            };

            result = GraficoN.DeleteGrafico(Objeto);
            return result;
        }
    }
}