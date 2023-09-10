using CodeBase.GamePlay.Battle;
using CodeBase.StaticData.Abilities;

namespace CodeBase.GamePlay.Abilities.Appliers
{
    public interface IAbilityApplier
    {
        void WarmUp();
        void ApplyAbility(ActiveAbility activeAbility);
        AbilityType AbilityType { get; }
        float CalculateAbilityValue(string casterId, AbilityTypeId abilityTypeId, string targetId);

    }
}