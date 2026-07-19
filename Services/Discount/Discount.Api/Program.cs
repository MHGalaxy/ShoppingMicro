using Discount.Api;
using Discount.Application;
using Discount.Infrastructure;
using Discount.Core;
using Discount.Infrastructure.Extensions;
using Discount.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Register all services 
builder.Services.ConfigureApplicationServices();
builder.Services.ConfigureInfrastructureServices(builder.Configuration);
builder.Services.ConfigureCoreServices();
builder.Services.ConfigureApiServices(builder.Configuration);

var app = builder.Build();

// Migrate the database
app.MigrateDatabase<Program>();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    // app.MapOpenApi();
}

app.UseRouting();
app.MapGrpcService<DiscountService>();

app.Map("/", async context =>
{
    await context.Response.WriteAsync("Communication with gRPC Discount Service");
});

//app.UseAuthorization();
//app.MapControllers();

app.Run();
