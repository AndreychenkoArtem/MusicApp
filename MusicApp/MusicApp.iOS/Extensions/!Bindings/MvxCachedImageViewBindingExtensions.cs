using FFImageLoading.Cross;
using FlexiMvvm.Bindings;
using FlexiMvvm.Bindings.Custom;

namespace MusicApp.iOS.Extensions
{
    public static class MvxCachedImageViewBindingExtensions
    {
        public static TargetItemBinding<MvxCachedImageView, string> ImagePathBinding(
            this IItemReference<MvxCachedImageView> imageViewReference)
        {
            return new TargetItemOneWayCustomBinding<MvxCachedImageView, string>(
                imageViewReference,
                (imageView, imagePath) => imageView.ImagePath = imagePath,
                () => nameof(MvxCachedImageView.ImagePath));
        }
    }
}