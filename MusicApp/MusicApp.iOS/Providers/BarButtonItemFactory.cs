using MusicApp.iOS.Theme;
using UIKit;

namespace MusicApp.iOS.Providers
{
    public static class BarButtonItemFactory
    {
        public static UIBarButtonItem CreateBackButtonItem()
        {
            var backButtonItem = new UIBarButtonItem(
                AppImages.GetBack24Icon().ImageWithRenderingMode(UIImageRenderingMode.AlwaysOriginal),
                UIBarButtonItemStyle.Plain,
                null);

            return backButtonItem;
        }
    }
}