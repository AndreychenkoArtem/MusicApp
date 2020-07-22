using FlexiMvvm.Bootstrappers;
using FlexiMvvm.Ioc;
using MusicApp.Core.AppConfig;

namespace MusicApp.Core.Bootstrappers
{
    public class ApplicationBootstrapper : IBootstrapper
    {
        public void Execute(BootstrapperConfig config)
        {
            var simpleIoc = config.GetSimpleIoc();

            SetupDependencies(simpleIoc);
        }

        private void SetupDependencies(ISimpleIoc simpleIoc)
        {
            simpleIoc.Register<IAppConfig>(() => new AppConfig.AppConfig(), Reuse.Singleton);
        }
    }
}