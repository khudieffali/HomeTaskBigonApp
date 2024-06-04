using Bigon.Data.Persistance;
using Bigon.Infrastructure.Commons.Abstracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bigon.Data
{
    public static class DataServiceInjection
    {
        public static IServiceCollection InstallDataServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DbContext, DataContext>(cfg =>
            {
                cfg.UseSqlServer(configuration.GetConnectionString("BigonDB"),
                opt =>
           {
               opt.MigrationsHistoryTable("Migrations");
           });
            });
            var repoInterfaceType = typeof(IRepository<>);
            var concretRepositoryAssembly = typeof(DataServiceInjection).Assembly;
            var repositoryPairs = repoInterfaceType.Assembly
                .GetTypes()
                .Where(m=>m.IsInterface && m.GetInterfaces().Any(i=>i.IsGenericType && i.GetGenericTypeDefinition()==repoInterfaceType))
                .Select(m=> new
                {
                    AbstractRepository=m,
                    ConcrateRepository=concretRepositoryAssembly.GetTypes().FirstOrDefault(r=>r.IsClass && m.IsAssignableFrom(r)),
                })
                .Where(x=>x.ConcrateRepository !=null);
            foreach (var item in repositoryPairs)
            {
                services.AddScoped(item.AbstractRepository, item.ConcrateRepository!);
            }
            return services;
        }
    }
}
