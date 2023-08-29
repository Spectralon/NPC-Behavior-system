using System;

namespace CodeBase.Services.General.CustomLogger
{
    public interface ILogger
    {
        void LogInfo(string message);
        void LogError(string errorMessage);
        void LogException(Exception exception);
    }
}