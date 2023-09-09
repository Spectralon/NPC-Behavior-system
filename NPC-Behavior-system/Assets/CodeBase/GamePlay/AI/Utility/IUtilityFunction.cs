using CodeBase.GamePlay.Abilities.Solver;
using CodeBase.GamePlay.Entities;

namespace CodeBase.GamePlay.AI.Utility
{
    public interface IUtilityFunction
    {
        bool AppliesTo(CombatAbility ability, IEntity entity);
        float GetInput(CombatAbility ability, IEntity entity, IAbilitySolver abilitySolver);
        float Score(float input, IEntity entity);
        string Name { get; }
    }
}