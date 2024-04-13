using Microsoft.AspNetCore.Mvc; // Importing the namespace for MVC framework
using MVCEntryApp.Models; // Importing the namespace for models


namespace MVCEntryApp.Controllers // Namespace declaration for the HomeController class
{
    public class HomeController : Controller // HomeController class declaration, inherits from Controller class
    {
        private readonly ILogger<HomeController> _logger; // Logger field declaration
        private readonly EntryService _dbContext; // EntryService field declaration

        // Constructor with dependencies injection for ILogger and EntryService
        public HomeController(ILogger<HomeController> logger, EntryService dbContext)
        {
            _logger = logger; // Assigning logger parameter to _logger field
            _dbContext = dbContext; // Assigning dbContext parameter to _dbContext field

            // Check if logger is null
            if (_logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }

            // Check if dbContext is null
            if (_dbContext == null)
            {
                throw new ArgumentNullException(nameof(dbContext));
            }
        }

        // Action method for handling requests to the default route 
        public IActionResult Index()
        {
            // Check if HttpContext is null
            if (HttpContext == null)
            {
                throw new InvalidOperationException("HttpContext is null");
            }

            // Creating a new instance of LogEntry model and populating its properties
            var logEntry = new LogEntry
            {
                DateTime = DateTime.Now, // Setting DateTime property to current date and time
                // Check if RemoteIpAddress is null
                IpAddress = HttpContext.Connection.RemoteIpAddress?.ToString() // Setting IpAddress property to client's IP address
            };

            // Inserting the logEntry object into the database using the _dbContext field
            _dbContext.InsertLogEntry(logEntry);

            // Returning a ViewResult, which renders a view named "Index" associated with this action
            return View();
        }

        // Action method for handling requests to the "Privacy" route ("/Home/Privacy")
        public IActionResult Privacy()
        {
            // Check if _dbContext is null
            if (_dbContext == null)
            {
                throw new InvalidOperationException("_dbContext is null");
            }

            // Retrieving the latest log entry from the database using the _dbContext field
            var latestLogEntry = _dbContext.GetLatestLogEntry();

            // Returning a ViewResult with the latestLogEntry object passed as the model
            return View(latestLogEntry);
        }
    }
}
