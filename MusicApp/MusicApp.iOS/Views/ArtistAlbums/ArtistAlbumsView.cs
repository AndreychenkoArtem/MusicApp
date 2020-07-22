using FlexiMvvm.Views;
using UIKit;

namespace MusicApp.iOS.Views.ArtistAlbums
{
    public class ArtistAlbumsView : LayoutView
    {
        public UITableView AlbumsTableView { get; } = new UITableView();

        protected override void SetupSubviews()
        {
            base.SetupSubviews();

            BackgroundColor = UIColor.White;

            AlbumsTableView.RegisterClassForCellReuse(typeof(ArtistAlbumsItemViewCell), ArtistAlbumsItemViewCell.CellId);
            AlbumsTableView.SeparatorStyle = UITableViewCellSeparatorStyle.None;
            AlbumsTableView.RowHeight = UITableView.AutomaticDimension;
            AlbumsTableView.EstimatedRowHeight = ArtistAlbumsItemViewCell.EstimatedHeight;
        }

        protected override void SetupLayout()
        {
            base.SetupLayout();

            ContentView
                .AddLayoutSubview(AlbumsTableView);
        }

        protected override void SetupLayoutConstraints()
        {
            base.SetupLayoutConstraints();

            AlbumsTableView.LeadingAnchor.ConstraintEqualTo(ContentView.LeadingAnchor).SetActive(true);
            AlbumsTableView.TopAnchor.ConstraintEqualTo(ContentView.TopAnchor).SetActive(true);
            AlbumsTableView.TrailingAnchor.ConstraintEqualTo(ContentView.TrailingAnchor).SetActive(true);
            AlbumsTableView.BottomAnchor.ConstraintEqualTo(ContentView.BottomAnchor).SetActive(true);
        }
    }
}