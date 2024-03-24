using ContactSearch.Application.Persistence;
using ContactSearch.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ContactSearch.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ContactSearchDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("ContactSearchConnectionString"));
            });

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IEmailRepository, EmailRepository>();
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<IPhoneRepository, PhoneRepository>();

            return services;
        }
    }
}
