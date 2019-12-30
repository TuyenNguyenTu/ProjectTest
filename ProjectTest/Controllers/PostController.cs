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
        [Route("/bai-viet")]
        public async Task<IActionResult> Index(int page = 1)
        {
            var query = _context.Posts.Where(x => x.Status == true).AsNoTracking().OrderByDescending(x => x.CreatedDate);
            var model = await PagingList.CreateAsync(query, 5, page); 
            return View(model);
        }
        [HttpGet]
        [Route("chi-tiet-bai-viet/{slug}-{id:long}")]
        public ViewResult ViewPost(long id)
        {
            int setViewCount = 1;
            var result = _context.Posts.Find(id);
            result.ViewCount += setViewCount;
            _context.SaveChanges();
            var result1 = _context.Posts.Find(id);
            ViewBag.ViewCount = result1.ViewCount;
            ViewBag.LikePost = _context.Posts.Where(x => x.Status == true).Take(4).OrderByDescending(x => x.ViewCount);
            return View(result1);
        }


    }
}