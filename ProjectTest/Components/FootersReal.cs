using Microsoft.AspNetCore.Mvc;
using ProjectTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTest.Components
{
    public class FootersReal : ViewComponent
    {
        private readonly MyBlogDbContext context;
        public FootersReal(MyBlogDbContext _context)
        {
            context = _context;
        }
        public IViewComponentResult Invoke()
        {
            var footer = context.Footers.Where(x => x.Status == true).First();
            return View(footer);
        }
    }
}
