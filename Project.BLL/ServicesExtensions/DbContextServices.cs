using Microsoft.Extensions.DependencyInjection;
using Project.DAL.Context;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration; //nuget'dan indir  Castle'a dikkat et indirip kullanma!
using Microsoft.EntityFrameworkCore;


namespace Project.BLL.ServicesExtensions
{
    public static class DbContextServices
    {
        public static IServiceCollection AddDbContextService(this IServiceCollection services)
        {
            //sadece DbContext eklemek yetmez appsetting.json daki ConnectionStrings'e de ulaşmam gerkiyor. Sonucta buraya ulaşmazsam DbContex'e ulaşırım ama aderesi veremem.

            ServiceProvider provider = services.BuildServiceProvider();

            //appsetting.json'a ulaşmak için gerekli configuration ayarlarını istiyorum :
            IConfiguration configuration = provider.GetService<IConfiguration>();

            services.AddDbContextPool<MyContext>(options => options.UseSqlServer(configuration.GetConnectionString("MyConnection")).UseLazyLoadingProxies());

            return services;
        }
    }
}
