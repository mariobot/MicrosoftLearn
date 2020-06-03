using System;
using Microsoft.Extensions.Configuration;
using System.IO;
using StackExchange.Redis;
using System.Threading.Tasks;
using Newtonsoft.Json;

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

                var stat = new GameStat("Soccer", new DateTime(1950, 7, 16), "FIFA World Cup", 
                new[] { "Uruguay", "Brazil" },
                new[] { ("Uruguay", 2), ("Brazil", 1) });

                string serializedValue = Newtonsoft.Json.JsonConvert.SerializeObject(stat);
                bool added = db.StringSet("event:1950-world-cup", serializedValue);

                var result2 = db.StringGet("event:1950-world-cup");
                var stat2 = Newtonsoft.Json.JsonConvert.DeserializeObject<GameStat>(result2.ToString());
                Console.WriteLine(stat2.Sport); // displays "Soccer"
                
                // LIBERAR CONEXION
                //redisConnection.Dispose();
                //redisConnection = null;

            }
        }
    }
}
