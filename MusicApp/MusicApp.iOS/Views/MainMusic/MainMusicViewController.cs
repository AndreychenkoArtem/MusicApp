using FlexiMvvm.Bindings;
using FlexiMvvm.Collections;
using MetalPerformanceShaders;
using MusicApp.Core.ViewModels.MainMusic;
using MusicApp.iOS.Base;
using MusicApp.iOS.Extensions;

namespace MusicApp.iOS.Views.MainMusic
{
    public class MainMusicViewController : BindableViewControllerBase<MainMusicViewModel>
    {
        private new MainMusicView View
        {
            get => (MainMusicView)base.View;
            set => base.View = value;
        }

        private TableViewObservablePlainSource DataSource { get; set; }

        public override void LoadView()
        {
            View = new MainMusicView();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            DataSource = new TableViewObservablePlainSource(View.MusicTableView, GetCellId){ItemsContext = ViewModel};
            View.MusicTableView.Source = DataSource;
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            NavigationController.SetNavigationBarHidden(false, true);
            NavigationController.NavigationBar.SetToolbarStyle();
            this.Title = "Music";
        }

        public override void Bind(BindingSet<MainMusicViewModel> bindingSet)
        {
            base.Bind(bindingSet);

            bindingSet.Bind(DataSource)
                .For(v => v.ItemsBinding())
                .To(vm => vm.ArtistsItemCollection);

            bindingSet.Bind(DataSource)
                .For(v => v.RowSelectedBinding())
                .To(vm => vm.NavigateToDetailsCommand);
        }

        private string GetCellId(object arg)
        {
            return MainMusicItemViewCell.CellId;
        }
    }
}