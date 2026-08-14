using MediatR;

namespace RrsChronosTimeSheet.Core.Application.Abstractions
{
    public interface ICommand<TResponse> : IRequest<TResponse>
    {
    }

    public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, TResponse>
        where TCommand : ICommand<TResponse>
    {
    }
}
