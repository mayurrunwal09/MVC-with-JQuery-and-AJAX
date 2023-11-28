using Microsoft.EntityFrameworkCore;
using Repository_And_Services.Context;
using Repository_And_Services.Repository;
using Repository_And_Services.Services.Custom.DepartmentServices;
using Repository_And_Services.Services.Custom.EmployeeServices;
using Repository_And_Services.Services.Generic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<MainDBContext>(o=>o.UseSqlServer(builder.Configuration.GetConnectionString("Database")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped(typeof(IRepositroy<>), typeof(Repository<>));
builder.Services.AddTransient(typeof(IService<>),typeof(Service<>));    
builder.Services.AddTransient(typeof(IEmployeeService),typeof(EmployeeService));
builder.Services.AddTransient(typeof(IDepartmentService), typeof(DepartmentService));

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
