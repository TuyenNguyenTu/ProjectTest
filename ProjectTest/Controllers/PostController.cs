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
    public class PostController : Controller
    {
        MyBlogDbContext _context;
        public PostController(MyBlogDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(int page = 1)
        {
            var query = _context.Posts.Where(x => x.Status == true).AsNoTracking().OrderByDescending(x => x.CreatedDate);
            var model = await PagingList.CreateAsync(query, 5, page); 
            return View(model);
        }
        [Route("chi-tiet-bai-viet/{slug}-{id:long}")]
        public ViewResult ViewPost(long id)
        {
            var result = _context.Posts.Find(id);
            return View(result);
        }
    }
}