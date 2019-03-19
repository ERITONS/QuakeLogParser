using QuakeLogParser.Api.Business;
using QuakeLogParser.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace QuakeLogParser.Api.Controllers
{
    public class ArquivoController : ApiController
    {
        private QuakeLogParse logParse = new QuakeLogParse();

        [ResponseType(typeof(Game))]
        public IHttpActionResult ImportarArquivo(Arquivo arquivo)
        {
            try
            {
                var games = logParse.RetornarGames(arquivo.Dados);
                logParse.Salvar(games);

                return Ok(games);
            }
            catch (Exception ex)
            {
                return Conflict();
            }
        }

        // GET: api/Games
        public ICollection<Game> GetGames()
        {
            return logParse.GetGame();
        }
    }
}
