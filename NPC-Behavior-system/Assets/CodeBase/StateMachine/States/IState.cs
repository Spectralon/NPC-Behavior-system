namespace CodeBase.StateMachine.States
{
    public interface IState : IExitState
    {
       void Enter();
    }
}