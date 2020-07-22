using FlexiMvvm.Bindings;
using FlexiMvvm.Collections;
using MusicApp.Core.ViewModels.ArtistAlbums;
using MusicApp.iOS.Base;
using MusicApp.iOS.Extensions;
using MusicApp.iOS.Providers;
using UIKit;

namespace MusicApp.iOS.Views.ArtistAlbums
{
    public class ArtistAlbumsViewController : BindableViewControllerBase<ArtistAlbumsViewModel, ArtistAlbumsParameters>
    {
        private UIBarButtonItem BackButton;
        private new ArtistAlbumsView View
        {
            get => (ArtistAlbumsView)base.View;
            set => base.View = value;
        }

        private TableViewObservablePlainSource DataSource { get; set; }

        public override void LoadView()
        {
            View = new ArtistAlbumsView();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            BackButton = BarButtonItemFactory.CreateBackButtonItem();

            DataSource = new TableViewObservablePlainSource(View.AlbumsTableView, GetCellId){ItemsContext = ViewModel};
            View.AlbumsTableView.Source = DataSource;
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            NavigationController.SetNavigationBarHidden(false, true);
            NavigationController.NavigationBar.SetToolbarStyle();

            NavigationItem.BackBarButtonItem = BackButton;
        }

        public override void Bind(BindingSet<ArtistAlbumsViewModel> bindingSet)
        {
            base.Bind(bindingSet);

            bindingSet.Bind(this)
                .For(v => v.TitleBinding())
                .To(vm => vm.Title);

            bindingSet.Bind(DataSource)
                .For(v => v.ItemsBinding())
                .To(vm => vm.ArtistAlbumsCollection);

            bindingSet.Bind(DataSource)
                .For(v => v.RowSelectedBinding())
                .To(vm => vm.NavigateToDetailsCommand);

            bindingSet.Bind(BackButton)
                .For(v => v.ClickedBinding())
                .To(vm => vm.NavigateBackCommand);
        }

        private string GetCellId(object arg)
        {
            return ArtistAlbumsItemViewCell.CellId;
        }
    }
}