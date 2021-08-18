using Project.DAL.Context;
using Project.DAL.Repositories.Abstarcts;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq; //Eklemeyi unutma ToList() çalışıramadım eklemeyi unutunca 

namespace Project.DAL.Repositories.Concretes
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        MyContext _db;
        public BaseRepository(MyContext db)
        {
            _db=db;
        }
        //Buradaki Add hiçbir şey sormadan direkt eklemeyi yapıcak
        //Bir şey soran yer Manager'daki Add olacak.
        public void Add(T item)
        {
            _db.Set<T>().Add(item);
            _db.SaveChanges();
        }

        public List<T> GetAll()
        {
            return _db.Set<T>().ToList();
        }
    }
}
