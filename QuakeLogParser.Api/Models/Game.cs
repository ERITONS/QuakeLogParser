using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuakeLogParser.Api.Models
{
    public class Game
    {
        public int GameID { get; set; }
        public int TotalKills { get; set; }
        public List<Player> Players { get; set; }
        public List<Kill> Kills { get; set; }
        public List<World> World { get; set; }

        public Game()
        {
            this.TotalKills = 0;
            this.Players = new List<Player>();
            this.Kills = new List<Kill>();
            this.World = new List<World>();
        }
    }
}
