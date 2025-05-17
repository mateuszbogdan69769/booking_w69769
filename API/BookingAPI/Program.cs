using BookingAPI;
using Domain;
using Infrastructure;
using ApiApplication;
using BookingAPI.Misc;
using Swashbuckle.AspNetCore.SwaggerUI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDomainServices();
builder.Services.AddAPIServices(builder.Configuration);
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApiApplicationServices(builder.Configuration);

var app = builder.Build();
app.UseCors("corspolicy");

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSwaggerAuthorized();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/api/swagger.json", "Booking API");
    c.DocumentTitle = "Booking API";
    c.DocExpansion(DocExpansion.None);
    c.DisplayRequestDuration();
});

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(name: "default", pattern: "{controller}/{action}/{id?}");

app.Run();
