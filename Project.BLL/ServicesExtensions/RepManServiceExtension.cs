using Microsoft.Extensions.DependencyInjection;
using Project.BLL.ManagerServices.Abstarct;
using Project.BLL.ManagerServices.Abstract;
using Project.BLL.ManagerServices.Concretes;
using Project.DAL.Repositories.Abstarcts;
using Project.DAL.Repositories.Concretes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.BLL.ServicesExtensions
{
    public static class RepManServiceExtension
    {
        //Benim burada öyle yapı kurmam lazımki Startup'ın UI'da  DInj.'ı .NetCore sunabilmesi için onu tatmin etmem lazım. Servis ayarlamaları IServiceCollection gerektirir. Öyle bir ypı kurayım ki ben Sturtup'ta sadece BLL'i kullanayım DAL'ı işe karıştırmayayım ,DAL'a ulaşan BLL olsun.

        public static IServiceCollection AddRepAndManServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(IManager<>), typeof(BaseManager<>));
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductManager, ProductManager>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryManager, CategoryManager>();

            return services;

        }
    }
}
