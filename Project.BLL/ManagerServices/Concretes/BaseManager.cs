using Project.BLL.ManagerServices.Abstarct;
using Project.DAL.Repositories.Abstarcts;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.BLL.ManagerServices.Concretes
{
    public class BaseManager<T> : IManager<T> where T : BaseEntity
    {
        protected IRepository<T> _irp; //protected yaptıkki dışarıya kapalı miras verdiği yere açık olsun
        public BaseManager(IRepository<T> irp)
        {
            _irp = irp;
        }
        public virtual string Add(T item) //virtual yaptık ProductRepository farklı ezer böylece.
        {
            if (item.CreatedDate!=null)
            {
                _irp.Add(item); //Burada dikkat, ManagerRepository'i kullandım.
                return "Ekleme Başarılı";
            }
            return "Ekleme Başarısız";
        }

        public List<T> GetAll()
        {
            return _irp.GetAll();
        }
    }
}
