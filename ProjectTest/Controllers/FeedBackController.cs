using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using ProjectTest.Models;

namespace ProjectTest.Controllers
{
    public class FeedBackController : Controller
    {
        private readonly MyBlogDbContext _context;
        public FeedBackController(MyBlogDbContext context)
        {
            _context = context;
        }
        [Route("/phan-hoi")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [Route("/phan-hoi")]
        public IActionResult Index(FeedBack fb)
        {
            if (ModelState.IsValid)
            {
                fb.CreatedDate = DateTime.Now;               
                _context.FeedBacks.Add(fb);
                _context.SaveChanges();
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Tin Tức", "onethrowgosu98@gmail.com"));
                message.To.Add(new MailboxAddress("naren", "nguyentutuyen444@gmail.com"));
                message.Subject = "Test mail";
                message.Body = new TextPart("plain")
                {
                    Text = "Tên: " + fb.Name + "\n" +
                    "Email: " + fb.Email + "\n" +
                    "SĐT: " + fb.Phone + "\n" +
                    "Địa chỉ: " + fb.Address +
                    "\n" + "Nội dung: " + fb.Contents
                };
                using (var client = new SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 587, false);
                    client.Authenticate("onethrowgosu98@gmail.com", "01626557355");
                    client.Send(message);

                    client.Disconnect(true);
                }
            }
            ViewBag.xinchao = "Success";
            return View();
        }
    }
}