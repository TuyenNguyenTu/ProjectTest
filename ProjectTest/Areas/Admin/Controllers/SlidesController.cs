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
using ProjectTest.Areas.Admin.Models;
using ProjectTest.Models;
using ReflectionIT.Mvc.Paging;

namespace ProjectTest.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SlidesController : Controller
    {
        private readonly MyBlogDbContext _context;
        private readonly IHostingEnvironment hostingEnvironment;

        public SlidesController(MyBlogDbContext context, IHostingEnvironment _hostingEnvironment)
        {
            _context = context;
            hostingEnvironment = _hostingEnvironment;
        }

        // GET: Admin/Slides
        public async Task<IActionResult> Index(string searchString, int page = 1)
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

        // GET: Admin/Slides/Details/5
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

        // GET: Admin/Slides/Create
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Image,DisplayOrder,Link,Description,Status")] SlideCreateViewModel slide)
        {
            if (!ModelState.IsValid)
            {
                slide.CreatedDate = DateTime.Now;
                slide.CreatedBy = HttpContext.Session.GetString("UserName");
                string uniqueFileName = null;
                if (slide.Image != null)
                {
                    string uploadFolder = Path.Combine(hostingEnvironment.WebRootPath, "image_slide");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + slide.Image.FileName;
                    string filePath = Path.Combine(uploadFolder, uniqueFileName);
                    slide.Image.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                Slide slide1 = new Slide
                {
                    Image = @"/image_slide/" + uniqueFileName,
                    Link = slide.Link,
                    Description = slide.Description,
                    Status = slide.Status,
                    CreatedDate = slide.CreatedDate,
                    CreatedBy = slide.CreatedBy

                };
                _context.Add(slide1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(slide);
        }

        // GET: Admin/Slides/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slide = await _context.Slides.FindAsync(id);
            SlideEditViewModel slideEdit = new SlideEditViewModel
            {
                Id = slide.Id,
                ExistImagePath = slide.Image,
                Status = slide.Status,
                Link = slide.Link,
                Description = slide.Description,
                DisplayOrder = slide.DisplayOrder
            };
            if (slide == null)
            {
                return NotFound();
            }
            return View(slideEdit);
        }

        // POST: Admin/Slide/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SlideEditViewModel slide)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Slide slide1 = _context.Slides.Find(slide.Id);
                    slide1.DisplayOrder = slide.DisplayOrder;
                    slide1.Description = slide.Description;
                    slide1.ModifiedDate = DateTime.Now;
                    slide1.Link = slide.Link;
                    if (slide.Image != null)
                    {
                        if (slide.ExistImagePath != null)
                        {
                            string filePath = Path.Combine(hostingEnvironment.WebRootPath, "image_slide", slide.ExistImagePath);
                            System.IO.File.Delete(filePath);
                        }
                        slide1.Image = @"/image_slide/" + ProcessUploadedFile(slide);
                    }
                    _context.Update(slide1);
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

        // GET: Admin/Slides/Delete/5
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

        // POST: Admin/Slides/Delete/5
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


        private string ProcessUploadedFile(SlideEditViewModel slide)
        {
            string uniqueFileName = null;
            if (slide.Image != null)
            {
                string upLoadFolder = Path.Combine(hostingEnvironment.WebRootPath, "image_slide");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + slide.Image.FileName;
                string filePath = Path.Combine(upLoadFolder, uniqueFileName);
                slide.Image.CopyTo(new FileStream(filePath, FileMode.Create));
            }

            return uniqueFileName;
        }
    }
}
