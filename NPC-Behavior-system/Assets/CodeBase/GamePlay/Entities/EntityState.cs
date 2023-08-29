using System.Collections.Generic;

namespace CodeBase.CompositionRoot
{
    public class EntityState
    {
        public float MaxHp;
        public float CurrentHp;
        public float Damage;
        public float Armor;
        public float CurrentStamina;
        public float MaxStamina;

        public List<AbilityState> SkillStates;
        public float HpPercentage => CurrentHp / MaxHp;
        public float StaminaPercentage => CurrentStamina / MaxStamina;

        public void IncreaseStamina(float value)
        {
            if (CurrentStamina <= MaxStamina) 
                CurrentStamina += value;
        }
    }
}