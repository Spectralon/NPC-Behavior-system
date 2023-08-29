using CodeBase.Services.GamePlay.ResourceLoad;
using CodeBase.Services.General.Progress.Registration;
using CodeBase.Services.General.Progress.Service;
using Zenject;

namespace CodeBase.Services.GamePlay.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IResourceLoader _resourceLoader;
        private readonly IInstantiator _instantiator;
        private readonly IProgressService _progressService;
        private readonly IRegistrationService _registrationService;
        
        public GameFactory(IResourceLoader resourceLoader, 
            IInstantiator instantiator,
            IProgressService progressService,
            IRegistrationService registrationService)
        {
            _resourceLoader = resourceLoader;
            _instantiator = instantiator;
            _progressService = progressService;
            _registrationService = registrationService;
        }

        
    }
}