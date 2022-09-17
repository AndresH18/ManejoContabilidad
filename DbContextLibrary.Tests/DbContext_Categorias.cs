using DbContextLibrary.Repository;
using ModelEntities;

namespace DbContextLibrary.Tests;

public class DbContext_Categorias
{
    private readonly ContabilidadDbContext _db;

    public DbContext_Categorias()
    {
        _db = ContabilidadDbContext.InMemoryDatabase();
    }

    [Theory]
    [MemberData(nameof(CategoriasNoId))]
    public void Add_NoId_IdNot0(Categoria categoria)
    {
        // Arrange
        var repo = new CategoriaRepository(_db);

        // Act
        repo.Create(categoria);

        // Assert
        Assert.NotEqual(0, categoria.Id);
    }

    [Theory]
    [MemberData(nameof(CateogirasWithId))]
    public void Add_WithId_IdNot0(Categoria categoria)
    {
        // Arrange
        var oldId = categoria.Id;
        var repo = new CategoriaRepository(_db);

        // Act
        repo.Create(categoria);

        // Assert
        // Id must not be 0 after inserting
        Assert.NotEqual(0, categoria.Id);
    }

    public static IEnumerable<object[]> CategoriasNoId()
    {
        yield return new object[] {new Categoria {Name = "Camaras"}};
        yield return new object[] {new Categoria {Name = "Alarmas"}};
    }

    public static IEnumerable<object[]> CateogirasWithId()
    {
        yield return new object[] {new Categoria() {Name = "Sensores", Id = 1}};
        yield return new object[] {new Categoria() {Name = "Cables", Id = 2}};
    }
}