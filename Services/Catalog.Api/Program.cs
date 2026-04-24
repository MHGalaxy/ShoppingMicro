using Catalog.Core.Abstractions;

var builder = WebApplication.CreateBuilder(args);

// Register all services using installers
InstallServices(builder.Services, builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "Store API v1");
        options.RoutePrefix = "swagger"; // /swagger
    });
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.MapHealthChecks("/health"); // Optional health check endpoint

app.Run();


// Helper method to discover and install all services
static void InstallServices(IServiceCollection services, IConfiguration configuration)
{
    var installers = AppDomain.CurrentDomain.GetAssemblies()
        .SelectMany(assembly => assembly.GetTypes())
        .Where(type => typeof(IServiceInstaller).IsAssignableFrom(type) &&
                       type is { IsInterface: false, IsAbstract: false })
        .Select(Activator.CreateInstance)
        .Cast<IServiceInstaller>();

    foreach (var installer in installers)
    {
        installer.Install(services, configuration);
    }
}