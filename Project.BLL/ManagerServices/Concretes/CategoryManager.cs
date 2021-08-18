using Project.BLL.ManagerServices.Abstract;
using Project.DAL.Repositories.Abstarcts;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.BLL.ManagerServices.Concretes
{
    public class CategoryManager:BaseManager<Category>,ICategoryManager
    {
        public CategoryManager(IRepository<Category> crp):base(crp)
        {

        }

        //CategoryManager için override yapmadım.Farklılık olsun...
    }
}
