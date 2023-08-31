namespace CodeBase.GamePlay.Stamina
{
    public interface IStaminaService
    {
        void RestoreStaminaTick();
        bool EntityIsReadyOnNextTick();
    }
}