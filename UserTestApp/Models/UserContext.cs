using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace UserTestApp.Models
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public UserContext(DbContextOptions<UserContext> dbContextOptions)
            : base(dbContextOptions)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
         
        }
       

        protected override void OnConfiguring
            (DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                Id = 10,
                Name = "User"
                },
                new Role
                {
                    Id = 20,
                    Name = "Admin"
                }
            );
            
            modelBuilder.Entity<User>().HasData(

               new User
                    {
                        Id=1,
                        FirstName = "Ivan",
                        LastName = "Petrov",
                        Age = 30,
                        RoleId = 10

                    },
               new User
               {
                   Id = 3,
                   FirstName = "Alexey",
                   LastName = "Sidorov",
                   Age = 25,
                   RoleId = 10

               },
               new User
               {
                   Id = 4,
                   FirstName = "Irina",
                   LastName = "Ivanova",
                   Age = 27,
                   RoleId = 10

               },
               new User
               {
                   Id = 5,
                   FirstName = "Alexey",
                   LastName = "Kuznetsov",
                   Age = 32,
                   RoleId = 20

               },
               new User
               {
                   Id = 2,
                   FirstName = "Admin",
                   LastName = "Adminov",
                   Age = 35,
                   RoleId = 20
               })
               ;

        }
        
    }
}
