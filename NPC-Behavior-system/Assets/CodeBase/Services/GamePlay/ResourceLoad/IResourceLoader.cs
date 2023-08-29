using UnityEngine;

namespace CodeBase.Services.GamePlay.ResourceLoad
{
    public interface IResourceLoader
    {
        GameObject Load(string path);
    }
}