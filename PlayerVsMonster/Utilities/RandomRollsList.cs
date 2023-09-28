using System.Collections.Generic;
using PlayerVsMonster.Services;

namespace PlayerVsMonster.Utilities
{
    public static class RandomRollsList
    {
        public static IEnumerable<int> GenerateRandomRolls(int generateElementsCount, IRandomService randomService)
        {
            for (int i = 0; i < generateElementsCount; i++)
            {
                yield return randomService.Next(new IntRange(0, 7));
            }
        }
    }
}