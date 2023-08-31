using CodeBase.GamePlay.Entities;
using CodeBase.GamePlay.EntitiesRegistarion;
using UnityEngine;

namespace CodeBase.GamePlay.Death
{
    public class DeathService : IDeathService
    {
        private const float DefaultDestroyTime = 3;
        private readonly IEntityRegistry _entityRegistry;

        public DeathService(IEntityRegistry entityRegistry) => 
            _entityRegistry = entityRegistry;

        public void ProcessDeadHeroes()
        {
            foreach (string id in _entityRegistry.AllIds)
            {
                EntityBehaviour entity = _entityRegistry.GetEntity(id);
                if (!entity.IsDead)
                    continue;
        
                _entityRegistry.Unregister(entity.Id);
        
                entity.Animator.PlayDeath();
                Object.Destroy(entity.gameObject, DefaultDestroyTime);
            }

        }
    }
}