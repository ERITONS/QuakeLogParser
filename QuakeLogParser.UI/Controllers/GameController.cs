using QuakeLogParser.Api.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace QuakeLogParser.UI.Controllers
{
    public class GameController : Controller
    {
        // GET: Game
        public ActionResult GetGame()
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("http://localhost:51508/api/Arquivo/GetGames");

            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("Game").Result;

            var games = response.Content.ReadAsAsync<IEnumerable<Game>>().Result;
            if (response.IsSuccessStatusCode)
            {
                
                return View(games);
            }
            else
            {
                string message = response.StatusCode + response.ReasonPhrase.ToString();
                ViewBag.Message = message;
                return View();
            }

            


            
        }
    }
}