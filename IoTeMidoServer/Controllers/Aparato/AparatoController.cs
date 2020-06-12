using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NEGOCIODLL.Aparato;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Net;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Net.Http.Headers;
using System.Net.Http;
using ENTIDADESDLL.Aparato;
using ENTIDADESDLL.Dispositivo;
using ENTIDADESDLL.Unidad;

namespace WebCoreGemesisII.Controllers.Aparato
{
    [Route("api/[controller]")]
    [ApiController]
    public class AparatoController : Controller
    {

        [HttpPost("GetAllAparatos")]
        public List<AparatoE> GetAllAparatos([FromBody] DispositivoE Dispositivo)
        {
            List<AparatoE> result = new List<AparatoE>();


            result = AparatoN.GetAllAparatos(new Object[] {
                new SqlParameter("@Accion","LOADALL"),
                new SqlParameter("@Tipo_aparato",Dispositivo.Tipo_disp),
                new SqlParameter("@Id_Nodo",Dispositivo.Id)
            });
            if (result.Count() > 0)
            {
                for (int i = 0; i< result.Count(); i++)
                {
                    this.UpdateOrdenAparato(result[i]);
                }
            }

            return result;
        }

        [HttpPost("GetAllAparatosMeca")]
        public List<AparatoE> GetAllAparatosMeca([FromBody] AparatoE Aparato)
        {
            List<AparatoE> result = new List<AparatoE>();


            result = AparatoN.GetAllAparatosMeca(new Object[] {
                new SqlParameter("@Accion","LOADALLMEC"),
                new SqlParameter("@Tipo_aparato",Aparato.Tipo_aparato),
                new SqlParameter("@Tipo",Aparato.Tipo),
                new SqlParameter("@Id_Nodo",Aparato.Id_Nodo)
            });

            return result;
        }


        [HttpPost("GetAllApaSensores")]
        public List<AparatoE> GetAllApaSensores([FromBody] AparatoE Aparato)
        {
            List<AparatoE> result = new List<AparatoE>();


            result = AparatoN.GetAllAparatosMeca(new Object[] {
                new SqlParameter("@Accion","LOADALLSEN"),
                new SqlParameter("@Tipo_aparato",Aparato.Tipo_aparato),
                new SqlParameter("@Id_Nodo",Aparato.Id_Nodo)
            });

            return result;
        }

        //Metodos para el grafico chart, hacer filtros para agregar parametros 
        [HttpPost("GetAllMagSensores")]
        public List<AparatoE> GetAllMagSensores([FromBody] AparatoE Aparato)
        {
            List<AparatoE> result = new List<AparatoE>();

            result = AparatoN.GetAllMagSensores(new Object[] {
                new SqlParameter("@Accion","LOADALLMAGXSEN"),
                new SqlParameter("@Id_Nodo",Aparato.Id_Nodo)
            });

            return result;
        }


        [HttpPost("GetAllUnidadXSen")]
        public List<UnidadE> GetAllUnidadXSen([FromBody] AparatoE Aparato)
        {
            List<UnidadE> result = new List<UnidadE>();

            result = AparatoN.GetAllUnidadXSen(new Object[] {
                new SqlParameter("@Accion","LOADALLUNIDADXSEN"),
                new SqlParameter("@Id_Nodo",Aparato.Id_Nodo),
                new SqlParameter("@Id_Magnitud",Aparato.Magnitud.Id)

            });

            return result;
        }

        [HttpPost("GetAllSensorXUnidad")]
        public List<AparatoE> GetAllSensorXUnidad([FromBody] AparatoE Aparato)
        {
            List<AparatoE> result = new List<AparatoE>();

            result = AparatoN.GetAllSensordXUnidad(new Object[] {
                new SqlParameter("@Accion","LOADALLSENXUNIDAD"),
                new SqlParameter("@Id_Nodo",Aparato.Id_Nodo),
                new SqlParameter("@Id_Unidad_Limite",Aparato.Id_Unidad_Limite)
            });

            return result;
        }
        //----

