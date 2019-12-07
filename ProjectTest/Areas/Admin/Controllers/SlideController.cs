using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectTest.Models;
using ReflectionIT.Mvc.Paging;

namespace ProjectTest.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SlideController : BaseController
    {
        private readonly MyBlogDbContext _context;

        public SlideController(MyBlogDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Slide
        public async Task<IActionResult> Index(string searchString, int page =1)
        {
            if (!string.IsNullOrEmpty(searchString))
            {
                var query = _context.Slides.Where(x => x.Description.Contains(searchString)).AsNoTracking().OrderBy(x => x.CreatedDate);
                var model = await PagingList.CreateAsync(query, 2, page);
                ViewBag.searchString = searchString;
                return View(model);
            }
            else
            {
                var query = _context.Slides.AsNoTracking().OrderBy(x => x.CreatedDate);
                var model = await PagingList.CreateAsync(query, 2, page);
                return View(model);
            }
        }

        // GET: Admin/Slide/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slide = await _context.Slides
                .FirstOrDefaultAsync(m => m.Id == id);
            if (slide == null)
            {
                return NotFound();
            }

            return View(slide);
        }

        // GET: Admin/Slide/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Slide/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Image,DisplayOrder,Link,Description,Status")] Slide slide)
        {
            if (!ModelState.IsValid)
            {
                slide.CreatedDate = DateTime.Now;
                slide.CreatedBy = HttpContext.Session.GetString("UserName");
                _context.Add(slide);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(slide);
        }

        // GET: Admin/Slide/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slide = await _context.Slides.FindAsync(id);
            if (slide == null)
            {
                return NotFound();
            }
            return View(slide);
        }

        // POST: Admin/Slide/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Image,DisplayOrder,Link,Description,Status")] Slide slide)
        {
            if (id != slide.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    slide.ModifiedDate = DateTime.Now;
                    _context.Update(slide);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SlideExists(slide.Id))
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
            return View(slide);
        }

        // GET: Admin/Slide/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slide = await _context.Slides
                .FirstOrDefaultAsync(m => m.Id == id);
            if (slide == null)
            {
                return NotFound();
            }

            return View(slide);
        }

        // POST: Admin/Slide/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var slide = await _context.Slides.FindAsync(id);
            _context.Slides.Remove(slide);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SlideExists(long id)
        {
            return _context.Slides.Any(e => e.Id == id);
        }
    }
}
