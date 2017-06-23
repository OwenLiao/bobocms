using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model;

namespace DAL
{
    public class DbInitializer
    {
        public static void Initialize(IServiceProvider service)
        {
            var db = service.GetService<MyDbContext>();
           // context.Database.EnsureCreated();

            // Look for any students.
            if (context.Category.Any())
            {
                return;   // DB has been seeded
            }
            var categories = new Category[]
          {
            new Category{Title="十佳球",Name="shijiaqiu"},

              new Category{Title="十佳球",Name="shijiaqiu"}
          };
            foreach (Category s in categories)
            {
                context.Category.Add(s);
            }

            if (!context.Manager.Any())
            {
                Manager m = new Manager
                {
                    UserName = "admin",
                    UserPwd = Common.DESEncrypt.Md5("admin888"),
                    roleId = 1
                };
                context.Manager.Add(m);
            }
            context.SaveChanges();


        }
    }
}
