using System.Linq;
using CodeBase.GamePlay.Abilities.Solver;
using CodeBase.GamePlay.AI.Utility;
using CodeBase.GamePlay.Entities;

namespace CodeBase.GamePlay.AI.Calculation
{
    public static class GetInput
    {
        private const int True = 1;
        private const int False = 0;

        public static float TargetHpPercentage(CombatAbility ability, IEntity target, IAbilitySolver abilitySolver) =>
            target.State.HpPercentage;

        public static float PercentageDamage(CombatAbility ability, IEntity target, IAbilitySolver abilitySolver)
        {
            float damage = abilitySolver.CalculateAbilityValue(ability.CasterId, ability.TypeId, target.Id);
            return damage / target.State.MaxHp;
        }

        public static float IsKillingBlow(CombatAbility ability, IEntity target, IAbilitySolver abilitySolver)
        {
            float damage = abilitySolver.CalculateAbilityValue(ability.CasterId, ability.TypeId, target.Id);
            return damage > target.State.CurrentHp 
                ? True 
                : False;
        }
    
        public static float HealPercentage(CombatAbility ability, IEntity target, IAbilitySolver abilitySolver) => 
            abilitySolver.CalculateAbilityValue(ability.CasterId, ability.TypeId, target.Id);
    
        public static float StaminaBurn(CombatAbility ability, IEntity target, IAbilitySolver abilitySolver)
        {
            float burn = abilitySolver.CalculateAbilityValue(ability.CasterId, ability.TypeId, target.Id);
            return burn / target.State.MaxStamina;
        }
    
        public static float TargetUltimateIsReady(CombatAbility ability, IEntity target, IAbilitySolver abilitySolver) => 
            target.State.SkillStates.Last().IsReady 
                ? True 
                : False;
    }
}