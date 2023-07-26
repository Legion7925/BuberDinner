using BubberDinner.Api.Common.Errors;
using BubberDinner.Api.Common.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace BubberDinner.Api.Extensions;

public static class IServiceCollectionExtensions
{
    public static void AddPresentationLayer(this IServiceCollection services)
    {
        //builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttribute>());
        services.AddControllers();
        services.AddSingleton<ProblemDetailsFactory, BubberDinnerProblemDetailsFactory>();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddMappings();
    }
}
 