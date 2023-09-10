using System;

namespace CodeBase.GamePlay.Battle.Conductor
{
    public interface ICombatConductor
    {
        event Action<EntityAction> EntityActionProduced;
        void Start();
        void Stop();
        void ResumeTurnTimer();
        void SetMode(CombatMode mode);
    }
}