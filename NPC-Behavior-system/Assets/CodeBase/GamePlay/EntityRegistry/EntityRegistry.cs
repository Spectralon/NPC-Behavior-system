using System.Collections.Generic;
using System.Linq;
using CodeBase.GamePlay.Entities;

namespace CodeBase.GamePlay.EntityRegistry
{
    public class EntityRegistry : IEntityRegistry
    {
        public List<string> FirstTeam { get; } = new();
        public List<string> SecondTeam { get; } = new();
        public List<string> AllIds { get; private set; } = new();

        public Dictionary<string, EntityBehaviour> All { get; } = new();

        public void RegisterFirstTeam(EntityBehaviour entity)
        {
            if (!FirstTeam.Contains(entity.Id))
                FirstTeam.Add(entity.Id);

            All[entity.Id] = entity;

            UpdateCashes();
        }

        public void RegisterSecondTeam(EntityBehaviour entity)
        {
            if (!SecondTeam.Contains(entity.Id))
                SecondTeam.Add(entity.Id);
      
            All[entity.Id] = entity;
      
            UpdateCashes();
        }

        public void Unregister(string entityId)
        {
            if (FirstTeam.Contains(entityId))
                FirstTeam.Remove(entityId);

            if (SecondTeam.Contains(entityId))
                SecondTeam.Remove(entityId);

            if (All.ContainsKey(entityId))
                All.Remove(entityId);
      
            UpdateCashes();
        }

        public bool IsAlive(string id) => All.ContainsKey(id);

        public EntityBehaviour GetEntity(string id)
        {
            return All.TryGetValue(id, out EntityBehaviour entityBehaviour)
                ? entityBehaviour
                : null;
        }

        public IEnumerable<EntityBehaviour> AllActiveEntities() => 
            All.Values;

        public IEnumerable<string> AlliesOf(string entityId)
        {
            if (FirstTeam.Contains(entityId))
                return FirstTeam;
      
            return SecondTeam;
        }

        public IEnumerable<string> EnemiesOf(string entityId)
        {
            if (FirstTeam.Contains(entityId))
                return SecondTeam;
      
            return FirstTeam;
        }

        public void CleanUp()
        {
            FirstTeam.Clear();
            SecondTeam.Clear();
            All.Clear();
      
            AllIds.Clear();
        }

        private void UpdateCashes() => 
            AllIds = All.Keys.ToList();
    }
}