using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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

        public AboutMeController(MyBlogDbContext context)
        {
            _context = context;
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

        public IActionResult Export()
        {
            var data = _context.AboutMes.OrderBy(x => x.Id).ToList();
            var stream = new MemoryStream();
            using(var pakage = new ExcelPackage(stream))
            {
                var sheet = pakage.Workbook.Worksheets.Add("Sheet 1");
                sheet.Cells.LoadFromCollection(data, true);
                //sheet.Cells[1, 1].Value = "Họ";
                //sheet.Cells[1, 2].Value = "Tên";
                //sheet.Cells[1, 3].Value = "Tiêu đề";
                //sheet.Cells[1, 4].Value = "Giới thiệu";
                //sheet.Cells[1, 5].Value = "Ngày viết bài";
                //sheet.Cells[1, 6].Value = "Người viết bài";
                //int rowIndex = 2;
                //foreach (var item in data)
                //{
                //    sheet.Cells[rowIndex, 1].Value = item.FirstName;
                //    sheet.Cells[rowIndex, 2].Value = item.LastName;
                //    sheet.Cells[rowIndex, 3].Value = item.Title;
                //    sheet.Cells[rowIndex, 4].Value = item.Introduce;
                //    sheet.Cells[rowIndex, 5].Value = item.CreatedDate;
                //    sheet.Cells[rowIndex, 6].Value = item.CreatedBy;
                //}
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
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Title,Introduce,Image,Status,Note")] AboutMe aboutMe)
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
        public async Task<IActionResult> Edit(long id, [Bind("Id,FirstName,LastName,Title,Introduce,Image,CreatedBy,Status,Note")] AboutMe aboutMe)
        {
            if (id != aboutMe.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    aboutMe.MetaTitle = XuLyChuoi.GetMetaTitle(aboutMe.Title);
                    aboutMe.ModifiedDate = DateTime.Now;
                    _context.Update(aboutMe);
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
