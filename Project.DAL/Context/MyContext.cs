using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project.DAL.DALModel;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.DAL.Context
{
    //Eğer kurmak istediğimiz VeriTabanı yapısında Identity kullancaksak DbContex'ten miras alamamalıyız. Çünkü Identity kendi tabloları tamamen hazı bir yapı kurar ve bu hazır yapıyı DbContex sağlayamazç Miras alacağımız sınıf IdentityDbContext olmalıdır.
    public class MyContext:IdentityDbContext
    {
        //
        public MyContext(DbContextOptions<MyContext> options):base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<AppUser> AppUsers { get; set; } //Custom olarak Identity'e eklenen sınıfları DbSet olarak burada oluşturmam gerek.

        //ayrı bir map katmanı açıp OnModelCreating metodumu ezip burada mappingleri ekleyeceğim...

    }
}
