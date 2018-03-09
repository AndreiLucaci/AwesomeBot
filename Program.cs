using AwesomeBot.Bot;

namespace LightRidersBot
{
    class Program
    {
        static void Main(string[] args)
        {
            BotParser parser = new BotParser(new AwesomeBot.Bot.AwesomeBot());
            parser.Run();
        }
    }
}
