using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace ProjectTest.Controllers
{
    public class FeedBackController : Controller
    {
        [Route("/phan-hoi")]
        public IActionResult Index()
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Tin Tức", "onethrowgosu98@gmail.com"));
            message.To.Add(new MailboxAddress("naren", "nguyentutuyen45@gmail.com"));
            message.Subject = "Test mail";
            message.Body = new TextPart("plain")
            {
                Text = "HelloWorld"
            };
            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587,false);
                client.Authenticate("onethrowgosu98@gmail.com", "01626557355");
                client.Send(message);
                ViewBag.Success = "thành công";
                client.Disconnect(true);
            }

            return View();
        }
    }
}