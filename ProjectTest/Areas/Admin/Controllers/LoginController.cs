using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectTest.Areas.Admin.Models;
using ProjectTest.Common;
using ProjectTest.DAO;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using ProjectTest.Models;

namespace ProjectTest.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        private MyBlogDbContext context;
        public LoginController(MyBlogDbContext _context)
        {
            context = _context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            ViewBag.Title = "Login Page";
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var result = context.Accounts.SingleOrDefault(x => x.UserName == model.UserName);
                if (result == null)
                {
                    ModelState.AddModelError("", "Không tồn tại tài khoản ");
                }
                else if (result.PassWord == model.Password)
                {
                    if (result.Status == true)
                    {
                        if (result.IsAdmin == true)
                        {
                            if (result.PassWord == model.Password)
                            {

                                HttpContext.Session.SetString("UserName", model.UserName);
                                return RedirectToAction("Index", "Home");
                            }
                            else
                            {
                                ModelState.AddModelError("", "Sai mật khẩu");
                            }

                        }
                        else
                        {
                            ModelState.AddModelError("", "Tài khoản không được cấp phép");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Tài khoản đang bị khóa");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Mật khẩu sai");
                }
              
                //else if (result == -1)
                //{

                //}
                //else
                //{
                //    ModelState.AddModelError("", "Sai mật khẩu");
                //}
            }
            return View("Index");
        }
        [Route("logout")]
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("UserName");
            return RedirectToAction("Index");
        }
    }
}