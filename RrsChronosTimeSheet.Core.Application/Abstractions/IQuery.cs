using MediatR;

namespace RrsChronosTimeSheet.Core.Application.Abstractions
{
    public interface IQuery<out TResponse> : IRequest<TResponse>
    {
    }
}
