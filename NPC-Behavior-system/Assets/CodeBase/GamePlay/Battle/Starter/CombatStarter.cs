using System;
using System.Collections.Generic;
using System.Linq;
using CodeBase.GamePlay.Battle.Conductor;
using CodeBase.GamePlay.Entities;
using CodeBase.GamePlay.EntitiesRegistarion;
using CodeBase.GamePlay.Factories.EntityFactory;
using CodeBase.StaticData.Entities;
using Random = UnityEngine.Random;

namespace CodeBase.GamePlay.Battle.Starter
{
    public class CombatStarter : ICombatStarter
    {
        private readonly IEntityFactory _entityFactory;
        private readonly IEntityRegistry _entityRegistry;
        private readonly ICombatConductor _combatConductor;

        public CombatStarter(IEntityFactory entityFactory, 
            IEntityRegistry entityRegistry,
            ICombatConductor combatConductor)
        {
            _entityFactory = entityFactory;
            _entityRegistry = entityRegistry;
            _combatConductor = combatConductor;
        }
        
        public void StartRandomBattle(PlaceSetup placeSetup)
        {
            SetupFirstTeam(placeSetup);
            SetupSecondTeam(placeSetup);
      
            _combatConductor.Start();
        }

        private void SetupFirstTeam(PlaceSetup placeSetup)
        {
            foreach (Place place in placeSetup.FirstTeamPlaces)
            {
                EntityBehaviour entity = _entityFactory.CreateEntityAt(RandomHeroTypeId(), place, place.Turned);
                _entityRegistry.RegisterFirstTeam(entity);
            }
        }

        private void SetupSecondTeam(PlaceSetup placeSetup)
        {
            foreach (Place place in placeSetup.SecondTeamPlaces)
            {
                EntityBehaviour entity = _entityFactory.CreateEntityAt(RandomHeroTypeId(), place, place.Turned);
                _entityRegistry.RegisterSecondTeam(entity);
            }
        }

        private static EntityTypeId RandomHeroTypeId()
        {
            List<EntityTypeId> typeIds = Enum.GetValues(typeof(EntityTypeId))
                .Cast<EntityTypeId>()
                .Except(new[] {EntityTypeId.Unknown})
                .ToList();
      
            return typeIds[Random.Range(0, typeIds.Count)];
        }
    }
}