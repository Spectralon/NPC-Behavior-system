using System.Collections.Generic;
using CodeBase.GamePlay.Entities;

namespace CodeBase.GamePlay.AI.Utility
{
    public class EntitySet
    {
        public IEnumerable<IEntity> Targets;

        public EntitySet(IEntity entity) => 
            Targets = new[] {entity};

        public EntitySet(IEnumerable<IEntity> entities) => 
            Targets = entities;
    }
}