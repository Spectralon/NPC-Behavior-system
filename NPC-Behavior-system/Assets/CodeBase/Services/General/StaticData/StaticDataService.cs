using UnityEngine;

namespace CodeBase.Services.General.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        public void Initialize()
        {
            Debug.Log("Static data initialized.");
        }
    }
}