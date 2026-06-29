using CleanArchitecture.Domain.DTOs;
using CleanArchitecture.Application.Features.CarFeatures.Commands.CreateCar;
using CleanArchitecture.Presentation.Controllers;

using Moq;
using MediatR;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace CleanArchitecture.UnitTest;

public class CarsControllerUnitTest
{
    [Fact]
    public async Task Create_ReturnsOkResult_WhenRequestIsValid()
    {
        //Arrange
        var mediatorMock = new Mock<IMediator>();
        CreateCarCommand createCarCommand = new("Toyota", "Corolla", 5000);
        MessageResponse response =  new("Car record completed successfully!");
        CancellationToken cancellationToken = new();

        mediatorMock.Setup(m => m.Send(createCarCommand, cancellationToken)).ReturnsAsync(response);

        CarsController carsController = new(mediatorMock.Object);

        //Act
        var result = await carsController.Create(createCarCommand, cancellationToken);

        //Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<MessageResponse>(okResult.Value);

        Assert.Equal(response, returnValue);
        mediatorMock.Verify(m => m.Send(createCarCommand, cancellationToken), Times.Once);
    }
}