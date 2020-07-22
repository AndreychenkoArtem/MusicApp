using System.Threading;

namespace MusicApp.Core.Base
{
    public interface ILifecycleAwareViewModel
    {
        CancellationToken LifecycleCancellationToken { get; }

        void OnActivate();

        void OnDeactivate();
    }
}