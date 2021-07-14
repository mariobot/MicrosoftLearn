namespace Az.Relay.Client
{
    using System;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Relay;

    class Program
    {
        private const string RelayNamespace = ".servicebus.windows.net";
        private const string ConnectionName = "mb-local";
        private const string KeyName = "RootManageSharedAccessKey";
        private const string Key = "";

        static void Main(string[] args)
        {
            RunAsync().GetAwaiter().GetResult();
        }

        private static async Task RunAsync()
        {
            Console.WriteLine("Enter lines of text to send to the server with ENTER");

            // Create a new hybrid connection client.
            var tokenProvider = TokenProvider.CreateSharedAccessSignatureTokenProvider(KeyName, Key);
            var client = new HybridConnectionClient(new Uri(String.Format("sb://{0}/{1}", RelayNamespace, ConnectionName)), tokenProvider);

            // Initiate the connection.
            var relayConnection = await client.CreateConnectionAsync();

            // Run two concurrent loops on the connection. One 
            // reads input from the console and then writes it to the connection 
            // with a stream writer. The other reads lines of input from the 
            // connection with a stream reader and then writes them to the console. 
            // Entering a blank line shuts down the write task after 
            // sending it to the server. The server then cleanly shuts down
            // the connection, which terminates the read task.

            var reads = Task.Run(async () => {
                // Initialize the stream reader over the connection.
                var reader = new StreamReader(relayConnection);
                var writer = Console.Out;
                do
                {
                    // Read a full line of UTF-8 text up to newline.
                    string line = await reader.ReadLineAsync();
                    // If the string is empty or null, you are done.
                    if (String.IsNullOrEmpty(line))
                        break;
                    // Write to the console.
                    await writer.WriteLineAsync(line);
                }
                while (true);
            });

            // Read from the console and write to the hybrid connection.
            var writes = Task.Run(async () => {
                var reader = Console.In;
                var writer = new StreamWriter(relayConnection) { AutoFlush = true };
                do
                {
                    // Read a line from the console.
                    string line = await reader.ReadLineAsync();
                    // Write the line out, also when it's empty.
                    await writer.WriteLineAsync(line);
                    // Quit when the line is empty.
                    if (String.IsNullOrEmpty(line))
                        break;
                }
                while (true);
            });

            // Wait for both tasks to finish.
            await Task.WhenAll(reads, writes);
            await relayConnection.CloseAsync(CancellationToken.None);
        }
    }
}
