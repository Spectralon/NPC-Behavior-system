using CodeBase.StateMachine.Machine;
using CodeBase.StateMachine.States;
using UnityEngine.SceneManagement;
using Zenject;
using ILogger = CodeBase.Services.General.CustomLogger.ILogger;

namespace CodeBase.StateMachine.GameStates
{
    public class GameLoopState : IState, IInitializable, ITickable
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly ILogger _logger;
        
        public GameLoopState(IGameStateMachine gameStateMachine, 
            ILogger logger)
        {
            _gameStateMachine = gameStateMachine;
            _logger = logger;
        }

        public void Initialize()
        {
            
        }

        public void Enter()
        {
            _logger.LogInfo($"State - {GetType().Name}, Scene - {SceneManager.GetActiveScene().name}");
        }

        public void Exit()
        {
        }

        public void Tick()
        {
            
        }

        public class Factory : PlaceholderFactory<IGameStateMachine, GameLoopState>
        {
        }
    }
}