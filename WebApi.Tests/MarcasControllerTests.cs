using System.Diagnostics;
using DbContextLibrary;
using DbContextLibrary.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelEntities;
using Moq;
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
    public void GetById_Exists_False(int id)
    {
        // arrange
        var actionResult = _controller.Get(id);
        
        // act
        var result = actionResult.Result;
        // assert
        
        
    }
}