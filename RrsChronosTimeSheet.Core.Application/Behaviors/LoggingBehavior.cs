using MediatR;
using Microsoft.Extensions.Logging;

namespace RrsChronosTimeSheet.Core.Application.Behaviors
{
    /// <summary>
    /// Behavior do MediatR para logging de requests e responses
    /// Executa antes e depois do handler
    /// </summary>
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : notnull
    {
        private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

        public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var requestName = typeof(TRequest).Name;
            _logger.LogInformation("Iniciando request: {RequestName}", requestName);
            _logger.LogDebug("Request details: {@Request}", request);

            try
            {
                var startTime = DateTime.UtcNow;
                var response = await next();
                var elapsedTime = DateTime.UtcNow - startTime;

                _logger.LogInformation("Request concluída: {RequestName} em {ElapsedMilliseconds}ms", 
                    requestName, elapsedTime.TotalMilliseconds);
                _logger.LogDebug("Response details: {@Response}", response);

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao processar request: {RequestName}", requestName);
                throw;
            }
        }
    }
}
