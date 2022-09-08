using DbContextLibrary;
using DbContextLibrary.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// https://docs.microsoft.com/en-us/dotnet/core/extensions/dependency-injection#service-lifetimes
// Dependency Injection
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IDetallesFacturaRepository, DetallesFacturaRepositoryRepository>();
builder.Services.AddScoped<IFacturaRepository, FacturaRepository>();
builder.Services.AddScoped<IInfoFacturaRepository, InfoFacturaRepository>();
builder.Services.AddScoped<IMarcaRepository, MarcaRepository>();
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();

// Adding DbContext Dependency.
builder.Services.AddDbContext<ContabilidadDbContext>(options =>
    options.UseSqlServer("Data Source=localhost; Initial Catalog=ContabilidadDb; Trusted_Connection=True"));
/*
 Usando el la dependencia del DbContext, permite una transitividad sobre las dependencias.
 Con esto se puede crear un objeto A que depende de B mientras que B depende de C. 
 */

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();