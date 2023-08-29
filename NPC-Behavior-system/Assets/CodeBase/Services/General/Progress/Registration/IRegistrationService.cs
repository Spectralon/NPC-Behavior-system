using System.Collections.Generic;
using CodeBase.Services.General.Progress.Watchers;
using UnityEngine;

namespace CodeBase.Services.General.Progress.Registration
{
    public interface IRegistrationService
    {
        List<IProgressReader> ProgressReaders { get; }
        List<IProgressWriter> ProgressWriters { get; }

        void RegisterWatchers(GameObject gameObject);
        void UnregisterWatchers(GameObject gameObject);
        void CleanUp();
    }
}