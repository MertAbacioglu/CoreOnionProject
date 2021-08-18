using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.BLL.ManagerServices.Abstarct
{
    public interface IManager<T> where T:BaseEntity
    {
        string Add(T item); //Bunun kullandığı şey Repository'deki Add(); methodu olacak.Yeri gelir hata mesajı döndürür. UI'da bunu kullanacak
        List<T> GetAll();

    }
}
