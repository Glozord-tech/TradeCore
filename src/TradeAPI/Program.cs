using Microsoft.EntityFrameworkCore;
using TradeInfrastructure.Data;
using TradeApplication.Interfaces;
using TradeApplication.Services;
using TradeInfrastructure.Repository;
var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped<IProductInterface, ProductServices>();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<IProductRepository, Repository>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
