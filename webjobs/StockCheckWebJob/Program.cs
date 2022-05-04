using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using System.Configuration;
using System.Threading;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;

namespace StockCheckWebJob
{
    // To learn more about Microsoft Azure WebJobs SDK, please see https://go.microsoft.com/fwlink/?LinkID=320976
    class Program
    {
        // Please set the following connection strings in app.config for this WebJob to run:
        // AzureWebJobsDashboard and AzureWebJobsStorage
        static void Main()
        {
            var config = new JobHostConfiguration();

            if (config.IsDevelopment)
            {
                config.UseDevelopmentSettings();
            }

            var host = new JobHost(config);
            // The following code ensures that the WebJob will be running continuously
            host.RunAndBlock();

            var queue = CloudStorageAccount.Parse(ConfigurationManager.ConnectionStrings["StorageAccount"].ConnectionString)
                            .CreateCloudQueueClient()
                            .GetQueueReference("stockchecks");

            queue.CreateIfNotExists();

            while (true)
            {
                var timestamp = DateTimeOffset.UtcNow.ToString("s");

                var message = new CloudQueueMessage($"Stock check at {timestamp} completed");
                queue.AddMessage(message);

                Thread.Sleep(TimeSpan.FromSeconds(30));
            }
        }
    }
}
