using CodeBase.GamePlay.Entities;
using CodeBase.GamePlay.EntitiesRegistarion;

namespace CodeBase.GamePlay.Stamina
{
    public class StaminaService : IStaminaService
    {
        private const int StaminaTickValue = 3;
        private readonly IEntityRegistry _entityRegistry;

        public StaminaService(IEntityRegistry entityRegistry) => 
            _entityRegistry = entityRegistry;

        public void RestoreStaminaTick()
        {
            foreach (EntityBehaviour entity in _entityRegistry.AllActiveEntities())
            {
                entity.SwitchNextTurnPointer(false);
                entity.State.IncreaseStamina(StaminaTickValue);
            }
        }

        public bool EntityIsReadyOnNextTick()
        {
            foreach (EntityBehaviour entity in _entityRegistry.AllActiveEntities())
            {
                if (entity.State.CurrentStamina + StaminaTickValue >= entity.State.MaxStamina)
                {
                    entity.SwitchNextTurnPointer(true);
                    return true;
                }
            }

            return false;
        }
    }
}