Login to Azure
```bash
az login
```

Create a resource group
```bash
az group create --location centralus --name az204-cosmos-rg
```

Create the cosmos db resource
```bash
az cosmosdb create --name <myCosmosDBacct> --resource-group az204-cosmos-rg
```

Retrieve the cosmos db connection string
```bash
az cosmosdb keys list --name <myCosmosDBacct> --resource-group az204-cosmos-rg
```

Run the project
```bash
dotnet run
```

Delete the resource group
```bash
az group delete --name az204-cosmos-rg --no-wait
```
