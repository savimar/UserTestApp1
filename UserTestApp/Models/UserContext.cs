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
                        Address = "Moscow",
                        Age = 30,
                        RoleId = 10

                    }, 
               new User
                    {
                        Id = 2,
                        FirstName = "Admin",
                        LastName = "Adminov",
                        Address = "Russia",
                        Age = 35,
                        RoleId = 20
                        })
               ;

        }
    }
}
