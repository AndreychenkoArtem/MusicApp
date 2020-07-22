using FlexiMvvm.Bootstrappers;
using FlexiMvvm.Configuration;
using FlexiMvvm.Ioc;
using MusicApp.Core.Bootstrappers;

namespace MusicApp.iOS.Bootstrappers
{
    /// <summary>
    /// Platform specific bootstrapper for main platform dependencies via Fasebook, Firebase, PushNotifications etc.
    /// </summary>
    public static class InitialBootstrapper
    {
        public static void Execute(UIKit.UIApplication application, Foundation.NSDictionary launchOptions)
        {
            SetupFlexiMvvm();
            SetupResources();

            var config = CreateBootstrapperConfig(application, launchOptions);
            ExecuteBootstrappers(config);
        }

        private static void SetupFlexiMvvm()
        {
            FlexiMvvmConfig.Instance.ShouldRaisePropertyChanged(false);
        }

        private static void SetupResources()
        {
            // TODO Implement .resx file
        }

        private static BootstrapperConfig CreateBootstrapperConfig(UIKit.UIApplication application, Foundation.NSDictionary launchOptions)
        {
            var config = new BootstrapperConfig();
            config.SetSimpleIoc(new SimpleIoc());

            return config;
        }

        private static void ExecuteBootstrappers(BootstrapperConfig config)
        {
            var compositeBootstrapper = new CompositeBootstrapper(
                new PlatformBootstrapper(),
                new ApplicationBootstrapper(),
                new PresentationBootstrapper());
            compositeBootstrapper.Execute(config);
        }
    }
}