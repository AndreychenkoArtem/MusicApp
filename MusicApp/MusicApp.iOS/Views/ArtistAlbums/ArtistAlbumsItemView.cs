using FFImageLoading.Cross;
using FlexiMvvm.Views;
using MusicApp.iOS.Theme;
using UIKit;

namespace MusicApp.iOS.Views.ArtistAlbums
{
    public class ArtistAlbumsItemView : LayoutView
    {
        private int EstimatedImageSize => AppDimens.Size8x;

        public MvxCachedImageView AlbumImageView { get; } = new MvxCachedImageView();

        public UILabel AlbumNameLabel { get; } = new UILabel();

        public UILabel PlayCountLabel { get; } = new UILabel();

        protected override void SetupSubviews()
        {
            base.SetupSubviews();

            AlbumImageView.ContentMode = UIViewContentMode.ScaleAspectFill;
            AlbumImageView.ClipsToBounds = false;

            AlbumNameLabel.Font = UIFont.PreferredSubheadline;
            AlbumNameLabel.TextColor = UIColor.Black;

            PlayCountLabel.Font = UIFont.PreferredCaption2;
            PlayCountLabel.TextColor = UIColor.Gray;
        }

        protected override void SetupLayout()
        {
            base.SetupLayout();

            ContentView
                .AddLayoutSubview(AlbumImageView)
                .AddLayoutSubview(AlbumNameLabel)
                .AddLayoutSubview(PlayCountLabel);
        }

        protected override void SetupLayoutConstraints()
        {
            base.SetupLayoutConstraints();

            AlbumImageView.LeadingAnchor.ConstraintEqualTo(ContentView.LeadingAnchor, AppDimens.Inset1x).SetActive(true);
            AlbumImageView.TopAnchor.ConstraintEqualTo(ContentView.TopAnchor, AppDimens.Inset1x).SetActive(true);
            AlbumImageView.HeightAnchor.ConstraintEqualTo(EstimatedImageSize).SetActive(true);
            AlbumImageView.WidthAnchor.ConstraintEqualTo(EstimatedImageSize).SetActive(true);
            AlbumImageView.BottomAnchor.ConstraintLessThanOrEqualTo(ContentView.BottomAnchor, -AppDimens.Inset1x).SetActive(true);

            AlbumNameLabel.LeadingAnchor.ConstraintEqualTo(AlbumImageView.TrailingAnchor, AppDimens.Inset2x).SetActive(true);
            AlbumNameLabel.TopAnchor.ConstraintEqualTo(ContentView.TopAnchor, AppDimens.Inset1x).SetActive(true);
            AlbumNameLabel.TrailingAnchor.ConstraintEqualTo(ContentView.TrailingAnchor).SetActive(true);

            PlayCountLabel.LeadingAnchor.ConstraintEqualTo(AlbumNameLabel.LeadingAnchor).SetActive(true);
            PlayCountLabel.TopAnchor.ConstraintEqualTo(AlbumNameLabel.BottomAnchor, AppDimens.Inset2x).SetActive(true);
            PlayCountLabel.TrailingAnchor.ConstraintEqualTo(ContentView.TrailingAnchor).SetActive(true);
        }
    }
}