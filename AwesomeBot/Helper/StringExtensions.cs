using AwesomeBot.Bot;

namespace AwesomeBot.Helper
{
    public static class StringExtensions
    {
        public static bool Free(this string value)
        {
            return value == BotConstants.Free;
        }
    }
}
