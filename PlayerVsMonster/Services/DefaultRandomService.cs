using PlayerVsMonster.Utilities;

namespace PlayerVsMonster.Services
{
    public class DefaultRandomService : IRandomService
    {
        public int Next(IntRange range)
        {
            var random = new System.Random();
            return random.Next(range.Start, range.End);
        }
    }
}