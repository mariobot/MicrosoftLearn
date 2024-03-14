using Application;
using Infraestucture.Services;
using Web.Api;
using Web.Api.Extensions;
using Web.Api.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPresentation()
                .AddInfraestructure(builder.Configuration)
                .AddApplication();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ApplyMigrations();
}

app.UseExceptionHandler("/error");

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

app.MapControllers();

app.Run();
