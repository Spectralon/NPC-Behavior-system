using System.Collections.Generic;
using System.Linq;
using CodeBase.Extensions;
using CodeBase.GamePlay.Abilities.Solver;
using CodeBase.GamePlay.Abilities.Targeting;
using CodeBase.GamePlay.AI.Reporter;
using CodeBase.GamePlay.AI.Score;
using CodeBase.GamePlay.Battle;
using CodeBase.GamePlay.Entities;
using CodeBase.GamePlay.EntityRegistry;
using CodeBase.Services.General.StaticData;

namespace CodeBase.GamePlay.AI.Utility
{
    public class UtilityAI : IArtificialIntelligence
    {
        private readonly IStaticDataService _staticDataService;
        private readonly ITargetPicker _targetPicker;
        private readonly IEntityRegistry _entityRegistry;
        private readonly IAIReporter _aiReporter;
        private readonly IAbilitySolver _abilitySolver;
        private ICollection<IUtilityFunction> _utilityFunctions;

        public UtilityAI(IStaticDataService staticDataService,
            ITargetPicker targetPicker,  
            IEntityRegistry entityRegistry,
            IAIReporter aiReporter, 
            IAbilitySolver abilitySolver)
        {
            _staticDataService = staticDataService;
            _targetPicker = targetPicker;
            _entityRegistry = entityRegistry;
            _aiReporter = aiReporter;
            _abilitySolver = abilitySolver;
            
            _utilityFunctions = new Brains().GetUtilityFunctions();
        }
        
        public EntityAction MakeBestDecision(IEntity readyEntity)
        {
            List<ScoredAction> choices = GetScoredHeroActions(readyEntity, ReadySkills(readyEntity))
                .ToList();

            _aiReporter.ReportDecisionScores(readyEntity, choices);
      
            return choices.FindMax(x => x.Score);
        }
        
        private IEnumerable<ScoredAction> GetScoredHeroActions(IEntity readyEntity, IEnumerable<CombatAbility> abilities)
        {
            foreach (CombatAbility ability in abilities)
            foreach (EntitySet entitySet in HeroSetForSkill(ability))
            {
                float? score = CalculateScore(ability, entitySet);
                if (!score.HasValue)
                    continue;

                yield return new ScoredAction(readyEntity, entitySet.Targets, ability, score.Value);
            }
        }
        
        private float? CalculateScore(CombatAbility ability, EntitySet entitySet)
        {
            return entitySet.Targets
                .Select(hero => CalculateScore(ability, hero))
                .Where(x => x != null)
                .Sum();
        }
        
        private float? CalculateScore(CombatAbility ability, IEntity entity)
        {
            List<ScoreFactor> scoreFactors = 
                (from utilityFunction in _utilityFunctions
                    where utilityFunction.AppliesTo(ability, entity)
                    let input = utilityFunction.GetInput(ability, entity, _abilitySolver)
                    let score = utilityFunction.Score(input, entity)
                    select new ScoreFactor(utilityFunction.Name, score))
                .ToList();
      
            _aiReporter.ReportDecisionDetails(ability, entity, scoreFactors);

            return scoreFactors.Select(x => x.Score)
                .SumOrNull();
        }
        
        private IEnumerable<EntitySet> HeroSetForSkill(CombatAbility ability)
        {
            IEnumerable<string> availableTargets =
                _targetPicker.AvailableTargetsFor(ability.CasterId, ability.TargetType);

            if (ability.IsSingleTarget)
            {
                foreach (string target in availableTargets)
                    yield return new EntitySet(_entityRegistry.GetEntity(target));
        
                yield break;
            }

            yield return new EntitySet(availableTargets.Select(_entityRegistry.GetEntity));
        }
        
        private IEnumerable<CombatAbility> ReadySkills(IEntity readyEntity)
        {
            return readyEntity.State.SkillStates
                .Where(x => x.IsReady)
                .Select(x => new CombatAbility
                {
                    CasterId = readyEntity.Id,
                    TypeId = x.TypeId,
                    MaxCooldown = x.MaxCooldown,
                    Type = _staticDataService.EntityAbilityFor(x.TypeId, readyEntity.TypeId).Type,
                    TargetType = _staticDataService.EntityAbilityFor(x.TypeId, readyEntity.TypeId).TargetType,
                });
        }
    }
}