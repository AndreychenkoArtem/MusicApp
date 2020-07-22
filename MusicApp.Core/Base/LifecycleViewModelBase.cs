using System;
using System.Reactive.Disposables;
using System.Threading;
using FlexiMvvm.ViewModels;

namespace MusicApp.Core.Base
{
    public class LifecycleViewModelBase : LifecycleViewModel, IDisposable, ILifecycleAwareViewModel
    {
        private readonly CompositeDisposable _lifecycleDisposable = new CompositeDisposable();
        private CancellationTokenSource _lifecycleCancellationTokenSource = new CancellationTokenSource();
        private bool _disposed = false;

        public CompositeDisposable LifecycleDisposable
        {
            get => _lifecycleDisposable;
        }

        public CancellationToken LifecycleCancellationToken
        {
            get => _lifecycleCancellationTokenSource != null ?
                _lifecycleCancellationTokenSource.Token
                : new CancellationToken(true);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Dispose(bool disposing) executes in two distinct scenarios.
        // If disposing equals true, the method has been called directly
        // or indirectly by a user's code. Managed and unmanaged resources
        // can be disposed.
        // If disposing equals false, the method has been called by the
        // runtime from inside the finalizer and you should not reference
        // other objects. Only unmanaged resources can be disposed.
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _lifecycleDisposable?.Dispose();
                }

                _disposed = true;
            }
        }

        void ILifecycleAwareViewModel.OnActivate()
        {
            Interlocked.CompareExchange(ref _lifecycleCancellationTokenSource, new CancellationTokenSource(), null);
            OnActivate();
        }

        protected virtual void OnActivate()
        {
        }

        void ILifecycleAwareViewModel.OnDeactivate()
        {
            var previousTokenSource = Interlocked.Exchange(ref _lifecycleCancellationTokenSource, null);
            previousTokenSource?.Cancel();
            previousTokenSource?.Dispose();
            _lifecycleDisposable.Clear();
            OnDeactivate();
        }

        protected virtual void OnDeactivate()
        {
        }
    }

    public class LifecycleViewModelBase<TParameters> : LifecycleViewModel<TParameters>, IDisposable, ILifecycleAwareViewModel
         where TParameters : Parameters
    {
        private readonly CompositeDisposable _lifecycleDisposable = new CompositeDisposable();
        private CancellationTokenSource _lifecycleCancellationTokenSource = new CancellationTokenSource();
        private bool _disposed = false;

        public CompositeDisposable LifecycleDisposable
        {
            get => _lifecycleDisposable;
        }

        public CancellationToken LifecycleCancellationToken
        {
            get => _lifecycleCancellationTokenSource != null ?
                _lifecycleCancellationTokenSource.Token
                : new CancellationToken(true);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Dispose(bool disposing) executes in two distinct scenarios.
        // If disposing equals true, the method has been called directly
        // or indirectly by a user's code. Managed and unmanaged resources
        // can be disposed.
        // If disposing equals false, the method has been called by the
        // runtime from inside the finalizer and you should not reference
        // other objects. Only unmanaged resources can be disposed.
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _lifecycleDisposable?.Dispose();
                }

                _disposed = true;
            }
        }

        void ILifecycleAwareViewModel.OnActivate()
        {
            Interlocked.CompareExchange(ref _lifecycleCancellationTokenSource, new CancellationTokenSource(), null);
            OnActivate();
        }

        protected virtual void OnActivate()
        {
        }

        void ILifecycleAwareViewModel.OnDeactivate()
        {
            var previousTokenSource = Interlocked.Exchange(ref _lifecycleCancellationTokenSource, null);
            previousTokenSource?.Cancel();
            previousTokenSource?.Dispose();
            _lifecycleDisposable.Clear();
            OnDeactivate();
        }

        protected virtual void OnDeactivate()
        {
        }
    }
}