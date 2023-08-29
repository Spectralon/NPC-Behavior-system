using CodeBase.Data;

namespace CodeBase.Services.General.SaveLoad
{
    public interface ISaveLoadService
    {
        void SaveProgress();
        OverallProgress LoadProgress();
    }
}