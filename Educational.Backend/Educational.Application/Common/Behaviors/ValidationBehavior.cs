﻿using FluentValidation;
using MediatR;

namespace Educational.Application.Common.Behaviors
{
    internal class ValidationBehavior<TRequest, TResponse> 
        : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            this.validators=validators;
        }

        public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var context = new ValidationContext<TRequest>(request);
            var failures = validators
                .Select(v => v.Validate(context))
                .SelectMany(r => r.Errors)
                .Where(failure => failure != null)
                .ToList();

            if(failures.Count != 0) 
            {
                throw new ValidationException(failures);
            }

            return next();
        }
    }
}
