using CodeBase.GamePlay.AI.Utility;
using CodeBase.GamePlay.Entities;
using CodeBase.StaticData.Abilities;

namespace CodeBase.GamePlay.AI.Calculation
{
    public static class When
    {
        public static bool AbilityIsDamage(CombatAbility ability, IEntity entity) =>
            ability.Type == AbilityType.Damage;

        public static bool AbilityIsBasicAttack(CombatAbility ability, IEntity entity) =>
            ability.Type == AbilityType.Damage && ability.MaxCooldown == 0;
    
        public static bool AbilityIsHeal(CombatAbility ability, IEntity target) => 
            ability.Type == AbilityType.Heal;
    
        public static bool AbilityIsStaminaBurn(CombatAbility ability, IEntity target) => 
            ability.Type == AbilityType.StaminaBurn;
    }
}