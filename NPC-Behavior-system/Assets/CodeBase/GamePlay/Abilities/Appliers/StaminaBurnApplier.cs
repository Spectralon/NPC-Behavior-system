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
    public class StaminaBurnApplier : IAbilityApplier
    {
        private const string FxPrefabPath = "Fx/energyBall/energyBalls";
        
        private readonly IStaticDataService _staticDataService;
        private readonly IEntityRegistry _entityRegistry;
        private readonly ICombatTextEntity _combatTextEntity;
        private GameObject _fxPrefab;


        public StaminaBurnApplier(IStaticDataService staticDataService,
            IEntityRegistry entityRegistry,
            ICombatTextEntity combatTextEntity)
        {
            _staticDataService = staticDataService;
            _entityRegistry = entityRegistry;
            _combatTextEntity = combatTextEntity;
        }

        public AbilityType AbilityType => AbilityType.StaminaBurn;


        public void WarmUp() => 
            _fxPrefab = Resources.Load<GameObject>(FxPrefabPath);

        public void ApplyAbility(ActiveAbility activeAbility)
        {
            foreach (string targetId in activeAbility.TargetIds)
            {
                if (!_entityRegistry.IsAlive(targetId)) 
                    continue;
        
                EntityBehaviour caster = _entityRegistry.GetEntity(activeAbility.CasterId);
                EntityAbility ability = _staticDataService.EntityAbilityFor(activeAbility.Ability, caster.TypeId);

                EntityBehaviour target = _entityRegistry.GetEntity(targetId);

                float burnt = target.State.MaxStamina * ability.Value;
                target.State.CurrentStamina -= burnt;
                if (target.State.CurrentStamina < 0)
                    target.State.CurrentStamina = 0;

                _combatTextEntity.PlayText($"-{burnt}", new Color(0.7f, 0.4f, 0.2f, 1f), target.transform.position);
                PlayFx(target.transform.position);
            }
        }

        public float CalculateAbilityValue(string casterId, AbilityTypeId abilityTypeId, string targetId)
        {
            EntityBehaviour caster = _entityRegistry.GetEntity(casterId);
            EntityBehaviour target = _entityRegistry.GetEntity(targetId);
            EntityAbility ability = _staticDataService.EntityAbilityFor(abilityTypeId, caster.TypeId);
      
            return target.State.MaxStamina * ability.Value;
        }
        
        private void PlayFx(Vector3 targetPosition) => 
            Object.Instantiate(_fxPrefab, targetPosition, Quaternion.identity);
    }
}