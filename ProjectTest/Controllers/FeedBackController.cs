using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ProjectTest.Controllers
{
    public class FeedBackController : Controller
    {
        [Route("/phan-hoi")]
        public IActionResult Index()
        {
            return View();
        }
    }
}