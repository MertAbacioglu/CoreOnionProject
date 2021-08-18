using Microsoft.AspNetCore.Identity;
using Project.DAL.DALModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.ManagerServices.Abstract
{
    //Identity aslında bir API'dır.Bize belirli Crud-Login işlemlerinin yapılmasına fırsat veren bir API'dır.
    //Identity kulanıyorsak Async metotlar ie çalışma durumundayız.Çünkü Async metotlarla çalışmazsak API'a belirli istekler gediğinde, API nın belli bir modülünde hata meydana geldiğinde birini tamamlayamadan bir başka modüe hizmet veremez.Asyn metotlar ise birine bir istek geldiinde onda hata çıksa bile bir diğer modülün çalışması için hata çıkan modülün tamamlanmasını beklemez.
    public interface IUserManagerSpecial
    {
        //normal metodum Async çalışmak istiyorsa başına Task alır.
        //Benim user'ım yok henüz.Identity'den gelicek. İstersem ben kendi User'ımı Identity'e çevirebilirim ama önce olmadan yapıcam.

        
        Task<bool> AddUser(AppUser item);

    }
}
