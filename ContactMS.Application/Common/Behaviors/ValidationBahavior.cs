using ErrorOr;
using FluentValidation;
using MediatR;

namespace ContactMS.Application.Common.Behaviors
{
    public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse : IErrorOr
    {
        private readonly IValidator<TRequest>? _validator;

        public ValidationBehaviour(IValidator<TRequest>? validator = null)
        {
            _validator = validator;
        }

        /// <summary>
        /// This pipeline check any validation error occure or not using fluent validation. If any validation error occure throw error other wise continue next 
        /// </summary>
        /// <param name="request">Command or query</param>
        /// <param name="next">Handler</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Errors or Handler</returns>
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validator is null)
            {
                return await next();
            }
            var validationResult = await _validator!.ValidateAsync(request, cancellationToken);
            if (validationResult.IsValid)
            {
                return await next();
            }
            var errors = validationResult.Errors.ConvertAll(validationFailure => Error.Validation(validationFailure.PropertyName, validationFailure.ErrorMessage));

            return (dynamic)errors;
        }
    }
}
