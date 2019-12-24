using Microsoft.AspNetCore.Mvc;
using ProjectTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTest.Components
{
    public class TopMenu :ViewComponent
    {
        private readonly MyBlogDbContext context;
        public TopMenu(MyBlogDbContext _context)
        {
            context = _context;
        }
        public IViewComponentResult Invoke()
        {
            var menu = context.Menus.Where(x => x.Status == true).ToList();
            return View(menu);
        }
    }
}
