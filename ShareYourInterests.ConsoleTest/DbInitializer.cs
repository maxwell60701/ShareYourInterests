using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShareYourInterests.Entity;

namespace ShareYourInterests.ConsoleTest
{
   public static class DbInitializer
    {
        public static void Initialize(ShareYourInterestsDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Users.Any())
            {
                return;   // DB has been seeded
            }

            var users = new User[]
            {
                new User{UserName="Carson",UserPassword="111"},
            };

            context.Users.AddRange(users);
            context.SaveChanges();
        }
    }
}

