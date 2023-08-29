namespace CodeBase.Services.General.Randomizer
{
    public interface IRandomService
    {
        int Next(int minValue, int maxValue);
    }
}