using CodeBase.GamePlay.Battle;
using CodeBase.StaticData.Abilities;

namespace CodeBase.GamePlay.Abilities.Solver
{
    public interface IAbilitySolver
    {
        void ProcessEntityAction(EntityAction entityAction);
        float CalculateAbilityValue(string casterId, AbilityTypeId abilityTypeId, string targetId);
        void AbilityDelaysTick();
    }
}