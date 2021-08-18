using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Project.DAL.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.BLL.ServicesExtensions
{
    //Identity kullanıyorsak, [hazır Identity(User,Role,Authorize) sınıflarının, şifremi unuttum işlemlerinin, login, register bütün işlemlerinin hazır olduğu kütüphane]
    public static class IdentityExtensionService
    {
        public static IServiceCollection AddIdentityService(this IServiceCollection services)
        {
            services.AddIdentity<IdentityUser, IdentityRole>(x => { x.Password.RequireDigit = false; x.Password.RequireLowercase = false; x.Password.RequireUppercase = false; x.Password.RequireNonAlphanumeric = false; x.Password.RequiredLength = 5; }).AddEntityFrameworkStores<MyContext>();

            return services;
        }
    }
}
