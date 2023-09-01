using System.Collections.Generic;
using System.Linq;
using CodeBase.StaticData.Abilities;
using CodeBase.StaticData.Entities;
using UnityEngine;

namespace CodeBase.Services.General.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private const string EntityConfigFolderPath = "Configs/Entities/";
    
        private Dictionary<EntityTypeId, EntityConfig> _entityConfigs = new();

        public EntityAbility EntityAbilityFor(AbilityTypeId typeId, EntityTypeId entityTypeId)
        {
            EntityConfig entityConfig = EntityConfigFor(entityTypeId);
            EntityAbility ability = entityConfig.Abilities.Find(x => x.TypeId == typeId);
            if (ability != null)
                return ability;
      
            throw new KeyNotFoundException($"No entity ability config found for {typeId} on {entityTypeId}");
        }

        public EntityConfig EntityConfigFor(EntityTypeId typeId)
        {
            if (_entityConfigs.TryGetValue(typeId, out EntityConfig config))
                return config;
      
            throw new KeyNotFoundException($"No config found for {typeId}");
        }

        public void LoadEntityConfigs()
        {
            _entityConfigs = Resources
                .LoadAll<EntityConfig>(EntityConfigFolderPath)
                .ToDictionary(x => x.TypeId, x => x);
        }
    }
}