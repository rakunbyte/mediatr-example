using MediatR;
using Microsoft.Extensions.Logging;

namespace Models.Behaviors;

public class LoggingBehavior<TRequest, TResponse>(ILogger<LoggingBehavior<TRequest, TResponse>> logger) : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken) 
    {
        logger.LogInformation($"Handling {typeof(TRequest).Name} : {request}"); 
        var response = await next(); 
            
        logger.LogInformation($"Handled {typeof(TResponse).Name} : {next.Method.Name}"); 
        logger.LogInformation($"---------------------------------------"); 
            
        return response;
    }
}