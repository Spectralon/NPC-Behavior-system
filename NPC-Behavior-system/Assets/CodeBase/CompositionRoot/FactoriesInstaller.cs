using CodeBase.GamePlay.AI.Reporter;
using CodeBase.GamePlay.EntitiesRegistarion;
using CodeBase.GamePlay.Factorys.EntityFactory;
using CodeBase.Services.GamePlay.Factory;
using CodeBase.Services.GamePlay.ResourceLoad;
using CodeBase.UI.Services.Factory;
using Zenject;

namespace CodeBase.CompositionRoot
{
    public class FactoriesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindResourceLoader();
            
            BindEntityFactory();
            
            BindEntityRegistry();

            BindAIReporter();

            BindGameFactory();
            
            BindUIFactory();
        }

        private void BindAIReporter()
        {
            Container
                .Bind<IAIReporter>()
                .To<AIReporter>()
                .AsSingle();
        }

        private void BindEntityRegistry()
        {
            Container
                .Bind<IEntityRegistry>()
                .To<EntityRegistry>()
                .AsSingle();
        }

        private void BindEntityFactory()
        {
            Container
                .Bind<IEntityFactory>()
                .To<EntityFactory>()
                .AsSingle();
        }

        private void BindResourceLoader()
        {
            Container
                .Bind<IResourceLoader>()
                .To<ResourceLoader>()
                .AsSingle();
        }

        private void BindGameFactory()
        {
            Container
                .Bind<IGameFactory>()
                .To<GameFactory>()
                .AsSingle();
        }
        
        private void BindUIFactory()
        {
            Container
                .Bind<IUIFactory>()
                .To<UIFactory>()
                .AsSingle();
        }
    }
}