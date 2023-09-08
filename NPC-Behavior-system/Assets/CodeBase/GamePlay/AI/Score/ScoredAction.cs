using System.Collections.Generic;
using System.Linq;
using CodeBase.GamePlay.AI.Utility;
using CodeBase.GamePlay.Battle;
using CodeBase.GamePlay.Entities;
using CodeBase.StaticData.Abilities;

namespace CodeBase.GamePlay.AI.Score
{
    public class ScoredAction : EntityAction
    {
        public float Score { get; }

        public ScoredAction(IEntity caster, IEnumerable<IEntity> targets, CombatAbility ability, float score)
        {
            Caster = caster;
            TargetIds = targets.Select(x => x.Id).ToList();
            Ability = ability.TypeId;
            AbilityType = ability.Type;
            Score = score;
        }

        public override string ToString()
        {
            string abilityCategory = "other";
            if (AbilityType is AbilityType.Damage)
                abilityCategory = "damage";

            if (AbilityType is AbilityType.Heal)
                abilityCategory = "heal";

            if (AbilityType is AbilityType.StaminaBurn)
                abilityCategory = "stamina burn";

            return $"{abilityCategory}: <#FFFF00>{Ability}</color> targets: {TargetIds.Count} score: \n<#00FF00>{Score:0.00}</color> \n";
        }
    }
}