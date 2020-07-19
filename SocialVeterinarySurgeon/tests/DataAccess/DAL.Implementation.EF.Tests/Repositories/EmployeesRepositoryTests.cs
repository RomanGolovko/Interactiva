using DAL.Implementation.EF.Context;
using DAL.Implementation.EF.Repositories;
using Microsoft.EntityFrameworkCore;
using Model;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DAL.Implementation.EF.Tests.Repositories
{
    public class EmployeesRepositoryTests
    {
        [Fact]
        public async void GetAllAsync_ShouldReturnListOfEmployees()
        {
            // Arrange
            var employees = new List<Employee>
            {
                new Employee{ Id = 1, FirstName = "John", LastName = "Dou", MediaInteractivaEmployee = true },
                new Employee{ Id = 2, FirstName = "Sam", LastName = "Smith", MediaInteractivaEmployee = false }
            };

            var options = new DbContextOptionsBuilder<AppContext>()
                .UseInMemoryDatabase(databaseName: "Employees1")
                .Options;

            using (var appContext = new AppContext(options))
            {

                await appContext.Employees.AddRangeAsync(employees);
                await appContext.SaveChangesAsync();
            }

            using (var appContext = new AppContext(options))
            {
                var repo = new EmployeesRepository(appContext);

                // Act
                var result = await repo.GetAllAsync();


                // Assert
                Assert.IsAssignableFrom<IEnumerable<Employee>>(result);
                Assert.Equal(employees.Count, result.Count());
            }
        }

        [Fact]
        public async void GetByIdAsync_ShouldReturnEmployee()
        {
            // Arrange
            var employees = new List<Employee>
            {
                new Employee{ Id = 1, FirstName = "John", LastName = "Dou", MediaInteractivaEmployee = true },
                new Employee{ Id = 2, FirstName = "Sam", LastName = "Smith", MediaInteractivaEmployee = false }
            };

            var options = new DbContextOptionsBuilder<AppContext>()
                .UseInMemoryDatabase(databaseName: "Employees2")
                .Options;

            using (var appContext = new AppContext(options))
            {

                await appContext.Employees.AddRangeAsync(employees);
                await appContext.SaveChangesAsync();
            }

            using (var appContext = new AppContext(options))
            {
                var repo = new EmployeesRepository(appContext);

                // Act
                var result = await repo.GetByIdAsync(employees.First().Id);


                // Assert
                Assert.IsAssignableFrom<Employee>(result);
                Assert.Equal(employees.First().Id, result.Id);
            }
        }

        [Fact]
        public async void AddAsync_ShouldAddEmployee()
        {
            // Arrange
            var employeeToAdd = new Employee { Id = 1, FirstName = "John", LastName = "Dou", MediaInteractivaEmployee = true };

            var options = new DbContextOptionsBuilder<AppContext>()
                .UseInMemoryDatabase(databaseName: "Employees3")
                .Options;

            using (var appContext = new AppContext(options))
            {
                var repo = new EmployeesRepository(appContext);

                // Act
                await repo.AddAsync(employeeToAdd);


                // Assert
                var employee = appContext.Employees.Find(employeeToAdd.Id);
                Assert.Equal(employeeToAdd.Id, employee.Id);
                Assert.Equal(employeeToAdd.FirstName, employee.FirstName);
                Assert.Equal(employeeToAdd.LastName, employee.LastName);
                Assert.Equal(employeeToAdd.MediaInteractivaEmployee, employee.MediaInteractivaEmployee);
            }
        }

        [Fact]
        public async void UpdateAsync_ShouldUpdateEmployee()
        {
            // Arrange
            var employeeBeforeUpdate = new Employee { Id = 1, FirstName = "John", LastName = "Dou", MediaInteractivaEmployee = true };
            var employeeAfterUpdate = new Employee { Id = 1, FirstName = "Obivan", LastName = "Kenobi", MediaInteractivaEmployee = true };

            var options = new DbContextOptionsBuilder<AppContext>()
                .UseInMemoryDatabase(databaseName: "Employees4")
                .Options;

            using (var appContext = new AppContext(options))
            {

                await appContext.Employees.AddAsync(employeeBeforeUpdate);
                await appContext.SaveChangesAsync();
            }

            using (var appContext = new AppContext(options))
            {
                var repo = new EmployeesRepository(appContext);

                // Act
                await repo.UpdateAsync(employeeAfterUpdate);


                // Assert
                var employee = appContext.Employees.Find(employeeAfterUpdate.Id);
                Assert.Equal(employeeAfterUpdate.Id, employee.Id);
                Assert.Equal(employeeAfterUpdate.FirstName, employee.FirstName);
                Assert.Equal(employeeAfterUpdate.LastName, employee.LastName);
                Assert.Equal(employeeAfterUpdate.MediaInteractivaEmployee, employee.MediaInteractivaEmployee);
            }
        }

        [Fact]
        public async void DeleteAsync_ShouldDeleteEmployee()
        {
            // Arrange
            var employeeToDelete = new Employee { Id = 1, FirstName = "John", LastName = "Dou", MediaInteractivaEmployee = true };

            var options = new DbContextOptionsBuilder<AppContext>()
                .UseInMemoryDatabase(databaseName: "Employees5")
                .Options;

            using (var appContext = new AppContext(options))
            {

                await appContext.Employees.AddAsync(employeeToDelete);
                await appContext.SaveChangesAsync();
            }

            using (var appContext = new AppContext(options))
            {
                var repo = new EmployeesRepository(appContext);

                // Act
                await repo.DeleteAsync(employeeToDelete.Id);


                // Assert
                var employee = appContext.Employees.Find(employeeToDelete.Id);
                Assert.Null(employee);
            }
        }
    }
}
