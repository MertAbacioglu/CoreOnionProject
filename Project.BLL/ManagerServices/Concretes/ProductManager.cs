using Project.BLL.ManagerServices.Abstract;
using Project.DAL.Repositories.Abstarcts;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.BLL.ManagerServices.Concretes
{
    public class ProductManager:BaseManager<Product>,IProductManager
    {
        //BaseManager'ın cTor'unda D.Inj. yaptığımız için hata verir burada. Bende isterim der.Ben de bilmeliyim der.
        public ProductManager(IRepository<Product> prp):base(prp)
        {

        }

        public override string Add(Product item)
        {

            #region OverrideEtmekİstemezsek
            // return base.Add(item); dersek base'dekini kullanırız. Ben ise override etmek isteyebilirim aşağıdaki gibi.
            #endregion

            #region OverrideEtmekİstersek
            if (item.ProductName == null || item.ProductName.Trim() == "")
            {
                return "Ekleme başarısız...İsim hatası yada tarih hatası var";
            }
            _irp.Add(item);
            return "Ekleme başarılı";
            #endregion

        }
    }
}
