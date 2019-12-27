using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectTest.Models;

namespace ProjectTest.Controllers
{

    public class HomeController : Controller
    {
        private readonly MyBlogDbContext context;
        public HomeController(MyBlogDbContext _context)
        {
            context = _context;
        }

        public IActionResult Index()
        {
            ViewBag.HotPosts = context.Posts.Where(x => x.Status == true).OrderByDescending(x => x.CreatedDate).Take(3).ToList();
            ViewBag.ListPost = context.Posts.Where(x => x.Status == true).Take(3).ToList();
            ViewBag.ListImage = context.Posts.Where(x => x.Status == true).ToList();
            ViewBag.ListBongDa = context.Posts.Where(x => x.Status == true && x.CategoryId == 6).Take(3).ToList();
            ViewBag.MotoGP = context.Posts.Where(x => x.Status == true && x.CategoryId == 5).Take(3).ToList();
            ViewBag.TheThaoQT = context.Posts.Where(x => x.Status == true && x.CategoryId == 7).Take(3).ToList();
            ViewBag.TinLienQuan = context.Posts.Where(x => x.Status == true && x.CategoryId == 4).Take(3).ToList();
            ViewBag.Slide = context.Slides.Where(x => x.Status == true).Take(3).OrderByDescending(x => x.CreatedDate).ToList();
            return View();
        }

    }
}
