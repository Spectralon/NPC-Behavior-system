using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.StaticData.Entities
{
    [CreateAssetMenu(menuName = "Combat/Entity Config")]
    public class EntityConfig : ScriptableObject
    {
        public EntityTypeId TypeId;
        public float Hp;
        public float Armor;
        public float Stamina;

        public List<EntityAbility> Abilities;

        public GameObject Prefab;
    }
}