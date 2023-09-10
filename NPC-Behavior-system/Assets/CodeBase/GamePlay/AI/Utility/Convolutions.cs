using System;
using System.Collections.Generic;
using CodeBase.GamePlay.Abilities.Solver;
using CodeBase.GamePlay.Entities;

namespace CodeBase.GamePlay.AI.Utility
{
    public class Convolutions : List<IUtilityFunction>
    {
        public void Add(
            Func<CombatAbility, IEntity, bool> appliesTo,
            Func<CombatAbility, IEntity, IAbilitySolver, float> getInput,
            Func<float, IEntity, float> score,
            string name)
        {
            Add(new UtilityFunction(appliesTo, getInput, score, name));
        }
    }
}