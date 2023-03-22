using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using ProiectPS.Controllers;
using ProiectPS.Data;
using ProiectPS.Models;
using ProiectPS.Models.Domain;

namespace ProiectPS.Tests
{
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class ClientsControllerTests
    {
        private Mock<MVCDemoDbContext> _dbContextMock;
        private ClientsController _clientsController;

        [Microsoft.VisualStudio.TestTools.UnitTesting.TestInitialize]
        public void TestInitialize()
        {
            _dbContextMock = new Mock<MVCDemoDbContext>();
            _clientsController = new ClientsController(_dbContextMock.Object);
        }

        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethod]
        public async Task Index_ReturnsListOfEmployees()
        {
            // Arrange
            var employees = new List<Employee>
            {
                new Employee { Id = Guid.NewGuid(), Name = "Cosmin Varvari", Email = "cosminvarcari@yahoo.com", Salary = "3000", Role = "Employee"},
                new Employee { Id = Guid.NewGuid(), Name = "Dan Oprean", Email = "cosminvarcari@yahoo.com", Salary = "3000", Role = "Client" },
            };

            var employeesDbSetMock = GetQueryableMockDbSet(employees);

            _dbContextMock.Setup(db => db.Employees).Returns(employeesDbSetMock.Object);

            // Act
            var result = await _clientsController.Index();

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
            var viewResult = result as ViewResult;
            Assert.IsNotNull(viewResult);

            Assert.IsInstanceOf<List<Employee>>(viewResult.Model);
            var model = viewResult.Model as List<Employee>;
            Assert.IsNotNull(model);
            Assert.AreEqual(2, model.Count);
        }

        private static Mock<DbSet<T>> GetQueryableMockDbSet<T>(List<T> sourceList) where T : class
        {
            var queryable = sourceList.AsQueryable();
            var dbSet = new Mock<DbSet<T>>();

            dbSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
            dbSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
            dbSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            dbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());

            return dbSet;
        }

        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethod]
        public async Task Add_CreatesEmployeeAndRedirectsToIndex()
        {
            // Arrange
            var addEmployeeRequest = new AddEmployeeViewModel
            {
                Name = "John Doe",
                Email = "john.doe@example.com",
                Salary = "50000",
                Role = "Developer",
                DateOfBirth = new DateTime(1990, 1, 1)
            };

            _dbContextMock.Setup(db => db.Employees.AddAsync(It.IsAny<Employee>(), It.IsAny<CancellationToken>()))
        .Returns((Employee employee, CancellationToken cancellationToken) => Task.FromResult(employee));
            _dbContextMock.Setup(db => db.SaveChangesAsync(It.IsAny<CancellationToken>())).Returns(Task.FromResult(1));

            // Act
            var result = await _clientsController.Add(addEmployeeRequest);

            // Assert
            Assert.IsInstanceOf<RedirectToActionResult>(result);
            var redirectResult = result as RedirectToActionResult;
            Assert.IsNotNull(redirectResult);
            Assert.AreEqual("Index", redirectResult.ActionName);
        }

        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethod]
        public async Task View_ReturnsEmployeeDataOrRedirectsToIndex()
        {
            // Arrange
            var id = Guid.NewGuid();
            var employee = new Employee
            {
                Id = id,
                Name = "John Doe",
                Email = "john.doe@example.com",
                Salary = "50000",
                Role = "Developer",
                DateOfBirth = new DateTime(1990, 1, 1)
            };

            _dbContextMock.Setup(db => db.Employees.FirstOrDefaultAsync(x => x.Id == id, It.IsAny<CancellationToken>())).ReturnsAsync(employee);

            // Act
            var result = await _clientsController.View(id);

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
            var viewResult = result as ViewResult;
            Assert.IsNotNull(viewResult);
            Assert.IsInstanceOf<UpdateEmployeeViewModel>(viewResult.Model);
            var model = viewResult.Model as UpdateEmployeeViewModel;
            Assert.AreEqual(employee.Id, model.Id);
            Assert.AreEqual(employee.Name, model.Name);
            Assert.AreEqual(employee.Email, model.Email);
            Assert.AreEqual(employee.Salary, model.Salary);
            Assert.AreEqual(employee.Role, model.Role);
            Assert.AreEqual(employee.DateOfBirth, model.DateOfBirth);
        }

        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethod]
        public async Task View_UpdateEmployeeAndRedirectsToIndex()
        {
            // Arrange
            var employeeId = Guid.NewGuid();

            var updateEmployeeModel = new UpdateEmployeeViewModel
            {
                Id = employeeId,
                Name = "John Doe",
                Email = "john.doe@example.com",
                Salary = "50000",
                Role = "Developer",
                DateOfBirth = new DateTime(1990, 1, 1)
            };

            var employee = new Employee
            {
                Id = employeeId,
                Name = "John Doe",
                Email = "john.doe@example.com",
                Salary = "50000",
                Role = "Developer",
                DateOfBirth = new DateTime(1990, 1, 1)
            };

            _dbContextMock.Setup(db => db.Employees.FindAsync(employeeId)).ReturnsAsync(employee);
            _dbContextMock.Setup(db => db.SaveChangesAsync(It.IsAny<CancellationToken>())).Returns(Task.FromResult(1));

            // Act
            var result = await _clientsController.View(updateEmployeeModel);

            // Assert
            Assert.IsInstanceOf<RedirectToActionResult>(result);
            var redirectResult = result as RedirectToActionResult;
            Assert.IsNotNull(redirectResult);
            Assert.AreEqual("Index", redirectResult.ActionName);
        }

        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethod]
        public async Task Delete_RemovesEmployeeAndRedirectsToIndex()
        {
            // Arrange
            var employeeId = Guid.NewGuid();

            var updateEmployeeModel = new UpdateEmployeeViewModel
            {
                Id = employeeId,
                Name = "John Doe",
                Email = "john.doe@example.com",
                Salary = "50000",
                Role = "Developer",
                DateOfBirth = new DateTime(1990, 1, 1)
            };

            var employee = new Employee
            {
                Id = employeeId,
                Name = "John Doe",
                Email = "john.doe@example.com",
                Salary = "50000",
                Role = "Developer",
                DateOfBirth = new DateTime(1990, 1, 1)
            };

            _dbContextMock.Setup(db => db.Employees.FindAsync(employeeId)).ReturnsAsync(employee);
            _dbContextMock.Setup(db => db.SaveChangesAsync(It.IsAny<CancellationToken>())).Returns(Task.FromResult(1));

            // Act
            var result = await _clientsController.Delete(updateEmployeeModel);

            // Assert
            Assert.IsInstanceOf<RedirectToActionResult>(result);
            var redirectResult = result as RedirectToActionResult;
            Assert.IsNotNull(redirectResult);
            Assert.AreEqual("Index", redirectResult.ActionName);

            _dbContextMock.Verify(db => db.Employees.Remove(employee), Times.Once);
            _dbContextMock.Verify(db => db.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}