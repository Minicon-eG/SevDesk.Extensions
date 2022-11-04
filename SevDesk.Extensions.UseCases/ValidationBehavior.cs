using System.ComponentModel.DataAnnotations;
using MediatR;

namespace SevDesk.Extensions.UseCases;

public sealed class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
	where TRequest : class, IRequest<TResponse>
{
	public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
		CancellationToken cancellationToken)
	{
		List<ValidationResult> result = new();
		var context = new ValidationContext(request);
		_ = Validator.TryValidateObject(request, context, result);

		if (result.Count == 1) throw new ValidationException(result.Single().ErrorMessage);

		if (result.Count > 1)
			throw new AggregateException(
				$"Error validating {request.GetType().Name}",
				result
					.Select(item =>
						new ValidationException(
							$"Members: {string.Join(", ", item.MemberNames)} Error: {item.ErrorMessage}"
						)
					)
			);

		return await next();
	}
}