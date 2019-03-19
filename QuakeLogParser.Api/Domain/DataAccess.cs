using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;


namespace QuakeLogParser.Api.Models
{
    public class DataAccess
    {
        private QuakeLogParserContext db = new QuakeLogParserContext();

        public void SaveGame(Games games)
        {
            try
            {
                foreach (Game game in games.ListGames)
                {
                    db.Games.Add(game);
                }

                db.SaveChanges();
            }
            catch (Exception ex)
            {

            }
        }

        public ICollection<Game> GetGames()
        {
            return db.Games.Include(m => m.Players).Include(m => m.Kills).ToList();
        }
    }
}