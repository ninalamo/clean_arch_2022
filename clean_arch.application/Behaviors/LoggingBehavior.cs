using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace clean_arch.application.Behaviors
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        #region Variable(s)
        private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;
        #endregion

        #region Ctor

        public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger) => _logger = logger;

        #endregion

        #region Public Method(s)
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            _logger.LogInformation("----- Handling command {CommandName} ({@Command})", request.GetGenericTypeName(), request);
            var response = await next();
            _logger.LogInformation("----- Command {CommandName} handled - response: {@Response}", request.GetGenericTypeName(), "removed response");

            return response;
        }

        #endregion
    }
}