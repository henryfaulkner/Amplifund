using Amplifund.Assignment.BL.Grants.Interactor;
using Microsoft.Extensions.DependencyInjection;
using Amplifund.Assignment.Data;

namespace Amplifund.Assignment.BL.Grants
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddGrantsBusiness(this IServiceCollection services)
        {
            services.AddTransient<IGrantsInteractor, GrantsInteractor>();
            services.AddAppData();
            return services;
        }
    }
}
