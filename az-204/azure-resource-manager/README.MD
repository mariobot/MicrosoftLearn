In this chapter will be to configure and deploy using Azure resource manager templates

Login in Azure.

```bash
az login
```

Create a resource group.

```bash
az group create --name az204-arm-rg --location centralus
```

Execute the command az deplyment group create to use the template. The execution will be take some minutes, progress will be display in the terminal.

```bash
az  deployment group create --resource-group az204-arm-rg --template-file azuredeploy.json --parameters azuredeploy.parameters.json
```

Execute the command to show the implementation. replace the name with the parameter defined in the script.

```bash
az storage account show --resource-group az204-arm-rg --name az204storagembotero
```

Delete the resource

```bash
az group delete --name az204-arm-rg --no-wait
```

