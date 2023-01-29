using Microsoft.Extensions.DependencyInjection;
using MediatR;

namespace RAWAPI.Application {
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection collection)
        {
            collection.AddMediatR(typeof(ServiceRegistration));
            collection.AddHttpClient();
        }
    }
}