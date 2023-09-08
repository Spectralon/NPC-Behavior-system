using CodeBase.GamePlay.Battle;
using CodeBase.GamePlay.Entities;

namespace CodeBase.GamePlay.AI
{
    public interface IArtificialIntelligence
    {
        EntityAction MakeBestDecision(IEntity readyEntity);  
    }
}