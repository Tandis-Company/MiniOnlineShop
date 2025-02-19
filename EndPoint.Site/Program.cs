using Microsoft.EntityFrameworkCore;
using MiniOnlineShop.Persistance.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
#region [-ConnectionString-]

builder.Services.AddDbContext<QueryDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Query") ?? throw new InvalidOperationException("Connection string 'Default' not found.")));
builder.Services.AddDbContext<CommandDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Command") ?? throw new InvalidOperationException("Connection string 'Default' not found.")));
#endregion

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddScoped<CommandDbContext>();
builder.Services.AddScoped<QueryDbContext>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
