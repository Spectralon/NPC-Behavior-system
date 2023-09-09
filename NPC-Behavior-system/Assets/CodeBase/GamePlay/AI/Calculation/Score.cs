using System;
using CodeBase.GamePlay.Entities;

namespace CodeBase.GamePlay.AI.Calculation
{
    public static class Score
    {
        public static float AsIs(float input, IEntity target) => input;

        public static Func<float, IEntity, float> ScaleBy(float scale)
        {
            return (input, _) => input * scale;
        }

        public static Func<float, IEntity, float> IfTrueThen(float value)
        {
            return (input, _) => input * value;
        }
    
        public static float CullByTargetHp(float healPercentage, IEntity target)
        {
            if (target.State.HpPercentage >= 0.7f)
                return -30;

            return 100 * (healPercentage + 3 * (0.7f - target.State.HpPercentage));
        }
    
        public static Func<float, IEntity, float> CullByTargetInitiative(float scaleBy, float cullThreshold)
        {
            return (input, target) => target.State.StaminaPercentage > cullThreshold 
                ? input * scaleBy 
                : 0;
        }

        public static float FocusDamage(float hpPercentage, IEntity target)
        {
            return (1f - hpPercentage) * 50;
        }
    }
}