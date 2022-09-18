using DbContextLibrary;
using DbContextLibrary.Repository;
using Microsoft.AspNetCore.Mvc;
using ModelEntities;
using WebApi.Controllers;

namespace WebApi.Tests;

public class MarcasControllerTests
{
    private readonly AbstractController<IMarcaRepository, Marca> _controller;

    public MarcasControllerTests()
    {
        var db = ContabilidadDbContext.InMemoryDatabase();

        var repo = new MarcaRepository(db);
        _controller = new MarcasController(repo);

        // var mock = new Mock<IMarcaRepository>();
    }

    [Fact]
    public void GetAll_ReturnsListOfMarca_True()
    {
        // arrange
        var actionResult = _controller.GetAll();

        // act
        var value = actionResult.Value;

        // assert
        Assert.IsAssignableFrom<List<Marca>>(value);
    }

    [Theory]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    [InlineData(6)]
    [InlineData(7)]
    public void GetById_NotExists_IsNotFoundResult(int id)
    {
        // arrange
        var actionResult = _controller.Get(id);

        // act
        var result = actionResult.Result;

        // assert
        Assert.IsAssignableFrom<NotFoundResult>(result);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public void GetById_Exists_IsOkResult(int id)
    {
        // arrange
        var actionResult = _controller.Get(id);

        // act
        var result = actionResult.Result;

        // assert
        Assert.IsAssignableFrom<OkObjectResult>(result);
    }

    [Theory]
    [InlineData(1, 2)]
    [InlineData(2, 3)]
    [InlineData(3, 4)]
    [InlineData(4, 5)]
    [InlineData(5, 6)]
    [InlineData(6, 7)]
    [InlineData(7, 8)]
    [InlineData(8, 9)]
    public void Update_DifferentId_IsBadRequestResult(int routeId, int objectId)
    {
        // arrange
        var actionResult = _controller.Update(routeId, new Marca {Id = objectId});

        // act 
        var result = actionResult;

        // assert
        Assert.IsAssignableFrom<BadRequestResult>(result);
    }

    [Theory]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    [InlineData(6)]
    [InlineData(7)]
    public void Update_NotExists_IsNotFoundResult(int id)
    {
        // arrange 
        var actionResult = _controller.Update(id, new Marca {Id = id});

        // act
        // assert
        Assert.IsAssignableFrom<NotFoundResult>(actionResult);
    }

    [Fact]
    public void Delete_Exists_IsNoContentResult()
    {
        // arrange
        var actionResult = _controller.Delete(1);

        // act
        // assert
        Assert.IsAssignableFrom<NoContentResult>(actionResult);
    }

    [Theory]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    [InlineData(6)]
    [InlineData(7)]
    public void Delete_NotExists_IsNotFoundResult(int id)
    {
        // arrange
        var actionResult = _controller.Delete(id);
        
        // act
        // assert
        Assert.IsAssignableFrom<NotFoundResult>(actionResult);
    }
}