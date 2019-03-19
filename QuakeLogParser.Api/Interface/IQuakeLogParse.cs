using QuakeLogParser.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuakeLogParser.Api.Contract
{
    interface IQuakeLogParse
    {
        Games RetornarGames(string arquivo);
        void ClientConnect(Game game, string linha);
        void ClientUserInfoChanged(Game game, string linha);
        void Kill(Game game, string linha);
        Game InitGame();
        void Salvar(Games games);
        ICollection<Game> GetGame();
    }
}
