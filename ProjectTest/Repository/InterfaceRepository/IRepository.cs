using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTest.Repository.InterfaceRepository
{
    public interface IRepository<T>
    {
        Task Add(T entity);
        bool Exist(long Id);
        Task Update(T entity);
        Task Delete(long Id);
        Task<T> GetCategoryPostByID(long Id);
        Task<List<T>> GetCategoryListPost();
    }
}
