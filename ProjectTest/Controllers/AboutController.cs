using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectTest.Models;

namespace ProjectTest.Controllers
{
    public class AboutController : Controller
    {
        MyBlogDbContext _context;
        public AboutController(MyBlogDbContext context)
        {
            _context = context;
        }
        [Route("/gioi-thieu")]
        public IActionResult Index()
        {
            ViewBag.DataAbout = _context.AboutMes.FirstOrDefault(x => x.Status == true);
            return View();
        }
    }
}