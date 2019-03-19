using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuakeLogParser.Api.Models;
using System.Net.Http;
using System.Net.Http.Headers;

namespace QuakeLogParser.UI.Controllers
{
    public class UploadFileController : Controller
    {
        // GET: Home
        public ActionResult UploadFile()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadFile (HttpPostedFileBase postedFile)
        {
            string filePath = string.Empty;
            if (postedFile != null)
            {
                string path = Server.MapPath(@"~/Uploads/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                filePath = path + Path.GetFileName(postedFile.FileName);
                string extension = Path.GetExtension(postedFile.FileName);
                postedFile.SaveAs(filePath);

                Arquivo arquivo = new Arquivo();
                //Leitura do arquivo de log
                arquivo.Dados = System.IO.File.ReadAllText(filePath);

                HttpClient client = new HttpClient();

                client.BaseAddress = new Uri("http://localhost:51508/api/Arquivo/ImportarArquivo");

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.PostAsJsonAsync("arquivo", arquivo).Result;

                if (response.IsSuccessStatusCode)
                {
                    return View("Success");
                }
                else
                {
                    return View("BadResult");
                }   
                    

            }
            else {

                return View("BadResult");
            }

          

            
        }

    }
}
