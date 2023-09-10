using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace CodeBase.GamePlay.Battle
{
    public class PlaceSetup : MonoBehaviour
    {
        public List<Place> FirstTeamPlaces;
        [FormerlySerializedAs("SecondTeamSlotsPlaces")] public List<Place> SecondTeamPlaces;
    }
}