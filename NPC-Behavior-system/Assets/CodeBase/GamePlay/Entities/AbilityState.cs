using CodeBase.Extensions;
using UnityEngine;

namespace CodeBase.CompositionRoot
{
    public class AbilityState
    {
        public AbilityTypeId TypeId;
        public float Cooldown;
        public float MaxCooldown;
        public Color Color;

        public bool IsReady => Cooldown <= 0;

        public static AbilityState FromEntityAbility(EntityAbility ability) =>
            new AbilityState()
                .With(x => x.TypeId = ability.TypeId)
                .With(x => x.Color = ability.Color)
                .With(x => x.MaxCooldown = ability.Cooldown);

        public void TickCooldown(float delta)
        {
            if (Cooldown > 0)
                Cooldown -= delta;
        }

        public void PutOnCooldown() => 
            Cooldown = MaxCooldown;
    }
}