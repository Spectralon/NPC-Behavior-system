using CodeBase.Data;

namespace CodeBase.Services.General.Progress.Service
{
    public interface IProgressService
    {
        OverallProgress OverallProgress { get; set; }
    }
}