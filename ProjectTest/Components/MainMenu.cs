using Microsoft.AspNetCore.Mvc;
using ProjectTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTest.Components
{
    public class MainMenu : ViewComponent
    {
        private readonly MyBlogDbContext context;
        public MainMenu(MyBlogDbContext _context)
        {
            context = _context;
        }
        public IViewComponentResult Invoke()
        {
            var menu = context.CategoryPosts.OrderBy(x => x.CategoryName);
            return View(menu);
        }
    }
}
