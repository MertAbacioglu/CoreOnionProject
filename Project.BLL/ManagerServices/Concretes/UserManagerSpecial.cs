using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Project.BLL.ManagerServices.Abstract;
using Project.DAL.DALModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.ManagerServices.Concretes
{
    public class UserManagerSpecial : IUserManagerSpecial
    {
        //önce Identity'yi tetikleyecek yapıları yazıyoruz :
        UserManager<AppUser> _umanager;
        SignInManager<AppUser> _smanager;
        public UserManagerSpecial(UserManager<AppUser> umanager, SignInManager<AppUser> smanager)
        {
            _umanager = umanager;
            _smanager = smanager;
        }
        public async Task<bool> AddUser(AppUser item)
        {
            //UserManager CreateAsync istediğimiz kullanıcıyı eklememize sağayan metottur.hatta istersek şifresini bile Hashleyebiliriz. CreateAsync bize Task Result döndürür(yani ilgili metot başarılı oldu mu olmadı mı).

            //aşağıda içerdeki generic tip tipinde(IdentityResult) döndürdü.Await koymasaydık mecburi Task koyacaktık dönüş tipine yani şöyle olurdu:
            //Task<IdentityResult> a =_umanager.CreateAsync(item, item.PasswordHash); 

            IdentityResult result = await _umanager.CreateAsync(item, item.PasswordHash);

            if (result.Succeeded)
            {
                //SignInAsync metodu kişinin login olmasını sağayan bir SignInManager methoduduru.İki argüman alır ; kim login olmuş...Login durumu SessionCookie'mi (yani browser kapandığında kapanacak mı) yoksa Persisten mı(yani browser kapandığında kalacak mı mı).Ben browser kapanınca kapandığını seçtim.

                await _smanager.SignInAsync(item, isPersistent: false); //kişi hem register olsun hem login olsun
                return true; // kişi login olmuşsa 

            }
            return false;
        }
    }
}
