using System;
using FlexiMvvm.Bootstrappers;
using FlexiMvvm.Ioc;
using FlexiMvvm.Operations;
using FlexiMvvm.ViewModels;
using MusicApp.Core.AppConfig;
using MusicApp.Core.Handlers;
using MusicApp.Core.Navigation;
using MusicApp.Core.Services;
using MusicApp.Core.ViewModels;
using MusicApp.Core.ViewModels.ArtistAlbums;
using MusicApp.Core.ViewModels.MainMusic;

namespace MusicApp.Core.Bootstrappers
{
    /// <summary>
    /// PresentationBootstrapper - Setup your dependencies for presentation layer here.
    /// </summary>
    public class PresentationBootstrapper : IBootstrapper
    {
        public void Execute(BootstrapperConfig config)
        {
            var simpleIoc = config.GetSimpleIoc();

            SetupDependencies(simpleIoc);
            SetupInteractors(simpleIoc);
            SetupViewModels(simpleIoc);
            SetupViewModelProvider(simpleIoc);
        }

        private void SetupDependencies(ISimpleIoc simpleIoc)
        {
            simpleIoc.Register<IOperationFactory>(() => new OperationFactory(simpleIoc, new ApplicationErrorHandler()));
            simpleIoc.Register<ILoadMusicService>(()=> new LoadMusicService(), Reuse.Singleton);
        }

        private void SetupInteractors(ISimpleIoc simpleIoc)
        {
        }

        private void SetupViewModels(ISimpleIoc simpleIoc)
        {
            simpleIoc.Register(() =>
                new EntryViewModel(
                    simpleIoc.Get<INavigationService>()));

            simpleIoc.Register(() =>
                new MainMusicViewModel(
                    simpleIoc.Get<ILoadMusicService>(),
                    simpleIoc.Get<IOperationFactory>(),
                    simpleIoc.Get<INavigationService>(),
                    simpleIoc.Get<IAppConfig>()));

            simpleIoc.Register(()=>
                new ArtistAlbumsViewModel(
                    simpleIoc.Get<INavigationService>(),
                    simpleIoc.Get<ILoadMusicService>(),
                    simpleIoc.Get<IOperationFactory>()));
        }

        private void SetupViewModelProvider(IServiceProvider serviceProvider)
        {
            LifecycleViewModelProvider.SetFactory(new DefaultLifecycleViewModelFactory(serviceProvider));
        }
    }
}