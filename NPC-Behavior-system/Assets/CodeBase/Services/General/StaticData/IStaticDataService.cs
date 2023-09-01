using CodeBase.StaticData.Abilities;
using CodeBase.StaticData.Entities;

namespace CodeBase.Services.General.StaticData
{
    public interface IStaticDataService
    {
        void LoadEntityConfigs();
        EntityConfig EntityConfigFor(EntityTypeId typeId);
        EntityAbility EntityAbilityFor(AbilityTypeId typeId, EntityTypeId entityTypeId);
    }
}