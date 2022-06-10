using System.Threading.Tasks;
using Microsoft.Identity.Client;

namespace microsoft_authentication_library
{
    class Program
    {
        private const string _clientId = "CLIENT-ID";
        private const string _tenantId = "TENANT-ID";

        public static async Task Main(string[] args)
        {
            var app = PublicClientApplicationBuilder
                .Create(_clientId)
                .WithAuthority(AzureCloudInstance.AzurePublic, _tenantId)
                .WithRedirectUri("http://localhost")
                .Build();
            string[] scopes = { "user.read" };
            AuthenticationResult result = await app.AcquireTokenInteractive(scopes).ExecuteAsync();

            Console.WriteLine($"Token:\t{result.AccessToken}");
            Console.WriteLine($"Account:\t{result.Account}");
            Console.WriteLine($"AuthenticationResultMetadata:\t{result.AuthenticationResultMetadata}");
            Console.WriteLine($"ClaimsPrincipal:\t{result.ClaimsPrincipal}");
            Console.WriteLine($"CorrelationId:\t{result.CorrelationId}");
            Console.WriteLine($"Scopes:\t{result.Scopes}");
            Console.WriteLine($"TenantId:\t{result.TenantId}");
            Console.WriteLine($"Scopes:\t{result.Scopes}");
        }
    }
}