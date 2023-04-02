using EmployeeAttendance.DAL;
using EmployeeAttendance.DAL.EntityTypeConfig;
using EmployeeAttendance.DAL.Repositories;
using EmployeeAttendance.DAL.Repositories.Impl;
using EmployeeAttendance.Middleware;
using EmployeeAttendance.Services;
using EmployeeAttendance.Services.Implementation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConection")));
builder.Services.AddControllers();

builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IAttendanceService, AttendanceService>();
builder.Services.AddScoped<IAttendanceRepository, AttendanceRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(x => x
          .AllowAnyOrigin()
          .AllowAnyMethod()
          .AllowAnyHeader());
}

app.UseMiddleware<ExceptionHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