        [HttpPost("GetAparatos")]
        public List<AparatoE> GetAparatos([FromBody] AparatoE Aparato)
        {
            List<AparatoE> result = new List<AparatoE>();


            result = AparatoN.GetAparatos(new Object[] {
                new SqlParameter("@Accion","GetAparatos"),
                new SqlParameter("@Id_Magnitud",Aparato.Id_Magnitud),
                new SqlParameter("@Id_Nodo",Aparato.Id_Nodo)
            });

            return result;
        }

        

        [HttpGet] //Obtener Imágen
        public String VerImagen(String pathImg)
        {

            String path = "";
            path = pathImg;

            if (path != "" && path != null)
            {

                CloudStorageAccount storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=datossensores;AccountKey=x7W/PW86xtAuEJv+aOwyIYiG1dHC0+8EX3GP2ktC39B94ppau5PodjNvf+3NXsoG5/On6kJIQ9T2EtM5+HtAXA==");

                CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

                CloudBlobContainer container = blobClient.GetContainerReference("imagenaparatos");

                CloudBlockBlob blockBlob = container.GetBlockBlobReference(path);

                var sasConstraints = new SharedAccessBlobPolicy();
                sasConstraints.SharedAccessStartTime = DateTime.UtcNow.AddMinutes(-5);
                sasConstraints.SharedAccessExpiryTime = DateTime.UtcNow.AddMinutes(10);
                sasConstraints.Permissions = SharedAccessBlobPermissions.Read;

                var sasBlobToken = blockBlob.GetSharedAccessSignature(sasConstraints);
                path = blockBlob.Uri + sasBlobToken;

                HttpWebRequest request = WebRequest.Create(path) as HttpWebRequest;

                // ************ ADDED HERE
                // timeout the request after x milliseconds
                request.Timeout = 2000;
                // ************

                //Setting the Request method HEAD, you can also use GET too.
                request.Method = "HEAD";
                //Getting the Web Response.
                try
                {
                    HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                    var existe = (response.StatusCode == HttpStatusCode.OK);
                }
                catch (Exception e)
                {

                    return e.HResult.ToString();
                    throw;
                }

                //Returns TRUE if the Status code == 200


            }

            return path;
        }


        [HttpPost("GetAparato")]
        public AparatoE GetAparato([FromBody]  AparatoE Aparato)
        {
            AparatoE result = null;
            SqlParameter _accion = new SqlParameter("@Accion", "GetAparato");
            SqlParameter _id = new SqlParameter("@Id", Aparato.Id);

            Object[] Objeto = new Object[]
            {
                _accion,
                _id
            };

            result = AparatoN.GetAparato(Objeto);
            result.Url_azure_img = VerImagen(result.Imagen);
            // result.Imagen = result.Url_azure_img ;
          
            return result;
        }


        [HttpPost("InsertAparato")]
        public AparatoE InsertAparato([FromBody]  AparatoE Aparato)
        {
            AparatoE result = new AparatoE();


            result = AparatoN.SetAparato(new Object[] {
                new SqlParameter("@Accion", "INGRESAR"),
                new SqlParameter("@Estado", Aparato.Estado),
                new SqlParameter("@Id_Nodo", Aparato.Id_Nodo),
                new SqlParameter("@Id_Magnitud", Aparato.Id_Magnitud),
                new SqlParameter("@Id_Unidad_Limite", Aparato.Id_Unidad_Limite),
                new SqlParameter("@Nombre", Aparato.Nombre),
                new SqlParameter("@Modelo", Aparato.Modelo),
                new SqlParameter("@Serial", Aparato.Serial),
                new SqlParameter("@Fabricante", Aparato.Fabricante),
                new SqlParameter("@FechaIngreso", Aparato.FechaIngreso),
                new SqlParameter("@Codigo", Aparato.Codigo),
                new SqlParameter("@Descripcion", Aparato.Descripcion),
                new SqlParameter("@Observacion", Aparato.Observacion),
                new SqlParameter("@Id_Usuario", Aparato.Id_Usuario),
                new SqlParameter("@Tipo", Aparato.Tipo),
                new SqlParameter("@Direccionamiento", Aparato.Direccionamiento),
                new SqlParameter("@Tipo_aparato", Aparato.Tipo_aparato),
                new SqlParameter("@Imagen", Aparato.Imagen),
                new SqlParameter("@Parametro", Aparato.Parametro),




            });

           // if (result.Mensaje.Titulo == "")
           // {
           //     Aparato.Id = result.Mensaje.Id;

           //     ProgramaAparatoController programaAparato = new ProgramaAparatoController();

           //     programaAparato.SetInsertDetalleProgramaInstruemnto(Aparato);
           // }

            //   result.Url_azure_img = VerImagen(result.Imagen);
            return result;
        }


