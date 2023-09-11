using System;
using System.Collections.Generic;
using System.Linq;
using CodeBase.GamePlay.AI.Score;
using CodeBase.GamePlay.AI.Utility;
using CodeBase.GamePlay.Entities;
using CodeBase.GamePlay.EntityRegistry;

namespace CodeBase.GamePlay.AI.Reporter
{
    public class AIReporter : IAIReporter
    {
        private readonly IEntityRegistry _registry;
        public event Action<DecisionDetails> DecisionDetailsReported;
        public event Action<DecisionScores> DecisionScoresReported;
    
        public AIReporter(IEntityRegistry registry) => 
            _registry = registry;
    
        public void ReportDecisionDetails(CombatAbility ability, IEntity target, List<ScoreFactor> scoreFactors)
        {
            EntityBehaviour caster = _registry.GetEntity(ability.CasterId);
            EntityBehaviour targetEntity = _registry.GetEntity(target.Id);
            DecisionDetails details = new DecisionDetails
            {
                CasterName = $"{caster.TypeId} [{caster.PlaceNumber}]",
                TargetName = $"{targetEntity.TypeId} [{targetEntity.PlaceNumber}]",
                AbilityName = $"{ability.TypeId}",
                Scores = scoreFactors,
                FormattedLine = string.Join(Environment.NewLine, 
                    scoreFactors.OrderByDescending(x => x.Score)
                        .Select(x => x.ToString())
                        .ToArray())
            };
      
            DecisionDetailsReported?.Invoke(details);
        }
    
        public void ReportDecisionScores(IEntity readyEntity, List<ScoredAction> choices)
        {
            EntityBehaviour caster = _registry.GetEntity(readyEntity.Id);
            DecisionScores scores = new DecisionScores
            {
                EntityName = $"{caster.TypeId} [{caster.PlaceNumber}]",
                Choices = choices,
                FormattedLine = string.Join(Environment.NewLine, 
                    choices.OrderByDescending(x => x.Score)
                        .Select(x => x.ToString())
                        .ToArray())
            };
    
            DecisionScoresReported?.Invoke(scores);
        }
    }
}