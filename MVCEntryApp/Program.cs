using MVCEntryApp.Models;

// Create a new WebApplication instance using the provided command-line arguments.
var builder = WebApplication.CreateBuilder(args);

// Add services to the dependency injection container.
builder.Services.AddControllersWithViews();

// Configure options for DatabaseSettings using values from the app's configuration.
builder.Services.Configure<DatabaseSettings>(
    builder.Configuration.GetSection("MongoDBSettings"));

// Add a singleton service for EntryService.
builder.Services.AddSingleton<EntryService>();

// Build the application.
var app = builder.Build();

// Configure the HTTP request pipeline.

// If not in development mode, configure exception handling and HTTPS Strict Transport Security (HSTS).
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // Configure HSTS. Note: Adjust the duration as needed for production.
    app.UseHsts();
}

// Redirect HTTP requests to HTTPS.
app.UseHttpsRedirection();

// Enable serving static files (e.g., CSS, JavaScript).
app.UseStaticFiles();

// Enable routing.
app.UseRouting();

// Enable authorization.
app.UseAuthorization();

// Map controller routes.
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Start the application.
app.Run();
