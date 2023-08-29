using CodeBase.CompositionRoot.SubContainers;
using CodeBase.Services.General.Ads;
using CodeBase.Services.General.CustomLogger;
using CodeBase.Services.General.Disposal;
using CodeBase.Services.General.Input;
using CodeBase.Services.General.Progress.Generator;
using CodeBase.Services.General.Progress.Registration;
using CodeBase.Services.General.Progress.Service;
using CodeBase.Services.General.Randomizer;
using CodeBase.Services.General.SaveLoad;
using CodeBase.Services.General.StaticData;
using Zenject;

namespace CodeBase.CompositionRoot
{
    public class ServicesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindInputService();
            
            BindCustomLogger();

            BindDisposer();
            
            BindRandomService();

            BindProgress();
            
            BindStaticDataService();

            BindSaveLoadService();
            
            BindAdsService();
        }

        private void BindProgressGenerator()
        {
            Container
                .Bind<IProgressGenerator>()
                .To<ProgressGenerator>()
                .AsSingle();
        }

        private void BindProgressService()
        {
            Container
                .Bind<IProgressService>()
                .To<ProgressService>()
                .AsSingle();
        }

        private void BindRegistrationService()
        {
            Container
                .Bind<IRegistrationService>()
                .To<RegistrationService>()
                .AsSingle();
        }

        private void BindCustomLogger()
        {
            Container
                .Bind<ILogger>()
                .To<Logger>()
                .AsSingle();
        }

        private void BindDisposer()
        {
            Container
                .Bind<IDisposer>()
                .To<Disposer>()
                .AsSingle();
        }

        private void BindStaticDataService()
        {
            Container
                .Bind<IStaticDataService>()
                .To<StaticDataService>()
                .AsSingle();
        }

        private void BindRandomService()
        {
            Container
                .Bind<IRandomService>()
                .To<RandomService>()
                .AsSingle();
        }

        private void BindSaveLoadService()
        {
            Container
                .Bind<ISaveLoadService>()
                .To<SaveLoadService>()
                .AsSingle();
        }

        private void BindAdsService()
        {
            Container
                .Bind<IAdsService>()
                .To<AdsService>()
                .AsSingle();
        }


        private void BindInputService()
        {
            Container
                .Bind<IInputService>()
                .FromSubContainerResolve()
                .ByInstaller<InputInstaller>()
                .AsSingle();
        }

        private void BindProgress()
        {
            BindRegistrationService();

            BindProgressGenerator();
            
            BindProgressService();
        }
    }
}