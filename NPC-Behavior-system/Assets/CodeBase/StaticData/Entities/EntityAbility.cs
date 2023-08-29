using System;
using UnityEngine;

namespace CodeBase.CompositionRoot
{
    [Serializable]
    public class EntityAbility
    {
        public AbilityTypeId TypeId;
        public AbilityType Type;
        public string Name;
        
        public TargetType TargetType;
        public float Value;
        public float Cooldown;
        
        public Color Color;
        public AbilityAnimation Animation;
        public GameObject CustomTargetFx;
    }
}