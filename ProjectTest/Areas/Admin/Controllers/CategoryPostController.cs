using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectTest.Models;
using ProjectTest.Repository.InterfaceRepository;

namespace ProjectTest.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryPostController : Controller
    {
        private ICategoryPostRepository categoryPostRepository;
        public CategoryPostController(ICategoryPostRepository _categoryPostRepository)
        {
            categoryPostRepository = _categoryPostRepository;
        }
        public async Task<IActionResult> Index()
        {
            List<CategoryPost> listCategory =await categoryPostRepository.GetCategoryListPost();
            return View(listCategory);
        }
        public IActionResult Test()
        {
            return View();
        }
    }
}