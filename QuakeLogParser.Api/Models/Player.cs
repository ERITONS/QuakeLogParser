using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuakeLogParser.Api.Models
{
    public class Player
    {
        public int PlayerID { get; set; }
        public string Nome { get; set; }

        public Player()
        {
            this.PlayerID = 0;
            this.Nome = String.Empty;
        }
    }
}