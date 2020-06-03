using System;
using Microsoft.Extensions.Configuration;
using System.IO;
using StackExchange.Redis;
using System.Threading.Tasks;

namespace SportsStatsTracker
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Start Redis Cache APP!");

            var config = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json")
                            .Build();
            
            string connectionString = config["CacheConnection"];

            using (var cache = ConnectionMultiplexer.Connect(connectionString))
            {
                IDatabase db = cache.GetDatabase();

                // HACE SET DE UN VALOR
                bool setValue = await db.StringSetAsync("test:key", "some value");
                Console.WriteLine($"SET: {setValue}");

                // HACE GET DE UN VALOR
                string getValue = await db.StringGetAsync("test:key");
                Console.WriteLine($"GET: {getValue}");                

                // ESTE VALOR FUE DEFINIDO EN CONSOLA FUERA DEL CONTEXTO
                string getValue2 = await db.StringGetAsync("mariobot");
                Console.WriteLine($"GET: {getValue2}");

                // INCREMENTA UN VALOR
                long newValue = await db.StringIncrementAsync("counter", 50);
                Console.WriteLine($"INCR new value = {newValue}");

                // EJECUTA PING
                var result = await db.ExecuteAsync("ping");
                Console.WriteLine($"PING = {result.Type} : {result}");

                // RESTABLECE TODA LA INTANCIA DE REDIS ELIMINA TODO
                result = await db.ExecuteAsync("flushdb");
                Console.WriteLine($"FLUSHDB = {result.Type} : {result}");

            }
        }
    }
}
