using Application.UseCases;
using Domain.Interfaces;
using Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("Sql")
    ?? throw new InvalidOperationException("Connection string not found.");

builder.Services.AddScoped<IOrderRepository>(sp =>
    new OrderRepository(connectionString));

builder.Services.AddScoped<IUserRepository>(sp =>
    new UserRepository(connectionString));

builder.Services.AddScoped<CreateOrderUseCase>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

await app.RunAsync();
