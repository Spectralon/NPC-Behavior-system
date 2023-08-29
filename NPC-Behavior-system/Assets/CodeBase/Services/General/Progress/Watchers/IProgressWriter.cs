using CodeBase.Data;

namespace CodeBase.Services.General.Progress.Watchers
{
    public interface IProgressWriter : IProgressReader
    {
        void WriteProgress(OverallProgress progress);
    }
}