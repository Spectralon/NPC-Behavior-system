using CodeBase.GamePlay.Abilities.Targeting;
using CodeBase.GamePlay.AI;
using CodeBase.GamePlay.AI.Reporter;
using CodeBase.GamePlay.Death;
using CodeBase.GamePlay.EntitiesRegistarion;
using CodeBase.GamePlay.Factories.EntityFactory;
using CodeBase.GamePlay.Stamina;
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

            BindDeathService();

            BindStaminaService();

            BindTargetPicker();

            BindUtilityAI();

            BindGameFactory();
            
            BindUIFactory();
        }

        private void BindUtilityAI()
        {
            Container
                .Bind<IArtificialIntelligence>()
                .To<UtilityAI>()
                .AsSingle();
        }

        private void BindTargetPicker()
        {
            Container
                .Bind<ITargetPicker>()
                .To<TargetPicker>()
                .AsSingle();
        }

        private void BindStaminaService()
        {
            Container
                .Bind<IStaminaService>()
                .To<StaminaService>()
                .AsSingle();
        }

        private void BindDeathService()
        {
            Container
                .Bind<IDeathService>()
                .To<DeathService>()
                .AsSingle();
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
