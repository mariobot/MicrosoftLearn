using Microsoft.AspNetCore.Diagnostics;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddHydro();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseExceptionHandler(b => b.Run(async context =>
{
    if (!context.IsHydro())
    {
        return;
    }

    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
    switch (contextFeature?.Error)
    {
        // custom cases for custom exception types if needed

        default:
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            await context.Response.WriteAsJsonAsync(new UnhandledHydroError(
                Message: "There was a problem with this operation and it wasn't finished",
                Data: null
            ));

            return;
    }
}));

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();
app.UseHydro(builder.Environment);

app.Run();
