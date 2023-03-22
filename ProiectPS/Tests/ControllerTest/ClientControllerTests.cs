using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using ProiectPS.Controllers;
using ProiectPS.Data;
using ProiectPS.Models.Domain;
using System.Runtime.CompilerServices;
using Xunit;

namespace ProiectPS.Tests.ControllerTest
{
    public class ClientControllerTests
    {
        /*private ClientsController _clientController;
        private MVCDemoDbContext mvcDemoDbContext;

        public ClientControllerTests()
        {
            //Dependencies
            mvcDemoDbContext = A.Fake<MVCDemoDbContext>();

            //SUT
            _clientController = new ClientsController(mvcDemoDbContext);
        }

        [Fact]
        public void ClientController_Index_ReturnsSuccess()
        {
            var employees = A.Fake<Employee>();
            A.CallTo(() => mvcDemoDbContext.Employees.Add()).Returns(employees);
            //Act
            var result = _clientController.Index();
            //Assert
            result.Should().BeOfType<Task<IActionResult>>();
        }

        [Fact]
        public void ClientController_View_ReturnsSuccess()
        {
            //Arrange
            var Id = 1;
            var Name = A.Fake<Employee>();
            var Email = A.Fake<Employee>();
            var Salary = A.Fake<Employee>();
            var Role = A.Fake<Employee>();
            var DateOfBirth = A.Fake<Employee>();
            A.CallTo(() => _clientController.AddAsync(Id)).Returns(Name, Email, Salary, Role, DateOfBirth);
            //Act
            var result = _clientController.View(Id);
            //Assert
            result.Should().BeOfType<Task<IActionResult>>();
        }*/
    }
}
