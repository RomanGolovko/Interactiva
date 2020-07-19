using DAL.Interfaces;
using Model;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace BLL.Implementation.Tests
{
    public class EmployeesServiceTests
    {
        [Fact]
        public async void GetAllEmployeesAsync_ShouldReturnEmployeesList()
        {
            // Arrange
            var employees = new List<Employee>
            {
                new Employee
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Dou",
                    MediaInteractivaEmployee = true,
                    Pet = new Pet{Id = 32, Name = "Dick", Type = "duck", OwnerId = 1}
                },
                new Employee
                {
                    Id = 2,
                    FirstName = "Sam",
                    LastName = "Smith",
                    MediaInteractivaEmployee = false,
                    Pet = new Pet{Id = 45, Name = "Mat", Type = "cat", OwnerId = 2}
                }
            };

            var employeesRepoMock = new Mock<IBaseRepository<Employee>>();
            employeesRepoMock.Setup(x => x.GetAllAsync()).ReturnsAsync(employees);

            var employeesService = new EmployeesService(employeesRepoMock.Object);

            // Act
            var result = await employeesService.GetAllEmployeesAsync();

            // Arrange
            Assert.IsAssignableFrom<IEnumerable<Employee>>(result);
            Assert.Equal(employees.Count, result.Count());
        }

        [Fact]
        public async void GetEmployeeByIdAsync_ShouldReturnEmployee()
        {
            // Arrange
            var employee = new Employee
            {
                Id = 23,
                FirstName = "John",
                LastName = "Dou",
                MediaInteractivaEmployee = true,
                Pet = new Pet { Id = 73, Name = "Dick", Type = "duck", OwnerId = 23 }
            };

            var employeesRepoMock = new Mock<IBaseRepository<Employee>>();
            employeesRepoMock.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(employee);

            var employeesService = new EmployeesService(employeesRepoMock.Object);

            // Act
            var result = await employeesService.GetEmployeeByIdAsync(employee.Id);

            // Arrange
            Assert.IsAssignableFrom<Employee>(result);
            Assert.Equal(employee.Id, result.Id);
            Assert.Equal(employee.FirstName, result.FirstName);
            Assert.Equal(employee.LastName, result.LastName);
        }

        [Fact]  
        public async void UpsertEmployeeAsync_ShouldCallAddEmployee()
        {
            // Arrange
            var employee = new Employee
            {
                Id = 0,
                FirstName = "John",
                LastName = "Dou",
                MediaInteractivaEmployee = true,
                Pet = new Pet { Id = 73, Name = "Dick", Type = "duck", OwnerId = 23 }
            };

            var employeesRepoMock = new Mock<IBaseRepository<Employee>>();

            var employeesService = new EmployeesService(employeesRepoMock.Object);

            // Act
            await employeesService.UpsertEmployeeAsync(employee);

            // Assert
            employeesRepoMock.Verify(x => x.AddAsync(employee), Times.Once);
            employeesRepoMock.Verify(x => x.UpdateAsync(It.IsAny<Employee>()), Times.Never);
        }

        [Fact]
        public async void UpsertEmployeeAsync_ShouldCallUpdateEmployee()
        {
            // Arrange
            var employee = new Employee
            {
                Id = 23,
                FirstName = "John",
                LastName = "Dou",
                MediaInteractivaEmployee = true,
                Pet = new Pet { Id = 73, Name = "Dick", Type = "duck", OwnerId = 23 }
            };

            var employeesRepoMock = new Mock<IBaseRepository<Employee>>();

            var employeesService = new EmployeesService(employeesRepoMock.Object);

            // Act
            await employeesService.UpsertEmployeeAsync(employee);

            // Assert
            employeesRepoMock.Verify(x => x.AddAsync(It.IsAny<Employee>()), Times.Never);
            employeesRepoMock.Verify(x => x.UpdateAsync(employee), Times.Once);
        }


        [Fact]
        public async void DeleteEmployeeAsync_ShouldCallDeleteEmployee()
        {
            // Arrange
            var employee = new Employee
            {
                Id = 23,
                FirstName = "John",
                LastName = "Dou",
                MediaInteractivaEmployee = true,
                Pet = new Pet { Id = 73, Name = "Dick", Type = "duck", OwnerId = 23 }
            };

            var employeesRepoMock = new Mock<IBaseRepository<Employee>>();
            employeesRepoMock.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(employee);

            var employeesService = new EmployeesService(employeesRepoMock.Object);

            // Act
            await employeesService.DeleteEmployeeAsync(employee.Id);

            // Assert
            employeesRepoMock.Verify(x => x.DeleteAsync(employee.Id), Times.Once);
        }
    }
}
