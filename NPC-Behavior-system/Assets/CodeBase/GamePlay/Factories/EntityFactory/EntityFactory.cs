using System;
using System.Linq;
using CodeBase.Extensions;
using CodeBase.GamePlay.Battle;
using CodeBase.GamePlay.Entities;
using CodeBase.Services.GamePlay.ResourceLoad;
using CodeBase.Services.General.StaticData;
using CodeBase.StaticData.Entities;
using Zenject;
using Random = UnityEngine.Random;

namespace CodeBase.GamePlay.Factories.EntityFactory
{
    public class EntityFactory : IEntityFactory
    {
        private readonly IStaticDataService _staticDataService;
        private readonly IResourceLoader _resourceLoader;
        private readonly IInstantiator _instantiator;

        public EntityFactory(IStaticDataService staticDataService,
            IResourceLoader resourceLoader,
            IInstantiator instantiator)
        {
            _staticDataService = staticDataService;
            _resourceLoader = resourceLoader;
            _instantiator = instantiator;
        }
        
        public EntityBehaviour CreateEntityAt(EntityTypeId entityTypeId, Place place, bool turned)
        {
            EntityConfig config = _staticDataService.EntityConfigFor(entityTypeId);
            EntityBehaviour entity = _instantiator.InstantiatePrefabForComponent<EntityBehaviour>(config.Prefab, place.transform)
                .With(x => x.TypeId = entityTypeId)
                .With(x => x.Id = Guid.NewGuid().ToString());

            entity.InitWithState(
                new EntityState()
                    .With(x => x.MaxHp = config.Hp)
                    .With(x => x.CurrentHp = config.Hp)
                    .With(x => x.MaxStamina = config.Stamina)
                    .With(x => x.CurrentStamina = Random.Range(0, config.Stamina))
                    .With(x => x.Armor = config.Armor)
                    .With(x => x.SkillStates = config.Abilities.Select(AbilityState.FromEntityAbility).ToList()),
                turned,
                place.PlaceNumber
            );
      
            return entity;
        }
    }
}