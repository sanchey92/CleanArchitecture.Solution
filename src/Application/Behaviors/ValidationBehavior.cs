using Domain.Exceptions.Base;
using FluentValidation;
using MediatR;

namespace Application.Behaviors;

/// <summary>
/// Pipeline behavior for request validation using FluentValidation.
/// </summary>
/// <typeparam name="TRequest">The type of the request.</typeparam>
/// <typeparam name="TResponse">The type of the response.</typeparam>
public sealed class ValidationBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    /// <summary>
    /// Initializes a new instance of the <see cref="ValidationBehavior{TRequest, TResponse}"/> class.
    /// </summary>
    /// <param name="validators">The collection of validators for the request.</param>
    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    /// <summary>
    /// Handles the request validation and invokes the next middleware in the pipeline.
    /// </summary>
    /// <param name="request">The request to be validated.</param>
    /// <param name="next">The delegate to invoke the next middleware in the pipeline.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The task representing the asynchronous operation.</returns>
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (!_validators.Any())
        {
            return await next();
        }

        var context = new ValidationContext<TRequest>(request);

        var errorsDictionary = _validators
            .Select(x => x.Validate(context))
            .SelectMany(x => x.Errors)
            .Where(x => x != null)
            .GroupBy(
                x => x.PropertyName.Substring(x.PropertyName.IndexOf('.') + 1),
                x => x.ErrorMessage,
                (propertyName, errorMessage) => new
                {
                    Key = propertyName,
                    Values = errorMessage.Distinct().ToArray()
                })
            .ToDictionary(x => x.Key, x => x.Values);

        if (errorsDictionary.Count != 0)
        {
            throw new ValidationApiException(errorsDictionary);
        }

        return await next();
    }
}