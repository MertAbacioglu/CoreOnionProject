using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.ManagerServices.Abstract;
using Project.CoreUI.Models.PageVM;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.CoreUI.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        ICategoryManager _icm;
        public CategoryController(ICategoryManager icm)
        {
            _icm = icm;
        }
        public IActionResult Index()
        {
            return View();
        }
        //[AllowAnonymous]  //Bu attribute ile sadece burada Authorization uygulanmaz
        public IActionResult CategoryList()
        {
            CategoryPageVM cpvm = new CategoryPageVM
            {
                Categories = _icm.GetAll()
            };
            return View(cpvm);
        }

        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            TempData["message"] = _icm.Add(category);
            return RedirectToAction("AddCategory");
        }
    }
}
