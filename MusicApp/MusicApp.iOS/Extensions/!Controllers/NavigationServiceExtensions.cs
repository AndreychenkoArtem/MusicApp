using FlexiMvvm.Navigation;
using UIKit;

namespace MusicApp.iOS.Extensions
{
    public static class NavigationServiceExtensions
    {
        public static T GetRootViewController<T>(this NavigationService navigationService)
            where T : class
        {
            return UIApplication.SharedApplication.KeyWindow.RootViewController as T;
        }
    }
}