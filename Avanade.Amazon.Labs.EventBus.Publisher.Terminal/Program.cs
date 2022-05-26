using Avanade.Amazon.Core.BusinessLayers;
using Avanade.Amazon.Core.DataAccessLayers;
using Avanade.Amazon.Core.DataAccessLayers.InMemory;
using Avanade.Amazon.Core.DataAccessLayers.Interfaces;
using Avanade.Cdo.Amazon.Core.Utils;
using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Producer;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Avanade.Amazon.Labs.EventBus.Publisher.Terminal
{
    static class Program
    {
        private const string connectionString = "Endpoint=sb://maurobussini.servicebus.windows.net/;" + 
            "SharedAccessKeyName=SendPolicy;" + 
            "SharedAccessKey=vL5zNGfZVZzGZhaRb5Q0/0KmntAGDQ296owwcR1JrdQ=;" + 
            "EntityPath=sample";

        private const string eventHubName = "sample";

        static async Task Main()
        {
            //Inizializzazione delle dipendenze e del business layer
            var storage = new MockAmazonStorage();
            IBookRepository repo = new MockBookRepository(storage);            
            MainBusinessLayer layer = new MainBusinessLayer(repo);

            //Creazione di un produttore cliente che segnala
            await using (var producerClient = new EventHubProducerClient(connectionString, eventHubName))
            {
                // 100 iterazioni
                const int TotalIterations = 10000;
                for (var i = 0; i < TotalIterations; i++)
                {
                    // Creazione di un batch di eventi
                    using EventDataBatch eventBatch = await producerClient.CreateBatchAsync();

                    //Selezione random
                    var books = layer.FetchAllBooks();
                    var single = RandomizationUtils.GetRandomElement(books);

                    //Creazione del messaggio
                    var message = $"Il libro '{single.Title}' è stato comprato [{i}/{TotalIterations}]";

                    //Codifica del messaggio in bytes
                    var messageAsBytes = Encoding.UTF8.GetBytes(message);

                    //Creo la "scatola" e ci metto il messaggio
                    var scatola = new EventData(messageAsBytes);

                    //Aggiunta dell'elemento al batch
                    eventBatch.TryAdd(scatola);

                    // Use the producer client to send the batch of events to the event hub
                    await producerClient.SendAsync(eventBatch);
                    Console.WriteLine($"Il messaggio è stato INVIATO. [iterazione: {i}/{TotalIterations}]. Attesa di 2 secondi...");
                    await Task.Delay(2000);
                }
            }
        }
    }
}
