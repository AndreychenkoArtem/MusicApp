using CoreGraphics;
using MusicApp.iOS.Theme;
using UIKit;

namespace MusicApp.iOS.Extensions
{
    public static class ControlsStyleExtensions
    {
        private const string IntroRust = "Intro Rust";

        public static void SetToolbarStyle(
            this UINavigationBar navigationBar,
            bool dropShadow = true)
        {
            var stylizedStringAttributes = new StylizedStringAttributes(
                UIFont.FromName(IntroRust, 14),
                UIColor.White,
                0.5f,
                1f,
                StylizedStringCase.Upper,
                UITextAlignment.Center);

            navigationBar.Translucent = false;
            navigationBar.StandardAppearance.TitleTextAttributes = stylizedStringAttributes.StringAttributes;
            navigationBar.StandardAppearance.BackgroundColor = UIColor.Blue;
            navigationBar.StandardAppearance.ShadowImage = new UIImage();
            navigationBar.SetViewWithShadowStyle(2, 0.4f, 2.0, 2.0, UIColor.LightGray);

            if (!dropShadow)
            {
                navigationBar.StandardAppearance.ShadowColor = UIColor.Clear;
            }
        }

        public static UIView SetViewWithShadowStyle(this UIView view,
            float radius = 4,
            float opacity = 1,
            double offsetWidth = 2,
            double offsetHeight = 2,
            UIColor color = null)
        {
            view.Layer.MasksToBounds = false;
            view.Layer.ShadowColor = color != null ? color.CGColor : UIColor.Black.CGColor;
            view.Layer.ShadowOffset = new CGSize(offsetWidth, offsetHeight);
            view.Layer.ShadowRadius = radius;
            view.Layer.ShadowOpacity = opacity;

            return view;
        }
    }
}