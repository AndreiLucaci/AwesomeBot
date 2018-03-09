using System.Collections.Generic;
using AwesomeBot.Field;

namespace AwesomeBot.Bot
{
    public class BotState
    {
        public int MaxTimebank { get; set; }
        public int TimePerMove { get; set; }
        public int MaxRounds { get; set; }
        public int RoundNumber { get; set; }
        public int Timebank { get; set; }
        public string MyName { get; set; }

        public Dictionary<string, LightRidersBot.Player.Player> Players { get; set; }
        public Board Board { get; set; }

        public BotState()
        {
            Board = new Board();
            Players = new Dictionary<string, LightRidersBot.Player.Player>();
        }
    }
}
