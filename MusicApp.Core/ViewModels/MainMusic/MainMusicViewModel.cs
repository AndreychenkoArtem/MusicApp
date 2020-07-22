using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlexiMvvm.Collections;
using FlexiMvvm.Commands;
using FlexiMvvm.Operations;
using FlexiMvvm.ViewModels;
using MusicApp.Core.AppConfig;
using MusicApp.Core.Models.TopArtists;
using MusicApp.Core.Navigation;
using MusicApp.Core.Services;
using MusicApp.Core.ViewModels.ArtistAlbums;

namespace MusicApp.Core.ViewModels.MainMusic
{
    public class MainMusicViewModel : LifecycleViewModel, ILifecycleViewModelWithResultHandler
    {
        private readonly ILoadMusicService _loadMusicService;
        private readonly IOperationFactory _operationFactory;
        private readonly INavigationService _navigationService;
        private readonly IAppConfig _appConfig;

        public MainMusicViewModel(
            ILoadMusicService loadMusicService,
            IOperationFactory operationFactory,
            INavigationService navigationService,
            IAppConfig appConfig)
        {
            _loadMusicService = loadMusicService;
            _operationFactory = operationFactory;
            _navigationService = navigationService;
            _appConfig = appConfig;
        }

        public ObservableCollection<MainMusicItemViewModel> ArtistsItemCollection { get; } =
            new ObservableCollection<MainMusicItemViewModel>();

        public Command ChangeLanguageCommand => CommandProvider.Get(ChangeLanguage);

        public Command<MainMusicItemViewModel> NavigateToDetailsCommand => CommandProvider.Get<MainMusicItemViewModel>(NavigateToDetails);

        public override async Task InitializeAsync(bool recreated)
        {
            await base.InitializeAsync(recreated);

            LoadData(PrepareRequest());
        }

        private string PrepareRequest(string country = "ukraine")
        {
            return country;
        }

        private void LoadData(string request)
        {
            _operationFactory.Create(this)
                .WithExpressionAsync(_ => _loadMusicService.GetTopArtistsAsync(request))
                .OnSuccess(HandleLoadData)
                .ExecuteAsync();
        }

        private void HandleLoadData(ArtistsModel artistsList)
        {
            var itemViewModels = artistsList.Topartists.Artist
                .Select(i => new MainMusicItemViewModel(i.Name, i.Listeners.ToString(), i.Image))
                .OrderBy(x=>x.ArtistName)
                .ToList();

            UpdateArtistsItemCollection(itemViewModels);
        }

        private void UpdateArtistsItemCollection(List<MainMusicItemViewModel> models)
        {
            ArtistsItemCollection.Clear();
            ArtistsItemCollection.AddRange(models);
        }

        private void ChangeLanguage()
        {

        }

        private void NavigateToDetails(MainMusicItemViewModel item)
        {
            var parameters = new ArtistAlbumsParameters(item.ArtistName);

            _navigationService.NavigateToArtistsAlbums(this, parameters);
        }

        public void HandleResult(ResultCode resultCode, Result result)
        {

        }
    }
}