using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTest.Models
{
    public class MyBlogDbContext :DbContext
    {
        public MyBlogDbContext(DbContextOptions<MyBlogDbContext> options):base(options)
        {

        }
    }
}
