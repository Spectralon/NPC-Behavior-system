using System;
using System.Collections.Generic;
using CodeBase.GamePlay.Entities;

namespace CodeBase.GamePlay.AI.Reporter
{
    public interface IAIReporter
    {
        event Action<DecisionDetails> DecisionDetailsReported;
        event Action<DecisionScores> DecisionScoresReported;
        void ReportDecisionDetails(CombatAbility ability, IEntity target, List<ScoreFactor> scoreFactors);
        void ReportDecisionScores(IEntity readyEntity, List<ScoredAction> choices);
    }
}