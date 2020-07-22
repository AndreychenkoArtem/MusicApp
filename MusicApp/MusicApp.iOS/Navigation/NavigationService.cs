using FlexiMvvm.Navigation;
using FlexiMvvm.ViewModels;
using FlexiMvvm.Views;
using MusicApp.Core.Navigation;
using MusicApp.Core.ViewModels.ArtistAlbums;
using MusicApp.iOS.Views.ArtistAlbums;
using MusicApp.iOS.Views.MainMusic;

namespace MusicApp.iOS.Navigation
{
    public class NavigationService : FlexiMvvm.Navigation.NavigationService, INavigationService
    {
        public void NavigateBack(ILifecycleViewModel fromViewModel)
        {
            NavigationViewProvider.TryGetView(fromViewModel, out INavigationView<ILifecycleViewModel> fromView);

            NavigateBack(fromView, true);
        }

        public void NavigateBack<TResult>(ILifecycleViewModelWithResult<TResult> fromViewModel, ResultCode resultCode, TResult result)
            where TResult : Result
        {
            NavigationViewProvider.TryGetView(fromViewModel, out INavigationView<ILifecycleViewModelWithResult<TResult>> fromView);

            NavigateBack(fromView, resultCode, result, true);
        }

        public void NavigateToMain(ILifecycleViewModel fromViewModel)
        {
            NavigationViewProvider.TryGetView(fromViewModel, out INavigationView<ILifecycleViewModel> fromView);
            var toView = new MainMusicViewController();

            Navigate(fromView, toView, true);
        }

        public void NavigateToArtistsAlbums(ILifecycleViewModel fromViewModel, ArtistAlbumsParameters parameters)
        {
            NavigationViewProvider.TryGetView(fromViewModel, out INavigationView<ILifecycleViewModel> fromView);
            var toView = new ArtistAlbumsViewController();

            Navigate(fromView, toView, parameters, true);
        }
    }
}