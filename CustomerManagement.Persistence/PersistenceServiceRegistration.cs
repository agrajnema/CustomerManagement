using CustomerManagement.Application.Contracts.Persistence;
using CustomerManagement.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CustomerManagementDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("CustomerDBConnectionString"));
                //In memory DB used for integration test
                //options.UseInMemoryDatabase("CustomerDB");
            });

            var sp = services.BuildServiceProvider();

            using (var scope = sp.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var context = scopedServices.GetRequiredService<CustomerManagementDbContext>();
                
                context.Database.Migrate();
            }
                services.AddScoped(typeof(IGenericAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            return services;
        }
    }
}