        [HttpPost("UpdatePosicionAparato")]
        public AparatoE UpdatePosicionAparato([FromBody]  AparatoE Aparato)
        {
            AparatoE result = new AparatoE();


            result = AparatoN.SetUpdatePosicion(new Object[] {
                new SqlParameter("@Accion", "UPDATEPOSICION"),
                new SqlParameter("@Id", Aparato.Id),
                new SqlParameter("@Posicion", Aparato.Posicion)

            });

            return result;
        }

        //[HttpPost] //Obtener Aparato
        //[Produces("application/json")]
        //[Route("api/Aparato/UpdateOrdenAparato")]
        public AparatoE UpdateOrdenAparato([FromBody]  AparatoE Aparato)
        {
            AparatoE result = new AparatoE();


            result = AparatoN.SetUpdatePosicion(new Object[] {
                new SqlParameter("@Accion", "UPDATEORDEN"),
                new SqlParameter("@Id", Aparato.Id),
                new SqlParameter("@Orden", Aparato.Orden)

            });

            return result;
        }


        [HttpPost("UpdateAparato")]
        public AparatoE UpdateAparato([FromBody]  AparatoE Aparato)
        {
            AparatoE result = new AparatoE();


            result = AparatoN.SetAparato(new Object[] {
                new SqlParameter("@Accion", "ACTUALIZAR"),
                new SqlParameter("@Id", Aparato.Id),
                new SqlParameter("@Estado", Aparato.Estado),
                new SqlParameter("@Id_Nodo", Aparato.Id_Nodo),
                new SqlParameter("@Id_Magnitud", Aparato.Id_Magnitud),
                new SqlParameter("@Id_Unidad_Limite", Aparato.Id_Unidad_Limite),
                new SqlParameter("@Nombre", Aparato.Nombre),
                new SqlParameter("@Modelo", Aparato.Modelo),
                new SqlParameter("@Serial", Aparato.Serial),
                new SqlParameter("@Fabricante", Aparato.Fabricante),
                new SqlParameter("@FechaIngreso", Aparato.FechaIngreso),
                new SqlParameter("@Codigo", Aparato.Codigo),
                new SqlParameter("@Descripcion", Aparato.Descripcion),
                new SqlParameter("@Observacion", Aparato.Observacion),
                new SqlParameter("@Id_Usuario", Aparato.Id_Usuario),
                new SqlParameter("@Tipo", Aparato.Tipo),
                new SqlParameter("@Direccionamiento", Aparato.Direccionamiento),
                new SqlParameter("@Tipo_aparato", Aparato.Tipo_aparato),
                //new SqlParameter("@Imagen", Aparato.Imagen),
                new SqlParameter("@Parametro", Aparato.Parametro),


            });
            //   result.Url_azure_img = VerImagen(result.Imagen);
            return result;
        }


        [HttpPost("DeleteAparato")]
        public AparatoE DeleteAparato([FromBody]  AparatoE aparato)
        {
            AparatoE result = null;
            SqlParameter _accion = new SqlParameter("@Accion", "ELIMINAR");
            SqlParameter _id = new SqlParameter("@Id", aparato.Id);

            Object[] Objeto = new Object[]
            {
                _accion,
                _id
            };

            result = AparatoN.DeleteAparato(Objeto);
            if (result.Mensaje.Titulo == "")
            {
                if (aparato.Imagenant != null)
                {
                    DeleteFromBlob(aparato.Imagenant);
                }
            }

            return result;
        }


