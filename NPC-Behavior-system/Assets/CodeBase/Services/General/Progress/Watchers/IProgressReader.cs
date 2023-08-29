using CodeBase.Data;

namespace CodeBase.Services.General.Progress.Watchers
{
    public interface IProgressReader
    {
        void ReadProgress(OverallProgress progress);
    }
}