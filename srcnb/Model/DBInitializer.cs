using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace Model
{
    public class DBInitializer : DropCreateDatabaseIfModelChanges<ComonDbContext>
    {
        protected override void Seed(ComonDbContext context)
        {
            //base.Seed(context);  继承父类的方法 不写也可
            //初始化用户
            var Accounts = new List<Account>
            {
                new Account{ UserName="admin", Password="admin" }
            };
            Accounts.ForEach(s => context.Accounts.Add(s));
            context.SaveChanges(); 
        }
    }
}
