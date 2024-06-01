using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace BuildingBlocks.Behaviors;

public class LoggingBehavior<TRequest, TResponse>
    (ILogger<LoggingBehavior<TRequest, TResponse>> logger) : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull, IRequest<TResponse>
    where TResponse : notnull
{
    public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        logger.LogInformation("[Start ]Handle Request={Request} - response={Response} - RequestData={RequestData}",
            typeof(TRequest).Name, typeof(TResponse).Name, request);
        var timer = new Stopwatch();
        timer.Start();

        var response = next();

        timer.Stop();
        var timerTaken = timer.Elapsed;
        if (timerTaken.Seconds > 3) // if the request greater than 3 secods, then
            logger.LogWarning("[PERFORMANCE] The request {Request} took {TimerTaken}", typeof(TRequest).Name, timerTaken.Seconds);

        logger.LogInformation("[End] Handled {Request} with {Response}", typeof(TRequest).Name, typeof(TResponse).Name);
        return response;
    }
}
