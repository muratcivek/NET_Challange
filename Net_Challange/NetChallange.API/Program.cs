using MediatR;
using NetChallange.Application;
using NetChallange.Application.Interface;
using NetChallange.Application.Services;
using NetChallange.Core.Entities;
using NetChallange.Core.Interfaces;
using NetChallange.Infrastructure.Data;
using NetChallange.Infrastructure.Repositories;
using System.Reflection;
using static NetChallange.Application.Features.Commands.Create.CreateOrderCommand;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApplicationDbContext>();

builder.Services.AddScoped<IRepository<Carriers>, Repository<Carriers>>();
builder.Services.AddScoped<IRepository<CarrierConfigurations>, Repository<CarrierConfigurations>>();
builder.Services.AddScoped<IRepository<Orders>, Repository<Orders>>();
builder.Services.AddScoped<ICreateOrderCalculationService, CreateOrderCalculationService>();



// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddApplicationService();
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
