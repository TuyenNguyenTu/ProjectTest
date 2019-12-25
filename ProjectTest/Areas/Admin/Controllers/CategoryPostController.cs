using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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
    public class CategoryPostController : BaseController
    {
        private readonly MyBlogDbContext _context;

        public CategoryPostController(MyBlogDbContext context)
        {
            _context = context;
        }

        // GET: Admin/CategoryPost
        public async Task<IActionResult> Index(string searchString,int page=1)
        {
            if (!string.IsNullOrEmpty(searchString))
            {
                var query = _context.CategoryPosts.Where(x => x.CategoryName.Contains(searchString)).AsNoTracking().OrderBy(x => x.CreatedDate);
                var model = await PagingList.CreateAsync(query, 6, page);
                ViewBag.SearchString = searchString;
                return View(model);
            }
            else
            {
                var query = _context.CategoryPosts.AsNoTracking().OrderBy(x => x.CreatedDate);
                var model = await PagingList.CreateAsync(query, 6, page);
                return View(model);
            }
        }
        public IActionResult Export()
        {
            var data = _context.CategoryPosts.OrderBy(x => x.Id).ToList();
            var stream = new MemoryStream();
            using(var pakage = new ExcelPackage(stream))
            {
                var sheet = pakage.Workbook.Worksheets.Add("Sheet 1");
                sheet.Cells.LoadFromCollection(data, true);
                //sheet.Cells[1, 1].Value = "Mã";
                //sheet.Cells[1, 2].Value = "Tên loại";
                //sheet.Cells[1, 3].Value = "Trạng thái";
                //int rowIndex = 2;
                //foreach (var item in data)
                //{
                //    sheet.Cells[rowIndex, 1].Value = item.Id;
                //    sheet.Cells[rowIndex, 2].Value = item.CategoryName;
                //    sheet.Cells[rowIndex, 3].Value = item.Status;
                //}
                pakage.Save();
            }
            stream.Position = 0;
            var fileName = $"DanhSachLoaiBaiViet_{DateTime.Now.ToString("yyyyMMddddHHmmss")}.xlsx";
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
        }

        // GET: Admin/CategoryPost/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryPost = await _context.CategoryPosts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (categoryPost == null)
            {
                return NotFound();
            }

            return View(categoryPost);
        }

        // GET: Admin/CategoryPost/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/CategoryPost/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CategoryName,Status")] CategoryPost categoryPost)
        {
            if (ModelState.IsValid)
            {
                categoryPost.MetaTitle = XuLyChuoi.GetMetaTitle(categoryPost.CategoryName);
                categoryPost.CreatedDate = DateTime.Now;
                _context.Add(categoryPost);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categoryPost);
        }

        // GET: Admin/CategoryPost/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryPost = await _context.CategoryPosts.FindAsync(id);
            if (categoryPost == null)
            {
                return NotFound();
            }
            return View(categoryPost);
        }

        // POST: Admin/CategoryPost/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,CategoryName,Status")] CategoryPost categoryPost)
        {
            if (id != categoryPost.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    CategoryPost category = _context.CategoryPosts.Find(categoryPost.Id);
                    category.CategoryName = categoryPost.CategoryName;

                    category.MetaTitle = XuLyChuoi.GetMetaTitle(categoryPost.CategoryName);
                    category.ModifiedDate = DateTime.Now;                  
                    _context.Update(category);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryPostExists(categoryPost.Id))
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
            return View(categoryPost);
        }

        // GET: Admin/CategoryPost/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryPost = await _context.CategoryPosts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (categoryPost == null)
            {
                return NotFound();
            }

            return View(categoryPost);
        }

        // POST: Admin/CategoryPost/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var categoryPost = await _context.CategoryPosts.FindAsync(id);
            _context.CategoryPosts.Remove(categoryPost);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryPostExists(long id)
        {
            return _context.CategoryPosts.Any(e => e.Id == id);
        }
    }
}
