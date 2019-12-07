using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Korzh.EasyQuery.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using ProjectTest.Models;
using ReflectionIT.Mvc.Paging;

namespace ProjectTest.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : BaseController
    {
        private readonly MyBlogDbContext _context;
        //tiêm phụ thuộc dependency injection

        public AccountController(MyBlogDbContext context)
        {
            _context = context;
        }

        public IActionResult Export()
        {
            var data = _context.Accounts.OrderBy(x => x.Id).ToList();

            var stream = new MemoryStream();
            //để tạo file excel ta cần dùng excelPagkage
            using (var pakage = new ExcelPackage(stream))
            {
                var sheet = pakage.Workbook.Worksheets.Add("Tài khoản");
                //đổ dữ liệu vào sheet
                sheet.Cells.LoadFromCollection(data, true);
                //sheet.Cells[1, 1].Value = "Tài khoản";
                //sheet.Cells[1, 2].Value = "Tên hiển thị";
                //sheet.Cells[1, 3].Value = "Địa chỉ";
                //sheet.Cells[1, 4].Value = "Email";
                //sheet.Cells[1, 5].Value = "Số điện thoại";
                //int rowIndex = 2;
                //foreach (var item in data)
                //{
                //    sheet.Cells[rowIndex, 1].Value = item.UserName;
                //    sheet.Cells[rowIndex, 2].Value = item.DisplayName;
                //    sheet.Cells[rowIndex, 3].Value = item.Address;
                //    sheet.Cells[rowIndex, 4].Value = item.Email;
                //    sheet.Cells[rowIndex, 5].Value = item.Phone;
                //}
                //save
                pakage.Save();//file excel đang nằm trong memory stream

            }
            stream.Position = 0;
            var fileName = $"DanhSach_Account_{DateTime.Now.ToString("yyyyMMddHHmmss")}.xlsx";
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
        }

        // GET: Admin/Account
        public async Task<IActionResult> Index(string searchString, int page = 1)
        {
            if (!string.IsNullOrEmpty(searchString))
            {
                var query1 = _context.Accounts.Where(x => x.UserName.Contains(searchString)).AsNoTracking().OrderBy(x => x.CreatedDate);
                var model1 = await PagingList.CreateAsync(query1, 2, page);
                ViewBag.search = searchString;
                return View(model1);
            }
            else
            {
                var query = _context.Accounts.AsNoTracking().OrderBy(x => x.CreatedDate);
                var model = await PagingList.CreateAsync(query, 2, page);
                return View(model);
            }



        }

        // GET: Admin/Account/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = await _context.Accounts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        // GET: Admin/Account/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Account/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserName,PassWord,Avartar,DisplayName,Address,Email,Phone,IsAdmin,Status")] Account account)
        {
            if (ModelState.IsValid)
            {
                account.CreatedDate = DateTime.Now;
                account.CreatedBy = HttpContext.Session.GetString("UserName");
                _context.Add(account);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(account);
        }

        // GET: Admin/Account/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = await _context.Accounts.FindAsync(id);
            if (account == null)
            {
                return NotFound();
            }
            return View(account);
        }

        // POST: Admin/Account/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,UserName,PassWord,Avartar,DisplayName,Address,Email,Phone,IsAdmin,Status")] Account account)
        {
            if (id != account.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    account.ModifiedDate = DateTime.Now;
                    _context.Update(account);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountExists(account.Id))
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
            return View(account);
        }

        // GET: Admin/Account/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = await _context.Accounts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        // POST: Admin/Account/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var account = await _context.Accounts.FindAsync(id);
            _context.Accounts.Remove(account);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccountExists(long id)
        {
            return _context.Accounts.Any(e => e.Id == id);
        }
    }
}
