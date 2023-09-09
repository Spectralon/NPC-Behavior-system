using CodeBase.GamePlay.Abilities.Solver;
using CodeBase.GamePlay.Entities;

namespace CodeBase.GamePlay.AI.Utility
{
    public class AIInput
    {
        public float TargetHpPercentage(CombatAbility ability, IEntity target, IAbilitySolver abilitySolver) =>
            target.State.HpPercentage;
    }
}