using Microsoft.EntityFrameworkCore;
using Sample.ProductAPI.DataAccess;
using Sample.ProductAPI.Middleware;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// --- Service Configuration ---

// Configure Serilog for structured logging
builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

// Add services to the dependency injection container.
builder.Services.AddControllers();

// Add Swagger/OpenAPI services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register the DbContext for Entity Framework Core
builder.Services.AddDbContext<ProductDbContext>(options =>
    options.UseInMemoryDatabase("ProductCatalogDB"));

// Register the repository for data access
builder.Services.AddScoped<IProductRepository, ProductRepository>();

// Register the custom exception handler
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

// --- Application Building ---
var app = builder.Build();

// --- Middleware Pipeline Configuration ---

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Add Serilog's request logging middleware
app.UseSerilogRequestLogging();

// Add custom middleware
app.UseMiddleware<TraceIdMiddleware>();

app.UseHttpsRedirection();

// Use the custom exception handler
app.UseExceptionHandler();

app.UseAuthorization();

app.MapControllers();

// --- Application Startup & Seeding ---

try
{
    Log.Information("Starting up the application");

    // Seed the database for demonstration purposes
    DataSeeder.SeedData(app);

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application start-up failed");
}
finally
{
    Log.CloseAndFlush();
}
