using RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts;
using RrsChronosTimeSheet.Core.Application.Abstractions;

using MediatR;

namespace RrsChronosTimeSheet.Core.Application.Behaviors
{
    public class TransactionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IUnitOfWork _uow;

        public TransactionBehavior(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (request is not ICommand)
                return await next();

            await _uow.BeginTransactionAsync();

            try
            {
                var response = await next();
                await _uow.CommitAsync();
                return response;
            }
            catch
            {
                await _uow.RollbackAsync();
                throw;
            }
        }
    }
}
