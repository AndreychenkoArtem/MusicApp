using FlexiMvvm.Persistence.Core;
using FlexiMvvm.ViewModels;
using FlexiMvvm.Views;
using MusicApp.Core.Base;

namespace MusicApp.iOS.Base
{
    public class BindableViewControllerBase<TViewModel> : FlexiBindableViewController<TViewModel>
        where TViewModel : class, ILifecycleViewModelWithoutParameters, IStateOwner
    {
        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            var awareViewModel = ViewModel as ILifecycleAwareViewModel;
            awareViewModel?.OnActivate();
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);

            var awareViewModel = ViewModel as ILifecycleAwareViewModel;
            awareViewModel?.OnDeactivate();
        }
    }

    public class BindableViewControllerBase<TViewModel, TParameters> : FlexiBindableViewController<TViewModel, TParameters>
        where TViewModel : class, ILifecycleViewModelWithParameters<TParameters>, IStateOwner
        where TParameters : Parameters
    {
        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            var awareViewModel = ViewModel as ILifecycleAwareViewModel;
            awareViewModel?.OnActivate();
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);

            var awareViewModel = ViewModel as ILifecycleAwareViewModel;
            awareViewModel?.OnDeactivate();
        }
    }
}