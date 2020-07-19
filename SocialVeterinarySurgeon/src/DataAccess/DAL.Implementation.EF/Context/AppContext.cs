using DAL.Implementation.EF.Context.Configuration;
using Microsoft.EntityFrameworkCore;
using Model;
using System.Collections.Generic;

namespace DAL.Implementation.EF.Context
{
    public class AppContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Pet> Pets { get; set; }

        public AppContext()
        { }

        public AppContext(DbContextOptions<AppContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");
            modelBuilder.ApplyConfiguration(new EmployeesConfiguration())
                        .ApplyConfiguration(new PetsConfiguration());

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>().HasData(
                        new List<Employee>
                        {
                            new Employee { Id = 1, FirstName = "John", LastName = "Dou", MediaInteractivaEmployee = true },
                            new Employee{ Id = 2, FirstName = "Sam", LastName = "Horny", MediaInteractivaEmployee = false },
                            new Employee{ Id = 3, FirstName = "Splinter", LastName = "Teacher", MediaInteractivaEmployee = true }
                        });

            modelBuilder.Entity<Pet>().HasData(
                        new List<Pet>
                        {
                            new Pet{ Id = 1, Name = "Dick", Type = "duck", OwnerId = 1 },
                            new Pet{ Id = 2, Name = "Pussy", Type = "cat", OwnerId = 2 },
                            new Pet{ Id = 3, Name = "Leonardo", Type = "turtle", OwnerId = 3 },
                        });
        }
    }
}
