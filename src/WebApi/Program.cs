using Application.UseCases;
using Domain.Interfaces;
using Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? "Server=localhost;Database=master;User Id=sa;Password=SuperSecret123!;TrustServerCertificate=True";

builder.Services.AddScoped<IOrderRepository>(sp =>
    new OrderRepository(connectionString));

builder.Services.AddScoped<CreateOrderUseCase>();
builder.Services.AddScoped<IOrderRepository>();
builder.Services.AddControllers();
builder.Services.AddScoped<IUserRepository>(sp =>
    new UserRepository(builder.Configuration.GetConnectionString("Sql")));
var app = builder.Build();


app.UseHttpsRedirection();

app.MapControllers();

app.Run();
