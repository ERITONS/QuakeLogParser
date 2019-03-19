using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuakeLogParser.Api.Models
{
    public class Kill
    {   
      
        public int KillID { get; set; }
        public Player Player { get; set; }
        public int Kills { get; set; }

        public Kill()
        {
            this.Player = new Player();
            this.Kills = 0;
        }
    }
}
