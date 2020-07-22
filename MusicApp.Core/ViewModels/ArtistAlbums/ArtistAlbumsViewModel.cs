using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlexiMvvm.Collections;
using FlexiMvvm.Commands;
using FlexiMvvm.Operations;
using MusicApp.Core.Base;
using MusicApp.Core.Models.ArtistAlbums;
using MusicApp.Core.Navigation;
using MusicApp.Core.Services;

namespace MusicApp.Core.ViewModels.ArtistAlbums
{
    public class ArtistAlbumsViewModel : LifecycleViewModelBase<ArtistAlbumsParameters>
    {
        private readonly INavigationService _navigationService;
        private readonly ILoadMusicService _loadMusicService;
        private readonly IOperationFactory _operationFactory;

        public ArtistAlbumsViewModel(
            INavigationService navigationService,
            ILoadMusicService loadMusicService,
            IOperationFactory operationFactory)
        {
            _navigationService = navigationService;
            _loadMusicService = loadMusicService;
            _operationFactory = operationFactory;
        }

        public string Title { get; private set; }

        public ObservableCollection<ArtistAlbumsItemViewModel> ArtistAlbumsCollection { get; } = new ObservableCollection<ArtistAlbumsItemViewModel>();

        public Command<ArtistAlbumsItemViewModel> NavigateToDetailsCommand => CommandProvider.Get<ArtistAlbumsItemViewModel>(NavigateToAlbumDetails);

        public Command NavigateBackCommand => CommandProvider.Get(NavigateBack);

        public override async Task InitializeAsync(ArtistAlbumsParameters parameters, bool recreated)
        {
            await base.InitializeAsync(parameters, recreated);

            Title = parameters.ArtistName;

            LoadData(parameters.ArtistName.ToLower());
        }

        private void LoadData(string artistName)
        {
            _operationFactory.Create(this)
                .WithExpressionAsync(_ => _loadMusicService.GetTopArtistAlbumsAsync(artistName))
                .OnSuccess(HandleLoadData)
                .ExecuteAsync();
        }

        private void HandleLoadData(ArtistAlbumModel model)
        {
            var itemViewModels = model.Topalbums.Album
                .Select(x => new ArtistAlbumsItemViewModel(x.Name, x.Playcount, x.Image))
                .ToList();

            UpdateArtistsItemCollection(itemViewModels);

            SaveDataToLocalStorage();
        }

        private void SaveDataToLocalStorage()
        {
            //TODO Inject IRealmLocalStorage
        }

        private void UpdateArtistsItemCollection(List<ArtistAlbumsItemViewModel> itemViewModels)
        {
            ArtistAlbumsCollection.Clear();
            ArtistAlbumsCollection.AddRange(itemViewModels);
        }

        private void NavigateToAlbumDetails(ArtistAlbumsItemViewModel model)
        {
            //TODO Navigate to details
        }

        private void NavigateBack()
        {
            _navigationService.NavigateBack(this);
        }
    }
}