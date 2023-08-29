using Random = UnityEngine.Random;

namespace CodeBase.Services.General.Randomizer
{
    public class RandomService : IRandomService
    {
        public int Next(int min, int max) =>
            Random.Range(min, max);
    }
}