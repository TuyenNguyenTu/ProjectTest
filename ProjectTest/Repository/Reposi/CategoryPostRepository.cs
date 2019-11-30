using Microsoft.EntityFrameworkCore;
using ProjectTest.DAO;
using ProjectTest.Models;
using ProjectTest.Repository.InterfaceRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTest.Repository.Reposi
{
    public class CategoryPostRepository : ICategoryPostRepository
    {
        private MyBlogDbContext context;
        /// <summary>
        /// Sử dụng dependency injection
        /// </summary>
        /// <param name="_context"></param>
        public CategoryPostRepository(MyBlogDbContext _context)
        {
            this.context = _context; // tieem phu thuoc // Dependency Injection trong ASP.NET Core
        }
        /// <summary>
        /// Thêm mới sử dụng async await
        /// </summary>
        /// <param name="categoryPost"></param>
        /// <returns></returns>
        public async Task Add(CategoryPost categoryPost)
        {
            context.CategoryPosts.Add(categoryPost);
            await context.SaveChangesAsync();
        }

        /// <summary>
        /// Xóa với ID
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task Delete(long Id)
        {
            CategoryPost category = context.CategoryPosts.Find(Id);
            context.CategoryPosts.Remove(category);
            await context.SaveChangesAsync();
        }

        /// <summary>
        /// Kiêm tra tồn tại
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool Exist(long Id)
        {
            CategoryPost categoryPost = context.CategoryPosts.Find(Id);
            if(categoryPost != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<CategoryPost>> GetCategoryListPost()
        {
           return await context.CategoryPosts.ToListAsync();
        }

        public async Task<CategoryPost> GetCategoryPostByID(long Id)
        {
            CategoryPost categoryPost = await context.CategoryPosts.FindAsync(Id);
            return categoryPost;
        }

        /// <summary>
        /// Update bản ghi
        /// </summary>
        /// <param name="categoryPost"></param>
        /// <returns></returns>
        public async Task Update(CategoryPost categoryPost)
        {
            CategoryPost category = await context.CategoryPosts.FindAsync(categoryPost.Id);
            category.CategoryName = categoryPost.CategoryName;
            category.MetaTitle = XuLyChuoi.GetMetaTitle(categoryPost.CategoryName);
            category.ModifiedDate = DateTime.Now;
            await context.SaveChangesAsync();
        }
    }
}
