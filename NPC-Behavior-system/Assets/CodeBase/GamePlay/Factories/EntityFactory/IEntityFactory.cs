using CodeBase.GamePlay.Battle;
using CodeBase.GamePlay.Entities;
using CodeBase.StaticData.Entities;

namespace CodeBase.GamePlay.Factories.EntityFactory
{
    public interface IEntityFactory
    {
        EntityBehaviour CreateEntityAt(EntityTypeId entityTypeId, Place place, bool turned);
    }
}