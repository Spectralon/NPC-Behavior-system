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
            BindEntityFactory();
            
            BindResourceLoader();

            BindGameFactory();
            
            BindUIFactory();
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