using UnityEngine;

namespace CodeBase.Infrastructure.CoroutineAccess
{
    public class CoroutineRunner : MonoBehaviour, ICoroutineRunner
    {
        private void Start() => 
            DontDestroyOnLoad(this);
    }
}