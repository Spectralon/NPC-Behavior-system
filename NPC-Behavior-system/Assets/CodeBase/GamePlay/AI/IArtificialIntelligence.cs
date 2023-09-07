using CodeBase.GamePlay.Entities;

namespace CodeBase.GamePlay.Battle
{
    public interface IArtificialIntelligence
    {
        EntityAction MakeBestDecision(IEntity readyEntity);  
    }
}