using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectTest.Areas.Admin.Models;
using ProjectTest.DAO;
using ProjectTest.Models;

namespace ProjectTest.Areas.Admin.Controllers
{
    [Route("api/chart")]
    public class ChartController : Controller
    {
        public readonly MyBlogDbContext context;
        public ChartController(MyBlogDbContext _context)
        {
            context = _context;
        }
        [HttpGet("viewchart")]
        [Produces("application/json")]
        public async Task<IActionResult> viewChart()
        {
            try
            {
                var model = from p in context.Posts
                            join cp in context.CategoryPosts on p.CategoryId equals cp.Id
                            group p by cp.CategoryName into gp
                            select new ChartViewModel()
                            {
                                CategoryName = gp.Key,
                                ViewCount = gp.Sum(x => x.ViewCount)
                                
                            };
                return  Ok(model.ToList());
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
    }
}