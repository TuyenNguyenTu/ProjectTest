using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectTest.Models;
using ReflectionIT.Mvc.Paging;

namespace ProjectTest.Controllers
{
    public class CategoriesPostController : Controller
    {
        private MyBlogDbContext context;
        public CategoriesPostController(MyBlogDbContext _context)
        {
            context = _context;
        }
        [Route("loai-baiviet/{slug}-{categoryID:long}")]
        public async Task<IActionResult> GetPostByCategory(long categoryID, int page=1)
        {
            var query = context.Posts.Where(x => x.Status == true && x.CategoryId == categoryID).AsNoTracking().OrderByDescending(x => x.CreatedDate);
            var model = await PagingList.CreateAsync(query, 5, page);
            return View(model);
        }
    }
}