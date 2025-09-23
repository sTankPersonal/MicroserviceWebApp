using BuildingBlocks.CrossCutting.Correlation;
using BuildingBlocks.SharedKernel.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BuildingBlocks.CrossCutting.Validation
{
    public class DefaultValidationFilter(ICorrelationIdAccessor correlationIdAccessor) : IValidationFilter
    {
        private readonly ICorrelationIdAccessor _correlationIdAccessor = correlationIdAccessor;
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .ToDictionary(
                        kvp => kvp.Key,
                        kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                    );

                ErrorResponse response = new(
                    "Validation failed",
                    errors,
                    _correlationIdAccessor.GetCorrelationId()
                );

                context.Result = new BadRequestObjectResult(response);
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // No implementation needed
        }
    }
}
