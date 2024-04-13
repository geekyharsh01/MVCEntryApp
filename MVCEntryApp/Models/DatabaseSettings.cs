namespace MVCEntryApp.Models
{
    // DatabaseSettings class holds configuration settings for the MongoDB database connection.
    public class DatabaseSettings
    {
        // ConnectionString property represents the connection string used to connect to the MongoDB database.
        // The "= null!" syntax initializes the property to null, and the "!" asserts that it will be assigned before it is used, avoiding null reference exceptions.
        public string ConnectionString { get; set; } = null!;

        // DatabaseName property represents the name of the MongoDB database to connect to.
        public string DatabaseName { get; set; } = null!;

        // CollectionName property represents the name of the collection within the MongoDB database.
        public string CollectionName { get; set; } = null!;
    }
}
