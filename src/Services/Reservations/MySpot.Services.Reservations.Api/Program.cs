using Micro.Framework;
using Micro.Handlers;
using Micro.Messaging;
using MySpot.Services.Reservations.Application;
using MySpot.Services.Reservations.Core;
using MySpot.Services.Reservations.Infrastructure;

var builder = WebApplication
    .CreateBuilder(args)
    .AddMicroFramework();

builder.Services
    .AddCore()
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

var app = builder.Build();

app.MapGet("/", (AppInfo appInfo) => appInfo).WithTags("API").WithName("Info");

app.MapGet("/ping", () => "pong").WithTags("API").WithName("Pong");

app.MapGet("/reservations/weekly", async (DateTime? date, IDispatcher dispatcher, HttpContext context) =>
{

}).RequireAuthorization().WithTags("Reservations").WithName("Get weekly reservations");


app.UseMicroFramework()
    .Subscribe();

app.Run();

static Guid UserId(HttpContext context)
    => string.IsNullOrWhiteSpace(context.User.Identity?.Name) ? Guid.Empty : Guid.Parse(context.User.Identity.Name);
