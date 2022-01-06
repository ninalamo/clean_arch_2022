using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SAFRA.SMCMS.MembershipService.Application.Behaviors
{
    public class ValidatorBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        #region Variable(s)
        private readonly ILogger<ValidatorBehavior<TRequest, TResponse>> _logger;
        private readonly IValidator<TRequest>[] _validators;
        #endregion

        #region Ctor

        public ValidatorBehavior(IValidator<TRequest>[] validators, ILogger<ValidatorBehavior<TRequest, TResponse>> logger)
        {
            _validators = validators;
            _logger = logger;
        }

        #endregion

        #region Public Method(s)
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var typeName = request.GetGenericTypeName();

            _logger.LogInformation("----- Validating command {CommandType}", typeName);

            var failures = _validators
                .Select(v => v.Validate(request))
                .SelectMany(result => result.Errors)
                .Where(error => error != null)
                .ToList();

            if (failures.Any())
            {
                _logger.LogWarning("Validation errors - {CommandType} - Command: {@Command} - Errors: {@ValidationErrors}", typeName, request, failures);

                throw new SpecialValidationException($"Command Validation Errors for type {typeof(TRequest).Name}.{Environment.NewLine} {string.Join(", ", failures.Select(x => x.ErrorMessage).ToArray())}");

            }

            return await next();
        }
        #endregion
    }
}