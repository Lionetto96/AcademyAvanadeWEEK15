using MongoDB.Driver;

namespace Avanade.Amazon.Core.Cosmos.Utilities
{
    public static class CosmosDbOptions
    {
        public static IMongoDatabase GetDatabase()
        {
            //string connectionString = "mongodb://localhost:27017/";

            //Definzione della stringa di connessione prelevata ESATTAMENTE da Azure
            string connectionString = "mongodb://maurobussini:" +
                "hMkNzgVuZVMkxEDuEjYAyTHfw8mzaHEx0MBKyL9pqWSrpzxnpj88aSTHSjEIFvN3Rc3QCoQptm94EcWoztNruQ==" +
                "@maurobussini.mongo.cosmos.azure.com:10255/" +
                "?ssl=true&retrywrites=false&replicaSet=globaldb" +
                "&maxIdleTimeMS=120000&appName=@maurobussini@";

            //Parsing della stringa in segmenti e recupero database name
            MongoUrl mongoUrl = MongoUrl.Create(connectionString);
            string databaseName = mongoUrl.DatabaseName;
            
            //Se il database non è presente, ce ne metto uno io
            if (string.IsNullOrEmpty(databaseName))
                databaseName = "avanade-amazon-cosmos-db";

            //Creazione del client per mongo
            var client = new MongoClient(connectionString);

            //Recupero istanza database
            var db = client.GetDatabase(databaseName);
            return db;
        }
    }
}
