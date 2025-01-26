using Microsoft.EntityFrameworkCore;
using PetBreedingSystemAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string connStr = builder.Configuration["ConnectionStrings:PetBreedingDB"].ToString();
builder.Services.AddDbContext<BreedingSystemContext>(options =>
                options.UseSqlServer(connStr));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


//app.UseAuthorization();

app.MapControllers();

app.Run();
