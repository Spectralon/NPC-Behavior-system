using System;
using CodeBase.GamePlay.Abilities.Solver;
using CodeBase.GamePlay.Entities;

namespace CodeBase.GamePlay.AI.Utility
{
    public class UtilityFunction : IUtilityFunction
    {
        private readonly Func<CombatAbility, IEntity, bool> _appliesTo;
        private readonly Func<CombatAbility, IEntity, IAbilitySolver, float> _getInput;
        private readonly Func<float, IEntity, float> _score;
        public string Name { get;  }

        public UtilityFunction(
            Func<CombatAbility, IEntity, bool> appliesTo,
            Func<CombatAbility, IEntity, IAbilitySolver, float> getInput,
            Func<float, IEntity, float> score,
            string name)
        {
            Name = name;
            _appliesTo = appliesTo;
            _getInput = getInput;
            _score = score;
        }

        public bool AppliesTo(CombatAbility ability, IEntity entity) =>
            _appliesTo(ability, entity);

        public float GetInput(CombatAbility ability, IEntity entity, IAbilitySolver abilitySolver) =>
            _getInput(ability, entity, abilitySolver);

        public float Score(float input, IEntity entity) => _score(input, entity);
    }
}