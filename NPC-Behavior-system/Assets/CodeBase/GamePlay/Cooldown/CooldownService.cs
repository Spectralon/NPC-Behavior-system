using CodeBase.GamePlay.Entities;
using CodeBase.GamePlay.EntityRegistry;

namespace CodeBase.GamePlay.Cooldown
{
    public class CooldownService : ICooldownService
    {
        private readonly IEntityRegistry _entityRegistry;
        
        public CooldownService(IEntityRegistry entityRegistry) => 
            _entityRegistry = entityRegistry;

        public void CooldownTick(float deltaTime)
        {
            foreach (EntityBehaviour entity in _entityRegistry.AllActiveEntities())
            foreach (AbilityState skillState in entity.State.SkillStates)
                skillState.TickCooldown(deltaTime);
        }
    }
}
