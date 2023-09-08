using CodeBase.GamePlay.Battle;
using CodeBase.GamePlay.Entities;
using CodeBase.GamePlay.EntitiesRegistarion;
using CodeBase.GamePlay.UI.Text;
using CodeBase.Services.General.StaticData;
using CodeBase.StaticData.Abilities;
using CodeBase.StaticData.Entities;
using UnityEngine;

namespace CodeBase.GamePlay.Abilities.Appliers
{
    public class DamageApplier : IAbilityApplier
    {
        private readonly IStaticDataService _staticDataService;
        private readonly IEntityRegistry _entityRegistry;
        private readonly ICombatTextEntity _combatTextEntity;

        public DamageApplier(IStaticDataService staticDataService,
            IEntityRegistry entityRegistry,
            ICombatTextEntity combatTextEntity)
        {
            _staticDataService = staticDataService;
            _entityRegistry = entityRegistry;
            _combatTextEntity = combatTextEntity;
        }

        public AbilityType AbilityType => AbilityType.Damage;

        public void WarmUp()
        {
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

                target.State.CurrentHp -= ability.Value;

                _combatTextEntity.PlayText($"{ability.Value}", Color.red, target.transform.position);
                PlayFx(ability.CustomTargetFx, target.transform.position);
            }

        }

        public float CalculateAbilityValue(string casterId, AbilityTypeId abilityTypeId, string targetId)
        {
            EntityBehaviour caster = _entityRegistry.GetEntity(casterId);
            EntityAbility ability = _staticDataService.EntityAbilityFor(abilityTypeId, caster.TypeId);
            return ability.Value;
        }

        private void PlayFx(GameObject fxPrefab, Vector3 position)
        {
            if (fxPrefab)
                Object.Instantiate(fxPrefab, position, Quaternion.identity);
        }
    }
}