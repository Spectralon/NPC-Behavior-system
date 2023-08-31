using System.Collections.Generic;
using CodeBase.GamePlay.Entities;
using CodeBase.StaticData.Abilities;

namespace CodeBase.GamePlay.Battle
{
    public class EntityAction
    {
        public IEntity Caster;
        public List<string> TargetIds;
        public AbilityTypeId Ability;
        public AbilityType AbilityType;
    }
}