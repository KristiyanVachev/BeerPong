using System;
using System.Data.Entity;
using BeerPong.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BeerPong.Data.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<BeerPongDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "BeerPong.Data.BeerPongDbContext";

            Database.SetInitializer(new DropCreateDatabaseAlways<BeerPongDbContext>());
        }

        protected override void Seed(BeerPongDbContext context)
        {
            const string roleName = "Admin";

            var userRole = new IdentityRole()
            {
                Name = roleName
            };

            context.Roles.Add(userRole);
            context.SaveChanges();

            var hasher = new PasswordHasher();

            var user = new User()
            {
                PasswordHash = hasher.HashPassword("nanana21"),
                Email = "mewtwo@gmail.com"
                //SecurityStamp = Guid.NewGuid().ToString()
            };

            context.Users.AddOrUpdate(user);
            context.SaveChanges();

            user.Roles.Add(new IdentityUserRole
            {
                RoleId = userRole.Id,
                UserId = user.Id
            });

            context.Users.AddOrUpdate(user);
            context.SaveChanges();
        }
    }
}
