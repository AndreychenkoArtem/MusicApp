using System;
using FlexiMvvm.Bindings;
using FlexiMvvm.Collections;
using FlexiMvvm.Views;
using MusicApp.Core.ViewModels.MainMusic;
using MusicApp.iOS.Base;
using MusicApp.iOS.Extensions;
using MusicApp.iOS.Theme;
using UIKit;

namespace MusicApp.iOS.Views.MainMusic
{
    public class MainMusicItemViewCell : TableViewBindableItemCellBase<MainMusicViewModel, MainMusicItemViewModel>
    {
        protected internal MainMusicItemViewCell(IntPtr handle)
            : base(handle)
        {
        }

        public static string CellId => nameof(MainMusicItemViewCell);

        public static float EstimatedHeight => AppDimens.Size12x;

        private MainMusicItemView View
        {
            get => (MainMusicItemView)base.View;
            set => base.View = value;
        }

        public override void LoadView()
        {
            View = new MainMusicItemView();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            SelectionStyle = UITableViewCellSelectionStyle.None;
        }

        public override void Bind(BindingSet<MainMusicItemViewModel> bindingSet)
        {
            base.Bind(bindingSet);

            bindingSet.Bind(View.ArtistNameLabel)
                .For(v => v.TextBinding())
                .To(vm => vm.ArtistName);

            bindingSet.Bind(View.ListenersCountLabel)
                .For(v => v.TextBinding())
                .To(vm => vm.Listeners);

            bindingSet.Bind(View.ArtistPhotoImageView)
                .For(v => v.ImagePathBinding())
                .To(vm => vm.ImagePath);
        }
    }
}