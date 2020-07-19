using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Model;
using Moq;
using System.Collections.Generic;
using System.Linq;
using WebUI.Controllers;
using Xunit;

namespace WebUI.Tests.Controllers
{
    public class EmployeeControllerTests
    {
        #region GetAll
        [Fact]
        public async void GetAsync_ShouldReturnOk()
        {
            // Arrange
            var employees = new List<Employee> { new Employee(), new Employee(), new Employee() };

            var employeeServiceMock = new Mock<IEmployeesService>();
            employeeServiceMock.Setup(x => x.GetAllEmployeesAsync()).ReturnsAsync(employees);

            var controller = new EmployeeController(employeeServiceMock.Object);

            // Act
            var result = await controller.GetAsync() as ObjectResult;

            // Arrange
            Assert.IsAssignableFrom<OkObjectResult>(result);
            Assert.Equal(employees.Count, ((IEnumerable<Employee>)result.Value).Count());
        } 
        #endregion

        #region GetById
        [Fact]
        public async void GetByIdAsync_ShouldReturnOk()
        {
            // Arrange
            var employee = new Employee { Id = 123 };

            var employeeServiceMock = new Mock<IEmployeesService>();
            employeeServiceMock.Setup(x => x.GetEmployeeByIdAsync(It.IsAny<int>())).ReturnsAsync(employee);

            var controller = new EmployeeController(employeeServiceMock.Object);

            // Act
            var result = await controller.GetAsync(employee.Id) as ObjectResult;

            // Arrange
            Assert.IsAssignableFrom<OkObjectResult>(result);
            Assert.Equal(employee.Id, ((Employee)result.Value).Id);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-123)]
        public async void GetByIdAsync_ShouldReturnBadRequest(int id)
        {
            // Arrange
            var controller = new EmployeeController(new Mock<IEmployeesService>().Object);

            // Act
            var result = await controller.GetAsync(id) as ObjectResult;

            // Arrange
            Assert.IsAssignableFrom<BadRequestObjectResult>(result);
            Assert.Equal("Wrong employee id", result.Value);
        }

        [Fact]
        public async void GetByIdAsync_ShouldReturnNotFound()
        {
            // Arrange
            int id = 123;
            Employee employee = null;

            var employeeServiceMock = new Mock<IEmployeesService>();
            employeeServiceMock.Setup(x => x.GetEmployeeByIdAsync(It.IsAny<int>())).ReturnsAsync(employee);

            var controller = new EmployeeController(employeeServiceMock.Object);

            // Act
            var result = await controller.GetAsync(id) as ObjectResult;

            // Arrange
            Assert.IsAssignableFrom<NotFoundObjectResult>(result);
            Assert.Equal($"There is no employee with {id} id", result.Value);
        } 
        #endregion


        #region Post
        [Fact]
        public async void PostAsync_ShouldReturnCreated()
        {
            // Arrange
            var employee = new Employee { Id = 0 };

            var employeeServiceMock = new Mock<IEmployeesService>();

            var controller = new EmployeeController(employeeServiceMock.Object);

            // Act
            var result = await controller.PostAsync(employee) as ObjectResult;

            // Arrange
            employeeServiceMock.Verify(x => x.UpsertEmployeeAsync(employee), Times.Once);
            Assert.IsAssignableFrom<CreatedResult>(result);
        }

        [Fact]
        public async void PostAsync_ShouldReturnNoContent()
        {
            // Arrange
            var employee = new Employee { Id = 123 };

            var employeeServiceMock = new Mock<IEmployeesService>();

            var controller = new EmployeeController(employeeServiceMock.Object);

            // Act
            var result = await controller.PostAsync(employee);

            // Arrange
            employeeServiceMock.Verify(x => x.UpsertEmployeeAsync(employee), Times.Once);
            Assert.IsAssignableFrom<NoContentResult>(result);
        }

        [Fact]
        public async void PostAsync_ShouldReturnBadRequest()
        {
            // Arrange
            Employee employee = null;

            var employeeServiceMock = new Mock<IEmployeesService>();

            var controller = new EmployeeController(employeeServiceMock.Object);

            // Act
            var result = await controller.PostAsync(employee) as ObjectResult;

            // Arrange
            employeeServiceMock.Verify(x => x.UpsertEmployeeAsync(employee), Times.Never);
            Assert.IsAssignableFrom<BadRequestObjectResult>(result);
            Assert.Equal("Wrong employee data", result.Value);
        } 
        #endregion


        #region Delete
        [Fact]
        public async void DeleteAsync_ShouldReturnNoContent()
        {
            // Arrange
            var id = 123;

            var employeeServiceMock = new Mock<IEmployeesService>();

            var controller = new EmployeeController(employeeServiceMock.Object);

            // Act
            var result = await controller.DeleteAsync(id);

            // Arrange
            employeeServiceMock.Verify(x => x.DeleteEmployeeAsync(id), Times.Once);
            Assert.IsAssignableFrom<NoContentResult>(result);
        } 
        #endregion
    }
}
