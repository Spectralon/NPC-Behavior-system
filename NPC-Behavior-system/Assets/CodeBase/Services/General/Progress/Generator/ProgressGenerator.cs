using CodeBase.Data;

namespace CodeBase.Services.General.Progress.Generator
{
    public class ProgressGenerator : IProgressGenerator
    { 
        public OverallProgress GenerateNewProgress() => new ();
    }
}