        [HttpPost("SetUpdateImageAparato")]
        public AparatoE SetUpdateImageAparato([FromBody]  AparatoE Aparato)
        {
            AparatoE result = new AparatoE();
            result = AparatoN.SetAparato(new Object[] {
                 new SqlParameter("@Accion", "ACTUALIZARIMAGEN"),
                 new SqlParameter("@Id", Aparato.Id),
                 new SqlParameter("@Imagen", Aparato.Imagen),
                 new SqlParameter("@Id_Usuario", Aparato.Id_Usuario)
            });
            if (Aparato.Imagenant != null)
            {
                DeleteFromBlob(Aparato.Imagenant);
            }
            


            return result;
        }

        public void DeleteFromBlob(string filename)
        {
            // Retrieve storage account from connection string.
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=datossensores;AccountKey=x7W/PW86xtAuEJv+aOwyIYiG1dHC0+8EX3GP2ktC39B94ppau5PodjNvf+3NXsoG5/On6kJIQ9T2EtM5+HtAXA==");

            // Create the blob client.
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            // Retrieve reference to a previously created container.
            CloudBlobContainer container = blobClient.GetContainerReference("imagenaparatos");

            // Retrieve reference to a blob named "myblob.csv".
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(filename);

            // Delete the blob.
            blockBlob.DeleteAsync();
        }



    }


    [Produces("application/json")]
    [Route("api/Aparato/IngresarImagen")]
    public class IngresarImagenController : Controller
    {
        private IHostingEnvironment _hostingEnvironment;

        public IngresarImagenController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpPost, DisableRequestSizeLimit]
        public async Task<String> IngresarImagen()
        {


            try
            {


                IFormFile file = Request.Form.Files[0];





                var path = "";
                 string folderName = "Upload";
                 string webRootPath = _hostingEnvironment.ContentRootPath;
                 string newPath = Path.Combine(webRootPath, folderName);
               // if (!Directory.Exists(newPath))
               // {
               //     Directory.CreateDirectory(newPath);
               // }
                if (file.Length > 0)
                {





                    CloudStorageAccount storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=datossensores;AccountKey=x7W/PW86xtAuEJv+aOwyIYiG1dHC0+8EX3GP2ktC39B94ppau5PodjNvf+3NXsoG5/On6kJIQ9T2EtM5+HtAXA==");
                    // Create the blob client.                                      
                    CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

                    // Retrieve a reference to a container.
                    CloudBlobContainer container = blobClient.GetContainerReference("imagenaparatos");

                    // Create the container if it doesn't already exist.
                    await container.CreateIfNotExistsAsync();

                    string fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    string fullPath = Path.Combine(newPath, fileName);

                    path = file.Name.Replace(".", "") + "(" + DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year + "-" + DateTime.Now.TimeOfDay.Ticks + ")" + Path.GetExtension(fullPath);
                    //var blob = container.GetBlockBlobReference(fileName);
                    //blob.DeleteIfExistsAsync();
                    CloudBlockBlob blockBlob = container.GetBlockBlobReference(path);
           
                    //using (var stream = new FileStream(fullPath, FileMode.Create))
                    //{
                    //    file.CopyTo(stream);

                    //}

                    using (Stream fileStream = file.OpenReadStream())
                    {

                        await blockBlob.UploadFromStreamAsync(fileStream);
                    }







                    // Create or overwrite the "myblob" blob with contents from a local file.
                    //using (var fileStream = file1.OpenRead())
                    //{


                    //}

                    //string fullPath = Path.Combine(newPath, fileName);
                    //using (var stream = new FileStream(fullPath, FileMode.Create))
                    //{



                    //    file.CopyTo(stream);
                    //}



                    HttpResponseMessage respuesta = new HttpResponseMessage(HttpStatusCode.OK);


                    respuesta.RequestMessage = new HttpRequestMessage();

                    respuesta.Headers.Add("data", path);

                    respuesta.RequestMessage.Content = new StringContent(path);
                    return path;


                }
                else
                {

                    return "Sin Imagen";
                }

            }
            catch (System.Exception ex)
            {
                var mensjae = ex.Message;
                return "Sin Imagen";
            }
        }
    }



}