using CodeBase.StaticData.Abilities;

namespace CodeBase.GamePlay.Battle
{
    public interface IAbilityApplier
    {
        void WarmUp();
        void ApplyAbility(ActiveAbility activeAbility);
        AbilityType AbilityType { get; }
        float CalculateAbilityValue(string casterId, AbilityTypeId abilityTypeId, string targetId);

    }
}