using CodeBase.Infrastructure.Loader;
using CodeBase.Services.General.StaticData;
using CodeBase.StateMachine.Machine;
using CodeBase.StateMachine.States;
using CodeBase.StaticData;
using UnityEngine.SceneManagement;
using Zenject;
using ILogger = CodeBase.Services.General.CustomLogger.ILogger;

namespace CodeBase.StateMachine.GameStates
{
    public class BootstrapState : IState
    {
        private readonly IGameStateMachine _stateMachine;
        private readonly ILogger _logger;
        private readonly ISceneLoader _sceneLoader;
        private readonly IStaticDataService _staticDataService;

        public BootstrapState(IGameStateMachine stateMachine, 
            ILogger logger,
            ISceneLoader sceneLoader,
            IStaticDataService staticDataService)
        {
            _stateMachine = stateMachine;
            _logger = logger;
            _sceneLoader = sceneLoader;
            _staticDataService = staticDataService;
        }

        public void Enter()
        {
            _logger.LogInfo($"Entered to State - {GetType().Name}, Scene - {SceneManager.GetActiveScene().name}");
            
            InitServices();
            _sceneLoader.Load(ScenesID.INIT, EnterLoadLevel);
        }

        private void InitServices()
        {
            _staticDataService.LoadEntityConfigs();
        }

        private void EnterLoadLevel() =>
            _stateMachine.Enter<LoadProgressState>();

        public void Exit() => 
            _logger.LogInfo($"Exited from State - {GetType().Name}, Scene - {SceneManager.GetActiveScene().name}");

        public class Factory : PlaceholderFactory<IGameStateMachine, BootstrapState>
        {
        }
    }
}