using PlayerVsMonster.Utilities;

namespace PlayerVsMonster.Services
{
    public interface IRandomService
    {
        int Next(IntRange range);
    }
}