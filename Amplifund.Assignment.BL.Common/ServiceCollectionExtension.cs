using Amplifund.Assignment.BL.Common.Interactor;
using Microsoft.Extensions.DependencyInjection;
using Amplifund.Assignment.Data;

namespace Amplifund.Assignment.BL.Common
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddCommonBusiness(this IServiceCollection services)
        {
            services.AddTransient<ICommonInteractor, CommonInteractor>();
            services.AddAppData();
            return services;
        }
    }
}
