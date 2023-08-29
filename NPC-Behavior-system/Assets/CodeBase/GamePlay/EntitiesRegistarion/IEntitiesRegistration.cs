using System.Collections.Generic;
using CodeBase.GamePlay.Entities;

namespace CodeBase.GamePlay.EntitiesRegistarion
{
    public interface IEntitiesRegistration
    {
        List<string> FirstTeam { get; }
        List<string> SecondTeam { get; }
        List<string> AllIds { get; }
    
        Dictionary<string, EntityBehaviour> All { get; }
        void RegisterFirstTeam(EntityBehaviour entity);
        void RegisterSecondTeam(EntityBehaviour entity);
        void Unregister(string entityId);
        bool IsAlive(string id);
        EntityBehaviour GetEntity(string id);
        IEnumerable<EntityBehaviour> AllActiveEntities();
        IEnumerable<string> AlliesOf(string entityId);
        IEnumerable<string> EnemiesOf(string entityId);
        void CleanUp();
    }
}