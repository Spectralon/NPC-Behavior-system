namespace CodeBase.CompositionRoot
{
    public class CooldownService : ICooldownService
    {
        private readonly IEntitiesRegistration _entitiesRegistration;
        
        public CooldownService(IEntitiesRegistration entitiesRegistration) => 
            _entitiesRegistration = entitiesRegistration;

        public void CooldownTick(float deltaTime)
        {
            foreach (EntityBehaviour entity in _entitiesRegistration.AllActiveEntities())
            foreach (AbilityState skillState in entity.State.SkillStates)
                skillState.TickCooldown(deltaTime);
        }
    }
}
