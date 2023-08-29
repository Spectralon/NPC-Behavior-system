using System;

namespace CodeBase.Infrastructure.Loader
{
    public interface ISceneLoader
    {
        void Load(string sceneName, Action onLoaded = null);
    }
}