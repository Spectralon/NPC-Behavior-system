using CodeBase.CompositionRoot.SubContainers;
using CodeBase.GamePlay.Cooldown;
using CodeBase.Infrastructure.CoroutineAccess;
using CodeBase.Infrastructure.Curtain;
using CodeBase.Infrastructure.Loader;
using CodeBase.StateMachine.GameStates;
using CodeBase.StateMachine.Machine;
using CodeBase.StaticData;
using Zenject;

namespace CodeBase.CompositionRoot
{
    public class BootstrapInstaller : MonoInstaller, IInitializable
    {
        public override void InstallBindings()
        {
            BindSelf();
            
            BindCoroutineRunner();
            
            BindSceneLoader();
            
            BindLoadingCurtain();

            BindGlobalStateMachine();

            BindCoolDownService();
        }

        private void BindCoolDownService()
        {
            Container
                .Bind<ICooldownService>()
                .To<CooldownService>()
                .AsSingle();
        }


        public void Initialize()
        {
            var stateMachine = Container.Resolve<IGameStateMachine>();
            stateMachine.Enter<BootstrapState>();
        }

        private void BindSelf()
        {
            Container.BindInterfacesTo<BootstrapInstaller>()
                .FromInstance(this)
                .AsSingle();
        }

        private void BindCoroutineRunner()
        {
            Container
                .Bind<ICoroutineRunner>()
                .To<CoroutineRunner>()
                .FromComponentInNewPrefabResource(ResourcePath.COROUTINE_RUNNER)
                .AsSingle();
        }

        private void BindSceneLoader()
        {
            Container
                .Bind<ISceneLoader>()
                .To<SceneLoader>()
                .AsSingle();
        }

        private void BindLoadingCurtain()
        {
            Container
                .Bind<ILoadingCurtain>()
                .To<LoadingCurtain>()
                .FromComponentInNewPrefabResource(ResourcePath.CURTAIN)
                .AsSingle();
        }
        
        private void BindGlobalStateMachine()
        {
            Container
                .Bind<IGameStateMachine>()
                .FromSubContainerResolve()
                .ByInstaller<GameStateMachineInstaller>()
                .AsSingle();
        }
    }
}