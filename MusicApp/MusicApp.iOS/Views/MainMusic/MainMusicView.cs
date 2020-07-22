using FlexiMvvm.Views;
using UIKit;

namespace MusicApp.iOS.Views.MainMusic
{
    public class MainMusicView : LayoutView
    {
        public UITableView MusicTableView { get; } = new UITableView();

        protected override void SetupSubviews()
        {
            base.SetupSubviews();

            BackgroundColor = UIColor.White;

            MusicTableView.RegisterClassForCellReuse(typeof(MainMusicItemViewCell), MainMusicItemViewCell.CellId);
            MusicTableView.SeparatorStyle = UITableViewCellSeparatorStyle.None;
            MusicTableView.RowHeight = UITableView.AutomaticDimension;
            MusicTableView.EstimatedRowHeight = MainMusicItemViewCell.EstimatedHeight;
        }

        protected override void SetupLayout()
        {
            base.SetupLayout();

            ContentView
                .AddLayoutSubview(MusicTableView);
        }

        protected override void SetupLayoutConstraints()
        {
            base.SetupLayoutConstraints();

            MusicTableView.LeadingAnchor.ConstraintEqualTo(ContentView.LeadingAnchor).SetActive(true);
            MusicTableView.TopAnchor.ConstraintEqualTo(ContentView.TopAnchor).SetActive(true);
            MusicTableView.TrailingAnchor.ConstraintEqualTo(ContentView.TrailingAnchor).SetActive(true);
            MusicTableView.BottomAnchor.ConstraintEqualTo(ContentView.BottomAnchor).SetActive(true);
        }
    }
}