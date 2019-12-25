using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectTest.Models;

namespace ProjectTest.Controllers
{
    public class PostController : Controller
    {
        MyBlogDbContext _context;
        public PostController(MyBlogDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}