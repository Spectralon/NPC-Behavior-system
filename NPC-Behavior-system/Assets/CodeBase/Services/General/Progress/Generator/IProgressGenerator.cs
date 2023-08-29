using CodeBase.Data;

namespace CodeBase.Services.General.Progress.Generator
{
    public interface IProgressGenerator
    {
        OverallProgress GenerateNewProgress();
    }
}