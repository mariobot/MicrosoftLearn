## The secret are holding in this route
´´´
%APPDATA%\Microsoft\UserSecrets\<user_secrets_id>\secrets.json
C:\Users\mbotero\AppData\Roaming\Microsoft\UserSecrets
´´´

## Init the secret at your project
´´´
dotnet user-secrets init
´´´

## Set app a secret
´´´
dotnet user-secrets set "Movies:ServiceApiKey" "12345"
´´´

## Set app a secret at different route
´´´
dotnet user-secrets set "Movies:ServiceApiKey" "12345" --project "C:\apps\WebApp1\src\WebApp1"
´´´

## Recovery a secret
´´´
    public void ConfigureServices(IServiceCollection services)
    {
        _moviesApiKey = Configuration["Movies:ServiceApiKey"];
    }
´´´

## Using POCO secrets
´´´
var moviesConfig = Configuration.GetSection("Movies")
                                .Get<MovieSettings>();
_moviesApiKey = moviesConfig.ServiceApiKey;
´´´

### Remove a secret
´´´
dotnet user-secrets remove "Movies:ConnectionString"
´´´

### Clear all secrets
´´´
dotnet user-secrets clear
´´´