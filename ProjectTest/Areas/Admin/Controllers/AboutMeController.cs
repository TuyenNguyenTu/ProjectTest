using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using ProjectTest.DAO;
using ProjectTest.Models;
using ReflectionIT.Mvc.Paging;

namespace ProjectTest.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutMeController : BaseController
    {
        private readonly MyBlogDbContext _context;
        private IHostingEnvironment hostingEnvironment;

        public AboutMeController(MyBlogDbContext context, IHostingEnvironment _hostingEnvironment)
        {
            _context = context;
            hostingEnvironment = _hostingEnvironment;
        }

        // GET: Admin/AboutMe
        public async Task<IActionResult> Index(string searchString, int page=1)
        {

            if (!string.IsNullOrEmpty(searchString))
            {
                var query = _context.AboutMes.Where(x=>x.Introduce.Contains(searchString)||x.Title.Contains(searchString)).AsNoTracking().OrderBy(x => x.CreatedDate);
                var model = await PagingList.CreateAsync(query, 2, page);
                ViewBag.search = searchString;
                return View(model);
            }
            else
            {
                var query = _context.AboutMes.AsNoTracking().OrderBy(x => x.CreatedDate);
                var model = await PagingList.CreateAsync(query, 2, page);
                return View(model);
            }
        }

        [Route("upload_ckeditor")]
        [HttpPost]
        public IActionResult UploadCKEditor(IFormFile upload)
        {
            var fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + upload.FileName.ToString();
            var path = Path.Combine(Directory.GetCurrentDirectory(), hostingEnvironment.WebRootPath, "uploads_admin", fileName);
            var stream = new FileStream(path, FileMode.Create);
            upload.CopyToAsync(stream);
            ViewBag.FileName = fileName;
            return new JsonResult(new { path = "/uploads_admin/" + fileName });
            
        }


        [Route("filebrowse")]
        [HttpGet]
        public IActionResult FileBrowse()
        {
            var direct = new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(), hostingEnvironment.WebRootPath, "uploads_admin"));
            ViewBag.fileInfos = direct.GetFiles();
            return View("FileBrowse");
        }

        public IActionResult Export()
        {
            var data = _context.AboutMes.OrderBy(x => x.Id).ToList();
            var stream = new MemoryStream();
            using(var pakage = new ExcelPackage(stream))
            {
                var sheet = pakage.Workbook.Worksheets.Add("Sheet 1");
                sheet.Cells.LoadFromCollection(data, true);
                pakage.Save();
            }
            stream.Position = 0;
            var fileName = $"ThongTinCaNhan_{DateTime.Now.ToString("yyyyMMddddHHmmss")}.xlsx";
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
        }

        // GET: Admin/AboutMe/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aboutMe = await _context.AboutMes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aboutMe == null)
            {
                return NotFound();
            }

            return View(aboutMe);
        }

        // GET: Admin/AboutMe/Create
        public IActionResult Create()
        {
            return View();
        }


        // POST: Admin/AboutMe/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Title,Introduce,Status,Note")] AboutMe aboutMe)
        {
            if (ModelState.IsValid)
            {
                aboutMe.MetaTitle = XuLyChuoi.GetMetaTitle(aboutMe.Title);
                aboutMe.CreatedDate = DateTime.Now;
                aboutMe.CreatedBy = HttpContext.Session.GetString("UserName");
                _context.Add(aboutMe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aboutMe);
        }

        // GET: Admin/AboutMe/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aboutMe = await _context.AboutMes.FindAsync(id);
            if (aboutMe == null)
            {
                return NotFound();
            }
            return View(aboutMe);
        }

        // POST: Admin/AboutMe/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,FirstName,LastName,Title,Introduce,CreatedBy,Status,Note")] AboutMe aboutMe)
        {
            if (id != aboutMe.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    AboutMe about = _context.AboutMes.Find(id);
                    about.FirstName = aboutMe.FirstName;
                    about.MetaTitle = XuLyChuoi.GetMetaTitle(aboutMe.Title);
                    about.Title = aboutMe.Title;
                    about.Introduce = aboutMe.Introduce;
                    about.Status = aboutMe.Status;
                    about.LastName = aboutMe.LastName;
                    about.ModifiedDate = DateTime.Now;
                    _context.Update(about);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AboutMeExists(aboutMe.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(aboutMe);
        }

        // GET: Admin/AboutMe/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aboutMe = await _context.AboutMes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aboutMe == null)
            {
                return NotFound();
            }

            return View(aboutMe);
        }

        // POST: Admin/AboutMe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var aboutMe = await _context.AboutMes.FindAsync(id);
            _context.AboutMes.Remove(aboutMe);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AboutMeExists(long id)
        {
            return _context.AboutMes.Any(e => e.Id == id);
        }
    }
}
