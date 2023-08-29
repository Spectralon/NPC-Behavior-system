using UnityEngine;

namespace CodeBase.Services.General.Ads
{
    public class AdsService : IAdsService
    {
        public void Initialize()
        {
            Debug.Log("Ads initialized.");
        }
    }
}