using Project.DAL.Context;
using Project.DAL.Repositories.Abstarcts;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.DAL.Repositories.Concretes
{
    //services.AddScoped<ICategoryRepository>().As<CategoryRepository>(); diyebileceğiz artık. Bu şu anlama gelir : sen ICategoryRepository'i bir paramatre olarak görüdÜğün anda CategoryRepository instance'ını al.

    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(MyContext db) : base(db)
        {

        }
    }
}
