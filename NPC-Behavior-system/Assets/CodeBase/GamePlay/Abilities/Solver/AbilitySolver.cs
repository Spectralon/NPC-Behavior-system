using System.Collections.Generic;
using CodeBase.GamePlay.Battle;
using CodeBase.GamePlay.Entities;
using CodeBase.GamePlay.EntitiesRegistarion;
using CodeBase.GamePlay.UI.Text;
using CodeBase.Services.General.StaticData;
using CodeBase.StaticData.Abilities;
using CodeBase.StaticData.Entities;
using UnityEngine;
using Zenject;

namespace CodeBase.GamePlay.Abilities.Solver
{
    public class AbilitySolver : IAbilitySolver, IInitializable
    {
        private readonly IStaticDataService _staticDataService;
        private readonly IEntityRegistry _entityRegistry;
        private readonly ICombatTextEntity _combatTextEntity;
        private readonly List<ActiveAbility> _activeAbilities = new(16);

        private List<IAbilityApplier> _appliers;

        public AbilitySolver(IStaticDataService staticDataService,
            IEntityRegistry entityRegistry)
        {
            _staticDataService = staticDataService;
            _entityRegistry = entityRegistry;

            InitAbilityAppliers();
        }

        public void Initialize()
        {
            foreach (IAbilityApplier skillApplier in _appliers) 
                skillApplier.WarmUp();
        }

        public void ProcessHeroAction(EntityAction entityAction)
        {
            EntityAbility ability = Ability(entityAction);

            EntityBehaviour entity = _entityRegistry.GetEntity(entityAction.Caster.Id);
      
            entity.Animator
                .PlaySkill(ability.Animation.AnimationIndex);

            entity.State.SkillStates
                .Find(x => x.TypeId == ability.TypeId)
                .PutOnCooldown();

            ShowAbilityName(entityAction.Caster.Id, ability.TypeId);

            _activeAbilities.Add(new ActiveAbility()
            {
                Ability = entityAction.Ability,
                Type = ability.Type,
                CasterId = entityAction.Caster.Id,
                TargetIds = entityAction.TargetIds,
                DelayLeft = ability.Animation.Delay
            });
        }

        public float CalculateAbilityValue(string casterId, AbilityTypeId abilityTypeId, string targetId)
        {
            EntityBehaviour caster = _entityRegistry.GetEntity(casterId);
            AbilityType type = _staticDataService.EntityAbilityFor(abilityTypeId, caster.TypeId).Type;
      
            return _appliers.Find(applier => applier.AbilityType == type)
                .CalculateAbilityValue(casterId, abilityTypeId, targetId);
        }

        public void AbilityDelaysTick()
        {
            for (int i = _activeAbilities.Count - 1; i >= 0; i--)
            {
                ActiveAbility activeAbility = _activeAbilities[i];
                activeAbility.DelayLeft -= Time.deltaTime;

                if (activeAbility.DelayLeft <= 0)
                {
                    _activeAbilities.Remove(activeAbility);
                    if (_entityRegistry.IsAlive(activeAbility.CasterId)) 
                        ApplyAbility(activeAbility);
                }
            }
        }

        private void ShowAbilityName(string casterId, AbilityTypeId abilityTypeId)
        {
            EntityBehaviour caster = _entityRegistry.GetEntity(casterId);

            _combatTextEntity.PlayText(SkillName(), Color.yellow, caster.transform.position);

            string SkillName()
            {
                return _staticDataService.EntityAbilityFor(abilityTypeId, caster.TypeId).Name;
            }
        }

        private void ApplyAbility(ActiveAbility activeAbility)
        {
            foreach (IAbilityApplier applier in _appliers)
            {
                if(applier.AbilityType == activeAbility.Type)
                    applier.ApplyAbility(activeAbility);
            }
        }

        private EntityAbility Ability(EntityAction entityAction) =>
            _staticDataService.EntityConfigFor(entityAction.Caster.TypeId)
                .Abilities.Find(x => x.TypeId == entityAction.Ability);

        private void InitAbilityAppliers()
        {
            _appliers = new List<IAbilityApplier>
            {
                new HealApplier(_staticDataService, _entityRegistry, _combatTextEntity),
                new DamageApplier(_staticDataService, _entityRegistry, _combatTextEntity),
                new StaminaBurnApplier(_staticDataService, _entityRegistry, _combatTextEntity),
            };
        }
    }
}