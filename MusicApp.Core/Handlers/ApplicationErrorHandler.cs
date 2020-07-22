using System;
using System.Threading;
using System.Threading.Tasks;
using FlexiMvvm.Operations;

namespace MusicApp.Core.Handlers
{
    public class ApplicationErrorHandler : IErrorHandler
    {
        public Task HandleAsync(OperationContext context, OperationError<Exception> error, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}