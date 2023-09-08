using System.Collections.Generic;
using CodeBase.GamePlay.AI.Score;

namespace CodeBase.GamePlay.AI.Reporter
{
    public class DecisionScores
    {
        public string EntityName;

        public string FormattedLine;
    
        public List<ScoredAction> Choices;
    }
}