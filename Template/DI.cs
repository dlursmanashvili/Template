using Template.Infrastructure.Repositories.Interfaces;
using Template.Infrastructure.Repositories.Repository;
using Template.Service.IServices;
using Template.Service.Services;

namespace Template.Api;

public static class DI
{
    public static void DependecyResolver(this IServiceCollection services)
    {
        services.AddScoped<ITemplateService, TemplateService>();

        services.AddScoped<ITemplateRepository, TemplateRepository>();
    }
}
