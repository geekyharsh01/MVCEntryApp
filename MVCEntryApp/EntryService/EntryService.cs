using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using MVCEntryApp.Models;

// The EntryService class handles interactions with the MongoDB database.
public class EntryService
{
    // IMongoCollection to store LogEntry objects.
    private readonly IMongoCollection<LogEntry> _logCollection;

    // Constructor accepting IOptions<DatabaseSettings> to configure database connection settings.
    public EntryService(IOptions<DatabaseSettings> _databaseSettings)
    {
        // Initializing a MongoClient using the provided connection string.
        var client = new MongoClient(_databaseSettings.Value.ConnectionString);

        // Getting a reference to the specified database using the provided database name.
        var database = client.GetDatabase(_databaseSettings.Value.DatabaseName);

        // Getting a reference to the collection within the specified database using the provided collection name.
        _logCollection = database.GetCollection<LogEntry>(_databaseSettings.Value.CollectionName);
    }

    // Method to insert a LogEntry object into the database.
    public void InsertLogEntry(LogEntry logEntry)
    {
        // Inserting the provided LogEntry object into the MongoDB collection.
        _logCollection.InsertOne(logEntry);
    }

    // Method to retrieve the latest LogEntry from the database.
    public LogEntry GetLatestLogEntry()
    {
        // Finding the latest LogEntry by querying the collection, sorting by DateTime in descending order, and returning the first result.
        var latestLogEntry = _logCollection.Find(new BsonDocument()).SortByDescending(e => e.DateTime).FirstOrDefault();

        // Returning the latest LogEntry.
        return latestLogEntry;
    }
}
