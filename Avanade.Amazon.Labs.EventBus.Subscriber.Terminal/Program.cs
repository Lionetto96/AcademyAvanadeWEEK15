using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Processor;
using Azure.Storage.Blobs;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Avanade.Amazon.Labs.EventBus.Subscriber.Terminal
{
    class Program
    {
        private const string connectionString = "Endpoint=sb://maurobussini.servicebus.windows.net/;" + 
            "SharedAccessKeyName=ListenPolicy;" + 
            "SharedAccessKey=/BSd9PgI6J3Rp9osLvWoyfph6T4Mi0vzH/eVtz1jJZQ=;" + 
            "EntityPath=sample";
        private const string eventHubName = "sample";

        //ATTENZIONE! Ricordarsi di creare il container nello storage account prima di avviare
        //perchè questa demo non lo crea automaticamente
        private const string blobContainerName = "eventhub-sample-bookmarks";

        private const string blobStorageConnectionString = "DefaultEndpointsProtocol=https;" +
                "AccountName=maurobussini;" +
                "AccountKey=mCxVdmUKxGhL5gURfJuXqa5O8qV5CJJbXmJK0Pg9h7rQuxkSHSBiMv0/hWHrbOIoK4zmfpvuySV07ILAn1rDCA==;" +
                "EndpointSuffix=core.windows.net";

        static async Task Main()
        {
            // Read from the default consumer group: $Default
            string consumerGroup = EventHubConsumerClient.DefaultConsumerGroupName;

            // Create a blob container client that the event processor will use 
            BlobContainerClient storageClient = new BlobContainerClient(blobStorageConnectionString, blobContainerName);

            // Create an event processor client to process events in the event hub
            EventProcessorClient processor = new EventProcessorClient(storageClient, consumerGroup, connectionString, eventHubName);

            // Register handlers for processing events and handling errors
            processor.ProcessEventAsync += ProcessEventHandler;
            processor.ProcessErrorAsync += ProcessErrorHandler;

            // Start the processing
            await processor.StartProcessingAsync();

            // Wait for 10 seconds for the events to be processed
            await Task.Delay(TimeSpan.FromSeconds(360));

            // Stop the processing
            await processor.StopProcessingAsync();
        }

        static Task ProcessEventHandler(ProcessEventArgs eventArgs)
        {
            // Write the body of the event to the console window
            Console.WriteLine("Ricevuto evento: {0}", Encoding.UTF8.GetString(eventArgs.Data.Body.ToArray()));
            return Task.CompletedTask;
        }

        static Task ProcessErrorHandler(ProcessErrorEventArgs eventArgs)
        {
            // Write details about the error to the console window
            Console.WriteLine($"\tPartition '{eventArgs.PartitionId}': an unhandled exception was encountered. This was not expected to happen.");
            Console.WriteLine(eventArgs.Exception.Message);
            return Task.CompletedTask;
        }
    }
}
