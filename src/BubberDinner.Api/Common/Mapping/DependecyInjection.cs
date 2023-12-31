﻿using Mapster;
using MapsterMapper;
using System.Reflection;

namespace BubberDinner.Api.Common.Mapping;

public static class DependecyInjection
{
    public static void AddMappings(this IServiceCollection services)
    {
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(Assembly.GetExecutingAssembly());
        services.AddSingleton(config);
        services.AddScoped<IMapper, ServiceMapper>();
    }
}
