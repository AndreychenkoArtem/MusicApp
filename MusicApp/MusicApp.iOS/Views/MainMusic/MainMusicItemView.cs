using FFImageLoading.Cross;
using FlexiMvvm.Views;
using MusicApp.iOS.Theme;
using UIKit;

namespace MusicApp.iOS.Views.MainMusic
{
    public class MainMusicItemView : LayoutView
    {
        private int EstimatedImageSize => AppDimens.Size8x;

        public MvxCachedImageView ArtistPhotoImageView { get; } = new MvxCachedImageView();

        public UILabel ArtistNameLabel { get; } = new UILabel();

        public UILabel ListenersCountLabel { get; } = new UILabel();

        protected override void SetupSubviews()
        {
            base.SetupSubviews();

            ArtistPhotoImageView.ContentMode = UIViewContentMode.ScaleAspectFill;
            ArtistPhotoImageView.ClipsToBounds = false;

            ArtistNameLabel.Font = UIFont.PreferredSubheadline;
            ArtistNameLabel.TextColor = UIColor.Black;

            ListenersCountLabel.Font = UIFont.PreferredCaption2;
            ListenersCountLabel.TextColor = UIColor.Gray;
        }

        protected override void SetupLayout()
        {
            base.SetupLayout();

            ContentView
                .AddLayoutSubview(ArtistPhotoImageView)
                .AddLayoutSubview(ArtistNameLabel)
                .AddLayoutSubview(ListenersCountLabel);
        }

        protected override void SetupLayoutConstraints()
        {
            base.SetupLayoutConstraints();

            ArtistPhotoImageView.LeadingAnchor.ConstraintEqualTo(ContentView.LeadingAnchor, AppDimens.Inset1x).SetActive(true);
            ArtistPhotoImageView.TopAnchor.ConstraintEqualTo(ContentView.TopAnchor, AppDimens.Inset1x).SetActive(true);
            ArtistPhotoImageView.HeightAnchor.ConstraintEqualTo(EstimatedImageSize).SetActive(true);
            ArtistPhotoImageView.WidthAnchor.ConstraintEqualTo(EstimatedImageSize).SetActive(true);
            ArtistPhotoImageView.BottomAnchor.ConstraintLessThanOrEqualTo(ContentView.BottomAnchor, -AppDimens.Inset1x).SetActive(true);

            ArtistNameLabel.LeadingAnchor.ConstraintEqualTo(ArtistPhotoImageView.TrailingAnchor, AppDimens.Inset2x).SetActive(true);
            ArtistNameLabel.TopAnchor.ConstraintEqualTo(ContentView.TopAnchor, AppDimens.Inset1x).SetActive(true);
            ArtistNameLabel.TrailingAnchor.ConstraintEqualTo(ContentView.TrailingAnchor).SetActive(true);

            ListenersCountLabel.LeadingAnchor.ConstraintEqualTo(ArtistNameLabel.LeadingAnchor).SetActive(true);
            ListenersCountLabel.TopAnchor.ConstraintEqualTo(ArtistNameLabel.BottomAnchor, AppDimens.Inset2x).SetActive(true);
            ListenersCountLabel.TrailingAnchor.ConstraintEqualTo(ContentView.TrailingAnchor).SetActive(true);
        }
    }
}