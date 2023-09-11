using CodeBase.GamePlay.Battle;
using CodeBase.GamePlay.Entities;
using CodeBase.GamePlay.EntityRegistry;
using CodeBase.GamePlay.UI.Text;
using CodeBase.Services.General.StaticData;
using CodeBase.StaticData.Abilities;
using CodeBase.StaticData.Entities;
using UnityEngine;

namespace CodeBase.GamePlay.Abilities.Appliers
{
    public class HealApplier : IAbilityApplier
    {
        private const string FxPrefabPath = "Fx/Heal/HealFx";
        
        private readonly IStaticDataService _staticDataService;
        private readonly IEntityRegistry _entityRegistry;
        private readonly ICombatTextEntity _combatTextEntity;
        private GameObject _fxPrefab;
        
        public AbilityType AbilityType => AbilityType.Heal;

        public HealApplier(IStaticDataService staticDataService,
            IEntityRegistry entityRegistry,
            ICombatTextEntity combatTextEntity)
        {
            _staticDataService = staticDataService;
            _entityRegistry = entityRegistry;
            _combatTextEntity = combatTextEntity;
        }

        public void ApplyAbility(ActiveAbility activeAbility)
        {
            foreach (string targetId in activeAbility.TargetIds)
            {
                if (!_entityRegistry.IsAlive(targetId)) 
                    continue;
        
                EntityBehaviour caster = _entityRegistry.GetEntity(activeAbility.CasterId);
                EntityAbility ability = _staticDataService.EntityAbilityFor(activeAbility.Ability, caster.TypeId);

                EntityBehaviour target = _entityRegistry.GetEntity(targetId);

                float healed = target.State.MaxHp * ability.Value;
                target.State.CurrentHp += healed;

                _combatTextEntity.PlayText($"+{healed}", Color.green, target.transform.position);
                PlayFx(target.transform.position);
            }
        }

        public float CalculateAbilityValue(string casterId, AbilityTypeId abilityTypeId, string targetId)
        {
            EntityBehaviour caster = _entityRegistry.GetEntity(casterId);
            EntityBehaviour target = _entityRegistry.GetEntity(targetId);
            EntityAbility ability = _staticDataService.EntityAbilityFor(abilityTypeId, caster.TypeId);

            return target.State.MaxHp * ability.Value;
        }

        public void WarmUp() => 
            _fxPrefab = Resources.Load<GameObject>(FxPrefabPath);

        private void PlayFx(Vector3 targetPosition) => 
            Object.Instantiate(_fxPrefab, targetPosition, Quaternion.identity);
    }
}