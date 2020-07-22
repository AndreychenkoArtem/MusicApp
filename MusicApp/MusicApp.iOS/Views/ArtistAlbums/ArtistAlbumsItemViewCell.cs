using System;
using FlexiMvvm.Bindings;
using MusicApp.Core.ViewModels.ArtistAlbums;
using MusicApp.iOS.Base;
using MusicApp.iOS.Extensions;
using MusicApp.iOS.Theme;
using UIKit;

namespace MusicApp.iOS.Views.ArtistAlbums
{
    public class ArtistAlbumsItemViewCell : TableViewBindableItemCellBase<ArtistAlbumsViewModel, ArtistAlbumsItemViewModel>
    {
        protected internal ArtistAlbumsItemViewCell(IntPtr handle)
            : base(handle)
        {
        }

        public static string CellId => nameof(ArtistAlbumsItemViewCell);

        public static float EstimatedHeight => AppDimens.Size12x;

        private ArtistAlbumsItemView View
        {
            get => (ArtistAlbumsItemView)base.View;
            set => base.View = value;
        }

        public override void LoadView()
        {
            View = new ArtistAlbumsItemView();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            SelectionStyle = UITableViewCellSelectionStyle.None;
        }

        public override void Bind(BindingSet<ArtistAlbumsItemViewModel> bindingSet)
        {
            base.Bind(bindingSet);

            bindingSet.Bind(View.AlbumNameLabel)
                .For(v => v.TextBinding())
                .To(vm => vm.Name);

            bindingSet.Bind(View.PlayCountLabel)
                .For(v => v.TextBinding())
                .To(vm => vm.PlayCount);

            bindingSet.Bind(View.AlbumImageView)
                .For(v => v.ImagePathBinding())
                .To(vm => vm.ImagePath);
        }

    }
}