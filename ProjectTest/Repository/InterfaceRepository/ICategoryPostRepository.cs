using ProjectTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTest.Repository.InterfaceRepository
{
    public interface ICategoryPostRepository
    {
        Task Add(CategoryPost categoryPost);
        bool Exist(long Id);
        Task Update(CategoryPost categoryPost);
        Task Delete(long Id);
        Task<CategoryPost> GetCategoryPostByID(long Id);
        Task<List<CategoryPost>> GetCategoryListPost();
    }
}
