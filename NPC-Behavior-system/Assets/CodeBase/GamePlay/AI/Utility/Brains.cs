using System.Collections.Generic;
using CodeBase.GamePlay.AI.Calculation;

namespace CodeBase.GamePlay.AI.Utility
{
    public class Brains
    {
        private AIInput Input => new AIInput();

        private Convolutions _convolutions;

        public Brains()
        {
            _convolutions = new()
            {
                {When.AbilityIsDamage, GetInput.PercentageDamage, Calculation.Score.ScaleBy(100), "Basic Damage"},
                {When.AbilityIsDamage, GetInput.IsKillingBlow, Calculation.Score.IfTrueThen(+150), "Killing Blow"},
                {When.AbilityIsBasicAttack, GetInput.IsKillingBlow, Calculation.Score.IfTrueThen(+30), "Basic Skill Killing Blow"},
      
                {When.AbilityIsHeal, GetInput.HealPercentage, Calculation.Score.CullByTargetHp, "Heal"},
        
                {When.AbilityIsStaminaBurn, GetInput.StaminaBurn, Calculation.Score.CullByTargetInitiative(scaleBy: 50f, cullThreshold: 0.25f), "Initiative Burn"},
                {When.AbilityIsStaminaBurn, GetInput.TargetUltimateIsReady, Calculation.Score.IfTrueThen(+30), "Initiative Burn Ultimate Is Ready"},
            };
        }

        public ICollection<IUtilityFunction> GetUtilityFunctions() => 
            _convolutions;
    }
}