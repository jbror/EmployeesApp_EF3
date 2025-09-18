using EmployeesApp.Application.Employees.Interfaces;
using EmployeesApp.Domain.Entities;
using EmployeesApp.Web.Controllers;
using EmployeesApp.Web.Views.Employees;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace EmployeesApp.Web.Tests;

public class EmployeesControllerTests
{
    [Fact]
    public void Index_NoParams_ReturnsViewResult()
    {
        // Arrange
        var employeeService = new Mock<IEmployeeService>();
        employeeService
            .Setup(o => o.GetAll())
            .Returns(
            [
                new Employee {Id = 1, Name = "Kurt"},
                new Employee {Id = 2, Name = "Olle"}
            ]);



        var controller = new EmployeesController(employeeService.Object);



        // Act


        var result = controller.Index();


        // Assert

        Assert.IsType<ViewResult>(result);


    }


    [Fact]
    public void Create_Get_ReturnsViewWithEmptyViewModel()
    {

        // Arrange
        var employeeService = new Mock<ICompanyService>();
        var controller = new EmployeesController(employeeService.Object);


        // Act
        var result = controller.Create();


        // Assert
        var viewResult = Assert.IsType<ViewResult>(result);
        var model = Assert.IsType<EmployeeCreateVM>(viewResult.Model);

        Assert.NotNull(model);
        Assert.Equal(string.Empty, model.Name);
        Assert.Equal(string.Empty, model.Email);
        Assert.Equal(0, model.Salary);





    }



    [Fact]
    public void Create_Post_ValidModel_RedirectsToIndex()
    {

        // Arrange

        var employeeService = new Mock<ICompanyService>();
        var controller = new EmployeesController(employeeService.Object);


        // Act

        var vm = new EmployeeCreateVM()
        {

            Name = "Frasse",
            Email = "superfrasse@gmail.com",
            Salary = 29000m

        };

        var result = controller.Create(vm);


        // Assert

        var redirectResult = Assert.IsType<RedirectToActionResult>(result);
        Assert.Equal("Index", redirectResult.ActionName);


        employeeService.Verify( s => s.Add(It.Is<Employee>(e =>
            e.Name == vm.Name &&
            e.Email == vm.Email &&
            e.Salary == vm.Salary
            )), Times.Once);
    }


    }
















