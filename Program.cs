global using api_obj_3.Models;
global using api_obj_3.Services.ItemService;
global using Microsoft.EntityFrameworkCore;
global using api_obj_3.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var conn = builder.Configuration.GetConnectionString("tempdbConnection");
builder.Services.AddDbContext<DataContext>(q => q.UseSqlServer(conn));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Services (NOT GENERATED)
builder.Services.AddScoped<iItemService, ItemService>();

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
