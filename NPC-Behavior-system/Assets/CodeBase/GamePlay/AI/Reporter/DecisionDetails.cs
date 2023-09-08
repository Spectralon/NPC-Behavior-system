using System.Collections.Generic;
using CodeBase.GamePlay.AI.Score;

namespace CodeBase.GamePlay.AI.Reporter
{
    public class DecisionDetails
    {
        public string CasterName;
        public string TargetName;
        public string AbilityName;

        public string FormattedLine;
    
        public List<ScoreFactor> Scores;
    }
}