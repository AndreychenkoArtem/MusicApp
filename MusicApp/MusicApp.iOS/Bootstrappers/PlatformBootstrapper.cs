using FlexiMvvm.Bootstrappers;
using FlexiMvvm.Ioc;
using MusicApp.Core.Bootstrappers;
using MusicApp.Core.Navigation;
using MusicApp.iOS.Navigation;

namespace MusicApp.iOS.Bootstrappers
{
    public class PlatformBootstrapper : IBootstrapper
    {
        public void Execute(BootstrapperConfig config)
        {
            var simpleIoc = config.GetSimpleIoc();

            SetupDependencies(simpleIoc);
        }

        private void SetupDependencies(ISimpleIoc simpleIoc)
        {
            simpleIoc.Register<INavigationService>(() => new NavigationService(), Reuse.Singleton);
        }
    }
}