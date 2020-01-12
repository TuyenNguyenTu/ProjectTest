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
        [Route("/lien-he")]
        public IActionResult Index()
        {
            return View();
        }
    }
}