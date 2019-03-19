using QuakeLogParser.Api.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuakeLogParser.Api.Models;
using System.Text.RegularExpressions;
using System.IO;
using System.Text;
using QuakeLogParser.Api.Models.Enum;

namespace QuakeLogParser.Api.Business
{
    public class QuakeLogParse : IQuakeLogParse
    {
        private Regex regexAction = new Regex("(InitGame|ClientConnect|ClientUserinfoChanged|Kill)");
        private Regex regexPlayer = new Regex(@"(\d)[^\d]*$");
        private const int WORLD_ID = 1022;
        private DataAccess data = new DataAccess();

        public Games RetornarGames(string arquivo)
        {
            try
            {
                Game game = new Game();
                Games games = new Games();

                StringReader sr = new StringReader(arquivo);
                while (true)
                {
                    string linha = sr.ReadLine();

                    if (linha != null)
                    {
                        Match action = regexAction.Match(linha);
                        switch (action.Value)
                        {

                            case "InitGame":
                                game = InitGame();
                                games.ListGames.Add(game);
                                break;

                            case "ClientConnect":
                                ClientConnect(game, linha);
                                break;

                            case "ClientUserinfoChanged":
                                ClientUserInfoChanged(game, linha);
                                break;

                            case "Kill":
                                Kill(game, linha);
                                break;

                            default:
                                break;
                        }
                    }
                    else
                    {
                        break;
                    }
                }

                return games;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void ClientConnect(Game game, string linha)
        {
            MatchCollection info = regexPlayer.Matches(linha);

            //Recupera informações da linha
            int id = Int32.Parse(info[0].Value);

            //Adiciona um novo jogador, se já não existir
            if (!game.Players.Any(p => p.PlayerID == id))
            {
                game.Players.Add(new Player { PlayerID = id });
            }
        }

        public void ClientUserInfoChanged(Game game, string linha)
        {
            int id = Int32.Parse(linha.Substring(linha.IndexOf(": ") + 2, 1).Trim());
            string nomeJogador = linha.Substring(linha.IndexOf(@"n\") + 2);
            string nome = nomeJogador.Substring(0, nomeJogador.IndexOf(@"\"));


            game.Players.Find(p => p.PlayerID == id).Nome = nome;
        }

        public void Kill(Game game, string linha)
        {

            string informacoes = linha.Substring(linha.IndexOf(": ") + 2);
            informacoes = informacoes.Substring(0, informacoes.IndexOf(":"));
            string[] info = informacoes.Split(' ');

            Player killer = game.Players.Any(q => q.PlayerID == Int32.Parse(info[0])) ? game.Players.Find(p => p.PlayerID == Int32.Parse(info[0])) : new Player { PlayerID = Int32.Parse(info[0]) };
            Player killed = game.Players.Find(p => p.PlayerID == Int32.Parse(info[1]));
            EMeansOfDeath mean = (EMeansOfDeath)Int32.Parse(info[2]);


            game.TotalKills++;

            if (killer.PlayerID == WORLD_ID)
            {

                if (game.Kills.Any(p => p.Player.PlayerID == killed.PlayerID))
                {
                    if (game.Kills.Find(k => k.Player.PlayerID == killed.PlayerID).Kills > 0)
                    {
                        game.Kills.Find(k => k.Player.PlayerID == killed.PlayerID).Kills--;
                    }
                }
            }
            else
            {

                if (game.Kills.Any(p => p.Player.PlayerID == killer.PlayerID))
                {
                    game.Kills.Find(k => k.Player.PlayerID == killer.PlayerID).Kills++;
                }
                else
                {
                    game.Kills.Add(new Kill { Player = killer, Kills = 1 });
                }
            }


            if (game.World.Any(k => k.Mean == mean))
            {
                game.World.Find(k => k.Mean == mean).Numero++;
            }
            else
            {
                game.World.Add(new World { Mean = mean, Numero = 1 });
            }
        }

        public Game InitGame()
        {
            return new Game();
        }

        public void Salvar(Games games)
        {
            try
            {
                data.SaveGame(games);
            }
            catch (Exception)
            {

            }
        }

        public ICollection<Game> GetGame()
        {
            try
            {
                var games = data.GetGames();
                return games;
            }
            finally
            {

            }
        }
    }
}

