using Autofac;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Project.BLL.ManagerServices.Abstract;
using Project.BLL.ManagerServices.Concretes;
using Project.DAL.Context;
using Project.DAL.Repositories.Abstarcts;
using Project.DAL.Repositories.Concretes;
using System;
using System.Collections.Generic;
using System.Text;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Project.BLL.ManagerServices.Abstarct;
using Project.DAL.DALModel;

namespace Project.BLL.DependencyResolvers
{
    //Bu yapıyı program.cs'te tetikleyeceğim Startup'ta da tetiklenebilir elbet ama maksat kod temizliği ve kişisel tercihim.Ben middleware katmanında tetiklenmesini tercih etmedim.

    public class AutofacBusinnessModule : Module //Autofac kütüphanesinin Module isimli sınıfını kullandım. 
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(BaseRepository<>)).As(typeof(IRepository<>));
            builder.RegisterGeneric(typeof(BaseManager<>)).As(typeof(IManager<>));
            builder.RegisterType<ProductManager>().As<IProductManager>();
            builder.RegisterType<ProductRepository>().As<IProductRepository>();
            builder.RegisterType<CategoryManager>().As<ICategoryManager>();
            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>();
            builder.RegisterType<UserManagerSpecial>().As<IUserManagerSpecial>();
            builder.RegisterType<LoginManager>().As<ILoginManager>();

            #region DiğerSeçenekler
            /*
              Autofac'in kendisi AddScope olarak alıgılar

             builder.RegisterGeneric(typeof(BaseRepository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope =>AddTimeScop demektir

            builder.RegisterGeneric(typeof(BaseRepository<>)).As(typeof(IRepository<>)).InstancePerDependency() => Singleton Pattern

            builder.RegisterGeneric(typeof(BaseRepository<>)).As(typeof(IRepository<>)).InstancePerRequest() => Add Transemit demektir

             */
            #endregion

            //Load(ContainerBuilder builder,IServiceCollection) yazamadığım için el ile ekleyeceğim :
            IServiceCollection ni = new ServiceCollection();
            ni.AddIdentity<AppUser, IdentityRole>(x => { x.Password.RequireDigit = false; x.Password.RequireLowercase = false; x.Password.RequireUppercase = false; x.Password.RequireNonAlphanumeric = false; x.Password.RequiredLength = 5; }).AddEntityFrameworkStores<MyContext>();

            //Bu noktada kesinlikle builder, Populate metodu ile Identity eklenmiş olan ServiceCollection nesnesini almak zorundadır...Yoksa Identity tablolarınızı açsa bile onun işlemlerini kullanamayız. Yani DI Identity için çalışmaz.Sadece tablolar açılmış olur...

            //builder aslında bir extension metottur, kendisi Autofac'ın  extension metodlarında var.

           builder.Populate(ni); //böylece Identitiy'miz builder nesnemize eklenmiş oluyor.

            
            builder.Register(c =>
            {
                IConfiguration config = c.Resolve<IConfiguration>();
                DbContextOptionsBuilder<MyContext> opt = new DbContextOptionsBuilder<MyContext>();
                opt.UseSqlServer(config.GetSection("ConnectionStrings:MyConnection").Value).UseLazyLoadingProxies();
                return new MyContext(opt.Options);
            }).AsSelf().InstancePerLifetimeScope();

            //InstancePerLifetimeScope(); ile Scoped yapmak istedim.DInj olduğu için ordan oraya prametrik gödnermesi daha cok yorar DI yapısı database yönetimini hallediyor zaten.

        }

    }
}
