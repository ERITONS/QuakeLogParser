using QuakeLogParser.Api.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuakeLogParser.Api.Models
{
    public class World
    {
        public int WorldID { get;set; }
        public EMeansOfDeath Mean { get; set; }
        public int Numero { get; set; }

        public World()
        {

        }
    }
}