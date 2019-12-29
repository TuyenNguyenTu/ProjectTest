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
using ProjectTest.Areas.Admin.Models;
using ProjectTest.DAO;
using ProjectTest.Models;
using ReflectionIT.Mvc.Paging;

namespace ProjectTest.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PostsController : BaseController
    {
        private readonly MyBlogDbContext _context;
        private readonly IHostingEnvironment hostingEnvironment;
        public PostsController(MyBlogDbContext context, IHostingEnvironment en)
        {
            _context = context;
            hostingEnvironment = en;
        }

        // GET: Admin/Posts
        [Route("/danh-sach-bai-viet")]
        public async Task<IActionResult> Index(string searchString, int page = 1)
        {

            if (!string.IsNullOrEmpty(searchString))
            {
                var query = _context.Posts.Where(x => x.Title.Contains(searchString) || x.Title.Contains(searchString)).AsNoTracking().OrderBy(x => x.Id);
                var model = await PagingList.CreateAsync(query, 2, page);
                ViewBag.search = searchString;
                return View(model);
            }
            else
            {
                var query = _context.Posts.AsNoTracking().OrderBy(x => x.Id);
                var model = await PagingList.CreateAsync(query, 2, page);
                return View(model);
            }
        }

        public IActionResult Export()
        {
            var data = _context.Posts.OrderBy(x => x.Id).ToList();
            var stream = new MemoryStream();
            using (var pakage = new ExcelPackage(stream))
            {
                var sheet = pakage.Workbook.Worksheets.Add("Sheet 1");
                sheet.Cells.LoadFromCollection(data, true);
                pakage.Save();
            }
            stream.Position = 0;
            var fileName = $"DanhSachPost_{DateTime.Now.ToString("yyyyMMddddHHmmss")}.xlsx";
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
        }

        [Route("upload_ckeditor")]
        [HttpPost]
        public IActionResult UploadCKEditor(IFormFile iformFile)
        {

            var fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + iformFile.FileName;
            var path = Path.Combine(Directory.GetCurrentDirectory(),hostingEnvironment.WebRootPath,"DataImage",fileName);
            var stream = new FileStream(path, FileMode.Create);
            iformFile.CopyToAsync(stream);

            return new JsonResult(new {
                uploaded=1,
                fileName = iformFile.FileName,
                url = "/DataImage/"+ fileName });
        }

        // GET: Admin/Posts/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Posts
                .Include(p => p.CategoryPost)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // GET: Admin/Posts/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.CategoryPosts, "Id", "CategoryName");
            return View();
        }

        // POST: Admin/Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ContentPost,MetaDescription,Status,Note,HinhAnh,CategoryId")] PostCreateViewModel post)
        {
            if (!ModelState.IsValid)
            {
                string uniqueFileName = ProcessUploadedFileC(post);
                post.MetaTitle = XuLyChuoi.GetMetaTitle(post.Title);
                post.CreatedDate = DateTime.Now;
                post.CreatedBy = HttpContext.Session.GetString("UserName");
                Post post_1 = new Post
                {
                    Title = post.Title,
                    ContentPost = post.ContentPost,
                    MetaTitle = post.MetaTitle,
                    CreatedDate = post.CreatedDate,
                    CreatedBy = post.CreatedBy,
                    Status = post.Status,
                    CategoryId = post.CategoryId,
                    MetaDescription = post.MetaDescription,
                    Note = post.Note,
                    HinhAnh = @"/uploads_admin/" + uniqueFileName

                };

                _context.Add(post_1);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", new { id = post_1.Id });
                // return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.CategoryPosts, "Id", "CategoryName", post.CategoryId);
            return View(post);
        }


        private string ProcessUploadedFileC(PostCreateViewModel post)
        {
            string uniqueFileName = null;
            if (post.HinhAnh != null)
            {
                string upLoadFolder = Path.Combine(hostingEnvironment.WebRootPath, "uploads_admin");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + post.HinhAnh.FileName;
                string filePath = Path.Combine(upLoadFolder, uniqueFileName);
                post.HinhAnh.CopyTo(new FileStream(filePath, FileMode.Create));
            }

            return uniqueFileName;
        }


        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Posts.FindAsync(id);
            PostEditViewModel postEditViewModel = new PostEditViewModel
            {
                Id = post.Id,
                Title = post.Title,
                ContentPost = post.ContentPost,
                MetaDescription = post.MetaDescription,
                CategoryPost = post.CategoryPost,
                ExistingPhotoPath = post.HinhAnh,
                Status = post.Status,
                CategoryId = post.CategoryId
            };
            if (post == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.CategoryPosts, "Id", "CategoryName", post.CategoryId);
            return View(postEditViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PostEditViewModel post)
        {
            if (ModelState.IsValid)
            {
                Post post1 = _context.Posts.Find(post.Id);
                post1.Title = post.Title;
                post1.ContentPost = post.ContentPost;
                post1.ModifiedBy = HttpContext.Session.GetString("UserName");
                post1.ModifiedDate = DateTime.Now;
                post1.Status = post.Status;
                post1.CategoryPost = post.CategoryPost;
                post1.CategoryId = post.CategoryId;
                if (post.HinhAnh != null)
                {
                    if (post.ExistingPhotoPath != null)
                    {
                        string filePath = Path.Combine(hostingEnvironment.WebRootPath, "uploads_admin", post.ExistingPhotoPath);
                        System.IO.File.Delete(filePath);
                    }
                    post1.HinhAnh = @"/uploads_admin/" + ProcessUploadedFile(post);
                }
                post.MetaTitle = XuLyChuoi.GetMetaTitle(post.Title);


                _context.Update(post1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
                // return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.CategoryPosts, "Id", "CategoryName", post.CategoryId);
            return View(post);

        }
        private string ProcessUploadedFile(PostEditViewModel post)
        {
            string uniqueFileName = null;
            if (post.HinhAnh != null)
            {
                string upLoadFolder = Path.Combine(hostingEnvironment.WebRootPath, "uploads_admin");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + post.HinhAnh.FileName;
                string filePath = Path.Combine(upLoadFolder, uniqueFileName);
                post.HinhAnh.CopyTo(new FileStream(filePath, FileMode.Create));
            }

            return uniqueFileName;
        }
        // GET: Admin/Posts/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Posts
                .Include(p => p.CategoryPost)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // POST: Admin/Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var post = await _context.Posts.FindAsync(id);
            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostExists(long id)
        {
            return _context.Posts.Any(e => e.Id == id);
        }
    }
}
