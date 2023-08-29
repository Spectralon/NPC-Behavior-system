namespace CodeBase.StateMachine.States
{
    public interface IPayloadState<TPayload> : IExitState
    { 
        void Enter(TPayload payload);
    }
}