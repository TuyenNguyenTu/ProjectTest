using ProjectTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTest.DAO
{
    public class AccountDAO
    {
        private MyBlogDbContext db;
        public AccountDAO(MyBlogDbContext _db)
        {
            this.db = _db;
        }
        public long Insert(Account account)
        {
            db.Accounts.Add(account);
            db.SaveChanges();
            return account.Id;
        }
        public Account GetAccountByUserName(string userName)
        {
            return db.Accounts.SingleOrDefault(x => x.UserName == userName);
        }
        public int Login(string userName, string passWord)
        {
            var result = db.Accounts.SingleOrDefault(x => x.UserName == userName);
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (result.Status == false)
                {
                    return -1;
                }
                else
                {
                    if (result.IsAdmin == false)
                        return -1;
                    else
                    {
                        if (result.PassWord == passWord)
                        {
                            return 1;
                        }
                        else
                        {
                            return -2;
                        }
                    }
                }
            }
        }


    }
}
