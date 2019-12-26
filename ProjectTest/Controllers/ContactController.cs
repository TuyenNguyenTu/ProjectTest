using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectTest.Models;

namespace ProjectTest.Controllers
{
    public class ContactController : Controller
    {
        private MyBlogDbContext _context;
        public ContactController(MyBlogDbContext context)
        {
            _context = context;
        }
        [Route("/lien-he")]
        public IActionResult Index()
        {
            return View();
        }
    }
}