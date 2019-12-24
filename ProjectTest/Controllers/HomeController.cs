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
            return View();
        }

        public IActionResult MainMenu()
        {
            ViewBag.Hello = "Hello";
            return View();
        }
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult TestView()
        {
            ViewBag.HotPosts = context.Posts.Where(x => x.Status == true).OrderByDescending(x => x.CreatedDate).Take(3).ToList();
            ViewBag.ListPost = context.Posts.Where(x => x.Status == true).Take(3).ToList();
            ViewBag.ListImage = context.Posts.Where(x => x.Status == true).ToList();
            ViewBag.ListBongDa = context.Posts.Where(x => x.Status == true && x.CategoryId == 6).Take(3).ToList();
            ViewBag.MotoGP = context.Posts.Where(x => x.Status == true && x.CategoryId == 5).Take(3).ToList();
            return View();
        }
    }
}
