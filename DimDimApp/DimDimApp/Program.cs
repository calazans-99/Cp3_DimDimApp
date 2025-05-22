using DimDimApp.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var provider = builder.Configuration["DatabaseProvider"];

if (provider == "Oracle")
{
    builder.Services.AddDbContext<DimDimDbContext>(options =>
        options.UseOracle(builder.Configuration.GetConnectionString("OracleConnection")));
}
else
{
    builder.Services.AddDbContext<DimDimDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
}

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();
