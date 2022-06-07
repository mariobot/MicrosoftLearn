Execute the next command to create the blob storage with Azure CLI

Login to azure
```bash
az login
```

Create a resource group with the name az204-blob-rg
```bash
az group create --location centralus --name az204-blob-rg
```

Create a storage account 
```bash
az storage account create --resource-group az204-blob-rg --name <myStorageAcct> --location centralus --sku Standard_LRS
```

Get the credentials of your storage account login to az portal and navigate to configuration option. 

run the project with
```bash
dotnet run
```

Finally delete the resource group
```bash
az group delete --name az204-blob-rg --no-wait
```