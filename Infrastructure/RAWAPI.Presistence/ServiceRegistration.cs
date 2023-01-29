using Microsoft.Extensions.DependencyInjection;
using RAWAPI.Domain.Entities.Identity;
using RAWAPI.Application.Abstractions.Services;
using RAWAPI.Application.Abstractions.Services.Authentications;
using Microsoft.AspNetCore.Identity;
using RAWAPI.Presistence.Context;
using Microsoft.EntityFrameworkCore;
using RAWAPI.Presistence.Repositories.Endpoint;
using RAWAPI.Presistence.Repositories.Menu;
using RAWAPI.Application.Repositories.Menu;
using RAWAPI.Presistence.Services;
using RAWAPI.Application.Repositories.Endpoint;
using RAWAPI.Application.Repositories.Profile;
using RAWAPI.Presistence.Repositories.Profile;
using RAWAPI.Application.Repositories.Content;
using RAWAPI.Presistence.Repositories.ContentRepository;
using RAWAPI.Application.Repositories.ContentRate;
using RAWAPI.Presistence.Repositories.ContentRate;

namespace RAWAPI.Presistence {
    public static class ServiceRegistration {
        public static void AddPersistenceServices(this IServiceCollection services) {
            services.AddDbContext<RawDbContext>(options => options.UseSqlServer(Configuration.getConnectionString()));
            services.AddIdentity<AppUser, AppRole>(options => {
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
            }).AddEntityFrameworkStores<RawDbContext>()
            .AddDefaultTokenProviders();

            //services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
            //services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();
            //services.AddScoped<IOrderReadRepository, OrderReadRepository>();
            //services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
            //services.AddScoped<IProductReadRepository, ProductReadRepository>();
            //services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
            //services.AddScoped<IFileReadRepository, FileReadRepository>();
            //services.AddScoped<IFileWriteRepository, FileWriteRepository>();
            //services.AddScoped<IProductImageFileReadRepository, ProductImageFileReadRepository>();
            //services.AddScoped<IProductImageFileWriteRepository, ProductImageFileWriteRepository>();
            //services.AddScoped<IInvoiceFileReadRepository, InvoiceFileReadRepository>();
            //services.AddScoped<IInvoiceFileWriteRepository, InvoiceFileWriteRepository>();
            services.AddScoped<IContentReadRepository, ContentReadRepository>();
            services.AddScoped<IContentRateReadRepository, ContentRateReadRepository>();
            services.AddScoped<IContentRateWriteRepository, ContentRateWriteRepository>();
            services.AddScoped<IContentWriteRepository, ContentWriteRepository>();
            services.AddScoped<ICommentReadRepository, CommentReadRepository>();
            services.AddScoped<ICommentWriteRepository, CommentWriteRepository>();
            //services.AddScoped<ICompletedOrderReadRepository, CompletedOrderReadRepository>();
            //services.AddScoped<ICompletedOrderWriteRepository, CompletedOrderWriteRepository>();
            services.AddScoped<IEndpointReadRepository, EndpointReadRepository>();
            services.AddScoped<IEndpointWriteRepository, EndpointWriteRepository>();
            services.AddScoped<IMenuReadRepository, MenuReadRepository>();
            services.AddScoped<IMenuWriteRepository, MenuWriteRepository>();
            services.AddScoped<IProfileWriteRepository, ProfileWriteRepository>();
            services.AddScoped<IProfileReadRepository, ProfileReadRepository>();


            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IExternalAuthentication, AuthService>();
            services.AddScoped<IInternalAuthentication, AuthService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IAuthorizationEndpointService, AuthorizationEndpointService>();
        }
    }
}
