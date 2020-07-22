using System.Threading.Tasks;
using FlexiMvvm.ViewModels;
using MusicApp.Core.Navigation;

namespace MusicApp.Core.ViewModels
{
    public class EntryViewModel : LifecycleViewModel
    {
        private readonly INavigationService _navigationService;

        public EntryViewModel(
            INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public override async Task InitializeAsync(bool recreated)
        {
            await base.InitializeAsync(recreated);

            if (!recreated)
            {
                NavigateToMain();
            }
        }

        private void NavigateToMain()
        {
            _navigationService.NavigateToMain(this);
        }
    }
}