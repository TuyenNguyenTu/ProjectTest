using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectTest.DAO;
using ProjectTest.Models;
using ReflectionIT.Mvc.Paging;

namespace ProjectTest.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MenuController : BaseController
    {
        private readonly MyBlogDbContext _context;

        public MenuController(MyBlogDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Menu
        public async Task<IActionResult> Index(string searchString, int page = 1)
        {
            if (!string.IsNullOrEmpty(searchString))
            {
                var query = _context.Menus.Where(x => x.Text.Contains(searchString)).AsNoTracking().OrderBy(x => x.Id);
                var model = await PagingList.CreateAsync(query, 2, page);
                ViewBag.searchString = searchString;
                return View(model);
            }
            else
            {
                var query = _context.Menus.AsNoTracking().OrderBy(x => x.Id);
                var model = await PagingList.CreateAsync(query, 2, page);
                return View(model);
            }
        }

        // GET: Admin/Menu/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menu = await _context.Menus
                .Include(m => m.TypeMenu)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (menu == null)
            {
                return NotFound();
            }

            return View(menu);
        }

        // GET: Admin/Menu/Create
        public IActionResult Create()
        {
            ViewData["TypeID"] = new SelectList(_context.TypeMenus, "Id", "Name");
            return View();
        }
        // POST: Admin/Menu/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Text,DisplayOrder,Status,TypeID")] Menu menu)
        {
            if (ModelState.IsValid)
            {
                menu.Link = "/" + XuLyChuoi.GetMetaTitle(menu.Text);
                _context.Add(menu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TypeID"] = new SelectList(_context.TypeMenus, "Id", "Name", menu.TypeID);
            return View(menu);
        }

        // GET: Admin/Menu/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menu = await _context.Menus.FindAsync(id);
            if (menu == null)
            {
                return NotFound();
            }
            ViewData["TypeID"] = new SelectList(_context.TypeMenus, "Id", "Name", menu.TypeID);
            return View(menu);
        }

        // POST: Admin/Menu/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Text,Link,DisplayOrder,Status,TypeID")] Menu menu)
        {
            if (id != menu.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    menu.Link = "/" + XuLyChuoi.GetMetaTitle(menu.Text);
                    _context.Update(menu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MenuExists(menu.Id))
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
            ViewData["TypeID"] = new SelectList(_context.TypeMenus, "Id", "Name", menu.TypeID);
            return View(menu);
        }

        // GET: Admin/Menu/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menu = await _context.Menus
                .Include(m => m.TypeMenu)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (menu == null)
            {
                return NotFound();
            }

            return View(menu);
        }

        // POST: Admin/Menu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var menu = await _context.Menus.FindAsync(id);
            _context.Menus.Remove(menu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MenuExists(long id)
        {
            return _context.Menus.Any(e => e.Id == id);
        }
    }
}
