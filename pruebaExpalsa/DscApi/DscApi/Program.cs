using DscApi.Interfaces;
using DscApi.Repositories;
using DscApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICatalogRepository, CatalogRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICatalogService, CatalogService>();





builder.Services.AddCors(policy => {
    policy.AddPolicy("dsccors", policy => {
        policy.WithOrigins("http://localhost:4200");
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();

    });
});


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

app.UseCors("dsccors");

app.UseAuthorization();

app.MapControllers();

app.Run();
