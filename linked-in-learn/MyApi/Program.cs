using Microsoft.EntityFrameworkCore;
using MyApi.Infraestructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();

builder.Services.AddDbContext<MyIdentityDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("Identity")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    //app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
