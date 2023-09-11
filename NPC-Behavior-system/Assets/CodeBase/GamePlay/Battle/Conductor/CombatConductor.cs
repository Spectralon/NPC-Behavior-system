using System;
using System.Collections.Generic;
using System.Linq;
using CodeBase.GamePlay.Abilities.Solver;
using CodeBase.GamePlay.AI;
using CodeBase.GamePlay.Cooldown;
using CodeBase.GamePlay.Death;
using CodeBase.GamePlay.Entities;
using CodeBase.GamePlay.EntityRegistry;
using CodeBase.GamePlay.Stamina;
using CodeBase.StaticData.Abilities;
using UnityEngine;
using Zenject;

namespace CodeBase.GamePlay.Battle.Conductor
{
    public class CombatConductor : ICombatConductor, ITickable
    {
        private const float TurnTickDuration = 0.3f;
    
        private readonly IEntityRegistry _entityRegistry;
        private readonly IDeathService _deathService;
        private readonly IStaminaService _staminaService;
        private readonly ICooldownService _cooldownService;
        private readonly IAbilitySolver _abilitySolver;
        private readonly IArtificialIntelligence _ai;
   
        private float _untilNextTurnTick;
        private bool _started;
        private bool _finished;
        private bool _turnTimerPaused;
      
        public CombatMode Mode { get; private set; } = CombatMode.Manual;
        
        public event Action<EntityAction> EntityActionProduced;
        
        public CombatConductor(
            IEntityRegistry entityRegistry,
            IDeathService deathService, 
            IStaminaService staminaService,
            IArtificialIntelligence ai,
            ICooldownService cooldownService,
            IAbilitySolver abilitySolver)
        {
            _ai = ai;
            _abilitySolver = abilitySolver;
            _entityRegistry = entityRegistry;
            _deathService = deathService;
            _deathService = deathService;
            _staminaService = staminaService;
            _cooldownService = cooldownService;
        }

        public void Tick()
        {
        if(!_started || _finished)
          return;
        
        UpdateTurnTimer();
        _abilitySolver.AbilityDelaysTick();
        _deathService.ProcessDeadHeroes();
        CheckBattleEnd(); 
        }

        public void Start() => _started = true;
        public void Stop() => _started = false;
        public void ResumeTurnTimer() => _turnTimerPaused = false;

        public void SetMode(CombatMode mode) => Mode = mode;
        
        private void PauseInManualMode()
        {
          if (Mode == CombatMode.Manual)
            _turnTimerPaused = true;
        }

        private void Finish() => _finished = true;

        private void UpdateTurnTimer()
        {
          if(_turnTimerPaused)
            return;
          
          _untilNextTurnTick -= Time.deltaTime;
          if (_untilNextTurnTick <= 0)
          {
            TurnTick();
            _untilNextTurnTick = TurnTickDuration;
          }
        }

        private void TurnTick()
        {
          _cooldownService.CooldownTick(TurnTickDuration);
          _staminaService.RestoreStaminaTick();
          ProcessReadyHeroes();

          if (_staminaService.EntityIsReadyOnNextTick())
            PauseInManualMode();
        }

        private void CheckBattleEnd()
        {
          if (_entityRegistry.FirstTeam.Count == 0 || _entityRegistry.SecondTeam.Count == 0)
            Finish();
        }

        private void ProcessReadyHeroes()
        {
          foreach (EntityBehaviour entity in _entityRegistry.AllActiveEntities())
          {
            if (entity.IsReady)
            {
              entity.State.CurrentStamina = 0;
              PerformEntityAction(entity);
            }
          }
        }

        private void PerformEntityAction(EntityBehaviour readyEntity)
        {
          EntityAction entityAction = _ai.MakeBestDecision(readyEntity);

          _abilitySolver.ProcessEntityAction(entityAction);
          
          EntityActionProduced?.Invoke(entityAction);
        }

        private AbilityTypeId TempSkill(EntityBehaviour readyEntity) => 
          readyEntity.State.SkillStates[0].TypeId;

        private List<string> TempTargets(EntityBehaviour readyEntity) => 
          _entityRegistry.EnemiesOf(readyEntity.Id).ToList();
            
    }
}