using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTest.Models
{
    public class MyBlogDbContext : DbContext
    {

        public MyBlogDbContext(DbContextOptions<MyBlogDbContext> options) : base(options)
        {

        }
        public DbSet<AboutMe> AboutMes { set; get; }
        public DbSet<Contact> Contacts { set; get; }
        public DbSet<Slide> Slides { set; get; }
        public DbSet<CategoryPost> CategoryPosts { set; get; }
        public DbSet<Account> Accounts { set; get; }
        public DbSet<FeedBack> FeedBacks { set; get; }
        public DbSet<Footer> Footers { set; get; }
        public DbSet<TypeMenu> TypeMenus { set; get; }
        public DbSet<Menu> Menus { set; get; }
        public DbSet<Post> Posts { set; get; }
    }
}
