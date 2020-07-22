using FlexiMvvm.ViewModels;
using MusicApp.Core.ViewModels.ArtistAlbums;

namespace MusicApp.Core.Navigation
{
    public interface INavigationService
    {
        void NavigateBack(ILifecycleViewModel fromViewModel);

        void NavigateBack<TResult>(ILifecycleViewModelWithResult<TResult> fromViewModel, ResultCode resultCode, TResult result)
            where TResult : Result;

        void NavigateToMain(ILifecycleViewModel fromViewModel);

        void NavigateToArtistsAlbums(ILifecycleViewModel fromViewModel, ArtistAlbumsParameters parameters);
    }
}