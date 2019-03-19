using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuakeLogParser.Api.Models
{
    public class Games
    {
        public List<Game> ListGames { get; set; }

        public Games()
        {
            this.ListGames = new List<Game>();
        }
    }
}