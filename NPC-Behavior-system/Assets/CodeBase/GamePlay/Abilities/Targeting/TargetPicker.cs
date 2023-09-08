using System;
using System.Collections.Generic;
using CodeBase.GamePlay.EntitiesRegistarion;
using CodeBase.StaticData.Abilities;

namespace CodeBase.GamePlay.Abilities.Targeting
{
    public class TargetPicker : ITargetPicker
    {
        private readonly IEntityRegistry _entityRegistry;

        public TargetPicker(IEntityRegistry entityRegistry) => 
            _entityRegistry = entityRegistry;

        public IEnumerable<string> AvailableTargetsFor(string casterId, TargetType targetType)
        {
            switch (targetType)
            {
                case TargetType.Ally:
                case TargetType.AllAllies:
                    return _entityRegistry.AlliesOf(casterId);
                case TargetType.Enemy:
                case TargetType.AllEnemies:
                    return _entityRegistry.EnemiesOf(casterId);
                case TargetType.Self:
                    return new[] {casterId};
                default:
                    throw new ArgumentOutOfRangeException(nameof(targetType), targetType, null);
            }
        }
    }
}