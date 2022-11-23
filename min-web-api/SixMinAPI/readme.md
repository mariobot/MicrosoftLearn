#.NET 6 Minimal API Full Build

This is the original video tutorial: https://www.youtube.com/watch?v=5YB49OEmbbE&t=5017s

In this step by step video we perform a full step by step build of a .NET 6 minimal API. We also contrast and compare it with a MVC API to further understand the differences and similarities between them.

## Final endpoints

´´´
GET https://localhost:7087/api/v1/commands
GET https://localhost:7087/api/v1/commands/1

POST https://localhost:7087/api/v1/commands
{
    "id": 3,
    "howTo": "Build a dotnet app",
    "platform": ".NET",
    "commandLine": "dotnet build"
}

PUT https://localhost:7087/api/v1/commands/2
{
    "howTo": "Build a dotnet app",
    "platform": ".NET6",
    "commandLine": "dotnet build"
}

DELETE https://localhost:7087/api/v1/commands/1
´´´