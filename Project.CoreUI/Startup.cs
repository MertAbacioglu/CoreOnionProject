using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.BLL.ServicesExtensions; //Elle ekledim.

namespace Project.CoreUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddAuthentication(); //Eklemeyi unutmayalım
            #region ManualTetiklemelerVsTheOther
            //Manual Extension yaptığımızda kullancağımız yöntemin içerisindeki metotları tetiklemek :

            // services.AddRepAndManServices(); => Extensions methodumuz ile servisimizi kullandım
            //services.AddDbContextService(); => Bu da DAL'ı kullanarak DbContext'imizi entegre edecektir

            //services.AddIdentityService(); =>Extensions methodumuz ile servisimizi kullandım
            //services.AddIdentity<MyContext> =>MyContext'i kullandık yine DAL'a ulaştık... 

            //Nihai amacım UI DAL'a ulaşmasın...
            #endregion


            #region Açıklamalar
            //N-Layered olmayan projelerde DI yapısı Core'da şu şekilde kurulur.
            //Core'un otomatik olarak hangi Interace'i nasıl algılayacağını belirten bir mimarisi vardır.Bu sisteme özellikle bir nesne göndermemize gerek yokturç.Ancak hangi Interface'in  olacağını belirlemeliyiz.
            #region AddScoped
            /* 
             * Bir istekte 1 instnce çıkarır
            //services.AddScoped<IProductRepository,ProductRepository>();

            public IActionResult(IProductRepository item1,IProductRepository item2)
            {

            return view();

;            }

            */
            #endregion

            #region AddTransient
            /*
             services.AddTransient<IProductRepository,ProductRepository>();
             Her sınıf teiklenişi için ayrı bir instance alır. 
             public IActionResult(IProductRepository item1,IProductRepositor item2)
             {

            return view();

;            }

             */

            #endregion

            //Yani projeye bir yerde IProductRepository gördüğünde ona nesne olarak ne gödnermeli onu öğrettik. Burada Instance alma işlemini bile biz yapmıyoruz.Bu instance alma işlemi Dependency Injection'ın Core'da otomatik olarak entegre edilmesiyle gerçekleşiyor. 

            //AddSingleton ilgili nesne için bir SingletonPattern görevi görürken , AddScope bir HttpRequest'i için sadece bir nesne alma görevi görürken AddTransient her class tetiklendiğinde bir nesne yaratan bir D. Injection işlemi yapar. 

            //Eğer katmanlı bir yapı kuruyorsak bu AddScoped olayını kendi mimarimize göre şekillendirmek zorundayız. Ya Autofac kütühanesi kullarak Injection Extension yapmak (yani Injection'ı genişletmek) ya da kendi Extension metodumuzu static sınıfta yaratarak bu Injecion Extension'ı manuel yapmak.
            #endregion

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseAuthentication(); //Eklemeyi unutmayalım

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Category}/{action=AddCategory}/{id?}");
            });
        }
    }
}
