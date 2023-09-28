using PlayerVsMonster.Utilities;

namespace PlayerVsMonster.Services
{
    public class DeterminedRandomService : IRandomService
    {
        public int Next(IntRange range)
        {
            return range.End-1;
        }
    }
}