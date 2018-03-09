using AwesomeBot.Bot;
using AwesomeBot.Field;
using NUnit.Framework;

namespace AwesomeBot.Tests
{
    [TestFixture]
    public class BotTests
    {
        public const string End =
                ".,.,.,.,.,.,.,0,.,.,.,.,.,.,.,.,.,.,.,.,.,.,.,x,.,.,.,.,.,.,.,.,.,.,.,.,.,.,.,x,.,.,.,.,.,.,.,.,.,.,.,.,.,.,.,x,.,.,.,.,.,.,.,.,.,.,.,.,.,.,.,x,.,.,.,.,.,.,.,.,.,.,.,.,.,.,.,x,.,.,.,.,.,.,.,.,.,.,.,.,.,.,.,x,.,x,x,x,x,x,x,x,.,.,.,.,.,.,x,x,.,x,.,x,x,x,x,x,.,x,x,x,x,x,x,x,.,.,.,x,x,x,x,x,.,x,x,x,x,x,x,x,.,.,.,x,x,x,x,x,.,x,x,x,x,x,x,.,.,.,1,x,x,x,x,x,.,x,x,x,x,x,x,.,.,.,x,x,x,x,x,x,.,x,x,x,x,x,x,.,.,.,x,x,x,x,x,x,.,x,x,x,x,x,x,.,.,.,x,x,x,x,x,x,.,x,x,x,x,x,x,.,.,.,x,x,x,x,x,x,.,x,x,x,x,x,x,.,.,.,x,x,x,x,x,x"
            ;

        [Test]
        public void Test_Bot_Test()
        {
            var board = new Board
            {
                Width = 16,
                Height = 16
            };

            board.InitField();
            board.ParseFromString(End);

            var bot = new Bot.AwesomeBot();

            var move = bot.MoveBot(new BotState {Board = board});
        }
    }
}
