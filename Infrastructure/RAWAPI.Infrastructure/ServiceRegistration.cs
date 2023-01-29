using RAWAPI.Application.Abstractions.Services.Configurations;
using RAWAPI.Application.Abstractions.Token;
using RAWAPI.Infrastructure.Services.Configurations;
using RAWAPI.Infrastructure.Services.Token;
using Microsoft.Extensions.DependencyInjection;
using RAWAPI.Application.Abstractions.Services;
using RAWAPI.Infrastructure.Services;
using RAWAPI.Application.Abstractions.Storage;
using RAWAPI.Infrastructure.Services.Storage;
using RAWAPI.Infrastructure.Services.Storage.Local;
using RAWAPI.Infrastructure.Enums;
using RAWAPI.Infrastructure.Services.Storage.Azure;

namespace RAWAPI.Infrastructure {
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IStorageService, StorageService>();
            serviceCollection.AddScoped<ITokenHandler, TokenHandler>();
            serviceCollection.AddScoped<IMailService, MailService>();
            serviceCollection.AddScoped<IApplicationService, ApplicationService>();
        }
        public static void AddStorage<T>(this IServiceCollection serviceCollection) where T : Storage, IStorage {
            serviceCollection.AddScoped<IStorage, T>();
        }
        public static void AddStorage(this IServiceCollection serviceCollection, StorageType storageType) {
            switch (storageType) {
                case StorageType.Local:
                    serviceCollection.AddScoped<IStorage, LocalStorage>();
                    break;
                case StorageType.Azure:
                    serviceCollection.AddScoped<IStorage, AzureStorage>();
                    break;
                case StorageType.AWS:

                    break;
                default:
                    serviceCollection.AddScoped<IStorage, LocalStorage>();
                    break;
            }
        }
    }
}
